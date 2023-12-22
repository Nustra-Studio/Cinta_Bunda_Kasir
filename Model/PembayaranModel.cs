using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class PembayaranModel
    {
        string nomorPJ;
        string bayar;
        string kembali;
        string subtotal;
        string diskontotal;
        string diskonmember;
        string totalbiaya;
        string status;

        public string NomorPJ { get => nomorPJ; set => nomorPJ = value; }
        public string Bayar { get => bayar; set => bayar = value; }
        public string Kembali { get => kembali; set => kembali = value; }
        public string Subtotal { get => subtotal; set => subtotal = value; }
        public string Diskontotal { get => diskontotal; set => diskontotal = value; }
        public string Diskonmember { get => diskonmember; set => diskonmember = value; }
        public string Totalbiaya { get => totalbiaya; set => totalbiaya = value; }
        public string Status { get => status; set => status = value; }
    }
}
