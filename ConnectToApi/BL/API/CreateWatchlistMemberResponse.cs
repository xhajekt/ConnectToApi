using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectToApi.BL.API
{
    public class CreateWatchlistMemberResponse
    {
        [JsonProperty(PropertyName = "id")]
        public string WatchlistMemberId { get; set; }

        public string DisplayName { get; set; }
        public string FullName { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public bool IsSuccess { get; set; }
    }
}
