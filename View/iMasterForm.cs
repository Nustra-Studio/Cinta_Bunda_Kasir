﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;
using System.Windows.Forms;

namespace KasirApp.View
{
    public interface iMasterForm
    {
        void Role(usrRole rl, userDataModel user);
        void addForm(Form frm);
        void subForm(Form frm);
        void CloseForm();
        void refreshMainPanel();
    }
}
