using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class AdultTicketModel : TicketModel
    {
        public AdultTicketModel()
        {
            Name = "Adult Ticket";
            Price = 9.99;
        }

        public override double Cost()
        {
            return Math.Round(9.99, 2, MidpointRounding.AwayFromZero);
        }
    }
}
