using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.ViewModels.Models
{
    class ChildTicketModel : ITicket
    {
        public string Name { get; set; } = "Child Ticket";
        public double Price { get; set; } = 5.99;
    }
}
