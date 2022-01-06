Feature: Login
	To test login functionality of an application

@mytag
Scenario: 1. Navigate to page
	Given browser
	When I open URL 'https://www.google.com'
	Then I should see 'Page Title'

Scenario: 2. Navidate to another page
	When I open URL 'https://www.yahoo.com'
	Then I should see 'Page Title'