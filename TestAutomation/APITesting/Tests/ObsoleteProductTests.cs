using APIClient.Resources;
using APITesting.TestData;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using System;
using System.Linq;
using System.Net;

namespace APITesting
{
	[TestClass]
	public class ObsoleteProductTests
	{
		static Products Products = new Products(ApiCredentials.ApiId, ApiCredentials.ApiKey);

		[ClassInitialize]
		public static void SetupTestData(TestContext testContext)
		{
			var response = Products.AddProduct("TST", "Test product");
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
			var response = Products.ObsoleteProduct("TST");
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
