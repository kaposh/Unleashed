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
		public static ApiClient GetApiClient(string apiClientName, string apiId, string apiKey)
		{
            switch (apiClientName.ToLower())
            {
                case AvailableApiClients.Resharp:
                    return new RestApiClient(apiId, apiKey);
                default:
                    throw new NotImplementedException($"A api client {apiClientName} is not supported");
            }
        }
	}
}
