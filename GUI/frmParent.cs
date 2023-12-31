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

namespace KasirApp.GUI
{
    public partial class frmParent : Form
    {
        iParentDock _dock;
        iMasterForm _master;
        public frmParent(Form frm, iParentDock dck, iMasterForm mst)
        {
            InitializeComponent();
            ShowChild(frm);
            _dock = dck;
            _master = mst;
        }

        public void ShowChild(Form frm)
        {
            frm.TopLevel = false;
            background.Controls.Add(frm);
            frm.Show();
            frm.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            _master.CloseForm();
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            _dock.top();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _dock.add();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _dock.next();
        }

        private void btnPrevous_Click(object sender, EventArgs e)
        {
            _dock.prev();
        }

        private void btnBottom_Click(object sender, EventArgs e)
        {
            _dock.Bot();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _dock.delete();
        }

        //Edit
        private void btnFind_Click(object sender, EventArgs e)
        {
            _dock.edit();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            _dock.list();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            _dock.print();
        }
    }
}
