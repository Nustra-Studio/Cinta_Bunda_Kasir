using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace KasirApp.Model
{
    public class Operator
    {
        //public string url = "https://inventory.nustrastudio.com/api/";

        public string url = "https://inventory.cinta-bunda.com/api/";
        public string urlcinta = "https://inventory.cinta-bunda.com";
        public MySqlConnection Conn = new MySqlConnection("server=localhost;user id=root;password =123;port=3306;database=kasirdb_deploy");
        public MySqlConnection Conn1 = new MySqlConnection("server=localhost;user id=root;password =123;port=3306;database=kasirdb_deploy");
        public string myDatetime = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
        public string simpleDate = DateTime.Now.ToString("dd/MMM/yy");
        
        public void KonekDB()
        {
            if (Conn.State == ConnectionState.Open)
            {
                return;
            }
            else
            {
                Conn.Open();
            }
        }
        
        public void KonekDB1()
        {
            if (Conn1.State == ConnectionState.Open)
            {
                return;
            }
            else
            {
                Conn1.Open();
            }
        }

        public bool CekNetwork()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 5;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void insertHistoriUser(userDataModel user, string form, string aktifitas)
        {
            using (var cmd = new MySqlCommand($"INSERT INTO histori_user VALUES (null,md5(RAND()), '{user.username}', '{form}', '{aktifitas}', '{myDatetime}', '{myDatetime}', '{myDatetime}')", Conn))
            {
                KonekDB();
                cmd.ExecuteNonQuery();
                KonekDB();
            }
        }

        public string pathReport(string filename)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            //string filePath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + $@"\Report\{filename}";
            string filePath = Path.GetDirectoryName(Application.ExecutablePath) + $@"\Report\{filename}";

            return filePath;
        }

        public string pathReportPOS(string filename)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            //string filePath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + $@"\Report\ReportPOS\{filename}";
            string filePath = Path.GetDirectoryName(Application.ExecutablePath) + $@"\Report\ReportPOS\{filename}";

            return filePath;
        }

        //Backup List Struk
        public void masukListStruk(string kelompok, string value)
        {
            bool thresNull = false;
            string id = "";
            string state = "";
            using (var cmd = new MySqlCommand("Select * from list_struk", Conn))
            {
                KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    System.Windows.Forms.MessageBox.Show("Execute");
                    rd.Read();
                    if (!rd.HasRows)
                    {
                        state = "PlaceNew";
                    }
                    else
                    {
                        while (rd.Read())
                        {
                            string group = rd[kelompok].ToString();
                            if (group == "" || group == null)
                            {
                                id = rd["id"].ToString();
                                thresNull = true;
                                break;
                            }
                            else if (group != "" || group != null)
                            {
                                state = "PlaceNew";
                                id = rd["id"].ToString();
                                break;
                            }
                        }
                    }
                }
                if (thresNull == true)
                {
                    using (var cmd1 = new MySqlCommand("Update list_struk SET " + kelompok + " = '" + value + "' where id = " + id + "", Conn))
                    {
                        KonekDB();
                        cmd1.ExecuteNonQuery();
                        KonekDB();
                    }
                }
                else if (state == "PlaceNew")
                {
                    using (var cmd2 = new MySqlCommand($"INSERT INTO list_struk (id,uuid,{kelompok}) VALUES (null,md5(rand()),'{value}')", Conn))
                    {
                        KonekDB();
                        cmd2.ExecuteNonQuery();
                        KonekDB();
                    }
                }
            }
        }

        public BarangsModel pickBarangsModel(string kode)
        {
            var model = new BarangsModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM barangs WHERE kode_barang='{kode}'", Conn))
            {
                KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    model.Nama = rd["name"].ToString();
                    model.Kode = rd["kode_barang"].ToString();
                    model.Harga = rd["harga"].ToString();
                    model.Harga_jual = rd["harga_jual"].ToString();
                    model.Harga_pokok = rd["harga_pokok"].ToString();
                    model.Harga_grosir = rd["harga_grosir"].ToString();
                    model.Stok = rd["stok"].ToString();
                }
            }
            return model;
        }

        public SettingModel CabangConfig()
        {
            var model = new SettingModel();
            using (var cmd = new MySqlCommand("SELECT * FROM settings", Conn))
            {
                KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    model.Nama = rd["nama"].ToString();
                    model.Alamat = rd["alamat"].ToString();
                    model.Telp = rd["telp"].ToString();
                    model.Autodiskon = rd["auto_diskon"].ToString();
                    model.Baris1 = rd["baris1"].ToString();
                    model.Baris2 = rd["baris2"].ToString();
                    model.Baris3 = rd["baris3"].ToString();
                    model.Header = rd["header"].ToString();
                    model.Valuepoint = rd["nilaipoint"].ToString();
                    model.Minimalcash = rd["minimumkupon"].ToString();
                    model.StokMinimum = rd["stokMinimum"].ToString();
                }
            }
            return model;
        }

        public void masukHistoriBarangs(HistoriStokModel model)
        {

            if (model.Diskon == "")
            {
                model.Diskon = "0";
            }
            var md = new BarangsModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM barangs where kode_barang='{model.Barcode}'", Conn))
            {
                KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        md.Nama = rd["name"].ToString();
                        md.Kode = rd["kode_barang"].ToString();
                        md.Harga_jual = rd["harga_jual"].ToString();
                    }
                }
            }
            using (var cmd = new MySqlCommand($"" +
            $"INSERT INTO report_stock_detail VALUES (null,MD5(RAND()),'{md.Nama}'," +
            $"'{model.Barcode}','{model.NomerTrans}','{simpleDate}','{model.Aktifitas}','{model.Diskon}'," +
            $"'{md.Harga_jual}','{model.Masuk}','{model.Keluar}'," +
            $"'{model.Saldo}','{myDatetime}','{myDatetime}')", Conn))
            {
                KonekDB();
                cmd.ExecuteNonQuery();
                KonekDB();
            }
        }

        public void hapusHistoriBarangs(HistoriStokModel model)
        {
            using (var cmd = new MySqlCommand(""))
            {

            }
        }

        public string convertDate(string TimeStamp)
        {
            DateTime dateTime = DateTime.ParseExact(TimeStamp, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            string formattedDate = dateTime.ToString("dd-MMM-yyyy").ToLower(); // Convert to lower case

            return formattedDate;
        }

        public string directconvertDate(string TimeStamp)
        {
            DateTime dateTime = DateTime.ParseExact(TimeStamp, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            string formattedDate = dateTime.ToString("dd-MMM-yyyy").ToLower(); // Convert to lower case

            return formattedDate;
        }

        public string convertDateHours(string TimeStamp)
        {
            DateTime dateTime = DateTime.ParseExact(TimeStamp, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            string formattedDate = dateTime.ToString("HH:mm").ToLower(); // Convert to lower case

            return formattedDate;
        }

        public string directconvertDateHours(string TimeStamp)
        {
            DateTime dateTime = DateTime.ParseExact(TimeStamp, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            string formattedDate = dateTime.ToString("HH:mm:ss").ToLower(); // Convert to lower case

            return formattedDate;
        }

        public DataTable getAll(string table)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from " + table +" ", Conn);
            MySqlDataReader rd;
            DataTable dt = new DataTable();
            KonekDB();
            rd = cmd.ExecuteReader();
            
            dt.Load(rd);
            KonekDB();
            return dt;
        }

        public MySqlDataReader fillcbo(string table)
        {
            MySqlCommand cmd = new MySqlCommand("select * from " + table + "", Conn);
            KonekDB();
            MySqlDataReader rd = cmd.ExecuteReader();

            rd.Read();
            KonekDB();
            return rd;
        }

        public DataTable getByQuery(string query)
        {
            DataTable dt = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand(query,Conn))
            {
                KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    dt.Load(rd);
                    return dt;
                }
            }
        }

        public MySqlDataReader search(string key)
        {
            MySqlCommand cmd = new MySqlCommand("select * from view_barang where Nama='" + key + "'",Conn);
            MySqlDataReader rd;

            KonekDB();
            rd = cmd.ExecuteReader();
            rd.Read();
            KonekDB();
            return rd;
        }
    }
}
