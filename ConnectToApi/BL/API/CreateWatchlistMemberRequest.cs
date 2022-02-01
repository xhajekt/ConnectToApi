using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToApi.BL.API
{
    public class CreateWatchlistMemberRequest : RequestBase
    {
        private readonly string _memberName;

        public CreateWatchlistMemberRequest(string memberName)
        {
            _memberName = memberName;
        }

        public async Task<CreateWatchlistMemberResponse> ExecuteAsync()
        {
            CreateWatchlistMemberResponse result = new();

            using (var message = new HttpRequestMessage(HttpMethod.Post, "/api/v1/WatchlistMembers"))
            {
                //message.Headers.Add("Authorization", hash);
                var body = GetRequestBody();
                message.Content = new StringContent(body, Encoding.UTF8, "text/json");

                HttpResponseMessage response = await ClientInstance.SendAsync(message).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<CreateWatchlistMemberResponse>(response.Content.ReadAsStringAsync().Result);
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
            RequestCreateMember requestCreateMember = new RequestCreateMember
            {
                DisplayName = _memberName,
                FullName = _memberName,
                Note = ""
            };
            return JsonConvert.SerializeObject(requestCreateMember);
        }

        private class RequestCreateMember
        {
            public string DisplayName { get; set; }
            public string FullName { get; set; }
            public string Note { get; set; }
        }

    }
}
