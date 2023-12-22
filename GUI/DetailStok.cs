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

namespace KasirApp.GUI
{
    public partial class DetailStok : Form
    {
        Operator op = new Operator();
        string tanggal1;
        string tanggal2;

        public DetailStok()
        {
            InitializeComponent();
            tgl1.Value = DateTime.Now;
            tgl2.Value = DateTime.Now;
            tanggal1 = tgl1.Value.ToString("yyyy/MM/dd 00:00:00");
            tanggal2 = tgl2.Value.ToString("yyyy/MM/dd 23:00:00");
            setDatagrid();
        }

        public void RaiseButton(object sender, EventArgs e)
        {
            tanggal1 = tgl1.Value.ToString("yyyy/MM/dd 00:00:00");
            tanggal2 = tgl2.Value.ToString("yyyy/MM/dd 23:00:00");
            setDatagrid();
        }

        public void setDatagrid()
        {
            DataTable dt = new DataTable();
            using (var cmd = new MySqlCommand($"SELECT Barcode,Nama,Stok FROM view_stok_minimum WHERE Tanggal BETWEEN '{tanggal1}' AND '{tanggal2}' AND Stok <= 0", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    dt.Load(rd);
                    DGV1.Refresh(); 
                    DGV1.DataSource = dt;
                }
            }
            using (var cmda = new MySqlCommand($"SELECT Barcode,Nama,Stok FROM view_stok_minimum WHERE Tanggal BETWEEN '{tanggal1}' AND '{tanggal2}' AND Stok > 0 AND Stok <= {op.CabangConfig().StokMinimum}", op.Conn))
            {
                DataTable dts = new DataTable();
                op.KonekDB();
                using (var rda = cmda.ExecuteReader())
                {
                    dts.Load(rda);
                    DGV2.Refresh();
                    DGV2.DataSource = dts;
                }
            }
        }
    }
}
