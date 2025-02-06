using OpenQA.Selenium;
using Selenium.Steps;

namespace Selenium.Pages;

public class HomePage
{
    
    private readonly IWebDriver _driver;
    private string url = "https://practice.expandtesting.com/dropdown";

    public HomePage (IWebDriver driver){  
        _driver=driver;
    }
        
    public void OpenThePage(){
        
        _driver.Navigate().GoToUrl(url);

    }
//testcommit

    public IWebElement DragAndDrop=>_driver.FindElement(By.XPath("//a[@href='/drag-and-drop']"));
    public IWebElement FileUpload=>_driver.FindElement(By.XPath("//a[@href='/upload']"));
    public IWebElement Dropdown=>_driver.FindElement(By.XPath("//*[@id=\"examples\"]/div[10]/div[3]/div/div/h3/a"));

    // public void ClickDragAndDrop(){
    //     DragAndDrop.Click();
    //
    // }
    //
    // public void ClickFileUpload(){
    //     FileUpload.Click();
    // }

    public void DropdownList()
    {
        Dropdown.Click();
    }

    public string getTitle()
    {
        return _driver.Title;
    }
    
    
}