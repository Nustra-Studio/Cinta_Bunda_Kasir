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
            using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM histori_transfergudang", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    nomor = Convert.ToInt32(rd["COUNT(*)"].ToString());
                    if (nomor == 0)
                    {
                        nomor++;
                    }
                }
            }
            nomor--;
            return nomor;
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

        internal DataTable RefreshData(object text)
        {
            DataTable dt = new DataTable();

            using (var cmd = new MySqlCommand($"SELECT * FROM histori_transfergudang WHERE nomerTrans = '{text}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        dt.Load(rd);
                    }
                }
            }

            return dt;
        }

        public List<TfGudangAPI> GetData(userDataModel model)
        {
            List<TfGudangAPI> listmodel = new List<TfGudangAPI>();
            using (var client = new RestClient($"{op.url}"))
            {
                var rs = new RestRequest("barang", Method.Get);
                rs.AddParameter("token", model.token);
                rs.AddParameter("uuid", model.uuid);

                var response = client.Execute(rs);

                System.Windows.Forms.MessageBox.Show(response.Content.ToString());

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

        public void hapusKiriman(userDataModel user)
        {
            if (mb.PeringatanYesNo("Hapus semua data dikirim dari gudang?") == true)
            {
                deleteRecent(user);
            }
        }

        public void simpanSementara(List<TransferGudangModel> listmodel, string nomerTrans)
        {
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
        }

        public void CekAvail(TransferGudangModel item, string nomerTrans, string keterangan,int total)
        {
            op.KonekDB();
            bool ada1 = false;
            bool ada2 = false;
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
                using (var cmd = new MySqlCommand($"INSERT INTO report_transfergudang VALUES (null,md5(rand()),'{nomerTrans}','{keterangan}','void','{op.myDatetime}','{op.myDatetime}')", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void masukanItem(List<TransferGudangModel> listmodel, string nomerTrans)
        {
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
                    using (var cmd = new MySqlCommand($"UPDATE barangs SET stok = '{total.ToString()}' where kode_barang = '{item.kode_barang}'", op.Conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                //Jika tidak ada insert barang baru
                else
                {
                    using (var cmd = new MySqlCommand($"" +
                        $"INSERT INTO barangs VALUES (null,MD5(RAND()),'{item.category_id}'," +
                        $"'{item.id_supplier}','{item.kode_barang}','{item.harga}','{item.harga_jual}'," +
                        $"'{item.harga_pokok}','{item.harga_grosir}',{item.stok},'{item.keterangan}'," +
                        $"'{item.name}','{item.merek_barang}','PCS','{DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}'," +
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

        public void masukanLaporan(List<TransferGudangModel> listtrans, string nomerTrans, string keterangan, userDataModel user)
        {
            bool ada1 = false;
            bool ada2 = false;
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
                using (var cmd = new MySqlCommand($"UPDATE report_transfergudang SET keterangan='{keterangan}', status='posted', updated_at='{op.myDatetime}' WHERE id_transfer='{nomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                }
            }
            updateNumbering();
            deleteRecent(user);
        }

        private void deleteRecent(userDataModel user)
        {
            using (var client = new RestClient(op.url))
            {
                var req = new RestRequest("deletetransaction", Method.Post);
                var body = new
                {
                    token = user.token,
                    uuid = user.uuid
                };
                req.AddJsonBody(body);

                var response = client.Execute(req);
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        mb.InformasiOK("Success");
                    }
                    else
                    {
                        mb.PeringatanOK("Terjadi Kesalahan saat memperbarui data inventori");
                    }
                }
                catch (Exception ex)
                {
                    mb.PeringatanOK(ex.Message);
                }

            }
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
