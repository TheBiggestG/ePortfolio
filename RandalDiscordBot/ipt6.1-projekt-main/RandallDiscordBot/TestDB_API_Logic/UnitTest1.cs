using SQLiteInserts.Models;
using SQLiteInserts;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Discord;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace TestDB_API_Logic
{
    public class UnitTest1
    {
        [Fact]
        public void TestInsertDiscordUserInDB()
        {
            //Arrange
            List<DiscordUser> discordUsers;
            List<string> discordUserNames = new List<string>();

            string discordUserName = "Unit Test user";

            //Act
            DBController.Instance.InsertDiscordUser(0, discordUserName, 0);
            discordUsers = DBController.Instance.ReadDiscordUsers();
            foreach (DiscordUser discordUser in discordUsers)
            {
                discordUserNames.Add(discordUser._name);
            }
            //Assert

            Assert.Contains(discordUserName, discordUserNames);
        }

        [Fact]
        public void TestGenerateDB()
        {
            //Arrange
            string Filepath = "C:\\SQLite\\database\\RandalBotDB.db;";
            List<DiscordUser> discordUsers;
            //Act
            File.Delete(Filepath);
            DBController.Instance.CheckDBState();
            discordUsers = DBController.Instance.ReadDiscordUsers();
            //Assert
            Assert.Empty(discordUsers);
        }

        [Fact]

        public void TestAPI() 
        {
            //Arrange
            string DiscordUserName = "UnitTestForAPI";
            string URL = "http://localhost:5000/discordbot/SearchByName?guildId=123&name=UnitTestForAPI";

            HttpClient client = new HttpClient();

            async Task<string> GetApiResponseAsync(string url)
            {
                try
                {
                    // Send a GET request to the specified URL
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    // Read the response content as a string
                    var responseBody = await response.Content.ReadAsStringAsync();
                    string user = JsonSerializer.Deserialize<DiscordUser>(responseBody, new JsonSerializerOptions{PropertyNameCaseInsensitive = true})._name;

                    return user;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                    return "AllowAnonymousAttribute";
                }
            }

            //Act
            DBController.Instance.InsertDiscordUser(123, DiscordUserName, 0);
            DBController.Instance.InsertDiscordServer(123, "UnittestAPIServer");
            DBController.Instance.InsertUserIsInServer(123, 123);

            var response = GetApiResponseAsync(URL);

            //Assert

            Assert.Equal(DiscordUserName, response.Result);
        }
    }
}