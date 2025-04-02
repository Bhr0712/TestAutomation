Feature: Filter Table Functionality

Background: 
    Given the browser is open
    When Lambda filter table  url is open

Scenario: Filter table by the value
When I apply filter by 'JavaScript'
Then I should see only rows containing 'JavaScript'


Scenario Outline: Filter user table by different columns
When I enter "<columnName>" into the "<filterValue>" filter
Then I should see only the rows column name's <filterValue>"
    Examples:
      | columnName  | filterValue  |
      | #           | 1            |
      | Username    | matheson     |
      | First Name  | Halima       |
      | Last Name   | John         |