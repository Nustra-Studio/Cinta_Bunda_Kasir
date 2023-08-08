using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using KasirApp.Model;
using System.Net;
using Newtonsoft.Json;

namespace KasirApp.Repository
{
    class TransaksiRepo
    {
        //Fields
        MboxOperator mb = new MboxOperator();
        Operator op = new Operator();

        //Constructor
        public TransaksiRepo()
        {

        }

        //Method
        public void AmbilPoint(userDataModel model, string kode)
        {
            using (var client = new RestClient($"{op.urlcloud}cabangmember/"))
            {
                var rs = new RestRequest("poin", Method.Get);
                rs.AddParameter("pin", kode);
                rs.AddParameter("token", model.token);

                var response = client.Get(rs);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    mb.InformasiOK(response.Content.ToString() + response.StatusCode.ToString());
                }
                else if(response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var jso = response.Content.ToString();
                    apiError err = JsonConvert.DeserializeObject<apiError>(jso);
                    mb.PeringatanOK(err.message.ToString());
                }
            }
        }
    }
}
