using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KasirApp.Model;
using KasirApp.View;
using KasirApp.Presenter;
using MySql.Data.MySqlClient;

namespace KasirApp.GUI
{
    public partial class AddMember : Form,iMember
    {
        Operator op = new Operator();
        addMemberPresenter _prn;
        userDataModel _user;

        //InterFaces
        public string nama { get => txtNama.Text; set => txtNama.Text = value; }
        public string telpon { get => noHp.Text ; set => noHp.Text = value; }
        public string email { get => txtEmail.Text; set => txtEmail.Text = value; }
        public string alamat { get => txtAlamat.Text; set => txtAlamat.Text = value; }

        //public readonly Action _getData;
        public AddMember(userDataModel usr)
        {
            InitializeComponent();
            CenterToParent();
            _user = usr;
            _prn = new addMemberPresenter(_user, this);
            //_getData = frm;
        }

        public void clear()
        {
            txtNama.Text = string.Empty;
            txtEmail.Text = string.Empty;
            noHp.Text = string.Empty;
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            _prn.Daftar();
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
