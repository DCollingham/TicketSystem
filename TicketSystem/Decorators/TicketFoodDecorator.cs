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
        public abstract override string FoodItem { get; }
    }
}
