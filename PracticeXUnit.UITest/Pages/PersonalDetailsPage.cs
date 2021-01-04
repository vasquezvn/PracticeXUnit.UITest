using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace PracticeXUnit.UITest.Pages
{
    class PersonalDetailsPage : Page
    {
        protected override string PageTitle => "Personal Details";
        protected override string PageUrl => "https://orangehrm-demo-6x.orangehrmlive.com/client/#/pim/wizard/personal_details";

        public PersonalDetailsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void SetBloodGroup(string bloodGroup)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='1_inputfileddiv']//input[@class='select-dropdown']"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='1_inputfileddiv']//ul/li[2]/span")));

            var query = from bloodOption in Driver.FindElements(By.XPath("//div[@id='1_inputfileddiv']//ul/li/span"))
                        where bloodOption.Text.Contains(bloodGroup)
                        select bloodOption;

            query.First().Click();
        }

        public void SetHobbies(string hobbie) => Driver.FindElement(By.Id("5")).SendKeys(hobbie);

        public JobPage PressNextBtn()
        {
            Driver.FindElement(By.XPath("//button[@translate='Next']")).Click();

            return new JobPage(Driver);
        }

        public bool AreValuesSaved(string name, string lastName, string bloodGroup, string hobbie)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//section[@id='content']//h4[@class='wrapped-word']")));

            var isNameSaved = Driver.FindElement(By.Id("firstName")).GetAttribute("value").Contains(name);
            var isLastNameSaved = Driver.FindElement(By.Id("lastName")).GetAttribute("value").Contains(lastName);
            var isBloodGroupSaved = Driver.FindElement(By.XPath("//div[@id='1_inputfileddiv']//input[@class='select-dropdown']")).GetAttribute("value").Contains(bloodGroup);
            var isHobbieSaved = Driver.FindElement(By.Id("5")).GetAttribute("value").Contains(hobbie);

            return isNameSaved && isLastNameSaved && isBloodGroupSaved && isHobbieSaved;
        }

        public bool IsDivorcedMaritalState()
        {
            var result = false;

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@class='active-drop-down']")));

            var query = from maritalStatus in Driver.FindElements(By.XPath("//div[@id='emp_marital_status_inputfileddiv']//ul/li"))
                        select maritalStatus;

            foreach (var maritalStatus in query.Skip(1))
            {
                if (maritalStatus.Text.Equals("Divorced"))
                {
                    result = true;
                }
            }
            
            return result;
        }
    }
}
