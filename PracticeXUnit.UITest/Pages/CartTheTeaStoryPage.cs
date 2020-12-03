using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Driver.SwitchTo().Frame("TPAMultiSection_j4mrllwviframe");
            var inputs = Driver.FindElements(By.CssSelector("._3sBNH"));
            var inputNumber = inputs[0];

            return inputNumber.Text;
        }
    }
}
