using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    //Abstract class cant be instantiated
    public abstract class TicketDecorator : TicketModel
    {
        //Used to replace virtual member that is defined in TicketModel
        public abstract override string Name { get; }
    }
}
