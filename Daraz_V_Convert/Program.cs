using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daraz_V_Convert.BL;
using Daraz_V_Convert.DL;
using Daraz_V_Convert.UI;
namespace Daraz_V_Convert
{
    class Program
    {
        ///////////////////////////////        Main Menu    /////////////////////////
        ///check\\\
        static void Main(string[] args)
        {/*
            List<User> user = new List<User>();
            SellerDL.load_data();
            load_customers_data(user);
            char main_menu_option = '5';
            string admin_pass = "1234";
            string pass = "";
            while (main_menu_option != '4')
            {
                MainUI.header();
                main_menu_option = MainUI.main_menu();
                if (main_menu_option == '1')
                {
                    MainUI.header();
                    Console.WriteLine("Admin > ");
                    Console.WriteLine("");
                    Console.Write("Enter Password : ");
                    pass = Console.ReadLine();
                    if (pass == admin_pass)
                    {
                        char admin_option = '9';
                        
                        while (admin_option != '6')
                        {
                            MainUI.header();
                            admin_option = admin_menu();
                            MainUI.header();
                            if (admin_option == '1')
                            {
                                SellerDL.add_list( SellerUI.add_seller());
                            }
                            else if (admin_option == '2')
                            {
                                SellerUI.view_all_seller(SellerDL.get_list());
                            }
                            else if (admin_option == '3')
                            {
                                Console.WriteLine("Admin Option > History >");
                                Console.WriteLine("");
                                
                            }
                            else if (admin_option == '4')
                            {
                                
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
                                MainUI.clear_screen();
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
                        MainUI.clear_screen();
                    }
                }
                else if (main_menu_option == '2')
                {
                    string passs = " ", name;
                    int index = -1;
                    char exit = ' ';
                    char seller_option = '9';
                    MainUI.header();
                    Console.WriteLine("Seller >");
                    Console.WriteLine("");
                    Console.WriteLine("1)  Create new account");
                    Console.WriteLine("2)  Login(if you already have an account");
                    Console.WriteLine("Press e to exit");
                    exit = Console.ReadLine()[0];
                    if (exit == '1')
                    {
                        MainUI.header();
                        seller.Add(add_seller());
                        Console.WriteLine("Seller id has been created");
                        Console.WriteLine("");
                        exit = '2';
                    }
                    if (exit == '2')
                    {
                        MainUI.header();
                        Console.WriteLine("Seller > Login >");
                        Console.WriteLine("");
                        Console.Write("Enter your name : ");
                        name = Console.ReadLine();
                        Console.Write("Enter your Password : ");
                        passs = Console.ReadLine();
                        index=seller_login(seller,passs,name);
                        if (index != -1)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Hello " + seller[index].name + " .");
                            Console.WriteLine("Hope you are fine .");
                            Console.WriteLine("Lets get back to work .");
                            Console.WriteLine("");
                            MainUI.clear_screen();
                            while (seller_option != '7')
                            {
                                MainUI.header();
                                seller_option = SellerUI.seller_menu();
                                MainUI.header();
                                if (seller_option == '1')
                                {
                                    add_product_function(seller, index);
                                }
                                else if (seller_option == '2')
                                {
                                    Console.WriteLine("Seller Menu > View Products >");
                                    show_all_products(seller[index].product);
                                }
                                else if (seller_option == '3')
                                {
                                    Console.WriteLine("Seller Menu > Sorted Products >");
                                    sorting(seller, index);
                                }
                                else if (seller_option == '4')
                                {
                                    Console.WriteLine("Seller Menu > Delete Product > ");
                                    Console.WriteLine("");
                                    delete_products(seller[index].password, seller[index].product);
                                }
                                else if (seller_option == '5')
                                {
                                    update_product(seller[index].product);
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
                                    MainUI.clear_screen();
                                }
                                else
                                {
                                    Console.WriteLine("You have entered the wrong input");
                                    MainUI.clear_screen();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("The Password You entered is Incorrrect.");
                            Console.WriteLine("Please enter again...");
                            Console.WriteLine("");
                            MainUI.clear_screen();
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
                        MainUI.header();
                        string user_name, user_password;
                        Console.WriteLine("1)  Create new account");
                        Console.WriteLine("2)  Login(if you already have an account)");
                        Console.WriteLine("Press e to exit");
                        exit = Console.ReadLine()[0];
                        if (exit == '1')
                        {
                            MainUI.header();
                            Console.WriteLine("Customer > Create New Account >");
                            Console.WriteLine("");
                            create_account_customer(user);
                            exit = '2';
                            MainUI.clear_screen();
                        }
                        if (exit == '2')
                        {
                            int index = -1;
                            MainUI.header();
                            Console.WriteLine("Customer > Login >");
                            Console.WriteLine("");
                            Console.Write("Enter your name : ");
                            user_name = Console.ReadLine();
                            Console.Write("Enter your Password : ");
                            user_password = Console.ReadLine();
                            index=check_user(user,user_name,user_password);
                            if (index != -1)
                            {
                                while (customer_option != '6')
                                {
                                    MainUI.header();
                                    customer_option = customer_menu();
                                    MainUI.header();
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
                                            int total = 0;
                                            Console.WriteLine("Products\tPrices");
                                            for (int i = 0; i < user[index].buy_product.Count; i++)
                                            {
                                                Console.WriteLine(user[index].buy_product[i].name + "\t\t" + user[index].buy_product[i].price);
                                                total = total + user[index].buy_product[i].price;
                                            }
                                            Console.WriteLine("");
                                            Console.WriteLine("Total = " + total);
                                            Console.WriteLine("Press 1 to buy Product ...");
                                            Console.WriteLine("Press 2 to remove Product ...");
                                            char op = Console.ReadLine()[0];
                                            if (op == '1')
                                            {
                                                Console.WriteLine("Press any key to enter details.");
                                                customer_option = '3';
                                            }
                                            else if (op == '2')
                                            {
                                                MainUI.header();
                                                string remove_product;
                                                Console.WriteLine("Customer Menu > Remove Product >");
                                                Console.WriteLine("");
                                                Console.WriteLine("Enter the name of Product you want to delete : ");
                                                remove_product = Console.ReadLine();
                                                for (int i = 0; i < user[index].buy_product.Count; i++)
                                                {
                                                    if (remove_product == user[index].buy_product[i].name)
                                                    {
                                                        user[index].buy_product.RemoveAt(i);
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please Enter some Products to Cart to buy .");
                                        }
                                        MainUI.clear_screen();
                                    }
                                    if (customer_option == '3')
                                    {
                                        MainUI.header();
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
                                                    MainUI.clear_screen();
                                                    break;
                                                }
                                                bool check = user_info_input(user, index);
                                                if (check)
                                                {
                                                    Console.WriteLine("Your order has been placed.You will recieve parcel in 3 to 5 working days.");
                                                    Console.WriteLine("You have to pay cash on delivery .");
                                                    user[index].buy_product.Clear();
                                                    Console.WriteLine("");
                                                    MainUI.clear_screen();
                                                }
                                                break;
                                            }
                                        }
                                        else if (op1 == 2)
                                        {
                                            MainUI.header();
                                            user_info_input(user, index);
                                            Console.WriteLine("Your order has been placed.You will recieve parcel in 3 to 5 working days.");
                                            Console.WriteLine("You have to pay cash on delivery .");
                                            user[index].buy_product.Clear();
                                            Console.WriteLine("");
                                            MainUI.clear_screen();
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have entered the wrong input .");
                                        }
                                    }
                                    else if (customer_option == '4')
                                    {
                                        Console.WriteLine("Customer_Menu > View Profile >");
                                        Console.WriteLine("");
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
                                        MainUI.clear_screen();
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
                                MainUI.clear_screen();
                            }
                        }
                        else
                        {
                            MainUI.header();
                            Console.WriteLine("You have entered the wrong input.");
                            MainUI.clear_screen();
                        }
                        Console.Clear();
                    }
                }
                else if (main_menu_option == '4')
                {
                    Console.WriteLine("Thanks for using our Program..");
                    Console.WriteLine("We are happy to serve you");
                    MainUI.clear_screen();
                    //Store DATA
                    store_Customer_data_to_file(user);
                    store_seller_data_to_file(seller);
                }
                else
                {
                    MainUI.header();
                    Console.WriteLine("You have entered the wrong input");
                    MainUI.clear_screen();
                }
            }*/
        }

