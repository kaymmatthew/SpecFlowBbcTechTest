Feature: Create User on BBC login page


@AutomatedCreateUser
Scenario: Varify user is able to Create User account on Bbc login page
	Given I am on bbc.co.uk home page
	When I click on sign in button from the navigation bar
	Then I am on BBC Sign in page
	When I click on register now button
	Then Register with the BBC is displayed
	When I Click 13 or over button
	And I enters details for date of birth
		| Day | Month | Year |
		| 15  | 03    | 1990 |
	And I click Continute button
	And I enters the following details:
		| Email                  | Password    | Postcode |
		| AuthoTest{0}@bbc.co.uk | TestPass22! | W12 7FA  |
	And I select Male
	And I click register
	Then A text is displayed 'OK you’re signed in. Now, want to keep up to date?'