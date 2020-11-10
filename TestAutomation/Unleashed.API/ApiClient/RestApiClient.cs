using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace APIClient 
{
    public class RestApiClient : ApiClient
    {
        public RestApiClient(string apiId, string apiKey)
        {
            ApiId = apiId;
            ApiKey = apiKey;
        }
        private string ApiHost = "https://api.unleashedsoftware.com";
        private string ApiId {get;set;}
        private string ApiKey { get; set; }
        private RestClient Client => new RestClient(ApiHost);

        public override ApiResponse Get(string uri)
        {
            RestRequest request = new RestRequest(uri, Method.GET);
            SetAuthenticationHeaders(request);
            var response = Client.Execute(request);
            return new ApiResponse() { Content = response.Content, StatusCode = response.StatusCode};
        }

        public override ApiResponse Post(string uri, string data)
        {
            RestRequest request = new RestRequest(uri, Method.POST);
            request.AddParameter("application/json; charset=utf-8", data, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            SetAuthenticationHeaders(request);
            var response = Client.Execute(request);
            return new ApiResponse() { Content = response.Content, StatusCode = response.StatusCode };
        }

        private void SetAuthenticationHeaders(RestRequest request)
        {
            var arguments = GetArgumentsString(request);
            string signature = GetSignature(arguments, ApiKey);
            request.AddHeader("api-auth-id", ApiId);
            request.AddHeader("api-auth-signature", signature);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json; charset=Windows-1252");
        }

        private string GetArgumentsString(RestRequest request)
        {
            var requestUriParts =Client.BuildUri(request).ToString().Split('?');
            return requestUriParts.Length > 1 ? requestUriParts[requestUriParts.Length - 1] : "";
        }

        private static string GetSignature(string args, string privateKey)
        {
            var encoding = new System.Text.UTF8Encoding();
            byte[] key = encoding.GetBytes(privateKey);
            var myhmacsha256 = new HMACSHA256(key);
            byte[] hashValue = myhmacsha256.ComputeHash(encoding.GetBytes(args));
            string hmac64 = Convert.ToBase64String(hashValue);
            myhmacsha256.Clear();
            return hmac64;
        }
    }
}
