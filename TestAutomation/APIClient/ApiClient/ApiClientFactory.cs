using System;
using System.Collections.Generic;
using System.Text;

namespace APIClient
{
    public class AvailableApiClients
    {
        public const string Resharp = "resharp";
    }

    public class ApiClientFactory
	{
        /// <summary>
        /// Get ApiClient instance
        /// </summary>
        /// <param name="apiClientName">Name of required API client</param>
        /// <param name="apiHostUri">Base uri of endpoint</param>
        /// <returns></returns>
		public static ApiClient GetApiClient(string apiClientName, string apiHostUri)
		{
            switch (apiClientName.ToLower())
            {
                case AvailableApiClients.Resharp:
                    return new RestApiClient(apiHostUri);
                default:
                    throw new NotImplementedException($"A api client {apiClientName} is not supported");
            }
        }
	}
}
