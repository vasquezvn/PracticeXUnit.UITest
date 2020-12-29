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

        //[Fact]
        //[Trait("Category", "PracticeCodi")]
        //public void BinaryGap()
        //{
        //    var carPage = new CartTheTeaStoryPage(ChromeDriverFixture.Driver);
        //    var result1 = carPage.GetBinaryGap(9);
        //    var result2 = carPage.GetBinaryGap(529);
        //    var result3 = carPage.GetBinaryGap(20);
        //    var result4 = carPage.GetBinaryGap(15);
        //    var result5 = carPage.GetBinaryGap(32);
        //    var result6 = carPage.GetBinaryGap(1041);
        //}

        //[Fact]
        //[Trait("Category", "PracticeCodi2")]
        //public void test()
        //{
        //    var carPage = new CartTheTeaStoryPage(ChromeDriverFixture.Driver);
        //    carPage.test(new int[] {1, 3, 6, 4, 1, 2});
        //    carPage.test(new int[] { 1, 2, 3});
        //    carPage.test(new int[] { -1, -3});
        //}

        //[Fact]
        //[Trait("Category", "PracticeCodi2")]
        //public void test1()
        //{
        //    var carPage = new CartTheTeaStoryPage(ChromeDriverFixture.Driver);
        //    var result = carPage.GetPosition(78, 195378678);
        //}

        //[Fact]
        //[Trait("Category", "PracticeCodi2")]
        //public void test2()
        //{
        //    var carPage = new CartTheTeaStoryPage(ChromeDriverFixture.Driver);
        //    var result = carPage.transformString("CBACD");
        //}

        //[Fact]
        //[Trait("Category", "PracticeCodi2")]
        //public void test3()
        //{
        //    var carPage = new CartTheTeaStoryPage(ChromeDriverFixture.Driver);
            
        //}
    }
}
