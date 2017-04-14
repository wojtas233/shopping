using Shopping.Common.Interfaces;
using Shopping.DataAccess.Entities;
using Shopping.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Logging;
using Shopping.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;

namespace Shopping.DataAccess.Repositories
{
    public class SystemParameterRepository : ISystemParameterRepository
    {
        private readonly DataContext _context;
        private readonly ITimeProvider _timeProvider;
        private readonly ILogger<ISystemParameterRepository> _logger;
        private readonly DbSet<SystemParameterValue> _entities;

        public SystemParameterRepository(DataContext context, ITimeProvider timeProvider, 
            ILogger<ISystemParameterRepository> logger)
        {
            _context = context;
            _timeProvider = timeProvider;            
            _logger = logger;
            _entities = _context.Set<SystemParameterValue>();
        }

        public T GetValue<T>(string code)
        {
            var value = (from sp in _context.Set<SystemParameter>()
                         join spv in _context.Set<SystemParameterValue>() on sp.Id equals spv.SystemParameterId
                         where sp.Code == code
                         && spv.IsActive
                         && (!spv.ValidFrom.HasValue || spv.ValidFrom < _timeProvider.Now())
                         && (!spv.ValidTo.HasValue || spv.ValidTo > _timeProvider.Now())
                         select spv.Value).FirstOrDefault();

            return (T)Convert.ChangeType(value, typeof(T));
        }

        public SaveResult AddValue<T>(string code, T value, string description, DateTime? validFrom, DateTime? validTo, bool isActive = true)
        {
            try
            { 
                var existingEntity = _context.Set<SystemParameter>().Where(s => s.Code == code).FirstOrDefault();

                if (existingEntity == null)
                {
                
                    var language = _context
                        .Set<SystemLanguage>()
                        .FirstOrDefault(s => s.Code == "en-US");

                    var systemTranslation = new SystemTranslation()
                    {
                        SystemLanguage = language,
                        Text = description
                    };

                    var systemParameter = new SystemParameter()
                    {
                        Code = code,
                        SystemTranslation = systemTranslation,
                    };

                    var systemParameterValue = new SystemParameterValue()
                    {
                        SystemParameter = systemParameter,
                        ValidFrom = validFrom,
                        ValidTo = validTo,
                        IsActive = isActive,
                        Value = value.ToString(),
                    };

                    _entities.Add(systemParameterValue);
                    
                }               
                else
                {
                    var systemParameterValue = new SystemParameterValue()
                    {
                        SystemParameter = existingEntity,
                        ValidFrom = validFrom,
                        ValidTo = validTo,
                        IsActive = isActive,
                        Value = value.ToString(),
                    };

                    _entities.Add(systemParameterValue);
                    var existingValues = _entities.Where(s => s.SystemParameterId == existingEntity.Id).ToList();
                    existingValues.ForEach(s => s.IsActive = false);                    
                }

                _context.SaveChanges();

                return new SaveResult();
            }
            catch (Exception e)
            {
                _logger.LogError(new EventId(), e, string.Empty);
                return new SaveResult("Error");
            }
        }        
    }
}
