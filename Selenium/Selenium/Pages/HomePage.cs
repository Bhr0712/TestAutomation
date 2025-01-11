using OpenQA.Selenium;

namespace Selenium.Pages;

public class HomePage
{
    
    private readonly IWebDriver _driver;
    private string url = "https://practice.expandtesting.com/upload";

    public HomePage (IWebDriver driver){  
        _driver=driver;
    }
        
    public void OpenThePage(){
        
        _driver.Navigate().GoToUrl(url);

    }


    public IWebElement DragAndDrop=>_driver.FindElement(By.XPath("//a[@href='/drag-and-drop']"));
    public IWebElement FileUpload=>_driver.FindElement(By.XPath("//a[@href='/upload']"));

    public void ClickDragAndDrop(){
        DragAndDrop.Click();

    }

    public void ClickFileUpload(){
        FileUpload.Click();
    }

    public string getTitle()
    {
        return _driver.Title;
    }
    
    
}