using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class NumberingModel
    {
        //fields
        private int id;
        private string ptg;
        private string pop;
        private string pad;
        private string pjc;
        
        //Properties
        public int Id { get => id; set => id = value; }
        public string Ptg { get => ptg; set => ptg = value; }
        public string Pop { get => pop; set => pop = value; }
        public string Pad { get => pad; set => pad = value; }
        public string Pjc { get => pjc; set => pjc = value; }
    }
}
