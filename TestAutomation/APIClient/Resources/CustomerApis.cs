using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace APIClient.Resources
{
	public class CustomerApis
	{
		ApiClient ApiClient { get; set; }
		/// <summary>
		/// Functionality of different Customer APIs
		/// </summary>
		public CustomerApis()
		{
			ApiClient = ApiClientFactory.GetApiClient(AvailableApiClients.Resharp, UnleashedApiHelpers.ApiHost);
		}

		/// <summary>
		/// Add a new customer https://apidocs.unleashedsoftware.com/Customers
		/// </summary>
		/// <returns>ApiResponse indicating if call was successful</returns>
		public ApiResponse AddCustomer(string customerCode, string customerName)
		{
			var guid = Guid.NewGuid();
			var uri = $"Customers/{guid}";
			var headers = UnleashedApiHelpers.GetAuthenticationHeaders(ApiClient.BuildRequestFullUri(uri));
			string postData = JsonHelper.Serialize(new Dictionary<string, string> { { "Guid", guid.ToString() }, { "CustomerCode", customerCode }, { "CustomerName", customerName } });
			return ApiClient.Post(uri, postData, headers);
		}

	}
}
