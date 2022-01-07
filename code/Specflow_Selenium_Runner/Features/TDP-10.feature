@BDDSTORY-TDP-10
Feature: Test Scenario 1



	@BDDTEST-TDP-11
	@BDDVER--1
	@BDDCYC-15b35e2f-1383-494c-81bb-b5c535bd1f66
	Scenario: 1. Navigate to page
	
		Given browser
			When I open URL 'https://www.google.com'
			Then I should see 'Page Title'

	@BDDTEST-TDP-12
	@BDDVER--1
	@BDDCYC-15b35e2f-1383-494c-81bb-b5c535bd1f66
	Scenario: 2. Navigate to another page
	
		When I open URL 'https://www.yahoo.com'
			Then I should see 'Page Title'

