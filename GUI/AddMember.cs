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
using MySql.Data.MySqlClient;

namespace KasirApp.GUI
{
    public partial class AddMember : Form
    {
        Operator op = new Operator();
        //public readonly Action _getData;
        public AddMember()
        {
            InitializeComponent();
            CenterToParent();
            //_getData = frm;
        }

        public void clear()
        {
            txtNama.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            noHp.Text = string.Empty;
        }

        public bool cekUnique()
        {
            using (MySqlCommand cmd = new MySqlCommand("select nama from members where nama=@nama", op.Conn))
            {
                cmd.Parameters.AddWithValue("nama", txtNama.Text);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            if (cekUnique()==true)
            {
                MessageBox.Show("Data Sudah Ada");
            }
            else
            {
                op.KonekDB();
                using (MySqlCommand com = new MySqlCommand("insert into members values(null,md5(@nama),@nama,@telepon,@email,@password,null)", op.Conn))
                {
                    com.Parameters.AddWithValue("nama", txtNama.Text);
                    com.Parameters.AddWithValue("telepon", noHp.Text);
                    com.Parameters.AddWithValue("email",txtEmail.Text);
                    com.Parameters.AddWithValue("password",txtPassword.Text);
                    com.ExecuteNonQuery();
                    clear();
                }
            }
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
