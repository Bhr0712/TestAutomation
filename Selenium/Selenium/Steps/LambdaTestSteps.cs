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
        _lambdaTest=new LambdaTest(_driver);
        _lambdaTest.OpenThePage();
    }

    [When(@"Choose the selection from list")]
    public void WhenChooseTheSelectionFromList()
    {
        _lambdaTest.SelectionOfOption("Wednesday");
        _lambdaTest.SelectMultipleOption(new List<string> { "California","Ohio" });
    }

    [Then(@"The select option is ""(.*)""")]
    public void ThenTheSelectOptionIs(string day)
    {
        Assert.That(_lambdaTest.GetSelectedOptionText(), Is.EqualTo(day));
    }
    

    [Then(@"Multiple selections are (.*)")]
    public void ThenMultipleSelectionsAreCaliforniaAndOhio(string state)
    {
        var stateList = state.Split("and").Select(x => x.Trim()).ToList();
        var actualState = _lambdaTest.ActualMultipleOption();

        for (int i = 0; i < stateList.Count; i++)
        {
            Assert.True(actualState.Contains(stateList[i]));
        }
    }
}