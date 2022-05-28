using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daraz_V_Convert.BL
{
    public class User
    {
        private string name;
        private string password;
        private string email;
        private string pin;
        private string phone;
        private List<Product> buy_product = new List<Product>();
        public string Name { get { return name; } set { name = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Pin { get { return pin; } set { pin = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public void add_product_list(Product input)
        {
            buy_product.Add(input);
        }
        public List<Product> get_product_list()
        {
            return buy_product;
        }
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
