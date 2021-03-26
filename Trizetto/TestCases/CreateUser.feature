Feature: CreateUser


@mytag
Scenario Outline: CreateUser
	Given I am on web page 'http://automationpractice.com/index.php'
	And I click on Sign In button
	When I enter email address <'Email'> in Create Account section
	And I click on Create an Account button
	Then I enter <'Fisrs Name'> <'Last Name'> <'Email'> <'Password'>

	Examples: 
	| Fisrs Name | Last Name | Email             | Password  |
	| Jon        | Due       | jdue1@myemail.com | password1 |