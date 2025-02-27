Feature: Pagination and row size adjustment

Scenario: Pagination throught the table and changing row size
Given the browser is open
When Lambda pagination url is open
And The row size change to the 10
Then I should see the 10 results per page
And Navigate to the next page of result
Then I should see the next set of results
