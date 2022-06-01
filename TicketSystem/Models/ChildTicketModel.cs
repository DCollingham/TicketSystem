using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class ChildTicketModel : TicketModel
    {
        public ChildTicketModel()
        {
            Name = "Child Ticket";
            Price = 4.99;
        }
        public override double Cost()
        {
            return Math.Round(Price, 2, MidpointRounding.AwayFromZero);
        }
    }
}
