using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Decorators
{
    class TourAddon : TicketDecorator
    {
        private readonly TicketModel _ticketModel;
        private readonly double _tourPrice = 10.50;

        public TourAddon(TicketModel ticketModel)
        {
            this._ticketModel = ticketModel;
        }
        public override string Name => _ticketModel.Name + " & Tour";

        public override double Cost()
        {
            return this._ticketModel.Cost() + _tourPrice;
        }
    }
}
