using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BionicleHeroesBingoGUI.Helpers
{
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
}
