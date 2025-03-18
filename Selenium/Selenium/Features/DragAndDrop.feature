Feature:Drag and drop verification on Lambda
Background: 
    Given the browser is open
    When Lambda test drop and drop Url is open

Scenario: Drag items and drop to the target
    And Drag the items 'Draggable 1, Draggable 2' drop it onto the target
    Then The target should contain "Draggable 1,Draggable 2" 

Scenario: Drag item and drop to the target
    When Drag the item drop it onto the target
    Then The target should contain "Dropped!"