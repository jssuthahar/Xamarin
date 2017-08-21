using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
 namespace AzureFunctionsDemo
{
   public class AzureFunctionHelper
    {
        // Remember to paste below your Azure Function url copied before in the Portal:
        const string AZURE_FUNCTION_URL = "https://devenvexefunctiondemo.azurewebsites.net/api/HttpTriggerCSharp1";
        // Remember to paste below your Azure Function Key copied before in the Portal:
        const string AZURE_CODE = "fnNK7ncbR3QKAgMgXAaV1gnPMgaPaqUTH3mbv7gi9nM9zt7yJImeng==";
        /// <summary>
        ///Get Azure Functions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>

        public async Task<object> GetAsync<T>(string value)
        {
            var httpClient = new HttpClient();
            Dictionary<string, string> query = new Dictionary<string, string>();
            query["code"] = AZURE_CODE;
            query["name"] = value;
            Uri uri = new Uri(AZURE_FUNCTION_URL).BuildQueryString(query);
            var content = await httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject(content);
        }

    }
    public static class Common
    {
        /// <summary>
        /// BuildQueryString
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Uri BuildQueryString(this Uri uri, Dictionary<string, string> parameters)
        {
            var stringBuilder = new StringBuilder();
            string str = "?";
            foreach (KeyValuePair<string, string> item in parameters)
            {
                stringBuilder.Append(str + item.Key + "=" + item.Value);
                str = "&";
            }

            return new Uri(uri + stringBuilder.ToString());
        }
    }
}
