using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daraz_V_Convert.BL;
using System.IO;
namespace Daraz_V_Convert.DL
{
    class SellerDL
    {
        static string path = "seller.txt";
        private static List<Seller> seller = new List<Seller>();
        public static void add_list(Seller input)
        {
            seller.Add(input);
        }
        public static List<Seller> get_list()
        {
            return seller;
        }
        public static void load_data()
        {
            string path = "seller.txt";
            if (File.Exists(path))
            {
                StreamReader var = new StreamReader(path);
                string record;
                while ((record = var.ReadLine()) != null)
                {
                    /*Seller input = new Seller();
                    input.name = parse(record, 1);
                    input.phone_num = parse(record, 2);
                    input.buisness = parse(record, 3);
                    input.password = parse(record, 4);
                    for (int i = 5; i < 100; i = i + 2)
                    {
                        Product inp = new Product();
                        if (parse(record, i) == "")
                        {
                            break;
                        }
                        inp.name = parse(record, i);
                        inp.prices = int.Parse(parse(record, i + 1));
                        input.product.Add(inp);
                    }
                    seller.Add(input);*/
                }
                var.Close();
            }

        }
        public static Seller seller_index(string seller_name)
        {
            for (int i = 0; i < seller.Count; i++)
            {
                if (seller_name == seller[i].name)
                {
                    return seller[i];
                }
            }
            return null;
        }
        public static void store_data(List<Seller> seller)
        {
            StreamWriter var = new StreamWriter(path, false);
            for (int i = 0; i < seller.Count; i++)
            {
                if (seller[i].name != "")
                {
                    var.Write(seller[i].name + "$" + seller[i].phone_num + "$" + seller[i].buisness + "$" + seller[i].password + "$");
                }
                for (int m = 0; m < seller[i].product.Count; m++)
                {
                    var.Write(seller[i].product[m].name + "$" + seller[i].product[m].prices + "$");
                }
                var.WriteLine("");
            }
            var.Close();
        }
    }
}
