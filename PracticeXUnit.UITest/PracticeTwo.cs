using PracticeXUnit.UITest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PracticeXUnit.UITest
{
    public class PracticeTwo : IClassFixture<ChromeDriverFixture>
    {
        public ChromeDriverFixture ChromeDriverFixture { get; }

        public PracticeTwo(ChromeDriverFixture chromeDriverFixture)
        {
            ChromeDriverFixture = chromeDriverFixture;

            ChromeDriverFixture.Driver.Manage().Cookies.DeleteAllCookies();
            ChromeDriverFixture.Driver.Navigate().GoToUrl("about:blank");
            ChromeDriverFixture.Driver.Manage().Window.Maximize();
        }

        [Fact]
        [Trait("Category", "Practice 2")]
        public void ValidateProductoOnShoopingCart()
        {
            var theTeaStoryPage = new TheTeaStoryPage(ChromeDriverFixture.Driver);
            theTeaStoryPage.NavigateTo();
            var productClassicTeaPage = theTeaStoryPage.ClickClassicBlendsAssortedTea();

            productClassicTeaPage.SetQuantity("3");
            productClassicTeaPage.PressAddToCarBtn();
            var cartTheTeaStory = productClassicTeaPage.PressViewCartBtn();

            var quantityTea = cartTheTeaStory.GetQuantity();
        }
    }
}
