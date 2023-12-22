using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KasirApp.Model;
using System.Data;
using Microsoft.Reporting.WinForms;
using KasirApp.Report;

namespace KasirApp.Repository
{
    class ReturRepo
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        int order;

        public int takeLimit()
        {
            int nomor = 0;
            using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM report_retur_pos", op.Conn))
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

        public ReturModel showByOrder(int urutan)
        {
            var md = new ReturModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM report_retur_pos LIMIT {urutan},1", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        md.NomerTrans = rd["nomerTrans"].ToString();
                        md.Nama = rd["nama"].ToString();
                        md.Barcode = rd["barcode"].ToString();
                        md.Qty = rd["qtyretur"].ToString();
                        md.Harga = rd["harga"].ToString();
                        md.Total = rd["total"].ToString();
                        md.Status = rd["status"].ToString();
                    }
                }
            }
            return md;
        }

        public bool cekRows()
        {
            using (var cmd = new MySqlCommand("SELECT * FROM report_retur_pos", op.Conn))
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

        public ReturModel showData(ReturModel model)
        {
            var md = new ReturModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM report_retur_pos WHERE nomerTrans='{model.NomerTrans}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        md.NomerTrans = rd["nomerTrans"].ToString();
                        md.Nama = rd["nama"].ToString();
                        md.Barcode = rd["barcode"].ToString();
                        md.Qty = rd["qtyretur"].ToString();
                        md.Harga = rd["harga"].ToString();
                        md.Total = rd["total"].ToString();
                        md.Status = rd["status"].ToString();
                    }
                }
            }
            return md;
        }

        public List<ReturModel> ListBarangs(ReturModel model)
        {
            var listmodel = new List<ReturModel>();
            if (model.NomerTrans == "")
            {
                mb.PeringatanOK("Masukan Nomer Struk");
            }
            else
            {
                using (var cmd = new MySqlCommand($"SELECT * FROM histori_penjualan WHERE nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                          var md = new ReturModel();
                            md.Barcode = rd["barcode"].ToString();
                            md.Nama = rd["nama"].ToString();
                            listmodel.Add(md);
                        }
                        if (listmodel.Count == 0)
                        {
                            mb.PeringatanOK("Struk Tidak Ditemukan");
                        }
                    }
                }
            }
            return listmodel; 
        }

        public ReturModel takeDetail(ReturModel model)
        {
            var md = new ReturModel();
            if (model.NomerTrans == "")
            {
                mb.PeringatanOK("Masukan Nomer Struk");
            }
            else
            {
                using (var cmd = new MySqlCommand($"SELECT * FROM histori_penjualan WHERE nomerTrans='{model.NomerTrans}' AND nama='{model.Nama}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if (rd.HasRows)
                        {
                            md.Nama = rd["nama"].ToString();
                            md.Barcode = rd["barcode"].ToString();
                            md.Qty = rd["quantity"].ToString();
                            md.Harga = rd["harga_jual"].ToString();
                        }
                    }
                }
            }
            return md;  
        }

        public bool saveRetur(ReturModel model)
        {
            string qtysebelum = "";
            bool state = false;
            if (model.NomerTrans == "" || model.Barcode == "" || model.Total == "")
            {
                mb.PeringatanOK("Tolong Lengkapi Data");
                state = false;
            }
            else if (Convert.ToInt32(model.Qty) > Convert.ToInt32(model.Maxqty))
            {
                mb.PeringatanOK("Qty retur melebihi Qty dalam Struk");
            }
            else
            {
                if (mb.PeringatanYesNo("Lakukan Retur?")==true)
                {
                    string qtydalamstruk = "";
                    string hargabrg = "";
                    string totalbrg = "";
                    //Ambil data quantitas
                    using (var cmd = new MySqlCommand($"SELECT * FROM barangs WHERE kode_barang='{model.Barcode}'", op.Conn))
                    {
                        op.KonekDB();
                        using (var rd = cmd.ExecuteReader())
                        {
                            rd.Read();
                            qtysebelum = rd["stok"].ToString();
                        }
                    }
                    //Ambil data dari Struk
                    using (var cmd = new MySqlCommand($"SELECT * FROM histori_penjualan WHERE nomerTrans='{model.NomerTrans}' AND barcode='{model.Barcode}'", op.Conn))
                    {
                        op.KonekDB();
                        using (var rd = cmd.ExecuteReader())
                        {
                            rd.Read();
                            model.Idkategori = rd["id_category"].ToString();
                            model.Harga = rd["harga_jual"].ToString();
                            qtydalamstruk = rd["quantity"].ToString();
                            hargabrg = rd["harga_jual"].ToString();
                            totalbrg = rd["total"].ToString();
                        }
                    }
                    //Total Perubahan Quantitas
                    int total = Convert.ToInt32(qtysebelum) + Convert.ToInt32(model.Qty);   

                    //Masukan ke Laporan Retur
                    using (var cmd = new MySqlCommand($"" +
                    $"INSERT INTO report_retur_pos VALUES(null,MD5(RAND()), '{model.Idkategori}','{model.NomerTrans}'," +
                    $"'{model.Nama}','{model.Barcode}','{model.Qty}','{qtydalamstruk}','{total}','{model.Harga}'," +
                    $"'{model.Total}','posted','{op.myDatetime}','{op.myDatetime}')", op.Conn))
                    {
                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                    }

                    //update quantitas barangs
                    using (var cmd = new MySqlCommand($"UPDATE barangs SET stok='{total.ToString()}', updated_at='{op.myDatetime}' WHERE kode_barang='{model.Barcode}'", op.Conn))
                    {
                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                    }

                    //Edit atau Hapus dari histori transaksi
                    int totalqty = Convert.ToInt32(qtydalamstruk) - Convert.ToInt32(model.Qty); 
                    if (totalqty != 0)
                    {
                        int totalsmua = totalqty * Convert.ToInt32(hargabrg);
                        using (var cmd = new MySqlCommand($"UPDATE histori_penjualan SET quantity='{totalqty}', total='{totalsmua}' WHERE nomerTrans='{model.NomerTrans}' AND barcode='{model.Barcode}'", op.Conn))
                        {
                            op.KonekDB();
                            cmd.ExecuteNonQuery();
                            op.KonekDB();
                        }
                    }
                    else if (totalqty == 0)
                    {
                        using (var cmd = new MySqlCommand($"DELETE FROM histori_penjualan WHERE nomerTrans='{model.NomerTrans}' AND barcode='{model.Barcode}'", op.Conn))
                        {
                            op.KonekDB();
                            cmd.ExecuteNonQuery();
                            op.KonekDB();
                        }
                    }

                    //Masukan Histori Stok
                    var mdh = new HistoriStokModel();
                    mdh.Barcode = model.Barcode;
                    mdh.NomerTrans = model.NomerTrans;
                    mdh.Masuk = model.Qty;
                    mdh.Keluar = "0";
                    mdh.Diskon = "0";
                    mdh.Saldo = total.ToString();
                    mdh.Aktifitas = "Retur POS";

                    op.masukHistoriBarangs(mdh);

                    mb.InformasiOK("Retur Sukses");

                    state = true;
                }
            }
            return state;
        }

        public ReturModel takeBot()
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
 
        public ReturModel takeTop() {
            if (cekRows()==false)
            {
                return null;
            }
            else
            {
                order = 0;
                return showByOrder(order);
            }
        }
        public ReturModel takeNext() {
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
        public ReturModel takePrev() 
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

        public void printPage(ReturModel model)
        {
            if (model.NomerTrans == "")
            {
                mb.PeringatanOK("Tidak ada Data untuk di Print");
            }
            else
            {
                string tanggal = "";
                string status = "Void";

                //ambil Data
                using (var cmd = new MySqlCommand($"SELECT * FROM report_retur_pos WHERE nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        tanggal = op.convertDate(rd["created_at"].ToString());
                        status = rd["status"].ToString();
                    }
                }

                var param = new ReportParameter[4];
                param[0] = new ReportParameter("Tanggal", tanggal);
                param[1] = new ReportParameter("Status", status);

                var mds = op.CabangConfig();
                param[2] = new ReportParameter("Cabang", mds.Nama);
                param[3] = new ReportParameter("Alamat", mds.Alamat);

                var dt = new DataTable();
                using (var cmd = new MySqlCommand("SELECT * FROM report_retur_pos WHERE nomerTrans='" + model.NomerTrans + "'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        dt.Load(rd);
                    }
                }
                
                var rds = new ReportDataSource("Retur", dt);

                var frm = new PrintReport();
                frm.LoadReport(op.pathReport("ReturReport.rdlc"), rds, param);
            }
        }
    }
}
