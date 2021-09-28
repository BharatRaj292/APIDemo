Feature: Users
	
Scenario: Verify Users
	Given This is Get Request
	When I send get Users request
	Then Verify Status code should be "200"
	And Verify FirstName should be "Michael"