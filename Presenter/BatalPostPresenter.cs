using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.View;
using KasirApp.Repository;
using KasirApp.Model;

namespace KasirApp.Presenter
{
    class BatalPostPresenter
    {
        iBatalPost _batal;
        userDataModel _user;
        BatalPostRepo _repo;
        public BatalPostPresenter(iBatalPost btl, userDataModel user)
        {
            _batal = btl;
            _user = user;
            _repo = new BatalPostRepo(user);
        }

        public bool attemptBatalPOS()
        {
            var model = new BatalPostModel();
            model.NomerTrans = _batal.nomerTrans;
            model.Alasan = _batal.alasan;

            return _repo.batalPOS(model);
        }

        public bool attemptBatalPenyesuaian()
        {
            var model = new BatalPostModel();
            model.NomerTrans = _batal.nomerTrans;
            model.Alasan = _batal.alasan;

            return _repo.batalPenyesuaian(model);
        }

        public bool attemptBatalTransferGudang()
        {
            var model = new BatalPostModel();
            model.NomerTrans = _batal.nomerTrans;
            model.Alasan = _batal.alasan;

            return _repo.batalTransferGudang(model);
        }

        public bool attemptBatalOpnames()
        {
            var model = new BatalPostModel();
            model.NomerTrans = _batal.nomerTrans;
            model.Alasan = _batal.alasan;

            return _repo.batalOpname(model);
        }

        public bool attemptBatalRetur()
        {
            var model = new BatalPostModel();
            model.NomerTrans = _batal.nomerTrans;
            model.Alasan = _batal.alasan;

            return _repo.batalRetur(model);
        }
    }
}
