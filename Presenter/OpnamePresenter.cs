using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.View;
using KasirApp.Repository;
using KasirApp.Model; 

namespace KasirApp.Presenter
{
    public class OpnamePresenter
    {
        //Fields
        OpnameRepo _repo = new OpnameRepo();
        MboxOperator mb = new MboxOperator();
        iOpname _op;

        //Constructor
        public OpnamePresenter(iOpname op)
        {
            _op = op;
        }

        public void ambilNmr()
        {
            _op.takeNumber(_repo.getNumber());
        }

        public bool cekData()
        {
            var model = new OpnameModel();
            model.Nama = _op.nama;
            return _repo.Cek(model);
        }

        public void insertOpname()
        {
            try
            {
                var model = new OpnameModel();
                model.NumeringKwitansi = _op.numeringKwitansi;
                model.Nomor = _op.nomer;
                model.Nama = _op.nama;
                model.Barcode = _op.kode;
                model.Stok = _op.stok;
                model.Perubahan = _op.perubahan;
                model.Selisih = _op.selisih.ToString();
                model.Posted = _op.posted;
                model.Tanggal = _op.tanggal;

                _repo.masukanOpname(model);
                _op.showTable(_repo.showtable(model));
            }
            catch (NullReferenceException ex)
            {
                mb.PeringatanOK(ex.Message);
            }
        }

        public void cekTable()
        {
            var model = new OpnameModel();
            model.Nomor = _op.nomer;
            _op.showTable(_repo.showtable(model));
        }
    }
}
