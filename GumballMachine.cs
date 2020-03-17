using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumballMachine
{
    public class GumballMachine
    {
        static GumballMachine instance;
        StorageBowl storageBowl = new StorageBowl();
        Handle handle = new Handle();
        OutputDrawer outputDrawer = new OutputDrawer();

        GumballMachine() { }

        public static GumballMachine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GumballMachine();
                }
                return instance;
            }
        }

        /// <summary>
        /// Returns the amount of gum left in the machine
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfGums()
        {
            return storageBowl.GetNumberOfGums().Count;
        }
        /// <summary>
        /// Retrievs the list of gums, used for showing the specific remainings
        /// </summary>
        /// <returns></returns>
        public List<Gum> GetListOfGums()
        {
            return storageBowl.GetNumberOfGums();
        }
        /// <summary>
        /// Method that controls the refilling, in which it both handle the refill and also ensures the correct refilling
        /// </summary>
        /// <param name="fillGums"></param>
        /// <returns>String which indicates the status of the filling</returns>
        public string FillMachine(List<Gum> fillGums)
        {
            if (storageBowl.GetNumberOfGums().Count == 55)
            {
                return "Machine is already full";
            }
            Random rand = new Random();
            while (storageBowl.GetNumberOfGums().Count != 55 && fillGums.Count > 0)
            {
                Gum bufferGum = fillGums[rand.Next(0, fillGums.Count)];
                int availableSlots = SortGum(bufferGum, storageBowl.GetNumberOfGums());
                List<Gum> sortedGums = new List<Gum>();
                foreach (Gum item in fillGums)
                {
                    if (item.Flavour == bufferGum.Flavour)
                    {
                        sortedGums.Add(item);
                    }
                }
                List<Gum> finalList = new List<Gum>();
                for (int i = 0; i < availableSlots; i++)
                {
                    finalList.Add(sortedGums[i]);
                    fillGums.Remove(sortedGums[i]);
                }
                storageBowl.FillMachine(finalList);
            }
            return "The machine has been filled";
        }
        /// <summary>
        /// Priavte method used to sort the gum, and calculate the possible correct fillings
        /// </summary>
        /// <param name="gum">The gum trying to be filled</param>
        /// <param name="holding">The list of gum that is currently in the machine</param>
        /// <returns>An integer which indicates how many of the specific flavour there can be in the machine</returns>
        int SortGum(Gum gum, List<Gum> holding)
        {
            int minHolding = 0;
            int maxHolding = 0;
            List<Gum> currentHolding = new List<Gum>();
            foreach (Gum gumItem in holding)
            {
                if (gumItem.Flavour == gum.Flavour)
                {
                    currentHolding.Add(gumItem);
                }
            }
            switch (gum.Flavour)
            {
                case "Blueberry":
                    minHolding = 12;
                    maxHolding = 14;
                    break;
                case "Blackberry":
                    minHolding = 5;
                    maxHolding = 7;
                    break;
                case "TuttiFrutti":
                    minHolding = 10;
                    maxHolding = 12;
                    break;
                case "Orange":
                    minHolding = 9;
                    maxHolding = 11;
                    break;
                case "Strawberry":
                    minHolding = 6;
                    maxHolding = 8;
                    break;
                case "Apple":
                    minHolding = 4;
                    maxHolding = 6;
                    break;
                default:
                    break;
            }
            if (currentHolding.Count == maxHolding)
            {
                return 0;
            }
            else if (currentHolding.Count < minHolding)
            {
                return minHolding - currentHolding.Count;
            }
            else
            {
                return 1;
            }
        }
        /// <summary>
        /// Retrieves the gum from the storageBowl and "puts" it in the output drawer
        /// </summary>
        public void GetGum()
        {
            if (handle.ActivateGetGum())
            {
                outputDrawer.Gum = storageBowl.GetGum();
            }
        }
        /// <summary>
        /// Handles the part where the gum is taken from the machine
        /// </summary>
        /// <returns></returns>
        public Gum TakeGum()
        {
            if (outputDrawer.Gum != null)
            {
                Gum gum = outputDrawer.Gum;
                outputDrawer.Gum = null;
                return gum;
            }
            else
            {
                return null;
            }
        }
    }
}
