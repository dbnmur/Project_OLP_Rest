Feature: GetCourses
	In order to get course
	As a student or a teacher
	I want to see course

@mytag
Scenario: Get course
	Given Im on home page
	When I have pressed login button
	Then The result should display all courses
	Then I press desired course
	Then I get a course page
