using APIClient.Resources;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;

namespace APITesting
{
	[TestClass]
	public class GetProductsTests
	{
		static ProductsApi Products = new ProductsApi();

		[ClassInitialize]
		public static void SetupTestData(TestContext testContext)
		{
			var response = Products.AddProduct("TST", "Test product");
			response.StatusCode.Should().Be(HttpStatusCode.Created);
			response = Products.AddProduct("ANO", "Another product");
			response.StatusCode.Should().Be(HttpStatusCode.Created);
		}

		[ClassCleanup]
		public static void CleanTestData()
		{
			// DB Cleanup
		}


		[TestMethod]
		public void GetAllProducts()
		{
			var response = Products.GetProducts();
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var products = JsonConvert.DeserializeObject<ProductsObject>(response.Content);
			// This will fail. There are some precreated products already
			products.Items.Count.Should().Be(2, $"Expected number of products 2, but got {products.Items.Count}");
		}

		[TestMethod]
		public void GetSingleProducts()
		{
			var response = Products.GetProduct("TST");
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var products = JsonConvert.DeserializeObject<ProductsObject>(response.Content);
			products.Items.Count.Should().Be(1, $"Expected number of products 1, but got { products.Items.Count}");
			products.Items[0].ProductCode.Should().Be("TST");
			products.Items[0].ProductDescription.Should().Be("Test product");
		}
		[TestMethod]
		public void GetNonExistingProducts()
		{
			var response = Products.GetProduct("NEX");
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var products = JsonConvert.DeserializeObject<ProductsObject>(response.Content);
			products.Items.Count.Should().Be(0, $"Expected number of products 0, but got { products.Items.Count}");
		}
	}
}
