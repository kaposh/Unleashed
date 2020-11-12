using APIClient.Resources;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace APITesting
{
	[TestClass]
	public class ObsoleteProductTests
	{
		static ProductsApi Products = new ProductsApi();

		[ClassInitialize]
		public static void SetupTestData(TestContext testContext)
		{
			var response = Products.AddProduct("PROD", "Test product");
			response.StatusCode.Should().Be(HttpStatusCode.Created);
		}

		[ClassCleanup]
		public static void CleanTestData()
		{
			// DB Cleanup
		}

		[TestMethod]
		public void ObsoleteProductExisting()
		{
			var response = Products.ObsoleteProduct("PROD");
			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		[TestMethod]
		public void ObsoleteProductNonExisting()
		{
			var response = Products.ObsoleteProduct(new Guid());
			response.StatusCode.Should().Be(HttpStatusCode.NotFound);
		}
	}
}
