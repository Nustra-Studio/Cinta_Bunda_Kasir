using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KasirApp.Model;
using KasirApp.View;

namespace KasirApp.Repository
{
    public class SettingRepo
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        iSetting _set;
        public SettingRepo(iSetting set)
        {
            _set = set;
        }

        public void Set()
        {
            using (var cmd = new MySqlCommand("select * from settings", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        var model = new SettingModel();
                        model.Karyawan = rd["presentase_karyawan"].ToString();
                        model.Reseller = rd["presentase_reseller"].ToString();
                        model.Autodiskon = rd["auto_diskon"].ToString();
                        _set.SetValue(model);
                    }
                }
            }
        }

        public void UpdateSetting(SettingModel model)
        {
            if (model.Karyawan == "" || model.Reseller == "" || model.Autodiskon == "")
            {
                mb.PeringatanOK("Lengkapi Data");
            }
            using (var cmd = new MySqlCommand("UPDATE settings SET presentase_karyawan = @karyawan,presentase_reseller = @reseller, auto_diskon = @diskon where id = 1", op.Conn))
            {
                cmd.Parameters.AddWithValue("@karyawan", model.Karyawan);
                cmd.Parameters.AddWithValue("@reseller", model.Reseller);
                cmd.Parameters.AddWithValue("@diskon", model.Autodiskon);

                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();

                mb.InformasiOK("Berhasil Di Simpan");
                Set();
            }
        }
    }
}
