using APIClient.Resources;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using TechTalk.SpecFlow;
using TestAutomation.DataObjects;

namespace TestAutomation.API
{
	[Binding]
	public sealed class ProductsSteps
	{
		static Products Products = new Products(ApiCredentials.ApiId, ApiCredentials.ApiKey);

		[Then(@"a new product with code '(.+)' is created")]
		public void ThenANewProductIsCreated(string productCode)
		{
			var response = Products.GetProduct(productCode);
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var products = JsonConvert.DeserializeObject<ProductsObject>(response.Content);
			products.Items.Count.Should().Be(1, $"A single product with name is expected. Found {products.Items.Count} products");
		}

		[Given(@"a product with code '(.+)' and description '(.+)' exists")]
		public void GivenANewProductIsExists(string productCode, string productDescription)
		{
			var response = Products.AddProduct(productCode, productDescription);
			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}
	}
}
