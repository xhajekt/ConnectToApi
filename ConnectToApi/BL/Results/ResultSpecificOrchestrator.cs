using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectToApi.BL.Result
{
    public class ResultSpecificOrchestrator<T> : ResultOrchestrator
    {
        public T ReturnValue { get; set; }
    }
}
