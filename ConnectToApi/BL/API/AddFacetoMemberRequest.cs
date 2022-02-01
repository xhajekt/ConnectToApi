using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToApi.BL.API
{
    internal class AddFacetoMemberRequest : RequestBase
    {
        private readonly string _watchlistMemberId;
        private readonly Guid _faceId;

        public AddFacetoMemberRequest(string watchlistMemberId, Guid faceId)
        {
            _watchlistMemberId = watchlistMemberId;
            _faceId = faceId;
        }

        public async Task<AddFacetoMemberResponse> ExecuteAsync()
        {
            AddFacetoMemberResponse result = new();

            using (var message = new HttpRequestMessage(HttpMethod.Post, $"/api/v1/WatchlistMembers/{_watchlistMemberId}/AddFaceFromSystem"))
            {
                string body = GetRequestBody();
                message.Content = new StringContent(body, Encoding.UTF8, "text/json");

                var response = await ClientInstance.SendAsync(message).ConfigureAwait(false);

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
            RequestAddFacetoMember requestAddFacetoMember = new RequestAddFacetoMember()
            {
                FaceId = _faceId
            };
            return JsonConvert.SerializeObject(requestAddFacetoMember);
        }

        internal class RequestAddFacetoMember
        {
            public Guid FaceId { get; internal set; }
        }
    }

}