using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Decorators
{
    //Concrete ticket decorator
    public class PieAddon : TicketFoodDecorator //Inherits from TicketFoodDecorator abstract class
    {
        private readonly TicketModel _ticketModel;
        private string premessage; //Message to be added to Food Item
        public static double PiePrice { get; } = 5.5; //Accessable by other classes
        public PieAddon(TicketModel ticketModel)
        {
            this._ticketModel = ticketModel;
            CheckFoodItem();
        }
        
        //Logic to order the Food Item Message
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
        public override string FoodItem => _ticketModel.FoodItem + premessage + "Pie"; //The message that is added

        public override double Price => _ticketModel.Price; //Without this price is set to 0 after decoration
        public override string Name => _ticketModel.Name; //Without this Name is blank after decoration
        public override double Cost()
        {
            return this._ticketModel.Cost() + PiePrice;
        }
    }
}
