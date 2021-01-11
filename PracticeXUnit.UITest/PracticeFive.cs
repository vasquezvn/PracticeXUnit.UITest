using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using PracticeXUnit.UITest.Pages;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PracticeXUnit.UITest
{
    public class PracticeFive : IClassFixture<ChromeDriverFixture>
    {
        public ChromeDriverFixture ChromeDriverFixture { get; }
        public PracticeFive(ChromeDriverFixture chromeDriverFixture)
        {
            ChromeDriverFixture = chromeDriverFixture;

            ChromeDriverFixture.Driver.Manage().Cookies.DeleteAllCookies();
            ChromeDriverFixture.Driver.Navigate().GoToUrl("about:blank");
            ChromeDriverFixture.Driver.Manage().Window.Maximize();
        }

        [Fact]
        [Trait("Category", "Pracice Five")]
        public void ValidateNumberHasMoreThanThreePrimeNumbers()
        {
            var number = 19;
            var primeCounter = 0;
            var primeNumbers = new List<int>();
            var IsNumberHasMoreThanThreePrimes = false;

            for (int i = number; i > 0; i--)
            {
                var divisibleCounter = 0;

                for (int j = i; j > 0; j--)
                {
                    if (i % j == 0)
                    {
                        divisibleCounter++;
                    }
                }

                if (divisibleCounter == 2)
                {
                    primeCounter++;
                    primeNumbers.Add(i);
                }

            }

            if (primeCounter > 2)
            {
                IsNumberHasMoreThanThreePrimes = true;
            }

            Assert.True(IsNumberHasMoreThanThreePrimes);
        }

        [Fact]
        [Trait("Category", "Pracice Five")]
        public void ValidateContactFormHasBeenSent()
        {
            var theTeaStoryPage = new TheTeaStoryPage(ChromeDriverFixture.Driver);
            theTeaStoryPage.NavigateTo();
            var contactUsPage = theTeaStoryPage.ClickContactUsLink();

            contactUsPage.EnterName("TestName");
            contactUsPage.EnterEmail("test@test.com");
            contactUsPage.EnterMessage("This is a test message");
            var isContactFormSubmitted = contactUsPage.PressSendButton();

            Assert.True(isContactFormSubmitted);
        }

        [Fact]
        [Trait("Category", "Pracice Five")]
        public void ValidateFirstStudentFromWebServer()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/student/");
            var urlParameters = "1";
            Student apiStudent = null;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(urlParameters).Result;

            if (response.IsSuccessStatusCode)
            {
                apiStudent = response.Content.ReadAsAsync<Student>().Result;
            }

            var expectedStudent = new Student() 
            { 
                id = "1", 
                firstName = "Vernon", 
                lastName = "Harper", 
                email = "egestas.rhoncus.Proin@massaQuisqueporttitor.org", 
                programme = "Financial Analysis", 
                courses = new string[]{ "Accounting", "Statistics" } 
            };

            client.Dispose();

            Assert.Equal(expectedStudent, apiStudent);

        }

        [Fact]
        [Trait("Category", "Pracice Five")]
        public async Task ValidateNewStudentFromWebServerAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/student/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var urlPärameters = "list";
                var counterApiStudent = 0;

                var response = client.GetAsync(urlPärameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    counterApiStudent = response.Content.ReadAsAsync<IEnumerable<Student>>().Result.Count();
                }

                var newStudent = new Student()
                {
                    id = counterApiStudent++.ToString(),
                    firstName = $"Student_{counterApiStudent}",
                    lastName = "lastName",
                    email = "email.email.email@test.org",
                    programme = "programme",
                    courses = new string[] { "Accounting", "Statistics" }
                };

                response = await client.PostAsJsonAsync("", newStudent);

                Assert.True(response.IsSuccessStatusCode);
            }
        }

        [Fact]
        [Trait("Category", "Pracice Five")]
        public void ValidateUpdatedStudentFromWebServer()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/student/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var urlPärameters = "1";

                var updatedStudent = new Student()
                {
                    id = "2",
                    firstName = $"Student",
                    lastName = "lastName",
                    email = "email.email.email@test.org",
                    programme = "programme",
                    courses = new string[] { "Accounting", "Statistics" }
                };

                var response = client.PutAsJsonAsync(urlPärameters, updatedStudent).Result;

                Assert.True(response.IsSuccessStatusCode);
            }
        }
    }
}
