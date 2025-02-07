using OpenQA.Selenium;

namespace Selenium.Pages;

public class LambdaTest
{
    private readonly WebDriver _driver;
    private string url = "https://www.lambdatest.com/selenium-playground/select-dropdown-demo";

    public LambdaTest(WebDriver driver)
    {
        _driver = driver;
    }

    public void OpenThePage()
    {
        _driver.Navigate().GoToUrl(url);
    }
    
    IWebElement SelectOption=> _driver.FindElement(By.Id("select-demo"));
    IWebElement SelectedOption => _driver.FindElement(By.XPath("//select[@id='select-demo']//option[@value='Wednesday']"));
    IWebElement MultipleOption1 => _driver.FindElement(By.XPath("//select[@id='multi-select']//option[@value='California']"));
    IWebElement FirstSelectedButton => _driver.FindElement(By.Id("printMe"));
    IWebElement MultipleOption2=>_driver.FindElement(By.XPath("//select[@id='multi-select']//option[@value='Ohio']"));
    IWebElement LastSelectedButton => _driver.FindElement(By.Id("printAll"));
    

    public void SelectionOfOption()
    {
        SelectOption.Click();
        SelectedOption.Click();
    }

    public void SelectMultipleOption()
    {
        MultipleOption1.Click();
        FirstSelectedButton.Click();
        
        MultipleOption2.Click();
        LastSelectedButton.Click();
    }
    
    public string ActualSelectedOption()
    {
        return SelectedOption.Text;
    }

    public string ActualMultipleOption()
    {
        string actual=_driver.FindElement(By.XPath("//span[@class='genderbutton']")).Text +"-"+_driver.FindElement(By.XPath("//span[@class='groupradiobutton block break-words']")).Text;
        return actual;
        
        
    }
    
}