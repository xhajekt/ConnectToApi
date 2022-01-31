using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConnectToApi.BL.API
{
    public class RequestBase
    {
        private static HttpClient _httpClient;
        private static object _lock = new();

        public static HttpClient ClientInstance
        {
            get
            {
                if (_httpClient == null)
                {
                    lock (_lock)
                    {
                        if (_httpClient == null)
                        {
                            _httpClient = new HttpClient
                            {
                                //url should be loaded from same safety place/online config
                                BaseAddress = new Uri("localhost:8098"),
                            };
                            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        }
                    }
                }

                return _httpClient;
            }
        }
    }
}
