using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumballMachine
{
    class Household
    {
        public string Address { get; set; }
        public GumballMachine gumballMachine = new GumballMachine();
        public List<Gum> spareGums = new List<Gum>();
        public SubscriptionManager subscriptionManager = new SubscriptionManager();

        public Household() { }
        /// <summary>
        /// Retrieves some more spare gums from the subscription manager to the spareGums list
        /// </summary>
        public void GetMoreGums()
        {
            spareGums.AddRange(subscriptionManager.DeliverGums());
        }
    }
}
