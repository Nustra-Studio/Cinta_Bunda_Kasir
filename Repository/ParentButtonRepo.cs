using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;
using System.Data;

namespace KasirApp.Repository
{
    class ParentButtonRepo
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        int order = 0;
        public ParentButtonRepo()
        {

        }

        public int limitRow(string table)
        {
            int limit = 0;
            using (var cmd = new MySqlCommand($"SELECT COUNT(*) FROM {table}", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        limit = Convert.ToInt32(rd["COUNT(*)"].ToString());
                    }
                }
            }
            return limit - 1;
        }

        public DataTable setView(string table, string nomerTrans)
        {
            DataTable dt = new DataTable();
            using (var cmd = new MySqlCommand($"SELECT * FROM {table} where nomerTrans = '{nomerTrans}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    dt.Load(rd);
                }
            }
            return dt;
        }

        public ParrentButtonModel dataAtas(string reportTable)
        {
            var model = new ParrentButtonModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM {reportTable} limit {order.ToString()},1", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        model.NomerTrans = rd[2].ToString();
                        model.Keterangan = rd[3].ToString();
                        model.Status1 = rd[4].ToString();
                    }
                }
            }
            return model;
        }

        public ParrentButtonModel dataAtasByValue(string reportTable, string identifier, string value)
        {
            var model = new ParrentButtonModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM {reportTable} WHERE {identifier}='{value}' ", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        model.NomerTrans = rd[2].ToString();
                        model.Keterangan = rd[3].ToString();
                        model.Status1 = rd[4].ToString();
                    }
                }
            }
            return model;
        }

        public DataTable dataByValue(string reportTable, string identifier, string value)
        {
            var dt = new DataTable();
            using (var cmd = new MySqlCommand($"SELECT * FROM {reportTable} WHERE {identifier}='{value}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    dt.Load(rd);
                }
            }
            return dt;
        }

        public string topValue(string table)
        {
            string noTrans = "";
            order = 0;
            using (var cmd = new MySqlCommand($"SELECT * FROM {table} limit {order.ToString()},1", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        noTrans = rd[2].ToString();
                    }
                }
            }
            return noTrans;
        }

        public string nextValue(string table)
        {
            int limit = limitRow(table);
            string noTrans = "";
            if (order >= limit)
            {
                order = limit;
            }   
            else
            {
                order++;
            }
            using (var cmd = new MySqlCommand($"SELECT * FROM {table} limit {order},1", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        noTrans = rd[2].ToString();
                    }
                }
            }
            return noTrans;
        }

        public string prevValue(string table)
        {
            int limit = limitRow(table);
            string noTrans = "";
            if (order <= 0)
            {
                order = 0;
            }
            else
            {
                order--;
            }
            using (var cmd = new MySqlCommand($"SELECT * FROM {table} limit {order},1", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        noTrans = rd[2].ToString();
                    }
                }
            }
            return noTrans;
        }

        //report table
        public string botValue(string table)
        {
            int limit = limitRow(table);
            order = limit;
            string noTrans = "";
            using (var cmd = new MySqlCommand($"SELECT * FROM {table} limit {limit.ToString()},1", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        noTrans = rd["id_transfer"].ToString();
                    }
                }
            }
            return noTrans;
        }
    }
}
