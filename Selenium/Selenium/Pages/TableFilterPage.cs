using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Pages;

public class TableFilterPage
{
    private readonly WebDriver _driver;
    private string url = "https://www.lambdatest.com/selenium-playground/table-search-filter-demo";

    public TableFilterPage(WebDriver driver)
    {
        _driver = driver;
    }

    public void OpenThePage()
    {
        _driver.Navigate().GoToUrl(url);
    }
    
    IWebElement filterByInput=>_driver.FindElement(By.Id("task-table-filter"));
    
    IList<IWebElement> wholeTableValues=>_driver.FindElements(By.XPath("//table[@id='task-table']//tbody//tr//td"));
    
    IList<IWebElement> filterInputs=>_driver.FindElements(By.XPath("//tr[@class='filters']//input"));
    
    IList<IWebElement> SecondTablefilteredValue=>_driver.FindElements(By.XPath("//tr[@classname='no-result text-center']//following-sibling::tr[1]//td"));
    
    IWebElement filterButton=>_driver.FindElement(By.XPath("//button[@class='btn btn-default btn-xs btn-filter border border-black']"));

    public void DynamicallyFilteringByValue(List<string> values)
    {
        for (int i = 0; i < values.Count; i++)
        {
            filterByInput.SendKeys(values[i]);
        }
    }

    public void VerifyFilteredValueInTheTable(string filteredValue)
    {
        for (int i = 0; i < wholeTableValues.Count; i++)
        {
            if (wholeTableValues[i].Text.Equals(filteredValue))
            {
                Console.WriteLine("Filtered value is :" + filteredValue + "The row containing: " + wholeTableValues[i].Text);
                break;
               
            }
        }
    }

    public void DefineFilteredValueInTheTable(string columnName, string filteredValue)
    {
        filterButton.Click();
        
        for (int i = 0; i < filterInputs.Count; i++)
        {
            if (filterInputs[i].GetDomAttribute("placeholder") == columnName)
            {
                filterInputs[i].SendKeys(filteredValue);
                break;
            }
        }
    }

    public void VerifyFilteredValueInTheSecondTable(string filtered)
    {
        for (int i = 0; i < SecondTablefilteredValue.Count; i++)
        {
            if (SecondTablefilteredValue[i].Text.Equals(filtered))
            {
                Console.WriteLine("Filtered value is : " + filtered + "The row containing: " + SecondTablefilteredValue[i].Text);
            }
        }   
    }
    
    
}