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

        private int _ticketAmount; //Total amount of tickets field
        private bool _tourEnabled = true;
        private bool _frontRowEnabled = true;
        private bool _comboEnabled = true;
        private bool _pieEnabled = true;
        private bool _pintEnabled = true;
        private bool _sliderEnabled = true;
        private string _qCode = "Hidden";
        private bool _payEnabled = true;
        private BindableCollection<TicketModel> _tickets;
        private TicketModel _selectedTicket; //Curent selected ticket field
        private ActionCommand resetPage; //Commands are bindable from xaml and they call functions

        public TicketModel Adult { get; set; } = new AdultTicketModel(); //Adult Ticket Model
        public TicketModel Child { get; set; } = new ChildTicketModel(); //Child Ticket Model   
        public TicketModel Member { get; set; } = new MemberTicketModel(); //Member Ticket Model

        public BindableCollection<TicketModel> Tickets
        {
            get { return _tickets; }
            set 
            { 
                _tickets = value;
                NotifyOfPropertyChange(() => Tickets);
            }
        }

        public bool TourEnabled
        {
            get { return _tourEnabled; }
            set
            {
                _tourEnabled = value;
                NotifyOfPropertyChange(() => TourEnabled);
            }
        }

        public bool ComboEnabled
        {
            get { return _comboEnabled; }
            set
            {
                _comboEnabled = value; 
            NotifyOfPropertyChange(() => ComboEnabled);
            }
        }

        public bool FrontRowEnabled
        {
            get { return _frontRowEnabled; }
            set 
            { 
                _frontRowEnabled = value;
                NotifyOfPropertyChange(() => FrontRowEnabled);
            }
        }

        public bool PieEnabled
        {
            get { return _pieEnabled; }
            set 
            { 
                _pieEnabled = value;
                NotifyOfPropertyChange(() => PieEnabled);
            }
        }

        public bool PintEnabled
        {
            get { return _pintEnabled; }
            set 
            {
                _pintEnabled = value;
                NotifyOfPropertyChange(() => PintEnabled);
            }
        }

        public bool SliderEnabled
        {
            get { return _sliderEnabled; }
            set 
            { 
                _sliderEnabled = value;
                NotifyOfPropertyChange(() => SliderEnabled);
            }
        }

        public bool PayEnabled
        {
            get { return _payEnabled; }
            set 
            { 
                _payEnabled = value;
                NotifyOfPropertyChange(() => PayEnabled);
            }
        }

        public string QCode
        {
            get { return _qCode; }
            set 
            { 
                _qCode = value;
                NotifyOfPropertyChange(() => QCode);
            }
        }

        private double _totalCost;

        public double TotalCost
        {
            get { return _totalCost; }
            set
            {
                _totalCost = SelectedTicket.Cost() * TicketAmount;
                _totalCost = Math.Round(TotalCost, 2, MidpointRounding.AwayFromZero);
                 _totalCost = value;
                NotifyOfPropertyChange(() => TotalCost);
            }
        }

        //Full property for ticket amount
        public int TicketAmount
        {
            get => _ticketAmount;

            set
            {
                _ticketAmount = value;
                NotifyOfPropertyChange(() => TicketAmount); //Notify observers of change
                NotifyOfPropertyChange(() => TotalCost);

                CalculateCost(); //Recaculates total cost of tickets
            }
        }

        //Adds Tickets to the bindable collection
        public ShellViewModel()
        {
            _selectedTicket = Adult; //Sets selected ticket field to Adult
            TotalCost = _selectedTicket.Price; //Initially sets the cost to the first ticket selected
            TicketAmount = 1; //Sets ticket amount to 1
            Tickets = new BindableCollection<TicketModel>(); //Initialises Ticket Collection
            Tickets.Add(Adult); //Adds tickets to collection
            Tickets.Add(Child);
            Tickets.Add(Member);
            
        }

        public TicketModel SelectedTicket //The ticket that is currently selected
        {
            get { return _selectedTicket; } //Returns _ticket field
            set
            {
                _selectedTicket = value;
                NotifyOfPropertyChange(() => SelectedTicket);
                NotifyOfPropertyChange(() => TotalCost);
                CalculateCost(); //Calculates cost on ticket change
            }
        }

        public void AddTour()
        {
            ComboEnabled = false; //Disables combo box
            TourEnabled = false; //Disables tour button
            SelectedTicket = new TourAddon(SelectedTicket); //Decorates ticket with tour
        }

        public void AddFrontRow()
        {
            ComboEnabled = false; //Disables combo box
            FrontRowEnabled = false; //Disables front row button
            SelectedTicket = new FrontRowAddon(SelectedTicket); //Decorates ticket with front row seats
        }

        public void AddPie()
        {
            ComboEnabled = false; //Disables combo box
            PieEnabled = false; //Disables Pie button
            SelectedTicket = new PieAddon(SelectedTicket); //Decorates ticket with food item Pie
        }
        public void AddPint()
        {
            ComboEnabled = false; //Disables combo box
            PintEnabled = false; //Disable pint button
            SelectedTicket = new PintAddon(SelectedTicket); //Decorates ticket with food item Pint
        }

        public void CalculateCost()
        {
            TotalCost = SelectedTicket.Cost() * TicketAmount; //Calculates cost fron selected ticket * quantity
            TotalCost = Math.Round(TotalCost, 2, MidpointRounding.AwayFromZero); //Round to 2DP
        }

        public ICommand ResetPageCommand //This is bound from the reset button
        {
            get
            {
                if (resetPage == null)
                {
                    resetPage = new ActionCommand(PerformResetPage); //Calls reset function
                }
                return resetPage;
            }
        }

        private void PerformResetPage() //Resets page to default and notifies observers
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
        }

        private ActionCommand printPageCommand;

        public ICommand PrintPageCommand //Bound from Pay/Print button
        {
            get
            {
                if (printPageCommand == null)
                {
                    printPageCommand = new ActionCommand(PrintPage); //Calls Print function
                }
                return printPageCommand;
            }
        }

        private void PrintPage() //Disables inputs until reset is called
        {
            QCode = "Visible";
            TourEnabled = false;
            FrontRowEnabled = false;
            PieEnabled = false;
            PintEnabled = false;
            ComboEnabled = false;
            SliderEnabled = false;
            PayEnabled = false;
        }
    }
}
