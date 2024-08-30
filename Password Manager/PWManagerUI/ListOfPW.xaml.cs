using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PWManagerUI
{
    /// <summary>
    /// Interaction logic for ListOfPW.xaml
    /// </summary>
    public partial class ListOfPW : Window
    {
        List<string> EntryList = new List<string>();
        PasswordManager PassManInstanceRes = new PasswordManager(".\\Passwords.json", ".\\Users.json");
        string SessionUser;
        public ListOfPW(string SessionUser)
        {
            InitializeComponent();

            this.SessionUser = SessionUser;

            var GroupHash = new HashSet<string>();

            foreach (PasswordManager.PasswordEntry entr in PassManInstanceRes.passwordEntries){
                GroupHash.Add(entr.Group);
            }

            foreach (string str in GroupHash) {
                ComboGroup.Items.Add(str);
            }

            foreach (PasswordManager.PasswordEntry entr in PassManInstanceRes.passwordEntries) {

                if (SessionUser == entr.RegisteredUser)
                {
                    EntryList.Add("URL:\t\t" + entr.Url);
                    EntryList.Add("Username:\t" + entr.UserName);
                    EntryList.Add("Password:\t" + entr.Password);
                    EntryList.Add("");
                }
            }


            MainList.ItemsSource = EntryList;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LogOutEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ReloadContent(object sender, EventArgs e)
        {
            EntryList.Clear();

            foreach (PasswordManager.PasswordEntry entr in PassManInstanceRes.passwordEntries)
            {
                if (entr.Group == ComboGroup.SelectedItem && entr.RegisteredUser == SessionUser)
                {
                    EntryList.Add("URL:\t\t" + entr.Url);
                    EntryList.Add("Username:\t" + entr.UserName);
                    EntryList.Add("Password:\t" + entr.Password);
                    EntryList.Add("");
                }
            }

            MainList.ItemsSource = EntryList;

            MainList.Items.Refresh();
        }
    }
}
