using System;
using System.Collections.Generic;

namespace APIClient
{
    public abstract class ApiClient
    {
        /// <summary>
        /// Get REST API call
        /// </summary>
        /// <param name="uri">API call uri</param>
        /// <returns>ApiResponse with content and exit code</returns>
        public abstract ApiResponse Get(string uri);
        /// <summary>
        /// Get REST API call
        /// </summary>
        /// <param name="uri">API call uri</param>
        /// <param name="headers">API call headers</param>
        /// <returns>ApiResponse with content and exit code</returns>
        public abstract ApiResponse Get(string uri, Dictionary<string,string> headers);
        /// <summary>
        /// Post REST API call
        /// </summary>
        /// <param name="uri">API call uri</param>
        /// <param name="data">API call data</param>
        /// <returns></returns>
        public abstract ApiResponse Post(string uri, string data);
        /// <summary>
        /// Post REST API call
        /// </summary>
        /// <param name="uri">API call uri</param>
        /// <param name="data">API call data</param>
        /// <param name="headers">API call headers</param>
        /// <returns></returns>
        public abstract ApiResponse Post(string uri, string data, Dictionary<string, string> headers);
        /// <summary>
        /// Build full uri of request
        /// </summary>
        /// <param name="uri">API call uri</param>
        /// <returns></returns>
        public abstract Uri BuildRequestFullUri(string uri);
    }
}
