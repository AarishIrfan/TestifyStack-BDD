Feature: Login Functionality on TestifyStack Practice Site

  Background:
    Given I am on the TestifyStack login page

  @Smoke_Test_Login
  Scenario: Login with valid username and password
    When I enter the following credentials:
      | username | password           |
      | practice | SuperSecretPassword! |
    And I click the login button
    Then I should be redirected to the secure area
    And I should see a welcome message confirming successful login