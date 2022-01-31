using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static ConnectToApi.BL.Enums;

namespace ConnectToApi.BL.API
{
    public class FacesSearchRequest : RequestBase
    {
        private readonly string _encodedImage;
        private readonly int _treshold;
        private readonly int _maxFaceSize;
        private readonly int _minFaceSize;

        public FacesSearchRequest(string encodedImage, int treshold, int maxFaceSize, int minFaceSize)
        {
            _encodedImage = encodedImage;
            _treshold = treshold;
            _maxFaceSize = maxFaceSize;
            _minFaceSize = minFaceSize;
        }

        public async Task<FacesSearchResponse> ExecuteAsync()
        {
            FacesSearchResponse result = new();

            //System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            using (var message = new HttpRequestMessage(HttpMethod.Post, "/api/v1/Faces/Search"))
            {
                //message.Headers.Add("Authorization", hash);
                var body = GetRequestBody();
                message.Content = new StringContent(body, Encoding.UTF8, "text/json");

                HttpResponseMessage response = await ClientInstance.SendAsync(message).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<FacesSearchResponse>(response.Content.ReadAsStringAsync().Result);
                    result.IsSuccess = true;
                }
                else
                {
                    result.IsSuccess = false;
                }
            }

            return result;
        }

        //I know, enum returns number,not string, but for me its more usual
        private string GetRequestBody()
        {
            RequestSearch requestSearch = new RequestSearch
            {
                FaceDetectorConfig = new FaceDetectorConfig() { ConfidenceTreshold = 450, MaxFaceSize = _maxFaceSize, MinFaceSize = _minFaceSize },
                FaceDetectorResourceId = FaceDetectorResourceId.cpu,
                TemplateGeneratorResourceId = TemplateGeneratorResourceId.gpu,
                Image = new ImageType() { Data = _encodedImage },
                Treshold = _treshold
            };
            return JsonConvert.SerializeObject(requestSearch);
        }

        private class RequestSearch
        {
            public ImageType Image { get; set; }
            public int Treshold { get; set; }
            public FaceDetectorConfig FaceDetectorConfig { get; set; }
            public FaceDetectorResourceId FaceDetectorResourceId { get; set; }
            public TemplateGeneratorResourceId TemplateGeneratorResourceId { get; set; }
        }

        private class FaceDetectorConfig
        {
            public int MinFaceSize { get; set; }
            public int MaxFaceSize { get; set; }
            public int ConfidenceTreshold { get; set; }
        }

        private class ImageType
        {
            public string Data { get; set; }
        }



    }
}
