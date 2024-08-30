using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography.Xml;
using System.Buffers.Text;
using System.Threading;

namespace PWManagerUI
{
    public class PasswordManager
    {
        EncryptionClass EncryptionClass = new EncryptionClass();
        string password = "rfg387fvg43287fv";
        byte[] IV = {123,23,41,76,45,96,34,163,245,175,221,200,101,137,189,69 };
        public List<PasswordEntry> passwordEntries = new List<PasswordEntry>();
        public List<UserEntry> UserEntries = new List<UserEntry>();
        string filePathPass;
        string filePathUser;
        public PasswordManager(string filePathPass, string filePathUser)
        {
            this.filePathUser = filePathUser;
            this.filePathPass = filePathPass;
            // Load existing data from the file, if any
            LoadData();

        }

        public string PasswordSaveFun(string Url, string UserName, string Password, string Group, string RegisteredUser, string RegisteredUserPassword)
        {
            if (UserEntries.Find(Entry => Entry.UserName == RegisteredUser && Entry.Password == RegisteredUserPassword) != null)
            {
                // Create a PasswordEntry object with the generated ID and input parameters
                var entry = new PasswordEntry
                {
                    Url = Url,
                    UserName = UserName,
                    Group = Group,
                    RegisteredUser = RegisteredUser,
                    Password = Password
                };

                // Add the entry to the list
                passwordEntries.Add(entry);

                // Save the updated data to the file
                SaveData();
            }
            else return "Error";

            return "";
        }
        public string PasswordSaveUser(string UserName, string Password)
        {

            if (UserEntries.Find(Entry => Entry.UserName == UserName && Entry.Password == Password) == null)
            {
                // Create a PasswordEntry object with the generated ID and input parameters
                var entry = new UserEntry
                {
                    UserName = UserName,
                    Password = Password
                };

                // Add the entry to the list
                UserEntries.Add(entry);

                // Save the updated data to the file
                SaveData();
            }
            else return "Error";

            return "";
        }

        public string PasswordDeleteUser(string UserNameDeletion, string PasswordDeletion)
        {
            if (UserEntries.Find(Entry => Entry.UserName == UserNameDeletion && Entry.Password == PasswordDeletion) != null)
            {
                UserEntry ToDeleteUserEntry = UserEntries.Find(Entry => Entry.UserName == UserNameDeletion && Entry.Password == PasswordDeletion);

                UserEntries.Remove(ToDeleteUserEntry);

                foreach (PasswordEntry entry in passwordEntries.ToList())
                {

                    if (entry.RegisteredUser == ToDeleteUserEntry.UserName)
                        passwordEntries.Remove(entry);
                }

                SaveData();
            }

            else return "Error";

            return "";
        }

        public string PasswordDeletePassword(string UserNameDeletion, string PasswordDeletion, string URLDeletion)
        {
            UserEntry ToDeleteUser = UserEntries.Find(Entry => Entry.UserName == UserNameDeletion);

            if (ToDeleteUser != null && ToDeleteUser.Password == PasswordDeletion)
            {
                PasswordEntry ToDeletePasswordEntry = passwordEntries.Find(Entry => Entry.RegisteredUser == UserNameDeletion && Entry.Url == URLDeletion);

                if (ToDeletePasswordEntry != null)
                {

                    passwordEntries.Remove(ToDeletePasswordEntry);

                    SaveData();
                }

                else return "error";
            }

            else return "error";

            return "";
        }

        public void LoadData()
        {
            bool ClearInstance = false;

            if (!File.Exists(filePathUser)) { File.WriteAllText(filePathUser, ""); ClearInstance = true; };
            if (!File.Exists(filePathPass)) { File.WriteAllText(filePathPass, ""); ClearInstance = true; };

            if (ClearInstance == false)
            {
                // Read existing data from the file and deserialize it
                string jsonDataUser = File.ReadAllText(filePathUser);
                string jsonDataPass = File.ReadAllText(filePathPass);

                byte[] ExportPassByte = Convert.FromBase64String(jsonDataPass);
                byte[] ExportUserByte = Convert.FromBase64String(jsonDataUser);

                UserEntries = JsonConvert.DeserializeObject<List<UserEntry>>(EncryptionClass.Decrypt(ExportUserByte, EncryptionClass.GetHash(password), IV));
                passwordEntries = JsonConvert.DeserializeObject<List<PasswordEntry>>(EncryptionClass.Decrypt(ExportPassByte, EncryptionClass.GetHash(password), IV));
            }
        }

        private void SaveData()
        {
            byte[] EncryptedPass = EncryptionClass.Encrypt(JsonConvert.SerializeObject(passwordEntries, Newtonsoft.Json.Formatting.Indented), EncryptionClass.GetHash(password), IV);
            byte[] EncryptedUser = EncryptionClass.Encrypt(JsonConvert.SerializeObject(UserEntries, Newtonsoft.Json.Formatting.Indented), EncryptionClass.GetHash(password), IV);

            string finalResultPass = Convert.ToBase64String(EncryptedPass);
            string finalResultUser = Convert.ToBase64String(EncryptedUser);


            File.WriteAllText(filePathPass, finalResultPass);
            File.WriteAllText(filePathUser, finalResultUser);
        }


        //Objects
        public class PasswordEntry
        {
            public int Id { get; set; }
            public string Group { get; set; }
            public string Url { get; set; }
            public string RegisteredUser { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class UserEntry
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }


        //static void Main(string[] args)
        //{
        //    // Specify the file path
        //    string filePath = ".\\PasswordSave.json";

        //    // Create a PasswordManager instance with the file path
        //    PasswordManager passwordManager = new PasswordManager(filePath);

        //    // Example usage of PasswordSaveFun function
        //    passwordManager.PasswordSaveFun("greg", "https://prem.com", "qwert", "mnbvc");
        //}
    }


}
