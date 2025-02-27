using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Selenium.Pages;

public class PaginationPage
{
    private readonly WebDriver _driver;
    private string url = "https://www.lambdatest.com/selenium-playground/table-pagination-demo";
    SelectElement select;

    public PaginationPage(WebDriver driver)
    {
        _driver = driver;
    }

    public void OpenThePage()
    {
        _driver.Navigate().GoToUrl(url);
    }

    IWebElement SelectField => _driver.FindElement(By.Id("maxRows"));
    
    //Dynamically changing the row Size
    public void DynamicallyChangingRow(List <int> rows)
    {
        select = new SelectElement(SelectField);
        for (int i=0; i<rows.Count; i++)
        {
            select.SelectByText(rows[i].ToString());
        }
    }

    public int getPageRow()
    {
        int row = int.Parse(select.SelectedOption.Text);
        return row;
    }

    public bool GoToNextPage()
    {
        IWebElement nextButton = _driver.FindElement(By.XPath("//div[@class='pagination-container']//span[contains(text(),'>')]"));
        try
        {
            if (nextButton.Enabled)
            {
                nextButton.Click();
                return true; //clicked
            }

            return false; //Not able to click the next button
        }

        catch (NoSuchElementException)
        {
            return false;
        }
    }
    

}



