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
using ClientInventoryRL.Model;

namespace ClientInventoryRL.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        User contextUser;
        public AuthorizationPage()
        {
            InitializeComponent();
            contextUser = new User();
            DataContext = contextUser;
        }

        private void BSignIn_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = App.DB.User.FirstOrDefault(x => x.Login == contextUser.Login);

            if (selectedUser == null || selectedUser.Password != contextUser.Password)
            {
                MessageBox.Show("Неправильный логин или пароль", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (selectedUser.RoleId != 1)
            {
                MessageBox.Show("Данный пользователь не имеет прав в системе", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NavigationService.Navigate(new MenuClientPage());
        }

        private void BSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void TBForgotPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ForgotPasswordPage());
        }
    }
}
