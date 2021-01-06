using System;
using Xunit;
using PracticeXUnit.UITest.Pages;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace PracticeXUnit.UITest
{
    public class PracticeFour : IClassFixture<ChromeDriverFixture>
    {
        public ChromeDriverFixture ChromeDriverFixture { get; }
        public PracticeFour(ChromeDriverFixture chromeDriverFixture)
        {
            ChromeDriverFixture = chromeDriverFixture;

            ChromeDriverFixture.Driver.Manage().Cookies.DeleteAllCookies();
            ChromeDriverFixture.Driver.Navigate().GoToUrl("about:blank");
            ChromeDriverFixture.Driver.Manage().Window.Maximize();

        }

        [Fact]
        [Trait("Category", "Practice four")]
        public void ValidateAllClients()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            var resultList = new List<string>();

            try
            {
                using(var conn = new SqlConnection(connectionString))
                {
                    var query = "SELECT name, lastname FROM Client";
                    var cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (var dbReader = cmd.ExecuteReader())
                    {
                        while (dbReader.Read())
                        {
                            resultList.Add(dbReader["name"].ToString() + " " + dbReader["lastname"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            var expectedList = new List<string>() { "test1 lastname1", "test2 lastname2" };

            Assert.Equal(expectedList, resultList);
        }

        [Fact]
        [Trait("Category", "Practice four")]
        public void ValidateClientById()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            var resultClient = string.Empty;
            var clientId = 2;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var query = $"SELECT name, lastname FROM Client WHERE id = {clientId}";
                    var cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (var dbReader = cmd.ExecuteReader())
                    {
                        while (dbReader.Read())
                        {
                            resultClient = dbReader["name"].ToString() + " " + dbReader["lastname"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Assert.Equal("test2 lastname2", resultClient);
        }

        [Fact]
        [Trait("Category", "Practice four")]
        public void ValidateClientDeletionById()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            var clientId = 3;
            var isDeleted = false;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM Client WHERE id = {clientId}";
                    var cmd = new SqlCommand(query, conn);
                    conn.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        isDeleted = true;
                    }

                    query = $"SELECT * FROM Client WHERE id = {clientId}";
                    cmd = new SqlCommand(query, conn);

                    if (cmd.ExecuteNonQuery() >= 1)
                    {
                        isDeleted = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Assert.True(isDeleted);
        }

        [Fact]
        [Trait("Category", "Practice four")]
        public void ValidateUpdateClientById()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            var clientId = 2;
            var isUpdated = false;
            var nameUpdated = "nameUpdate1";
            var lastnameUpdated = "lastnameUpdated1";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var query = $"UPDATE Client SET name = '{nameUpdated}', lastname = '{lastnameUpdated}' WHERE id = {clientId}";
                    var cmd = new SqlCommand(query, conn);
                    conn.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        isUpdated = true;
                    }

                    query = $"SELECT name, lastname FROM Client WHERE id = {clientId}";
                    cmd = new SqlCommand(query, conn);

                    using (var dbReader = cmd.ExecuteReader())
                    {
                        while (dbReader.Read())
                        {
                            if (!dbReader["name"].ToString().Equals(nameUpdated) || !dbReader["lastname"].ToString().Equals(lastnameUpdated))
                            {
                                isUpdated = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Assert.True(isUpdated);
        }

        [Fact]
        [Trait("Category", "Practice four")]
        public void ValidateInsertClient()
        {
            var random = new Random();
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            var isInserted = false;
            var newName = "newName_" + random.Next(100);
            var newLastname = "newLastname_" + random.Next(100);
            var newEmail = "test@test.com";
            var newProgramme = "Pascal";
            var newCourses = "NG";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO Client (name, lastname, email, programme, courses) " +
                        $"VALUES('{newName}', '{newLastname}', '{newEmail}', '{newProgramme}', '{newCourses}')";
                    var cmd = new SqlCommand(query, conn);
                    conn.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        isInserted = true;
                    }

                    query = $"SELECT name, lastname FROM Client WHERE name = '{newName}'";
                    cmd = new SqlCommand(query, conn);

                    using (var dbReader = cmd.ExecuteReader())
                    {
                        while (dbReader.Read())
                        {
                            if (!dbReader["name"].ToString().Equals(newName) || !dbReader["lastname"].ToString().Equals(newLastname))
                            {
                                isInserted = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Assert.True(isInserted);
        }

    }
}
