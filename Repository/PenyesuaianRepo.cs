using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KasirApp.Model;
using KasirApp.Report;
using KasirApp.GUI;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace KasirApp.Repository
{
    class PenyesuaianRepo
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        int _order;

        public PenyesuaianRepo()
        {

        }


        public bool cekRows()
        {
            using (var cmd = new MySqlCommand("SELECT * FROM report_penyesuaian",op.Conn))
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
            using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM report_penyesuaian", op.Conn))
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

        public PenyesuaianModel showByOrder(int urutan)
        {
            var md = new PenyesuaianModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM report_penyesuaian LIMIT {urutan},1",op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        md.nomerTrans = rd["id_penyesuaian"].ToString();
                        md.keterangan = rd["keterangan"].ToString();
                        md.status = Convert.ToInt32(rd["status"].ToString());
                    }
                }
            }
            return md;
        }

        internal string getStok(string nama)
        {
            string kode = "";
            using (var cmd = new MySqlCommand($"SELECT * FROM barangs WHERE name = '{nama}' OR kode_barang = '{nama}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if(rd.HasRows)
                    {
                        kode = rd["stok"].ToString();
                    }
                }
            }
            return kode;
        }

        public PenyesuaianModel takeBot()
        {
            if (cekRows() == false)
            {
                return null;
            }
            else
            {
                _order = takeLimit();
                return showByOrder(_order);
            }
        }

        public PenyesuaianModel takeTop()
        {
            if (cekRows() == false)
            {
                return null;
            }
            else
            {
                _order = 0;
                return showByOrder(_order);
            }
        }

        public PenyesuaianModel takePrev()
        {
            if (cekRows() == false)
            {
                return null;
            }
            else
            {
                if (_order <= 0)
                {
                    _order = 0;
                    return showByOrder(_order);
                }
                else
                {
                    _order--;
                    return showByOrder(_order);
                }
            }
        }

        public PenyesuaianModel takeNext()
        {
            if (cekRows() == false)
            {
                return null;
            }
            else
            {
                if (_order >= takeLimit())
                {
                    _order = takeLimit();
                    return showByOrder(_order);
                }
                else
                {
                    _order++;
                    return showByOrder(_order);
                }
            }
        }

        public void deleteData(PenyesuaianModel model)
        {
            if (mb.PeringatanYesNo("Yakin Hapus Data?") == true)
            {
                using (var cmd = new MySqlCommand($"DELETE FROM penyesuaianstok WHERE nomerTrans='{model.nomerTrans}'",op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();  
                    op.KonekDB();
                }
                using (var cmd2 = new MySqlCommand($"DELETE FROM report_penyesuaian WHERE id_penyesuaian='{model.nomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd2.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
        }

        public void PrintPagePenyesuaian(PenyesuaianModel model)
        {
            if (model.nomerTrans == "" || model.nomerTrans == null)
            {
                mb.PeringatanOK("Tidak ada Data untuk di Print");
            }
            else
            {
                string tanggal = "";
                string keterangan = "";
                string status = "Void";
                string nomerTrans = "";

                //ambil Data
                using (var cmd = new MySqlCommand($"SELECT * FROM report_penyesuaian WHERE id_penyesuaian='{model.nomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if (rd.HasRows)
                        {
                            tanggal = op.convertDate(rd["created_at"].ToString());
                            keterangan = rd["keterangan"].ToString();
                            if (rd["status"].ToString() == "1")
                            {
                                status = "Posted";
                            }
                            nomerTrans = rd["id_penyesuaian"].ToString();
                        }
                    }
                }

                var param = new ReportParameter[4];
                param[0] = new ReportParameter("Tanggal", tanggal);
                param[1] = new ReportParameter("Keterangan", keterangan);
                param[2] = new ReportParameter("Status", status);
                param[3] = new ReportParameter("NomerTrans", nomerTrans);

                var dt = new DataTable();
                using (var cmd = new MySqlCommand("SELECT * FROM view_report_penyesuaian WHERE nomerTrans='" + model.nomerTrans + "'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        dt.Load(rd);
                    }
                }

                var da = new MySqlDataAdapter("SELECT * FROM view_report_penyesuaian WHERE nomerTrans='" + model.nomerTrans + "'", op.Conn);
                var ds = new DsKasir();
                da.Fill(ds, "Dt_Penyesuaian");
                //var rds = new ReportDataSource("Penyesuaian", ds.Tables[0]);
                var rds = new ReportDataSource("Penyesuaian", dt);

                var frm = new PrintReport();
                frm.LoadReport(op.pathReport("ReportPenyesuaian.rdlc"), rds, param);
            }
        }

        public void tampilList()
        {

        }

        public long takeNumber()
        {
            long nomor = 0;
            using (MySqlCommand cmd = new MySqlCommand("select PAD from numberingkwitansi", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        nomor = Convert.ToInt64(rd["PAD"].ToString());
                    }
                }
                op.KonekDB();
            }
            return nomor;
        }

        public DataTable reDGV(string nomerTrans)
        {
            var dt = new DataTable();
            using (var cmd = new MySqlCommand($"SELECT barcode,nama,sat,stok,harga_jual FROM penyesuaianstok WHERE nomerTrans = '{nomerTrans}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    dt.Load(rd);
                }
            }
            return dt;
        }

        public PenyesuaianModel PickHeader(string nomerTrans)
        {
            var md = new PenyesuaianModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM report_penyesuaian where id_penyesuaian= '{nomerTrans}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        md.nomerTrans = rd["id_penyesuaian"].ToString();
                        md.status = Convert.ToInt32(rd["status"].ToString());
                        md.keterangan = rd["keterangan"].ToString();
                    }
                    else
                    {
                        md = null;
                    }
                }
            }
            return md;
        }

        public void addPenyesuaian(PenyesuaianModel model)
        {
            var md = new PenyesuaianModel();
            //ambil value
            using (var cmd = new MySqlCommand($"SELECT * FROM barangs WHERE name='{model.nama}' OR kode_barang='{model.nama}' ", op.Conn))
            {
                op.KonekDB();
                using(var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    md.barcode = rd["kode_barang"].ToString();
                    md.nama = rd["name"].ToString();
                    md.sat = rd["satuan"].ToString();
                    int selisih = Convert.ToInt32(model.stoknew) - Convert.ToInt32(rd["stok"].ToString());
                    md.selisih = selisih.ToString();
                    md.stok = model.stok;
                    md.harga_jual = rd["harga_jual"].ToString();
                }
            }

            //Cek Apakah sudah Ada
            using (var cmd = new MySqlCommand($"SELECT * FROM penyesuaianstok WHERE barcode='{md.barcode}' AND nomerTrans='{model.nomerTrans}' ", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        using (var cmd1 = new MySqlCommand($"UPDATE penyesuaianstok SET stok ='{model.stoknew}' WHERE barcode='{md.barcode}' AND nomerTrans='{model.nomerTrans}'", op.Conn1))
                        {
                            op.Conn1.Open();
                            cmd1.ExecuteNonQuery();
                            op.Conn1.Close();
                        }
                    }
                    else
                    {
                        //Masukan Value Baru
                        using (var cmd2 = new MySqlCommand($"" +
                            $"INSERT INTO penyesuaianstok VALUES (null,MD5(RAND()),'{model.nomerTrans}'," +
                            $"'{md.barcode}','{md.nama}','{md.sat}','{md.selisih}','{model.stoknew}'," +
                            $"'{md.harga_jual}','0','{DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}','{DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}')", op.Conn1))
                        {
                            op.Conn1.Open();
                            cmd2.ExecuteNonQuery();
                            op.Conn1.Close();
                        }
                    }
                }
                addReport(model);
            }
        }

        public void addReport(PenyesuaianModel model)
        {
            using (var cmd = new MySqlCommand($"SELECT * FROM report_penyesuaian where id_penyesuaian = '{model.nomerTrans}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (!rd.HasRows)
                    {
                        using (var cmd1 = new MySqlCommand($"INSERT INTO report_penyesuaian VALUES (null,MD5(RAND()),'{model.nomerTrans}','0','{model.keterangan}','{DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}','{DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}')", op.Conn1))
                        {
                            op.Conn1.Open();
                            cmd1.ExecuteNonQuery();
                            op.Conn1.Close();
                        }
                    }
                    else if (rd.HasRows && model.status == 1)
                    {
                        using (var cmd1 = new MySqlCommand($"UPDATE report_penyesuaian SET status='1', updated_at='{op.myDatetime}' WHERE id_penyesuaian='{model.nomerTrans}'", op.Conn1))
                        {
                            op.Conn1.Open();
                            cmd1.ExecuteNonQuery();
                            op.Conn1.Close();
                        }
                    }
                }
            }
        }

        public bool simpanStok(PenyesuaianModel model)
        {
            bool status = false;
            var listBarang = new List<PenyesuaianModel>();
            string masuk = "0";
            string keluar = "0";
            int total = 0;
            if (mb.PeringatanYesNo("Yakin Untuk Menyimpan?") == true)
            {
                if (checkIfNull(model) == true)
                {
                    using (var cmd = new MySqlCommand($"SELECT * FROM penyesuaianstok WHERE nomerTrans='{model.nomerTrans}'", op.Conn))
                    {
                        op.KonekDB();
                        using (var rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                var md = new PenyesuaianModel();
                                md.barcode = rd["barcode"].ToString();
                                md.stok = rd["stok"].ToString();
                                md.nomerTrans = model.nomerTrans;
                                listBarang.Add(md);
                            }
                        }
                    }
                    foreach (var item in listBarang)
                    {
                        using (var cmd = new MySqlCommand($"UPDATE barangs SET stok='{item.stok}', updated_at='{op.myDatetime}' WHERE kode_barang='{item.barcode}'", op.Conn))
                        {
                            op.KonekDB();
                            cmd.ExecuteNonQuery();
                            op.KonekDB();
                        }

                        var mdb = op.pickBarangsModel(item.barcode);
                            
                        if (Convert.ToInt32(item.stok) < 0)
                        {
                            total = Convert.ToInt32(item.stok) * -1;
                            keluar = total.ToString();
                        }
                        else
                        {
                            masuk = item.stok;
                        }

                        var mdh = new HistoriStokModel();
                        mdh.Barcode = item.barcode;
                        mdh.NomerTrans = item.nomerTrans;
                        mdh.Masuk = masuk;
                        mdh.Keluar = keluar;
                        mdh.Diskon = "0";
                        mdh.Saldo = mdb.Stok;
                        mdh.Aktifitas = "Penyesuaian";
                        
                        op.masukHistoriBarangs(mdh);
                    }
                    addReport(model);
                    incPAD();
                    mb.InformasiOK("Berhasil Simpan Data");
                    status = true;
                }
                else
                {
                    mb.PeringatanOK("Tidak ada Data untuk Disimpan");
                    status = false;
                }
            }
            return status;
        }

        public void incPAD()
        {
            long PAD = 0;
            using (var cmd = new MySqlCommand("SELECT PAD FROM numberingkwitansi ", op.Conn))
            {   
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    PAD = Convert.ToInt64(rd["PAD"].ToString());
                    PAD++;
                }
            }
            using (var cmd = new MySqlCommand($"UPDATE numberingkwitansi SET PAD='{PAD}' WHERE id=1", op.Conn))
            {
                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
        }

        public bool checkIfNull(PenyesuaianModel model)
        {
            bool cek = false;
            using (var cmd = new MySqlCommand($"SELECT * FROM penyesuaianstok WHERE nomerTrans='{model.nomerTrans}'",op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        cek = true;
                    }
                }
            }
            return cek;
        }

        public void deleteRow(string barcode, string nomertrans)
        {
            if (mb.PeringatanYesNo("Yakin Hapus Data?") == true)
            {
                using (var cmd = new MySqlCommand($"DELETE FROM penyesuaianstok WHERE barcode='{barcode}' AND nomerTrans='{nomertrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
        }

        public bool Checks(string barang)
        {
            using (var cmd = new MySqlCommand($"SELECT * FROM barangs WHERE name='{barang}' OR kode_barang='{barang}'", op.Conn))
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
    }
}
