using PracticeXUnit.UITest.Pages;
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
            var quantity = "3";

            productClassicTeaPage.SetQuantity(quantity);
            productClassicTeaPage.PressAddToCarBtn();
            var cartTheTeaStory = productClassicTeaPage.PressViewCartBtn();

            Assert.Equal(quantity, cartTheTeaStory.GetQuantity());
        }

    }
}
