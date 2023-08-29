using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data; 

namespace KasirApp.Model
{
    public class Operator
    {
        public string url = "https://inventory.nustrastudio.com/api/";
        public string urlcloud = "https://cloudinventory.nustrastudio.com/api/";
        public MySqlConnection Conn = new MySqlConnection("server=localhost;user id=root;password=123;port=3306;database=kasirdb");
        public MySqlConnection Conn1 = new MySqlConnection("server=localhost;user id=root;password=123;port=3306;database=kasirdb");
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
            if (Conn.State == ConnectionState.Open)
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
                            System.Windows.Forms.MessageBox.Show("while read");
                            string group = rd[kelompok].ToString();
                            System.Windows.Forms.MessageBox.Show(kelompok + id + group);
                            if (group == "" || group == null)
                            {
                                System.Windows.Forms.MessageBox.Show("detect null");
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
