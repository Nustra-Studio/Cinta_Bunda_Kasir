using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.View;
using KasirApp.Model;
using KasirApp.Repository;

namespace KasirApp.Presenter
{
    public class TransaksiPresenter
    {
        //Fields
        iTransaksi _trn;
        userDataModel _model;
        TransaksiRepo _repo;
        
        //Constructor
        public TransaksiPresenter(iTransaksi trans, userDataModel model)
        {
            _trn = trans;
            _model = model;
            _repo = new TransaksiRepo();
        }

        //Method TO Repo
        public void GetPoint()
        {
            string rand = _trn.randKode.ToString();
            _repo.AmbilPoint(_model,rand);
        }
    }
}
