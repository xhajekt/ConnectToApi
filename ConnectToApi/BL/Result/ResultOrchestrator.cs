using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectToApi.BL.Result
{
    public class ResultOrchestrator
    {
        public bool IsSuccess
        {
            get { return string.IsNullOrEmpty(ErrorMessage); }
        }

        public string ErrorMessage { get; set; }
    }
}
