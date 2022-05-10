using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.ViewModels.Models;

namespace TicketSystem.ViewModels
{
    public class ShellViewModel : Screen
    {
        //New collection of tickets
        private BindableCollection<ITicket> _tickets = new BindableCollection<ITicket>();

        private double _tourPrice;
        public double TourPrice
        {
            get { return _tourPrice; }
            set { _tourPrice = value; }
        }


        //Private ticket field
        private ITicket _selectedTicket;

        //Adds Tickets to the bindable collection
        public ShellViewModel()
        {
            Tickets.Add(new AdultTicketModel());
            Tickets.Add(new ChildTicketModel());
            Tickets.Add(new MemberTicketModel());
        }

        public BindableCollection<ITicket> Tickets
        {
            get { return _tickets; }
            set { _tickets = value; }
        }


        //Property used to access field
        public ITicket SelectedTicket
        {
            get { return _selectedTicket; }
            set 
            { 
                _selectedTicket = value;
                NotifyOfPropertyChange(() => SelectedTicket);
            }
        }
        public void AddTour()
        {
            TourPrice = 10.99;
            NotifyOfPropertyChange(() => TourPrice);
        }

    }
}
