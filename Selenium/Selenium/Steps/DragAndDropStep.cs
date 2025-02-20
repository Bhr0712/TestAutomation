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


    [When(@"Drag the item and drop it onto the target")]
    public void WhenDragTheItemAndDropItOntoTheTarget()
    {
        _dragAndDropPage.PerformDragAndDrop();
    }

    [Then(@"The target should contain ""(.*)"", ""(.*)"" and ""(.*)""")]
    public void ThenTheTargetShouldContainAnd(string draggable1, string draggable2, string dropped)
    {
        Assert.That(draggable1, Is.EqualTo(_dragAndDropPage.GetTargetElement1()));
        Assert.That(draggable2, Is.EqualTo(_dragAndDropPage.GetTargetElement2()));
        Assert.That(dropped, Is.EqualTo(_dragAndDropPage.GetTargetElement3()));
    }
}