        ////////////////////////////////////////////////Functions/////////////////////////////////////
        
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
        
        
        static int check_user(List<User> user,string name,string pass)
        {
            for (int i = 0; i < user.Count; i++)
            {
                if (name == user[i].name && pass == user[i].password)
                {
                    return i;
                }
            }
            return -1;
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
        
        static void add_product_function(List<Seller> seller, int index)
        {
            int exit = 0;
            while (true)
            {
                MainUI.header();
                Console.WriteLine("Seller Menu > Add Products > ");
                Console.WriteLine("");
                seller[index].product.Add(add_product());
                Console.WriteLine("");
                Console.WriteLine("Press 1 to Exit ...");
                exit = int.Parse(Console.ReadLine());
                if (exit == 1)
                {
                    break;
                }
            }
        }
        static Product add_product()
        {
            Product input = new Product();
            Console.Write("Enter the name of the product : ");
            input.name = Console.ReadLine();
            Console.Write("Enter the price of product : ");
            input.prices = int.Parse(Console.ReadLine());
            Console.WriteLine("Product has been added Successfully .");
            return input;
        }
        static void show_all_products(List<Product> product)
        {
            Console.WriteLine("");
            if (product.Count>0)
            {
                Console.WriteLine("Products\tPrice");
                Console.WriteLine("");
                for (int i = 0; i < product.Count; i++)
                {
                    show_one_product(product[i].name,product[i].prices);
                }
                Console.WriteLine("");
                MainUI.clear_screen();
            }
            else
            {
                Console.WriteLine("You have not entered any Products.");
                Console.WriteLine("Go to option 1 to add some products.");
                Console.WriteLine("");
                MainUI.clear_screen();
            }
        }
        static void show_one_product(String name,int price)
        {
            Console.WriteLine(name + "\t" + price);
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
                    }
                    show_all_products(seller[index].product);*/
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
                    }
                    show_all_products(seller[index].product);*/
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
                MainUI.clear_screen();
            }
        }
        static void delete_products(string seller_pass, List<Product> product)
        {
            string delete_product;
            string password;
            Console.Write("Enter Password : ");
            password = Console.ReadLine();
            if (password == seller_pass)
            {
                if (product.Count>0)
                {
                    Console.Write("Enter the name of product you want to delete : ");
                    delete_product = Console.ReadLine();
                    int idx=check_product(delete_product,product);
                    if (idx == -1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("There is no such product .");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine(product[idx].name + " has been deleted .");
                        product.RemoveAt(idx);
                    }
                    Console.WriteLine("");
                    MainUI.clear_screen();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("You have Entered no Products .");
                    Console.WriteLine("Go to Option 1 to add some Products .");
                    Console.WriteLine("");
                    MainUI.clear_screen();
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("The Password You entered is Incorrrect.");
                Console.WriteLine("Please enter again...");
                Console.WriteLine("");
                MainUI.clear_screen();
            }
        }
        static void update_product(List<Product> products)
        {
            if (products.Count > 0)
            {
                string update_product;
                Console.Write("Enter the name of product you want to Update : ");
                update_product = Console.ReadLine();
                int idx=check_product(update_product,products);
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
                    products[idx] = product;
                    Console.WriteLine(products[idx].name + " has been updated. Its Current Price is " + products[idx].prices + " .");
                }
            }
            else
            {
                Console.WriteLine("You have Entered no Products .");
                Console.WriteLine("Go to Option 1 to add some Products .");
            }
            Console.WriteLine("");
            MainUI.clear_screen();
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
            MainUI.clear_screen();
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
            bool check = true;
            Console.Write("Please Enter your Phone number : ");
            phone = Console.ReadLine();
            if (phone.Length >= 11)
            {
                user[index].phone = phone;
            }
            else
            {
                Console.WriteLine("Please Enter Valid Phone Number.");
                MainUI.clear_screen();
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
                MainUI.clear_screen();
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
            //bool yt = check_product_all(seller);
            if (seller[0].product.Count>0)
            {
                string buy_products = "";
                while (true)
                {
                    MainUI.header();
                    Console.WriteLine("Customer_Menu > View Products >");
                    Console.WriteLine("");
                    Console.WriteLine("Products\tPrices");
                    for (int i = 0; i < seller.Count; i++)
                    {
                        if (seller[i].product.Count > 0)
                        {
                            Console.WriteLine("Products By " + seller[i].name + " > ");
                            for (int j = 0; j < seller[i].product.Count; j++)
                            {
                                show_one_product(seller[i].product[j].name, seller[i].product[j].prices);
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
                    MainUI.clear_screen();
                }
            }
            else
            {
                Console.WriteLine("There are no Products to display .");
                MainUI.clear_screen();
            }
        }
        static void display_user_info(List<User> user, int index)
        {
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
            MainUI.clear_screen();
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
                    if (parse(record, x) == "")
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
        static int seller_login(List<Seller> seller, string seller_name,string password)
        {
            int index = -1;
            for (int i = 0; i < seller.Count; i++)
            {
                if (password == seller[i].name && seller_name == seller[i].password)
                {
                    index = i;
                }
            }
            return index;
        }
    }
}
