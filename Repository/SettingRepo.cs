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
                        model.Karyawanacc = rd["karyawanacc"].ToString();
                        model.Reseller = rd["presentase_reseller"].ToString();
                        model.Reselleracc = rd["reselleracc"].ToString();
                        model.Autodiskon = rd["auto_diskon"].ToString();
                        model.StokMinimum = rd["stokMinimum"].ToString();
                        model.Nama = rd["nama"].ToString();
                        model.Alamat = rd["alamat"].ToString();
                        model.Telp = rd["telp"].ToString();
                        model.Baris1 = rd["baris1"].ToString();
                        model.Baris2 = rd["baris2"].ToString();
                        model.Baris3 = rd["baris3"].ToString();
                        model.Header = rd["header"].ToString();
                        model.Valuepoint = rd["nilaipoint"].ToString();
                        model.Minimalcash = rd["minimumkupon"].ToString();
                        model.Backup = rd["backup"].ToString();
                        _set.SetValue(model);
                    }   
                }
            }
        }

        public void UpdateSetting(SettingModel model)
        {
            if (model.Karyawan == "" || model.Reseller == "" || model.Autodiskon == "" || model.Nama == "" || model.Alamat == "" || model.Telp == "" || model.Header == "" || model.Valuepoint == "" || model.Minimalcash == "" || model.Karyawanacc == "" || model.Reselleracc == "")
            {
                mb.PeringatanOK("Lengkapi Data");
            }
            using (var cmd = new MySqlCommand("UPDATE settings SET presentase_karyawan = @karyawan, karyawanacc = @acck, reselleracc = @accr, presentase_reseller = @reseller, auto_diskon = @diskon, stokMinimum = @stok,nama = @nama,alamat = @alamat, telp = @telp, baris1 = @baris1, baris2 = @baris2, baris3 = @baris3,header = @header,nilaipoint = @value,minimumkupon = @minim, backup = @backup, jeda_kertas = @jeda where id = 1", op.Conn))
            {
                cmd.Parameters.AddWithValue("@karyawan", model.Karyawan);
                cmd.Parameters.AddWithValue("@acck", model.Karyawanacc);
                cmd.Parameters.AddWithValue("@reseller", model.Reseller);
                cmd.Parameters.AddWithValue("@accr", model.Reselleracc);
                cmd.Parameters.AddWithValue("@diskon", model.Autodiskon);
                cmd.Parameters.AddWithValue("@stok", model.StokMinimum);
                cmd.Parameters.AddWithValue("@nama", model.Nama);
                cmd.Parameters.AddWithValue("@alamat", model.Alamat);
                cmd.Parameters.AddWithValue("@telp", model.Telp);
                cmd.Parameters.AddWithValue("@baris1", model.Baris1);
                cmd.Parameters.AddWithValue("@baris2", model.Baris2);
                cmd.Parameters.AddWithValue("@baris3", model.Baris3);
                cmd.Parameters.AddWithValue("@header", model.Header);
                cmd.Parameters.AddWithValue("@value", model.Valuepoint);
                cmd.Parameters.AddWithValue("@minim", model.Minimalcash);
                cmd.Parameters.AddWithValue("@backup", model.Backup);
                cmd.Parameters.AddWithValue("@jeda", model.Jeda);

                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();

                mb.InformasiOK("Berhasil Di Simpan");
                Set();
            }
        }
    }
}
