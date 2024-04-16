Feature: RegisterAndAddAdditionalInfo

As a new user
I would like to register a account and add additional info to my account
So that I can start view the rating of cars

Scenario Outline: Register a account and add additional info, then use valid details to login
Given I used this json file with valid credentials to resgister a new account
When I start enter valid username, first name, last name, password and confirm password
Then The new account should be register sucessfully by click the register button
Then I should see the register successful message
And I use valid user name and valid password to login to the portal
Then I should be able to go to my profile page to add additional info
Then I enter valid '<userGender>','<userAge>', '<userAddress>', '<userPhone>' to my additional info, and select gender and hobby
And I want to change password and enter '<currentPassword>', '<newPassword>', '<newConfirmPassword>'
Then I click the Save button to save the changes
And I should be able to see the info save successfully message
Then I click logout to logout the account
Then I use valid username and new password to login to the portal

Examples: 
| userGender | userAge | userAddress                                       | userPhone  | currentPassword | newPassword | newConfirmPassword |
| Male		 | 28      | Eden Road, Mount Eden, Auckland, New Zealand 1024 | 0212460124 | Eddie1234!      | Eddie510!   | Eddie510!          |