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

        private readonly double _price = 4.5;

        public FrontRowAddon(TicketModel ticketModel)
        {
            this._ticketModel = ticketModel;
        }

        //This is added to the passed in ticket model object
        public override string Name => _ticketModel.Name + " with Front Row Seats";

        public override double Cost()
        {
            return this._ticketModel.Cost() + _price; //front row cost added to cost
        }
    }
}
