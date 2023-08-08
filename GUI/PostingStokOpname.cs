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

namespace KasirApp.GUI
{
    public partial class PostingStokOpname : Form,iPostingOpname
    {
        //Fields
        PostingOpnamePresenter _pres;
        string tanggalan;

        //Interface Fields
        public string tanggal { get => tanggalan; set => tanggalan = value; }

        //Constructor
        public PostingStokOpname()
        {
            InitializeComponent();
            //Declaratrion
            tanggalan = DateTime.Now.ToString("yyyy/MM/dd");
            _pres = new PostingOpnamePresenter(this);
        }

        //Raise Click Events
        private void RaiseClickPost(object sender, EventArgs e)
        {
            _pres.Posting();
        }
    }
}
