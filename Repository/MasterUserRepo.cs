using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;
using MySql.Data.MySqlClient;
using RestSharp;
using Newtonsoft.Json;

namespace KasirApp.Repository
{
    class MasterUserRepo
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        int order = 0;
        //Constructor
        public MasterUserRepo()
        {

        }

        public bool addBaru(userDataModel model)
        {
            bool adaRow = true;
            using (var cmd = new MySqlCommand($"SELECT * FROM user_cabangs where username = BINARY '{model.username}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (!rd.HasRows)
                    {
                        adaRow = false;
                    }
                }
            }
            if (model.username == "" || model.uuid == "")
            {
                return false;
            }
            else if (adaRow == true)
            {
                mb.PeringatanOK("Username Sudah ada");
                return false;
            }
            else
            {
                using (var cmd = new MySqlCommand($"" +
                    $"INSERT INTO user_cabangs VALUES (null,'{model.username}','{model.uuid}',MD5('{model.password}')," +
                    $"MD5(RAND()),'{model.role}','0', '{model.cabang_id}','{model.token}',@tanggal,@tanggal)", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@tanggal", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                }
                mb.InformasiOK("Berhasil Simpan User");
                simpanCloud(model);
                return true;
            }
        }

        public bool deleteUsr(userDataModel user, userDataModel olusr)
        {
            if (mb.PeringatanYesNo("Hapus User?")==true)
            {
                string uuidusr = "";
                using (var cmd = new MySqlCommand($"SELECT * FROM user_cabangs where username='{user.username}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        uuidusr = rd["uuid"].ToString();
                    }
                }

                using (var cmd = new MySqlCommand($"DELETE FROM user_cabangs WHERE username = BINARY '{user.username}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }

                //hapus ke db online
                try
                {
                    using (var client = new RestClient(op.url))
                    {
                        var body = new
                        {
                            token = olusr.token,
                            data = new
                            {
                                uuid = uuidusr,
                                cabang_id = olusr.cabang_id
                            }
                        };

                        var req = new RestRequest("deleteuser", Method.Post);
                        req.AddJsonBody(body);

                        var res = client.Execute(req);
                    }
                }
                catch (Exception)
                {

                }

                return true;
            }
            else
            {
                return false;
            }

           
        }

        public bool editUsr(userDataModel usr, userDataModel oluser)
        {
            if (usr.username == "")
            {
                return false;
            }
            else
            {
                string uuidusr = "";
                using (var cmd = new MySqlCommand($"SELECT * FROM user_cabangs where username='{usr.username}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        uuidusr = rd["uuid"].ToString();
                    }
                }

                using (var cmd = new MySqlCommand($"UPDATE user_cabangs SET username='{usr.username}', nama='{usr.uuid}', password= md5('{usr.password}'), role='{usr.role}' where username= BINARY '{usr.username}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }

                try
                {
                    using (var client = new RestClient(op.url))
                    {
                        var body = new
                        {
                            token = oluser.token,
                            data = new
                            {
                                password = usr.password,
                                uuid = uuidusr,
                                role = usr.role,
                                cabang_id = oluser.cabang_id
                            }
                        };

                        var req = new RestRequest("updateuser", Method.Post);
                        req.AddJsonBody(body);

                        var res = client.Execute(req);
                    }
                }
                catch (Exception)
                {
                    
                }

                return true;
            }
        }

        public void simpanCloud(userDataModel model)
        {
            var md = new userDataModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM user_cabangs WHERE username = '{model.username}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        md.username = rd["username"].ToString();
                        md.api_key = rd["nama"].ToString();//nama di api key
                        md.password = rd["password"].ToString();
                        md.uuid = rd["uuid"].ToString();
                        md.role = rd["role"].ToString();
                        md.cabang_id = rd["cabang_id"].ToString();
                    }
                }
            }
            var body = new
            {
                token = model.token,
                data = new
                {
                    username = md.username,
                    password = model.password,
                    uuid = md.uuid,
                    role = md.role,
                    cabang_id = md.cabang_id
                }
            };

            using (var client = new RestClient(op.url))
            {
                var req = new RestRequest("createuser", Method.Post);
                req.AddJsonBody(body);

                var res = client.Execute(req);

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    return;
                }
            }
        }

        public List<string> isiCombo()
        {
            var list = new List<string>();
            using (var cmd = new MySqlCommand("SELECT nama FROM roles", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(rd["nama"].ToString());
                    }
                }
            }
            return list;
        }

        public List<string> ComboAPI()
        {
            var list = new List<string>();
            using (var client = new RestClient($"{op.url}owner/"))
            {
                var req = new RestRequest("listcabang", Method.Get);

                var res = client.Execute(req);

                string jso = res.Content.ToString();
                    
                List<CabangModel> fn = JsonConvert.DeserializeObject<List<CabangModel>>(jso); 

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    foreach (var item in fn)
                    {
                        list.Add(item.nama);
                    }
                }
                else
                {
                    mb.PeringatanOK("Cek Konesksi Internet");
                }
            }
            return list;
        }

