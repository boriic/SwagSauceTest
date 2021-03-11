Feature: MainPage
	Testing product list page, like adding and removing products and changing filters

@addToCart
Scenario: Pressing add to cart button on the first product
	Given I sucessfully login and redirected to the product list page
	And I press the add to cart button
	Then Button text should change to REMOVE and the cart number should be updated

@addToCart
Scenario: Pressing remove button on the first product
	Given I sucessfully login and redirected to the product list page
	And I add the first product to the cart
	And I press the remove button on the first product
	Then Button text should change to ADD TO CART and the cart number should be updated

@filterZ-A
Scenario: Pressing filter Z-A
	Given I sucessfully login and redirected to the product list page
	And I press the option Z-A on the filter dropdown list
	Then Products should be filtered by that option

@filterHI-LO
Scenario: Pressing filter HI-LO
	Given I sucessfully login and redirected to the product list page
	And I press the option HI-LO on the filter dropdown list
	Then Products should be filtered by that option

@filterLO-HI
Scenario: Pressing filter LO-HI
	Given I sucessfully login and redirected to the product list page
	And I press the option LO-HI on the filter dropdown list
	Then Products should be filtered by that option