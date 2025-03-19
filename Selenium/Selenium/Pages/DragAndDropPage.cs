using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Collections.ObjectModel;


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
    
    IWebElement Draggable3=> _driver.FindElement(By.Id("draggable"));
    
    IWebElement Draggable=>_driver.FindElement(By.Id("todrag"));
    
    IWebElement DropZone=> _driver.FindElement(By.Id("mydropzone"));
    IWebElement DropZone2=> _driver.FindElement(By.Id("droppable"));
    
    IWebElement DroppedList=> _driver.FindElement(By.Id("droppedlist"));
    
    IWebElement DroppedItem3=> _driver.FindElement(By.Id("droppable"));

    public void PerformDragAndDrop(List<string> listOfDraggables)
    {
        Actions action=new Actions(_driver);
        for (int j=0; j<listOfDraggables.Count; j++)
        {
            IWebElement draggable = Draggable.FindElement(By.XPath($"//span[contains(text(),'{listOfDraggables[j]}')]"));
            action.DragAndDrop(draggable, DropZone).Perform();
        }
    }

    public void PerformDrop()
    {
        Actions action = new Actions(_driver);
        action.DragAndDrop(Draggable3,DropZone2).Perform();
    }

    public List<string> GetTargetElements()
    {
        List<string> draggedItems=new List<string>();
      //Assuming each draggable item when dropped is wrapped in a span within in the Dropdown list
      IReadOnlyCollection<IWebElement> spans = DroppedList.FindElements(By.XPath(".//span"));
      foreach(IWebElement span in spans)
      {
         draggedItems.Add(span.Text);
      }
        return draggedItems;
    }
    
    public string GetTargetElement3()
    {
        return DroppedItem3.Text;
    }




    
}