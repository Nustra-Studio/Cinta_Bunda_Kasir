using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data; 

namespace KasirApp.Model
{
    public class Koneksi1
    {
        public MySqlConnection Conn = new MySqlConnection("server=localhost;user id=root;password=admin;port=3307;database=kasirdb");
        public string url = "https://inventory.nustrastudio.com/api/";
        //MySqlDataReader rd;
        //MySqlDataAdapter da;
    }

    public class Operator
    {
        public MySqlConnection Conn = new MySqlConnection("server=localhost;user id=root;password=admin;port=3307;database=kasirdb");
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
