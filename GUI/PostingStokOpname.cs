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
using KasirApp.Presenter;
using KasirApp.Model;

namespace KasirApp.GUI
{
    public partial class PostingStokOpname : Form,iPostingOpname
    {
        //Fields
        PostingOpnamePresenter _pres;
        Operator op = new Operator();
        userDataModel _user;
        iMasterForm _master;
        string tanggalan;

        //Interface Fields
        public string tanggal { get => tanggalan; set => tanggalan = value; }

        //Constructor
        public PostingStokOpname(iMasterForm mas, userDataModel user)
        {
            InitializeComponent();
            //Declaratrion
            //tanggalan = DateTime.Now.ToString("yyyy/MM/dd");
            tgl.Value = DateTime.Now;
            tanggalan = tgl.Value.Date.ToString("yyyy/MM/dd");
            _user = user;
            _master = mas;
            _pres = new PostingOpnamePresenter(this,_user);
        }

        //Raise Click Events
        private void RaiseClickPost(object sender, EventArgs e)
        {
            _pres.Posting();
            op.insertHistoriUser(_user, this.Text, "Posting Stok Opname");
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Hide();
            _master.CloseForm();
        }

        private void PostingStokOpname_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            _master.CloseForm();
        }
    }
}
