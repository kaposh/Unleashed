using FluentAssertions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestAutomation.Helpers;
using TestAutomation.Helpers.Driver;
using TestAutomation.PageObjects;

namespace TestAutomation.StepDefinitions
{
	[Binding]
	public sealed class AddSalesOrderPageSteps
	{
		private WebDriverFactory _webDriverFactory;
		private Pages _pages;

		public AddSalesOrderPageSteps(WebDriverFactory webDriverFactory, Pages pages)
		{
			_webDriverFactory = webDriverFactory;
			_pages = pages;
		}

		[When(@"I select a customer with code '(.+)' on Add sales order page")]
		public void WhenISelectACustomer(string customerCode)
		{
			_pages.AddSalesOrderPage.CustomerSearchBtn.Click();
			_pages.CustomerSearchPage = new CustomerSearchPage(_webDriverFactory);
			_pages.CustomerSearchPage.SelectACustomerByCode(customerCode);
		}

		[When(@"I select a product with code '(.+)' on Add sales order page")]
		public void WhenISelectAProduct(string productCode)
		{
			_pages.AddSalesOrderPage.ProductSearchBtn.Click();
			_pages.ProductSearchPage = new ProductSearchPage(_webDriverFactory);
			_pages.ProductSearchPage.SelectAProductByCode(productCode);
		}

		[When(@"I add a product with code '(.+)' to sales order on Add sales order page")]
		public void WhenIAddAProductWithCodeToSalesOrder(string productCode, Dictionary<string, string> productProperties)
		{
			WhenISelectAProduct(productCode);
			foreach (var property in productProperties)
			{
				switch(property.Key)
				{
					case "QuantityAddLineTxtBox":
						_pages.AddSalesOrderPage.QuantityAddLineTxtBox.ClearAndSendKeys(property.Value);
						break;
					case "PriceAddLine":
						_pages.AddSalesOrderPage.PriceAddLineTxtBox.ClearAndSendKeys(property.Value);
						break;
					default:
						throw new ArgumentException($"Control with name {property.Key} is not defined");
				}
			}
			_pages.AddSalesOrderPage.AddOrderLineBtn.Click();
		}

		[When(@"I complete sales order on Add sales order page")]
		public void WhenICompleteSalesOrder()
		{
			_pages.AddSalesOrderPage.CompleteOrderBtn.Click();
			_pages.CompleteOrderPage = new CompleteOrderPage(_webDriverFactory);
		}

		[Then(@"Complete sales order dialog is shown")]
		public void CompleteDialogIsShown() => _pages.CompleteOrderPage.ConfirmDialogIsVisible().Should().BeTrue("Complete sales order dialog is not shown");

		[When(@"I click '(Yes|No)' on complete sales order page")]
		public void IClickYesNoOnCompleteSalesOrder(string choice)
		{
			_pages.AddSalesOrderPage = choice == "yes" ? _pages.CompleteOrderPage.PressYes() : _pages.CompleteOrderPage.PressNo();
		}
	}
}
