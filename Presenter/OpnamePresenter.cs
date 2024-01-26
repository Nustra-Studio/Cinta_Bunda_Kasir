using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.View;
using KasirApp.Repository;
using KasirApp.Model;
using System.Data;

namespace KasirApp.Presenter
{
    public class OpnamePresenter
    {
        //Fields
        OpnameRepo _repo = new OpnameRepo();
        MboxOperator mb = new MboxOperator();
        userDataModel _user;
        iOpname _op;

        //Constructor
        public OpnamePresenter(iOpname op, userDataModel user)
        {
            _op = op;
            _user = user;
        }

        public void ambilNmr()
        {
            _op.takeNumber(_repo.getNumber());
        }

        public bool cekData()
        {
            var model = new OpnameModel();
            model.Barcode = _op.kode;
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

                _repo.masukanOpname(model,_user);
                _op.showTable(_repo.showtable(model));
            }
            catch (NullReferenceException ex)
            {
                mb.PeringatanOK(ex.Message);
            }
        }

        public bool AttemptSyncData()
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

            var bol = _repo.SyncData(model, _user);
            cekTable();

            return bol;
        }

        public bool DeleteData()
        {
            if (_op.selection == "")
            {
                mb.PeringatanOK("Pilih data yang akan di hapus");
            }
            {
                var model = new OpnameModel();
                model.Nomor = _op.nomer;
                model.Barcode = _op.selection;
                return _repo.Delete(model);
            }
        }

        public DataTable Search()
        {
            var model = new OpnameModel();
            model.Nomor = _op.nomer;
            model.Nama = _op.search;
            return _repo.doSearch(model);
        }

        public void PrintOP()
        {
            var model = new OpnameModel();
            model.Nomor = _op.nomer;
            _repo.printPage(model);
        }

        public void cekTable()
        {
            var model = new OpnameModel();
            model.Nomor = _op.nomer;
            _op.showTable(_repo.showtable(model));
        }

        internal void insertDirect()
        {
            var model = new OpnameModel();
            model.Barcode = _op.kode;
            model.Nomor = _op.nomer;

            _repo.directInsert(model, _user);

            _op.showTable(_repo.showtable(model));
        }

        internal void Upload()
        {
            var model = new OpnameModel();
            model.Nomor = _op.nomer;

            if (model.Nomor == "")
            {
                mb.PeringatanOK("Masukan Nomer Transaksi");
            }
            else
            {
                _repo.UploadData(model, _user);
            }
        }

        internal void Export()
        {
            _repo.ExportData();
        }
    }
}
