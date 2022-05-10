using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.ViewModels.Models
{
    class MemberTicketModel : ITicket
    {
        public string Name { get; set; } = "Member Ticket";
        public double Price { get; set; } = 6.99;
    }
}
