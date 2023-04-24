Feature: Testing loigin Page of Hotel Adactin

A short summary of the feature

@SmokeTest
Scenario: Adding valid user name and password to  test login
	Given I am on Url of HotelAdaction working and on login page
	When I am typing valid username and password
	| username || password |
    | AmirImam || AmirImam |

	Then Website will go to search page
