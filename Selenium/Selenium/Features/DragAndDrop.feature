Feature:Drag and drop verification on Lambda

Scenario: Drag items and drop to the target
Given the browser is open
When Lambda test drop and drop Url is open
And Drag the item and drop it onto the target
Then The target should contain "Draggable 1", "Draggable 2" and "Dropped!"
