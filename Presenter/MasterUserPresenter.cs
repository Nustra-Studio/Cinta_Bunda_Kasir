using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;
using KasirApp.View;
using KasirApp.Repository;

namespace KasirApp.Presenter
{
    class MasterUserPresenter
    {
        MasterUserRepo _repo = new MasterUserRepo();
        userDataModel _usrdata;
        iUser _model;
        //Constructor
        public MasterUserPresenter(iUser user, userDataModel usrdata)
        {
            _model = user;
            _usrdata = usrdata;
        }

        public bool addnew()
        {
            var usr = new userDataModel();
            usr.username = _model.login;
            usr.password = _model.password;
            usr.uuid = _model.nama;
            usr.role = _model.group;
            usr.cabang_id = _usrdata.cabang_id;
            usr.token = _usrdata.token;

            return _repo.addBaru(usr);
        }

        public bool DeleteUser()
        {
            var usr = new userDataModel();
            usr.username = _model.login;

            return _repo.deleteUsr(usr, _usrdata);
        }

        public List<string> fillCombo()
        {
            return _repo.isiCombo();
        }

        public List<string> apiCombo()
        {
            return _repo.ComboAPI();
        }

        public userDataModel Bottom()
        {
            return _repo.Bawah();
        }
        public userDataModel Top()
        {
            return _repo.Atas();
        }
        public userDataModel Next()
        {
            return _repo.Next();
        }
        public userDataModel Prev()
        {
            return _repo.Prev();
        }

        public userDataModel tampilList(string name)
        {
            return _repo.listTake(name);
        }

        public bool editUser()
        {
            var usr = new userDataModel();
            usr.username = _model.login;
            usr.password = _model.password;
            usr.uuid = _model.nama;
            usr.role = _model.group;
            usr.cabang_id = _usrdata.cabang_id;
            usr.token = _usrdata.token;

            return _repo.editUsr(usr, _usrdata);
        }
    }
}
