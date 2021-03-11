Feature: Login
	Check various types of login on the website

@validInformation
Scenario: Perform Login on the SauceDemo website with the right information
	Given I launch the website
	And I enter the following details
		| Username      | Password     |
		| standard_user | secret_sauce |
	And I click the login button
	Then I should be redirected to product list page

@noInformation
Scenario: Perform Login on the SauceDemo website with no information
	Given I launch the website
	And I enter no details in the login form
	And I click the login button
	Then I should see the Username is required error message

@noPasswordCorrectUsername
Scenario: Perform Login on the SauceDemo website with no password but correct username
	Given I launch the website
	And I enter the following details
		| Username      | Password |
		| standard_user |          |
	And I click the login button
	Then I should see the Password is required error message

@wrongInformation
Scenario: Perform Login on the SauceDemo website with wrong information
	Given I launch the website
	And I enter the following details
		| Username | Password |
		| krivi    | podatci  |
	And I click the login button
	Then I should see the Username and password do not match any user in this service error message