using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TicketSystem.ViewModels;

namespace TicketSystem
{   //Starting Point for application
    public class Bootstrapper : BootstrapperBase
    {
        //Starts bootstrapper proccesses
        public Bootstrapper()
        {
            Initialize();
        }

        //Overides base implementation of startup
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //Display root for for this view model
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
