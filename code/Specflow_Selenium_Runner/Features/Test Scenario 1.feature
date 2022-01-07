@BDDSTORY-TDP-10
Feature: Test Scenario 1
  @BDDTEST-TDP-11
  Scenario: 1. Navigate to page
    Given browser
    	When I open URL 'https://www.google.com'
    	Then I should see 'Page Title'

  @BDDTEST-TDP-12
  Scenario: 2. Navigate to another page
    When I open URL 'https://www.yahoo.com'
    	Then I should see 'Page Title'
