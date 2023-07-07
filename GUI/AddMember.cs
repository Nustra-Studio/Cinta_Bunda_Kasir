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
        public readonly Action _getData;
        public AddMember(Action frm)
        {
            InitializeComponent();
            _getData = frm;
        }

        public bool cekUnique()
        {
            using (MySqlCommand cmd = new MySqlCommand("select nama from members where nama=@nama", op.Conn))
            {
                cmd.Parameters.AddWithValue("nama", txtBarang.Text);
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
                using (MySqlCommand com = new MySqlCommand("insert into members values(null,md5('@nama'),@nama,@hp,'0',null,null)", op.Conn))
                {
                    com.Parameters.AddWithValue("nama", txtBarang.Text);
                    com.Parameters.AddWithValue("hp", gunaTextBox1.Text);
                    com.ExecuteNonQuery();
                    _getData();
                }
            }
        }
    }
}
