﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class DepartemenModel
    {
        //Fields
        private int id;
        private string uuid;
        private string kode;
        private string nama;
        private int kenaDiskon;
        private int isGrosir;

        //Properties
        public int Id { get => id; set => id = value; }
        public string Uuid { get => uuid; set => uuid = value; }
        public string Kode { get => kode; set => kode = value; }
        public string Nama { get => nama; set => nama = value; }
        public int KenaDiskon { get => kenaDiskon; set => kenaDiskon = value; }
        public int IsGrosir { get => isGrosir; set => isGrosir = value; }
    }
}
