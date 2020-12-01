using OpenQA.Selenium;
using System;

namespace PracticeXUnit.UITest.Pages
{
    class Page
    {
        protected IWebDriver Driver;
        protected virtual string PageUrl { get; }
        protected virtual string PageTitle { get; }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(PageUrl);
            EnsurePageLoad();
        }

        public void EnsurePageLoad(bool onlyCheckUrlStartWithExpectedText = true)
        {
            bool isUrlCorrect = false;
            if (onlyCheckUrlStartWithExpectedText)
            {
                isUrlCorrect = Driver.Url.StartsWith(PageUrl);
            }
            else
            {
                isUrlCorrect = Driver.Url == PageUrl;
            }

            bool isPageLoaded = isUrlCorrect && (Driver.Title == PageTitle);

            if (!isPageLoaded)
            {
                throw new Exception($"Failed to load Page. Page Url: {Driver.Url} Page Source: \r\n {Driver.PageSource}");
            }
        }

        public void TakeScreenShot(string name)
        {
            ITakesScreenshot screenShotDriver = (ITakesScreenshot)Driver;
            Screenshot screenshot = screenShotDriver.GetScreenshot();
            screenshot.SaveAsFile($"{name}.bmp", ScreenshotImageFormat.Bmp);
        }

    }
}
