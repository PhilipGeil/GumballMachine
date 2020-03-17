using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumballMachine
{
    class Program
    {
        static Household household = new Household();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, please enter your address of your household: ");
            household.Address = Console.ReadLine();
            Console.WriteLine("Very good, now you're ready to get some gum");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You know have the following options: ");
            while (true)
            {
                ShowMenu();
                MenuSelector(int.Parse(Console.ReadLine()));
            }
        }
        /// <summary>
        /// Method to show the menu
        /// </summary>
        static void ShowMenu()
        {
            Console.Clear();
            List<string> options = new List<string>() { "Turn the handle to get a gum", "Take the gum from the output drawer", "Show how much gum is left in the machine", "Show the specific number of different gums in the machine", "Fill the machine", "Show how much gum you have in the house", "Get some more spare gum", "Exit the program" };
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, options[i]);
            }
        }
        /// <summary>
        /// Method that executes the choise of the menu
        /// </summary>
        /// <param name="choise">the selected choise</param>
        static void MenuSelector(int choise)
        {
            Console.Clear();
            switch (choise)
            {
                case 1:
                    TurnTheHandle();
                    EndOption();
                    break;
                case 2:
                    TakeTheGum();
                    EndOption();
                    break;
                case 3:
                    ShowGumAmount();
                    EndOption();
                    break;
                case 4:
                    ShowSpecificAmount();
                    EndOption();
                    break;
                case 5:
                    FillTheMachine();
                    EndOption();
                    break;
                case 6:
                    ShowHouseHolding();
                    EndOption();
                    break;
                case 7:
                    GetMoreSpareGum();
                    EndOption();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Method that returns the user to the menu
        /// </summary>
        static void EndOption()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }
        /// <summary>
        /// Simulates the handle turn, in which it executes the gum dropping to the output drawer
        /// </summary>
        static void TurnTheHandle()
        {
            if (household.gumballMachine.GetNumberOfGums() == 0)
            {
                Console.WriteLine("Oh no, the machine appears to be empty.. that sure sucks..");
            }
            else
            {
                household.gumballMachine.GetGum();
                Console.WriteLine("You just got yourself a gum");
            }
        }
        /// <summary>
        /// Simulate that the user takes the gum from the machine
        /// </summary>
        static void TakeTheGum()
        {
            Gum gum = household.gumballMachine.TakeGum();
            if (gum != null)
            {
                Console.WriteLine("Allright, you just got a delicious {0} gum", gum.Flavour);
            }
            else
            {
                Console.WriteLine("I'm sorry, but there is no gum..");
            }
        }
        /// <summary>
        /// Shows the amount of gum left in the machine
        /// </summary>
        static void ShowGumAmount()
        {
            Console.WriteLine("There is exactly {0} pieces of gum in the machine", household.gumballMachine.GetNumberOfGums());
        }
        /// <summary>
        /// Shows the specific amount of gum left, divided into each flavour
        /// </summary>
        static void ShowSpecificAmount()
        {
            int blueberry = 0;
            int blackberry = 0;
            int tutti = 0;
            int orange = 0;
            int strawberry = 0;
            int apple = 0;
            foreach (Gum gum in household.gumballMachine.GetListOfGums())
            {
                switch (gum.Flavour)
                {
                    case "Blueberry":
                        blueberry++;
                        break;
                    case "Blackberry":
                        blackberry++;
                        break;
                    case "TuttiFrutti":
                        tutti++;
                        break;
                    case "Orange":
                        orange++;
                        break;
                    case "Strawberry":
                        strawberry++;
                        break;
                    case "Apple":
                        apple++;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Here's the specific amount");
            Console.WriteLine("Blueberry: {0}", blueberry);
            Console.WriteLine("Blackberry: {0}", blackberry);
            Console.WriteLine("TuttiFrutti: {0}", tutti);
            Console.WriteLine("Orange: {0}", orange);
            Console.WriteLine("Strawberry: {0}", strawberry);
            Console.WriteLine("Apple: {0}", apple);
        }
        /// <summary>
        /// Fills the machine
        /// </summary>
        static void FillTheMachine()
        {
            if (household.spareGums.Count == 0)
            {
                Console.WriteLine("You don't have any gums to fill in.. ");
                Console.WriteLine("You better call up your subscription manager and get some more");
            }
            else
            {
                Console.WriteLine(household.gumballMachine.FillMachine(household.spareGums));
            }
        }
        /// <summary>
        /// Shows the amount of gum you have left in the house
        /// </summary>
        static void ShowHouseHolding()
        {
            Console.WriteLine("You have {0} pieces of gum in your house", household.spareGums.Count);
        }
        /// <summary>
        /// Retrieves some more gum to have in the house
        /// </summary>
        static void GetMoreSpareGum()
        {
            if (household.spareGums.Count < 55)
            {
                Console.WriteLine("I can confirm that we have just send a brand new shipment to {0}", household.Address);
                household.spareGums.AddRange(household.subscriptionManager.DeliverGums());
            }
            else if (household.spareGums.Count < 110)
            {
                Console.WriteLine("Getting a bit greedy huh.. but sure i'll send some to {0}", household.Address);
                household.spareGums.AddRange(household.subscriptionManager.DeliverGums());
            }
            else
            {
                Console.WriteLine("I can see you have more than enough");
            }
        }
    }
}
