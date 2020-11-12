using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestAutomation.Helpers;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.StepDefinitions
{
	[Binding]
	public sealed class ViewProductsPageSteps
	{
		private WebDriverFactory _webDriverFactory;
		private Pages _pages;

		public ViewProductsPageSteps(WebDriverFactory webDriverFactory, Pages pages)
		{
			_webDriverFactory = webDriverFactory;
			_pages = pages;
		}

		[Then(@"products page list has item on row '(\d+)' and column '(\d+)' with text '(.+)'")]
		public void ProductPageListHasItemOnRowAndColumn(int rowIndex, int columnIndex, string expectedText)
		{
			var cellText = _pages.ViewProductsPage.GetProductsTableCell(rowIndex, columnIndex).Text;
			cellText.Should().Be(expectedText, $"Products page list does not have item {expectedText} but {cellText} on row {rowIndex} and column {columnIndex}");
		}
	}
}
