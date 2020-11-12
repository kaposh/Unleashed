using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace APIClient.Resources
{
	public class ProductsApi
	{
		ApiClient ApiClient { get; set; }
		/// <summary>
		/// Functionality of different Products APIs
		/// </summary>
		public ProductsApi()
		{
			ApiClient = ApiClientFactory.GetApiClient(AvailableApiClients.Resharp, UnleashedApiHelpers.ApiHost);
		}

		/// <summary>
		/// Get all products https://apidocs.unleashedsoftware.com/Products
		/// </summary>
		/// <returns>ApiResponse with all products</returns>
		public ApiResponse GetProducts()
		{
			var uri = "Products";
			var headers = UnleashedApiHelpers.GetAuthenticationHeaders(ApiClient.BuildRequestFullUri(uri));
			return ApiClient.Get(uri, headers);
		}
		/// <summary>
		/// Get specific product https://apidocs.unleashedsoftware.com/Products
		/// </summary>
		/// <returns>ApiResponse with product</returns>
		public ApiResponse GetProduct(Guid guid)
		{
			var uri = $"Products/{guid}";
			var headers = UnleashedApiHelpers.GetAuthenticationHeaders(ApiClient.BuildRequestFullUri(uri));
			return ApiClient.Get(uri, headers);
		}

		/// <summary>
		/// Get specific product by product code https://apidocs.unleashedsoftware.com/Products
		/// </summary>
		/// <returns>ApiResponse with product</returns>
		public ApiResponse GetProduct(string productCode)
		{
			var uri = $"Products?productCode={productCode}";
			var headers = UnleashedApiHelpers.GetAuthenticationHeaders(ApiClient.BuildRequestFullUri(uri));
			return ApiClient.Get(uri, headers);
		}

		/// <summary>
		/// Add a new product https://apidocs.unleashedsoftware.com/Products
		/// </summary>
		/// <returns>ApiResponse indicating if call was successful</returns>
		public ApiResponse AddProduct(string productCode, string productDescription)
		{
			var guid = Guid.NewGuid();
			var uri = $"Products/{guid}";
			var headers = UnleashedApiHelpers.GetAuthenticationHeaders(ApiClient.BuildRequestFullUri(uri));
			string postData = JsonHelper.Serialize(new Dictionary<string, string> { { "Guid", guid.ToString() }, { "ProductCode", productCode }, { "ProductDescription", productDescription } });
			return ApiClient.Post(uri, postData, headers);
		}

		/// <summary>
		/// Update existing product https://apidocs.unleashedsoftware.com/Products
		/// </summary>
		/// <returns>ApiResponse indicating if call was successful</returns>
		public ApiResponse UpdateProduct(string guid, string productCode, string productDescription)
		{
			var uri = $"Products/{guid}";
			var headers = UnleashedApiHelpers.GetAuthenticationHeaders(ApiClient.BuildRequestFullUri(uri));
			string postData = JsonHelper.Serialize(new Dictionary<string, string> { { "Guid", guid }, { "ProductCode", productCode }, { "ProductDescription", productDescription } });
			return ApiClient.Post(uri, postData, headers);
		}

		/// <summary>
		/// Obsolete existing product https://apidocs.unleashedsoftware.com/Products
		/// </summary>
		/// <returns>ApiResponse indicating if call was successful</returns>
		public ApiResponse ObsoleteProduct(Guid guid)
		{
			var uri = $"/Products/Obsolete/{guid}";
			var headers = UnleashedApiHelpers.GetAuthenticationHeaders(ApiClient.BuildRequestFullUri(uri));
			string postData = JsonHelper.Serialize(new Dictionary<string, string> { });
			return ApiClient.Post(uri, postData, headers);
		}

		/// <summary>
		/// Obsolete existing product by product code https://apidocs.unleashedsoftware.com/Products
		/// </summary>
		/// <returns>ApiResponse indicating if call was successful</returns>
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
