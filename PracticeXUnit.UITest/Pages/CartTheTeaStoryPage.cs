using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace PracticeXUnit.UITest.Pages
{
    class CartTheTeaStoryPage : Page
    {
        protected override string PageTitle => "Cart | The Tea Story";
        protected override string PageUrl => "https://www.theteastory.co/cart?appSectionParams=%7B%22origin%22%3A%22cart-popup%22%7D";

        public CartTheTeaStoryPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public string GetQuantity()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("TPAMultiSection_j4mrllwviframe")));
            Driver.SwitchTo().Frame("TPAMultiSection_j4mrllwviframe");

            wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("input")));
            var inputs = Driver.FindElements(By.TagName("input"));
            var inputNumber = inputs[0].GetAttribute("value");

            return inputNumber;
        }
    }
}
