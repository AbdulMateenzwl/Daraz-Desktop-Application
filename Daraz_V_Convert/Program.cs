using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daraz_V_Convert.BL;

namespace Daraz_V_Convert
{
    class Program
    {
        ///////////////////////////////        Main Menu    /////////////////////////
        //check//
        static void Main(string[] args)
        {
            List<Seller> seller = new List<Seller>();
            List<User> user = new List<User>();
            load_seller_data(seller);
            load_customers_data(user);

            char main_menu_option = '5';
            string admin_pass = "1234";
            string pass = "";

            while (main_menu_option != '4')
            {
                header();
                main_menu_option = main_menu();
                if (main_menu_option == '1')
                {
                    header();
                    Console.WriteLine("Admin > ");
                    Console.WriteLine("");
                    Console.Write("Enter Password : ");
                    pass = Console.ReadLine();
                    if (pass == admin_pass)
                    {
                        char admin_option = '9';
                        string delete_seller = "";
                        while (admin_option != '6')
                        {
                            header();
                            admin_option = admin_menu();
                            header();
                            if (admin_option == '1')
                            {
                                add_seller(seller);
                            }
                            else if (admin_option == '2')
                            {
                                Console.WriteLine("Admin Menu > View Seller >");
                                Console.WriteLine("");
                                if (seller.Count > 0)
                                {
                                    Console.WriteLine("Name\tNumber\tBuisness\tPassword");
                                    show_seller_data(seller);
                                }
                                else
                                {
                                    Console.WriteLine("You have not entered any data .");
                                }
                                Console.WriteLine("");
                                clear_screen();
                            }
                            else if (admin_option == '3')
                            {
                                Console.WriteLine("Admin Option > History >");
                                Console.WriteLine("");
                                Console.WriteLine("Ali Just bought Two bags . ");
                                for (int i = 0; i < seller.Count; i++)
                                {
                                    if (seller[i].phone_num != "")
                                    {
                                        Console.WriteLine("You just added " + seller[i].name + " to " + seller[i].buisness + " Buisness list .");
                                    }
                                }
                                Console.WriteLine("");
                                clear_screen();
                            }
                            else if (admin_option == '4')
                            {
                                Console.WriteLine("Admin Menu > Delete Seller > ");
                                Console.WriteLine("");
                                Console.Write("Enter Password : ");
                                pass = Console.ReadLine();
                                if (pass == admin_pass)
                                {
                                    int index = -1;
                                    Console.Write("Enter the name of seller you want to delete : ");
                                    delete_seller = Console.ReadLine();
                                    for (int i = 0; i < seller.Count; i++)
                                    {
                                        if (delete_seller == seller[i].name)
                                        {
                                            index = i;
                                            break;
                                        }
                                    }
                                    if (index != -1)
                                    {
                                        Console.WriteLine(seller[index].name + " has been deleted from " + seller[index].buisness + " List .");
                                        seller.RemoveAt(index);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no seller named as " + delete_seller + " . ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You have entered the wrong Password .");
                                }
                                clear_screen();
                            }
                            else if (admin_option == '5')
                            {
                                Console.WriteLine("Admin Menu > Update Password > ");
                                admin_pass = update_password(admin_pass);
                            }
                            else if (admin_option == '6')
                            {
                                Console.WriteLine("Thanks for using our program .");
                                Console.WriteLine("We are happy to serve you .");
                                clear_screen();
                            }
                            else
                            {
                                Console.WriteLine("You have entered the wrong input .");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have entered the Wrong Password .");
                        Console.WriteLine("Please Enter the Correct Password .");
                        clear_screen();
                    }
                }
                else if (main_menu_option == '2')
                {
                    string passs = "O", name;
                    int index = -1;
                    char exit = ' ';
                    char seller_option = '9';
                    header();
                    Console.WriteLine("Seller >");
                    Console.WriteLine("");
                    Console.WriteLine("1)  Create new account");
                    Console.WriteLine("2)  Login(if you already have an account");
                    Console.WriteLine("Press e to exit");
                    exit = Console.ReadLine()[0];
                    if (exit == '1')
                    {
                        header();
                        Console.WriteLine("Seller > Create New Account >");
                        Console.WriteLine("");
                        header();
                        Seller input = new Seller();
                        Console.WriteLine("Admin Menu > Add Seller > ");
                        Console.WriteLine("");
                        Console.Write("Enter Seller Name : ");
                        input.name = Console.ReadLine();
                        Console.Write("Enter Seller Phone Number : ");
                        input.phone_num = Console.ReadLine();
                        Console.Write("Enter Seller Buisness : ");
                        input.buisness = Console.ReadLine();
                        Console.Write("Enter Seller Password : ");
                        input.password = Console.ReadLine();
                        seller.Add(input);
                        Console.WriteLine("Seller id has been created");
                        Console.WriteLine("");
                        exit = '2';
                    }
                    if (exit == '2')
                    {
                        header();
                        Console.WriteLine("Seller > Login >");
                        Console.WriteLine("");
                        Console.Write("Enter your name : ");
                        name = Console.ReadLine();
                        Console.Write("Enter your Password : ");
                        passs = Console.ReadLine();
                        for (int i = 0; i < seller.Count; i++)
                        {
                            if (passs == seller[i].name && name == seller[i].password)
                            {
                                index = i;
                            }
                        }
                        if (index != -1)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Hello " + seller[index].name + " .");
                            Console.WriteLine("Hope you are fine .");
                            Console.WriteLine("Lets get back to work .");
                            Console.WriteLine("");
                            clear_screen();
                            while (seller_option != '7')
                            {
                                header();
                                seller_option = seller_menu();
                                header();
                                if (seller_option == '1')
                                {
                                    add_product(seller, index);
                                }
                                else if (seller_option == '2')
                                {
                                    Console.WriteLine("Seller Menu > View Products >");
                                    show_products(seller, index);
                                }
                                else if (seller_option == '3')
                                {
                                    Console.WriteLine("Seller Menu > Sorted Products >");
                                    sorting(seller, index);
                                }
                                else if (seller_option == '4')
                                {
                                    delete_products(seller[index].password, seller, index);
                                }
                                else if (seller_option == '5')
                                {
                                    update_seller(seller, index);
                                }
                                else if (seller_option == '6')
                                {
                                    Console.WriteLine("Seller Menu > Update Password >");
                                    Console.WriteLine("");
                                    seller[index].password = update_password(seller[index].password);
                                }
                                else if (seller_option == '7')
                                {
                                    Console.WriteLine("Thanks for using our Program.");
                                    Console.WriteLine("We are happy to serve you.");
                                    clear_screen();
                                }
                                else
                                {
                                    Console.WriteLine("You have entered the wrong input");
                                    clear_screen();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("The Password You entered is Incorrrect.");
                            Console.WriteLine("Please enter again...");
                            Console.WriteLine("");
                            clear_screen();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have entered the wrong input .");
                    }
                }
                else if (main_menu_option == '3')
                {
                    char customer_option = '9';
                    char exit = ' ';
                    while (exit != 'e')
                    {
                        header();
                        string user_name, user_password;
                        Console.WriteLine("1)  Create new account");
                        Console.WriteLine("2)  Login(if you already have an account");
                        Console.WriteLine("Press e to exit");
                        exit = Console.ReadLine()[0];
                        if (exit == '1')
                        {
                            header();
                            Console.WriteLine("Customer > Create New Account >");
                            Console.WriteLine("");
                            create_account_customer(user);
                            exit = '2';
                            clear_screen();
                        }
                        if (exit == '2')
                        {
                            int index = -1;
                            header();
                            Console.WriteLine("Customer > Login >");
                            Console.WriteLine("");
                            Console.Write("Enter your name : ");
                            user_name = Console.ReadLine();
                            Console.Write("Enter your Password : ");
                            user_password = Console.ReadLine();
                            for (int i = 0; i < user.Count; i++)
                            {
                                if (user_name == user[i].name && user_password == user[i].password)
                                {
                                    index = i;
                                }
                            }
                            if (index != -1)
                            {
                                while (customer_option != '6')
                                {
                                    header();
                                    customer_option = customer_menu();
                                    header();
                                    if (customer_option == '1')
                                    {
                                        Console.WriteLine("Customer Menu > View Products >");
                                        Console.WriteLine("");
                                        show_product_cust(seller, user, index);
                                    }
                                    else if (customer_option == '2')
                                    {
                                        Console.WriteLine("Customer Menu > View Cart >");
                                        Console.WriteLine("");
                                        if (user[index].buy_product.Count > 0)
                                        {
                                            Console.WriteLine("Products\tPrices");
                                            for (int i = 0; i < user[index].buy_product.Count; i++)
                                            {
                                                Console.WriteLine(user[index].buy_product[i].name + "\t\t" + user[index].buy_product[i].price);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please Enter some Products to Cart to buy .");
                                        }
                                        clear_screen();
                                    }
                                    else if (customer_option == '3')
                                    {
                                        Console.WriteLine("Customer Menu > Payment >");
                                        Console.WriteLine("");
                                        int op1;
                                        Console.WriteLine("Select Payment Method :");
                                        Console.WriteLine("1) Debit Card");
                                        Console.WriteLine("2) Cash On Delivery");
                                        op1 = int.Parse(Console.ReadLine());
                                        if (op1 == 1)
                                        {
                                            while (true)
                                            {
                                                string credit_card_num;
                                                Console.WriteLine("");
                                                Console.Write("Please Enter your credit card number : ");
                                                credit_card_num = Console.ReadLine();
                                                if (credit_card_num.Length >= 7)
                                                {
                                                    user[index].pin = credit_card_num;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Please Enter Correct Card Number.");
                                                    clear_screen();
                                                    break;
                                                }
                                                bool check = user_info_input(user, index);
                                                if (check)
                                                {
                                                    Console.WriteLine("Your order has been placed.You will recieve parcel in 3 to 5 working days.");
                                                    Console.WriteLine("You have to pay cash on delivery .");
                                                    Console.WriteLine("");
                                                    clear_screen();
                                                }
                                                break;
                                            }
                                        }
                                        else if (op1 == 2)
                                        {
                                            header();
                                            user_info_input(user, index);
                                            Console.WriteLine("Your order has been placed.You will recieve parcel in 3 to 5 working days.");
                                            Console.WriteLine("You have to pay cash on delivery .");
                                            Console.WriteLine("");
                                            clear_screen();
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have entered the wrong input .");
                                        }
                                    }
                                    else if (customer_option == '4')
                                    {
                                        display_user_info(user, index);
                                    }
                                    else if (customer_option == '5')
                                    {
                                        Console.WriteLine("Customer_Menu > Update Password >");
                                        Console.WriteLine("");
                                        user[index].password = update_password(user[index].password);
                                    }
                                    else if (customer_option == '6')
                                    {
                                        Console.WriteLine("Thanks for using our program.");
                                        Console.WriteLine("We are happy to serve you.");
                                        exit = 'e';
                                        clear_screen();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You have entered the wrong input.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sorry it seems like you do not  have an account");
                                Console.WriteLine("Try to connect later...");
                                clear_screen();
                            }
                        }
                        else
                        {
                            header();
                            Console.WriteLine("You have entered the wrong input.");
                            clear_screen();
                        }
                        Console.Clear();
                    }
                }
                else if (main_menu_option == '4')
                {
                    Console.WriteLine("Thanks for using our Program..");
                    Console.WriteLine("We are happy to serve you");
                    clear_screen();
                    //Store DATA
                    store_Customer_data_to_file(user);
                    store_seller_data_to_file(seller);
                }
                else
                {
                    header();
                    Console.WriteLine("You have entered the wrong input");
                    clear_screen();
                }
            }
        }

        ////////////////////////////////////////////////Functions/////////////////////////////////////
        static void store_seller_data_to_file(List<Seller> seller)
        {
            string path = "seller.txt";
            StreamWriter var = new StreamWriter(path, false);
            for (int i = 0; i < seller.Count; i++)
            {
                if (seller[i].name != "")
                {
                    var.Write(seller[i].name + "$" + seller[i].phone_num + "$" + seller[i].buisness + "$" + seller[i].password+"$");
                }
                for (int m = 0; m < seller[i].product.Count; m++)
                {
                    var.Write(seller[i].product[m].name + "$" + seller[i].product[m].prices + "$");
                }
                var.WriteLine("");
            }
            var.Close();
        }
        static void store_Customer_data_to_file(List<User> user)
        {
            string path = "cust.txt";
            StreamWriter var = new StreamWriter(path, false);
            for (int i = 0; i < user.Count; i++)
            {
                if (user[i].password != "")
                {
                    var.Write(user[i].name + "$" + user[i].password + "$" + user[i].email + "$" + user[i].pin + "$" + user[i].phone + "$");
                    for (int m = 0; m < user[i].buy_product.Count; m++)
                    {
                        var.Write(user[i].buy_product[m].name + "$" + user[i].buy_product[m].price + "$");
                    }
                    var.WriteLine("");
                }
            }
            var.Close();
        }
        static void header()
        {
            Console.Clear();
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("*****                                                                            *****");
            Console.WriteLine("***            *****          ***       *****         ***       ***********        ***");
            Console.WriteLine("**             **  ***       *   *      **   **      *   *      **      **          **");
            Console.WriteLine("**             **    **     **   **     ******      **   **          **             **");
            Console.WriteLine("**             **  ***     *********    **  **     *********      **     **         **");
            Console.WriteLine("***            *****      **       **   **    **  **       **   ***********        ***");
            Console.WriteLine("*****                                                                            *****");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        static char main_menu()
        {
            Console.WriteLine("///////////////////   MAIN MENU     /////////////////////");
            Console.WriteLine("Login as :");
            Console.WriteLine("1)   Admin");
            Console.WriteLine("2)   Seller");
            Console.WriteLine("3)   Customer");
            Console.WriteLine("");
            Console.WriteLine("Press 4 to Exit");
            char op;
            op = Console.ReadLine()[0];
            return op;
        }
        static string parse(string row, int column)
        {
            int dollar_count = 1;
            string item = "";
            for (int index = 0; index < row.Length; index++)
            {
                char ch;
                ch = row[index];
                if (ch == '$')
                {
                    dollar_count++;
                }
                else if (dollar_count == column)
                {
                    item = item + ch;
                }
            }
            return item;
        }
        static char admin_menu()
        {
            Console.WriteLine("/////////////////////   Admin Menu  /////////////////");
            Console.WriteLine("Welcome Admin");
            Console.WriteLine("");
            Console.WriteLine("1)  Add Seller");
            Console.WriteLine("2)  View Record");
            Console.WriteLine("3)  View history");
            Console.WriteLine("4)  Delete Seller");
            Console.WriteLine("5)  Update Password");
            Console.WriteLine("6)  Exit");
            Console.WriteLine("");
            Console.WriteLine("Enter your option");
            char op;
            op = Console.ReadLine()[0];
            return op;
        }
        static void add_seller(List<Seller> seller)
        {
            while (true)
            {
                int exit = 0;
                header();
                Seller input = new Seller();
                Console.WriteLine("Admin Menu > Add Seller > ");
                Console.WriteLine("");
                Console.Write("Enter Seller Name : ");
                input.name = Console.ReadLine();
                Console.Write("Enter Seller Phone Number : ");
                input.phone_num = Console.ReadLine();
                Console.Write("Enter Seller Buisness : ");
                input.buisness = Console.ReadLine();
                Console.Write("Enter Seller Password : ");
                input.password = Console.ReadLine();
                seller.Add(input);
                Console.WriteLine("Seller id has been created");
                Console.WriteLine("");
                Console.WriteLine("Press 1 to Exit...");
                exit = int.Parse(Console.ReadLine());
                if (exit == 1)
                {
                    break;
                }
            }
        }
        static bool check_product(List<Seller> seller, int index)
        {
            bool yt = false;
            for (int x = 0; x < seller[index].product.Count; x++)
            {
                if (seller[index].product[x].prices > 0)
                {
                    yt = true;
                    return yt;
                }
            }
            return yt;
        }
        static bool check_seller(List<Seller> seller)
        {
            bool yt = false;
            for (int x = 0; x < seller.Count; x++)
            {
                if (seller[x].phone_num != "")
                {
                    yt = true;
                }
            }
            return yt;
        }
        static bool check_name(string buyp, List<Seller> seller, List<User> user, int index)
        {
            bool yt = false;
            for (int i = 0; i < seller.Count; i++)
            {
                for (int x = 0; x < seller[i].product.Count; x++)
                {
                    if (seller[i].product[x].name == buyp)
                    {
                        yt = true;
                        buy_products input = new buy_products();
                        input.name = seller[i].product[x].name;
                        input.price = seller[i].product[x].prices;
                        user[index].buy_product.Add(input);
                        return yt;
                    }
                }
            }
            return yt;
        }
        static void show_seller_data(List<Seller> seller)
        {
            for (int i = 0; i < seller.Count; i++)
            {
                if (seller[i].phone_num != "")
                {
                    Console.WriteLine(seller[i].name + "\t" + seller[i].phone_num + "\t" + seller[i].buisness + "\t" + seller[i].password);
                }
            }
        }
        static void clear_screen()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static char seller_menu()
        {
            char op;
            Console.WriteLine("////////////////   Seller Menu   ////////////////");
            Console.WriteLine("");
            Console.WriteLine("Welcome Seller");
            Console.WriteLine("1)  Add Product");
            Console.WriteLine("2)  View Products");
            Console.WriteLine("3)  Sort By Price");
            Console.WriteLine("4)  Delete Product");
            Console.WriteLine("5)  Update price of a Product");
            Console.WriteLine("6)  Update Password");
            Console.WriteLine("7)  Exit");
            Console.WriteLine("");
            Console.WriteLine("Enter any option");
            op = Console.ReadLine()[0];
            return op;
        }
        static void add_product(List<Seller> seller, int index)
        {
            int exit = 0;
            while (true)
            {
                Console.Clear();
                header();
                Product input = new Product();
                Console.WriteLine("Seller Menu > Add Products > ");
                Console.WriteLine("");
                Console.Write("Enter the name of the product : ");
                input.name = Console.ReadLine();
                Console.Write("Enter the price of product : ");
                input.prices = int.Parse(Console.ReadLine());
                seller[index].product.Add(input);
                Console.WriteLine("Product has been added Successfully .");
                Console.WriteLine("");
                Console.WriteLine("Press 1 to Exit ...");
                exit = int.Parse(Console.ReadLine());
                if (exit == 1)
                {
                    break;
                }
            }
        }
        static bool check_product_all(List<Seller> seller)
        {
            bool yt = false;
            for (int i = 0; i < seller.Count; i++)
            {
                yt = check_product(seller, i);
                if (yt)
                {
                    return yt;
                }
            }
            return yt;
        }
        static void show_products(List<Seller> seller, int index)
        {
            bool yt = check_product(seller, index);
            Console.WriteLine("");
            if (yt)
            {
                Console.WriteLine("Products\tPrice");
                Console.WriteLine("");
                for (int i = 0; i < seller[index].product.Count; i++)
                {
                    if (seller[index].product[i].prices > 0)
                    {
                        Console.WriteLine(seller[index].product[i].name + "\t" + seller[index].product[i].prices);
                    }
                }
                Console.WriteLine("");
                clear_screen();
            }
            else
            {
                Console.WriteLine("You have not entered any Products.");
                Console.WriteLine("Go to option 1 to add some products.");
                Console.WriteLine("");
                clear_screen();
            }
        }
        static void sorting(List<Seller> seller, int index)
        {
            if (seller[index].product.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("1) Ascending Order");
                Console.WriteLine("2) Decending Order");
                int op = int.Parse(Console.ReadLine());
                if (op == 1)
                {
                    /*for (int x = 0; x < seller[index].product.Count; x++)
                    {
                        for (int m = x + 1; m < seller[index].product.Count; m++)
                        {
                            if (seller[index].product[x].prices > seller[index].product[m].prices)
                            {
                                string temp = seller[index].product[x].name;
                                seller[index].product[x].name = seller[index].product[m].name;
                                seller[index].product[m].name = temp;
                                int temp1 = seller[index].product[x].prices;
                                seller[index].product[x].prices = seller[index].product[m].prices;
                                seller[index].product[m].prices = temp1;
                            }
                        }
                    }*/
                    show_products(seller, index);
                }
                else if (op == 2)
                {
                    /*for (int x = 0; x < seller[index].product.Count; x++)
                    {
                        for (int m = x + 1; m < seller[index].product.Count; m++)
                        {
                            if (seller[index].product[x].prices < seller[index].product[m].prices)
                            {
                                string temp = seller[index].product[x].name;
                                seller[index].product[x].name = seller[index].product[m].name;
                                seller[index].product[m].name = temp;
                                int temp1 = seller[index].product[x].prices;
                                seller[index].product[x].prices = seller[index].product[m].prices;
                                seller[index].product[m].prices = temp1;
                            }
                        }
                    }*/
                    show_products(seller, index);
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("You have entered the wrong input .");
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("You have Entered no Products .");
                Console.WriteLine("Go to Option 1 to add some Products .");
                Console.WriteLine("");
                clear_screen();
            }
        }
        static void delete_products(string seller_pass, List<Seller> seller, int index)
        {
            string delete_product;
            int idx = -1;
            string password;
            Console.WriteLine("Seller Menu > Delete Product > ");
            Console.WriteLine("");
            Console.Write("Enter Password : ");
            password = Console.ReadLine();
            if (password == seller_pass)
            {
                bool yt = check_product(seller, index);
                if (yt)
                {
                    Console.Write("Enter the name of product you want to delete : ");
                    delete_product = Console.ReadLine();
                    for (int i = 0; i < seller[index].product.Count; i++)
                    {
                        if (delete_product == seller[index].product[i].name)
                        {
                            idx = i;
                        }
                    }
                    if (idx == -1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("There is no such product .");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine(seller[index].product[idx].name + " has been deleted .");
                        seller[index].product.RemoveAt(idx);
                    }
                    Console.WriteLine("");
                    clear_screen();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("You have Entered no Products .");
                    Console.WriteLine("Go to Option 1 to add some Products .");
                    Console.WriteLine("");
                    clear_screen();
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("The Password You entered is Incorrrect.");
                Console.WriteLine("Please enter again...");
                Console.WriteLine("");
                clear_screen();
            }

        }
        static void update_seller(List<Seller> seller, int index)
        {
            Console.WriteLine("Seller Menu > Update Product >");
            Console.WriteLine("");
            if (seller[index].product.Count>0)
            {
                string update_product;
                int idx = -1;
                Console.Write("Enter the name of product you want to Update : ");
                update_product = Console.ReadLine();
                for (int i = 0; i < seller[index].product.Count; i++)
                {
                    if (update_product == seller[index].product[i].name)
                    {
                        idx = i;
                    }
                }
                if (idx == -1)
                {
                    Console.WriteLine("There is no such Product .");
                }
                else
                {
                    Product product = new Product();
                    Console.Write("Enter the updated name of the product : ");
                    product.name = Console.ReadLine();
                    Console.Write("Enter the updated price of the product : ");
                    product.prices = int.Parse(Console.ReadLine());
                    seller[index].product[idx] = product;
                    Console.WriteLine(seller[index].product[idx].name + " has been updated. Its Current Price is " + seller[index].product[idx].prices + " .");
                }
            }
            else
            {
                Console.WriteLine("You have Entered no Products .");
                Console.WriteLine("Go to Option 1 to add some Products .");
            }
            Console.WriteLine("");
            clear_screen();
        }
        static string update_password(string password)
        {
            string pass;
            Console.Write("Enter your Old Password : ");
            pass = Console.ReadLine();
            if (pass == password)
            {
                string confirm_pass, pass1;
                string cancel_pass = "";
                while (cancel_pass != "c")
                {
                    Console.WriteLine("");
                    Console.Write("Enter New Password : ");
                    pass1 = Console.ReadLine();
                    Console.Write("Renter New Password : ");
                    confirm_pass = Console.ReadLine();
                    if (pass1 == confirm_pass)
                    {
                        if (password == pass1 || password == confirm_pass)
                        {
                            Console.WriteLine("Your new password can not be the old password .");
                            Console.WriteLine("Please enter again(Press C to cancel)");
                            cancel_pass = Console.ReadLine();
                        }
                        else
                        {
                            password = pass1;
                            Console.WriteLine("Password has been changed Successfuly .");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Password does not match .");
                        Console.WriteLine("Please enter again(Press C to cancel)");
                        cancel_pass = Console.ReadLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("You have entered the Wrong Password .");
            }
            Console.WriteLine("");
            clear_screen();
            return password;
        }
        static char customer_menu()
        {
            Console.WriteLine("///////////////////  Customer Menu  ////////////////////");
            Console.WriteLine("");
            Console.WriteLine("1)  View Products");
            Console.WriteLine("2)  View Cart");
            Console.WriteLine("3)  Payment");
            Console.WriteLine("4)  View Profile");
            Console.WriteLine("5)  Update Password");
            Console.WriteLine("6)  Exit");
            Console.WriteLine("");
            Console.WriteLine("Enter your option");
            char op = Console.ReadLine()[0];
            return op;
        }
        static bool user_info_input(List<User> user, int index)
        {
            string phone, email, address, location;
            bool email_check = false;
            bool check = false;
            Console.Write("Please Enter your Phone number : ");
            phone = Console.ReadLine();
            if (phone.Length >= 11)
            {
                user[index].phone = phone;
            }
            else
            {
                Console.WriteLine("Please Enter Valid Phone Number.");
                clear_screen();
                return false;
            }
            Console.WriteLine("On which address you want to recieve parcel.");
            Console.WriteLine("1) Home Address");
            Console.WriteLine("2) Office Address");
            location = Console.ReadLine();
            Console.Write("Please Enter your address : ");
            address = Console.ReadLine();
            Console.Write("Please Enter Email : ");
            email = Console.ReadLine();
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    email_check = true;
                }
            }
            if (email_check)
            {
                user[index].email = email;
            }
            else
            {
                Console.WriteLine("Please Enter Correct Email Address .");
                clear_screen();
                return false;
            }
            return check;
        }
        static void create_account_customer(List<User> user)
        {
            User input = new User();
            Console.Write("Enter your name : ");
            input.name = Console.ReadLine();
            Console.Write("Enter your password : ");
            input.password = Console.ReadLine();
            user.Add(input);
            Console.WriteLine("Welcome " + input.name);
            Console.WriteLine("Your Account has been created Successfully.");
        }
        static void show_product_cust(List<Seller> seller, List<User> user, int index)
        {
            bool yt = check_product_all(seller);
            if (yt)
            {
                string buy_products = "";
                while (true)
                {
                    header();
                    Console.WriteLine("Customer_Menu > View Products >");
                    Console.WriteLine("");
                    Console.WriteLine("Products\tPrices");
                    for (int i = 0; i < seller.Count; i++)
                    {
                        bool ch = check_product(seller, i);
                        if (ch)
                        {
                            Console.WriteLine("Products By " + seller[i].name + " > ");
                            for (int j = 0; j < seller[i].product.Count; j++)
                            {
                                if (seller[i].product[j].prices > 0)
                                {
                                    Console.WriteLine(seller[i].product[j].name + "\t\t" + seller[i].product[j].prices);
                                }
                            }
                            Console.WriteLine("");
                        }
                    }
                    Console.WriteLine("Which product you want to buy(press E to Exit");
                    buy_products = Console.ReadLine();
                    if (buy_products == "e")
                    {
                        break;
                    }
                    bool check = check_name(buy_products, seller, user, index);
                    if (check)
                    {
                        Console.WriteLine("Product has been Succesfully added to Cart .");
                    }
                    else
                    {
                        Console.WriteLine("There is no Such Product .");
                    }
                    clear_screen();
                }
            }
            else
            {
                Console.WriteLine("There are no Products to display .");
                clear_screen();
            }
        }
        static void display_user_info(List<User> user, int index)
        {
            Console.WriteLine("Customer_Menu > View Profile >");
            Console.WriteLine("");
            Console.WriteLine(" Name :\t " + user[index].name);
            Console.WriteLine(" Pasword :\t" + user[index].password);
            if (user[index].email != "")
            {
                Console.WriteLine(" Email :\t " + user[index].email);
            }
            if (user[index].pin != "")
            {
                Console.WriteLine(" Credit Card :\t " + user[index].pin);
            }
            if (user[index].phone != "")
            {
                Console.WriteLine(" Phone Number :\t " + user[index].phone);
            }
            Console.WriteLine("");
            clear_screen();
        }
        static void load_seller_data(List<Seller> seller)
        {
            string path = "seller.txt";
            if (File.Exists(path))
            {
                StreamReader var = new StreamReader(path);
                string record;
                while ((record = var.ReadLine()) != null)
                {
                    Seller input = new Seller();
                    input.name = parse(record, 1);
                    input.phone_num = parse(record, 2);
                    input.buisness = parse(record, 3);
                    input.password = parse(record, 4);
                    for (int i = 5;i<100; i=i+2)
                    {
                        Product inp = new Product();
                        if(parse(record,i)=="")
                        {
                            break;
                        }
                        inp.name = parse(record, i);
                        inp.prices = int.Parse(parse(record,i+1));
                        input.product.Add(inp);
                    }
                    seller.Add(input);
                }
                var.Close();
            }

        }
        static void load_customers_data(List<User> user)
        {
            string path = "cust.txt";
            StreamReader var = new StreamReader(path);
            string record;
            while ((record = var.ReadLine()) != null)
            {
                User input_f = new User();
                input_f.name = parse(record, 1);
                input_f.password = parse(record, 2);
                input_f.email = parse(record, 3);
                input_f.pin = parse(record, 4);
                input_f.phone = parse(record, 5);
                int m = 0;
                for (int x = 6; record[x] != '\0'; x = x + 2)
                {
                    buy_products inu = new buy_products();
                    if(parse(record,x)=="")
                    {
                        break;
                    }
                    inu.name = parse(record, x);
                    inu.price = int.Parse(parse(record, x + 1));
                    input_f.buy_product.Add(inu);
                    m++;
                }
                user.Add(input_f);
            }
            var.Close();
        }

    }
}
