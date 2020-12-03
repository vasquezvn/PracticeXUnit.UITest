using OpenQA.Selenium;
using System;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace PracticeXUnit.UITest.Pages
{
    class ProductClassicTeaPage : Page
    {
        protected override string PageTitle => "The Tea Story | Singapore | Classic Blends Assorted Tea Box Collection";
        protected override string PageUrl => "https://www.theteastory.co/product-page/classic-blends-assorted-tea-box-collection";

        public ProductClassicTeaPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void SetQuantity(string quantity)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.TagName("input"))).Click();
            var numberArrowUp = Driver.FindElement(By.ClassName("_11lkb"));

            var quantityNumber = Int32.Parse(quantity);
            for (int i = 1; i < quantityNumber; i++)
            {
                numberArrowUp.Click();
            }

        }

        public void PressAddToCarBtn()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var addToCartBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@class='buttonnext2291024870__content']")));
            addToCartBtn.Click();
        }

        public CartTheTeaStoryPage PressViewCartBtn()
        {
            if (this.PageTitle != "Cart | The Tea Story")
            {
                var frames = Driver.FindElements(By.TagName("iframe"));
                var idframe = frames.Last().GetAttribute("id");

                Driver.SwitchTo().Frame(idframe);

                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                var viewCartBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("widget-view-cart-button")));
                viewCartBtn.Click();

                Driver.SwitchTo().ParentFrame();
            }
            
            return new CartTheTeaStoryPage(Driver);
        }
    }
}
