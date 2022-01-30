using ConnectToApi.BL.Result;
using ConnectToApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectToApi.Orchestrator
{
    public class RegisterOrchestrator : IRegisterOrchestrator
    {
        public async Task<ResultOrchestrator> RegisterAsync(byte[] fileBytes, string memberName, string watchListName)
        {
            await Task.Delay(1);
            return new ResultOrchestrator();
        }
    }
}
