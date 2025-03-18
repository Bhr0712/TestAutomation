using Reqnroll;
using Selenium.Pages;

namespace Selenium.Steps;

[Binding]
public class DragAndDropStep:CommonSteps
{
    private DragAndDropPage _dragAndDropPage;
    
    [When(@"Lambda test drop and drop Url is open")]
    public void WhenLambdaTestDropAndDropUrlIsOpen()
    {
        _dragAndDropPage=new DragAndDropPage(_driver);
        _dragAndDropPage.OpenThePage();
    }
    
    
    [Given("Drag the items {string} drop it onto the target")]
    public void GivenDragTheItemsDropItOntoTheTarget(string draggable)
    {
        List<string> draggables=draggable.Split(',').Select(x => x.Trim()).ToList();
        _dragAndDropPage.PerformDragAndDrop(draggables);
    }
    
    

    [Then(@"The target should contain ""(.*)""")]
    public void ThenTheTargetShouldContain(string draggables)
    {
        var actualDragged=draggables.Split(",").Select(x => x.Trim()).ToList();
        var expectedDragged = _dragAndDropPage.GetTargetElements();
        for (int i=0; i<expectedDragged.Count; i++)
        {
            Assert.IsTrue(actualDragged.Contains(expectedDragged[i]));
        }
    }

    [When(@"Drag the item drop it onto the target")]
    public void ThenDragTheItemDropItOntoTheTarget()
    {
        _dragAndDropPage.PerformDrop();
    }

    [When(@"Drag the items '(.*)' drop it onto the target")]
    public void WhenDragTheItemsDropItOntoTheTarget(string draggable)
    {
        List<string> draggables=draggable.Split(',').Select(x => x.Trim()).ToList();
            _dragAndDropPage.PerformDragAndDrop(draggables);
    }
}