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
    class addMemberPresenter
    {
        //Fields
        iMember _mem;
        userDataModel _user;
        MemberRepo _repo = new MemberRepo();
        MboxOperator mb = new MboxOperator();

        public addMemberPresenter(userDataModel user, iMember mem)
        {
            _user = user;
            _mem = mem;
        }

        public void Daftar()
        {
            var model = new MemberModel();
            model.Token = _user.token.ToString();
            model.Password = "12345678";
            model.Nama = _mem.nama.ToString();
            model.Email = _mem.email.ToString();
            model.Alamat = _mem.alamat.ToString();
            model.Phone = _mem.telpon.ToString();

            _repo.Regist(model);
        }

        internal bool AttemptReset()
        {
            var model = new MemberModel();
            model.Token = _user.token.ToString();
            model.Email = _mem.email.ToString();
            model.Phone = _mem.telpon.ToString();
            model.Password = "12345678";
            return _repo.ResetPassword(model);
        }
    }
}
