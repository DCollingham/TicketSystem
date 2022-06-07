using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Decorators
{
    public class TourAddon : TicketDecorator //Inherits from TicketDecorator abstract class
    {
        private readonly TicketModel _ticketModel;
        public static double TourPrice { get; } = 10.50;
        public TourAddon(TicketModel ticketModel)
        {
            this._ticketModel = ticketModel;
        }
        public override string Name => _ticketModel.Name + " & Tour"; //Adds string to passed in object name
        public override double Price => _ticketModel.Price; //Without this price is set to 0 after decoration
        public override string FoodItem => _ticketModel.FoodItem;
        public override double Cost()
        {
            return this._ticketModel.Cost() + TourPrice; //Adds the price of tour to decorated object
        }
    }
}
