using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KasirApp.Presenter;
using KasirApp.Model;
using KasirApp.View; 

namespace KasirApp.GUI
{
    public partial class PasswordReset : Form, iMember
    {
        addMemberPresenter _prn;
        userDataModel _user;
        Operator op = new Operator();

        public string nama { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string telpon { get => txtNoHP.Text; set => txtNoHP.Text = value; }
        public string email { get => txtEmail.Text; set => txtEmail.Text = value; }
        public string alamat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PasswordReset(userDataModel user, iMember mem)
        {   
            InitializeComponent();
            _prn = new addMemberPresenter(user, this);
            _user = user;
            CenterToScreen();
        }


        private void btnProses_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtNoHP.Text != "")
            {
                this.Cursor = Cursors.WaitCursor;
                if (_prn.AttemptReset() == true)
                {
                    txtEmail.Text = "";
                    txtNoHP.Text = "";
                    op.insertHistoriUser(_user, this.Text, "Reset Password");
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
