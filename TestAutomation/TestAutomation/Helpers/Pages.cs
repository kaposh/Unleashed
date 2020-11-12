using TestAutomation.PageObjects;

namespace TestAutomation.Helpers
{
	/// <summary>
	/// Contains all pages. it makes it ease to access them from steps
	/// </summary>
	public class Pages
	{
		public LoginPage LoginPage { get;set;}
		public HomePage HomePage { get; set; }
		public AddProductPage AddProductPage { get; set; }
		public AddSalesOrderPage AddSalesOrderPage { get; set; }
		public CustomerSearchPage CustomerSearchPage { get; set; }
		public CompleteOrderPage CompleteOrderPage { get; set; }
		public ProductSearchPage ProductSearchPage { get; set; }
		public ViewProductsPage ViewProductsPage { get; set; }
	}
}
