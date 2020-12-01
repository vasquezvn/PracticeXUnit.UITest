using Xunit;
using PracticeXUnit.UITest.Pages;
using System;

namespace PracticeXUnit.UITest
{
    public class PracticeOne : IClassFixture<ChromeDriverFixture>
    {
        public ChromeDriverFixture ChromeDriverFixture { get; }
        public PracticeOne(ChromeDriverFixture chromeDriverFixture)
        {
            ChromeDriverFixture = chromeDriverFixture;
            ChromeDriverFixture.Driver.Manage().Cookies.DeleteAllCookies();
            ChromeDriverFixture.Driver.Navigate().GoToUrl("about:blank");
            ChromeDriverFixture.Driver.Manage().Window.Maximize();
        }

        [Fact]
        [Trait("Category", "Practice 1")]
        public void ValidateSendStudentForm()
        {
            var studentFormPage = new StudentRegistrationPage(ChromeDriverFixture.Driver);
            var name = "TestName";
            var lastname = "TestLastName";
            var email = "test@test.com";
            var mobile = "9875649877";
            var dateOfBirth = "12 December,1986";
            var subjects = new string[] { "English", "Maths", "Biology" };
            var hobbies = new string[] { "Sports", "Music" };
            var address = "Test Address for Selenium";
            var state = "Haryana";
            var city = "Karnal";

            studentFormPage.NavigateTo();
            studentFormPage.EnterName(name);
            studentFormPage.EnterLastName(lastname);
            studentFormPage.EnterEmail(email);
            studentFormPage.ChooseGender(Gender.Male);
            studentFormPage.SetMobile(mobile);
            studentFormPage.EnterDateOfBirth(dateOfBirth);
            studentFormPage.EnterSubjecs(subjects);
            studentFormPage.ChooseHobbies(hobbies);
            studentFormPage.EnterCurrentAddress(address);
            studentFormPage.SelectState(State.Haryana);
            studentFormPage.SelectCity(city);
            studentFormPage.PressSubmitButton();

            Assert.Equal($"{name} {lastname}", studentFormPage.GetSubmittedValue("Student Name"));
            Assert.Equal(email, studentFormPage.GetSubmittedValue("Student Email"));
            Assert.Equal(Gender.Male.ToString(), studentFormPage.GetSubmittedValue("Gender"));
            Assert.Equal(mobile, studentFormPage.GetSubmittedValue("Mobile"));
            Assert.Equal(dateOfBirth, studentFormPage.GetSubmittedValue("Date of Birth"));
            Assert.Equal($"{subjects[0]}, {subjects[1]}, {subjects[2]}", studentFormPage.GetSubmittedValue("Subjects"));
            Assert.Equal($"{hobbies[0]}, {hobbies[1]}", studentFormPage.GetSubmittedValue("Hobbies"));
            Assert.Equal(address, studentFormPage.GetSubmittedValue("Address"));
            Assert.Equal($"{state} {city}", studentFormPage.GetSubmittedValue("State and City"));
        }
    }
}
