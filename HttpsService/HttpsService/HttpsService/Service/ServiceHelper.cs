using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpsService
{
    public class ServiceHelper
    {
        //if you are using local Hosting or on premises with self signed certficate, 
        //in IOS add domain host address and Android use IP ADDRESS
         
        const string SERVICE_BASE_URL = "https://devenvexe.com"; //replace base address 
        const string SERVICE_RELATIVE_URL = "/my/api/path";
        public ServiceHelper()
        {
        }
        public Task<string> GetDataAsync()
        {
            return GetDataAsync(SERVICE_BASE_URL, SERVICE_RELATIVE_URL);
        }
        private async Task<string> GetDataAsync(string baseUrl, string relUrl)
        {
            var uri = new Uri(relUrl, UriKind.Relative);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = uri
            };

            var client = GetHttpClient(baseUrl);

            HttpResponseMessage response = null;

            try
            {
                response = await client.GetAsync(request.RequestUri, HttpCompletionOption.ResponseHeadersRead);
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        HttpClient GetHttpClient(string baseUrl)
        {
            var handler = new HttpClientHandler
            {
                UseProxy = true,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };

            client.DefaultRequestHeaders.Connection.Add("keep-alive");
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

            return client;
        }
    }
}