        public int limit()
        {
            int batas = 0;
            using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM user_cabangs", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        batas = Convert.ToInt32(rd["COUNT(*)"].ToString());
                    }
                }
            }
            return batas;
        }

        public userDataModel Bawah()
        {
            order = limit();
            var model = new userDataModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM user_cabangs LIMIT {order.ToString()},1", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        model.username = rd["username"].ToString();
                        model.api_key = rd["nama"].ToString();
                        model.password = rd["password"].ToString();
                        model.uuid = rd["uuid"].ToString(); 
                        model.role = rd["role"].ToString();
                        model.level = rd["levelusr"].ToString();
                        model.cabang_id = rd["cabang_id"].ToString();
                        model.token = rd["api_key"].ToString();
                    }
                }
            }
            return model;
        }

        public userDataModel Atas()
        {
            order = 0;
            var model = new userDataModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM user_cabangs LIMIT {order},1", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        model.username = rd["username"].ToString();
                        model.api_key = rd["nama"].ToString();
                        model.password = rd["password"].ToString();
                        model.uuid = rd["uuid"].ToString();
                        model.role = rd["role"].ToString();
                        model.level = rd["levelusr"].ToString();
                        model.cabang_id = rd["cabang_id"].ToString();
                        model.token = rd["api_key"].ToString();
                    }
                }
            }
            return model;
        }

        public userDataModel Next()
        {
            if (order == limit())
            {
                order = limit();
            }
            else
            {
                order++;
            }
            var model = new userDataModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM user_cabangs LIMIT {order.ToString()},1", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        model.username = rd["username"].ToString();
                        model.api_key = rd["nama"].ToString();
                        model.password = rd["password"].ToString();
                        model.uuid = rd["uuid"].ToString();
                        model.role = rd["role"].ToString();
                        model.level = rd["levelusr"].ToString();
                        model.cabang_id = rd["cabang_id"].ToString();
                        model.token = rd["api_key"].ToString();
                    }
                }
            }
            return model;
        }

        public userDataModel Prev()
        {
            if (order == 0)
            {
                order = 0;
            }
            else
            {
                order--;
            }
            var model = new userDataModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM user_cabangs LIMIT {order.ToString()},1", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        model.username = rd["username"].ToString();
                        model.api_key = rd["nama"].ToString();
                        model.password = rd["password"].ToString();
                        model.uuid = rd["uuid"].ToString();
                        model.role = rd["role"].ToString();
                        model.level = rd["levelusr"].ToString();
                        model.cabang_id = rd["cabang_id"].ToString();
                        model.token = rd["api_key"].ToString();
                    }
                }
            }
            return model;
        }

        public userDataModel listTake(string name)
        {
            var model = new userDataModel();
            using (var cmd = new MySqlCommand($"SELECT * FROM user_cabangs where username='{name}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        model.username = rd["username"].ToString();
                        model.api_key = rd["nama"].ToString();
                        model.password = rd["password"].ToString();
                        model.uuid = rd["uuid"].ToString();
                        model.role = rd["role"].ToString();
                        model.level = rd["levelusr"].ToString();
                        model.cabang_id = rd["cabang_id"].ToString();
                        model.token = rd["api_key"].ToString();
                    }
                }
            }
            return model;
        }
    }
}
