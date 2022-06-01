using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class MemberTicketModel : TicketModel
    {
        public MemberTicketModel()
        {
            Name = "Member Ticket";
            Price = 3.99;
        }
        public override double Cost()
        {
            return Math.Round(Price, 2, MidpointRounding.AwayFromZero);
        }
    }
}
