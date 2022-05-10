using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class TourModel : ITicket
    {
       public string Name { get; set; } = "Tour";

       public double Price { get; set; } = 14.99;

       public string Description { get; set; } = "A Tour around the stadium";
    }
}
