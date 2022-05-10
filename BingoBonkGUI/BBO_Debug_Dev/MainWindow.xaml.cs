using RestSharp;
using SocketIOClient;
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

namespace BBO_Debug_Dev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class User
    {
        public string Username { get; private set; }
        public string Key { get; private set; }
        public User(string a, string b)
        {
            Username = a;
            Key = b;
        }
    }
    public partial class MainWindow : Window
    {
        public SocketIO Client { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        //Register Player Button
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Client = new SocketIO("http://bingo.test.dev:5000/");

            Client.OnConnected += async (sender, e) =>
            {


            };

            Client.On("successRegister", response =>
            {
                MessageBox.Show(response.ToString());

            });
            await Client.ConnectAsync();
        }
        //Connection Code
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string a = "";
            string b = "";
            Dispatcher.Invoke(new Action(() =>
            {
                a = UsernameTextbox.Text;
                b = KeyTextBox.Text;

            }));
            User x = new User(a, b);
            // Emit a string and an object

            await Client.EmitAsync("register", x);
        }
    }
}
