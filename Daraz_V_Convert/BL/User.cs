using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daraz_V_Convert.BL
{
    internal class User
    {
        public string name="";
        public string password="";
        public string email="";
        public string pin="";
        public string phone="";
        public List<buy_products> buy_product = new List<buy_products>();
        public User() { }
        public User(string names, string pass, string em,string pn,string ph)
        {
            name = names;
            password = pass;
            email=em;
            pin=pn;
            phone=ph;
        }
    }
}
