using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TicketSystem.Models;
using TicketSystem.ViewModels;
using TicketSystem.Decorators;
namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Tests if the reset button can execute
        public void CanResetExecute()
        {
            var ShellView = new ShellViewModel(); //Creates ShellViewModel
            bool result = ShellView.ResetPageCommand.CanExecute(null); //Invokes command
            bool expectedResult = true;
            Assert.AreEqual(result, expectedResult, "Can reset can not execute"); //Checks expected vs actual
        }

        [TestMethod]
        //Tests if the pay button can execute
        public void CanPayExecute()
        {
            var ShellView = new ShellViewModel();
            bool result = ShellView.PrintPageCommand.CanExecute(null);
            bool expectedResult = true;
            Assert.AreEqual(result, expectedResult, "Pay can not execute");
        }

        //tests the expected price for adult ticket model

        [TestMethod]
        public void AdultTicketPrice()
        {
            AdultTicketModel adult = new AdultTicketModel();
            double expectedPrice = 9.99;
            Assert.AreEqual(adult.Price, expectedPrice, "Adult Ticket is not the right price");
        }

        [TestMethod]
        public void MemberTicketPrice()
        {
            MemberTicketModel adult = new MemberTicketModel();
            double expectedPrice = 3.99;
            Assert.AreEqual(adult.Price, expectedPrice, "Member Ticket is not the right price");
        }

        [TestMethod]
        public void ChildTicketPrice()
        {
            ChildTicketModel adult = new ChildTicketModel();
            double expectedPrice = 4.99;
            Assert.AreEqual(adult.Price, expectedPrice, "Child Ticket is not the right price");
        }

        [TestMethod]
        public void CheckIntitalPrice()
        {
            var ShellView = new ShellViewModel();
            AdultTicketModel adult = new AdultTicketModel();
            double expectedPrice = ShellView.SelectedTicket.Price; //Checks if the inital selected ticket is correct
            Assert.AreEqual(adult.Price, expectedPrice, "Selected ticket has the wrong price");
        }
        [TestMethod] 
        public void CheckPintDecorator() //Checks whether Pint decorator & adult price is correct
        {
            TicketModel adult = new AdultTicketModel();
            double expectedPrice = PintAddon.PintPrice + adult.Price;
            adult = new PintAddon(adult);
            Assert.AreEqual(adult.Cost(), expectedPrice, "Adult and pint is wrong price");
        }
    }
}
