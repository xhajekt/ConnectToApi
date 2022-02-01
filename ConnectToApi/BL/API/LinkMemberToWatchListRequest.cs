using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToApi.BL.API
{
    internal class LinkMemberToWatchListRequest : RequestBase
    {
        private readonly string _watchlistMemberId;
        private readonly string _watchListName;
        private string _watchlistId;

        public LinkMemberToWatchListRequest(string watchlistMemberId, string watchListName)
        {
            _watchlistMemberId = watchlistMemberId;
            _watchListName = watchListName;
        }

        public async Task<LinkMemberToWatchListResponse> ExecuteAsync()
        {
            LinkMemberToWatchListResponse result = new();

            //POST    /api/v1/Watchlists/Search retunrs WatchlistId by watchListName
            _watchlistId = "someFakeId";

            using (var message = new HttpRequestMessage(HttpMethod.Post, "/api/v1/WatchlistMembers/LinkToWatchlist"))
            {
                string body = GetRequestBody();
                message.Content = new StringContent(body, Encoding.UTF8, "text/json");

                HttpResponseMessage response = await ClientInstance.SendAsync(message).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    result.IsSuccess = true;
                }
                else
                {
                    result.IsSuccess = false;
                }
            }

            return result;
        }

        private string GetRequestBody()
        {
            RequestMemberLinkToWatchlist requestMemberLinkToWatchlist = new RequestMemberLinkToWatchlist()
            {
                WatchlistId = _watchlistId,
                WatchlistMembersIds = new List<string>()
            };
            requestMemberLinkToWatchlist.WatchlistMembersIds.Add(_watchlistMemberId);
            return JsonConvert.SerializeObject(requestMemberLinkToWatchlist);
        }
        internal class RequestMemberLinkToWatchlist
        {
            public string WatchlistId { get; set; }
            public List<string> WatchlistMembersIds { get; set; }
        }
    }

}