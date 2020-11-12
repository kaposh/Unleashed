@SalesOrder
Feature: Sales Order
	As a customer I want to create a new Sales Order

Background: 
	#Given a product with code 'COLA' and description 'Coca-Cola' exists
	#And a customer with customer code 'JOHN' and name 'John Monday' exists
	# TODO Create all required test data in DB including
	#	- Adding a new supplier
	#	- Adding a new purchase order
	Given I navigate to the login page

Scenario: Add a new Sales Order
	When I login with as user 'Bohdan' on the Login Page
	And I click on the Sales menu item on the main navigation bar
	And I click on the Orders menu item on the main navigation bar
	And I click on the Add Sales Order menu item on the main navigation bar
	And I select a customer with code 'JOHN' on Add sales order page
	And I add a product with code 'COLA' to sales order on Add sales order page
		| PropertyName          | PropertyValue |
		| QuantityAddLineTxtBox | 5             |
		| PriceAddLine          | 1.50          |
	And I complete sales order on Add sales order page
	Then Complete sales order dialog is shown
	When I click 'Yes' on complete sales order page
	And I click on the Inventory menu item on the main navigation bar
	And I click on the Products menu item on the main navigation bar
	And I click on the View Products menu item on the main navigation bar
	Then products page list has item on row '0' and column '2' with text 'COLA'
	And products page list has item on row '0' and column '3' with text 'Coca Cola'
	And products page list has item on row '0' and column '7' with text '40.00'
		