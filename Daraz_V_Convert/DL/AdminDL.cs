using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daraz_V_Convert.BL;
namespace Daraz_V_Convert.DL
{
    internal class AdminDL
    {
        private static Admin admin = new Admin();
        public Admin Admin { get { return admin; } set { admin = value;} }
        public static Admin get_admin(string name, string pass)
        {
            if (name == admin.Username && admin.Password == pass)
            {
                return admin;
            }
            else
            {
                return null;
            }
        }
        public static int change_password(string pass,string pass1,string pass2)
        {
            if(pass==admin.Password)
            {
                if(pass1==pass)
                {
                    return 2;
                }
                else
                {
                    if(pass1==pass2)
                    {
                        admin.Password = pass1;
                        return 3;
                    }
                    else
                    {
                        return 4;
                    }
                }
            }
            else
            {
                return 1;
            }
        }
    }
}
