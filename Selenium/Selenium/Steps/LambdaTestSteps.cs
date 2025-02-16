using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using Selenium.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium.Steps;

[Binding]
public class LambdaTestSteps:CommonSteps
{
    private LambdaTest _lambdaTest;
    private WebDriverWait _wait;
    
    [Given(@"Lambda test dropdown Url is open")]
    public void WhenLambdaTestDropdownUrlIsOpen()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        _driver=new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/select-dropdown-demo");
        _lambdaTest = new LambdaTest(_driver);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    [When(@"Choose the selection from list")]
    public void WhenChooseTheSelectionFromList()
    {
        _lambdaTest.SelectOption("Wednesday");
        _lambdaTest.SelectMultipleOptions(new List<string>() {"California", "Florida"});
    }

    [When(@"Choose (.*) from dropdown list")]
    public void WhenChooseFromDropdownList(string day)
    {
        _wait.Until(driver => { return driver.FindElement(By.Id("select-demo")); });
        _lambdaTest.SelectOption(day);
    }

    [When(@"Choose (.*) from multiselect list")]
    public void WhenChooseFromMultiselectList(string options)
    {
        var optionList = options.Split(',').Select(option => option.Trim()).ToList();
        _lambdaTest.SelectMultipleOptions(optionList);
    }

    [Then(@"Verify the selected option in dropdown list is (.*)")]
    public void ThenVerifyTheSelectedOptionInDropdownListIs(string option)
    {
        Assert.IsTrue(_lambdaTest.verifyDropdownSelectedOption(option));
    }

    [Then(@"Verify the selected option/s in multiselect list is/are (.*)")]
    public void ThenVerifyTheSelectedOptionInMultiselectListIs(string options)
    {
        var optionList = options.Split(',').Select(option => option.Trim()).ToList();
        Assert.IsTrue(_lambdaTest.verifyMultipleSelectedOptions(optionList));
        Thread.Sleep(5000);
    }
}