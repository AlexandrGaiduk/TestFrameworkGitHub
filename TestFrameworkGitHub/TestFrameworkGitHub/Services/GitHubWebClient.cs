using System;
using System.Net;

namespace TestFrameworkGitHub.Services
{
    public class GitHubWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            request.UserAgent = "application/jsonMozilla/5.0 (Linux; Android 7.0; SM-G930VC Build/NRD90M; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/58.0.3029.83 Mobile Safari/537.36";
            request.ContentType = "application/json";
            return request;
        }
    }
}
