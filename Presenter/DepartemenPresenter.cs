﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.View;
using KasirApp.Model;
using KasirApp.Repository;

namespace KasirApp.Presenter
{
    class DepartemenPresenter
    {
        //Fields
        iDepartemen _dept;
        iParentDock _dock;
        DeptRepo _repo = new DeptRepo();
        MboxOperator mb = new MboxOperator();

        //Constructor
        public DepartemenPresenter(iDepartemen dep, iParentDock dock)
        {
            _dept = dep;
            _dock = dock;
        }

        //Crud Method
        public void Simpan()
        {
            var model = new DepartemenModel();
            model.Nama = _dept.nama;
            model.Kode = _dept.kode;
            model.KenaDiskon = _dept.kenaDiskon.Equals(true) ? 1 : 0;
            model.IsGrosir = _dept.grosir.Equals(true) ? 1 : 0;
            try
            {
                if (_repo.Insert(model)==true)
                {
                    _dept.startState();
                }
            }
            catch (ArgumentNullException)
            {
                mb.PeringatanOK("Lengkapi Data");
            }
        }

        public void EditData()
        {
            var model = new DepartemenModel();
            model.Nama = _dept.nama;
            model.Kode = _dept.kode;
            model.KenaDiskon = _dept.kenaDiskon.Equals(true) ? 1 : 0;
            model.IsGrosir = _dept.grosir.Equals(true) ? 1 : 0;
            try
            {
                if (_repo.edit(model) == true)
                {
                    _dept.startState();
                }
            }
            catch (ArgumentNullException)
            {
                mb.PeringatanOK("Lengkapi Data");
            }
        }

        public void hapus()
        {
            var model = new DepartemenModel();
            model.Kode = _dept.kode;
            try
            {
                _repo.Delete(model);
                _dept.showRd(_repo.topValue());
            }
            catch (ArgumentNullException)
            {
                mb.PeringatanOK("Lengkapi Data");
            }
        }

        public void showByList()
        {
            var model = new DepartemenModel();
            model.Kode = _dept.kode;
            _dept.showRd(_repo.showBykode(model));
        }

        //Direction Method
        public void atas()
        {
            _dept.showRd(_repo.topValue());
        }
       
        public void lanjut()
        {
            _dept.showRd(_repo.nextValue());
        }

        public void sebelum()
        {
            _dept.showRd(_repo.prevValue());
        }

        public void bawah()
        {
            _dept.showRd(_repo.botValue());
        }
    }
}
