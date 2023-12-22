using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Repository;
using KasirApp.Model;
using System.Data;

namespace KasirApp.Presenter
{
    class TransferGudangPresenter   
    {
        TransferGudangRepo _repo = new TransferGudangRepo();
        MboxOperator mb = new MboxOperator();
        public TransferGudangPresenter()
        {
            _repo = new TransferGudangRepo();
        }

        public long AmbilNumbering()
        {
           return _repo.Numbering();
        }

        public TransferGudangModel bawah()
        {
            return _repo.takeBot();
        }

        public TransferGudangModel atas()
        {
            return _repo.takeTop();
        }

        public TransferGudangModel sebelum()
        {
            return _repo.takePrev();
        }

        public TransferGudangModel lanjut()
        {
            return _repo.Next();
        }

        public List<TransferGudangModel> ambilData(userDataModel model)
        {
            return _repo.GetData(model);
        }

        public DataTable GetData()
        {
            if (_repo.GetListTransfer() != null)
            {
                return _repo.GetListTransfer();
            }
            else
            {
                return null;
            }
        }

        public void deleteSent(userDataModel user)
        {
            _repo.hapusKiriman(user);
        }

        public void Sementara(List<TransferGudangModel> model,string nomerTrans)
        {
            _repo.simpanSementara(model, nomerTrans);
        }

        public void Insert(List<TransferGudangModel> model, string nomerTrans, string keterangan, userDataModel user)
        {
            if (nomerTrans == "" || keterangan == "")
            {
                mb.PeringatanOK("Tolong lengkapi data!");
            }
            else if (mb.KonfimasiYesNo("Simpan Item?") == true)
            {
                _repo.masukanItem(model,nomerTrans);
                _repo.masukanLaporan(model, nomerTrans, keterangan, user);
            }
        }

        public void PrintData(string nomerTrans)
        {
            _repo.PrintPage(nomerTrans);
        }

        internal DataTable MuatDGV(object text)
        {
            return _repo.RefreshData(text);
        }
    }
}
