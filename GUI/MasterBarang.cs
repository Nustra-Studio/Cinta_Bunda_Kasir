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
using KasirApp.View;

namespace KasirApp.GUI
{
    public partial class MasterBarang : Form
    {
        Operator op = new Operator();
        SuplierModel sm = new SuplierModel();
        userDataModel _user;
        string select = null;
        iMasterForm _master;

        public MasterBarang(iMasterForm form, userDataModel user)
        {
            InitializeComponent();
            _master = form;
            _user = user;
            getData();
            fillCombo();
        }

        public void fillCombo()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
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
            }
            using (var client = new RestClient(op.url))
            {
                try
                {
                    var req = new RestRequest("supplier", Method.Get);
                    req.AddParameter("token", _user.token);
                    req.AddParameter("uuid", _user.cabang_id);

                    var res = client.Execute(req);

                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var list = JsonConvert.DeserializeObject<List<SuplierModel>>(res.Content);

                        foreach (var item in list)
                        {
                            CekSupplier(item);
                            comboBox1.Items.Add(item.nama.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error!");
                }
            }
        }

        public void CekSupplier(SuplierModel model)
        {
            bool isExist = false;
            using (var cmd = new MySqlCommand($"SELECT * FROM supliers WHERE nama = '{model.nama}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        isExist = true;
                    }
                }
            }

            if (isExist == false)
            {
                using (var cmd = new MySqlCommand($"INSERT INTO supliers VALUES (null,SHA2('{model.nama}', 256), '{model.nama}', '{model.alamat}', '{model.telepon}', '{model.product}', '{model.keterangan}', '{model.category_barang_id}', '{op.myDatetime}', '{op.myDatetime}')", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
        }

        public void tombol(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemplus)
            {
                Insert frm = new Insert(this.getData, _master, _user);
                _master.subForm(frm);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Insert frm = new Insert(this.getData, _master, _user);
                _master.subForm(frm);
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
            DGV.DataSource = op.getAll("view_barang LIMIT 1000");
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
                DGV.DataSource = op.getAll("view_barang LIMIT 1000");
            }
            else if (comboBox1.Text == "" && comboBox2.Text == "")
            {
                DGV.DataSource = op.getAll("view_barang where Nama LIKE '%" + a + "%' OR Barcode LIKE '%" + a + "%' LIMIT 500");
            }
            else if(comboBox1.Text == "")
            {
                DGV.DataSource = op.getAll("view_barang where Nama LIKE '%" + a + "%' OR Barcode LIKE '%" + a + "%' AND Supplier LIKE '%" + b + "%' LIMIT 500");
            }
            else if(comboBox2.Text == "")
            {
                DGV.DataSource = op.getAll("view_barang where Nama LIKE '%" + a + "%' OR Barcode LIKE '%" + a + "%' AND Categori LIKE '%" + c + "%'  LIMIT 500");
            }
            else
            {
                DGV.DataSource = op.getAll("view_barang where Nama LIKE '%" + a + "%' OR Barcode LIKE '%" + a + "%' AND Supplier LIKE '%" + b + "%' AND Categori LIKE '%" + c + "%' LIMIT 500");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = comboBox1.Text;
            string c = comboBox2.Text;

            if (textBox1.Text == "" && comboBox1.Text == "" && comboBox2.Text == "")
            {
                //DGV.DataSource = op.getAll("view_barang where Nama LIKE '%" + a + "%' AND Supplier LIKE '" + b + "' AND Categori LIKE '" + c + "'");
                DGV.DataSource = op.getAll("view_barang LIMIT 1000");
            }
            else if (comboBox1.Text == "" && comboBox2.Text == "")
            {
                DGV.DataSource = op.getAll("view_barang where Nama LIKE '%" + a + "%' OR Barcode LIKE '%" + a + "%' LIMIT 500");
            }
            else if (comboBox1.Text == "")
            {
                DGV.DataSource = op.getAll("view_barang where Nama LIKE '%" + a + "%' OR Barcode LIKE '%" + a + "%' AND Supplier LIKE '%" + b + "%' LIMIT 500");
            }
            else if (comboBox2.Text == "")
            {
                DGV.DataSource = op.getAll("view_barang where Nama LIKE '%" + a + "%' OR Barcode LIKE '%" + a + "%' AND Categori LIKE '%" + c + "%'  LIMIT 500");
            }
            else
            {
                DGV.DataSource = op.getAll("view_barang where Nama LIKE '%" + a + "%' OR Barcode LIKE '%" + a + "%' AND Supplier LIKE '%" + b + "%' AND Categori LIKE '%" + c + "%' LIMIT 500");
            }
        }

        private void MasterBarang_FormClosing(object sender, FormClosingEventArgs e)
        {
            _master.CloseForm();
        }
    }
}
