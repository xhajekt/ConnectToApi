using ConnectToApi.BL.Result;
using ConnectToApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectToApi.Orchestrator
{
    public interface IRegisterOrchestrator
    {
        Task<ResultOrchestrator> RegisterAsync(byte[] fileBytes, string memberName, string watchListName);
    }
}
