using ConnectToApi.BL.Result;
using ConnectToApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectToApi.Orchestrator
{
    public class SearchOrchestrator : ISearchOrchestrator
    {
        public async Task<ResultSpecificOrchestrator<SearchResultViewModel>> SearchByParamsAsync(byte[] fileBytes, string watchlistName, int treshold, int maxFaceSize, int minFaceSize)
        {
            await Task.Delay(1);
            ResultSpecificOrchestrator<SearchResultViewModel> result = new ResultSpecificOrchestrator<SearchResultViewModel>();
            result.ErrorMessage = "method is not implemented";
            return result;
        }
    }
}
