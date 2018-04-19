Feature: Navigation
	In order to browse the site
	As an user
	I want to use navigation

@mytag
Scenario: Browse to OLP site
	Given I am on the home page
	When I click on a 'link' in navigation bar
	Then I should land on 'link' page
