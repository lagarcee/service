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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfapp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {

            string login = TextBoxLogin.Text.Trim();
            string pass = PasswordBox.Password.Trim();
            string pass_2 = PasswordRepitBox.Password.Trim();
            string email = TextBoxEmail.Text.ToLower().Trim();

            if (login.Length < 6)
            {
                TextBoxLogin.ToolTip = "Поле заполнено не корректно";
                TextBoxLogin.Background = Brushes.Red;
            }
            else if (pass.Length < 6)
            {
                TextBoxLogin.Background = Brushes.White;
                PasswordBox.ToolTip = "Поле заполнено не корректно";
                PasswordBox.Background = Brushes.Red;
            }
            else if (pass != pass_2)
            {
                PasswordBox.Background = Brushes.White;
                PasswordRepitBox.ToolTip = "Пароль не совпадает";
                PasswordRepitBox.Background = Brushes.Red;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                PasswordRepitBox.Background = Brushes.White;
                TextBoxEmail.ToolTip = "Формат не верный";
                TextBoxEmail.Background = Brushes.Red;
            }
            else
            {
                TextBoxLogin.Background = Brushes.Transparent;
                TextBoxLogin.ToolTip = "";

                TextBoxEmail.Background = Brushes.Transparent;
                TextBoxEmail.ToolTip = "";

                PasswordBox.Background = Brushes.Transparent;
                PasswordBox.ToolTip = "";

                PasswordRepitBox.Background = Brushes.Transparent;
                PasswordRepitBox.ToolTip = "";

                MessageBox.Show("Регистрация прошла успешно");
                Close();
            }

        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
