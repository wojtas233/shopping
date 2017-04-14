using Autofac;
using Shopping.DataAccess.Entities;
using Shopping.DataAccess.Repositories;
using Shopping.DataAccess.Repositories.Interfaces;
using System;
using System.ComponentModel;
using Shopping.DataAccess.Entities;

namespace Shopping.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private DataContext _dbContext;
        private readonly Autofac.IContainer _applicationContainer;

        public IRepository<Client> Clients => new GenericRepository<Client>(_dbContext);
        public IRepository<SystemLanguage> SystemLanguages => new GenericRepository<SystemLanguage>(_dbContext);
        public ISystemParameterRepository SystemParameters { get; set; }

        public UnitOfWork(DataContext dbContext, ISystemParameterRepository systemParameters)
        {            
            _dbContext = dbContext;
            SystemParameters = systemParameters;
        }
        
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
