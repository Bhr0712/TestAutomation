Feature:Dropdown test

Scenario: Open Dropdown page and Select options on the list
Given the browser is open
When Url is open
And Click Dropdown list hyperlink and choose the selection from list
Then Verify "Option 1", "20 elements per page" and "Albania" is selected


