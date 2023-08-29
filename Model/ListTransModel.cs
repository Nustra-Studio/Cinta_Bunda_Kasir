using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class ListTransModel
    {
        string id;
        string uuid;
        string PTG;
        string PJC;
        string PAD;
        string POP;
        string tanggal;

        public string Id { get => id; set => id = value; }
        public string Uuid { get => uuid; set => uuid = value; }
        public string PTG1 { get => PTG; set => PTG = value; }
        public string PJC1 { get => PJC; set => PJC = value; }
        public string PAD1 { get => PAD; set => PAD = value; }
        public string POP1 { get => POP; set => POP = value; }
        public string Tanggal { get => tanggal; set => tanggal = value; }
    }
}
