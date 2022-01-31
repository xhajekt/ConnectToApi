using ConnectToApi.BL.API;
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
            ResultSpecificOrchestrator<SearchResultViewModel> result = new ResultSpecificOrchestrator<SearchResultViewModel>();

            string encodedImage = System.Text.Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
            var searchImageRequest = new FacesSearchRequest(encodedImage, treshold, maxFaceSize, minFaceSize);
            var facesSearchResponse = await searchImageRequest.ExecuteAsync();

            if (!facesSearchResponse.IsSuccess)
            {
                result.ErrorMessage = "face wasnt found in images search";
                return result;
            }

            //continue search in watchlistMember by FaceId and watchlistName  - no idea witch method

            result.ErrorMessage = "method is not implemented";
            return result;
        }
    }
}
