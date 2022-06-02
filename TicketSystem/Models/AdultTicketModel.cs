using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class AdultTicketModel : TicketModel //Inherits from ticket model
    {
        public AdultTicketModel() //Price and name set in constructor
        {
            Name = "Adult Ticket";
            Price = 9.99;
        }

        public override double Cost()
        {
            return Math.Round(Price, 2, MidpointRounding.AwayFromZero); //Returns price to 2DP
        }
    }
}
