Feature: AddRecord
	In order to add a record
	As a user
	I want to enter record name and description 

@mytag
Scenario: Add record
	Given Im on the course page
	Then I press plus button
	Then I enter name
	Then I enter description
	Then I press add
	Then I should see new record
