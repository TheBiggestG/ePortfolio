using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace PWManagerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Generally used variables
        /// </summary>
        
        byte StateOfWindow;

        public PasswordManager PassManInstance = new PasswordManager(".\\Passwords.json", ".\\Users.json");

        public MainWindow()
        {
            InitializeComponent();
            MainUserInit();
        }

        /// <summary>
        /// Main pages
        /// </summary>
        
        public void MainUserInit()
        {
            StateOfWindow = 1;

            Titlebar.Content = "PW Manager";

            //Labels
            Label1.Content = "User:";
            Label2.Content = "PW:";
            //Buttons
            AuxButton.Content = "New User";
            LabelAux.Content = "Welcome.";

            Label2.Visibility = Visibility.Visible;
            TextBox2.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Hidden;
            TextBox3.Visibility = Visibility.Hidden;
            Label4.Visibility = Visibility.Hidden;
            TextBox4.Visibility = Visibility.Hidden;
            Label5.Visibility = Visibility.Hidden;
            TextBox5.Visibility = Visibility.Hidden;
            Label6.Visibility = Visibility.Hidden;
            TextBox6.Visibility = Visibility.Hidden;

            LoginButton.Visibility = Visibility.Visible;
            AuxButton3.Visibility = Visibility.Visible;
            AuxButton2.Visibility = Visibility.Hidden;
            ReturnButton.Visibility = Visibility.Hidden;
        }
        public void NewUserInit()
        {
            StateOfWindow = 2;

            Titlebar.Content = "New User";

            //Labels
            Label1.Content = "User:";
            Label2.Content = "PW:";
            //Buttons
            AuxButton.Content = "Confirm choice";

            Label2.Visibility = Visibility.Visible;
            TextBox2.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Hidden;
            TextBox3.Visibility = Visibility.Hidden;
            Label4.Visibility = Visibility.Hidden;
            TextBox4.Visibility = Visibility.Hidden;
            Label5.Visibility = Visibility.Hidden;
            TextBox5.Visibility = Visibility.Hidden;
            Label6.Visibility = Visibility.Hidden;
            TextBox6.Visibility = Visibility.Hidden;

            AuxButton2.Visibility = Visibility.Hidden;
            AuxButton3.Visibility = Visibility.Hidden;
            LoginButton.Visibility = Visibility.Hidden;
            ReturnButton.Visibility = Visibility.Visible;
        }
        public void NewEntryInit() {
            StateOfWindow = 3;

            Titlebar.Content = "New Entry";

            //Labels
            Label1.Content = "URL:";
            Label2.Content = "User:";
            Label3.Content = "Password:";
            Label4.Content = "Group:";
            //Buttons
            AuxButton.Content = "Confirm choice";
            AuxButton2.Content = "Generate";

            Label2.Visibility = Visibility.Visible;
            TextBox2.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Visible;
            TextBox3.Visibility = Visibility.Visible;
            Label4.Visibility = Visibility.Visible;
            TextBox4.Visibility = Visibility.Visible;
            Label5.Visibility = Visibility.Visible;
            TextBox5.Visibility = Visibility.Visible;
            Label6.Visibility = Visibility.Visible;
            TextBox6.Visibility = Visibility.Visible;

            AuxButton2.Visibility = Visibility.Visible;
            AuxButton3.Visibility = Visibility.Hidden;
            LoginButton.Visibility = Visibility.Hidden;
            ReturnButton.Visibility = Visibility.Visible;
        }
        public void RemoveUserInit()
        {
            StateOfWindow = 4;

            Titlebar.Content = "Remove User";

            //Labels
            Label1.Content = "User:";
            Label2.Content = "PW:";
            //Buttons
            AuxButton.Content = "Confirm choice";

            Label2.Visibility = Visibility.Visible;
            TextBox2.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Hidden;
            TextBox3.Visibility = Visibility.Hidden;
            Label4.Visibility = Visibility.Hidden;
            TextBox4.Visibility = Visibility.Hidden;
            Label5.Visibility = Visibility.Hidden;
            TextBox5.Visibility = Visibility.Hidden;
            Label6.Visibility = Visibility.Hidden;
            TextBox6.Visibility = Visibility.Hidden;

            AuxButton2.Visibility = Visibility.Hidden;
            AuxButton3.Visibility = Visibility.Hidden;
            LoginButton.Visibility = Visibility.Hidden;
            ReturnButton.Visibility = Visibility.Visible;
        }
        public void RemoveEntryInit()
        {
            StateOfWindow = 5;

            Titlebar.Content = "Remove Entry";

            //Labels
            Label1.Content = "Reg. User:";
            Label2.Content = "Reg. PW:";
            Label3.Content = "URL:";
            //Buttons
            AuxButton.Content = "Confirm choice";

            Label2.Visibility = Visibility.Visible;
            TextBox2.Visibility = Visibility.Visible;
            Label3.Visibility = Visibility.Visible;
            TextBox3.Visibility = Visibility.Visible;
            Label4.Visibility = Visibility.Hidden;
            TextBox4.Visibility = Visibility.Hidden;
            Label5.Visibility = Visibility.Hidden;
            TextBox5.Visibility = Visibility.Hidden;
            Label6.Visibility = Visibility.Hidden;
            TextBox6.Visibility = Visibility.Hidden;

            AuxButton2.Visibility = Visibility.Hidden;
            AuxButton3.Visibility = Visibility.Hidden;
            LoginButton.Visibility = Visibility.Hidden;
            ReturnButton.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Events / triggers with buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void AuxButtonSwitch(object sender, RoutedEventArgs e)
        {
            switch (StateOfWindow) {

                case 1:
                    ResetAndGoDefault();
                    NewUserInit();
                    break;
                case 2:
                    LabelAux.Content = PassManInstance.PasswordSaveUser(TextBox1.Text, TextBox2.Text);
                    if (LabelAux.Content != "Error") ResetAndGoDefault();
                    break;
                case 3:
                    LabelAux.Content = PassManInstance.PasswordSaveFun(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text);
                    if (LabelAux.Content != "Error") ResetAndGoDefault();
                    break;
                case 4:
                    LabelAux.Content = PassManInstance.PasswordDeleteUser(TextBox1.Text, TextBox2.Text);
                    if (LabelAux.Content != "Error") ResetAndGoDefault();
                    break;
                case 5:
                    LabelAux.Content = PassManInstance.PasswordDeletePassword(TextBox1.Text, TextBox2.Text, TextBox3.Text);
                    if (LabelAux.Content != "Error") ResetAndGoDefault();
                    break;
            }

        }
        private void NewEntryEvent(object sender, RoutedEventArgs e)
        {
            ResetAndGoDefault();
            NewEntryInit();
        }
        private void ReturnEvent(object sender, RoutedEventArgs e){
            ResetAndGoDefault();
            MainUserInit();
        }
        private void LoginEvent(object sender, RoutedEventArgs e)
        {
            string PlaceholderUser = TextBox1.Text;
            string PlaceholderPassword = TextBox2.Text;

            foreach (PasswordManager.UserEntry UserEntry in PassManInstance.UserEntries) {
                if ((PlaceholderPassword == UserEntry.Password) && (PlaceholderUser == UserEntry.UserName))
                {
                    ListOfPW qt = new ListOfPW(PlaceholderUser);
                    qt.InitializeComponent();
                    qt.Show();
                }
                else LabelAux.Content = "Error";
            }

            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        private void AuxButton2Switch(object sender, RoutedEventArgs e)
        {
            PasswordGenerator PasswordGenerator = new PasswordGenerator();
            TextBox3.Text = PasswordGenerator.PasswordGen();
        }
        private void RemoveUserEvent(object sender, RoutedEventArgs e)
        {
            RemoveUserInit();
        }
        private void RemoveEntryEvent(object sender, RoutedEventArgs e)
        {
            RemoveEntryInit();
        }

        /// <summary>
        /// General Funcitonality
        /// </summary>
        private void ClearBoxes()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";


            Label1.Content = "";
            Label2.Content = "";
            Label3.Content = "";
        }
        private void ResetAndGoDefault() {
            LabelAux.Content = "Welcome.";
            ClearBoxes();
            MainUserInit();
        }
    }
}
