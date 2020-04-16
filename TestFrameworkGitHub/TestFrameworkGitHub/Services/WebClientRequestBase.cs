using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkGitHub.Services
{
    public class WebClientRequestBase
    {
        protected GitHubWebClient _client;

        protected WebClientRequestBase (string baseUri, string token)
        {
            _client = new GitHubWebClient();
            _client.BaseAddress = baseUri;
            _client.Headers.Add("Authorization", $"Bearer {token}");
        }

        protected T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        protected T Get<T>(string resourceEndPoint) where T: class
        {
            var response = _client.DownloadString(resourceEndPoint);
            T deserializedResponse = Deserialize<T>(response);
            return deserializedResponse;
        }

        protected T Post<T>(string resourceEndPoint, string dataToUpload) where T : class
        {
            var response = _client.UploadString($"{resourceEndPoint}", "POST", dataToUpload);
            T deserializedResponse = Deserialize<T>(response);
            return deserializedResponse;
        }

        protected void Delete(string resourceEndPoint, string data="")
        {
            var response = _client.UploadString(resourceEndPoint, "DELETE", data);
        }
    }
}

