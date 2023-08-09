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
    public partial class Transaksi : Form,iTransaksi
    {
        //Fields
        public static Transaksi instance;
        public TextBox tb;
        Operator op = new Operator();
        MySqlDataReader rd;
        userDataModel _user;
        TransaksiPresenter _prn;
        int i;

        //Interface Fields
        public string randKode { get => txtRandKode.Text; set => txtRandKode.Text = value ; }

        //Intercase Method
        public void GetMember(RootMember rootmem)
        {
            txtPoint.Text = rootmem.poin.poin.ToString();
        }

        //Constructor
        public Transaksi(userDataModel user)
        {
            InitializeComponent();
            instance = this;
            tb = textBox1;
            i = 1;
            _user = user;
            _prn = new TransaksiPresenter(this, _user);
        }

        public void NumericOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public bool isNull()
        {
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void print()
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
        }   
    
        public void insert()
        {
            using (MySqlCommand cmd = new MySqlCommand("select * from barangs where kode_barang=@kode OR name=@kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@kode", textBox1.Text);
                op.KonekDB();
                using (rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (!rd.HasRows)
                    {
                        PopUp frm = new PopUp(null);
                        frm.Show();
                        frm.getBarang(textBox1.Text.ToString());
                    }
                    else
                    {
                        decimal qty = Convert.ToDecimal(textBox3.Text);
                        decimal harga = Convert.ToDecimal(rd["harga_jual"]);

                        decimal total = qty * harga;
                        dgv.Rows.Add(i, textBox1.Text, rd["name"], qty, rd["harga_jual"], total);

                        label9.Text = "0";

                        if (dgv.Rows.Count >= 2)
                        {
                            int sum = 0;
                            for (int a = 0; a < dgv.Rows.Count; ++a)
                            {
                                sum += Convert.ToInt32(dgv.Rows[a].Cells[5].Value);
                                label9.Text = "Total = " + sum.ToString();
                            }
                        }
                        else
                        {
                            label9.Text = "Total : " + total.ToString();
                        }
                        i++;
                        op.Conn.Close();

                    }
                }
            }

        }

        //Raise KeyEvent
        private void Transaksi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (isNull() == true)
                {
                    insert();
                }else
                {
                    insert();
                }
            }
            else if (e.KeyCode == Keys.Y)
            {
                print();
            }
        }

        public void RaiseEnterKode(object sender, KeyEventArgs e)
        {
            string RandNumber = txtRandKode.Text;
            if (e.KeyCode == Keys.Enter)
            {
                _prn.GetPoint();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength >= 4)
            {
                MySqlCommand cmd = new MySqlCommand("select harga_jual from barangs where kode_barang=@kode OR name=@kode", op.Conn);
                cmd.Parameters.AddWithValue("kode", textBox1.Text);
                MySqlDataReader rd;
                op.KonekDB();

                rd = cmd.ExecuteReader();

                rd.Read();
                if (rd.HasRows)
                {
                    textBox2.Text = rd["harga_jual"].ToString();
                    op.Conn.Close();
                }
                else
                {
                    op.Conn.Close();
                    return;
                }
                op.Conn.Close();
            }
            else
            {
                return;
            }
        }

        public void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Cinta Bunda", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75,10));

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                e.Graphics.DrawString(dgv.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(80,10));
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        
        private void btnProses_Click(object sender, EventArgs e)
        {
            AddMember fra = new AddMember(_user);
            if (fra.IsDisposed)
            {
                fra.Show();
            }
            else
            {
                fra.Show();
                fra.BringToFront();
            }
        }

        
    }
}
