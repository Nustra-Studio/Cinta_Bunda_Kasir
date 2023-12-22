using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Repository;
using KasirApp.Model;
using KasirApp.View;

namespace KasirApp.Presenter
{
    class GroupPresenter
    {
        GroupRepo _repo = new GroupRepo();
        iGroup _grp;

        //Constructor 
        public GroupPresenter (iGroup grp)
        {
            _grp = grp;
        }

        public GroupModel top()
        {
            return _repo.takeTop();
        }

        public GroupModel Bot()
        {
            return _repo.takeBot();
        }

        public GroupModel next()
        {
            return _repo.takeNext();
        }

        public GroupModel prev()
        {
            return _repo.takePrev();
        }

        public bool attemptAdd()
        {
            var model = new GroupModel();
            model.Nama = _grp.nama;
            model.Kode = _grp.kode;
            model.Masters = _grp.master;
            model.Gudang = _grp.gudang;
            model.Penjualan = _grp.penjualan;
            model.Supervisor = _grp.supervisor;

            return _repo.addGroup(model);
        }

        public bool attemptDelete()
        {
            var model = new GroupModel();
            model.Nama = _grp.nama;
            model.Kode = _grp.kode;
            model.Masters = _grp.master;
            model.Gudang = _grp.gudang;
            model.Penjualan = _grp.penjualan;
            model.Supervisor = _grp.supervisor;

            return _repo.delGroup(model);
        }

        public bool attemptEdit()
        {
            var model = new GroupModel();
            model.Nama = _grp.nama;
            model.Kode = _grp.kode;
            model.Masters = _grp.master;
            model.Gudang = _grp.gudang;
            model.Penjualan = _grp.penjualan;
            model.Supervisor = _grp.supervisor;

            return _repo.editGroup(model);
        }

        public GroupModel popupData(string kode)
        {
            return _repo.takePopData(kode);
        }
    }
}
