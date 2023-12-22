using KasirApp.GUI;
using KasirApp.GUI.Supervisor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KasirApp.Model;
using KasirApp.View;
using KasirApp.GUI.Master;

namespace KasirApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Transaksi(null, null));
            Application.Run(new MasterForm());
            //Application.Run(new LaporanPOS(null));
        }
    }
}
