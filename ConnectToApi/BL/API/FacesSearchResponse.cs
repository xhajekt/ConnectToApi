using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectToApi.BL.API
{
    public class FacesSearchResponse
    {
        [JsonProperty(PropertyName = "searchSessionId")]
        public string FaceId { get; set; }

        public bool IsSuccess { get; set; }
    }
}
