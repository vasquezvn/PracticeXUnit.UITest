using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PracticeXUnit.UITest.Pages
{
    class OrangeHrmDashboardPage : Page
    {
        protected override string PageTitle => "OrangeHRM";
        protected override string PageUrl => "https://orangehrm-demo-6x.orangehrmlive.com/client/#/dashboard";

        public OrangeHrmDashboardPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void ClickPimOption() => Driver.FindElement(By.Id("menu_pim_viewPimModule")).Click();
        public EmployeeListPage ClickAddEmployeeOption()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menu_pim_addEmployee"))).Click();

            return new EmployeeListPage(Driver);
        }

        public EmployeeListPage ClickEmployeeListOption()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h4[@class='wrapped-word']")));

            Driver.FindElement(By.Id("menu_pim_viewEmployeeList")).Click();

            return new EmployeeListPage(Driver);
        }

    }
}