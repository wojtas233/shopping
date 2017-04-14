using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Common.Models
{
    public class SaveResult
    {
        public SaveResult()
        {
            Success = true;
        }

        public SaveResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Success = false;
        }
        
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
