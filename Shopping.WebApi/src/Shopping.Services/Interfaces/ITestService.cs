using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.DataObjects.Models.Api.Questionnaire;
using Shopping.Services.Models;

namespace Shopping.Services.Interfaces
{
    public interface ITestService
    {
        string HelloWorld();
        IList<ClientModel> GetCliens();
        Task<IList<QuestionnaireModel>> GetQuestionnaires();
    }
}
