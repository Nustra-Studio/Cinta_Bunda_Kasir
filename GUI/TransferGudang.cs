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
using KasirApp.Repository;
using KasirApp.Model;

namespace KasirApp.GUI
{
    public partial class TransferGudang : Form,iParentDock,iPopUpRecieve
    {
        string select;
        userDataModel _model;
        MboxOperator mb = new MboxOperator();
        Operator op = new Operator();
        TransferGudangPresenter _pres = new TransferGudangPresenter();
        ParentButtonPresenter _parpres = new ParentButtonPresenter();
        string table = "report_transfergudang";
        string viewTable = "view_dgv_transfergudang";
        bool editState = false;
        DataTable dta;

        public TransferGudang(userDataModel model)
        {
            InitializeComponent();
            CenterToParent();
            dgv.AutoGenerateColumns = false;
            _model = model;
            tglTransfer.Text = DateTime.Now.ToString();
            getList();
            closedState();
            dgv.AutoGenerateColumns = false;
            dta = new DataTable();
            foreach (DataGridViewColumn item in dgv.Columns)
            {
                dta.Columns.Add(item.Name);
            }
            tglTransfer.Value = DateTime.Now;
            Bot();
        }

        //Interface Method
        public void add()
        {
            if (dta != null)
            {
                dta.Rows.Clear();
                dgv.Refresh();
                openState();
            }
            editState = false;
        }

        public void Bot()
        {
            ChangeOrder(_pres.bawah());
            editState = false;
        }

        public void delete()
        {
            if (txtNomorPTG.Text == null)
            {
                MessageBox.Show("Nomer Transaksi Kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (chkVoid.Checked == true)
            {
                _pres.deleteSent(_model, txtNomorPTG.Text);
                Bot();
            } 
            editState = false;
        }

        public void exit()
        {

        }

        public void list()
        {
            var pop = new PopUp(this);
            pop.getDataList("Select keterangan, id_transfer AS 'NomerTrans' from report_transferGudang", "Select keterangan, id_transfer AS 'nomerTrans' FROM report_transfergudang where id_transfer=");
            pop.Show();
            editState = false;
        }

        public void next()
        {
            ChangeOrder(_pres.lanjut());
            editState = false;
        }

        public void prev()
        {
            ChangeOrder(_pres.sebelum());
            editState = false;
        }

        public  void print()
        {
            if (txtNomorPTG.Text != "")
            {
                _pres.PrintData(txtNomorPTG.Text);
            }
        }

        public void edit()
        {
            if(chkPosted.Checked == true)
            {
                mb.PeringatanOK("Data yang sudah ter posted tidak bisa di edit");
            }
            else
            {
                editState = true;
                WriteState();
            }
        }

        public void top()
        {
            ChangeOrder(_pres.atas());
        }

        //Pop up interface
        public void GetPopUpData(BarangsModel model)
        {
            var md = _parpres.headerDataByValue(table, "id_transfer", model.Nama);
            txtNomorPTG.Text = md.NomerTrans;
            txtKeterangan.Text = md.Keterangan;
            ChangeOrder(_pres.byValue(md.NomerTrans));
            //dgv.DataSource = _parpres.gridByValue(viewTable, "nomerTrans", md.NomerTrans);
        }

        public void ChangeOrder(TransferGudangModel model)
        {
            txtNomorPTG.Enabled = false;
            txtKeterangan.Enabled = false;
            if (model == null)
            {
                return;
            }
            else
            {
                setHeader(model);
                txtNomorPTG.Text = model.nomerTrans;
                txtKeterangan.Text = model.keterangan;
                RefreshDGV();
                //checkStatus(model.status);
                //editState = false;
            }
        }


        public void RefreshDGV()
        {
            if (dta != null)
            {
                dta.Rows.Clear();
            }
            dgv.Refresh();

            var list = _pres.MuatDGV(txtNomorPTG.Text);

            foreach (var item in list)
            {
                dta.Rows.Add(item.kode_barang, item.name, item.stok, item.merek_barang, item.harga, item.harga_jual, item.harga_pokok, item.harga_grosir);
            }

            dgv.DataSource = dta;
        }

        public void setHeader(TransferGudangModel model)
        {
            if (dgv.Rows.Count == 0)
            {

            }
            else
            {
                dgv.Refresh();
            }
            txtNomorPTG.Text = model.nomerTrans;
            txtKeterangan.Text = model.keterangan;
            if (model.status == "posted")
            {
                chkPosted.Checked = true;
                chkVoid.Checked = false;
            }
            else
            {
                chkPosted.Checked = false;
                chkVoid.Checked = true;
            }
        }

        public void closedState()   
        {
            txtNomorPTG.Text = "";
            txtKeterangan.Text = "";
            txtNomorPTG.ReadOnly = true;
            txtKeterangan.ReadOnly = true;
            chkPosted.Checked = false;
            chkVoid.Checked = true;
        }

        public void openState()
        {
            txtNomorPTG.Focus();
            txtNomorPTG.Text = "";
            txtNomorPTG.Enabled = true;
            txtNomorPTG.ReadOnly = false;
            txtKeterangan.Text = "";
            txtKeterangan.ReadOnly = true;
            chkPosted.Checked = false;
            chkVoid.Checked = true;
        }

        public void WriteState()
        {
            txtNomorPTG.ReadOnly = true;
            txtKeterangan.ReadOnly = false;
            txtKeterangan.Enabled = true;
            txtKeterangan.Focus();
        }
            
        public void RaiseKeydown(object sender, KeyEventArgs e)
        {
            var listBarang = new List<TfGudangAPI>();
            var tanggal = tglTransfer.Value.ToString("yyyy-MM-dd 00:00:00");
            if (e.KeyCode == Keys.F1)
            {
                this.Cursor = Cursors.WaitCursor;
                listBarang = _pres.ambilData(_model, tanggal);
                if (listBarang.Count == 0)
                {
                    MessageBox.Show("Tidak ada Barang yang dikirim", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    long nomorKwitansi = _pres.AmbilNumbering();
                    txtNomorPTG.Text = $"PTG-{nomorKwitansi.ToString()}";
                    dgv.DataSource  = _pres.Sementara(listBarang, txtNomorPTG.Text);

                    txtKeterangan.ReadOnly = false;
                    txtKeterangan.Enabled = true;
                    Bot();
                    WriteState();
                }
                this.Cursor = Cursors.Default;
            }
            else if (e.KeyCode == Keys.F3)
            {
                _pres.Insert(txtNomorPTG.Text, txtKeterangan.Text, _model);

                closedState();
                dta.Rows.Clear();
                Bot();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (txtNomorPTG.Text == null)
                {
                    MessageBox.Show("Nomer Transaksi Kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (editState == false)
                {
                    mb.PeringatanOK("Tekan Edit terlebih dahulu");
                }
                else if (chkPosted.Checked == true)
                {
                    mb.PeringatanOK("Data yang sudah ter posted tidak dapat di hapus");
                }
                else if(mb.KonfimasiYesNo("Hapus Data?"))
                {
                    _pres.deleteItem(select, txtNomorPTG.Text);
                    Bot();
                    editState = true;
                }
                editState = true;
            }
        }

        private void RaiseCellClicks(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                select = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                return;
            }
        }

        public void getList()
        {
            DataTable dt = new DataTable();
            _pres = new TransferGudangPresenter();
            try
            {
                dt = _pres.GetData();
            }
            catch (Exception)
            {
                return;
            }
        }

        
    }
}
