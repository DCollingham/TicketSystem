using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Decorators
{
    public class PieAddon : TicketFoodDecorator
    {
        private readonly TicketModel _ticketModel;
        private string premessage;
        public PieAddon(TicketModel ticketModel)
        {
            this._ticketModel = ticketModel;
            CheckFoodItem();
        }
        
        private void CheckFoodItem()
        {
            if (_ticketModel.FoodItem == null)
            {
                premessage = "Including ";
            }
            else
            {
                premessage = " & ";
            }
        }
        public override string FoodItem => _ticketModel.FoodItem + premessage + "Pie";
        public override string Name => _ticketModel.Name;

        public override double Cost()
        {
            return this._ticketModel.Cost() + 5.50;
        }
    }
}
