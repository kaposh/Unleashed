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
        /// <summary>
        /// Implementation of RestApiClient
        /// </summary>
        /// <param name="apiHostUri">Base uri of endpoint</param>
        public RestApiClient(string apiHostUri)
        {
            ApiHostUri = apiHostUri;
        }

        public string ApiHostUri {get;set;}

        private RestClient Client => new RestClient(ApiHostUri);

        public override ApiResponse Get(string uri)
        {
            RestRequest request = new RestRequest(uri, Method.GET);
            var response = Client.Execute(request);
            return new ApiResponse() { Content = response.Content, StatusCode = response.StatusCode};
        }

        public override ApiResponse Get(string uri, Dictionary<string, string> headers)
        {
            RestRequest request = new RestRequest(uri, Method.GET);
            request = AddHeaders(request, headers);
            var response = Client.Execute(request);
            return new ApiResponse() { Content = response.Content, StatusCode = response.StatusCode };
        }

        public override ApiResponse Post(string uri, string data)
        {
            RestRequest request = new RestRequest(uri, Method.POST);
            request.AddParameter("application/json; charset=utf-8", data, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = Client.Execute(request);
            return new ApiResponse() { Content = response.Content, StatusCode = response.StatusCode };
        }

        public override ApiResponse Post(string uri, string data, Dictionary<string, string> headers)
        {
            RestRequest request = new RestRequest(uri, Method.POST);
            request.AddParameter("application/json; charset=utf-8", data, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            request = AddHeaders(request, headers);
            var response = Client.Execute(request);
            return new ApiResponse() { Content = response.Content, StatusCode = response.StatusCode };
        }

        public override Uri BuildRequestFullUri(string uri)
        {
            RestRequest request = new RestRequest(uri);
            return Client.BuildUri(request);
        }

        /// <summary>
        /// Add headers to request
        /// </summary>
        /// <param name="request">Rest request</param>
        /// <param name="headers">Dictionary of headers to be added</param>
        /// <returns>Updated request</returns>
        private RestRequest AddHeaders(RestRequest request, Dictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }
            return request;
        }
    }
}
