using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
