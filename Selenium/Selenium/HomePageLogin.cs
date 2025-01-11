using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Selenium.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium;

[Binding]
public class HomePageLogin
{
    private HomePage _homePage;
    private IWebDriver _driver;
    
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
        Assert.That(_homePage.getTitle(), Is.EqualTo(expectedTitle),"Page title does not match");
    }
    
    [AfterScenario]
    public void tearDown()
    {
        _driver.Quit();
    }
}