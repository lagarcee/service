using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
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
using WpfApp2;

namespace wpfapp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {

            string login = TextBoxLogin.Text.Trim();
            string pass = PasswordBoxx.Password.Trim();

            //(local)\

            string myConnectionString = @"Data Source=LAGARCE\MSSQLSERVER01; Initial Catalog=demo; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                connection.Open();
                string mySelectQuery = "SELECT email FROM organization WHERE email = @email";
                string mySelectQuery1 = "SELECT password FROM organization WHERE password = @password";

                SqlCommand sqlCommand = new SqlCommand(mySelectQuery, connection);
                SqlCommand sqlCommand1 = new SqlCommand(mySelectQuery1, connection);

                sqlCommand.Parameters.AddWithValue("@email", TextBoxLogin.Text);
                sqlCommand1.Parameters.AddWithValue("@password", PasswordBoxx.Password);

                SqlDataReader reader = sqlCommand.ExecuteReader();


                if (!reader.HasRows || login.Length < 6)
                {
                    MessageBox.Show("Поле заполнено не корректно");
                    TextBoxLogin.Background = Brushes.Red;
                    reader.Close();


                }

                SqlDataReader reader1 = sqlCommand1.ExecuteReader();

                if (!reader1.HasRows || pass.Length < 6)
                {
                    MessageBox.Show("Поле заполнено не корректно");
                    PasswordBoxx.Background = Brushes.Red;
                }

                else
                {
                    TextBoxLogin.Background = Brushes.Transparent;
                    TextBoxLogin.ToolTip = "";

                    PasswordBoxx.Background = Brushes.Transparent;
                    PasswordBoxx.ToolTip = "";

                    MessageBox.Show("Авторизация прошла успешно!");

                    Organization organization = new Organization();
                    organization.Show();
                }

            }
        }

        private void Button_Window_Main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }


    }
}
