using SQLiteInserts.Data;
using SQLiteInserts.Models;
using System;

namespace SQLiteInserts
{
    public class Program
    {
        RandalBotDbContext context = new RandalBotDbContext(); 

        public static void Main()
        {
            Program asd = new Program();

            Console.Write(asd.context.Database.EnsureCreated());

            //asd.InsertDiscordUser(1, "ASD", 1);



            asd.InsertUserLog("Existin users", 1, "bla1");

            asd.InsertDiscordUser();
            asd.InsertDiscordServer();


            asd.context.SaveChanges();

            //Console.WriteLine(asd.context.DiscordUsers.First());
        }

        public void InsertComplaint(string complainttext, string userloginName, string complainttype)
        {

            var existingComplaintType = context.ComplaintTypes.FirstOrDefault(ct => ct.ComplaintTypeName == complainttype);
            if (existingComplaintType == null) return;
            var existingUserLogin = context.UserLogins.FirstOrDefault(ct => ct.UserLoginName == userloginName);
            if (existingUserLogin == null) return;

            var insertval = new Complaint
            {
                ComplaintText = complainttext,
                FkUserLogin = existingUserLogin,
                FkComplaintType = existingComplaintType
            }; 

            context.Complaints.Add(insertval);
        }

        public void InsertComplaintType(string complainttypename)
        {
            var insertval = new ComplaintType { ComplaintTypeName = complainttypename };

            context.ComplaintTypes.Add(insertval);
        }

        public void InsertDiscordServer(int discordserverinternalid, string discordservername)
        {
            var insertval = new DiscordServer
            {
                DiscordServerInternalId = discordserverinternalid,
                DiscordServerName = discordservername
            };

            context.DiscordServers.Add(insertval);
        }
        public void InsertDiscordUser(int discorduserinternalid, string discordusername, int points)
        {
            var insertval = new DiscordUser
            {
                DiscordUserInternalId = discorduserinternalid,
                DiscordUserName = discordusername,
                Points = points
            };

            context.DiscordUsers.Add(insertval);
        }
        public void InsertLogType(string logtypename)
        {
            var insertval = new LogType
            {
                LogTypeName = logtypename
            };

            context.LogTypes.Add(insertval);
        }
        public void InsertUserLog(string userlogtext, int discorduserid, string logtype)
        {
            var existingDiscordUser = context.DiscordUsers.FirstOrDefault(ct => ct.DiscordUserInternalId == discorduserid);
            if (existingDiscordUser == null) return;
            var existingLogType = context.LogTypes.FirstOrDefault(ct => ct.LogTypeName == logtype);
            if (existingLogType == null) return;

            var insertval = new UserLog
            { 
                UserLogText = userlogtext,
                FkDiscordUser = existingDiscordUser,
                FkLogType = existingLogType
            };

            context.UserLogs.Add(insertval);
        }

        public void InsertUserLogin(string userloginname, string userloginpassword)
        {
            var insertval = new UserLogin
            {
                UserLoginName = userloginname, 
                UserLoginPassword = userloginpassword
            };

            context.UserLogins.Add(insertval);
        }

        public void InsertUserIsInServer(int discorduserId, int discordserverId)
        {
            var existingDiscordUser = context.DiscordUsers.FirstOrDefault(ct => ct.DiscordUserInternalId == discorduserId);
            if (existingDiscordUser == null) return;
            var existingDiscordServer = context.DiscordServers.FirstOrDefault(ct => ct.DiscordServerInternalId == discordserverId);
            if (existingDiscordServer == null) return;

            var insertval = new UserIsInServer
            {
                FkDiscordUser = existingDiscordUser,
                FkServer = existingDiscordServer
            };

            context.UserIsInServers.Add(insertval);
        }
        public void InsertUserAccessToServer(string userloginusername, int discordserverId)
        {
            var existingUserLogin = context.UserLogins.FirstOrDefault(ct => ct.UserLoginName == userloginusername);
            if (existingUserLogin == null) return ;
            var existingDiscordServer = context.DiscordServers.FirstOrDefault(ct => ct.DiscordServerInternalId == discordserverId);
            if (existingDiscordServer == null) return;

            var insertval = new UserAccessToServer
            {
                FkUserLogin = existingUserLogin,
                FkServer = existingDiscordServer
            };

            context.UserAccessToServers.Add(insertval);
        }
    }
}