using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using KasirApp.Model;
using RestSharp;
using Newtonsoft.Json;

namespace KasirApp.GUI
{
    public partial class MasterBarang : Form
    {
        Operator op = new Operator();
        SuplierModel sm = new SuplierModel();
        LoginTOKEN _lg;
        string select = null;

        public MasterBarang()
        {
            InitializeComponent();
            getData();
            fillCombo();
        }

        public void fillCombo()
        {
            //using (var client = new RestClient(op.urlcloud))
            //{
            //    FprPbNY8WewfFpKrA8Ppy4clot2Z5xWOiuA6uVGt
            //    var request = new RestRequest("supplier");
            //    request.AddParameter("token", _lg.token);
            //    RestResponse res = client.GetAsync(request).Result;

            //    var jso = res.Content.ToString();

            //    List<SuplierModel> dn = JsonConvert.DeserializeObject<List<SuplierModel>>(jso);

            //    foreach (var item in dn)
            //    {
            //        comboBox1.Items.Add(item.nama.ToString());
            //    }
            //}
            using (MySqlCommand cmd = new MySqlCommand("select * from category_barangs", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        comboBox2.Items.Add(rd["name"].ToString());
                    }
                }
                op.KonekDB();
            }using (MySqlCommand cmd = new MySqlCommand("select * from supliers", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        comboBox1.Items.Add(rd["nama"].ToString());
                    }
                }
                op.KonekDB();
            }
        }

        public void tombol(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                Insert frm = new Insert(this.getData);
                frm.Show();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Insert frm = new Insert(this.getData);
                frm.Show();
                frm.assignData(select);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DialogResult res = MessageBox.Show("Yakin Hapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    delete();
                }
                else
                {
                    return;
                }
            }
        }

        public void delete()
        {
            using (MySqlCommand cmd = new MySqlCommand("delete from barangs where name='" + select + "'",op.Conn))
            {
                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
                getData();
            }
        }

        public void getData()
        {
            DGV.Refresh();
            DGV.DataSource = op.getAll("view_barang");
            textBox1.Focus();
        }

        private void MasterBarang_KeyDown(object sender, KeyEventArgs e)
        {
            tombol(e);
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                select = DGV.Rows[e.RowIndex].Cells["Nama"].Value.ToString();
                using (MySqlCommand cmd = new MySqlCommand("select * from view_barang_detail where Name='" + select + "'", op.Conn))
                {
                    op.KonekDB();
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            gunaTextBox1.Text = rd["Kode"].ToString();
                            gunaTextBox2.Text = rd["Category"].ToString();
                            gunaTextBox3.Text = rd["Name"].ToString();
                            label18.Text = "Rp." + rd["Harga"].ToString();
                            gunaTextBox4.Text = rd["Harga Grosir"].ToString();
                            gunaTextBox5.Text = rd["Harga Jual"].ToString();
                            gunaTextBox6.Text = rd["Harga Pokok"].ToString();
                        }
                    }
                    op.KonekDB();
                }
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = comboBox1.Text;
            string c = comboBox2.Text;
            if (textBox1.Text == "" && comboBox1.Text == "" && comboBox2.Text == "")
            {
                //DGV.DataSource = op.getAll("view_barang where Nama LIKE '%" + a + "%' AND Supplier LIKE '" + b + "' AND Categori LIKE '" + c + "'");
                DGV.DataSource = op.getAll("view_barang");
            }
            else
            {
                DGV.DataSource = op.getAll("view_barang where Nama LIKE '%" + a + "%' AND Supplier LIKE '" + b + "' AND Categori LIKE '" + c + "'");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = comboBox1.Text;
            string c = comboBox2.Text;
            DGV.DataSource = op.getAll("view_barang where Nama LIKE '%" + a + "%' AND Supplier LIKE '%" + b + "%' AND Categori LIKE '%" + c + "%'");
        }
    }
}
