using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Repository;
using KasirApp.Model;
using KasirApp.View;

namespace KasirApp.Presenter
{
    class ReturPresenter
    {
        ReturRepo _repo = new ReturRepo();
        iRetur _ret;

        //Constructor
        public ReturPresenter(iRetur ret)
        {
            _ret = ret;
        }

        public ReturModel tampilData()
        {
            var model = new ReturModel();
            model.NomerTrans = _ret.nomerTrans;
            return _repo.showData(model);
        }

        public ReturModel Top()
        {
            var model = new ReturModel();
            if (_repo.cekRows() == true)
            {
                model = _repo.takeTop();
            }
            return model;
        }

        public ReturModel Bot()
        {
            var model = new ReturModel();
            if (_repo.cekRows()==true)
            {
                model = _repo.takeBot();
            }
            return model;
        }

        public ReturModel Prev()
        {
            var model = new ReturModel();
            if (_repo.cekRows() == true)
            {
                model = _repo.takePrev();
            }
            return model;
        }

        public ReturModel Next()
        {
            var model = new ReturModel();
            if (_repo.cekRows() == true)
            {
                model = _repo.takeNext();
            }
            return model;
        }

        public void addRetur()
        {

        }

        public List<ReturModel> takeList()
        {
            var model = new ReturModel();
            model.NomerTrans = _ret.nomerTrans;
            return _repo.ListBarangs(model);
        }

        public ReturModel takeDetailBarang()
        {
            var model = new ReturModel();
            model.Nama = _ret.nama;
            model.NomerTrans = _ret.nomerTrans;
            return _repo.takeDetail(model);
        }

        public bool simpanRetur()
        {
            var model = new ReturModel();
            model.Barcode = _ret.barcode;
            model.NomerTrans = _ret.nomerTrans;
            model.Nama = _ret.nama;
            model.Qty = _ret.qtyreturn;
            model.Harga = _ret.harga;   
            model.Total = _ret.total;
            model.Maxqty = _ret.maxqty;
            return _repo.saveRetur(model);
        }

        public void printData()
        {
            var model = new ReturModel();
            model.NomerTrans = _ret.nomerTrans;
            _repo.printPage(model);
        }
    }
}
