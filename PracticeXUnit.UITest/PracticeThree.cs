using System;
using Xunit;
using PracticeXUnit.UITest.Pages;

namespace PracticeXUnit.UITest
{
    public class PracticeThree : IClassFixture<ChromeDriverFixture>
    {
        public ChromeDriverFixture ChromeDriverFixture { get; }

        public PracticeThree(ChromeDriverFixture chromeDriverFixture)
        {
            ChromeDriverFixture = chromeDriverFixture;

            ChromeDriverFixture.Driver.Manage().Cookies.DeleteAllCookies();
            ChromeDriverFixture.Driver.Navigate().GoToUrl("about:blank");
            chromeDriverFixture.Driver.Manage().Window.Maximize();

        }

        [Fact]
        [Trait("Category", "Practice 3")]
        public void ValidateNewUser()
        {
            var random = new Random();

            var employeeName = "TestUser" + random.Next(100);
            var employeeLastName = "TestLastName";
            var bloodGroup = "AB";
            var hobbie = "Jazzing";

            var orangeHrmPage = new OrangeHrmPage(ChromeDriverFixture.Driver);
            orangeHrmPage.Goto();
            orangeHrmPage.EnterUsr("admin");
            orangeHrmPage.EnterPass("admin123");
            var orangeHrmDashboardPage = orangeHrmPage.PressLoginBtn();

            orangeHrmDashboardPage.ClickPimOption();
            var employeeListPage = orangeHrmDashboardPage.ClickAddEmployeeOption();

            employeeListPage.EnterFirstName(employeeName);
            employeeListPage.EnterLastName(employeeLastName);
            employeeListPage.SetLocation("France Regional HQ");
            var personalDetailsPage = employeeListPage.PressNextBtn();

            personalDetailsPage.SetBloodGroup(bloodGroup);
            personalDetailsPage.SetHobbies(hobbie);
            var jobPage = personalDetailsPage.PressNextBtn();

            jobPage.SetRegion("Region-2");
            jobPage.SetFte("0.75");
            jobPage.SetTemporaryDep("Sub unit-2");
            orangeHrmDashboardPage = jobPage.PressSaveBtn();

            employeeListPage = orangeHrmDashboardPage.ClickEmployeeListOption();

            employeeListPage.EnterSearchCriteria($"{employeeName} {employeeLastName}");
            employeeListPage.ClickAutoComplete();
            personalDetailsPage = employeeListPage.ClickCreatedUser($"{employeeName} {employeeLastName}");

            var areValuesSaved = personalDetailsPage.AreValuesSaved(employeeName, employeeLastName, bloodGroup, hobbie);

            Assert.True(areValuesSaved);

        }
    }
}
