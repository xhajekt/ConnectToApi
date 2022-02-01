using ConnectToApi.BL.Result;
using ConnectToApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectToApi.BL.API;

namespace ConnectToApi.Orchestrator
{
    public class RegisterOrchestrator : IRegisterOrchestrator
    {
        public async Task<ResultOrchestrator> RegisterAsync(byte[] fileBytes, string memberName, string watchListName)
        {
            ResultOrchestrator result = new();

            var createWatchlistMemberRequest = new CreateWatchlistMemberRequest(memberName);
            var createWatchlistMemberResponse = await createWatchlistMemberRequest.ExecuteAsync();

            if (!createWatchlistMemberResponse.IsSuccess)
            {
                result.ErrorMessage = $"not success creation of member: {memberName}";
                return result;
            }

            var linkMemberToWatchListRequest = new LinkMemberToWatchListRequest(createWatchlistMemberResponse.WatchlistMemberId, watchListName);
            var linkMemberToWatchListResponse = await linkMemberToWatchListRequest.ExecuteAsync();

            if (!createWatchlistMemberResponse.IsSuccess)
            {
                result.ErrorMessage = $"not success link member: {memberName} to watchlist: {watchListName}";
                //and maybe delete createWatchlistMemberResponse.watchlistMembersId
                return result;
            }

            //no idea where to put picture and get its id
            Guid faceId = new Guid();

            var addFacetoMemberRequest = new AddFacetoMemberRequest(createWatchlistMemberResponse.WatchlistMemberId, faceId);
            var addFacetoMemberResponse = await addFacetoMemberRequest.ExecuteAsync();

            if (!addFacetoMemberResponse.IsSuccess)
            {
                result.ErrorMessage = $"not success link watchlistMembersId {createWatchlistMemberResponse.WatchlistMemberId} with faceId {faceId}";
                //and maybe undo all requestes higher
            } 
            return result;
        }
    }
}
