using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

using ClientInventoryRL.Model;

namespace ClientInventoryRL.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        User contextUser;
        public RegistrationPage()
        {
            InitializeComponent();
            contextUser = new User();
            DataContext = contextUser;
        }

        private void BUpload_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BSaveUser_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(contextUser.Login) == true)
            {
                errorMessage += "Введите логин\n";
            }
            if (string.IsNullOrWhiteSpace(contextUser.Password) == true)
            {
                errorMessage += "Введите пароль\n";
            }
            if (string.IsNullOrWhiteSpace(contextUser.LastName) == true)
            {
                errorMessage += "Введите фамилию\n";
            }
            if (string.IsNullOrWhiteSpace(contextUser.FirstName) == true)
            {
                errorMessage += "Введите имя\n";
            }
            if (string.IsNullOrWhiteSpace(contextUser.Patronymic) == true)
            {
                errorMessage += "Введите отчество\n";
            }
            if (string.IsNullOrWhiteSpace(contextUser.Phone) == true)
            {
                errorMessage += "Введите номер\n";
            }
            else if(contextUser.Phone.Length > 11)
            {
                errorMessage += "Некорректный номер\n";
            }
            if (string.IsNullOrWhiteSpace(contextUser.Email) == true)
            {
                errorMessage += "Введите email\n";
            }
            else if(!Regex.IsMatch(contextUser.Email, @"^[\w_.]+@([\w][-\w]?[\w]+\.)+[A-Za-z]{2,4}$"))
            {
                errorMessage += "Некорректный email\n";
            }

            if (errorMessage != string.Empty) 
            {
                MessageBox.Show(errorMessage);
                return;
            }

            contextUser.RoleId = 1;
            App.DB.User.Add(contextUser);

            try
            {
                App.DB.SaveChanges();
                MessageBox.Show("Пользователь успешно сохранен");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
