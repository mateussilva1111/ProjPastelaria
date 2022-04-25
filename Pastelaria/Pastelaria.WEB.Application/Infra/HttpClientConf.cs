using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Routing;

namespace Pastelaria.WEB.Application.Infra
{
    public static class HttpClientConf
    {
        private static HttpClient _httpClient;

        public static HttpClient HttpClientConfig(string controller)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"http://localhost:52830/api/{controller}/");
            _httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));

            return _httpClient;
        }

        public static Uri HttpClientConfigGet(string url, object parameters)
        {
            _httpClient = new HttpClient();
            var builder = new UriBuilder($"http://localhost:52830/api/{url}/");
            var param = string.Empty;
            foreach (var parameter in new RouteValueDictionary(parameters))
                param += $"{parameter.Key}={parameter.Value}&";

            builder.Query = param;
            return builder.Uri;
        }

        public static HttpContent Content<T>(T obj)
        {
            if (obj == null)
                return new StringContent(string.Empty);

            return new ObjectContent<T>(obj, new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new DefaultContractResolver
                    {
                        IgnoreSerializableAttribute = true
                    }
                }
            });
        }
    }
}
