using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeXUnit.UITest.Pages
{
    class ContactUsPage : Page
    {
        protected override string PageTitle => "The Tea Story | Singapore | Contact Us";
        protected override string PageUrl => "https://www.theteastory.co/contact-us";

        public ContactUsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void EnterName(string name)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("input_comp-kgaljzxs"))).SendKeys(name);
        }

        public void EnterEmail(string email) => Driver.FindElement(By.Id("input_comp-kgaljzy4")).SendKeys(email);

        public void EnterMessage(string message) => Driver.FindElement(By.Id("textarea_comp-kgaljzy8")).SendKeys(message);

        public bool PressSendButton()
        {
            var result = false;
            Driver.FindElement(By.Id("comp-kgaljzyh")).Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var sendMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("comp-kgaljzyr"))).Text;

            if (sendMessage.Equals("We'll get back to you shortly!"))
            {
                result = true;
            }

            return result;
        }
    }
}
