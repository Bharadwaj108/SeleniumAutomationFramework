Feature: Shopping Cart Tests
	Test Login as Office work user and add items to cart

@mytag
Scenario: Add Items To Cart
	Given I navigate to the Officeworks website
	And I have logged as "Bharat" using the login credentials	
	And I have navigated to "iPhones & Mobile Phones" section under the "Technology" main menu item
	And Clicked to view the "IPhones"
	When I add the "" to my shopping cart
	And Selected the View cart 
	Then The items "" should be part of my cart
