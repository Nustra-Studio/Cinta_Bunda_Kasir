using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class apiError
    {
        public string success { get; set; }
        public string message { get; set; }
        public string data { get; set; }
    }

    public class error
    {
        public string message { get; set; }
    }
}
