using ConnectToApi.BL.Result;
using ConnectToApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectToApi.Orchestrator
{
    public interface ISearchOrchestrator
    {
        Task<ResultSpecificOrchestrator<SearchResultViewModel>> SearchByParamsAsync(byte[] fileBytes, string watchlistName, int treshold, int maxFaceSize, int minFaceSize);
    }
}
