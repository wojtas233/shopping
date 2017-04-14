using Shopping.DataObjects.Models.Api.Questionnaire;
using Shopping.DataObjects.POCO;
using Shopping.External.Consts.Questionnaire;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Shopping.External.ApiServices
{
    public class QuestionnaireService
    {
        private readonly ExternalApi _externalApi;
        private readonly ILogger<QuestionnaireService> _logger;

        public QuestionnaireService(ILogger<QuestionnaireService> logger, IOptions<ExternalApi> externalApi)
        {
            _externalApi = externalApi.Value;
            _logger = logger;
        }

        public async Task<List<QuestionnaireModel>> GetQuestionnaires()
        {
            using (HttpClient httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync($"{_externalApi.Questionnaire}{UriConsts.GetQuestionnaires}");
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<QuestionnaireModel>>(await response.Content.ReadAsStringAsync());
                }

                _logger.LogError(new EventId(), response.StatusCode.ToString());
                return null;
            }
        }
    }
}
