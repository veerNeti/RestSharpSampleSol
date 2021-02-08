Feature: RestAPIMethod

Scenario: Method Post
	Given the availability if a reqres service
	And resource/payload to create a new user
		| name       | job     |
		| sam austin | Surfing |
	When I post the payload to the service
	Then the user information is persisted
	And user id is assigned with a create date