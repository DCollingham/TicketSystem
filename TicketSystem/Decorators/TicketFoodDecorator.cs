using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Decorators
{
    public abstract class TicketFoodDecorator : TicketModel
    {
        //Used to replace virtual member that is defined in TicketModel
        public abstract override string FoodItem { get; }
    }
}
