using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumballMachine
{
    class StorageBowl
    {
        List<Gum> gums = new List<Gum>();

        public StorageBowl() { }
        /// <summary>
        /// return the list with the remaining gums
        /// </summary>
        /// <returns></returns>
        
        //Forkert navngivning - burde bare hedde GetGums
        public List<Gum> GetNumberOfGums()
        {
            return gums;
        }
        /// <summary>
        /// Fills the list with new gum
        /// </summary>
        /// <param name="fillGums">The list of gums which shall be filled with</param>
        public void FillMachine(List<Gum> fillGums) 
        {
            gums.AddRange(fillGums);
        }
        /// <summary>
        /// Retrieves a random piece of gum from the list
        /// </summary>
        /// <returns>The randomly chosen piece of gum</returns>
        public Gum GetGum()
        {
            Random rand = new Random();
            Gum gum = gums[rand.Next(0, gums.Count)];
            gums.Remove(gum);
            return gum;
        }
    }
}
