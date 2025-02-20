using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Selenium.Pages;

public class DragAndDropPage
{
    private readonly WebDriver _driver;
    private string url = "https://www.lambdatest.com/selenium-playground/drag-and-drop-demo";

    public DragAndDropPage(WebDriver driver)
    {
        _driver = driver;
    }
    
    public void OpenThePage()
    {
        _driver.Navigate().GoToUrl(url);
    }
    
    IWebElement Draggable1=> _driver.FindElement(By.XPath("//div[@id='todrag']//*[contains(text(),'Draggable 1')]"));
    IWebElement Draggable2=> _driver.FindElement(By.XPath("//div[@id='todrag']//*[contains(text(),'Draggable 2')]"));
    IWebElement Draggable3=> _driver.FindElement(By.Id("draggable"));
    IWebElement DropZone=> _driver.FindElement(By.XPath("//*[@id='mydropzone']"));
    IWebElement DropZone2=> _driver.FindElement(By.XPath("//*[@id='droppable']"));
    
    IWebElement DroppedItem1=> _driver.FindElement(By.XPath("//div[@id='droppedlist']//*[contains(text(),'Draggable 1')]"));
    IWebElement DroppedItem2=> _driver.FindElement(By.XPath("//div[@id='droppedlist']//*[contains(text(),'Draggable 2')]"));
    IWebElement DroppedItem3=> _driver.FindElement(By.Id("droppable"));

    public void PerformDragAndDrop()
    {
        Actions action=new Actions(_driver);
        action.DragAndDrop(Draggable1, DropZone).Perform();
        action.DragAndDrop(Draggable2, DropZone).Perform();
        action.DragAndDrop(Draggable3, DropZone2).Perform();
        
    }

    public string GetTargetElement1()
    {
        return DroppedItem1.Text;
    }
    
    public string GetTargetElement2()
    {
        return DroppedItem2.Text;
    }
    
    public string GetTargetElement3()
    {
        return DroppedItem3.Text;
    }




    
}