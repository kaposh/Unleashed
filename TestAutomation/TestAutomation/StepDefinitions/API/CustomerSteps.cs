﻿using APIClient.Resources;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using TechTalk.SpecFlow;
using TestAutomation.DataObjects;

namespace TestAutomation.API
{
	[Binding]
	public sealed class CustomerSteps
	{
		static Customer Customer = new Customer(ApiCredentials.ApiId, ApiCredentials.ApiKey);

		[Given(@"a customer with customer code '(.+)' and name '(.+)' exists")]
		public void GivenANewProductIsExists(string customerCode, string customerName)
		{
			var response = Customer.AddCustomer(customerCode, customerName);
			response.StatusCode.Should().Be(HttpStatusCode.Created);
		}
	}
}
