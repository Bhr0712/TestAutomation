using Reqnroll;
using Selenium.Pages;

namespace Selenium.Steps;

[Binding]
public class PaginationSteps: CommonSteps
{
    private PaginationPage _paginationPage;
    
    [When(@"Lambda pagination url is open")]
    public void WhenLambdaPaginationUrlIsOpen()
    { 
        _paginationPage = new PaginationPage(_driver);
        _paginationPage.OpenThePage();
    }


    [When(@"The row size change to the (.*)")]
    public void WhenTheRowSizeChangeToThe(int rowSize)
    {
        _paginationPage.DynamicallyChangingRow(new List<int>{rowSize});
    }

    [Then(@"I should see the (.*) results per page")]
    public void ThenIShouldSeeTheResultsPerPage(int expectedCount)
    {
        Console.WriteLine($"{expectedCount}: {_paginationPage.getPageRow()}");
        Assert.That(_paginationPage.getPageRow(), Is.EqualTo(expectedCount));
    }

    [Then(@"Navigate to the next page of result")]
    public void ThenNavigateToTheNextPageOfResult()
    {
        _paginationPage.GoToNextPage();
    }

    [Then(@"I should see the next set of results")]
    public void ThenIShouldSeeTheNextSetOfResults()
    {
       Assert.That(_paginationPage.IsLastPage(), Is.True);
    }

    [When(@"Click the '(.*)'")]
    public void WhenClickThe(string allRowSelected)
    {
        _paginationPage.SelectAllRows(allRowSelected);
    }

    [Then(@"I should see the (.*) rows")]
    public void ThenIShouldSeeTheRows(int AllRowsCount)
    {
      Assert.That(_paginationPage.getAllRowsCount(), Is.EqualTo(AllRowsCount));
    }


    [Then(@"I should see the (.*) rows on the last page")]
    public void ThenIShouldSeeTheRowsOnTheLastPage(int lastPageRowCount)
    {
     Assert.That(_paginationPage.getPageRow(), Is.EqualTo(lastPageRowCount));   
    }
}