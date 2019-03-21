Feature: Shopping Cart Tests
	Test Login as Office work user and add items to cart

@mytag
# The purpose of this test is to make sure you add the products to the shopping cart 
# and test if the Add cart functionalityis working by checking the cart items
# The assumption here is the items which we are adding to the cart are part of the inventory.
# In real world you can set up the test data through various meand like calling 
# an end point as a background task
Scenario: Add Items To Cart - Positive test
	Given I navigate to the Officeworks website
	And I have logged as "bharadwaj54@yahoo.com" using the login credentials	
	And I have navigated to "iPhones & Mobile Phones" section under the "Technology" main menu item
	And Clicked to view the "IPhones"
	When I add the "iPhone XS Max 64GB Gold" to my shopping cart
	And Selected the View cart 
	Then The items "iPhone XS Max 64GB Gold" should be part of my cart
