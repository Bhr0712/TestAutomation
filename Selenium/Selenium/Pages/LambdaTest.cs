using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Pages;

public class LambdaTest
{
    private readonly WebDriver _driver;
    private string url = "https://www.lambdatest.com/selenium-playground/select-dropdown-demo";
    private SelectElement selectSingle;
    private SelectElement selectMultiple;

    public LambdaTest(WebDriver driver)
    {
        _driver = driver;
    }

    public void OpenThePage()
    {
        _driver.Navigate().GoToUrl(url);
    }
    
    IWebElement SelectOption=> _driver.FindElement(By.Id("select-demo"));
    IWebElement MultipleOption1 => _driver.FindElement(By.XPath("//select[@id='multi-select']//option[@value='California']"));
    IWebElement FirstSelectedButton => _driver.FindElement(By.Id("printMe"));
    IWebElement MultipleOption2=>_driver.FindElement(By.XPath("//select[@id='multi-select']//option[@value='Ohio']"));
    IWebElement LastSelectedButton => _driver.FindElement(By.Id("printAll"));
    

    public void SelectionOfOption(string day)
    {
        selectSingle = new SelectElement(SelectOption);
        selectSingle.SelectByText(day);

    }

    public void SelectMultipleOption(List<string> options)
    {
        selectMultiple=new SelectElement(_driver.FindElement(By.Id("multi-select")));
        for (int i = 0; i < options.Count; i++)
        {
            selectMultiple.SelectByText(options[i]);
        }
    }
    
    public string GetSelectedOptionText()
    {
        return selectSingle.SelectedOption.Text;
    }

    public List<string> ActualMultipleOption()
    {
        return selectMultiple.AllSelectedOptions.Select(x => x.Text).ToList();
            
    }
    
}