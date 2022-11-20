using System.Drawing;
using System.Runtime.CompilerServices;

namespace Tea_Shop_Project
{
    internal class ThomasProject3
    {
        // global constants
        const double PLAIN_TEA = 0.43; // where plain tea costs $0.43 per ounce
        const double BLACK_TEA = 0.53; // where black tea costs $0.53 per ounce
        const double GREEN_TEA = 0.65; // where green tea costs $0.65 per ounce
        const double WHITE_TEA = 0.78; // where white tea costs $0.78 per ounce
        const double TAX_RATE = 0.045; // where the sales tax rate is 4.5%

        // method that displays the first menu
        public static void displayStartMenu()
        {
            // display start menu
            Console.WriteLine("Welcome to the World's Best Tea Shop");
            Console.WriteLine("\t1 - Process a Single Order");
            Console.WriteLine("\t2 - Process Multiple Orders from a File");
            Console.WriteLine("\t3 - Quit");
            Console.Write("Enter menu choice (1, 2, or 3): ");
        }

        // method that accepts the user's menu choice for tea type and returns the price per ounce
        public static double determineCostPerOunce(int teaType)
        {
            // local variable to hold cost per ounce
            double cost;

            // calculate tea cost per ounce
            if (teaType == 1) // plain tea
            {
                cost = PLAIN_TEA; // $0.43 per ounce
            }
            else if (teaType == 2) // black tea
            {
                cost = BLACK_TEA; // $0.53 per ounce
            }
            else if (teaType == 3) // green tea
            {
                cost = GREEN_TEA; // $0.65 per ounce
            }
            else cost = WHITE_TEA; // white tea $0.78 per ounce

            // return cost per ounce
            return cost;
        }

        // method that accepts the user's menu choice for size of tea and returns the number of ounces
        public static int determineNumberOunces(int size)
        {
            // local variable to hold number of ounces 
            int ounces;

            // calculate number of ounces
            if (size == 1) // small
            {
                ounces = 8; // 8oz
            }
            else if (size == 2) // medium
            {
                ounces = 16; // 16oz
            }
            else ounces = 24; // large 24oz

            // return number of ounces
            return ounces;
        }

        // method that accepts the price per ounce and the number of ounces purchased and returns the price of the tea
        public static double calcPriceTea(double teaCost, int numOunces)
        {
            // local variable to hold price
            double price;

            // calculate subtotal
            price = teaCost * (double)numOunces;

            // return subtotal
            return price;
        }

        // method that only accepts the price of the tea and returns the sales tax owed
        public static double calcSalesTax(double subtotal)
        {
            // local variable to hold tax
            double tax;

            // calculate the sales tax
            tax = subtotal * TAX_RATE;

            // return sales tax
            return tax;
        }

        // method that accepts the price of the tea and the sales tax and returns the total amount owed
        public static double calcCostBill(double subtotal, double tax)
        {
            // local variable to hold total
            double total;

            // calculate total
            total = subtotal + tax;

            // return total
            return total;
        }

