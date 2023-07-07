using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Report
{
    class Receipt
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Harga { get; set; }
        public int Qty { get; set; }
        public string Total { get; set; }
    }
}
