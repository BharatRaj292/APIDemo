Feature: Create User

Scenario: Add User
	Given I input name "Mike"
	And I Input role "QA"
	When I send create user request
	Then validate user is created


Scenario Outline: Add User with Json
	Given I send createUser request  <json>
	Then validate user is created

	Examples: 
	| json                                       |
	|{"name": "morpheus","job": "leader"} |

Scenario: Add User with Json1
	Given I send createUserPost request :
	""" 
		{
			'name': 'Bharat',
			'job': 'leader'
		} 
	"""
	Then validate user is created

