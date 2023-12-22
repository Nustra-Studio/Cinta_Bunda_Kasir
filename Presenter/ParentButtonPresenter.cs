using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Repository;
using KasirApp.Model;

namespace KasirApp.Presenter
{
    class ParentButtonPresenter
    {
        ParentButtonRepo _repo = new ParentButtonRepo();
        public ParentButtonPresenter()
        {

        }

        public DataTable setview(string viewTable, string nomerTrans)
        {
            return _repo.setView(viewTable, nomerTrans);
        }

        public DataTable atas(string table, string viewTable)
        {
            return setview(viewTable, _repo.topValue(table));
        }

        public DataTable lanjut(string table, string viewTable)
        {
            return setview(viewTable, _repo.nextValue(table));
        }

        public DataTable sebelum(string table, string viewTable)
        {
            return setview(viewTable, _repo.prevValue(table));
        }

        public DataTable bawah(string table, string viewTable)
        {
            return setview(viewTable, _repo.botValue(table));
        }

        public ParrentButtonModel headerData(string reportTable)
        {
            return _repo.dataAtas(reportTable);
        }

        public ParrentButtonModel headerDataByValue(string reportTable,string identifier, string value)
        {
            return _repo.dataAtasByValue(reportTable, identifier, value);
        }

        public DataTable gridByValue(string reportTable, string identifier, string value)
        {
            return _repo.dataByValue(reportTable, identifier, value);
        }
    }
}
