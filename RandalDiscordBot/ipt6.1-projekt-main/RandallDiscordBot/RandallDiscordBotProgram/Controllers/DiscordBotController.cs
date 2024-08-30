 using Microsoft.AspNetCore.Mvc;
using Discord;
using Discord.WebSocket;
using System.Reflection.Metadata.Ecma335;
using SQLiteInserts;
using SQLiteInserts.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace RandalBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscordBotController : ControllerBase
    {
        DiscordSocketClient _client;

        public DiscordBotController(DiscordSocketClient client)
        {
            _client = client;
        }

        [HttpGet(/*Name = "SearchByName"*/ "SearchByName")]
        public ActionResult<DiscordUser> SearchByName(ulong guildId, string name)
        {
            List<UserIsInServer> userisinserver = DBController.Instance.ReadUserIsInServer();
            List<DiscordServer> discordServers = DBController.Instance.ReadDiscordServers();
            List<DiscordUser> discordUser = DBController.Instance.ReadDiscordUsers();
            List<DiscordUser> returningList = new List<DiscordUser>();

            foreach (UserIsInServer instance in userisinserver)
            {
                if (instance.FkServer._internalId == guildId)
                {
                    if (instance.FkDiscordUser._name.Contains(name))
                    {
                        returningList.Add(instance.FkDiscordUser);
                    }
                }
            }
            try
            {
                var returnObject = returningList.First();
                return returnObject;
            }
            catch
            {
                
            }
            return null;
        }


        [HttpGet(/*Name = "SearchByName"*/ "isLoginValid")]
        public ActionResult<bool> SearchByName(string username, string password)
        {
            try
            {
                List<UserLogin> UserLogins = DBController.Instance.ReadUserLogin();
                bool doesExist = false;

                foreach (UserLogin instance in UserLogins)
                {
                    if (instance._name == username && instance.UserLoginPassword == password)
                    {
                        doesExist = true;
                    }
                }

                return doesExist;
            }
            catch
            {
                return null;
            }
        }

        [HttpGet(/*Name = "SearchByName"*/ "TestDiscordUser")]
        public ActionResult<DiscordUser> testUser()
        {


            try
            {
                List<DiscordUser> discordUser = DBController.Instance.ReadDiscordUsers();
                var returnObject = discordUser.Find(e => e._internalId == 1);
                return returnObject;
            }
            catch
            {

            }
            return null;
        }


        [HttpGet(/*Name = "SearchByName"*/ "getserverbylogin")]
        public ActionResult<List<DiscordServer>> GetAllServersByLogin(string username, string password)
        {
            List<UserAccessToServer> userhasaccesstoserver = DBController.Instance.ReadUserAccessToServer();
            List<UserLogin> userLogins = DBController.Instance.ReadUserLogin();
            List<DiscordServer> discordServers = DBController.Instance.ReadDiscordServers();

            List<DiscordServer> returningList = new List<DiscordServer>();

            foreach (UserAccessToServer instance in userhasaccesstoserver)
            {
                var selUserLogin = userLogins.Find(e => e._id == instance.FkUserLoginId);

                if (selUserLogin._name == username && selUserLogin.UserLoginPassword == password)
                {
                    var server = discordServers.Find(e => e._id == instance.FkServerId);
                    if (server != null)
                    {
                        returningList.Add(server);
                    }
                }
            }
            try
            {
                return returningList;
            }
            catch
            {

            }
            return null;
        }


        //[HttpGet(/*Name = "GetUserInfo"*/ "GetUserInfo")]
        //public ActionResult<IEnumerable<DiscordUser>> GetUserInfo(ulong guildId, string name)
        //{
        //    var guild = _client.GetGuild(1186215061170176070);

        //    var guildUser = guild.Users.FirstOrDefault(user => user.Username == name);

        //    DiscordUser discordUser = new DiscordUser(guildUser.Username, guildUser.Id, 12 /*temporary*/);

        //    return Ok(discordUser);
        //}

        //public class testClass {
        //    string _asd;
        //    public testClass(string asds) { _asd = asds; }
        //}

    }
}
