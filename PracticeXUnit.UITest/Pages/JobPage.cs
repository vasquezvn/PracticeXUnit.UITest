using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace PracticeXUnit.UITest.Pages
{
    class JobPage : Page
    {
        protected override string PageTitle => "Job";
        protected override string PageUrl => "https://orangehrm-demo-6x.orangehrmlive.com/client/#/pim/wizard/job";

        public JobPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void SetRegion(string region)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("section-heading")));

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            var regionElement = Driver.FindElement(By.XPath("//div[@id='9_inputfileddiv']//input[@class='select-dropdown']"));
            js.ExecuteScript("arguments[0].click();", regionElement);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='9_inputfileddiv']//ul/li[2]/span")));

            var query = from regionOption in Driver.FindElements(By.XPath("//div[@id='9_inputfileddiv']//ul/li/span"))
                        where regionOption.Text.Contains(region)
                        select regionOption;

            query.First().Click();
        }

        public void SetFte(string fte)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.FindElement(By.XPath("//div[@id='10_inputfileddiv']//input[@class='select-dropdown']")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='10_inputfileddiv']//ul/li[2]/span")));

            var query = from fteOption in Driver.FindElements(By.XPath("//div[@id='10_inputfileddiv']//ul/li/span"))
                        where fteOption.Text.Contains(fte)
                        select fteOption;

            query.First().Click();
        }

        public void SetTemporaryDep(string dept)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.FindElement(By.XPath("//div[@id='11_inputfileddiv']//input[@class='select-dropdown']")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='11_inputfileddiv']//ul/li[2]/span")));

            var query = from deptOption in Driver.FindElements(By.XPath("//div[@id='11_inputfileddiv']//ul/li/span"))
                        where deptOption.Text.Contains(dept)
                        select deptOption;

            query.First().Click();
        }

        public OrangeHrmDashboardPage PressSaveBtn()
        {
            Driver.FindElement(By.XPath("//button[@translate='Save']")).Click();

            return new OrangeHrmDashboardPage(Driver);
        }
    }
}
