using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopping.Services.Interfaces;

namespace Shopping.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ITestService _testService;

        public ValuesController(ITestService testService)
        {
            _testService = testService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", _testService.HelloWorld() };
        }
    }
}
