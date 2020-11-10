using APIClient.Resources;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using TechTalk.SpecFlow;
using TestAutomation.DataObjects;

namespace TestAutomation.API
{
	[Binding]
	public sealed class ProductsAPISteps
	{
		static Products Products = new Products(ApiCredentials.ApiId, ApiCredentials.ApiKey);

		[Then(@"a new product with code '(.+)' is created")]
		public void NewProductIsCreated(string productCode)
		{
			var response = Products.GetProduct(productCode);
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var products = JsonConvert.DeserializeObject<ProductsObject>(response.Content);
			products.Items.Count.Should().Be(1, $"A single product with name is expected. Found {products.Items.Count} products");
		}
	}
}
