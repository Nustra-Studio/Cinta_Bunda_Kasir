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
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        
        //Constructor
        public TransaksiPresenter(iTransaksi trans, userDataModel model, iPopUpRecieve rec)
        {
            _trn = trans;
            _model = model;
            _repo = new TransaksiRepo(model);
            _rec = rec;
        }

        ///Method TO Repo
        //View and UI Method
        public void GetPoint()
        {
            string rand = _trn.randKode.ToString();
            if (op.CekNetwork()==false)
            {
                mb.PeringatanOK("Tidak ada koneksi Internet");
            }
            else if (_repo.AmbilPoint(_model, rand)==null)
            {
                mb.PeringatanOK("Kode Salah atau Kadaluarsa!");
            }
            else
            {
                _trn.GetMember(_repo.AmbilPoint(_model, rand));
            }
        }

        public void getDataByValue()
        {
            var model = new TransaksiModel();
            model.Barkode = _trn.selection;
            model.State = _trn.state;
            model.NomorPJ = _trn.nomorPJ;

            _trn.GetDataBarangs(_repo.getByValue(model));
        }

        public void UpdateState(string state)
        {
            var model = new TransaksiModel();
            model.NomorPJ = _trn.nomorPJ;
            _repo.StateChange(state, model);

            TampilTable();
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
            model.Id_member = _trn.NamaMem;
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
            string rand = _trn.randKode.ToString();

            var model = new TransaksiModel();
            model.Barkode = _trn.barcode;
            model.NomorPJ = _trn.nomorPJ;
            model.Id_member = _trn.noHpMem;

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

            if (model.Quantity == "")
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
        public void ApplyDiskon()
        {
            var model = new TransaksiModel();
            model.NomorPJ = _trn.nomorPJ;
            model.Barkode = _trn.selection;
            model.Diskon = _trn.diskonTrans;
            model.State = _trn.state;

            if (model.Diskon == "")
            {
                mb.PeringatanOK("Masukan Nominal Diskon");
            }
            else
            {
                _repo.UpdateDiskon(model);
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

    }
}
