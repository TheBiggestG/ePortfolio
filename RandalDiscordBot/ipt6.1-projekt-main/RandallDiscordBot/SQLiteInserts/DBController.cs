using Microsoft.Data.Sqlite;
using SQLiteInserts.Data;
using SQLiteInserts.Models;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Data.SQLite;

namespace SQLiteInserts
{
    public class DBController
    {
        RandalBotDbContext context = new RandalBotDbContext();

        static void Main(string[] args)
        {
            Instance.CheckDBState();
        }

        private static DBController instance = null;

        private DBController()
        {
        }

        public static DBController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBController();
                }
                return instance;
            }
        }

        public void CheckDBState()
        {
            string databaseFile = "C:\\SQLite\\database\\RandalBotDB.db;";
            string sqlDefinitionFile = "C:\\temporary\\definition\\query.sql";
            string sqlUpdateFile = "C:\\temporary\\update\\query.sql";


            if (!File.Exists(sqlDefinitionFile))
            {
                Console.WriteLine($"SQL definition file '{sqlDefinitionFile}' does not exist.");
                return;
            }

            string sqlDefinition = File.ReadAllText(sqlDefinitionFile);
            string sqlUpdate = File.ReadAllText(sqlUpdateFile);

            if (!File.Exists(databaseFile))
            {
                Console.WriteLine($"Database file '{databaseFile}' does not exist. Creating a new database.");
                SQLiteConnection.CreateFile(databaseFile);
                try
                {
                    using (var connection = new SQLiteConnection($"Data Source={databaseFile};"))
                    {
                        connection.Open();
                        using (var command = new SQLiteCommand(sqlDefinition, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            if (File.Exists(sqlUpdateFile))
            {
                try
                {
                    using (var connection = new SQLiteConnection($"Data Source={databaseFile};"))
                    {
                        connection.Open();
                        using (var command = new SQLiteCommand(sqlUpdate, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }

        public void InsertComplaint(string complainttext, string userloginName, string complainttype)
        {

            var existingComplaintType = context.ComplaintTypes.FirstOrDefault(ct => ct._name == complainttype);
            if (existingComplaintType == null) return;
            var existingUserLogin = context.UserLogins.FirstOrDefault(ct => ct._name == userloginName);
            if (existingUserLogin == null) return;

            var insertval = new Complaint
            {
                _text = complainttext,
                FkUserLogin = existingUserLogin,
                FkComplaintType = existingComplaintType
            }; 

            context.Complaints.Add(insertval);
            Instance.context.SaveChanges();
        }

        public void InsertComplaintType(string complainttypename)
        {
            var insertval = new ComplaintType { _name = complainttypename };

            context.ComplaintTypes.Add(insertval);
            Instance.context.SaveChanges();
        }

        public void InsertDiscordServer(ulong discordserverinternalid, string discordservername)
        {
            var insertval = new DiscordServer
            {
                _internalId = discordserverinternalid,
                _name = discordservername
            };

            context.DiscordServers.Add(insertval);
            Instance.context.SaveChanges();
        }
        public void InsertDiscordUser(ulong discorduserinternalid, string discordusername, int points)
        {
            var insertval = new DiscordUser
            {
                _internalId = discorduserinternalid,
                _name = discordusername,
                Points = points
            };

            context.DiscordUsers.Add(insertval);
            Instance.context.SaveChanges();
        }
        public void InsertLogType(string logtypename)
        {
            var insertval = new LogType
            {
                _name = logtypename
            };

            context.LogTypes.Add(insertval);
            Instance.context.SaveChanges();
        }
        public void InsertUserLog(string userlogtext, ulong discorduserid, string logtype)
        {
            var existingDiscordUser = context.DiscordUsers.FirstOrDefault(ct => ct._internalId == discorduserid);
            if (existingDiscordUser == null) return;
            var existingLogType = context.LogTypes.FirstOrDefault(ct => ct._name == logtype);
            if (existingLogType == null) return;

            var insertval = new UserLog
            { 
                _text = userlogtext,
                FkDiscordUser = existingDiscordUser,
                FkLogType = existingLogType
            };

            context.UserLogs.Add(insertval);
            Instance.context.SaveChanges();
        }

        public void InsertUserLogin(string userloginname, string userloginpassword)
        {
            var insertval = new UserLogin
            {
                _name = userloginname, 
                UserLoginPassword = userloginpassword
            };

            context.UserLogins.Add(insertval);
            Instance.context.SaveChanges();
        }

        public void InsertUserIsInServer(ulong discorduserId, ulong discordserverId)
        {
            var existingDiscordUser = context.DiscordUsers.FirstOrDefault(ct => ct._internalId == discorduserId);
            if (existingDiscordUser == null) return;
            var existingDiscordServer = context.DiscordServers.FirstOrDefault(ct => ct._internalId == discordserverId);
            if (existingDiscordServer == null) return;

            var insertval = new UserIsInServer
            {
                FkDiscordUser = existingDiscordUser,
                FkServer = existingDiscordServer
            };

            context.UserIsInServers.Add(insertval);
            Instance.context.SaveChanges();
        }
        public void InsertUserAccessToServer(string userloginusername, ulong discordserverId)
        {
            var existingUserLogin = context.UserLogins.FirstOrDefault(ct => ct._name == userloginusername);
            if (existingUserLogin == null) return ;
            var existingDiscordServer = context.DiscordServers.FirstOrDefault(ct => ct._internalId == discordserverId);
            if (existingDiscordServer == null) return;

            var insertval = new UserAccessToServer
            {
                FkUserLogin = existingUserLogin,
                FkServer = existingDiscordServer
            };

            context.UserAccessToServers.Add(insertval);
            Instance.context.SaveChanges();
        }

        public List<Complaint> ReadComplaints()
        {
            return context.Complaints.ToList();
        }

        public List<DiscordServer> ReadDiscordServers()
        {
            return context.DiscordServers.ToList();
        }
        public List<DiscordUser> ReadDiscordUsers()
        {
            return context.DiscordUsers.ToList();
        }
        public List<UserLog> ReadUserLog()
        {
            return context.UserLogs.ToList();
        }

        public List<UserLogin> ReadUserLogin()
        {
            return context.UserLogins.ToList();
        }

        public List<UserIsInServer> ReadUserIsInServer()
        {
            return context.UserIsInServers.ToList();
        }
        public List<UserAccessToServer> ReadUserAccessToServer()
        {
            return context.UserAccessToServers.ToList();
        }
    }
}