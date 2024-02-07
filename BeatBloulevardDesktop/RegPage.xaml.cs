using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace BeatBloulevardDesktop
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();

            var regData = new
            {
                email = _regLogin.Text,
                password = _regPassword.Password
            };

            var json = JsonConvert.SerializeObject(regData);
            var content = new StringContent(json, Encoding.UTF8,"application/json");

            var responce = await client.PostAsync("http://localhost:8081/sign-up", content);

            if (responce.IsSuccessStatusCode)
            {
                MessageBox.Show("Вы успешно зарегистрированы, необходимо авторизоваться");
                NavigationService.Navigate(new AuthPage());
            }
            else
            {
                MessageBox.Show("Регистрация не удалась, попробуйте позднее");
                NavigationService.Navigate(new AuthPage());
            }
           
        }
    }
}
