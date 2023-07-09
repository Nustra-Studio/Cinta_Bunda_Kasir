using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KasirApp.Model
{
    class MboxOperator
    {
        public void PeringatanOK(string text)
        {
            MessageBox.Show(text,"Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void InformasiOK(string text)
        {
            MessageBox.Show(text,"Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool KonfimasiYesNo(string text)
        {
            DialogResult dr = MessageBox.Show(text, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PeringatanYesNo(string text)
        {
            DialogResult dr = MessageBox.Show(text, "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
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
