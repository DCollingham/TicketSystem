using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Decorators
{
    //Concrete decorator to add pint food item
    public class PintAddon : TicketFoodDecorator //Inherits from TicketFoodDecorator abstract class
    {
        private readonly TicketModel _ticketModel;
        private string premessage; //Message to be added to passed in object
        public static double PintPrice { get; } = 3.5; //Accessable by other classes
        public PintAddon(TicketModel ticketModel)
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
        //Adds pre-message then pint to decorated object
        public override string FoodItem => _ticketModel.FoodItem + premessage + "Pint"; 
        public override string Name => _ticketModel.Name; //Without this Name is blank after decoration
        public override double Price => _ticketModel.Price; //Without this price is set to 0 after decoration

        public override double Cost()
        {
            return this._ticketModel.Cost() + PintPrice;
        }
    }
}