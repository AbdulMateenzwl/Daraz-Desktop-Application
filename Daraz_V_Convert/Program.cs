using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Daraz_V_Convert.BL;
using Daraz_V_Convert.DL;
using Daraz_V_Convert.Forms;
namespace Daraz_V_Convert
{
    class Program
    {
        static void Main()
        {
            Seller s = new Seller("2", "2", "2", "2");
            SellerDL.add_list(s);
            User u = new User("3", "3");
            UserDL.add_list(u);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Sign_In());
        }
    }
}
