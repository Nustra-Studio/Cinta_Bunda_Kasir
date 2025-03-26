using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using RestSharp;
using Newtonsoft.Json;
using KasirApp.Model;
using KasirApp.View;
using KasirApp.GUI;
using KasirApp.Repository;
using System.Security.Cryptography;

namespace KasirApp.Presenter
{
    class LoginPresenter : iRole
    {
        MboxOperator mb = new MboxOperator();
        Operator op = new Operator();
        TransaksiRepo rep = new TransaksiRepo(null);
        iLogin _login;
        iMasterForm _iform;

        //Interface Variable API
        string _role;
        string _token;
        //local db 
        int _id;
        string _uuid;
        string _kode;
        string _nama;
        private int _masters;
        private int _gudang;
        private int _penjualan;
        private int _kasbank;
        private int _akuntansi;
        private int _supervisor;

        //Interface API
        public string Role { get { return _role; } set { _role = value; } }
        public string Token { get { return _token; } set { _token = value; } }
        //LOCAL DB
        public int id { get => _id; set => _id = value; }
        public string uuid { get => _uuid; set => _uuid = value; }
        public string Kode { get => _kode; set => _kode = value; }
        public string nama { get => _nama; set => _nama = value; }
        public int masters { get => _masters; set => _masters = value; }
        public int gudang { get => _gudang; set => _gudang = value; }
        public int penjualan { get => _penjualan; set => _penjualan = value; }
        public int kasbank { get => _kasbank; set => _kasbank = value; }
        public int akuntansi { get => _akuntansi; set => _akuntansi = value; }
        public int supervisor { get => _supervisor; set => _supervisor = value; }

        public LoginPresenter(iLogin lg, iMasterForm frm1)
        {
            _login = lg;
            _iform = frm1;
        }

