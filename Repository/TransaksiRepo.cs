using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using KasirApp.Model;
using MySql.Data.MySqlClient;
using System.Net;
using Newtonsoft.Json;
using System.Data;

namespace KasirApp.Repository
{
    class TransaksiRepo
    {
        //Fields
        MboxOperator mb = new MboxOperator();
        Operator op = new Operator();
        userDataModel _user;
        string stateHJ;

        //Constructor
        public TransaksiRepo(userDataModel user)
        {
            _user = user;
        }

        //Local Method
        public int AmbilNomor()
        {
            int nomor = 0;
            using (MySqlCommand cmd = new MySqlCommand("select PJC from numberingkwitansi", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        nomor = Convert.ToInt32(rd["PJC"].ToString());
                    }
                }
                op.KonekDB();
            }
            return nomor;
        }

        public bool CekData(TransaksiModel model)
        {
            using (MySqlCommand cmd = new MySqlCommand("select * from barangs where kode_barang = @kode OR name = @kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@kode", model.Barkode);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
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

        public TransaksiModel getByValue(TransaksiModel model)
        {
            var md = new TransaksiModel();
            using (var cmd = new MySqlCommand("SELECT * FROM histori_penjualan WHERE barcode = @barcode AND nomerTrans = @noPJ", op.Conn))
            {
                cmd.Parameters.AddWithValue("@barcode", model.Barkode);//Nama = selection
                cmd.Parameters.AddWithValue("@noPJ", model.NomorPJ);

                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();

                    if (rd.HasRows)
                    {
                        md.Nama = rd["nama"].ToString();
                        md.Harga_jual = rd["harga_jual"].ToString();
                        md.Harga_pokok = rd["hpp"].ToString();
                        md.Diskon = rd["diskon"].ToString();
                        md.Quantity = rd["quantity"].ToString();
                        md.State = model.State;
                    }
                }
            }

            return md;
        }

        public TransaksiModel AmbilValueRead(TransaksiModel model)
        {
            var md = new TransaksiModel();
            using (MySqlCommand cmd = new MySqlCommand("select * from barangs where kode_barang = @kode OR name = @kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@kode", model.Barkode);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();

                    //Data AssignMent
                    md.NomorPJ = model.NomorPJ;
                    md.Nama = rd["name"].ToString();
                    md.Barkode = rd["kode_barang"].ToString();
                    md.Quantity = "1";
                    md.Harga_jual = rd["harga_jual"].ToString();
                    md.Harga_pokok = rd["harga_pokok"].ToString();
                    md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                    md.State = model.State;

                    //Logic
                    int qty = Convert.ToInt32(md.Quantity);
                    int HJ = Convert.ToInt32(md.Harga_jual);
                    int TotalPCS = qty * HJ;
                    md.Total = TotalPCS.ToString();

                }
            }
            return md;
        }

