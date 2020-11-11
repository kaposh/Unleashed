
using APIClient.Resources;
using APITesting.TestData;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;

namespace APITesting
{
	[TestClass]
	public class CreateProductsTests
	{
		static Products Products = new Products(ApiCredentials.ApiId, ApiCredentials.ApiKey);


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
