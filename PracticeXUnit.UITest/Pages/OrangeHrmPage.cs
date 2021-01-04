using OpenQA.Selenium;

namespace PracticeXUnit.UITest.Pages
{
    class OrangeHrmPage : Page
    {
        protected override string PageTitle => "OrangeHRM";
        protected override string PageUrl => "https://orangehrm-demo-6x.orangehrmlive.com/auth/login";

        public OrangeHrmPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void Goto() => Driver.Navigate().GoToUrl(this.PageUrl);
        public void EnterUsr(string user)
        {
            var userLogin = Driver.FindElement(By.Id("txtUsername"));
            userLogin.Clear();
            userLogin.SendKeys(user);
        }

        public void EnterPass(string pass)
        {
            var passLogin = Driver.FindElement(By.Id("txtPassword"));
            passLogin.Clear();
            passLogin.SendKeys(pass);
        }
        public OrangeHrmDashboardPage PressLoginBtn()
        {
            Driver.FindElement(By.Id("btnLogin")).Click();

            return new OrangeHrmDashboardPage(Driver);
        }
    }
}
