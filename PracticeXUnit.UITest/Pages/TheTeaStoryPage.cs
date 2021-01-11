using OpenQA.Selenium;
using System;

namespace PracticeXUnit.UITest.Pages
{
    class TheTeaStoryPage : Page
    {
        protected override string PageTitle => "The Tea Story | Singapore | Organic Premium Loose Leaf Tea";
        protected override string PageUrl => "https://www.theteastory.co/";

        public TheTeaStoryPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public ProductClassicTeaPage ClickClassicBlendsAssortedTea()
        {
            Driver.FindElement(By.XPath("//div[@class='slick-slide slick-active slick-current']")).Click();
            
            return new ProductClassicTeaPage(Driver);
        }

        public ContactUsPage ClickContactUsLink()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            var regionElement = Driver.FindElement(By.Id("comp-jr09do7i5label"));
            js.ExecuteScript("arguments[0].click();", regionElement);

            return new ContactUsPage(Driver);
        }
    }
}
