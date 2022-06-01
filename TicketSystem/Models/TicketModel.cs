using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public abstract class TicketModel
    {
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual string FoodItem { get; set; }
        public abstract double Cost();
    }
}
