Feature: RestAPIMethod

Background:
	Given the availability of a "POST" reqres service

Scenario: Get List<Users>
	When we get a list of users in page "2"
	Then validate the response from ExecuteGetTaskAsync

Scenario: Get single user
	When we get a single user "2"
	Then validate the response from ExecuteAsyncReq

Scenario: Post
	And resource/payload to create a new user
		| name       | job     |
		| sam austin | Surfing |
	When I post the payload to the service
	Then the user information is persisted
	And user id is assigned with a create date

Scenario: Put Update one record
	And resource/payload to create a new user
		| name    | job        |
		| PUT Sam | PUT Surfer |
	When i "PUT" a user "2" record information
	Then the user information is persisted
	And user id is assigned with a create date

Scenario: Patch Update one record
	And resource/payload to create a new user
		| name      | job          |
		| PATCH Sam | PATCH Surfer |
	When i "PATCH" a user "2" record information
	Then the user information is persisted
	And user id is assigned with a create date