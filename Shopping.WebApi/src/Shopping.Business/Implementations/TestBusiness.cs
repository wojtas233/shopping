using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.Business.Interfaces;

namespace Shopping.Business.Implementations
{
    public class TestBusiness : ITestBusiness
    {
        public string GetTestName()
        {
            return "test value";
        }
    }
}
