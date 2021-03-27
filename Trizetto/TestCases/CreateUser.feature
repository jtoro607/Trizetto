Feature: CreateUser


@mytag
Scenario Outline: CreateUser
	Given I am on web page 'http://automationpractice.com/index.php'
	And I click on Sign In button
	When I enter email address <Email> in Create Account section
	And I click on Create an Account button
	Then I enter <Fisrs Name> <Last Name> <Email> <Password>
	And I also enter on Address section '<Address>', '<City>', '<State>', '<Zipcode>', '<Country>', <Mobile>, and '<Alias>'
	And I click on Register button
	And Assert the logged use in the same first/last name that you entered

	Examples: 
	| Fisrs Name | Last Name | Email             | Password  | Address   | City    | State   | Zipcode | Country           | Mobile       | Alias        |
	| Jon        | Due       | someguy1@myemail.com | password1 | 1 main st | Orlando | Florida | 32822   | United States     | 4073214567   | TestCustomer |
