using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumballMachine
{
    class OutputDrawer
    {
        public Gum Gum { get; set; }

        public OutputDrawer() { }
        /// <summary>
        /// Simulate the action where the gum is being taken from the machine
        /// </summary>
        /// <returns>The gum</returns>
        public Gum TakeGum()
        {
            return Gum;
        }
    }
}
