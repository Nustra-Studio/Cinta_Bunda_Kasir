using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.View
{
    public interface iUser
    {
        string login { get; set; }
        string nama { get; set; }
        string group { get; set; }
        string password { get; set; }
    }
}
