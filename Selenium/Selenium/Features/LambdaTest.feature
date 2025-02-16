Feature: Dropdown Selection Verification on LambdaTest

@test
Scenario: Verify dropdown contains expected options and selections
Given Lambda test dropdown Url is open
When Choose Wednesday from dropdown list
And Choose Ohio,California from multiselect list
Then Verify the selected option in dropdown list is Wednesday
And Verify the selected option/s in multiselect list is/are Ohio,California