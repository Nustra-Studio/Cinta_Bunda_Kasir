using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KasirApp.Model;
using KasirApp.Report;
using System.Data;
using Microsoft.Reporting.WinForms;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Office.Interop.Excel;

namespace KasirApp.Repository
{
    public class OpnameRepo
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();

        //Constructor
        public OpnameRepo()
        {

        }

        //MySql Method
        public OpnameModel getNumber()
        {
            var model = new OpnameModel();
            using (MySqlCommand cmd = new MySqlCommand("select POP from numberingkwitansi",op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        model.NumeringKwitansi = Convert.ToInt64(rd["POP"].ToString());
                    }
                }
                op.KonekDB();
            }
            return model;
        }

        //CRUD Method
        public void masukanOpname(OpnameModel model, userDataModel user)
        {
            using (var cmd = new MySqlCommand($"SELECT * FROM barangs WHERE kode_barang='{model.Barcode}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    model.Uuid = rd["uuid"].ToString();
                }
            }

            bool isExist = false;

            using (var cmd = new MySqlCommand($"SELECT * FROM opnames WHERE nomerTrans = '{model.Nomor}' AND Barcode = '{model.Barcode}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        isExist = true;
                    }
                }
            }

            if (isExist == true)
            {
                using (var cmd = new MySqlCommand($"UPDATE opnames SET Perubahan = '{model.Perubahan}', Selisih = '{model.Selisih}' WHERE nomerTrans='{model.Nomor}' AND Barcode = '{model.Barcode}' ", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
            else
            {
                //Save ke table
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO opnames VALUES(null,md5(RAND()),@nomer,@nama,@barcode,@stok,@perubahan,@selisih,@posted,@tanggal)", op.Conn))
                {
                    cmd.Parameters.AddWithValue("nomer", model.Nomor);
                    cmd.Parameters.AddWithValue("nama", model.Nama);
                    cmd.Parameters.AddWithValue("barcode", model.Barcode);
                    cmd.Parameters.AddWithValue("stok", model.Stok);
                    cmd.Parameters.AddWithValue("perubahan", model.Perubahan);
                    cmd.Parameters.AddWithValue("selisih", model.Selisih);
                    cmd.Parameters.AddWithValue("posted", model.Posted);
                    cmd.Parameters.AddWithValue("tanggal", model.Tanggal);

                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
        }

        internal void UploadData(OpnameModel model, userDataModel user)
        {
            bool status = true;
            var listbarang = new List<barangOpname>();
            using (var cmd = new MySqlCommand($"SELECT uuid,kode_barang,stok FROM barangs", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    NotifyIcon notify1 = new NotifyIcon();
                    notify1.BalloonTipText = "Sedang Upload Data";
                    notify1.BalloonTipTitle = "Proses Upload";
                    notify1.Icon = SystemIcons.Information;
                    notify1.Visible = true;
                    notify1.ShowBalloonTip(100);

                    while (rd.Read())
                    {
                        var brg = new barangOpname();
                        brg.barcode = rd["kode_barang"].ToString();
                        brg.stok = rd["stok"].ToString();
                        brg.uuid = rd["uuid"].ToString();
                        listbarang.Add(brg);
                    }

                    try
                    {
                        foreach (var item in listbarang)
                        {
                            using (var client = new RestClient($"{op.url}opname/"))
                            {
                                var body = new
                                {
                                    token = user.token,
                                    id_toko = user.cabang_id,
                                    data = new
                                    {
                                        barcode = item.barcode,
                                        stock = item.stok,
                                        uuid = item.uuid
                                    }
                                };

                                var req = new RestRequest("push", Method.Post);
                                req.AddJsonBody(body);

                                var res = client.Execute(req);

                                if (res.StatusCode != HttpStatusCode.OK)
                                {
                                    Console.WriteLine(res.Content.ToString());
                                    mb.PeringatanOK($"Terjadi Kesalahan");
                                    status = false;
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        mb.PeringatanOK($"ERROR! : {ex.ToString()}");
                        status = false;
                    }
                }
            }

            if (status == true)
            {
                mb.InformasiOK("Data ter Upload");
            }
        }

        internal void ExportData()
        {
            var listbarang = new List<barangOpname>();
            using (var cmd = new MySqlCommand("SELECT * FROM barangs", op.Conn))
            {
                cmd.CommandTimeout = 360;
                var col = 1;
                var row = 1;
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    Microsoft.Office.Interop.Excel.Application excelapp = new Microsoft.Office.Interop.Excel.Application();
                    Workbook excelWorkbook = excelapp.Workbooks.Add();
                    Worksheet excelworksheet = excelWorkbook.Worksheets[1];

                    while (rd.Read())
                    {
                        var brg = new barangOpname();
                        brg.barcode = rd["kode_barang"].ToString();
                        brg.stok = rd["stok"].ToString();
                        brg.uuid = rd["uuid"].ToString();
                        listbarang.Add(brg);
                    }

                    //while (rd.Read())
                    //{
                    //    col = 1;
                    //    for (int i = 0; i < rd.FieldCount; i++)
                    //    {
                    //        excelworksheet.Cells[row, col].Value2 = rd[i];
                    //        col++;
                    //    }
                    //    row++;
                    //}

                    foreach (var item in listbarang)
                    {
                        string insert = "";
                        col = 1;
                        for (int i = 0; i < 3; i++)
                        {
                            if (i == 0)
                            {
                                insert = item.uuid;
                            }
                            else if (i == 1)
                            {
                                insert = item.barcode;
                            }
                            else if (i == 2)
                            {
                                insert = item.stok;
                            }
                            excelworksheet.Cells[row, col].Value2 = insert;
                            col++;
                        }
                        row++;
                    }
                    excelworksheet.SaveAs(@"C:\Ussage\Excel.xls");
                    excelWorkbook.Close();
                    excelapp.Quit();
                }
            }
        }

        internal void directInsert(OpnameModel model, userDataModel user)
        {
            var md = new OpnameModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM barangs WHERE kode_barang='{model.Barcode}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        md.Nama = rd["name"].ToString();
                        md.Stok = rd["stok"].ToString();
                        md.Perubahan = rd["stok"].ToString();
                        md.Selisih = "0";
                    }
                }
            }

            bool isExist = false;
            using (var cmd = new MySqlCommand($"SELECT * FROM opnames WHERE nomerTrans = '{model.Nomor}' AND Barcode = '{model.Barcode}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        isExist = true;
                    }
                }
            }

            if (isExist == false)
            {
                using (var cmd = new MySqlCommand($"" +
                $"INSERT INTO opnames VALUES (null,SHA2('{model.Barcode}' , 256), '{model.Nomor}', '{md.Nama}', '{model.Barcode}', " +
                $"'{md.Stok}', '{md.Perubahan}', '{md.Selisih}', '0', '{op.myDatetime}')", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
        }

        public System.Data.DataTable showtable(OpnameModel model)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (MySqlCommand cmd = new MySqlCommand("select * from view_opname where nomerTrans=@nomor",op.Conn))
            {
                cmd.Parameters.AddWithValue("nomor", model.Nomor);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    if (!rd.HasRows)
                    {
                        dt = null;
                    }
                    else
                    {
                        dt.Load(rd);
                    }
                }
                op.KonekDB();
            }
            return dt;
        }

        public bool Delete(OpnameModel model)
        {
            if (mb.PeringatanYesNo("Yakin Hapus Data?")==true)
            {
                using (var cmd = new MySqlCommand($"DELETE FROM opnames WHERE nomerTrans='{model.Nomor}' AND Barcode='{model.Barcode}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public System.Data.DataTable doSearch(OpnameModel model)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (MySqlCommand cmd = new MySqlCommand($"select * from view_opname where nomerTrans=@nomor AND Nama LIKE '%{model.Nama}%'", op.Conn))
            {
                cmd.Parameters.AddWithValue("nomor", model.Nomor);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    if (!rd.HasRows)
                    {
                        dt = null;
                    }
                    else
                    {
                        dt.Load(rd);
                    }
                }
                op.KonekDB();
            }
            return dt;
        }

        public void printPage(OpnameModel model)
        {
            var dt = new System.Data.DataTable();
            string tanggal = "";
            string status = "Void";
            bool isExist = false;
            using (var cmd = new MySqlCommand($"SELECT * FROM opnames WHERE nomerTrans ='{model.Nomor}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        tanggal = op.convertDate(rd["Created_at"].ToString());
                        if (rd["Posted"].ToString() == "1")
                        {
                            status = "Posted";
                            isExist = true;
                        }
                    }
                }
                using (var rd1 = cmd.ExecuteReader())
                {
                    dt.Load(rd1);
                }
            }

            if (isExist == false)
            {
                mb.PeringatanOK("Tidak ada Data");
            }
            else
            {
                var src = new ReportDataSource("Opname", dt);

                var set = op.CabangConfig();
                var param = new ReportParameter[4];
                param[0] = new ReportParameter("Cabang", set.Nama);
                param[1] = new ReportParameter("Alamat", set.Alamat);
                param[2] = new ReportParameter("Tanggal", tanggal);
                param[3] = new ReportParameter("Status", status);

                var report = new PrintReport();
                report.LoadReport(op.pathReport("Opname.rdlc"), src, param);
            }
        }

        public bool Cek(OpnameModel model)
        {
            bool periksa = false;
            using (MySqlCommand cmd = new MySqlCommand($"select * from view_barang where Barcode = '{model.Barcode}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        periksa = true;
                    }
                    else
                    {
                        periksa = false;
                    }
                }
            }
            return periksa;
        }

        public bool SyncData(OpnameModel model, userDataModel user)
        {
            var status = false;
            var statusstring = "";
            try
            {
                using (var client = new RestClient($"{op.url}opname"))
                {
                    var rs = new RestRequest("get", Method.Get);
                    rs.AddParameter("token", user.token);
                    rs.AddParameter("uuid", user.cabang_id);

                    var res = client.Execute(rs);

                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        status = true;
                        var jso = res.Content.ToString();
                        statusstring = jso;

                        if (statusstring.Length < 50)
                        {
                            mb.InformasiOK("Tidak ada Data untuk Sinkronize");
                        }
                        else if (jso == "")
                        {
                            mb.PeringatanOK("Tidak ada Data untuk Sinkronize");
                            status = false;
                        }
                        else if (model.Nomor == "")
                        {
                            mb.PeringatanOK("Masukan Nomer Transaksi terlebih dahulu");
                        }
                        else
                        {
                            var opnameget = JsonConvert.DeserializeObject<getOpname>(res.Content.ToString());
                            var oplist = opnameget.data;
                            foreach (var item in oplist)
                            {
                                bool isExist = false;
                                using (var cmd = new MySqlCommand($"SELECT * FROM opnames WHERE Barcode='{item.barcode}' AND nomerTrans='{model.Nomor}'", op.Conn))
                                {
                                    op.KonekDB();
                                    using (var rd = cmd.ExecuteReader())
                                    {
                                        rd.Read();
                                        if (rd.HasRows)
                                        {
                                            isExist = true;
                                        }
                                    }
                                }

                                if (isExist == true)
                                {
                                    using (var cmd = new MySqlCommand($"UPDATE opnames SET Perubahan='{item.perubahan}', Created_at = '{op.myDatetime}' WHERE Barcode='{item.barcode}' AND nomerTrans='{model.Nomor}'", op.Conn))
                                    {
                                        op.KonekDB();
                                        cmd.ExecuteNonQuery();
                                        op.KonekDB();
                                    }
                                }
                                else
                                {
                                    int selisih = Convert.ToInt32(item.perubahan) - Convert.ToInt32(item.stock);
                                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO opnames VALUES(null,md5(RAND()),@nomer,@nama,@barcode,@stok,@perubahan,@selisih,@posted,@tanggal)", op.Conn))
                                    {
                                        cmd.Parameters.AddWithValue("nomer", model.Nomor);
                                        cmd.Parameters.AddWithValue("nama", item.barcode);
                                        cmd.Parameters.AddWithValue("barcode", item.barcode);
                                        cmd.Parameters.AddWithValue("stok", item.stock);
                                        cmd.Parameters.AddWithValue("perubahan", item.perubahan);
                                        cmd.Parameters.AddWithValue("selisih", selisih.ToString());
                                        cmd.Parameters.AddWithValue("posted", "0");
                                        cmd.Parameters.AddWithValue("tanggal", op.myDatetime);

                                        op.KonekDB();
                                        cmd.ExecuteNonQuery();
                                        op.KonekDB();
                                    }
                                }
                            }
                            status = true;
                        }
                    }
                    else
                    {
                        status = false;
                        mb.PeringatanOK("Tidak ada data untuk di Sinkron");
                    }
                }
            }
            catch (Exception ex)
            {
                mb.PeringatanOK(ex.Message);
                //mb.PeringatanOK(statusstring);
            }
            return status;
        }
    }

    public class barangOpname
    {
        public string uuid { get; set; }
        public string barcode { get; set; }
        public string stok { get; set; }
    }
}


