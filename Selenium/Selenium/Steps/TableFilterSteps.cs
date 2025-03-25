using Reqnroll;
using Selenium.Pages;

namespace Selenium.Steps;

[Binding]
public class TableFilterSteps: CommonSteps
{
    private TableFilterPage _tableFilterPage;
    
    [When(@"Lambda filter table  url is open")]
    public void WhenLambdaFilterTableUrlIsOpen()
    {
        _tableFilterPage=new TableFilterPage(_driver);
        _tableFilterPage.OpenThePage();
    }
    
    [When(@"I apply filter by '(.*)'")]
    public void WhenIApplyFilterBy(string value)
    {
        _tableFilterPage.DynamicallyFilteringByValue(new List<string> { value });
        Thread.Sleep(1000);
    }

    [Then(@"I should see only rows containing '(.*)'")]
    public void ThenIShouldSeeOnlyRowsContaining(string FilteredValue)
    {
        _tableFilterPage.VerifyFilteredValueInTheTable(FilteredValue);
    }

    [When(@"I enter ""(.*)"" into the ""(.*)"" filter")]
    public void WhenIEnterIntoTheFilter(string column, string value)
    {
        _tableFilterPage.DefineFilteredValueInTheTable(column, value);
    }

    [Then(@"I should see only the rows column name's (.*)""")]
    public void ThenIShouldSeeOnlyTheRowsColumnNames(string SecondfilteredValue)
    {
        _tableFilterPage.VerifyFilteredValueInTheSecondTable(SecondfilteredValue);
    }
}