using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.View;
using KasirApp.Model;
using KasirApp.Repository;
using KasirApp.GUI;

namespace KasirApp.Presenter
{
    public class TransaksiPresenter
    {
        //Fields
        iTransaksi _trn;
        iPopUpRecieve _rec;
        userDataModel _model;
        TransaksiRepo _repo;
        MboxOperator mb = new MboxOperator();
        
        //Constructor
        public TransaksiPresenter(iTransaksi trans, userDataModel model, iPopUpRecieve rec)
        {
            _trn = trans;
            _model = model;
            _repo = new TransaksiRepo();
            _rec = rec;
        }

        ///Method TO Repo
        //View and UI Method
        public void GetPoint()
        {
            string rand = _trn.randKode.ToString();
            _trn.GetMember(_repo.AmbilPoint(_model, rand));
        }

        public void TampilTable()
        {
            var model = new TransaksiModel();
            model.NomorPJ = _trn.nomorPJ;
            model.State = _trn.state;

            _trn.TampilGrid(_repo.SetView(model));
        }

        public int TakeNumber()
        {
            return _repo.AmbilNomor();
        }

        public void cekState()
        {
            
        }

        //CRUD Method
        public void AttemptInsertGrid()
        {
            var model = new TransaksiModel();
            model.Barkode = _trn.barcode;
            model.NomorPJ = _trn.nomorPJ;
            model.State = _trn.state;
            if (_repo.CekData(model)==true)
            {
                _repo.CekRows(model);
                TampilTable();
                _trn.clear();
                _trn.GetDataBarangs(_repo.AmbilValueRead(model));
            }
            else
            {
                var pop = new PopUp(_rec);
                pop.Show();
                pop.ShowBarangs(model.Barkode);
            }
        }

        public void insertApi(int sum)
        {
            var model = new TransaksiModel();
            model.Barkode = _trn.barcode;
            model.NomorPJ = _trn.nomorPJ;
            _repo.insertHistori(_model, model, sum);
            _trn.ClearAll();
        }

        public void ChangeQty()
        {
            var model = new TransaksiModel();
            model.Quantity = _trn.qty;
            model.Barkode = _trn.selection;
            model.NomorPJ = _trn.nomorPJ;
            model.State = _trn.state;

            if (model.Quantity == null)
            {
                mb.PeringatanOK("Quantity Tidak Boleh Kosong");
            }
            else if (model.Barkode == null)
            {
                mb.PeringatanOK("Silakan Pilih Barang yang akan di edit");
            }
            else 
            {
                _repo.UpdateQuantity(model);
                TampilTable();
            }
        }

        public void DeleteItem(TransaksiModel model)
        {
            if (mb.KonfimasiYesNo("Yakin Hapus?")==true)
            {
                _repo.Delete(model);
                TampilTable();
            }
            else
            {
                return;
            }
        }

        public void ApplyDiskon(TransaksiModel model)
        {

        }
    }
}
