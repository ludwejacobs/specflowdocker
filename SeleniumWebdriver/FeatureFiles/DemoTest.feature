Feature: Login 

@login
Scenario Outline: Login correct credentials
	Given the LoginPage is open
    And  the page "header" message is present
    And the user fills their <username>
  #  And the user fills their <password>
    When the user clicks the login button
    Examples: 
    | Testcase | username      | password |
    | a        | standard_user | 1234     |


#Scenario Outline: Login incorrect credentials
#	Given the LoginPage is open
 #   And  the page "header" message is present
#    And the user fills their <username>
#    And the user fills their <password>
 #   When the user clicks the login button
#    Then the "error" message is displayed 
 #   Examples: 
 #   | Testcase                               | username       | password      |
##    | Correct password & incorrect username  | standard_users | secret_sauce  |
 #   | Inorrect password incorrect username   | standard_user  | 1234          |
 #  | Correct password incorrect username    | standard_users | secret_sauce  |
   
   






