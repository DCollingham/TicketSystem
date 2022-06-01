using Caliburn.Micro;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicketSystem.Decorators;
using TicketSystem.Models;

namespace TicketSystem.ViewModels
{
    public class ShellViewModel : Screen
    {
        public double TotalCost { get; set; }
        public TicketModel Adult { get; set; } = new AdultTicketModel();
        public TicketModel Child { get; set; } = new ChildTicketModel();
        public TicketModel Member { get; set; } = new MemberTicketModel();
        public bool TourEnabled { get; set; } = true;
        public bool FrontRowEnabled { get; set; } = true;
        public bool ComboEnabled { get; set; } = true;
        public BindableCollection<TicketModel> Tickets { get; set; }

        //Private ticket field
        private TicketModel _selectedTicket;

        //Adds Tickets to the bindable collection
        public ShellViewModel()
        {
            _selectedTicket = Adult;
            TotalCost = _selectedTicket.Price; //Initially sets the cost to the first ticket selected
            Tickets = new BindableCollection<TicketModel>();
            Tickets.Add(Adult);
            Tickets.Add(Child);
            Tickets.Add(Member);
            
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
                ComboEnabled = false;
                NotifyOfPropertyChange(() => ComboEnabled);

            }
        }
        public void AddTour()
        {
            if (TourEnabled)
            {
                SelectedTicket = new TourAddon(SelectedTicket);
                NotifyOfPropertyChange(() => SelectedTicket);
                NotifyOfPropertyChange(() => TotalCost);
                TourEnabled = false;
            }
        }

        public void AddFrontRow()
        {
            if (FrontRowEnabled)
            {
                SelectedTicket = new FrontRowAddon(SelectedTicket);
                NotifyOfPropertyChange(() => SelectedTicket);
                NotifyOfPropertyChange(() => TotalCost);
                FrontRowEnabled = false;
            }

        }

        public void CalculateCost()
        {
            TotalCost = SelectedTicket.Cost();
            TotalCost = Math.Round(TotalCost, 2, MidpointRounding.AwayFromZero);
            NotifyOfPropertyChange(() => TotalCost);
        }

        private ActionCommand resetPage;

        public ICommand ResetPageCommand
        {
            get
            {
                if (resetPage == null)
                {
                    resetPage = new ActionCommand(PerformResetPage);
                }

                return resetPage;
            }
        }

        private void PerformResetPage()
        {
            SelectedTicket = Adult;
            TourEnabled = true;
            FrontRowEnabled = true;
            ComboEnabled = true;
            NotifyOfPropertyChange(() => ComboEnabled);
            NotifyOfPropertyChange(() => Tickets);
            NotifyOfPropertyChange(() => TotalCost);
            NotifyOfPropertyChange(() => SelectedTicket);

        }
    }
}
