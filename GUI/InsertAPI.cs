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
using RestSharp;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace KasirApp.GUI
{
    public partial class Insert : Form
    {
        Operator op = new Operator();
        public readonly Action _getData;
        string aName;
        public Insert(Action frm)
        {
            InitializeComponent();
            fillCombo();
            clearAll();
            _getData = frm;
        }

        public void clearAll()
        {
            gunaComboBox1.Text = "";
            gunaComboBox2.Text = "";
            txtBarang.Text = "";
            txtBarcode.Text = "";
            txtHarga.Text = "";
            txtMerek.Text = "";
            txtHargaJual.Text = "";
            txtLaba.Text = "0";
            txtPajak.Text = "11";
            txtGrosir.Text = "";
            txtHargapokok.Text = "";
            txtSTOK.Text = "0";
            txtKeterangan.Text = "";
            btnProses.Text = "Proses";
        }

        public bool isNull()
        {
            if (txtBarang.Text == "" || txtMerek.Text == "" || txtBarcode.Text == "" || txtHarga.Text =="" || txtSTOK.Text == "" || txtHargaJual.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool cekUnique()
        {
            using (MySqlCommand cmd = new MySqlCommand("select name,kode_barang from barangs where NAME=@nama and kode_barang=@kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("nama", txtBarang.Text);
                cmd.Parameters.AddWithValue("kode", txtBarcode.Text);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
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

        public void assignData(string name)
        {
            aName = name;
            using (MySqlCommand cmd = new MySqlCommand("Select * from view_barangs_all where Nama='" + name + "'",op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        decimal harga = Convert.ToDecimal(rd["Harga"].ToString());
                        decimal hargaJual = Convert.ToDecimal(rd["Harga Jual"].ToString());

                        txtBarang.Text = rd["Nama"].ToString();
                        txtMerek.Text = rd["Merk"].ToString();
                        txtKeterangan.Text = rd["Keterangan"].ToString();
                        gunaComboBox1.Text = rd["Categori"].ToString();
                        gunaComboBox2.Text = rd["Supplier"].ToString();
                        txtHarga.Text = rd["Harga"].ToString();
                        txtHargaJual.Text = rd["Harga Jual"].ToString();
                        txtGrosir.Text = rd["Harga Grosir"].ToString();
                        txtHargapokok.Text = rd["Harga Pokok"].ToString();
                        txtSTOK.Text = rd["Stok"].ToString();
                        txtBarcode.Text = rd["Barcode"].ToString();

                        btnProses.Text = "Update";
                    }
                }
            }
        }

        public void insData()
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO barangs VALUE(NULL,MD5(RAND()),(select uuid from category_barangs where name=@kategori),(select uuid from supliers where nama=@suplier),@kode,@harga,@hargajual,@hargapokok,@hargagrosir,@stok,@keterangan,@name,@merk,NULL,@tglbuat,@tglupdate)", op.Conn))
                {
                    cmd.Parameters.AddWithValue("kategori", gunaComboBox1.Text);
                    cmd.Parameters.AddWithValue("suplier", gunaComboBox2.Text);
                    cmd.Parameters.AddWithValue("kode", txtBarcode.Text);
                    cmd.Parameters.AddWithValue("harga", txtHarga.Text);
                    cmd.Parameters.AddWithValue("hargajual", txtHargaJual.Text);
                    cmd.Parameters.AddWithValue("hargapokok", txtHarga.Text);
                    cmd.Parameters.AddWithValue("hargagrosir", txtGrosir.Text);
                    cmd.Parameters.AddWithValue("stok", txtSTOK.Text);
                    cmd.Parameters.AddWithValue("keterangan", txtKeterangan.Text);
                    cmd.Parameters.AddWithValue("name", txtBarang.Text);
                    cmd.Parameters.AddWithValue("merk", txtMerek.Text);
                    cmd.Parameters.AddWithValue("tglbuat", DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
                    cmd.Parameters.AddWithValue("tglupdate", DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));

                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    clearAll();
                    MessageBox.Show("Item Berhasil Di Insert", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _getData();
                    op.KonekDB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void upData()
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("UPDATE barangs SET category_id=(SELECT uuid FROM category_barangs WHERE name=@kategori)" +
                    "                                       ,name=@name,id_supplier= (SELECT uuid FROM supliers where nama=@suplier),kode_barang=@kode,harga=@harga" +
                    "                                       ,harga_jual=@hargajual,harga_pokok=@hargapokok,harga_grosir=@hargagrosir" +
                    "                                       ,stok=@stok,keterangan=@keterangan" +
                    "                                       ,merek_barang=@merk" +
                    "                                       ,updated_at=@tglUpdate WHERE name='" + aName + "'", op.Conn))
                {
                    cmd.Parameters.AddWithValue("kategori", gunaComboBox1.Text);
                    cmd.Parameters.AddWithValue("suplier", gunaComboBox2.Text);
                    cmd.Parameters.AddWithValue("kode", txtBarcode.Text);
                    cmd.Parameters.AddWithValue("harga", txtHarga.Text);
                    cmd.Parameters.AddWithValue("hargajual", txtHargaJual.Text);
                    cmd.Parameters.AddWithValue("hargapokok", txtHarga.Text);
                    cmd.Parameters.AddWithValue("hargagrosir", txtGrosir.Text);
                    cmd.Parameters.AddWithValue("stok", txtSTOK.Text);
                    cmd.Parameters.AddWithValue("keterangan", txtKeterangan.Text);
                    cmd.Parameters.AddWithValue("name", txtBarang.Text);
                    cmd.Parameters.AddWithValue("merk", txtMerek.Text);
                    cmd.Parameters.AddWithValue("tglbuat", DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
                    cmd.Parameters.AddWithValue("tglupdate", DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));

                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    clearAll();
                    MessageBox.Show("Item Berhasil Di Update", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _getData();
                    this.Hide();
                    this.Close();
                    op.KonekDB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void fillCombo()
        {
            using (MySqlCommand cmd = new MySqlCommand("select * from category_barangs",op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        gunaComboBox1.Items.Add(rd["name"].ToString());
                    }
                }
                op.KonekDB();
            }using (MySqlCommand cmd = new MySqlCommand("select * from supliers",op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        gunaComboBox2.Items.Add(rd["nama"].ToString());
                    }
                }
                op.KonekDB();
            }
            //using (var client = new RestClient(op.urlcloud))
            //{
            //    var request = new RestRequest("supplier");
            //    request.AddParameter("token", "FprPbNY8WewfFpKrA8Ppy4clot2Z5xWOiuA6uVGt");
            //    RestResponse res = client.GetAsync(request).Result;

            //    var jso = res.Content.ToString();

            //    List<SuplierModel> dn = JsonConvert.DeserializeObject<List<SuplierModel>>(jso);

            //    foreach (var item in dn)
            //    {
            //        gunaComboBox2.Items.Add(item.nama.ToString());
            //    }
            //}
        }

        private void Insert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnProses_Click(sender,e);
            }
        }   

        public void btnProses_Click(object sender, EventArgs e)
        {
            if (isNull()==true)
            {
                MessageBox.Show("Tolong Lengkapi Data");
            }
            else if(cekUnique()==true)
            {
                MessageBox.Show("Sudah Ada");
            }
            else if (btnProses.Text == "Proses")
            {
                insData();
            }
            else
            {
                upData();
            }
        }

        public void DigitOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar);
        }

        private void txtHarga_TextChanged(object sender, EventArgs e)
        {
            if (txtHarga.Text == "" || txtLaba.Text == "" || txtPajak.Text == "" || txtSTOK.Text == "")
            {
                return;
            }
            else
            {
                decimal harga = Convert.ToDecimal(txtHarga.Text);
                decimal Laba = Convert.ToDecimal(txtLaba.Text);
                decimal Pajak = Convert.ToDecimal(txtPajak.Text);
                decimal stok = Convert.ToDecimal(txtSTOK.Text);

                decimal perPCS = harga + (harga * Laba / 100) + (harga * Pajak / 100);
                decimal total = stok * (harga * Laba / 100);

                lblHarga.Text = "Rp." + harga.ToString();
                txtHargaJual.Text = perPCS.ToString();
                lblLaba.Text = "Rp." + Convert.ToString(harga * Laba / 100);
                lblPajak.Text = "Rp." + Convert.ToString(harga * Pajak / 100);
                lblperPCS.Text = "Rp." + perPCS.ToString();
                lblTotal.Text = "Rp." + total.ToString();
            }
        }
    }
}
