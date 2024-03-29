﻿using System;
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
        userDataModel _model;
        Operator op = new Operator();
        TransferGudangPresenter _pres = new TransferGudangPresenter();
        ParentButtonPresenter _parpres = new ParentButtonPresenter();
        string table = "report_transfergudang";
        string viewTable = "view_dgv_transfergudang";
        DataTable dta;

        public TransferGudang(userDataModel model)
        {
            InitializeComponent();
            CenterToParent();
            dgv.AutoGenerateColumns = false;
            _model = model;
            dateTimePicker1.Text = DateTime.Now.ToString();
            getList();
            closedState();
            dgv.AutoGenerateColumns = false;
            dta = new DataTable();
            foreach (DataGridViewColumn item in dgv.Columns)
            {
                dta.Columns.Add(item.Name);
            }
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
        }

        public void Bot()
        {
            ChangeOrder(_pres.bawah());
        }

        public void delete()
        {
            if (chkVoid.Checked == true)
            {
                _pres.deleteSent(_model);
            } 
        }

        public void exit()
        {

        }

        public void list()
        {
            var pop = new PopUp(this);
            pop.getDataList("Select keterangan, id_transfer AS 'NomerTrans' from report_transferGudang", "Select keterangan, id_transfer AS 'nomerTrans' FROM report_transfergudang where id_transfer=");
            pop.Show();
        }

        public void next()
        {
            ChangeOrder(_pres.lanjut());
        }

        public void prev()
        {
            ChangeOrder(_pres.sebelum());
        }

        public void print()
        {
            if (txtNomorPTG.Text != "")
            {
                _pres.PrintData(txtNomorPTG.Text);
            }
        }

        public void edit()
        {
            return;
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
            dgv.DataSource = _parpres.gridByValue(viewTable, "nomerTrans", md.NomerTrans);
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
                dta.Rows.Add(item.kode_barang, item.name, item.stok, item.merek_barang, item.harga, item.harga_pokok, item.harga_grosir);
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
            txtKeterangan.Focus();
            txtKeterangan.ReadOnly = false;
            txtNomorPTG.ReadOnly = true;
        }

        public void RaiseKeydown(object sender, KeyEventArgs e)
        {
            var listBarang = new List<TfGudangAPI>();
            if (e.KeyCode == Keys.F1)
            {
                this.Cursor = Cursors.WaitCursor;
                listBarang = _pres.ambilData(_model);
                txtKeterangan.ReadOnly = false;
                txtKeterangan.Enabled = true;
                if (listBarang.Count == 0)
                {
                    MessageBox.Show("Tidak ada Barang yang dikirim", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    long nomorKwitansi = _pres.AmbilNumbering();
                    txtNomorPTG.Text = $"PTG-{nomorKwitansi.ToString()}";

                    foreach (var md in listBarang)
                    {
                        md.harga_grosir = md.harga_grosir ?? "0";
                        md.harga = md.harga ?? "0";
                        md.harga_pokok = md.harga_pokok ?? "0";
                        md.harga_jual = md.harga_jual ?? "0";

                        dta.Rows.Add(md.kode_barang, md.name, md.stok, md.merek_barang, md.harga, md.harga_pokok, md.harga_jual, md.harga_grosir);
                    }
                    _pres.Sementara(listBarang, txtNomorPTG.Text);
                    WriteState();
                    dgv.DataSource = dta;
                }
                this.Cursor = Cursors.Default;
            }
            else if (e.KeyCode == Keys.F3)
            {
                listBarang = _pres.ambilData(_model);
                _pres.Insert(listBarang, txtNomorPTG.Text, txtKeterangan.Text, _model);
                op.insertHistoriUser(_model, this.Text, "Simpan Tf Gudang");
                if (txtKeterangan.Text != "")
                {
                    closedState();
                    dta.Rows.Clear();
                    Bot();
                }
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
