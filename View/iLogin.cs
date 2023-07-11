using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace KasirApp.View
{
    interface iLogin
    {
        string Username { get; set; }
        string Password { get; set; }
        void hideForm();
    }
}
