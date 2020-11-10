using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace APIClient.Resources
{
	public class Products
	{
		ApiClient ApiClient { get; set; }
		public Products(string apiId, string apiKey)
		{
			ApiClient = ApiClientFactory.GetApiClient(AvailableApiClients.Resharp, apiId, apiKey);
		}

		public ApiResponse GetProducts()
		{
			return ApiClient.Get("Products");
		}
		public ApiResponse GetProduct(Guid guid)
		{
			return ApiClient.Get($"Products/{guid}");
		}

		public ApiResponse GetProduct(string productCode)
		{
			return ApiClient.Get($"Products?productCode={productCode}");
		}

		public ApiResponse AddProduct(string productCode, string productDescription)
		{
			var guid = Guid.NewGuid();
			string postData = JsonHelper.Serialize(new Dictionary<string, string> { { "Guid", guid.ToString() }, { "ProductCode", productCode }, { "ProductDescription", productDescription } });
			return ApiClient.Post($"Products/{guid}", postData);
		}

		public ApiResponse UpdateProduct(string guid, string productCode, string productDescription)
		{
			string postData = JsonHelper.Serialize(new Dictionary<string, string> { { "Guid", guid }, { "ProductCode", productCode }, { "ProductDescription", productDescription } });
			return ApiClient.Post($"Products/{guid}", postData);
		}

		public ApiResponse ObsoleteProduct(Guid guid)
		{
			string postData = JsonHelper.Serialize(new Dictionary<string, string> { });
			return ApiClient.Post($"/Products/Obsolete/{guid}", postData);
		}

		public ApiResponse ObsoleteProduct(string productCode)
		{
			var response = GetProduct(productCode);
			var products = JsonConvert.DeserializeObject<ProductsObject>(response.Content);
			if (products.Items.Count == 0)
				throw new KeyNotFoundException($"Product with code {productCode} does not exist");
			return ObsoleteProduct(Guid.Parse(products.Items.First().Guid));
		}
	}
}
