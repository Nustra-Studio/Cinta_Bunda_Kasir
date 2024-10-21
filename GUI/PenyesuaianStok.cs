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
using KasirApp.View;
using KasirApp.Model;
using KasirApp.Report;

namespace KasirApp.GUI
{
    public partial class PenyesuaianStok : Form,iParentDock,iPenyesuaian,iPopUpRecieve
    {
        PenyesuaianPresenter _pres;
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        userDataModel _user;
        iMasterForm _master;
        DataTable _dt;
        string nomerTrans;
        string select;
        bool editState;

        public string nomerPAD { get => txtNomer.Text; set => txtNomer.Text = value; }
        public string keterangan { get => txtKeterangan.Text; set => txtKeterangan.Text = value; }

        //Constructor
        public PenyesuaianStok(iMasterForm form, userDataModel user)
        {
            InitializeComponent();
            CenterToParent();
            _master = form;
            _user = user;
            nomerTrans = txtNomer.Text;
            _pres = new PenyesuaianPresenter(null, this);
            editState = false;
            Bot();
        }

        //Method Interfaces
        public void add()
        {
            if (txtKeterangan.Enabled == false)
            {
                var model = _pres.loadHeader();
                if (model != null)
                {
                    txtNomer.Text = model.nomerTrans;
                    txtKeterangan.Text = model.keterangan;
                    checkStatus(model.status);
                }
                else
                {
                    long nomor = _pres.AmbilNomer();
                    txtNomer.Text = $"PAD-{nomor.ToString()}";
                }
                txtNomer.Enabled = true;
                txtNomer.Focus();
                clearDGV();
            }
            else
            {
                if (txtKeterangan.Text == "")
                {
                    mb.PeringatanOK("Masukan Keterangan");
                }
                else
                {
                    var frm1 = new SubPenyesuaian(this, txtNomer.Text);
                    _master.subForm(frm1);
                }
            }
            editState = true;
        }

        public void Bot()
        {
            ChangeOrder(_pres.bawah());
        }

        public void delete()
        {
            if (txtNomer.Enabled == false && txtKeterangan.Enabled == false)
            {
                if (chkPosted.Checked == true)
                {
                    mb.PeringatanOK("Data sudah Posted tidak bisa Di Hapus!");
                }
                else
                {
                    _pres.hapusData();
                    Bot();
                }
            }
            else if(txtNomer.Text == "")
            {
                mb.PeringatanOK("Pilih Data yang akan dihapus");         
            }
            else
            {
                mb.PeringatanOK("Data yang sedang di edit tidak bisa Di Hapus");
            }
        }

        public void exit()
        {

        }

        public void list()
        {
            var pop = new PopUp(this);
            pop.getDataList("SELECT * FROM view_popup_penyesuaian", "SELECT * FROM view_popup_penyesuaian WHERE nomerTrans LIKE ");
            pop.Show(); 
            _pres.showList();
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
            _pres.printData();
        }

        public void edit()
        {
            if (chkPosted.Checked == true)
            {
                mb.PeringatanOK("Data sudah Posted Tidak bisa Di edit");
            }
            else
            {
                if (txtKeterangan.Text == "" && DGV.Rows.Count == 0)
                {
                    mb.PeringatanOK("Belum ada Data untuk Di edit");
                }
                else
                {
                    editState = true;
                    txtKeterangan.Enabled = true;
                }
            }
        }

        public void top()
        {
            ChangeOrder(_pres.atas());
        }

        //Method PopUp
        public void GetPopUpData(BarangsModel model)
        {
            txtNomer.Clear();
            txtNomer.Text = model.Nama;
            RefreshDGV();
            ChangeOrder(_pres.loadHeader());
        }

        //Method iPenyesuaian
        public void RefreshDGV()
        {
            _dt = _pres.MuatDGV(txtNomer.Text);
            DGV.DataSource = _dt;
            //pick header Details
        }

        //Local Method
        public void clearDGV()
        {
            if (_dt != null)
            {
            _dt.Clear();
            }
            DGV.DataSource = _dt;
            txtNomer.Clear();
            txtKeterangan.Clear();
            checkStatus(0);
            DGV.Refresh();
        }

        public void ChangeOrder(PenyesuaianModel model)
        {
            if (model == null)
            {
                editState = false;
                return;
            }
            else
            {
                txtNomer.Enabled = false;
                txtKeterangan.Enabled = false;
                txtNomer.Text = model.nomerTrans;
                txtKeterangan.Text = model.keterangan;
                RefreshDGV();
                checkStatus(model.status);
                editState = false;
            }
        }

        public void checkStatus(int stat)
        {
            if (stat == 1)
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

        public void RaiseKeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (txtNomer.Focused == true)
                {
                    long nomor = _pres.AmbilNomer();
                    txtNomer.Text = $"PAD-{nomor.ToString()}";
                    var model = _pres.loadHeader();
                    if (model != null)
                    {
                        txtNomer.Text = model.nomerTrans;
                        txtKeterangan.Text = model.keterangan;
                        checkStatus(model.status);
                    }
                    txtNomer.Enabled = false;
                    txtKeterangan.Enabled = true;
                    txtKeterangan.Focus();
                    RefreshDGV();
                }
            }
            if (e.KeyCode == Keys.F3)
            {
                if (_pres.SaveStok()==true)
                {
                    Bot();
                    op.insertHistoriUser(_user, this.Text, "Simpan Penyesuaian Stok");
                }
                else
                {
                    return;
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (editState == false)
                {
                    mb.PeringatanOK("Silakan Tekan Edit Terlebih Dahulu");
                }
                else
                {
                    _pres.hapus(select);
                    RefreshDGV();
                }
            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                select = DGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                return;
            }
        }

       
    }
}
