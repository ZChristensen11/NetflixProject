using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeramecNetFlixProject.UI;


namespace MeramecNetFlixProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new GenreDataEntry());
            //Application.Run(new MovieDataEntry());
            //Application.Run(new MemberDataEntry());
            //Application.Run(new RentalForm());
            //Application.Run(new LoginForm());
            //Application.Run(new ViewMovie());
            //Application.Run(new SignUp());
        }
    }
}
