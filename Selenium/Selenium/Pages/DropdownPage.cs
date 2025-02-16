using System;
using OpenQA.Selenium;

namespace Selenium.Pages;

public class DropdownPage
{
    private readonly IWebDriver _driver;
    private string url = "https://practice.expandtesting.com/dropdown";

    public DropdownPage (IWebDriver driver){  
        _driver=driver;
    }
        
    public void OpenThePage(){
        
        _driver.Navigate().GoToUrl(url);

    }
    
    IWebElement Dropdown => _driver.FindElement(By.Id("dropdown"));
    IWebElement DropdownItem => _driver.FindElement(By.XPath("//select[@id='dropdown']//option[@value='1']"));
    IWebElement ElementPerPageDropdown=>_driver.FindElement(By.Id("elementsPerPageSelect"));
    IWebElement ElementDropdownItem => _driver.FindElement(By.Id("//select[@id='elementsPerPageSelect']//option[@value=20']"));
    IWebElement CountryDropdown => _driver.FindElement(By.Id("country"));
    IWebElement SelectedCountry=> _driver.FindElement(By.XPath("//select[@id='country']//option[@value='AL']"));

    public void SelectOption()
    {
        Dropdown.Click();
        DropdownItem.Click();
    }

    public void SelectElementPerPage()
    {
        ElementPerPageDropdown.Click();
        ElementDropdownItem.Click();
    }

    public void SelectCountry()
    {
        CountryDropdown.Click();
        SelectedCountry.Click();
    }

    public String Actualoption()
    {
        return Dropdown.Text;
    }

    public String ActualElementPerPage()
    {
        return ElementPerPageDropdown.Text;
    }

    public String ActualCountry()
    {
        return CountryDropdown.Text;
    }
}