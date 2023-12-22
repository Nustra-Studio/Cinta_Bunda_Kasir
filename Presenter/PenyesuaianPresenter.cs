using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Repository;
using KasirApp.View;
using KasirApp.Model;

namespace KasirApp.Presenter
{
    class PenyesuaianPresenter
    {
        //Fields
        iSubPenyesuaian _sub;
        iPenyesuaian _peny;
        PenyesuaianRepo _repo = new PenyesuaianRepo();
        MboxOperator mb = new MboxOperator();

        public PenyesuaianPresenter(iSubPenyesuaian sub, iPenyesuaian pen)
        {
            _sub = sub;
            _peny = pen;
        }

        public PenyesuaianModel bawah()
        {
            return _repo.takeBot();
        }

        public PenyesuaianModel atas()
        {
            return _repo.takeTop();
        }

        public PenyesuaianModel sebelum()
        {
            return _repo.takePrev();
        }

        public PenyesuaianModel lanjut()
        {
            return _repo.takeNext();
        }

        public void hapusData()
        {
            var model = new PenyesuaianModel();
            model.nomerTrans = _peny.nomerPAD;
            _repo.deleteData(model);
        }

        public void printData()
        {
            var model = new PenyesuaianModel();
            model.nomerTrans = _peny.nomerPAD;
            _repo.PrintPagePenyesuaian(model);
        }

        public void showList()
        {
            _repo.tampilList();
        }

        public long AmbilNomer()
        {
            return _repo.takeNumber();
        }

        public DataTable MuatDGV(string nomerTrans)
        {
            return _repo.reDGV(nomerTrans);
        }

        public PenyesuaianModel loadHeader()
        {
            return _repo.PickHeader(_peny.nomerPAD);
        }

        public void hapus(string barcode)
        {
            _repo.deleteRow(barcode, _peny.nomerPAD);
        }

        public bool cekBarang()
        {
            return _repo.Checks(_sub.nama);
        }

        public void addItem()
        {
            var model = new PenyesuaianModel();
            model.nomerTrans = _peny.nomerPAD;
            model.nama = _sub.nama;
            model.stok = _sub.stok;
            model.keterangan = _peny.keterangan;
            _repo.addPenyesuaian(model);
        }

        public bool SaveStok()
        {
            var model = new PenyesuaianModel();
            model.nomerTrans = _peny.nomerPAD;
            model.keterangan = _peny.keterangan;
            model.status = 1;
            return _repo.simpanStok(model);
        }
    }
}
