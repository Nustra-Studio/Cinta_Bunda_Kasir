using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KasirApp.Model;

namespace KasirApp.Repository
{
    class GroupRepo
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        int _order;

        public bool cekRows()
        {
            using (var cmd = new MySqlCommand("SELECT * FROM roles", op.Conn))
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

        public bool cekUnique(GroupModel model)
        {
            using (var cmd = new MySqlCommand($"SELECT * FROM roles where kode='{model.Kode}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (!rd.HasRows)
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
            using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM roles", op.Conn))
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

        public GroupModel showByOrder(int urutan)
        {
            var md = new GroupModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM roles LIMIT {urutan},1", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        md.Nama = rd["nama"].ToString();
                        md.Kode = rd["kode"].ToString();
                        md.Masters = rd["masters"].ToString().Equals("1") ? true : false;
                        md.Gudang = rd["Gudang"].ToString().Equals("1") ? true : false;
                        md.Supervisor = rd["Supervisor"].ToString().Equals("1") ? true : false;
                        md.Penjualan = rd["Penjualan"].ToString().Equals("1") ? true : false;
                    }
                }
            }
            return md;
        }

        public GroupModel takeBot()
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

        public GroupModel takeTop()
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

        public GroupModel takePrev()
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

        public GroupModel takeNext()
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

        public bool addGroup(GroupModel model) 
        {
            if (cekRows()==false)
            {
                return false;
            }
            else if (cekUnique(model)==false)
            {
                mb.PeringatanOK("Group dengan Kode tersebut Sudah ada!");
                return false;
            }
            else if (model.Nama == "" || model.Kode == "")
            {
                mb.PeringatanOK("Lengkapi Data");
                return false;
            }
            else
            {
                using (var cmd = new MySqlCommand($"" +
                    $"INSERT INTO roles VALUES (null,md5(rand()),'{model.Kode}','{model.Nama}'," +
                    $"{model.Masters},{model.Gudang},{model.Penjualan},0,0,{model.Supervisor})", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
                mb.InformasiOK("Data tersimpan");
                return true;
            }
        }

        public bool delGroup(GroupModel model)
        {
            if (cekRows()==false)
            {
                return false;
            }
            else if (model.Kode == "" && model.Nama == "")
            {
                return false;
            }
            else
            {
                bool status = false;
                if (mb.PeringatanYesNo("Hapus Data?")==true)
                {
                    using (var cmd = new MySqlCommand($"delete from roles where kode='{model.Kode}'", op.Conn))
                    {
                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                        status = true;
                    }
                }
                return status;
            }
        }

        public bool editGroup(GroupModel model)
        {
            if (cekRows() == false)
            {
                return false;
            }
            else if (model.Kode == "" && model.Nama == "")
            {
                mb.PeringatanOK("Tidak Boleh Kosong");
                return false;
            }
            else
            {
                bool status = false;
                if (mb.PeringatanYesNo("Edit Data?") == true)
                {
                    using (var cmd = new MySqlCommand($"" +
                        $"UPDATE roles Set kode='{model.Kode}',nama='{model.Nama}'," +
                        $"masters={model.Masters},gudang={model.Gudang},penjualan={model.Penjualan}," +
                        $"Supervisor={model.Supervisor} WHERE kode='{model.Kode}'", op.Conn))
                    {
                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                        status = true;
                    }
                }
                return status;
            }
        }

        public GroupModel takePopData(string kode)
        {
            var md = new GroupModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM roles where kode='{kode}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        md.Nama = rd["nama"].ToString();
                        md.Kode = rd["kode"].ToString();
                        md.Masters = rd["masters"].ToString().Equals("1") ? true : false;
                        md.Gudang = rd["Gudang"].ToString().Equals("1") ? true : false;
                        md.Supervisor = rd["Supervisor"].ToString().Equals("1") ? true : false;
                        md.Penjualan = rd["Penjualan"].ToString().Equals("1") ? true : false;
                    }
                }
            }
            return md;
        }
    }
}
