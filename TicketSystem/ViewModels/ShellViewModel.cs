using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Decorators;
using TicketSystem.Models;

namespace TicketSystem.ViewModels
{
    public class ShellViewModel : Screen
    {
        //New collection of tickets
        private BindableCollection<TicketModel> _tickets = new BindableCollection<TicketModel>();

        public double TotalCost { get; set; }
        public TicketModel Adult { get; set; } = new AdultTicketModel();
        public TicketModel Child { get; set; } = new ChildTicketModel();
        public TicketModel Member { get; set; } = new MemberTicketModel();


        //Private ticket field
        private TicketModel _selectedTicket;

        //Adds Tickets to the bindable collection
        public ShellViewModel()
        {
            Tickets.Add(Adult);
            Tickets.Add(Child);
            Tickets.Add(Member);
            TotalCost = Tickets[0].Price; //Initially sets the cost to the first ticket selected
            
        }

        public BindableCollection<TicketModel> Tickets
        {
            get { return _tickets; }
            set { _tickets = value; }
        }


        //Property used to access field
        public TicketModel SelectedTicket
        {
            get { return _selectedTicket; }
            set 
            { 
                _selectedTicket = value;
                NotifyOfPropertyChange(() => SelectedTicket);
                CalculateCost();
                NotifyOfPropertyChange(() => TotalCost);
            }
        }
        public void AddTour()
        {
            SelectedTicket = new TourAddon(SelectedTicket);
            NotifyOfPropertyChange(() => SelectedTicket);
            NotifyOfPropertyChange(() => TotalCost);
        }

        public void AddFrontRow()
        {
            SelectedTicket = new FrontRowAddon(SelectedTicket);
            NotifyOfPropertyChange(() => SelectedTicket);
            NotifyOfPropertyChange(() => TotalCost);
        }

        public void CalculateCost()
        {
            TotalCost = SelectedTicket.Cost();
            TotalCost = Math.Round(TotalCost, 2, MidpointRounding.AwayFromZero);
            NotifyOfPropertyChange(() => TotalCost);
        }

    }
}
