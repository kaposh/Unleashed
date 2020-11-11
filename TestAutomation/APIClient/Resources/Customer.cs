using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace APIClient.Resources
{
	public class Customer
	{
		ApiClient ApiClient { get; set; }
		public Customer(string apiId, string apiKey)
		{
			ApiClient = ApiClientFactory.GetApiClient(AvailableApiClients.Resharp, apiId, apiKey);
		}

		public ApiResponse AddCustomer(string customerCode, string customerName)
		{
			var guid = Guid.NewGuid();
			string postData = JsonHelper.Serialize(new Dictionary<string, string> { { "Guid", guid.ToString() }, { "CustomerCode", customerCode }, { "CustomerName", customerName } });
			return ApiClient.Post($"Customers/{guid}", postData);
		}

	}
}
