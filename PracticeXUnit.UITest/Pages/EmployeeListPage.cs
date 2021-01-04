using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace PracticeXUnit.UITest.Pages
{
    class EmployeeListPage : Page
    {
        protected override string PageTitle => "Employee List";
        protected override string PageUrl => "https://orangehrm-demo-6x.orangehrmlive.com/client/#/pim/employees";

        public EmployeeListPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void EnterFirstName(string firstName)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("firstName"))).SendKeys(firstName);
        }
        public void EnterLastName(string lastName) => Driver.FindElement(By.Id("lastName")).SendKeys(lastName);

        public void SetLocation(string location)
        {
            Driver.FindElement(By.XPath("//input[@value='-- Select --']")).Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='location_inputfileddiv']//ul/li[3]/span")));

            var query = from locationOption in Driver.FindElements(By.XPath("//div[@id='location_inputfileddiv']//ul/li/span"))
                        where locationOption.Text.Contains(location)
                        select locationOption;

            query.First().Click();
        }

        public PersonalDetailsPage PressNextBtn()
        {
            Driver.FindElement(By.Id("systemUserSaveBtn")).Click();

            return new PersonalDetailsPage(Driver);
        }

        public void EnterSearchCriteria(string criteria) => Driver.FindElement(By.Id("employee_name_quick_filter_employee_list_value")).SendKeys(criteria);

        public void ClickAutoComplete()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='employee_name_quick_filter_employee_list_dropdown']/div/span"))).Click();
        }

        public PersonalDetailsPage ClickCreatedUser(string criteria)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.StalenessOf(Driver.FindElement(By.Id("loading-bar"))));

            var employeeTable = Driver.FindElement(By.Id("employeeListTable"));
            var query = from row in employeeTable.FindElements(By.TagName("td"))
                        where row.Text.Contains(criteria)
                        select row;

            query.First().Click();

            return new PersonalDetailsPage(Driver);
        }

        public bool IsSaveButtonDisplayed()
        {
            var result = false;

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("systemUserSaveBtn")));

            if (Driver.FindElement(By.Id("systemUserSaveBtn")).Text.ToLower().Equals("save"))
            {
                result = true;
            }

            return result;
        }

    }
}