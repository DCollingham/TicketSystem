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

        private int _ticketAmount;

        public double TotalCost { get; set; }
        public TicketModel Adult { get; set; } = new AdultTicketModel();
        public TicketModel Child { get; set; } = new ChildTicketModel();
        public TicketModel Member { get; set; } = new MemberTicketModel();
        public bool TourEnabled { get; set; } = true;
        public bool FrontRowEnabled { get; set; } = true;
        public bool ComboEnabled { get; set; } = true;
        public bool PieEnabled { get; set; } = true;
        public bool SliderEnabled { get; set; } = true;
        public bool PintEnabled { get; set; } = true;
        public bool PayEnabled { get; set; } = true;
        public string QCode { get; set; } = "Hidden";

        public int TicketAmount
        {
            get => _ticketAmount;

            set
            {
                _ticketAmount = value;
                NotifyOfPropertyChange(() => TicketAmount);
                NotifyOfPropertyChange(() => TotalCost);
                CalculateCost();
            }
        }
        public BindableCollection<TicketModel> Tickets { get; set; }

        //Private ticket field
        private TicketModel _selectedTicket;

        //Adds Tickets to the bindable collection
        public ShellViewModel()
        {
            _selectedTicket = Adult;
            TotalCost = _selectedTicket.Price; //Initially sets the cost to the first ticket selected
            TicketAmount = 1; //
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
                ComboEnabled = false;
                NotifyOfPropertyChange(() => SelectedTicket);
                CalculateCost();
                NotifyOfPropertyChange(() => TotalCost);
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
                NotifyOfPropertyChange(() => TourEnabled);
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
                NotifyOfPropertyChange(() => FrontRowEnabled);
            }

        }

        public void AddPie()
        {
            SelectedTicket = new PieAddon(SelectedTicket);
            PieEnabled = false;
            NotifyOfPropertyChange(() => SelectedTicket);
            NotifyOfPropertyChange(() => TotalCost);
            NotifyOfPropertyChange(() => PieEnabled);
        }
        public void AddPint()
        {
            SelectedTicket = new PintAddon(SelectedTicket);
            PintEnabled = false;
            NotifyOfPropertyChange(() => SelectedTicket);
            NotifyOfPropertyChange(() => TotalCost);
            NotifyOfPropertyChange(() => PintEnabled);
        }

        public void CalculateCost()
        {
            TotalCost = SelectedTicket.Cost() * TicketAmount;
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
            PieEnabled = true;
            PintEnabled = true;
            ComboEnabled = true;
            SliderEnabled = true;
            QCode = "Hidden";
            TicketAmount = 1;
            PayEnabled = true;
            NotifyOfPropertyChange(() => ComboEnabled);
            NotifyOfPropertyChange(() => Tickets);
            NotifyOfPropertyChange(() => TotalCost);
            NotifyOfPropertyChange(() => SelectedTicket);
            NotifyOfPropertyChange(() => FrontRowEnabled);
            NotifyOfPropertyChange(() => TourEnabled);
            NotifyOfPropertyChange(() => PintEnabled);
            NotifyOfPropertyChange(() => PieEnabled);
            NotifyOfPropertyChange(() => QCode);
            NotifyOfPropertyChange(() => TicketAmount);
            NotifyOfPropertyChange(() => SliderEnabled);
            NotifyOfPropertyChange(() => PayEnabled);
        }

        private ActionCommand printPageCommand;

        public ICommand PrintPageCommand
        {
            get
            {
                if (printPageCommand == null)
                {
                    printPageCommand = new ActionCommand(PrintPage);
                }

                return printPageCommand;
            }
        }

        private void PrintPage()
        {
            QCode = "Visible";
            NotifyOfPropertyChange(() => QCode);
            TourEnabled = false;
            FrontRowEnabled = false;
            PieEnabled = false;
            PintEnabled = false;
            ComboEnabled = false;
            SliderEnabled = false;
            PayEnabled = false;
            NotifyOfPropertyChange(() => SliderEnabled);
            NotifyOfPropertyChange(() => ComboEnabled);
            NotifyOfPropertyChange(() => SelectedTicket);
            NotifyOfPropertyChange(() => FrontRowEnabled);
            NotifyOfPropertyChange(() => TourEnabled);
            NotifyOfPropertyChange(() => PintEnabled);
            NotifyOfPropertyChange(() => PieEnabled);
            NotifyOfPropertyChange(() => PayEnabled);



        }
    }
}
