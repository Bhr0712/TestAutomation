using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Pages;

public class LambdaTest
{
    private readonly WebDriver _driver;
    private string url = "https://www.lambdatest.com/selenium-playground/select-dropdown-demo";

    public LambdaTest(WebDriver driver)
    {
        _driver = driver;
        dropdown = new SelectElement(SelectOptionSingle);
        multiSelect = new SelectElement(SelectOptionMultiple);
    }

    public void OpenThePage()
    {
        _driver.Navigate().GoToUrl(url);
    }

    IWebElement SelectOptionSingle => _driver.FindElement(By.Id("select-demo"));
    IWebElement SelectOptionMultiple => _driver.FindElement(By.Id("multi-select"));

    SelectElement dropdown, multiSelect;

    public void SelectOption(String option)
    {
        dropdown.SelectByText(option);
    }

    public void SelectMultipleOptions(List<String> options)
    {
        SelectElement multiSelect = new SelectElement(SelectOptionMultiple);
        foreach (var option in options)
        {
            multiSelect.SelectByText(option);
        }
    }

    public Boolean verifyDropdownSelectedOption(String option)
    {
        return dropdown.SelectedOption.Text.Equals(option);
    }
    
    public Boolean verifyMultipleSelectedOptions(List<String> options)
    {
        List<String> selectedOptions = new List<String>();
        List<string> allSelectedOptions = multiSelect.AllSelectedOptions.Select(option => option.Text).ToList();
        foreach (var option in options)
        {
            if (!allSelectedOptions.Contains(option))
            {
                return false;
            }
        }
        return true;
    }
}