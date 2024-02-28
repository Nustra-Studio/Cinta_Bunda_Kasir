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

        public List<TfGudangAPI> ambilData(userDataModel model)
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

        public void Sementara(List<TfGudangAPI> model,string nomerTrans)
        {
            var listTF = new List<TransferGudangModel>();
            foreach (var item in model)
            {
                var md = new TransferGudangModel();
                md.id = item.id;
                md.uuid = item.uuid;
                md.category_id = item.category_id;
                md.id_supplier = item.id_supplier;
                md.kode_barang = item.kode_barang;
                md.harga = item.harga;
                md.harga_jual = item.harga_jual;
                md.harga_pokok = item.harga_pokok;
                md.harga_grosir = item.harga_grosir;
                md.stok = Convert.ToInt32(item.stok);
                md.keterangan = item.keterangan;
                md.name = item.name;
                md.merek_barang = item.merek_barang;
                md.type_barang_id = item.type_barang_id;
                md.created_at = item.created_at;
                md.updated_at = item.updated_at;
                listTF.Add(md);
            }
            _repo.simpanSementara(listTF, nomerTrans);
        }

        public void Insert(List<TfGudangAPI> model, string nomerTrans, string keterangan, userDataModel user)
        {
            var listTF = new List<TransferGudangModel>();
            foreach (var item in model)
            {
                var md = new TransferGudangModel();
                md.id = item.id;
                md.uuid = item.uuid;
                md.category_id = item.category_id;
                md.id_supplier = item.id_supplier;
                md.kode_barang = item.kode_barang;
                md.harga = item.harga;
                md.harga_jual = item.harga_jual;
                md.harga_pokok = item.harga_pokok;
                md.harga_grosir = item.harga_grosir;
                md.stok = Convert.ToInt32(item.stok);
                md.keterangan = item.keterangan;
                md.name = item.name;
                md.merek_barang = item.merek_barang;
                md.type_barang_id = item.type_barang_id;
                md.created_at = item.created_at;
                md.updated_at = item.updated_at;
                listTF.Add(md);
            }
            if (nomerTrans == "" || keterangan == "")
            {
                mb.PeringatanOK("Tolong lengkapi data!");
            }
            else if (mb.KonfimasiYesNo("Simpan Item?") == true)
            {
                _repo.masukanItem(listTF, nomerTrans);
                _repo.masukanLaporan(listTF, nomerTrans, keterangan, user);
            }
        }

        public void PrintData(string nomerTrans)
        {
            _repo.PrintPage(nomerTrans);
        }

        internal List<TransferGudangModel> MuatDGV(object text)
        {
            return _repo.RefreshData(text);
        }
    }
}