        public bool isNull()
        {
            if (_login.Username == "" || _login.Password == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CekNetwork()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 3;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AttemptLogin()
        {
            if (CekNetwork() == false)
            {
                mb.PeringatanOK("Tidak Ada Koneksi Internet");
            }
            else if (isNull() == false)
            {
                mb.PeringatanOK("Masukan Username dan Password yang lengkap");
            }
            else
            {
                //config request
                var option = new RestClientOptions(op.url) { MaxTimeout = 30000};

                using (var url = new RestClient(option))
                {
                    var request = new RestRequest("login", Method.Post);
                    request.AddParameter("username", _login.Username);
                    request.AddParameter("password", _login.Password);
                    request.AddParameter("cabang", op.settingData().Cabang);
                    try
                    {
                        RestResponse res = url.Execute(request);
                        if (res.StatusCode == HttpStatusCode.OK)
                        {
                            var jso = res.Content.ToString();
                            Root fn = JsonConvert.DeserializeObject<Root>(jso);

                            mb.InformasiOK("Login sebagai : " + fn.user.role.ToString() + " Berhasil");

                            _login.hideForm();
                            _role = fn.user.role.ToString();
                            _token = fn.token.ToString();

                            var hash = hashString(_login.Password);

                            var usercl = new userDataModel();
                            usercl.csrf_token = res.Headers.FirstOrDefault(h => h.Name == "X-CSRF-TOKEN")?.Value?.ToString();
                            usercl.token = _token;
                            usercl.api_key = _token;
                            usercl.uuid = fn.user.uuid.ToString();
                            usercl.password = hash.ToString();
                            usercl.username = fn.user.username.ToString();
                            usercl.role = _role;
                            usercl.cabang_id = fn.user.cabang_id;

                            updateAkunOffline(usercl);

                            using (MySqlCommand cmd = new MySqlCommand("select * from roles where nama = @nama", op.Conn))
                            {
                                cmd.Parameters.AddWithValue("@nama", _role);
                                op.KonekDB();
                                using (MySqlDataReader rd = cmd.ExecuteReader())
                                {
                                    while (rd.Read())
                                    {
                                        usrRole user = new usrRole()
                                        {
                                            Id = Convert.ToInt32(rd["id"]),
                                            Uuid = rd["uuid"].ToString(),
                                            Kode1 = rd["kode"].ToString(),
                                            Nama = rd["nama"].ToString(),
                                            Masters = Convert.ToInt32(rd["masters"].ToString()),
                                            Gudang = Convert.ToInt32(rd["Gudang"].ToString()),
                                            Penjualan = Convert.ToInt32(rd["Penjualan"].ToString()),
                                            Kasbank = Convert.ToInt32(rd["KasBank"].ToString()),
                                            Akuntansi = Convert.ToInt32(rd["Akuntansi"].ToString()),
                                            Supervisor = Convert.ToInt32(rd["Supervisor"].ToString()),
                                            Token = _token
                                        };
                                        _iform.Role(user, usercl);
                                        _iform.CloseForm();
                                    }
                                }
                            }
                            rep.uploadPending(usercl);
                            updateKategori();
                            updateSupplier(usercl);

                        }
                        else if (res.StatusCode == HttpStatusCode.Unauthorized)
                        {   
                            var jso = res.Content.ToString();
                            error fn = JsonConvert.DeserializeObject<error>(jso);
                            mb.PeringatanOK(fn.message.ToString());
                        }
                        else if(res.StatusCode == HttpStatusCode.RequestTimeout)
                        {
                            var hashed = SHA256.Create(_login.Password);

                            var offlineUser = new userDataModel() 
                            { 
                                username = _login.Username,
                                password = hashed.ToString(),
                            };

                            offlineLogin(offlineUser);
                        }
                        else
                        {
                            var jso = res.Content.ToString();
                            mb.PeringatanOK(jso);
                        }
                    }
                    catch (Exception ex)
                    {
                        mb.PeringatanOK(ex.Message);
                    }
                }
                updateKwitansi();
            }
        }

        string kwitansi;
        
        public string hashString(string Key)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(Key));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public void updateAkunOffline(userDataModel user)
        {
            //exist status
            var isExist = false;

            using (var cmd = new MySqlCommand($"SELECT * FROM user_cabangs where username = '{user.username}' AND password = '{user.password}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        isExist = true;
                    }
                }
                op.KonekDB();
            }

            if(!isExist)
            {
                using (var cmd = new MySqlCommand($"insert into user_cabangs values(null,'{user.username}','{user.nama ?? ""}', '{user.password}', '{user.uuid}','{user.role}','0', '{user.cabang_id}', '{user.api_key}', '{op.myDatetime}', '{op.myDatetime}')", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
            else
            {
                using (var cmd = new MySqlCommand($"update user_cabangs set api_key = '{user.api_key}', password = '{user.password}' where username = '{user.username}' and password ='{user.password}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
        }

        public void offlineLogin(userDataModel userLogin)
        {
            //deklarasi Kredensial user offline
            var offlineUser = new userDataModel();
            var isExist = false;

            //Ambil Data User Offline
            using (var cmd = new MySqlCommand($"select * from user_cabangs where username = '{userLogin.username}' AND password = '{userLogin.password}'" ,op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        var model = new userDataModel()
                        {
                            api_key = rd["api_key"].ToString(),
                            token = rd["api_key"].ToString(),
                            username = rd["username"].ToString(),
                            nama = rd["nama"].ToString(),
                            password = rd["password"].ToString(),
                            uuid = rd["uuid"].ToString(),
                            role = rd["role"].ToString(),
                        };

                        offlineUser = model;

                        isExist = true;
                    }
                    else
                    {
                        mb.peringatanError("Mencoba Login Offline, User Belum Login Sebelumnya");
                    }
                }
                op.KonekDB();
            }

            if(isExist)
            {
                mb.InformasiOK("Login Offline sebagai : " + offlineUser.role + " Berhasil");

                _login.hideForm();

                using (MySqlCommand cmd = new MySqlCommand("select * from roles where nama = @nama", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@nama", offlineUser.role);
                    op.KonekDB();
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            usrRole user = new usrRole()
                            {
                                Id = Convert.ToInt32(rd["id"]),
                                Uuid = rd["uuid"].ToString(),
                                Kode1 = rd["kode"].ToString(),
                                Nama = rd["nama"].ToString(),
                                Masters = Convert.ToInt32(rd["masters"].ToString()),
                                Gudang = Convert.ToInt32(rd["Gudang"].ToString()),
                                Penjualan = Convert.ToInt32(rd["Penjualan"].ToString()),
                                Kasbank = Convert.ToInt32(rd["KasBank"].ToString()),
                                Akuntansi = Convert.ToInt32(rd["Akuntansi"].ToString()),
                                Supervisor = Convert.ToInt32(rd["Supervisor"].ToString()),
                                Token = _token
                            };
                            _iform.Role(user, offlineUser);
                            _iform.CloseForm();
                        }
                    }
                }
                updateKategori();
            }
        }

        public void updateKategori()
        {
            //declare list barang
            var listbarang = new List<BarangsModel>();

            //read barang dengan kategori kosong
            using (var cmd = new MySqlCommand("SELECT * FROM barangs where category_id = ''", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var model = new BarangsModel();
                        model.Kode = rd["kode_barang"].ToString();

                        listbarang.Add(model);
                    }
                }
            }

            foreach (var item in listbarang)
            {
                //take 3 letter pertama barcode
                var kategori = item.Kode.Substring(0, 3).ToString();

                //status Barang eksis dan kode kategori
                var uuidKategori = "";

                //get uuid tidak ada kategori 
                using (var cmd = new MySqlCommand("select * from category_barangs where name = 'Tanpa Kategori'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        if(rd.Read())
                        {
                            uuidKategori = rd["uuid"].ToString();
                        }
                    }
                }

                //search di tabel kategori
                using (var cmd = new MySqlCommand($"select * from category_barangs where name ='{kategori}' ", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        if(rd.Read())
                        {
                            uuidKategori = rd["uuid"].ToString();
                        }
                    }
                }

                //jika barang ada maka update id kategori
                using (var cmd = new MySqlCommand($"update barangs set category_id = '{uuidKategori}' where kode_barang ='{item.Kode}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
        }
            
        public void updateSupplier(userDataModel user)
        {
            var listSuplier = new List<SuplierModel>();
            using (var client = new RestClient(op.url))
            {
                try
                {
                    var request = new RestRequest("supplier", Method.Get);
                    var body = new
                    {
                        token = user.token,
                        uuid = user.uuid
                    };

                    var response = client.Execute(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        listSuplier = JsonConvert.DeserializeObject<List<SuplierModel>>(response.Content.ToString());
                    }
                    else
                    {
                        return;
                    }

                    if(listSuplier.Count >= 1)
                    {
                        foreach (var item in listSuplier)
                        {
                            //cek Data apakah Exist
                            var isExist = false;
                            using (var cmd = new MySqlCommand($"SELECT * FROM supliers where nama = {item.nama}", op.Conn))
                            {
                                op.KonekDB();
                                using (var rd = cmd.ExecuteReader())
                                {
                                    if(rd.Read())
                                    {
                                        isExist = true;
                                    }
                                }
                            }

                            if(!isExist)
                            {
                                using (var cmd = new MySqlCommand($"insert into supliers values(null,'{item.uuid}','{item.nama}', '{item.alamat}', '{item.telepon}', '{item.product}','{item.keterangan}', '{item.category_barang_id}','{op.myDatetime}', '{op.myDatetime}')", op.Conn))
                                {
                                    op.KonekDB();
                                    cmd.ExecuteNonQuery();
                                    op.KonekDB();
                                }
                            }

                        }
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        public void updateKwitansi()
        {
            string tnggal = DateTime.Now.ToString("yyyy-MM-dd");
            bool updateTgl = false;
            //Set current Tanggal
            using (var cmd = new MySqlCommand($"Select * from numberingkwitansi where tanggal = '{tnggal}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (!rd.HasRows)
                    {
                        updateTgl = true;
                    }
                }
            }

            string[] table = { "report_penjualan", "report_transfergudang", "opnames", "report_penyesuaian" };
            string[] identifier = { "id_penjualan", "id_transfer", "nomerTrans", "id_penyesuaian" };
            string[] header = { "PJC", "PTG", "POP", "PAD" };

            for (int i = 0; i <= 3; i++)
            {
                var rowStatus = false;
                //Cek Struk Sebelumnya
                using (var cmd = new MySqlCommand($"SELECT * FROM {table[i]} where {identifier[i]} LIKE '%{header[i]}-{DateTime.Now.ToString("yyMMdd")}%'", op.Conn))
                {
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if(rd.HasRows)
                        {
                            rowStatus = true;
                        }
                        else
                        {
                            kwitansi = $"{DateTime.Now.ToString("yyMMdd")}0001";
                        }
                    }
                }

                //Update ke no struk kemarin
                if (rowStatus)
                {
                    using (var cmd = new MySqlCommand($"SELECT MAX({identifier[i]}) AS max_id FROM {table[i]} WHERE {identifier[i]} LIKE '%{header[i]}-{DateTime.Now.ToString("yyMMdd")}%'", op.Conn))
                    {
                        using (var rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                var number = Convert.ToInt64(rd["max_id"].ToString().Substring(4)) + 1;
                                kwitansi = number.ToString();
                            }
                        }
                    }
                }

                //Update Numbering
                if (updateTgl == true)
                {
                    using (var cmd = new MySqlCommand($"Update numberingkwitansi SET tanggal = '{tnggal}',{header[i]} = '{kwitansi}'", op.Conn))
                    {
                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                    }
                }
            }


        }
    }
}
