using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Decorators
{
    class FrontRowAddon : TicketDecorator
    {
        private readonly TicketModel _ticketModel;

        public FrontRowAddon(TicketModel ticketModel)
        {
            this._ticketModel = ticketModel;
        }
        public override string Name => _ticketModel.Name + " with Front Row Seats";


        public override double Cost()
        {
            return this._ticketModel.Cost() + 4.50;
        }
    }
}
