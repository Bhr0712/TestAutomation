using System.Collections;
using System.Collections.ObjectModel;
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
    
    IList<IWebElement> allRows=> SelectField.FindElements(By.XPath("//table[@id='table-id']//tbody//tr"));
    
    IList<IWebElement> numberOfRows=> _driver.FindElements(By.XPath("//table[@id='table-id']/tbody/tr[not(contains(@style,'display: none'))]"));
    
    IWebElement nextButton =>_driver.FindElement(By.XPath("//div[@class='pagination-container']//span[contains(text(),'>')]"));

     IWebElement lastRow =>
        _driver.FindElement(By.XPath("//table[@id='table-id']/tbody/tr/td[contains(text(),'Cherry')]"));

     IList<IWebElement> PaginationListELement =>
        _driver.FindElements(By.XPath("//div[@class='pagination-container']//ul/li"));

     public void GoToLastPage()
     {
         for (int i=0;i<PaginationListELement.Count-3; i++)
         {
             nextButton.Click();
         }
     }
    
    //Dynamically changing the row Size
    public void DynamicallyChangingRow(List <int> rows)
    {
        select = new SelectElement(SelectField);
        for (int i=0; i<rows.Count; i++)
        {
            select.SelectByText(rows[i].ToString());
        }
    }

    public void SelectAllRows()
    {
        select=new SelectElement(SelectField);
        select.SelectByText("Show ALL Rows");
    }

    public int getPageRow()
    {
        Thread.Sleep(2000);
        return numberOfRows.Count;
    }

    public int getAllRowsCount()
    {
        return allRows.Count;
    }

    public bool IsLastPage()
    { 
        //Return true if disabled, meaning it's the last page
        // if (lastRow.Displayed)
        // { 
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }

        while (true)
        {
            int i = PaginationListELement.Count - 2;
            if (PaginationListELement[i].GetDomAttribute("class").Equals("active"))
            {
                return true;
            }
        }
    }

    // public void GoToNextPage()
    // {
    //     while (true)
    //     {
    //         try
    //         {
    //             if (lastRow.Displayed)
    //             {
    //                break; //Exit loop if button is disabled
    //             }
    //             if(nextButton.Enabled && nextButton.Displayed)
    //             {
    //                 nextButton.Click();
    //                 Thread.Sleep(1000); //Give some time page to load
    //             }
    //             else{break;}
    //         }
    //         catch (NoSuchElementException)
    //         {
    //             break; //Exit loop if button is not found
    //         }
    //
    //     }
    // }
}



