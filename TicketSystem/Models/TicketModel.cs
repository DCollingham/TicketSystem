using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public abstract class TicketModel
    {
        //Virtual properties can be overidden
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual string FoodItem { get; set; } //The string to contain the fooditem
        public abstract double Cost();
    }
}