        static void Main(string[] args)
        {
            // variables
            int mainMenuChoice; // to hold the main menu choice
            int teaType;        // to hold the tea type choice
            double teaCost;     // to hold the tea cost per ounce
            int size;           // to hold the tea size choice
            int numOunces;      // to hold the number of ounces per size
            string name;        // to hold the customer's name
            double subtotal;    // to hold the total before tax
            double tax;         // to hold the calculated sales tax
            double totalCost;   // to hold the total order cost
            string fileName = "orders.txt"; // to hold a reference to the multiple orders file object

            
            do // allow user to continue making main menu choices until they choose to quit
            {
                do // display the main menu, prompt choice and validate input
                {
                    // call method to display start menu and get menu input
                    displayStartMenu();
                    mainMenuChoice = Convert.ToInt32(Console.ReadLine());

                    // display error message if main menu input invalid
                    if (mainMenuChoice < 1 || mainMenuChoice > 3)
                    {
                        Console.WriteLine("\nERROR: INVALID MENU CHOICE. TRY AGAIN.\n");
                    }
                } while (mainMenuChoice < 1 || mainMenuChoice > 3); // reiterate main menu if input invalid
            
                // process a single order, multiple orders from file or quit, per main menu choice
                switch (mainMenuChoice)
                {
                    case 1: // process single order
                        do // display tea type menu, get and validate input
                        {
                            Console.WriteLine("\n\t1 - Plain Tea");
                            Console.WriteLine("\t2 - Black Tea");
                            Console.WriteLine("\t3 - Green Tea");
                            Console.WriteLine("\t4 - White Tea");
                            Console.Write("Enter Choice of Tea: ");
                            teaType = Convert.ToInt32(Console.ReadLine());

                            // display error message if tea type input invalid
                            if (teaType < 1 || teaType > 4)
                            {
                                Console.WriteLine("\nERROR: INVALID MENU CHOICE. PLEASE TRY AGAIN.");
                            }
                        } while (teaType < 1 || teaType > 4); // reiterate tea type menu if input invalid

                        // call method to determine tea cost per ounce
                        teaCost = determineCostPerOunce(teaType);

                        do // display size menu, get and validate input
                        {
                            Console.WriteLine("\nSelect a Size:");
                            Console.WriteLine("\t1 - Small (8oz)");
                            Console.WriteLine("\t2 - Medium (16oz)");
                            Console.WriteLine("\t3 - Large (24oz)");
                            Console.Write("Enter Choice of Size: ");
                            size = Convert.ToInt32(Console.ReadLine());

                            // display error message if size menu input invalid
                            if (size < 1 || size > 3)
                            {
                                Console.WriteLine("\nERROR: INVALID MENU CHOICE. PLEASE TRY AGAIN.");
                            }
                        } while (size < 1 || size > 3); // reiterate size menu if input invalid

                        // call method to calculate the number of ounces
                        numOunces = determineNumberOunces(size);

                        // call method to calculate subtotal of tea order
                        subtotal = calcPriceTea(teaCost, numOunces);

                        // call method to calcluate the sales tax
                        tax = calcSalesTax(subtotal);

                        // get customer's name
                        Console.Write("\nEnter the name of the customer: ");
                        name = Console.ReadLine();

                        // call method to calculate total cost
                        totalCost = calcCostBill(subtotal, tax);

                        // output order information
                        Console.WriteLine("\nName on order: {0}", name);
                        Console.WriteLine("Price of Tea: {0}", subtotal.ToString("c"));
                        Console.WriteLine("Sales Tax: {0}", tax.ToString("c"));
                        Console.WriteLine("Order Total: {0}\n", totalCost.ToString("c"));
                        break;

                    case 2: // process multiple orders from a file 
                        // declare the file reader object and read the orders.txt file
                        StreamReader sr = new StreamReader(fileName);

                        // process file from start to finish 
                        while (!sr.EndOfStream)
                        {
                            // read name
                            name = sr.ReadLine();

                            // read tea type 
                            teaType = int.Parse(sr.ReadLine());

                            // read tea size
                            size = int.Parse(sr.ReadLine());

                            // read blank line between entries
                            sr.ReadLine();

                            // call method to determine tea cost per ounce
                            teaCost = determineCostPerOunce(teaType);

                            // call method to determine the number of ounces in size choice
                            numOunces = determineNumberOunces(size);

                            // call method to calculate subtotal
                            subtotal = calcPriceTea(teaCost, numOunces);

                            // call method to calculate the sales tax
                            tax = calcSalesTax(subtotal);

                            // call method to calculate the total cost
                            totalCost = calcCostBill(subtotal, tax);

                            // output the order information
                            Console.WriteLine("\nName on order: {0}", name);
                            Console.WriteLine("Price of Tea: {0}", subtotal.ToString("c"));
                            Console.WriteLine("Sales Tax: {0}", tax.ToString("c"));
                            Console.WriteLine("Order Total: {0}\n", totalCost.ToString("c"));
                        }
                        // close the file
                        sr.Close();
                        break;

                    case 3: // display exit message and quit
                        Console.WriteLine("\nThank you for using the program. Goodbye.");
                        Environment.Exit(0);
                        break;
                }
            } while (mainMenuChoice != 3); // reiterate main menu until user chooses to quit
        }
    }
}