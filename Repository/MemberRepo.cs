﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using KasirApp.Model;
using RestSharp;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace KasirApp.Repository
{
    public class MemberRepo
    {
        //Fields
        Operator con = new Operator();
        MboxOperator mb = new MboxOperator();

        //constructor
        public MemberRepo()
        {

        }
       
        //method
        public void Regist(MemberModel  model)
        {
            try
            {
                using (RestClient rc = new RestClient($"{con.url}cabangmember/"))
                {
                    var body = new
                    {
                        token = model.Token,
                        data = new
                        {
                            nama = model.Nama,
                            email = model.Email,
                            password = model.Password,
                            alamat = model.Alamat,
                            phone = model.Phone
                        }
                    };

                    var rs = new RestRequest("register", Method.Post);
                    rs.AddHeader("Content-Type", "application/json");
                    rs.AddJsonBody(body);

                    var response = rc.Execute(rs);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        mb.InformasiOK("Berhasil Daftar Member");
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var jso = response.Content.ToString();
                        apiError err = JsonConvert.DeserializeObject<apiError>(jso);
                        mb.PeringatanOK(err.message.ToString());
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                mb.PeringatanOK(ex.Message);
                throw;
            }
        }

        internal bool ResetPassword(MemberModel model)
        {
            bool isSuccess = false; 
            using (var client = new RestClient($"{con.url}cabangmember/"))
            {
                var body = new
                {
                    token = model.Token,
                    nik = model.Email,
                    phone = model.Phone,
                    password = model.Password
                };

                var rq = new RestRequest("resetmember", Method.Post);
                rq.AddJsonBody(body);

                try
                {
                    var rs = client.Execute(rq);

                    if (rs.StatusCode == HttpStatusCode.OK)
                    {
                        mb.InformasiOK("Berhasil Reset Password");
                        isSuccess = true;
                    }
                    else if (rs.StatusCode == HttpStatusCode.NotFound)
                    {
                        mb.PeringatanOK("Data tidak ada");
                    }
                    Console.WriteLine(rs.Content.ToString());
                }
                catch (Exception ex)
                {
                    mb.PeringatanOK(ex.ToString());
                }
            }
            return isSuccess;
        }
    }
}

