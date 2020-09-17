using BankingDomain;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // "Inversion of Control Container"
            // a piece of software that knows how to construct our objects for us.
            // it is a super factory. We'll train it, then say "You make the Form1"
            var container = Bootstrap();
            new Form1();
            Application.Run(container.GetInstance<Form1>()); // This is the "new new"
        }

        public static Container Bootstrap()
        {
            var container = new Container(); // this'll be about our only use of the "new" keyword for a while..
                                             // if we are trying to avoid coupling, "new is glue" as Steve Smith says.
            container.Options.EnableAutoVerification = false;
            var myClock = new SystemTime(); // configure it or whatever.
            container.RegisterInstance<ISystemTime>(myClock);
            container.Register<ICalculateBankAccountBonuses, StandardBonusCalculator>();
            container.Register<IProvideTheCutoffClock, StandardCutoffClock>();
            container.Register<INotifyTheFeds, WindowsFormsFedNotifier>();
            container.Register<BankAccount>(); // these two (this and below) are saying "Be prepared to make these, too"
            container.Register<Form1>();


            return container;
        }
    }
}