        //Cek Kesamaan pada saat insert
        public void CekRows(TransaksiModel md)
        {
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomer AND nama = @nama OR nomerTrans = @nomer AND barcode = @barcode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", md.NomorPJ);
                cmd.Parameters.AddWithValue("@nama", md.Nama);
                cmd.Parameters.AddWithValue("@barcode", md.Barkode);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        int qty =  Convert.ToInt32(rd["quantity"].ToString()) + 1;
                        int total = qty * Convert.ToInt32(rd[md.State].ToString());
                        using (MySqlCommand com = new MySqlCommand("UPDATE histori_penjualan SET quantity = @Qty,total = @total where nomerTrans = @nomor AND nama = @nama OR nomerTrans = @nomor AND barcode = @kode", op.Conn))
                        {
                            com.Parameters.AddWithValue("nomor", md.NomorPJ);
                            com.Parameters.AddWithValue("@nama", md.Nama);
                            com.Parameters.AddWithValue("kode", md.Barkode);
                            com.Parameters.AddWithValue("Qty", qty);
                            com.Parameters.AddWithValue("total", total);

                            op.KonekDB();
                            rd.Close();
                            com.ExecuteNonQuery();
                            op.KonekDB();
                        }
                        cekdiskon(md);
                    }
                    else
                    {
                        rd.Close();
                        AmbilValue(md);
                    }
                }
            }
        }

        public void AmbilValue(TransaksiModel model)
        {
            
            if (model.State == "hpp")
            {
                stateHJ = "harga_pokok";
            }
            else
            {
                stateHJ = model.State;
            }
            var md = new TransaksiModel();
            using (MySqlCommand cmd = new MySqlCommand("select * from barangs where kode_barang = @kode OR name = @kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@kode", model.Barkode);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();

                    //Data AssignMent
                    md.NomorPJ = model.NomorPJ;
                    md.Nama = rd["name"].ToString();
                    md.Barkode = rd["kode_barang"].ToString();
                    md.Quantity = "1";
                    md.Harga_jual = rd["harga_jual"].ToString();
                    md.Harga_pokok = rd["harga_pokok"].ToString();
                    md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                    md.Id_member = model.Id_member;

                    //Logic
                    int qty = Convert.ToInt32(md.Quantity);
                    int HJ = Convert.ToInt32(rd[stateHJ].ToString());
                    int TotalPCS = qty * HJ;
                    md.Total = TotalPCS.ToString();
                }
            }
            insertPJ(md);
        }

        public void insertPJ(TransaksiModel model)
        {
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO histori_penjualan VALUES (null,md5(RAND()), @nomorPJ, @nama, @barcode, @quantity, @HJ, @HPP, @Diskon, @Total, @user, @id_member, @tanggal)", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomorPJ", model.NomorPJ);
                cmd.Parameters.AddWithValue("@nama", model.Nama);
                cmd.Parameters.AddWithValue("@barcode", model.Barkode);
                cmd.Parameters.AddWithValue("@quantity", "1");//insert satu quantity
                cmd.Parameters.AddWithValue("@HJ", model.Harga_jual);
                cmd.Parameters.AddWithValue("@HPP", model.Harga_pokok);
                cmd.Parameters.AddWithValue("@Total", 1 * Convert.ToInt32(model.Total));
                cmd.Parameters.AddWithValue("@tanggal", model.Tanggal);
                cmd.Parameters.AddWithValue("@Diskon", "0");// Set Diskon ke 0
                cmd.Parameters.AddWithValue("@id_member", model.Id_member);
                cmd.Parameters.AddWithValue("@user", _user.username);

                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
            cekdiskon(model);
        }

        public SettingModel AmbilSetting()
        {
            var model = new SettingModel();
            using (var cmd = new MySqlCommand("Select * from settings", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        model.Karyawan = rd["presentase_karyawan"].ToString();
                        model.Reseller = rd["presentase_reseller"].ToString();
                        model.Autodiskon = rd["auto_diskon"].ToString();
                    }
                }
            }
            return model;
        }

        int presentase;
        public void StateChange(string state, TransaksiModel model)
        {
            var ListBarang = new List<TransaksiModel>();
            using (var cmd = new MySqlCommand("SELECT * FROM histori_penjualan where nomerTrans = '" + model.NomorPJ + "'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var md = new TransaksiModel();
                        md.Barkode = rd["barcode"].ToString();
                        md.Harga_pokok = rd["hpp"].ToString();
                        md.Harga = rd["hpp"].ToString();
                        md.Quantity = rd["quantity"].ToString();
                        ListBarang.Add(md);
                    }
                }
            }
            
            foreach (var md in ListBarang)
            {
                if (model.State == "hpp")
                {
                    stateHJ = "harga_pokok";
                }
                else
                {
                    stateHJ = "harga_jual";
                }
                int hpp = 0;
                using (var cmd = new MySqlCommand("SELECT * from barangs where kode_barang = @barcode", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@barcode", md.Barkode);
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if (rd.HasRows)
                        {
                            hpp = Convert.ToInt32(rd[stateHJ].ToString());
                        }
                    }
                }
                int potongan = 0;
                int totalstate = 0;
                if (state == "karyawan")
                {
                    presentase = Convert.ToInt32(AmbilSetting().Karyawan);
                    potongan = hpp * presentase / 100;
                    totalstate = hpp + potongan;
                }
                else if (state == "reseller")
                {
                    presentase = Convert.ToInt32(AmbilSetting().Reseller);
                    potongan = hpp * presentase / 100;
                    totalstate = hpp - potongan;//harga jual - presentase potongan
                }
                else if (state == "reguler")
                {
                    totalstate = hpp;
                }
                int totalHpp = totalstate * Convert.ToInt32(md.Quantity);
                using (var cmd = new MySqlCommand("UPDATE histori_penjualan SET " + model.State + " = @hpp,total = @total WHERE barcode = @barcode AND nomerTrans = @nomorPJ", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@hpp", totalstate.ToString());
                    cmd.Parameters.AddWithValue("@total", totalHpp.ToString());
                    cmd.Parameters.AddWithValue("@barcode", md.Barkode);
                    cmd.Parameters.AddWithValue("@nomorPJ", model.NomorPJ);

                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
        }

        public void UpdateNumberint()
        {
            int nomor = 0;
            using (MySqlCommand cmd = new MySqlCommand("Select PJC from numberingkwitansi", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        nomor = Convert.ToInt32(rd["PJC"]);
                    }
                }
                op.KonekDB();
            }
            int update = nomor + 1;
            using (MySqlCommand cmd = new MySqlCommand("UPDATE numberingkwitansi SET PJC = @value WHERE PJC = @Set", op.Conn))
            {
                cmd.Parameters.AddWithValue("value", update);
                cmd.Parameters.AddWithValue("Set", nomor);

                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
        }

        public DataTable SetView(TransaksiModel model)
        {
            UpdateHarga(model);
            var dt = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand("select barcode, nama, quantity, " + model.State + ", diskon, total from histori_penjualan where nomerTrans = '" + model.NomorPJ + "' ", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    dt.Load(rd);
                }
                op.KonekDB();
            }
            return dt;
        }

        public void cekdiskon(TransaksiModel model)
        {
            var md = new TransaksiModel();
            using (var cmd = new MySqlCommand("select * from histori_penjualan where barcode LIKE '%BBG%' and nomerTrans = @nomerPJ", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomerPJ", model.NomorPJ);
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        var red = new TransaksiModel();
                        red.Quantity = rd["quantity"].ToString();
                        red.Barkode = rd["barcode"].ToString();
                        red.Diskon = rd["diskon"].ToString();
                        red.NomorPJ = model.NomorPJ;
                        md = red;
                    }
                }
            }
            if (Convert.ToInt32(md.Quantity) == 3)
            {
                int finalDiskon = Convert.ToInt32(md.Diskon) + Convert.ToInt32(AmbilSetting().Autodiskon);
                using (var cmd = new MySqlCommand("UPDATE histori_penjualan SET diskon = @diskon where barcode = @barcode AND nomerTrans = @nomerPJ", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@barcode", md.Barkode);
                    cmd.Parameters.AddWithValue("@nomerPJ", md.NomorPJ);
                    cmd.Parameters.AddWithValue("@diskon", finalDiskon.ToString());

                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
            else if (Convert.ToInt32(md.Quantity) < 3)
            {
                int finalDiskon = Convert.ToInt32(md.Diskon);
                if (md.Diskon == "0")
                {
                    return;
                }
                //else if(Convert.ToInt32(md.Diskon) >= 1000)
                //{
                //    finalDiskon = Convert.ToInt32(md.Diskon) - 1000;
                //}
                using (var cmd = new MySqlCommand("UPDATE histori_penjualan SET diskon = @diskon where barcode = @barcode AND nomerTrans = @nomerPJ", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@barcode", md.Barkode);
                    cmd.Parameters.AddWithValue("@nomerPJ", md.NomorPJ);
                    cmd.Parameters.AddWithValue("@diskon", finalDiskon.ToString());

                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
            else
            {
                return;
            }
        }

        public void UpdateDiskon(TransaksiModel model)
        {
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomor AND barcode = @barcode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomor", model.NomorPJ);
                cmd.Parameters.AddWithValue("@barcode", model.Barkode);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        int total = Convert.ToInt32(rd["quantity"].ToString()) * Convert.ToInt32(rd[model.State].ToString()) - Convert.ToInt32(model.Diskon);
                        using (MySqlCommand com = new MySqlCommand("UPDATE histori_penjualan SET diskon = @discon,total = @total where nomerTrans = @nomor AND barcode = @kode", op.Conn))
                        {
                            com.Parameters.AddWithValue("nomor", model.NomorPJ);
                            com.Parameters.AddWithValue("kode", model.Barkode);
                            com.Parameters.AddWithValue("discon", model.Diskon);
                            com.Parameters.AddWithValue("total", total);

                            op.KonekDB();
                            rd.Close();
                            com.ExecuteNonQuery();
                            op.KonekDB();
                        }
                    }
                }
            }
        }

        public void UpdateQuantity(TransaksiModel model)
        {
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomor AND barcode = @barcode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomor", model.NomorPJ);
                cmd.Parameters.AddWithValue("@barcode", model.Barkode);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        int total = Convert.ToInt32(model.Quantity) * Convert.ToInt32(rd[model.State].ToString());
                        using (MySqlCommand com = new MySqlCommand("UPDATE histori_penjualan SET quantity = @Qty,total = @total where nomerTrans = @nomor AND barcode = @kode", op.Conn))
                        {
                            com.Parameters.AddWithValue("nomor", model.NomorPJ);
                            com.Parameters.AddWithValue("kode", model.Barkode);
                            com.Parameters.AddWithValue("Qty", model.Quantity);
                            com.Parameters.AddWithValue("total", total);

                            op.KonekDB();
                            rd.Close();
                            com.ExecuteNonQuery();
                            op.KonekDB();
                        }
                    }
                }
            }
            cekdiskon(model);
        }

        public void UpdateHarga(TransaksiModel model)
        {
            int HJ = 0;
            var listmodel = new List<TransaksiModel>();
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomor", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomor", model.NomorPJ);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    op.KonekDB();
                    while (rd.Read())
                    {
                        var md = new TransaksiModel();

                        //Data AssignMent
                        md.NomorPJ = model.NomorPJ;
                        md.Nama = rd["nama"].ToString();
                        md.Barkode = rd["barcode"].ToString();
                        md.Quantity = rd["quantity"].ToString();
                        md.Harga_jual = rd["harga_jual"].ToString();
                        md.Harga = rd[model.State].ToString();
                        md.Harga_pokok = rd["hpp"].ToString();
                        md.Diskon = rd["diskon"].ToString();
                        md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");



                        //Logic
                        int qty = Convert.ToInt32(md.Quantity);
                        int diskon = Convert.ToInt32(md.Diskon);
                        HJ = Convert.ToInt32(md.Harga.Equals(null) ? null : md.Harga);
                        int TotalPCS = qty * HJ - diskon;
                        md.Total = TotalPCS.ToString();

                        listmodel.Add(md);
                    }
                }

                foreach (var md in listmodel)
                {
                    int total = Convert.ToInt32(md.Quantity) * Convert.ToInt32(md.Harga) - Convert.ToInt32(md.Diskon);
                    using (MySqlCommand com = new MySqlCommand("UPDATE histori_penjualan SET " + model.State + " = @harga, total = @total where nomerTrans = @nomor AND barcode = @kode", op.Conn))
                    {
                        com.Parameters.AddWithValue("nomor", model.NomorPJ);
                        com.Parameters.AddWithValue("harga", md.Harga);
                        com.Parameters.AddWithValue("kode", md.Barkode);
                        com.Parameters.AddWithValue("total", total);

                        op.KonekDB();
                        com.ExecuteNonQuery();
                        op.KonekDB();
                    }
                }
            }
        }

        public void SubtrakBarangs(List<TransaksiModel> model)
        {
            int stok = 0;
            foreach (var md in model)
            {
                using (var cmd = new MySqlCommand("Select stok FROM barangs where kode_barang = @barcode", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@barcode", md.Barkode);
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if (rd.HasRows)
                        {
                            stok = Convert.ToInt32(rd["stok"].ToString());
                        }
                    }
                }
                int final = stok - Convert.ToInt32(md.Quantity);
                using (var cmd = new MySqlCommand("UPDATE barangs SET stok = @final WHERE kode_barang = @kode", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@final", final.ToString());
                    cmd.Parameters.AddWithValue("@kode", md.Barkode);

                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
        }

        public void Delete(TransaksiModel model)
        {
            using (MySqlCommand com = new MySqlCommand("Delete FROM histori_penjualan where nomerTrans = @nomor AND barcode = @kode", op.Conn))
            {
                com.Parameters.AddWithValue("nomor", model.NomorPJ);
                com.Parameters.AddWithValue("kode", model.Barkode);

                op.KonekDB();
                com.ExecuteNonQuery();
                op.KonekDB();
            }
        }

        //API Method
        public RootMember AmbilPoint(userDataModel model, string kode)
        {
            var mem = new RootMember();
            using (var client = new RestClient($"{op.urlcloud}cabangmember/"))
            {
                var rs = new RestRequest("poin", Method.Get);
                rs.AddParameter("pin", kode);
                rs.AddParameter("token", model.token);

                var response = client.Execute(rs);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string json = response.Content.ToString();
                    mem = JsonConvert.DeserializeObject<RootMember>(json);
                    mem.member.status = "sucess";
                    ///mbox cek error
                    //mb.InformasiOK(response.Content.ToString() + response.StatusCode.ToString());
                }
                else if(response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var jso = response.Content.ToString();
                    apiError err = JsonConvert.DeserializeObject<apiError>(jso);
                    mem = null;
                }
                else
                {
                    mb.PeringatanOK("Kode Salah");
                }
            }
            return mem;
        }

        public void insertHistori(userDataModel user, TransaksiModel model, int subtotal)
        {
            if (op.CekNetwork() == false)
            {
                return;
            }
            else
            {
                //Ambil Data Local
                var listTrans = new List<TransaksiModel>();
                using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomer", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@nomer", model.NomorPJ);
                    op.KonekDB();
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var md = new TransaksiModel();
                            
                            //Data AssignMent
                            md.NomorPJ = model.NomorPJ;
                            md.Nama = rd["nama"].ToString();
                            md.Barkode = rd["barcode"].ToString();
                            md.Quantity = rd["quantity"].ToString();
                            md.Harga_jual = rd["harga_jual"].ToString();
                            md.Harga_pokok = rd["hpp"].ToString();
                            md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                            md.Id_member = model.Id_member;
                            //Logic
                            int qty = Convert.ToInt32(md.Quantity);
                            int HJ = Convert.ToInt32(md.Harga_pokok);
                            int TotalPCS = qty * HJ;
                            md.Total = TotalPCS.ToString();

                            listTrans.Add(md);
                        }
                    }

                    SubtrakBarangs(listTrans);
                    //Update List Struk
                    op.masukListStruk("PJC", model.NomorPJ);

                    using (var client = new RestClient($"{op.urlcloud}cabangmember/"))
                    {
                        var body = new
                        {
                            token = user.token,
                            id_cabang = user.uuid,
                            data = listTrans,
                            subtotal = subtotal
                        };

                        var rs = new RestRequest("transaksi", Method.Post);
                        rs.AddJsonBody(body);

                        var response = client.Execute(rs);
                        //mb.InformasiOK(response.Content.ToString());
                        mb.InformasiOK("Transaksi Selesai");
                    }
                }
                //Update Nomor
                UpdateNumberint();
            }
        }
    }
}
