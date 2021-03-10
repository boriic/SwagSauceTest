Feature: Login 
	Login to SauceDemo

@validInformation
Scenario: Perform Login on the SauceDemo website
	Given I launch the website
	And I enter the following details
		| Username      |   Password     |
		| standard_user |   secret_sauce |
	And I click the login button
	Then I should be redirected to product list page