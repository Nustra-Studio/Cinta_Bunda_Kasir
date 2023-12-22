using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KasirApp.View;
using KasirApp.Model;
using KasirApp.Presenter;

namespace KasirApp.GUI.Supervisor
{
    
    public partial class batalPenyesuaian : Form,iBatalPost
    {
        iMasterForm _master;
        BatalPostPresenter _pres;
        userDataModel _user;
        public string nomerTrans { get => txtNomor.Text; set => txtNomor.Text = value; }
        public string alasan { get => txtAlasan.Text; set => txtAlasan.Text = value; }

        public batalPenyesuaian(iMasterForm mstr, userDataModel user)
        {
            InitializeComponent();
            _pres = new BatalPostPresenter(this, user);
            _master = mstr;
            _user = user;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (_pres.attemptBatalPenyesuaian() == true)
            {
                txtAlasan.Clear();
                txtNomor.Clear();
            }
        }

        private void batalPOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            _master.CloseForm();
        }
    }
}
