Feature: Pagination and row size adjustment

Background: 
    Given the browser is open
    When Lambda pagination url is open

Scenario: Pagination throught the table and changing row size
    And The row size change to the 10
    Then I should see the 10 results per page
    And Navigate to the next page of result
    Then I should see the next set of results

Scenario: Verify the number of rows on the last page
    When Click the 'Show ALL Rows'
    Then I should see the 40 rows
    When The row size change to the 15
    Then Navigate to the next page of result
    And I should see the 10 rows on the last page




