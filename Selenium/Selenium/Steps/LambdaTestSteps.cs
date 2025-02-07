using OpenQA.Selenium.BiDi.Modules.Script;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Selenium.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium.Steps;

[Binding]
public class LambdaTestSteps:CommonSteps
{
    private LambdaTest _lambdaTest;
    
    [When(@"Lambda test dropdown Url is open")]
    public void WhenLambdaTestDropdownUrlIsOpen()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        _driver=new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _lambdaTest=new LambdaTest(_driver);
        _lambdaTest.OpenThePage();
        
        
    }

    [When(@"Choose the selection from list")]
    public void WhenChooseTheSelectionFromList()
    {
        _lambdaTest.SelectionOfOption();
        _lambdaTest.SelectMultipleOption();
    }

    [Then(@"The select option is ""(.*)"" and Multiple selections are ""(.*)"" and ""(.*)""")]
    public void ThenTheSelectOptionIsAndMultipleSelectionsAreAnd(string expectedDay, string expectedOption1, string expectedOption2)
    {
        Assert.That(_lambdaTest.ActualSelectedOption(), Is.EqualTo(expectedDay));
        Assert.That(_lambdaTest.ActualMultipleOption(), Is.EqualTo(expectedOption1+"-"+expectedOption2));
    }
}