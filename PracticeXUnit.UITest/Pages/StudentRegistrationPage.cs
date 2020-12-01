using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticeXUnit.UITest.Pages
{
    class StudentRegistrationPage: Page
    {
        protected override string PageUrl => "https://demoqa.com/automation-practice-form";
        protected override string PageTitle => "ToolsQA";

        public StudentRegistrationPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void EnterName(string name) => Driver.FindElement(By.Id("firstName")).SendKeys(name);
        public void EnterLastName(string lastName) => Driver.FindElement(By.Id("lastName")).SendKeys(lastName);
        public void EnterEmail(string email) => Driver.FindElement(By.Id("userEmail")).SendKeys(email);
        public void SetMobile(string number) => Driver.FindElement(By.Id("userNumber")).SendKeys(number);
        public void EnterCurrentAddress(string address) => Driver.FindElement(By.Id("currentAddress")).SendKeys(address);
        public void PressSubmitButton() => Driver.FindElement(By.Id("submit")).Click();

        public void EnterDateOfBirth(string date)
        {
            Driver.FindElement(By.Id("dateOfBirthInput")).Click();

            var dateArray = date.Split(new string[] { " ", "," }, StringSplitOptions.None);
            var selectMonth = new SelectElement(Driver.FindElement(By.ClassName("react-datepicker__month-select")));
            var selectYear = new SelectElement(Driver.FindElement(By.ClassName("react-datepicker__year-select")));

            selectMonth.SelectByText(dateArray[1]);
            selectYear.SelectByText(dateArray[2]);

            var calendarDiv = Driver.FindElement(By.ClassName("react-datepicker__month"));
            var daysArray = calendarDiv.FindElements(By.ClassName("react-datepicker__day"));

            foreach (var day in daysArray)
            {
                if (day.Text.Equals(dateArray[0]))
                {
                    day.Click();
                    break;
                }
            }

        }
        
        public void SelectState(State state)
        {
            Driver.FindElement(By.Id("state")).Click();

            switch (state)
            {
                case State.NCR:
                    Driver.FindElement(By.Id("react-select-3-option-0")).Click();
                    break;
                case State.UttarPradesh:
                    Driver.FindElement(By.Id("react-select-3-option-1")).Click();
                    break;
                case State.Haryana:
                    Driver.FindElement(By.Id("react-select-3-option-2")).Click();
                    break;
                case State.Rajasthan:
                    Driver.FindElement(By.Id("react-select-3-option-3")).Click();
                    break;
                default:
                    break;
            }

        }
        public void SelectCity(string city)
        {
            Driver.FindElement(By.Id("city")).Click();

            if (city.Equals("Delhi") || city.Equals("Agra") || city.Equals("Karnal") || city.Equals("Jaipur"))
            {
                Driver.FindElement(By.Id("react-select-4-option-0")).Click();
            }
            else if (city.Equals("Gurgaon") || city.Equals("Lucknow") || city.Equals("Panipat") || city.Equals("Jaiselmer"))
            {
                Driver.FindElement(By.Id("react-select-4-option-1")).Click();
            }
            else if (city.Equals("Noida") || city.Equals("Merrut"))
            {
                Driver.FindElement(By.Id("react-select-4-option-2")).Click();
            }
        }
        public void EnterSubjecs(string[] subjects)
        {
            foreach (var subject in subjects)
            {
                var subjectTextBox = Driver.FindElement(By.Id("subjectsInput"));
                subjectTextBox.SendKeys(subject);
                subjectTextBox.SendKeys(Keys.Enter);
            }
        }
        public void ChooseHobbies(string[] hobbies)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            var script = string.Empty;

            foreach (var hobbie in hobbies)
            {
                if (hobbie.Equals("Sports"))
                {
                    script = "document.getElementById('hobbies-checkbox-1').click()";
                }
                else if (hobbie.Equals("Reading"))
                {
                    script = "document.getElementById('hobbies-checkbox-2').click()";
                }
                else if (hobbie.Equals("Music"))
                {
                    script = "document.getElementById('hobbies-checkbox-3').click()";
                }

                js.ExecuteScript(script);
            }
        }
        public void ChooseGender(Gender gender)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            var script = string.Empty;

            switch (gender)
            {
                case Gender.Male:
                    script = "document.getElementById('gender-radio-1').click()";
                    break;
                case Gender.Female:
                    script = "document.getElementById('gender-radio-2').click()";
                    break;
                case Gender.Other:
                    script = "document.getElementById('gender-radio-3').click()";
                    break;
                default:
                    break;
            }

            js.ExecuteScript(script);
        }

        public string GetSubmittedValue(string label)
        {
            var tableSubmitted = Driver.FindElement(By.ClassName("table-dark"));
            var tableRows = tableSubmitted.FindElements(By.XPath(".//tr")).ToList();
            tableRows.RemoveAt(0);
            var result = string.Empty;

            foreach (var row in tableRows)
            {
                var cells = row.FindElements(By.TagName("td"));
                if (cells[0].Text.Equals(label))
                {
                    result = cells[1].Text;
                    break;
                }
            }

            return result;
        }
        
    }

    public enum State
    {
        NCR,
        UttarPradesh,
        Haryana,
        Rajasthan
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
