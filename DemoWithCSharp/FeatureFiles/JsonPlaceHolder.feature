Feature: API Test of JSONPlaceHolder
		 In order to leverage https://jsonplaceholder.typicode.com/
		 As a user
		 I want to try with several API calls
		

Scenario: Verify post API works
	Given the site service is up and running
	When I post with json data of
	| Key    | Value            |
	| name   | peter.zhang      |
	| career | automationTester |
	Then I should get successful response code
