using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Selenium.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium.Steps;

public class LoginHomePage
{
    private IWebDriver _driver;
    private HomePage _homePage;

    [Given(@"the browser is open")]
    public void GivenTheBrowserIsOpen()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());

        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _homePage = new HomePage(_driver);
    }

    [When(@"Url is open")]
    public void WhenUrlIsOpen()
    {
        _homePage.OpenThePage();
    }

    [Then(@"Verify the title of the page is ""(.*)""")]

    public void ThenVerifyTheTitleOfThePageIs(string expectedTitle)
    {
       string actualTitle = _homePage.Title;
       Assert.Equal(expectedTitle, actualTitle,"Titles are not matching");
    }
}
