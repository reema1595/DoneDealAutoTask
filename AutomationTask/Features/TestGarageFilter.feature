Feature: TestGarageFilter

A short summary of the feature

@tag1
Scenario: Verify Garaage Filter Returns Valid Results
	Given A user is searching properties for sale in Dublin
	And Has a list of properties displayed
	When The User clicks on Filters
	And Enters text <Garage> in the keyword search filter
	And Clicks on show Results tab
	And Opens the first advert
	Then The advert must contain the keyword Garage in it
	Examples: 
	| Garage |
	| garage |
	| GARAGE |
	| GaRaGe |

	
@tag1
Scenario: Verify Garaage Filter Returns Valid Results navigating from homepage
	Given A user is on daft homepage
	And  The user clicks on Buy Option
	And  The user selects dublin from the dropdown
	Then A list of properties in Dublin are returned
	When The User clicks on Filters
	And Enters text <Garage> in the keyword search filter
	And Clicks on show Results tab
	And Opens the first advert
	Then The advert must contain the keyword Garage in it
	Examples: 
	| Garage |
	| garage |
	| GARAGE |
	| GaRaGe |
