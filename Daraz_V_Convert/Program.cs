using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daraz_V_Convert
{
    class Program
    {
        const int SELLER_COUNT = 10;
        const int PRODUCT_COUNT = 20;
        const int CUST_COUNT = 10;
        const int BUY_COUNT = 5;
        ///////////////////////////////        Main Menu    /////////////////////////
        static void Main(string[] args)
        {
            ///////new
            int num_seller = 0;
            string[] seller_name = new string[SELLER_COUNT];
            string[] seller_phone_num = new string[SELLER_COUNT];
            string[] seller_buisness = new string[SELLER_COUNT];
            string[] seller_password = new string[SELLER_COUNT];

            int num_products = 0;
            string[] products = new string[PRODUCT_COUNT];
            int[] prices = new int[PRODUCT_COUNT];

            int num_cust = 0, num_product1 = 0;
            string[] user_nameA = new string[CUST_COUNT];
            string[] user_passwordA = new string[CUST_COUNT];
            string[] buy_productA = new string[BUY_COUNT];
            int[] buy_product_price = new int[BUY_COUNT];

            load_data(ref num_seller, seller_name, seller_phone_num, seller_buisness, seller_password,ref num_products, products, prices,ref num_cust, user_nameA, user_passwordA);

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
                                add_seller(ref num_seller, seller_name, seller_phone_num, seller_buisness, seller_password);
                            }
                            else if (admin_option == '2')
                            {
                                Console.WriteLine("Admin Menu > View Seller >");
                                Console.WriteLine("");
                                if (check_seller(num_seller,seller_phone_num))
                                {
                                    Console.WriteLine("Name\tNumber\tBuisness\tPassword");
                                    show_seller_data(num_seller, seller_name, seller_phone_num, seller_buisness, seller_password);
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
                                for (int i = 0; i < num_seller; i++)
                                {
                                    if (seller_phone_num[i] != "")
                                    {
                                        Console.WriteLine("You just added " + seller_name[i] + " to " + seller_buisness[i] + " Buisness list .");
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
                                    for (int i = 0; i < num_seller; i++)
                                    {
                                        if (delete_seller == seller_name[i])
                                        {
                                            index = i;
                                            break;
                                        }
                                    }
                                    if (index != -1)
                                    {
                                        Console.WriteLine(seller_name[index] + " has been deleted from " + seller_buisness[index] + " List .");
                                        seller_name[index] = "";
                                        seller_phone_num[index] = "";
                                        seller_buisness[index] = "";
                                        seller_password[index] = "";
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
                        string name1, buis, pass1, phone;
                        Console.WriteLine("Admin Menu > Add Seller > ");
                        Console.WriteLine("");
                        Console.Write("Enter Seller Name : ");
                        name1 = Console.ReadLine();
                        Console.Write("Enter Seller Phone Number : ");
                        phone = Console.ReadLine();
                        Console.Write("Enter Seller Buisness : ");
                        buis = Console.ReadLine();
                        Console.Write("Enter Seller Password : ");
                        pass1 = Console.ReadLine();
                        add_seller_to_array(name1, phone, buis, pass1,ref num_seller,seller_name, seller_phone_num, seller_buisness, seller_password);
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
                        for (int i = 0; i < num_seller; i++)
                        {
                            if (passs == seller_password[i] && name == seller_name[i])
                            {
                                index = i;
                            }
                        }
                        if (index != -1)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Hello " + seller_name[index] + " .");
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
                                    add_product(ref num_products, products, prices);
                                }
                                else if (seller_option == '2')
                                {
                                    Console.WriteLine("Seller Menu > View Products >");
                                    show_products(num_products, products, prices);
                                }
                                else if (seller_option == '3')
                                {
                                    Console.WriteLine("Seller Menu > Sorted Products >");
                                    sorting(num_products, products, prices);
                                }
                                else if (seller_option == '4')
                                {
                                    delete_products(seller_password[index], num_products, products, prices);
                                }
                                else if (seller_option == '5')
                                {
                                    update_seller(num_products, products, prices);
                                }
                                else if (seller_option == '6')
                                {
                                    Console.WriteLine("Seller Menu > Update Password >");
                                    Console.WriteLine("");
                                    seller_password[index] = update_password(seller_password[index]);
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
                            create_account_customer(ref num_cust, user_nameA, user_passwordA);
                            clear_screen();
                        }
                        else if (exit == '2')
                        {
                            int index = -1;
                            header();
                            Console.WriteLine("Customer > Login >");
                            Console.WriteLine("");
                            Console.WriteLine("Enter your name :");
                            user_name = Console.ReadLine();
                            Console.WriteLine("Enter your Password :");
                            user_password = Console.ReadLine();
                            for (int i = 0; i < num_cust; i++)
                            {
                                if (user_name == user_nameA[i] && user_password == user_passwordA[i])
                                {
                                    index = i;
                                }
                            }
                            if (index != -1)
                            {
                                while (customer_option != '5')
                                {
                                    header();
                                    customer_option = customer_menu();
                                    header();
                                    if (customer_option == '1')
                                    {
                                        Console.WriteLine("Customer Menu > View Products >");
                                        Console.WriteLine("");
                                        show_product_cust(num_products, products, prices,ref num_product1,buy_productA,buy_product_price);
                                    }
                                    else if (customer_option == '2')
                                    {
                                        Console.WriteLine("Customer Menu > View Cart >");
                                        Console.WriteLine("");
                                        bool yt = check_product(num_products,prices);
                                        if (yt)
                                        {
                                            Console.WriteLine("Products\tPrices");
                                            for (int i = 0; i < num_product1; i++)
                                            {
                                                Console.WriteLine(buy_productA[i] + "\t" + buy_product_price[i]);
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
                                        int tr = 0;
                                        Console.WriteLine("Customer Menu > Payment >");
                                        Console.WriteLine("");
                                        int op1;
                                        Console.WriteLine("Select Payment Method :");
                                        Console.WriteLine("1) Debit Card");
                                        Console.WriteLine("2) Cash On Delivery");
                                        op1 = int.Parse(Console.ReadLine());
                                        if (op1 == 1)
                                        {
                                            string credit_card_num;
                                            while (true)
                                            {
                                                Console.WriteLine("");
                                                Console.Write("Please Enter your credit card number : ");
                                                credit_card_num = Console.ReadLine();
                                                if (credit_card_num.Length == 7)
                                                {
                                                    Console.WriteLine("Your order has been placed.You will recieve parcel in 3 to 5 working days.");
                                                    Console.WriteLine("You have choosen Online Payment.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Please Enter Correct Card Number.");
                                                    Console.WriteLine("Press 1 to Exit...");
                                                    tr = int.Parse(Console.ReadLine());
                                                    if (tr == 1)
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        else if (op1 == 2)
                                        {
                                            header();
                                            string location, address;
                                            Console.WriteLine("On which address you want to recieve parcel.");
                                            Console.WriteLine("1) Home Address");
                                            Console.WriteLine("2) Office Address");
                                            location = Console.ReadLine();
                                            Console.WriteLine("Please Enter your address : ");
                                            address = Console.ReadLine();
                                            Console.WriteLine("Your order has been placed.You will recieve parcel in 3 to 5 working days.");
                                            Console.WriteLine("You have to pay cash on delivery .");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have entered the wrong input .");
                                        }
                                        if (tr == 0)
                                        {
                                            clear_screen();
                                        }
                                    }
                                    else if (customer_option == '4')
                                    {
                                        Console.WriteLine("Customer_Menu > Update Password >");
                                        Console.WriteLine("");
                                        user_passwordA[index] = update_password(user_passwordA[index]);
                                    }
                                    else if (customer_option == '5')
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
                            }
                            clear_screen();
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
                    store_data(num_seller, seller_name, seller_phone_num, seller_buisness, seller_password, products, prices, user_nameA, user_passwordA);
                }
                else
                {
                    header();
                    Console.WriteLine("You have entered the wrong input");
                    clear_screen();
                }
            }
            Console.ReadKey();
        }
        
        
        ////////////////////////////////////////////////Functions/////////////////////////////////////
        
        
        static void store_data(int num_seller, string[] seller_name, string[] seller_phone_num, string[] seller_buisness, string[] seller_password, string[] products, int[] prices, string[] user_nameA, string[] user_passwordA)
        {
            store_seller_data_to_file(num_seller,seller_name,seller_phone_num,seller_buisness,seller_password);
            store_product_to_file( products, prices);
            store_Customer_data_to_file(user_nameA, user_passwordA);
        }
        static void store_seller_data_to_file(int num_seller,string[] seller_name,string[] seller_phone_num,string[] seller_buisness,string[] seller_password)
        {
            string path = "seller.txt";
            StreamWriter var = new StreamWriter(path,false);
            for (int i = 0; i < num_seller; i++)
            {
                if(seller_name[i]!="")
                {
                    var.WriteLine(seller_name[i] + "$" + seller_phone_num[i] + "$" + seller_buisness[i] + "$" + seller_password[i]);
                }
            }
            var.Close();
        }
        static void store_product_to_file(string[] products, int[] prices)
        {
            string path = "product.txt";
            StreamWriter var = new StreamWriter(path, false);
            for (int i = 0; i < PRODUCT_COUNT; i++)
            {
                if(prices[i]>0)
                {
                    var.WriteLine(products[i] + "$" + prices[i]);
                }
            }
            var.Close();
        }
        static void store_Customer_data_to_file(string[] user_nameA, string[] user_passwordA)
        {
            string path = "cust.txt";
            StreamWriter var = new StreamWriter(path, false);
            for (int i = 0; i < CUST_COUNT; i++)
            {
                if(user_passwordA[i] != "")
                {
                    var.WriteLine(user_nameA[i] + "$" + user_passwordA[i]);
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
        static void add_seller_to_array(string name, string ph, string buisness, string pass,ref int num_seller, string[] seller_name, string[] seller_phone_num, string[] seller_buisness, string[] seller_password)
        {
            seller_name[num_seller] = name;
            seller_phone_num[num_seller] = ph;
            seller_buisness[num_seller] = buisness;
            seller_password[num_seller] = pass;
            num_seller++;
        }
        static void add_seller(ref int num_seller,string[] seller_name, string[] seller_phone_num, string[] seller_buisness, string[] seller_password)
        {
            for (int i = num_seller; i < SELLER_COUNT; i++)
            {
                int exit = 0;
                header();
                string name, buis, pass, phone;
                Console.WriteLine("Admin Menu > Add Seller > ");
                Console.WriteLine("");
                Console.Write("Enter Seller Name : ");
                name = Console.ReadLine();
                Console.Write("Enter Seller Phone Number : ");
                phone = Console.ReadLine();
                Console.Write("Enter Seller Buisness : ");
                buis = Console.ReadLine();
                Console.Write("Enter Seller Password : ");
                pass = Console.ReadLine();
                add_seller_to_array(name, phone, buis, pass,ref num_seller, seller_name, seller_phone_num, seller_buisness, seller_password);
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
        static bool check_product(int num_products, int[] prices)
        {
            bool yt = false;
            for (int x = 0; x < num_products; x++)
            {
                if (prices[x] > 0)
                {
                    yt = true;
                }
            }
            return yt;
        }
        static bool check_seller(int num_seller,string[] seller_phone_num)
        {
            bool yt = false;
            for (int x = 0; x < num_seller; x++)
            {
                if (seller_phone_num[x] != "")
                {
                    yt = true;
                }
            }
            return yt;
        }
        static int check_name(string buyp, int num_products, string[] products)
        {
            int yt = -1;
            for (int x = 0; x < num_products; x++)
            {
                if (products[x] == buyp)
                {
                    yt = x;
                }
            }
            return yt;
        }
        static void show_seller_data(int num_seller, string[] seller_name, string[] seller_phone_num, string[] seller_buisness, string[] seller_password)
        {
            for (int i = 0; i < num_seller; i++)
            {
                if (seller_phone_num[i] != "")
                {
                    Console.WriteLine(seller_name[i] + "\t" + seller_phone_num[i] + "\t" + seller_buisness[i] + "\t" + seller_password[i]);
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
        static void add_product_to_array(string product, int price,ref int num_products, string[] products, int[] prices)
        {
            products[num_products] = product;
            prices[num_products] = price;
            num_products++;
        }
        static void add_product(ref int num_products, string[] products, int[] prices)
        {
            int exit = 0;
            for (int i = num_products; i < PRODUCT_COUNT; i++)
            {
                Console.Clear();
                header();
                string product;
                int price;
                Console.WriteLine("Seller Menu > Add Products > ");
                Console.WriteLine("");
                Console.Write("Enter the name of the product : ");
                product = Console.ReadLine();
                Console.Write("Enter the price of product : ");
                price = int.Parse(Console.ReadLine());
                add_product_to_array(product, price,ref num_products,products, prices);
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
        static void show_products(int num_products, string[] products, int[] prices)
        {
            bool yt = check_product(num_products,prices);
            Console.WriteLine("");
            if (yt)
            {
                Console.WriteLine("Products\tPrice");
                Console.WriteLine("");
                for (int i = 0; i < num_products; i++)
                {
                    if (prices[i] > 0)
                    {
                        Console.WriteLine(products[i] + "\t" + prices[i]);
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
        static void sorting(int num_products, string[] products, int[] prices)
        {
            bool yt = check_product(num_products,prices);
            if (yt)
            {
                Console.WriteLine("");
                Console.WriteLine("1) Ascending Order");
                Console.WriteLine("2) Decending Order");
                int op = int.Parse(Console.ReadLine());
                if (op == 1)
                {
                    for (int x = 0; x < num_products; x++)
                    {
                        for (int m = x + 1; m < num_products; m++)
                        {
                            if (prices[m] < prices[x])
                            {
                                string temp = products[x];
                                products[x] = products[m];
                                products[m] = temp;
                                int temp1 = prices[x];
                                prices[x] = prices[m];
                                prices[m] = temp1;
                            }
                        }
                    }
                    show_products(num_products,  products,prices);
                }
                else if (op == 2)
                {
                    for (int x = 0; x < num_products; x++)
                    {
                        for (int m = x + 1; m < num_products; m++)
                        {
                            if (prices[m] > prices[x])
                            {
                                string temp = products[x];
                                products[x] = products[m];
                                products[m] = temp;
                                int temp1 = prices[x];
                                prices[x] = prices[m];
                                prices[m] = temp1;
                            }
                        }
                    }
                    show_products(num_products,products,prices);
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
        static void delete_products(string seller_pass,int num_products, string[] products, int[] prices)
        {
            string delete_product;
            int index = -1;
            string password;
            bool yt = check_product(num_products,prices);
            Console.WriteLine("Seller Menu > Delete Product > ");
            Console.WriteLine("");
            Console.Write("Enter Password : ");
            password = Console.ReadLine();
            if (password == seller_pass)
            {
                if (yt)
                {
                    Console.Write("Enter the name of product you want to delete : ");
                    delete_product = Console.ReadLine();
                    for (int i = 0; i < num_products; i++)
                    {
                        if (delete_product == products[i])
                        {
                            index = i;
                        }
                    }
                    if (index == -1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("There is no such product .");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine(products[index] + " has been deleted .");
                        products[index] = "";
                        prices[index] = 0;
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
        static void update_seller(int num_products, string[] products, int[] prices)
        {
            Console.WriteLine("Seller Menu > Update Product >");
            Console.WriteLine("");
            bool yt = check_product(num_products,prices);
            if (yt)
            {
                string update_product;
                int index = -1;
                Console.Write("Enter the name of product you want to Update : ");
                update_product = Console.ReadLine();
                for (int i = 0; i < num_products; i++)
                {
                    if (update_product == products[i])
                    {
                        index = i;
                    }
                }
                if (index == -1)
                {
                    Console.WriteLine("There is no such Product .");
                }
                else
                {
                    Console.Write("Enter the updated name of the product : ");
                    products[index] = Console.ReadLine();
                    Console.Write("Enter the updated price of the product : ");
                    prices[index] = int.Parse(Console.ReadLine());
                    Console.WriteLine(products[index] + " has been updated. Its Current Price is " + prices[index] + " .");

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
            Console.WriteLine("4)  Update Password");
            Console.WriteLine("5)  Exit");
            Console.WriteLine("");
            Console.WriteLine("Enter your option");
            char op = Console.ReadLine()[0];
            return op;
        }
        static void add_cust_to_array(string name, string pass,ref int num_cust,string[] user_nameA,string[] user_passwordA)
        {
            user_nameA[num_cust] = name;
            user_passwordA[num_cust] = pass;
            num_cust++;
        }
        static void create_account_customer(ref int num_cust, string[] user_nameA, string[] user_passwordA)
        {
            string name, pass;
            Console.Write("Enter your name : ");
            name = Console.ReadLine();
            Console.Write("Enter your password : ");
            pass = Console.ReadLine();
            add_cust_to_array(name, pass,ref num_cust,user_nameA, user_passwordA);
            Console.WriteLine("Welcome " + name);
            Console.WriteLine("Your Account has been created Successfully.");

        }
        static void show_product_cust(int num_products,string[] products,int[] prices,ref int num_product1,string[] buy_productA,int[] buy_product_price)
        {
            bool yt = check_product(num_products, prices);
            if (yt)
            {
                string buy_products = "";
                if (num_product1 < 5)
                {
                    while (num_product1 < 5)
                    {
                        header();
                        Console.WriteLine("Customer_Menu > View Products >");
                        Console.WriteLine("");
                        Console.WriteLine("Products\tPrices");
                        for (int i = 0; i < num_products; i++)
                        {
                            if (prices[i] > 0)
                            {
                                Console.WriteLine(products[i] + "\t" + prices[i]);
                            }
                        }
                        Console.WriteLine("Which product you want to buy(press E to Exit");
                        buy_products = Console.ReadLine();
                        if (buy_products == "e")
                        {
                            break;
                        }
                        int ft = check_name(buy_products, num_products,products);
                        if (ft != -1)
                        {
                            buy_productA[num_product1] = buy_products;
                            buy_product_price[num_product1] = prices[ft];
                            num_product1++;
                            Console.WriteLine(buy_products + " has been succesfully added to the Cart.");
                            clear_screen();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("There is no such Product");
                            Console.WriteLine("Please Enter again");
                        }
                        clear_screen();
                    }
                }
                else
                {
                    Console.WriteLine("You have reached your limit .");
                    clear_screen();
                }
            }
            else
            {
                Console.WriteLine("There are no Products to display .");
                clear_screen();
            }
        }
        static void load_seller_data_to_array(ref int num_seller, string[] seller_name, string[] seller_phone_num, string[] seller_buisness, string[] seller_password)
        {
            string path = "seller.txt";
            if (File.Exists(path))
            {
                StreamReader var = new StreamReader(path);
                string record;
                string name, phone, buisness, pass;
                while ((record = var.ReadLine()) != null)
                {
                    name = parse(record, 1);
                    phone = parse(record, 2);
                    buisness = parse(record, 3);
                    pass = parse(record, 4);
                    add_seller_to_array(name, phone, buisness, pass,ref num_seller,seller_name,seller_phone_num, seller_buisness, seller_password);
                }
                var.Close();
            }
        
        }
        static void load_products_to_array(ref int num_products, string[] products, int[] prices)
        {
            string path = "product.txt";
            if(File.Exists(path))
            {
                StreamReader var=new StreamReader(path);
                string record;
                string product;
                int price;
                while((record = var.ReadLine()) != null)
                {
                    product = parse(record, 1);
                    price = int.Parse(parse(record, 2));
                    add_product_to_array(product, price,ref num_products,products, prices);
                }
                var.Close();
            }
        }
        static void load_customers_to_array(ref int num_cust, string[] user_nameA, string[] user_passwordA)
        {
            string path = "cust.txt";
            if (File.Exists(path))
            {
                StreamReader var = new StreamReader(path);
                string record;
                string name;
                string pass;
                while ((record = var.ReadLine()) != null)
                {
                    name = parse(record, 1);
                    pass = parse(record, 2);
                    add_cust_to_array(name, pass,ref num_cust, user_nameA, user_passwordA);
                }
                var.Close();
            }
        }
        static void load_data(ref int num_seller, string[] seller_name, string[] seller_phone_num, string[] seller_buisness, string[] seller_password,ref int num_products, string[] products, int[] prices,ref int num_cust, string[] user_nameA, string[] user_passwordA)
        {
            load_seller_data_to_array(ref num_seller, seller_name, seller_phone_num, seller_buisness, seller_password);
            load_products_to_array(ref num_products, products, prices);
            load_customers_to_array(ref num_cust, user_nameA, user_passwordA);
        }
    }
}
