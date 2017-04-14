using Shopping.DataAccess;
using Shopping.DataAccess.Entities;
using Shopping.Services.Interfaces;
using Shopping.Services.Models;
using ExpressMapper;
using ExpressMapper.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Shopping.DataObjects.Models.Api.Questionnaire;
using System.Threading.Tasks;
using Shopping.External.ApiServices;

namespace Shopping.Services.Implementations
{
    public class TestService : ITestService
    {
        private readonly ILogger<ITestService> _logger;
        private readonly UnitOfWork _unitOfWork;
        private readonly QuestionnaireService _questionnaireService;

        public TestService(ILogger<ITestService> logger, UnitOfWork unitOfWork, QuestionnaireService questionnaireService)
        {
            logger.LogInformation("Test service started");
            _logger = logger;
            _unitOfWork = unitOfWork;
            _questionnaireService = questionnaireService;

        }
        public string HelloWorld()
        {
            var a = new TestModelA()
            {
                Id = 4,
                Name = "Hello World!"
            };

            var b = new TestModelB();
            a.Map(b);

            try
            {
                int number0 = 0;
                int result = 5 / number0;
            }
            catch(Exception e)
            {
                _logger.LogError(new EventId(), e, string.Empty);
            }

            return b.Name;
        }

        public IList<ClientModel> GetCliens()
        {
            return Mapper.Map<IList<Client>, IList<ClientModel>>(_unitOfWork.Clients.GetAll().ToList());
        }

        public async Task<IList<QuestionnaireModel>> GetQuestionnaires()
        {
            return await _questionnaireService.GetQuestionnaires();
        }
    }
}
