using ClientInventoryRL.Service;
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

namespace ClientInventoryRL.Pages
{
    /// <summary>
    /// Логика взаимодействия для ForgotPasswordPage.xaml
    /// </summary>
    public partial class ForgotPasswordPage : Page
    {
        public string Email { get; set; }
        public string GeneratedCode { get; set; }
        public Random rnd = new Random();
        public ForgotPasswordPage()
        {
            InitializeComponent();
            DataContext = this;
            Email = "dinarhertz@gmail.com";
        }



        private void BGetCode_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(Email, @"^[\w_.]+@([\w][-\w]?[\w]+\.)+[A-Za-z]{2,4}$"))
            {
                MessageBox.Show("Некорректный email");
                return;
            }



            SPCode.Visibility = Visibility.Visible;
            GeneratedCode = rnd.Next(100000, 999999).ToString();
            MailSendService mailSend = new MailSendService();
            string userName = "Flason";
            string body = $@"<tbody>
                                <tr>
                                    <td align=""center"" valign=""top"">
                                        <table border=""0"" cellpadding=""0"" cellspacing=""0"" height=""90"" width=""100%"" style=""background-color:#fff;background-image:none;background-repeat:repeat;background-position:top left"">
                                            <tr>
                                                <td align=""center"" valign=""middle"">
                                                    <div style=""text-align:left;padding:20px 0 20px 0;font-size:30px;line-height:1.5;width:80%;color:#9147ff;text-align:center;font-family: monospace;font-weight: bold;"">
                                                        INVENTORY RL
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align=""center"" valign=""top"">
                                        <table border=""0"" cellpadding=""0"" cellspacing=""0"" height=""1"" width=""100%"">
                                            <tr>
                                                <td align=""center"" valign=""middle"" style=""background-color:#eeeeee"" width=""249""></td>
                                                <td align=""center"" valign=""middle"" style=""background-color:#9147ff"" width=""102""></td>
                                                <td align=""center"" valign=""middle"" style=""background-color:#eeeeee"" width=""249""></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>  
                                    <td align=""center"" valign=""middle"">
                                        <div style=""text-align:left;padding:20px 0 20px 0;font-size:14px;line-height:1.5;width:80%;color:#9147ff;text-align:center"">
                                            Здравствуйте, {userName}!
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align=""center"" valign=""middle"">
                                        <div style=""text-align:left;padding:0 0 20px 0;font-size:14px;line-height:1.5;width:80%"">
                                            Чтобы восстановить пароль, введите следующий код:
                                        </div>
                                        <div style=""background:#faf9fa;border:1px solid #dad8de;text-align:center;padding:5px;margin:0 0 5px 0;font-size:24px;line-height:1.5;width:80%"">
                                            {GeneratedCode}
                                        </div>
                                        <div style=""text-align:center;padding:0 0 20px 0;font-size:12px;font-style:italic;font-weight:bold;line-height:1.5;width:80%"">
                                            Обратите внимание, что срок действия этого кода истекает после закрытия приложения
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align=""center"" valign=""middle"">
                                        <div style=""text-align:left;padding:0 0 20px 0;font-size:14px;line-height:1.5;width:80%"">
                                            Спасибо,<br>Служба поддержки InventoryRealLife
                                        </div>
                                    </td>
                                </tr>
                            </tbody>";

            var mail = mailSend.CreateMail("", "flason.smtp@gmail.com", $"{Email}", "text", body);
            mailSend.SendMail("smtp.gmail.com", 587, "flason.smtp@gmail.com", "sbwowwurankglfjp", mail);
        }

        private void BGiveCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 6)
            {
                if ((sender as TextBox).Text == GeneratedCode)
                {
                    SPCode.Visibility = Visibility.Collapsed;
                    var selectedEmail = App.DB.User.FirstOrDefault(x => x.Email == Email);
                    if (selectedEmail != null)
                    {
                        selectedEmail.Password = GenerateLoginPassword();
                        App.DB.SaveChanges();
                        var result = MessageBox.Show(selectedEmail.Password, 
                                                    "Новый пароль",
                                                    MessageBoxButton.OK,
                                                    MessageBoxImage.Information);
                        if (result == MessageBoxResult.OK || result == MessageBoxResult.Cancel)
                        {
                            NavigationService.GoBack();
                        };

                    }
                }
            }
        }

        private string GenerateLoginPassword()
        {
            int length = 8;

            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random random = new Random();
            while (0 < length--)
            {
                res.Append(valid[random.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
