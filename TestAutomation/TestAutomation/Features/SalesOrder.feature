@SalesOrder
Feature: Sales Order
	As a customer I want to create a new Sales Order

Background: 
	Given a product with code 'COLA' and description 'Coca-Cola' exists
	And a customer with customer code 'JOHN' and name 'John Monday' exists
	# TODO Create all required data in DB
	Given I navigate to the login page

Scenario: Add a new Sales Order
	When I login with as user 'Bohdan' on the Login Page
	And I click on the Sales menu item on the main navigation bar
	And I click on the Orders menu item on the main navigation bar
	And I click on the Add Sales Order menu item on the main navigation bar
	And I select a customer with code 'JOHN' on add sales order page
	And I select a product with code 'COLA' on add sales order page