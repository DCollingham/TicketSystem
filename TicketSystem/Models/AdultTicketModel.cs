using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.ViewModels.Models
{
    class AdultTicketModel : ITicket
    {
        public string Name { get; set; } = "Adult Ticket";
        public double Price { get; set; } = 10.99;
    }
}
