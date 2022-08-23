Feature: User Sign in Successfully


@AutomatedUserLogin 
Scenario: Varify user is able to login successfully on BBC login page
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
	Given I am on bbc.co.uk home page
	When I click on your account button on the navigation bar
	Then Your account is displayed on the account page
	When I click on Sign out button
	Then A text is displayed on the Sign out page 'You've signed out, sorry to see you go.'
	When I click on continue button
	Then Welcome to the BBC is displayed on the home page
	When I click on sign in button from the navigation bar
	Then I am on BBC Sign in page
	When I enter email and password
	And I click on Sign in button
	Then Welcome to the BBC is displayed on the home page
	And I check to verify the presence of the comment Icon is enabled


#@manual1
#Scenario: Varify that a verified acount is able to post comment successfully on the news article
#	Given I am on bbc.co.uk home page
#	When I click on sign in text button on the navigation bar
#	Then I am on sign in or Register page
#	When I login via verified email and password
#	Then I am logged in successfully
#	When I click on comments Icon
#	Then comment Icon is successfully clicked
#	And I am able to type in to comment textfield successfully
#
#@manual2
#Scenario: Varify user is not able to login with unregistered useremail and password
#	Given I am on bbc.co.uk home page
#	When I click on sign in text button on the navigation bar
#	Then I am on sign in or Register page
#	When I enter unregister email and password
#	Then The user is not able to logged in successfully
#	And An error is displayed "Sorry, we can't find an accout with that email. You can register for a new account or get help here."
#
#@manual3
#Scenario: Varify that unverified account is not able to type into the comments textfield area
#	Given I am on bbc.co.uk home page
#	When I click on sign in text button on the navigation bar
#	Then I am on sign in or Register page
#	When I enter unverified email and password after a successfull registration
#	Then The user is able to log in successfully
#	When I click on article to add comment
#	Then A text is displayed "We’ll need to verify your email address before you can use this."
#
#@manual4
#Scenario: Varify user that is not logged in can not see the comment Icon
#	Given I am on bbc.co.uk home page
#	When I click on article with out login
#	Then I am able to see the comments Icon
#
#@manual5
#Scenario: Varify registered user on a specific browser can access there account on other browers
#	Given I am on bbc.co.uk home page
#	When I logged in with verified account on mutiple browsers
#	Then I am able to type in the comments textfield section
#
#@manual6
#Scenario: Varify user is able click continue text button successfully to be able to verify account.
#	Given I am on bbc.co.uk home page
#	When I click on sign in text button on the navigation bar
#	Then I am on sign in or Register page
#	When I enter unverified email and password after a successfull registration
#	Then The user is able to log in successfully
#	When I click on article to comment
#	Then A text is displayed "We’ll need to verify your email address before you can use this."
#	When I click the continue text button
#	Then I recieved verify your email link in my registered email
#
#@manual7
#Scenario: Varify user is able to click the reply text button and reply to comments succesfully.
#	Given I am on bbc.co.uk home page
#	When I click on sign in text button on the navigation bar
#	Then I am on sign in or Register page
#	When I login via verified email and password
#	Then I am logged in successfully
#	When I click on reply text button
#	Then I am able to type in to reply text field successfully
#
#@manual8
#Scenario: Varify user is able to filter to show choice of comments on through the dropdown
#	Given I am on bbc.co.uk home page
#	When I click on sign in text button on the navigation bar
#	Then I am on sign in or Register page
#	When I login via verified email and password
#	Then I am logged in successfully
#	When I click on dropdown to select 'Latest'
#	Then The 'Latest' comments is displayed to the user
#
#@manual9
#Scenario: Varify user is able to use tumbs up or tumbs down on comments
#	Given I am on bbc.co.uk home page
#	When I click on sign in text button on the navigation bar
#	Then I am on sign in or Register page
#	When I login via verified email and password
#	Then I am logged in successfully
#	When I give tumbs up or tumbs down
#	Then I can see numbers of tumbs up or tumbs down added
#
#@manual10
#Scenario: Varify user is able to use Report comment section
#	Given I am on bbc.co.uk home page
#	When I click on sign in text button on the navigation bar
#	Then I am on sign in or Register page
#	When I login via verified email and password
#	Then I am logged in successfully
#	When I click on 'Report comment'
#	Then I was redirected to Report comments page successfully