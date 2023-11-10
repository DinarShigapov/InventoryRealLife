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
using MimeKit;
using MailKit.Net.Smtp;

namespace ClientInventoryRL.Windows
{
    /// <summary>
    /// Логика взаимодействия для ForgotPasswordWindow.xaml
    /// </summary>
    public partial class ForgotPasswordWindow : Window
    {
        public string Email { get; set; }
        public ForgotPasswordWindow()
        {
            InitializeComponent();
            DataContext = this;
            
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "login@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("yand3x911@yandex.ru", "yandexPassword911");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

        private void BSignIn_Click(object sender, RoutedEventArgs e)
        {
            SendEmailAsync("dinarhertz@gmail.com", "Тема письма", "Тест письма: тест!");
        }
    }
}
