using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;    
using Newtonsoft.Json;
using KasirApp.Model;
using KasirApp.Report;
using System.Net;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Reporting.WinForms;

namespace KasirApp.Repository
{
    class TransferGudangRepo
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        int order;

        public long Numbering()
        {
            long number = 0;
            long kwitansi = 0;
            using (var cmd = new MySqlCommand("SELECT PTG FROM numberingkwitansi", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        number = Convert.ToInt64(rd["PTG"].ToString());
                        kwitansi = number + 1;
                    }
                }
            }
            return kwitansi;
        }

        public bool cekRows()
        {
            using (var cmd = new MySqlCommand("SELECT * FROM histori_transfergudang", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public int takeLimit()
        {
            int nomor = 0;
            using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM report_transfergudang", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    nomor = Convert.ToInt32(rd["COUNT(*)"].ToString());
                }
            }
            return nomor - 1;
        }

        public TransferGudangModel showByOrder(int urutan)
        {
            var md = new TransferGudangModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM report_transfergudang LIMIT {urutan},1", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        md.nomerTrans = rd["id_transfer"].ToString();
                        md.keterangan = rd["keterangan"].ToString();
                        md.status = rd["status"].ToString();
                    }
                }
            }
            return md;
        }

        public TransferGudangModel showByNomer(string nomerTrans)
        {
            var md = new TransferGudangModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM report_transfergudang where id_transfer = '{nomerTrans}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        md.nomerTrans = rd["id_transfer"].ToString();
                        md.keterangan = rd["keterangan"].ToString();
                        md.status = rd["status"].ToString();
                    }
                }
            }
            return md;
        }

        public TransferGudangModel Next()
        {
            if (cekRows() == false)
            {
                return null;
            }
            else
            {
                if (order >= takeLimit())
                {
                    order = takeLimit();
                    return showByOrder(order);
                }
                else
                {
                    order++;
                    return showByOrder(order);
                }
            }
        }

        public TransferGudangModel takePrev()
        {
            if (cekRows() == false)
            {
                return null;
            }
            else
            {
                if (order <= 0)
                {
                    order = 0;
                    return showByOrder(order);
                }
                else
                {
                    order--;
                    return showByOrder(order);
                }
            }
        }

        public TransferGudangModel takeTop()
        {
            if (cekRows() == false)
            {
                return null;
            }
            else
            {
                order = 0;
                return showByOrder(order);
            }
        }

        public TransferGudangModel takeBot()
        {
            if (cekRows() == false)
            {
                return null;
            }
            else
            {
                order = takeLimit();
                return showByOrder(order);
            }
        }

        public int limitRow()
        {
            int limit = 0;
            using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM report_transferGudang", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        order = Convert.ToInt32(rd["COUNT(*)"].ToString());
                        limit = order;
                    }
                }
            }
            return limit;
        }

        internal void deleteData(string select, string nomerTrans)
        {
            using (var cmd = new MySqlCommand($"DELETE FROM histori_transfergudang where nomerTrans = '{nomerTrans}' AND barcode = '{select}'", op.Conn))
            {
                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
        }
            
        public DataTable GetListTransfer()
        {
            var dt = new DataTable();
            using (var cmd = new MySqlCommand("Select * from report_transferGudang", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        dt.Load(rd);
                    }
                    else
                    {
                        dt = null;
                    }
                }
            }
            return dt;
        }

        internal List<TransferGudangModel> RefreshData(object text)
        {
            var listf = new List<TransferGudangModel>();

            using (var cmd = new MySqlCommand($"SELECT * FROM histori_transfergudang WHERE nomerTrans = '{text}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var tf = new TransferGudangModel();
                        tf.kode_barang = rd["barcode"].ToString();
                        tf.name = rd["name"].ToString();
                        tf.stok = Convert.ToInt32(rd["stok"].ToString());
                        tf.merek_barang = rd["merk"].ToString();
                        tf.harga = rd["harga"].ToString();
                        tf.harga_pokok = rd["harga_pokok"].ToString();
                        tf.harga_grosir = rd["harga_grosir"].ToString();
                        tf.harga_jual = rd["harga_jual"].ToString();
                        listf.Add(tf);
                    }
                }
            }

            return listf;
        }

        public List<TfGudangAPI> GetData(userDataModel model, string tanggal)
        {
            List<TfGudangAPI> listmodel = new List<TfGudangAPI>();
            using (var client = new RestClient($"{op.url}"))
            {
                var rs = new RestRequest("barang", Method.Get);
                rs.AddParameter("token", model.token);
                rs.AddParameter("uuid", model.uuid);
                rs.AddParameter("tanggal", tanggal);

                var response = client.Execute(rs);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var jso = response.Content.ToString();
                    List<TfGudangAPI> fn = JsonConvert.DeserializeObject<List<TfGudangAPI>>(jso);

                    listmodel = fn;
                }
                else
                {
                    mb.PeringatanOK(response.StatusCode.ToString());
                }
            }

            return listmodel;
        }

        public void hapusKiriman(userDataModel user, string nomerTrans)
        {
            if (mb.PeringatanYesNo("Hapus semua data dikirim dari gudang?") == true)
            {
                deleteRecent(user, nomerTrans);
            }
        }

        public DataTable simpanSementara(List<TransferGudangModel> listmodel, string nomerTrans)
        {
            var dt = new DataTable();

            op.KonekDB();
            foreach (var item in listmodel)
            {
                bool Exist = false;
                int stokAwal = 0;
                int total = 0;
                using (var cmd = new MySqlCommand($"SELECT * FROM barangs where kode_barang = '{item.kode_barang}'", op.Conn))
                {
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if (rd.HasRows)
                        {
                            Exist = true;
                            stokAwal = Convert.ToInt32(rd["stok"].ToString());
                        }
                    }
                }
                //jika barang dengan barcode tersebut ada
                if (Exist == true)
                {
                    total = stokAwal + item.stok;
                }
                //Jika tidak ada insert barang baru
                else
                {
                    total = item.stok;
                }
                CekAvail(item, nomerTrans, "", total);
            }

            using (var cmd = new MySqlCommand($"select * from histori_transfergudang where nomerTrans = '{nomerTrans}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    if(rd.Read())
                    {
                        dt.Load(rd);
                    }
                }
            }

            return dt;
        }

        public void CekAvail(TransferGudangModel item, string nomerTrans, string keterangan,int total)
        {
            op.KonekDB();
            bool ada1 = false;
            bool ada2 = false;
            string keteranganFinal = (keterangan != "") ? keterangan : "Tidak ada Keterangan";
            using (var cmd = new MySqlCommand($"SELECT * FROM histori_transfergudang WHERE nomerTrans='{nomerTrans}' AND barcode='{item.kode_barang}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (!rd.HasRows)
                    {
                        ada1 = true;
                    }
                }
            }
            if (ada1 == true)
            {
                using (var cmd = new MySqlCommand($"" +
                    $"INSERT INTO histori_transfergudang VALUES (null,MD5(RAND()),'{nomerTrans}','{item.category_id}'," +
                    $"'{item.id_supplier}','{item.kode_barang}','{item.harga}','{item.harga_jual}'," +
                    $"'{item.harga_pokok}','{item.harga_grosir}',{item.stok},'{item.keterangan}'," +
                    $"'{item.name}','{item.merek_barang}','{item.type_barang_id}'," +
                    $"'{DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}'," +
                    $"'{DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}')", op.Conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            using (var cmd = new MySqlCommand($"SELECT * FROM report_transfergudang WHERE id_transfer='{nomerTrans}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (!rd.HasRows)
                    {
                        ada2 = true;
                    }
                }
            }
            if (ada2 == true)
            {
                using (var cmd = new MySqlCommand($"INSERT INTO report_transfergudang VALUES (null,md5(rand()),'{nomerTrans}','{keteranganFinal}','void','{op.myDatetime}','{op.myDatetime}')", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void masukanItem(string nomerTrans)
        {
            op.KonekDB();
            List<TransferGudangModel> listmodel = new List<TransferGudangModel>();

            using (var cmd = new MySqlCommand($"SELECT * FROM histori_transfergudang where nomerTrans = '{nomerTrans}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var tf = new TransferGudangModel();
                        tf.kode_barang = rd["barcode"].ToString().Trim();
                        tf.name = rd["name"].ToString();
                        tf.stok = Convert.ToInt32(rd["stok"].ToString());
                        tf.merek_barang = rd["merk"].ToString();
                        tf.harga = rd["harga_pokok"].ToString();
                        tf.harga_pokok = rd["harga_pokok"].ToString();
                        tf.harga_grosir = rd["harga_jual"].ToString();
                        tf.harga_jual = rd["harga_jual"].ToString();
                        listmodel.Add(tf);
                    }
                }
            }

            foreach (var item in listmodel)
            {
                bool Exist = false;
                int stokAwal = 0;
                int total = 0;
                using (var cmd = new MySqlCommand($"SELECT * FROM barangs where kode_barang = '{item.kode_barang}'", op.Conn))
                {
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if (rd.HasRows)
                        {
                            Exist = true;
                            stokAwal = Convert.ToInt32(rd["stok"].ToString());
                        }
                    }
                }

                //jika barang dengan barcode tersebut ada
                if (Exist == true)
                {   
                    total = stokAwal + item.stok;
                    using (var cmd = new MySqlCommand($"UPDATE barangs SET stok = '{total.ToString()}', harga_grosir = '{item.harga_jual}', harga_jual = '{item.harga_jual}', harga = '{item.harga_pokok}', harga_pokok = '{item.harga_pokok}' where kode_barang = '{item.kode_barang}'", op.Conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                //Jika tidak ada insert barang baru
                else
                {
                    using (var cmd = new MySqlCommand($"" +
                        $"INSERT INTO barangs VALUES (null,MD5(RAND()),'{takeCategory(item.kode_barang.Trim())}'," +
                        $"'{item.id_supplier}','{item.kode_barang.Trim()}','{item.harga_pokok}','{item.harga_jual}'," +
                        $"'{item.harga_pokok}','{item.harga_jual}',{item.stok},'{item.keterangan}'," +
                        $"'{item.name}','{item.merek_barang}','PCS', 0,'{DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}'," +
                        $"'{DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}')", op.Conn))
                    {
                        cmd.ExecuteNonQuery();
                        total = item.stok;
                    }
                }

                var mdb = new HistoriStokModel();
                mdb.Barcode = item.kode_barang;
                mdb.NomerTrans = nomerTrans;
                mdb.Masuk = item.stok.ToString();
                mdb.Diskon = "0";
                mdb.Keluar = "0";
                mdb.Saldo = total.ToString();
                mdb.Aktifitas = "TrnfrGudang";
                op.masukHistoriBarangs(mdb);
            }
        }

        public void masukanLaporan(string nomerTrans, string keterangan, userDataModel user)
        {
            bool ada1 = false;
            bool ada2 = false;
            List<TransferGudangModel> listtrans = new List<TransferGudangModel>();
            string keteranganFinal = (keterangan != "") ? keterangan : "Tidak ada Keterangan";

            op.KonekDB();
            foreach (var item in listtrans)
            {
                using (var cmd = new MySqlCommand($"SELECT * FROM histori_transfergudang WHERE nomerTrans='{nomerTrans}' AND barcode='{item.kode_barang}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if (!rd.HasRows)
                        {
                            ada1 = true;
                        }
                    }
                }
                if (ada1 == true)
                {

                    //using (var cmd = new MySqlCommand($"" +
                    //    $"INSERT INTO histori_transfergudang VALUES (null,MD5(RAND()),'{nomerTrans}','{item.category_id}'," +
                    //        $"'{item.id_supplier}','{item.kode_barang}','{item.harga}','{item.harga_jual}'," +
                    //        $"'{item.harga_pokok}','{item.harga_grosir}',{item.stok},'{item.keterangan}'," +
                    //        $"'{item.name}','{item.merek_barang}','{item.type_barang_id}'," +
                    //        $"'{DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}'," +
                    //        $"'{DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}')", op.Conn))
                    //{
                    //    cmd.ExecuteNonQuery();
                    //}
                }
            }
            using (var cmd = new MySqlCommand($"SELECT * FROM report_transfergudang WHERE id_transfer='{nomerTrans}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        ada2 = true;
                    }
                }
            }
            if (ada2 == true)
            {
                using (var cmd = new MySqlCommand($"UPDATE report_transfergudang SET keterangan='{keteranganFinal}', status='posted', updated_at='{op.myDatetime}' WHERE id_transfer='{nomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                }
            }
            updateNumbering();
            deleteRecent(user, nomerTrans);
        }

        private void deleteRecent(userDataModel user, string nomerTrans)
        {
            var listData = new List<TransferGudangModel>();

            using (var cmd = new MySqlCommand($"SELECT * FROM histori_transfergudang where nomerTrans='{nomerTrans}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var model = new TransferGudangModel();

                        model.kode_barang = rd["barcode"].ToString();
                        model.uuid = rd["uuid"].ToString();

                        listData.Add(model);
                    }
                }
            }

            using (var client = new RestClient(op.url))
            {
                var req = new RestRequest("deletetransaction", Method.Post);
                var body = new
                {
                    token = user.token,
                    uuid = user.uuid,
                    data = listData,
                };

                var jso = JsonConvert.SerializeObject(body);

                req.AddJsonBody(jso);

                var response = client.Execute(req);
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        mb.InformasiOK("Success");
                    }
                    else
                    {
                        mb.PeringatanOK("Terjadi Kesalahan saat memperbarui data inventori" + response.Content.ToString());
                    }
                }
                catch (Exception ex)
                {
                    mb.PeringatanOK(ex.Message);
                }
            }


            //if (nomerTrans != "")
            //{
            //    using (var cmd = new MySqlCommand($"DELETE FROM histori_transfergudang where nomerTrans = '{nomerTrans}'", op.Conn))
            //    {
            //        op.KonekDB();
            //        cmd.ExecuteNonQuery();
            //        op.KonekDB();
            //    }

            //    using (var cmd = new MySqlCommand($"DELETE FROM report_transfergudang where id_transfer = '{nomerTrans}'", op.Conn))
            //    {
            //        op.KonekDB();
            //        cmd.ExecuteNonQuery();
            //        op.KonekDB();
            //    }
            //}
        }

        public string takeCategory(string barcode)
        {
            string letter = barcode.Substring(0, 3);
            string uuid = "";

            //Null Value
            using (var cmd = new MySqlCommand("select * from category_barangs where name = 'Tanpa Kategori' ", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    if(rd.Read())
                    {
                        uuid = rd["uuid"].ToString();
                    }
                }
            }

            //Exist Value
            using (var cmd = new MySqlCommand($"select * from category_barangs where name = '{letter}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        uuid = rd["uuid"].ToString();
                    }
                }
            }

            return uuid;
        }

        public void updateNumbering()
        {
            long nomor = 0;
            using (MySqlCommand cmd = new MySqlCommand("Select PTG from numberingkwitansi", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        nomor = Convert.ToInt64(rd["PTG"]);
                    }
                }
                op.KonekDB();
            }
            long update = nomor + 1;
            using (MySqlCommand cmd = new MySqlCommand("UPDATE numberingkwitansi SET PTG = @value WHERE PTG = @Set", op.Conn))
            {
                cmd.Parameters.AddWithValue("value", update);
                cmd.Parameters.AddWithValue("Set", nomor);

                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
        }

        public void PrintPage(string nomerTrans)
        {
            ReportParameter[] param = new ReportParameter[5];
            string tanggal = "";
            string status = "void";
            string Keterangan = "";
            if (nomerTrans != "")
            {
                using (var cmd = new MySqlCommand($"SELECT * FROM report_transfergudang WHERE id_transfer='{nomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        tanggal = op.convertDate(rd["updated_at"].ToString());
                        status = rd["status"].ToString();
                        Keterangan = rd["keterangan"].ToString();
                    }
                }
                var md = op.CabangConfig();

                if(Keterangan == "")
                {
                    Keterangan = "Tidak Ada Keterangan";
                }

                param[0] = new ReportParameter("Tanggal", tanggal);
                param[1] = new ReportParameter("Status", status);
                param[2] = new ReportParameter("Keterangan", Keterangan);
                param[3] = new ReportParameter("Cabang", md.Nama);
                param[4] = new ReportParameter("Alamat", md.Alamat);

                var dt = new DataTable();
                using (var cmd = new MySqlCommand($"SELECT * FROM histori_transfergudang WHERE nomerTrans='{nomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        dt.Load(rd);
                    }
                }

                var src = new ReportDataSource("TfGudang", dt);

                var report = new PrintReport();
                report.LoadReport(op.pathReport("TransferGudang.rdlc"), src, param);
            }
        }
    }
}
