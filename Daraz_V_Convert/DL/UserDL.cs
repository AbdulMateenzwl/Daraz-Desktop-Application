using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daraz_V_Convert.BL;
namespace Daraz_V_Convert.DL
{
    class UserDL
    {
        private static List<User> users= new List<User>();
        public static void add_list(User input)
        {
            users.Add(input);
        }
        public static List<User> get_list()
        {
            return users;
        }
        public static User get_user(string name,string pass)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (name == users[i].Name && users[i].Password==pass)
                {
                    return users[i];
                }
            }
            return null;
        }
    }
}
