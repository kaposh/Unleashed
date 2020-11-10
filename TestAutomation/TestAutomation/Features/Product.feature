Feature: Product Page

Background: 
	Given I navigate to the login page

Scenario: Create a new product
	When I login with as user 'Bohdan' on the Login Page
	And I click on the Inventory menu item on the main navigation bar
	And I click on the Products menu item on the main navigation bar
	And I click on the Add Product menu item on the main navigation bar
	And I add a new product with following properties:
		| PropertyName             | PropertyValue             |
		| ProductCodeTxtBox        | PROD                      |
		| ProductDescriptionTxtBox | Very Short Decription 123 |
	Then a new product with code 'PROD' is created
