﻿Feature: Shopping Cart Tests
	Test Login as Office work user and add items to cart

@mytag
Scenario: Add Items To Cart
	Given I navigate to the Officeworks website
	And I have logged as "bharadwaj54@yahoo.com" using the login credentials	
	And I have navigated to "iPhones & Mobile Phones" section under the "Technology" main menu item
	And Clicked to view the "IPhones"
	When I add the "iPhone XS Max 64GB Gold|iPhone XR 64GB Black" to my shopping cart
	#And Selected the View cart 
	#Then The items "" should be part of my cart
