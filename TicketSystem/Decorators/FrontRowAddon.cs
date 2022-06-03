using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Decorators
{
    //Concrete decorator used to add front row addon
    public class FrontRowAddon : TicketDecorator //Inherits from TicketDecorator abstract class
    {
        private readonly TicketModel _ticketModel;
        public static double FrontRowPrice { get; } = 4.5;

        public FrontRowAddon(TicketModel ticketModel)
        {
            _ticketModel = ticketModel;
        }

        //This is added to the passed in ticket model object
        public override string Name => _ticketModel.Name + " with Front Row Seats"; //Adds front row description to name
        public override double Price => _ticketModel.Price; //Without this price is set to 0 after decoration

        public override double Cost()
        {
            return _ticketModel.Cost() + FrontRowPrice; //front row cost added to cost
        }
    }
}
