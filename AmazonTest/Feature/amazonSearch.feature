Feature: Amazon
	Test amazon search for laptops

@mytag
Scenario: Test first laptop result price is higher than 100
	Given I navigate to the amazon homepage
	And I search for the word laptop
	And I click on the first result
	Then Its price should be higher than 100