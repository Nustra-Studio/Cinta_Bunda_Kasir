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
    class DepartemenPresenter
    {
        //Fields
        iDepartemen _dept;
        DeptRepo _repo = new DeptRepo();
        MboxOperator mb = new MboxOperator();
        public DepartemenPresenter(iDepartemen dep)
        {
            _dept = dep;
        }

        public void Simpan()
        {
            if (_dept.nama == null || _dept.kode == null)
            {
                mb.PeringatanOK("Lengkapi Data");
            }
            else
            {
                var model = new DepartemenModel();
                model.Nama = _dept.nama;
                model.Kode = _dept.kode;
                model.KenaDiskon = _dept.kenaDiskon;
                try
                {
                    _repo.Insert(model);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
