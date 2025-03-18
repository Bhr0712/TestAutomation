using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Selenium.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium.Steps;

[Binding]
public class DropdownSteps:CommonSteps
{
    private DropdownPage _dropdownPage;
    
    [When(@"Dropdown Url is open")]
    public void WhenDropdownUrlIsOpen()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _dropdownPage = new DropdownPage(_driver);
        _dropdownPage.OpenThePage();
        
    }

    [When(@"Click Dropdown list hyperlink and choose the selection from list")]
    public void WhenClickDropdownListHyperlinkAndChooseTheSelectionFromList()
    {
        _dropdownPage.SelectOption();
        _driver.SwitchTo().Frame("//iframe[@id='aswift_3]");
        IWebElement closeButton = _driver.FindElement(By.Id("close"));
        closeButton.Click(); 
        _driver.SwitchTo().DefaultContent();
        
        
        _dropdownPage.SelectElementPerPage();
        _dropdownPage.SelectCountry();
    }
    
     [Then(@"Verify ""(.*)"", ""(.*)"" and ""(.*)"" is selected")]
     public void ThenVerifyAndIsSelected(string expectedOption, string expectedValue, string expectedCountry)
     {
         Assert.Equals(_dropdownPage.Actualoption(), expectedOption);
         Assert.Equals(_dropdownPage.ActualElementPerPage(), expectedValue);
         Assert.Equals(_dropdownPage.ActualCountry(), expectedCountry);
         
     }

}