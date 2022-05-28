using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daraz_V_Convert.BL
{
    class Admin
    {
        private string username="1";
        private string password="1";
        public Admin() { }
        public Admin(string username,string password)
        {
            this.password=password;
            this.username=username;
        }
        public string Username{ get { return username; } set { username = value; } }
        public string Password{ get { return password; } set { password = value; } }
        
    }
}
