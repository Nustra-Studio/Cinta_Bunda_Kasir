using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Repository;
using KasirApp.Model;
using KasirApp.View;
using System.Data;

namespace KasirApp.Presenter
{
    class PopUpPresenter
    {
        //Fields
        PopUpRepo _repo = new PopUpRepo();
        iPopup _pop;

        //Constructor
        public PopUpPresenter(iPopup pop)
        {
            _pop = pop;
        }
        
        public DataTable tampilBarangs()
        {
            return _repo.Barangs();
        }

        public void getBarangsData(string text)
        {
           _pop.GetBarangs(_repo.AmbildataBarang(text));
        }
    }
}
