using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using KasirApp.Model;
using RestSharp;
using Newtonsoft.Json;

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
                using (RestClient rc = new RestClient($"{con.urlcloud}/cabangmember/"))
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

                    var response = rc.Post(rs);
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
    }
}

