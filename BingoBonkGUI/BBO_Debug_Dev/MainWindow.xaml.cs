using BBO_Debug_Dev.Helpers;
using RestSharp;
using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        BoardConfig boardConfig = null;
        public BingoLogic Logic { get; private set; } = new BingoLogic();

        public SocketIO Client { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Logic.GenerateControlsNeeded();
        }

        //Register Player Button
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string a = "";
            Dispatcher.Invoke(new Action(() => { a = KeyTextBox.Text; }));
            Client = new SocketIO($"http://bingo.test.dev:5000/{a}");
            //Client.Options.Auth = a;
            Client.Options.ExtraHeaders = new Dictionary<string, string>();
            Client.Options.ExtraHeaders["KEY"] = a;
            Client.OnConnected += async (sender, e) =>
            {


            };

            Client.On("successRegister", response =>
            {

                boardConfig = response.GetValue<BoardConfig>();
                Dispatcher.Invoke(new Action(() => { Config.Text = boardConfig.ToString(); }));
                List<bool?> Flags = new List<bool?>() { boardConfig.Canister, boardConfig.CanisterSubdivide, boardConfig.Ach1k, boardConfig.Matoro, boardConfig.Hewkii, boardConfig.Shop, boardConfig.CanisterLocator, boardConfig.PirakaPlayground, boardConfig.AlwaysFillMiddleSquare };
                List<string> f = new List<string>() { boardConfig.Vahki.ToString() };
                var board = Logic.GenerateBoard(Flags, boardConfig.Seed, f);
                // MessageBox.Show(String.Join("\n", board));
                Client.EmitAsync("SendBoard", board);
            });

            Client.On("boardUpadte", response =>
            {
                boardConfig = response.GetValue<BoardConfig>();
                Dispatcher.Invoke(new Action(() => { Config.Text = boardConfig.ToString(); }));
                List<bool?> Flags = new List<bool?>() { boardConfig.Canister, boardConfig.CanisterSubdivide, boardConfig.Ach1k, boardConfig.Matoro, boardConfig.Hewkii, boardConfig.Shop, boardConfig.CanisterLocator, boardConfig.PirakaPlayground, boardConfig.AlwaysFillMiddleSquare };
                List<string> f = new List<string>() { boardConfig.Vahki.ToString() };
                var board = Logic.GenerateBoard(Flags, boardConfig.Seed, f);
                //MessageBox.Show(String.Join("\n", board));
                Client.EmitAsync("SendBoard", board);
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

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() => { Config.Text = boardConfig.ToString(); }));
            List<bool?> Flags = new List<bool?>() { boardConfig.Canister, boardConfig.CanisterSubdivide, boardConfig.Ach1k, boardConfig.Matoro, boardConfig.Hewkii, boardConfig.Shop, boardConfig.CanisterLocator, boardConfig.PirakaPlayground, boardConfig.AlwaysFillMiddleSquare };
            List<string> f = new List<string>() { boardConfig.Vahki.ToString() };
            var board = Logic.GenerateBoard(Flags, boardConfig.Seed, f);
            Client.EmitAsync("SendBoard", board);
           // MessageBox.Show(String.Join("\n", board));

            //{["{\"Seed\":-1,\"Vahki\":0,\"Canister\":false,\"CanisterSubdivide\":true,\"Matoro\":true,\"Hewkii\":true,\"Shop\":true,\"CanisterLocator\":true,\"AlwaysFillMiddleSquare\":true}"]}
            //string json = 
        }
    }
}
