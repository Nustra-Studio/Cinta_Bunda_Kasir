using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.View
{
    public interface iParentDock
    {
        void top();
        void next();
        void prev();
        void Bot();
        void add();
        void delete();
        void search();
        void list();
        void print();
        void exit();
    }
}
