using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var quantityField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='1']")));
            //var quantityField = Driver.FindElement(By.XPath("//input[@value='1']"));
            quantityField.Clear();
            quantityField.SendKeys(quantity);
        }

        public void PressAddToCarBtn()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var addToCartBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@class='buttonnext2291024870__content']")));
            addToCartBtn.Click();
            //Driver.FindElement(By.XPath("//span[@class='buttonnext84631916__content']")).Click();
        }

        public CartTheTeaStoryPage PressViewCartBtn()
        {
            var frames = Driver.FindElements(By.TagName("iframe"));
            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //var idFrame = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id($"{frames[2].GetAttribute("id")}")));

            var idframe = frames[3].GetAttribute("id");
            var idFrame = "tpaPopup-ki90ag5iiframe";
            Driver.SwitchTo().Frame(idframe);
            Driver.FindElement(By.Id("widget-view-cart-button")).Click();
            Driver.SwitchTo().ParentFrame();

            return new CartTheTeaStoryPage(Driver);
        }
    }
}
