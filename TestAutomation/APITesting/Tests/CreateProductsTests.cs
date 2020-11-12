using APIClient.Resources;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace APITesting
{
	[TestClass]
	public class CreateProductsTests
	{
		static ProductsApi Products = new ProductsApi();


		[ClassCleanup]
		public static void CleanTestData()
		{
			// DB Cleanup
		}


		[TestMethod]
		public void CreateASingleProduct()
		{
			var response = Products.AddProduct("NEW", "New product");
			response.StatusCode.Should().Be(HttpStatusCode.Created);
		}

		[TestMethod]
		public void CreateASingleProductTwice()
		{
			var response = Products.AddProduct("ONE", "First product");
			response.StatusCode.Should().Be(HttpStatusCode.Created);
			response = Products.AddProduct("ONE", "First product");
			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		}
	}
}
