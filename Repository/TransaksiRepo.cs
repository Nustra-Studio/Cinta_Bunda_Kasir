﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using KasirApp.Model;
using MySql.Data.MySqlClient;
using System.Net;
using Newtonsoft.Json;
using System.Data;
using KasirApp.Report;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;
using ESCPOS_NET;
using ESCPOS_NET.Emitters;
using ESCPOS_NET.Utilities;
using System.Runtime.InteropServices;
using System.Xml;
using System.Globalization;

namespace KasirApp.Repository
{
    class TransaksiRepo
    {
        //Fields
        MboxOperator mb = new MboxOperator();
        Operator op = new Operator();
        userDataModel _user;
        string stateHJ;
        string nomerTransgb;
        float pageHeight;
        RootMember usr;
        //Constructor
        public TransaksiRepo(userDataModel user)
        {
            _user = user;
        }

        //Local Method
        public long AmbilNomor()
        {
            long nomor = 0;
            using (MySqlCommand cmd = new MySqlCommand("select PJC from numberingkwitansi", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        nomor = Convert.ToInt64(rd["PJC"].ToString());
                    }
                }
                op.KonekDB();
            }
            UpdateNumberint();
            return nomor;
        }


        public bool CekData(TransaksiModel model)
        {
            using (MySqlCommand cmd = new MySqlCommand("select * from barangs where kode_barang = @kode OR name = @kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@kode", model.Barkode);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
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

        public TransaksiModel getByValue(TransaksiModel model)
        {
            var md = new TransaksiModel();
            using (var cmd = new MySqlCommand("SELECT * FROM histori_penjualan WHERE barcode = @barcode AND nomerTrans = @noPJ", op.Conn))
            {
                cmd.Parameters.AddWithValue("@barcode", model.Barkode);//Nama = selection
                cmd.Parameters.AddWithValue("@noPJ", model.NomorPJ);

                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        md.Nama = rd["nama"].ToString();
                        md.Harga_jual = rd["harga_jual"].ToString();
                        md.Harga_pokok = rd["hpp"].ToString();
                        md.Diskon = rd["diskon"].ToString();
                        md.Quantity = rd["quantity"].ToString();
                        md.State = model.State;
                    }
                }
            }
            return md;
        }

        public TransaksiModel AmbilValueRead(TransaksiModel model)
        {
            var md = new TransaksiModel();
            using (MySqlCommand cmd = new MySqlCommand("select * from barangs where kode_barang = @kode OR name = @kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@kode", model.Barkode);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();

                    //Data AssignMent
                    md.NomorPJ = model.NomorPJ;
                    md.Nama = rd["name"].ToString();
                    md.Barkode = rd["kode_barang"].ToString();
                    md.Quantity = "1";
                    md.Harga_jual = rd["harga_jual"].ToString();
                    md.Harga_pokok = rd["harga_pokok"].ToString();
                    md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                    md.State = model.State;

                    //Logic
                    int qty = Convert.ToInt32(md.Quantity);
                    int HJ = Convert.ToInt32(md.Harga_jual);
                    int TotalPCS = qty * HJ;
                    md.Total = TotalPCS.ToString();

                }
            }
            return md;
        }

        //Cek Kesamaan pada saat insert
        public void CekRows(TransaksiModel md, RootMember mem)
        {
            bool adarow = false;
            int qty = 0;
            int total = 0;

            using (var cmd = new MySqlCommand($"SELECT * FROM barangs WHERE name='{md.Nama}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        md.Barkode = rd["kode_barang"].ToString();
                    }
                }
            }

            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomer AND nama = @nama OR nomerTrans = @nomer AND barcode = @barcode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", md.NomorPJ);
                cmd.Parameters.AddWithValue("@nama", md.Nama);
                cmd.Parameters.AddWithValue("@barcode", md.Barkode);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {   
                        qty =  Convert.ToInt32(rd["quantity"].ToString()) + 1;
                        md.Idkategori = rd["id_category"].ToString();
                        md.Diskon = rd["diskon"].ToString();
                        md.Quantity = qty.ToString();
                        md.Harga = rd[md.State].ToString();
                        total = qty * Convert.ToInt32(md.Harga) - Convert.ToInt32(rd["diskon"].ToString());
                        md.Total = total.ToString();
                        adarow = true;
                    }
                    else
                    {
                        rd.Close();
                        AmbilValue(md, mem);
                    }
                }
            }
            if (adarow == true)
            {
                int diskon = Convert.ToInt32(md.Diskon) + cekdiskon(md);
                md.Diskon = diskon.ToString();
                int final = total - diskon;
                using (MySqlCommand com = new MySqlCommand($"UPDATE histori_penjualan SET {md.State}=@harga, diskon = @diskon, quantity = @Qty, total = @total where nomerTrans = @nomor AND nama = @nama OR nomerTrans = @nomor AND barcode = @kode", op.Conn))
                {
                    com.Parameters.AddWithValue("nomor", md.NomorPJ);
                    com.Parameters.AddWithValue("harga", md.Harga);
                    com.Parameters.AddWithValue("@nama", md.Nama);
                    com.Parameters.AddWithValue("kode", md.Barkode);
                    com.Parameters.AddWithValue("diskon", diskon.ToString());
                    com.Parameters.AddWithValue("Qty", qty);
                    com.Parameters.AddWithValue("total", final);

                    md.Total = total.ToString();

                    op.KonekDB();
                    com.ExecuteNonQuery();
                    op.KonekDB();
                }
                cekGrosir(md);
            }
        }

        public void AmbilValue(TransaksiModel model, RootMember mem)
        {
            
            if (model.State == "hpp")
            {
                stateHJ = "harga_pokok";
            }
            else
            {
                stateHJ = model.State;
            }
            var md = new TransaksiModel();
            using (MySqlCommand cmd = new MySqlCommand("select * from barangs where kode_barang = @kode OR name = @kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@kode", model.Barkode);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();

                    //Data AssignMent
                    md.NomorPJ = model.NomorPJ;
                    md.Idkategori = rd["category_id"].ToString();
                    md.Nama = rd["name"].ToString();
                    md.Barkode = rd["kode_barang"].ToString();
                    md.Quantity = "1";
                    md.Harga_jual = rd["harga_jual"].ToString();
                    md.Harga_pokok = rd["harga_pokok"].ToString();
                    md.Satuan = rd["satuan"].ToString();
                    md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                    md.Id_member = model.Id_member;
                    md.State = model.State;

                    //Logic
                    int qty = Convert.ToInt32(md.Quantity);
                    int HJ = Convert.ToInt32(rd[stateHJ].ToString());
                    int TotalPCS = qty * HJ;
                    md.Total = TotalPCS.ToString();
                }
            }
            insertPJ(md, mem);
        }

        public void insertPJ(TransaksiModel model, RootMember mem)
        {
            string namaMember = "";
            if (mem == null)
            {
                namaMember = "";
            }
            else
            {
                namaMember = mem.member.name;
            }
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO histori_penjualan VALUES (null,md5(RAND()),@idkategori, @nomorPJ, @nama, @barcode, @quantity, @satuan, @HJ, @HPP, @Diskon, @Total, @user, @id_member,@status, @tanggal)", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomorPJ", model.NomorPJ);
                cmd.Parameters.AddWithValue("@@idkategori", model.Idkategori);
                cmd.Parameters.AddWithValue("@nama", model.Nama);
                cmd.Parameters.AddWithValue("@barcode", model.Barkode);
                cmd.Parameters.AddWithValue("@quantity", "1");//insert satu quantity
                cmd.Parameters.AddWithValue("@satuan", model.Satuan);//insert satu quantity
                cmd.Parameters.AddWithValue("@HJ", model.Harga_jual);
                cmd.Parameters.AddWithValue("@HPP", model.Harga_pokok);
                cmd.Parameters.AddWithValue("@Total", 1 * Convert.ToInt32(model.Total));
                cmd.Parameters.AddWithValue("@tanggal", op.myDatetime);
                cmd.Parameters.AddWithValue("@Diskon", "0");// Set Diskon ke 0
                cmd.Parameters.AddWithValue("@status", model.State);// Set Diskon ke 0
                cmd.Parameters.AddWithValue("@id_member", namaMember);
                cmd.Parameters.AddWithValue("@user", _user.username);

                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
            cekdiskon(model);
        }

        public SettingModel AmbilSetting()
        {
            var model = new SettingModel();
            using (var cmd = new MySqlCommand("Select * from settings", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        model.Karyawan = rd["presentase_karyawan"].ToString();
                        model.Karyawanacc = rd["karyawanacc"].ToString();
                        model.Reseller = rd["presentase_reseller"].ToString();
                        model.Reselleracc = rd["reselleracc"].ToString();
                        model.Autodiskon = rd["auto_diskon"].ToString();
                        model.StokMinimum = rd["stokMinimum"].ToString();
                    }
                }
            }
            return model;
        }

        int presentase;
        public void StateChange(string state, TransaksiModel model)
        {   
            var ListBarang = new List<TransaksiModel>();
            using (var cmd = new MySqlCommand("SELECT * FROM histori_penjualan where nomerTrans = '" + model.NomorPJ + "'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var md = new TransaksiModel();
                        md.Barkode = rd["barcode"].ToString();
                        md.Harga_pokok = rd["hpp"].ToString();
                        md.Diskon = rd["diskon"].ToString();
                        md.Harga = rd["hpp"].ToString();
                        md.Quantity = rd["quantity"].ToString();
                        md.Idkategori = rd["id_category"].ToString();
                        ListBarang.Add(md);
                    }
                }
            }

            foreach (var md in ListBarang)
            {
                bool isNoDiskon = false;
                bool isGrosir = false;
                bool isACC = false;

                string hjnodiskon = "";
                using (var cmd = new MySqlCommand($"SELECT * FROM barangs WHERE kode_barang = '{md.Barkode}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if (rd.HasRows)
                        {
                            hjnodiskon = rd["harga_jual"].ToString();
                            if (rd["nodiskon"].ToString() == "1")
                            {
                                isNoDiskon = true;
                            }
                        }
                    }
                }
                
                if (isNoDiskon == false)
                {
                    if (md.Idkategori != "")
                    {
                        using (var cmd = new MySqlCommand($"SELECT * FROM category_barangs WHERE uuid='{md.Idkategori}'", op.Conn))
                        {
                            op.KonekDB();
                            using (var rd = cmd.ExecuteReader())
                            {
                                rd.Read();
                                if (rd["grosir"].ToString() == "1")
                                {
                                    isGrosir = true;
                                }

                                if (rd["name"].ToString() == "ACC")
                                {
                                    isACC = true;
                                }
                            }
                        }
                    }

                    if (model.State == "hpp" && isGrosir == true)
                    {
                        stateHJ = "harga_jual";
                    }
                    else if (model.State == "hpp")
                    {
                        stateHJ = "harga_pokok";
                    }
                    else
                    {
                        stateHJ = "harga_jual";
                    }
                    int hpp = 0;
                    using (var cmd = new MySqlCommand("SELECT * from barangs where kode_barang = @barcode", op.Conn))
                    {
                        cmd.Parameters.AddWithValue("@barcode", md.Barkode);
                        using (var rd = cmd.ExecuteReader())
                        {
                            rd.Read();
                            if (rd.HasRows)
                            {
                                if (isGrosir == true && Convert.ToInt32(md.Quantity) >= 3)
                                {
                                    hpp = Convert.ToInt32(rd["harga_grosir"].ToString());
                                }
                                else
                                {
                                    hpp = Convert.ToInt32(rd[stateHJ].ToString());
                                }
                            }
                        }
                    }
                    int potongan = 0;
                    int totalstate = 0;
                    if (isGrosir == true)
                    {
                        totalstate = hpp;
                    }
                    else if (isACC == true)
                    {
                        if (state == "karyawan")
                        {
                            presentase = Convert.ToInt32(AmbilSetting().Karyawanacc);
                            potongan = hpp * presentase / 100;
                            totalstate = hpp + potongan;
                        }
                        else if (state == "reseller")
                        {
                            presentase = Convert.ToInt32(AmbilSetting().Reselleracc);
                            potongan = hpp * presentase / 100;
                            totalstate = hpp - potongan;//harga jual - presentase potongan
                        }
                        else if (state == "reguler")
                        {
                            totalstate = hpp;
                        }
                    }
                    else if (state == "karyawan")
                    {
                        presentase = Convert.ToInt32(AmbilSetting().Karyawan);
                        potongan = hpp * presentase / 100;
                        totalstate = hpp + potongan;
                    }
                    else if (state == "reseller")
                    {
                        presentase = Convert.ToInt32(AmbilSetting().Reseller);
                        potongan = hpp * presentase / 100;
                        totalstate = hpp - potongan;//harga jual - presentase potongan
                    }
                    else if (state == "reguler")
                    {
                        totalstate = hpp;
                    }
                    int rounded = Convert.ToInt32(CekRound(totalstate.ToString()));
                    int totalHpp = rounded * Convert.ToInt32(md.Quantity) - Convert.ToInt32(md.Diskon);
                    using (var cmd = new MySqlCommand("UPDATE histori_penjualan SET " + model.State + " = @hpp,total = @total, status=@state WHERE barcode = @barcode AND nomerTrans = @nomorPJ", op.Conn))
                    {
                        cmd.Parameters.AddWithValue("@hpp", rounded.ToString());
                        cmd.Parameters.AddWithValue("@total", totalHpp.ToString());
                        cmd.Parameters.AddWithValue("@barcode", md.Barkode);
                        cmd.Parameters.AddWithValue("@nomorPJ", model.NomorPJ);
                        cmd.Parameters.AddWithValue("@state", model.State);

                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                    }
                }
                else
                {
                    int rounded = Convert.ToInt32(CekRound(hjnodiskon.ToString()));
                    int totalHpp = rounded * Convert.ToInt32(md.Quantity) - Convert.ToInt32(md.Diskon);
                    using (var cmd = new MySqlCommand("UPDATE histori_penjualan SET " + model.State + " = @hpp,total = @total WHERE barcode = @barcode AND nomerTrans = @nomorPJ", op.Conn))
                    {
                        cmd.Parameters.AddWithValue("@hpp", rounded.ToString());
                        cmd.Parameters.AddWithValue("@total", totalHpp.ToString());
                        cmd.Parameters.AddWithValue("@barcode", md.Barkode);
                        cmd.Parameters.AddWithValue("@nomorPJ", model.NomorPJ);

                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                    }
                }
            }
        }

        public void UpdateNumberint()
        {
            long nomor = 0;
            using (MySqlCommand cmd = new MySqlCommand("Select PJC from numberingkwitansi", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        nomor = Convert.ToInt64(rd["PJC"]);
                    }
                }
                op.KonekDB();
            }
            long update = nomor + 1;
            using (MySqlCommand cmd = new MySqlCommand("UPDATE numberingkwitansi SET PJC = @value WHERE PJC = @Set", op.Conn))
            {
                cmd.Parameters.AddWithValue("value", update);
                cmd.Parameters.AddWithValue("Set", nomor);

                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
        }

        public DataTable SetView(TransaksiModel model)
        {
            UpdateHarga(model);
            var dt = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand("select barcode, nama, quantity, " + model.State + ", diskon, total from histori_penjualan where nomerTrans = '" + model.NomorPJ + "' ", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    dt.Load(rd);
                }
                op.KonekDB();
            }
            return dt;
        }

        public int cekdiskon(TransaksiModel model)
        {
            //Cek apakah Diskons
            bool kenaDiskon = false;
            int diskon = 0;
            using (var cmd = new MySqlCommand($"SELECT * FROM category_barangs WHERE uuid='{model.Idkategori}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        if (rd["diskon"].ToString() == "1")
                        {
                            kenaDiskon = true;
                        }
                    }
                }
            }
            if (kenaDiskon == true)
            {
                if (Convert.ToInt32(model.Quantity) % 3 == 0 && Convert.ToInt32(model.Quantity) < 13)
                {
                    diskon = Convert.ToInt32(op.CabangConfig().Autodiskon);
                }
            }
            return diskon;
        }

        public void cekGrosir(TransaksiModel model)
        {
            bool isGrosir = false;
            using (var cmd = new MySqlCommand($"select * from barangs where kode_barang='{model.Barkode}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        model.Harga_grosir = rd["harga_grosir"].ToString();
                        if (model.State == "hpp")
                        {
                            model.State = "harga_pokok";
                        }
                        model.Harga = rd[model.State].ToString();
                    }
                }
            }

            //Cek Apakah Grosir
            if (Convert.ToInt32(model.Quantity) >= 3 && model.Idkategori != "")
            {
                using (var cmd = new MySqlCommand($"SELECT * FROM category_barangs WHERE uuid='{model.Idkategori}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if (Convert.ToInt32(rd["grosir"].ToString()) == 1)
                        {
                            isGrosir = true;
                            rd.Close();
                        }
                    }
                }
            }
            else
            {
                isGrosir = false;
            }

            if (model.State == "harga_pokok")
            {
                model.State = "hpp";
            }

            var mdo = new TransaksiModel();
            if (isGrosir == true)
            {
                //Update Harga
                int total = Convert.ToInt32(model.Harga_grosir) * Convert.ToInt32(model.Quantity) - Convert.ToInt32(model.Diskon);
                using (var cmd = new MySqlCommand($"UPDATE histori_penjualan SET {model.State}='{model.Harga_grosir}', total='{total.ToString()}' WHERE barcode='{model.Barkode}' AND nomerTrans='{model.NomorPJ}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
            else
            {
                int total = Convert.ToInt32(model.Harga) * Convert.ToInt32(model.Quantity) - Convert.ToInt32(model.Diskon);
                using (var cmd = new MySqlCommand($"UPDATE histori_penjualan SET {model.State}='{model.Harga}', total='{total.ToString()}' WHERE barcode='{model.Barkode}' AND nomerTrans='{model.NomorPJ}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
        }

        public void UpdateDiskon(TransaksiModel model)
        {
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomor AND barcode = @barcode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomor", model.NomorPJ);
                cmd.Parameters.AddWithValue("@barcode", model.Barkode);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        int finalDiskon = Convert.ToInt32(rd["quantity"].ToString()) * Convert.ToInt32(model.Diskon);
                        int total = Convert.ToInt32(rd["quantity"].ToString()) * Convert.ToInt32(rd[model.State].ToString()) - finalDiskon;
                        using (MySqlCommand com = new MySqlCommand("UPDATE histori_penjualan SET diskon = @discon,total = @total where nomerTrans = @nomor AND barcode = @kode", op.Conn))
                        {
                            com.Parameters.AddWithValue("nomor", model.NomorPJ);
                            com.Parameters.AddWithValue("kode", model.Barkode);
                            com.Parameters.AddWithValue("discon", finalDiskon.ToString());
                            com.Parameters.AddWithValue("total", total);

                            op.KonekDB();
                            rd.Close();
                            com.ExecuteNonQuery();
                            op.KonekDB();
                        }
                    }
                }
            }
        }

        public void UpdateQuantity(TransaksiModel model)
        {
            string idKategori = "";
            using (var cmd = new MySqlCommand($"Select * from barangs WHERE kode_barang='{model.Barkode}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        idKategori = rd["category_id"].ToString();
                        model.Idkategori = idKategori;
                    }
                }
            }

            int diskon = cekdiskon(model);
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomor AND barcode = @barcode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomor", model.NomorPJ);
                cmd.Parameters.AddWithValue("@barcode", model.Barkode);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        model.Harga = rd[model.State].ToString();
                        model.Idkategori = rd["id_category"].ToString();
                        int finaldiskon = (Convert.ToInt32(model.Quantity) * Convert.ToInt32(rd["diskon"].ToString())) + diskon;
                        model.Diskon = finaldiskon.ToString();
                        int total1 = Convert.ToInt32(model.Quantity) * Convert.ToInt32(rd[model.State].ToString());
                        int total = total1 - finaldiskon;
                        using (MySqlCommand com = new MySqlCommand("UPDATE histori_penjualan SET quantity = @Qty, diskon=@diskon, total = @total where nomerTrans = @nomor AND barcode = @kode", op.Conn))
                        {
                            com.Parameters.AddWithValue("nomor", model.NomorPJ);
                            com.Parameters.AddWithValue("kode", model.Barkode);
                            com.Parameters.AddWithValue("diskon", finaldiskon.ToString());
                            com.Parameters.AddWithValue("Qty", model.Quantity);
                            com.Parameters.AddWithValue("total", total.ToString());

                            op.KonekDB();
                            rd.Close();
                            com.ExecuteNonQuery();
                            op.KonekDB();
                        }
                    }
                }
            }
            cekGrosir(model);
        }

        public void UpdateHarga(TransaksiModel model)
        {
            int HJ = 0;
            List<TransaksiModel> listmodel = new List<TransaksiModel>();
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomor", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomor", model.NomorPJ);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    op.KonekDB();
                    while (rd.Read())
                    {
                        var md = new TransaksiModel();

                        //Data AssignMent
                        md.NomorPJ = model.NomorPJ;
                        md.Nama = rd["nama"].ToString();
                        md.Barkode = rd["barcode"].ToString();
                        md.Quantity = rd["quantity"].ToString();
                        md.Harga_jual = rd["harga_jual"].ToString();
                        md.Harga = rd[model.State].ToString();
                        md.Harga_pokok = rd["hpp"].ToString();
                        md.Diskon = rd["diskon"].ToString();
                        md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");

                        //Logic
                        int qty = Convert.ToInt32(md.Quantity);
                        int diskon = Convert.ToInt32(md.Diskon);
                        HJ = Convert.ToInt32(md.Harga.Equals(null) ? null : md.Harga);
                        int TotalPCS = qty * HJ - diskon;
                        md.Total = TotalPCS.ToString();

                        listmodel.Add(md);
                    }
                }
            }
        }

        string text = "";
        public void SubtrakBarangs(List<TransaksiModel> model)
        {
            int stok = 0;
            var setting = AmbilSetting();
            bool iskurang = false;
            List<string> listNotif = new List<string>();
            foreach (var md in model)
            {
                using (var cmd = new MySqlCommand("Select stok FROM barangs where kode_barang = @barcode", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@barcode", md.Barkode);
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if (rd.HasRows)
                        {
                            stok = Convert.ToInt32(rd["stok"].ToString());
                        }
                    }
                }

                int final = stok - Convert.ToInt32(md.Quantity);
                //Masukan Histori Stok
                var mdh = new HistoriStokModel();
                mdh.Nama = md.Nama;
                mdh.Barcode = md.Barkode;
                mdh.NomerTrans = md.NomorPJ;
                mdh.Tanggal = op.simpleDate;
                mdh.Diskon = md.Diskon;
                mdh.Harga_jual = md.Harga_jual;
                mdh.Masuk = "0";
                mdh.Keluar = md.Quantity;
                mdh.Saldo = final.ToString();
                mdh.Aktifitas = "POS";
                op.masukHistoriBarangs(mdh);

                //Update stok barangs
                using (var cmd = new MySqlCommand($"UPDATE barangs SET stok = @final, updated_at = @tanggal WHERE kode_barang = @kode", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@final", final.ToString());
                    cmd.Parameters.AddWithValue("@kode", md.Barkode);
                    cmd.Parameters.AddWithValue("@tanggal", DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss"));

                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
                //cek kurang dari
                using (var cmd = new MySqlCommand($"SELECT * FROM barangs WHERE kode_barang = '{md.Barkode}' AND stok <= {setting.StokMinimum}", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if (rd.HasRows)
                        {
                            text = $"Stok {md.Nama} sekarang : {rd["stok"].ToString()}";
                            iskurang = true;   
                        }
                    }
                }
                if (iskurang == true)
                {
                    NotifyIcon notify1 = new NotifyIcon();
                    notify1.BalloonTipText = text;
                    notify1.BalloonTipTitle = "Stok Minimum";
                    notify1.Icon = SystemIcons.Information;
                    notify1.Visible = true;
                    notify1.ShowBalloonTip(500);
                }
            }
        }

        public void Delete(TransaksiModel model)
        {
            using (MySqlCommand com = new MySqlCommand("Delete FROM histori_penjualan where nomerTrans = @nomor AND barcode = @kode", op.Conn))
            {
                com.Parameters.AddWithValue("nomor", model.NomorPJ);
                com.Parameters.AddWithValue("kode", model.Barkode);

                op.KonekDB();
                com.ExecuteNonQuery();
                op.KonekDB();
            }
        }
            
        public void MasukanLaporan(PembayaranModel model, userDataModel user)
        {
            //Jika diskonmember = null maka set value ke 0
            if (model.Diskonmember == "")
            {
                model.Diskonmember = "0";
            }

            //Jika diskontotal = null maka set value ke 0
            if (model.Diskontotal == "")
            {
                model.Diskontotal = "0";
            }

            using (var cmd = new MySqlCommand("INSERT INTO report_penjualan values (null, md5(rand()), @nomerPj, @bayar, @kembali, @diskonTotal,@diskonmember, @subtotal, @totalbayar, @user, @tanggal)", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomerPj", model.NomorPJ);
                cmd.Parameters.AddWithValue("@bayar", model.Bayar);
                cmd.Parameters.AddWithValue("@kembali", model.Kembali);
                cmd.Parameters.AddWithValue("@diskonTotal", model.Diskontotal);
                cmd.Parameters.AddWithValue("@diskonmember", model.Diskonmember);
                cmd.Parameters.AddWithValue("@subtotal", model.Subtotal);
                cmd.Parameters.AddWithValue("@user", user.username);
                cmd.Parameters.AddWithValue("@totalbayar", model.Totalbiaya);
                cmd.Parameters.AddWithValue("@tanggal", op.myDatetime);
                
                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }

            using (var cmd = new MySqlCommand("" +
                "INSERT INTO report_penjualan_retur VALUES (null,md5(rand()), @nomer, @subtotal, @barcode, @nama, @qtyretur," +
                "@total, @status, @user, @datetime, @datetime)", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", model.NomorPJ);
                cmd.Parameters.AddWithValue("@subtotal", model.Totalbiaya);
                cmd.Parameters.AddWithValue("@barcode", "0");
                cmd.Parameters.AddWithValue("@nama", "0");
                cmd.Parameters.AddWithValue("@qtyretur", "0");
                cmd.Parameters.AddWithValue("@total", "0");
                cmd.Parameters.AddWithValue("@status", "penjualan");
                cmd.Parameters.AddWithValue("@user", user.username);
                cmd.Parameters.AddWithValue("@datetime", op.myDatetime);

                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
        }

        public void ChangeMember(TransaksiModel model, RootMember mem)
        {
            var listmodel = new List<TransaksiModel>();
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomor", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomor", model.NomorPJ);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    op.KonekDB();
                    while (rd.Read())
                    {
                        var md = new TransaksiModel();

                        //Data AssignMent
                        md.NomorPJ = model.NomorPJ;
                        md.Nama = rd["nama"].ToString();
                        md.Barkode = rd["barcode"].ToString();
                        md.Quantity = rd["quantity"].ToString();
                        md.Harga_jual = rd["harga_jual"].ToString();
                        md.Harga_pokok = rd["hpp"].ToString();
                        md.Diskon = rd["diskon"].ToString();
                        md.Tanggal = DateTime.Now.ToString("yyyy-MM-dd");

                        listmodel.Add(md);
                    }
                }

                foreach (var md in listmodel)
                {
                    using (MySqlCommand com = new MySqlCommand("UPDATE histori_penjualan SET id_member = @member where nomerTrans = @nomor AND barcode = @kode", op.Conn))
                    {
                        com.Parameters.AddWithValue("@member", mem.member.name);
                        com.Parameters.AddWithValue("@nomor", model.NomorPJ);
                        com.Parameters.AddWithValue("@kode", md.Barkode);

                        op.KonekDB();
                        com.ExecuteNonQuery();
                        op.KonekDB();
                    }
                }
            }
        }

        ///Direct Print
        ///
        
        //Cek Banyak Rows
        public int totalRows(PembayaranModel model)
        {
            int row = 0;
            using (var cmd = new MySqlCommand($"SELECT COUNT(*) FROM view_report_penjualan WHERE nomerTrans = '{model.NomorPJ}'", op.Conn))
            {
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        row = Convert.ToInt32(rd["COUNT(*)"].ToString());
                    }
                }
            }
            return row;
        }

        //API Method
        public RootMember AmbilPoint(userDataModel model, string kode)
        {
            var mem = new RootMember();
            using (var client = new RestClient($"{op.url}cabangmember/"))
            {
                var rs = new RestRequest("poin", Method.Get);
                rs.AddParameter("pin", kode);
                rs.AddParameter("token", model.token);

                var response = client.Execute(rs);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string json = response.Content.ToString();
                    mem = JsonConvert.DeserializeObject<RootMember>(json);
                    mem.member.status = "sucess";
                    ///mbox cek error
                    //mb.InformasiOK(response.Content.ToString() + response.StatusCode.ToString());
                }
                else if(response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var jso = response.Content.ToString();
                    apiError err = JsonConvert.DeserializeObject<apiError>(jso);
                    mem = null;
                }
                else
                {
                    mb.PeringatanOK("Kode Salah");
                }
            }
            return mem;
        }

        public void insertHistori(userDataModel user, TransaksiModel model, int subtotal)
        {
            var statusKirim = false;
            //Ambil Data Local
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomer", op.Conn))
            {
                var listarr = new List<SendTransaksi>();
                var listTrans = new List<TransaksiModel>();
                cmd.Parameters.AddWithValue("@nomer", model.NomorPJ);
                op.KonekDB();
                string mem = "";

                if (model.Id_member == "")
                {
                    mem = null;
                }
                else
                {
                    mem = model.Id_member;
                }

                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var md = new SendTransaksi();

                        //Data AssignMent
                        md.nomorPJ = model.NomorPJ;
                        md.id_kategori = rd["id_category"].ToString();
                        md.nama = rd["nama"].ToString();
                        md.barkode = rd["barcode"].ToString();
                        md.quantity = rd["quantity"].ToString();
                        md.harga = rd["harga_jual"].ToString();
                        md.harga_pokok = rd["hpp"].ToString();
                        md.harga_jual = rd["harga_jual"].ToString();
                        md.tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                        md.id_member = mem;
                        //Logic
                        int qty = Convert.ToInt32(md.quantity);
                        int HJ = Convert.ToInt32(md.harga_jual);
                        int TotalPCS = Convert.ToInt32(rd["total"].ToString());
                        md.total = TotalPCS.ToString();
                        
                        listarr.Add(md);
                    }
                }
                using (var rd2 = cmd.ExecuteReader())
                {
                    while (rd2.Read())
                    {
                        var md = new TransaksiModel();

                        //Data AssignMent
                        md.NomorPJ = model.NomorPJ;
                        md.Idkategori = rd2["id_category"].ToString();  
                        md.Nama = rd2["nama"].ToString();
                        md.Diskon = rd2["diskon"].ToString();
                        md.State = rd2["status"].ToString();
                        md.Barkode = rd2["barcode"].ToString();
                        md.Satuan = rd2["satuan"].ToString();
                        md.Quantity = rd2["quantity"].ToString();
                        md.Harga = rd2["harga_jual"].ToString();
                        md.Harga_pokok = rd2["hpp"].ToString();
                        md.Harga_jual = rd2["harga_jual"].ToString();
                        md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                        md.Id_member = mem;
                        
                        //Logic
                        int qty = Convert.ToInt32(md.Quantity);
                        int HJ = Convert.ToInt32(md.Harga_jual);
                        int TotalPCS = Convert.ToInt32(rd2["total"].ToString());
                        md.Total = TotalPCS.ToString();

                        listTrans.Add(md);
                    }
                }

                //Update List Struk
                //op.masukListStruk("PJC", model.NomorPJ);
                //Update Nomor

                if (op.CekNetwork() == false)
                {
                    insertPending(listTrans, user);
                    SubtrakBarangs(listTrans);
                    mb.PeringatanOK("Jaringan bermasalah upload data ter pending");
                }
                else
                {
                    //Request simpan ke server, handle error dan timeout
                    try
                    {
                        using (var client = new RestClient($"{op.url}/cabangmember/"))
                        {
                            var rs = new RestRequest("transaksi", Method.Post);
                            var body = new
                            {
                                token = user.token,
                                id_cabang = user.cabang_id,
                                data = listarr,
                                subtotal = subtotal
                            };  

                            var arr = JsonConvert.SerializeObject(body);

                            rs.AddJsonBody(arr);
                            if(!string.IsNullOrEmpty(user.csrf_token))
                            {
                                rs.AddHeader("X-CSRF-TOKEN", user.csrf_token);
                            }
                            rs.AddHeader("Content-Type", "application/json");

                            rs.Timeout = 10000;    

                            var response = client.Execute(rs);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                mb.InformasiOK("Transaksi Selesai");
                                statusKirim = true;
                            }
                            else
                            {
                                mb.PeringatanOK("Terjadi Kesalahan pada server, Data ter Pending");
                                insertPending(listTrans, user);
                                //MessageBox.Show(response.Content.ToString(), "Error List", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        insertPending(listTrans, user);
                        mb.peringatanError("Terjadi Timeout, Transaksi ter Pending");
                    }
                }
                SubtrakBarangs(listTrans);
            }

            if (statusKirim == true)
            {
                //uploadPending(user);
            }
        }

        public void uploadPending(userDataModel user)
        {
            var listPending = new List<SendTransaksi>();
            var subtotal = 0;
            //Get Subtotal

            using (var cmd = new MySqlCommand("select * from pending_penjualan", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var md = new SendTransaksi();

                        //Data AssignMent
                        md.nomorPJ = rd["nomerTrans"].ToString();
                        md.nama = rd["nama"].ToString();
                        md.barkode = rd["barcode"].ToString();
                        md.quantity = rd["quantity"].ToString();
                        md.diskon = rd["diskon"].ToString();
                        md.harga = rd["harga_jual"].ToString();
                        md.harga_pokok = rd["hpp"].ToString();
                        md.harga_jual = rd["harga_jual"].ToString();
                        md.tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                        md.id_kategori = rd["id_member"].ToString();
                        //Logic
                        int qty = Convert.ToInt32(md.quantity);
                        int HJ = Convert.ToInt32(md.harga);
                        int TotalPCS = qty * HJ;
                        md.total = TotalPCS.ToString();
                        subtotal += Convert.ToInt32(rd["total"].ToString());
                        listPending.Add(md);
                    }
                    
                }
            }

            try
            {
                using (var client = new RestClient($"{op.url}/cabangmember/"))
                {
                    var rs = new RestRequest("transaksi", Method.Post);
                    var body = new
                    {
                        token = user.token,
                        id_cabang = user.cabang_id,
                        data = listPending,
                        subtotal = subtotal
                    };

                    var arr = JsonConvert.SerializeObject(body);

                    rs.AddJsonBody(arr);
                    if (!string.IsNullOrEmpty(user.csrf_token))
                    {
                        rs.AddHeader("X-CSRF-TOKEN", user.csrf_token);
                    }
                    rs.AddHeader("Content-Type", "application/json");

                    rs.Timeout = 10000;

                    var response = client.Execute(rs);
                    //mb.InformasiOK(response.Content.ToString());
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        clearPendingData();
                        return;
                    }
                    else
                    {
                        mb.peringatanError("terjadi Kesalahan saat upload pending data");
                        mb.fotoIni(response.Content.ToString(), "API ERROR");
                        //mb.PeringatanOK("terjadi Kesalahan pada server, Data ter Pending");
                        return;
                        //MessageBox.Show(response.Content.ToString(), "Error List", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                mb.peringatanError(ex.Message.ToString());
                //mb.PeringatanOK("terjadi Kesalahan pada server, Data ter Pending");
                return;
            }
        }

        private void clearPendingData()
        {
            using (var cmd = new MySqlCommand("delete  from pending_penjualan", op.Conn))
            {
                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
        }

        //Pending Barang jika gagal Upload
        public void insertPending(List<TransaksiModel> listBarang, userDataModel user)
        {
            if(listBarang.Count <= 0)
            {
                return;
            }
            else
            {

                foreach (var model in listBarang)
                {

                    //Simpan Ke Pending
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO pending_penjualan VALUES (null,md5(RAND()),@idkategori, @nomorPJ, @nama, @barcode, @quantity, @satuan, @HJ, @HPP, @Diskon, @Total, @user, @id_member,@status, @tanggal)", op.Conn))
                    {
                        cmd.Parameters.AddWithValue("@nomorPJ", model.NomorPJ);
                        cmd.Parameters.AddWithValue("@idkategori", model.Idkategori);
                        cmd.Parameters.AddWithValue("@nama", model.Nama);
                        cmd.Parameters.AddWithValue("@barcode", model.Barkode);
                        cmd.Parameters.AddWithValue("@quantity", model.Quantity);//insert satu quantity
                        cmd.Parameters.AddWithValue("@satuan", model.Satuan);//insert satu quantity
                        cmd.Parameters.AddWithValue("@HJ", model.Harga_jual);
                        cmd.Parameters.AddWithValue("@HPP", model.Harga_pokok);
                        cmd.Parameters.AddWithValue("@Total", model.Total);
                        cmd.Parameters.AddWithValue("@tanggal", op.myDatetime);
                        cmd.Parameters.AddWithValue("@Diskon", model.Diskon);// Set Diskon ke 0
                        cmd.Parameters.AddWithValue("@status", model.State);// Set Diskon ke 0
                        cmd.Parameters.AddWithValue("@id_member", model.Id_member);
                        cmd.Parameters.AddWithValue("@user", _user.username);

                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                    }
                }
            }

            return;
        }

        //FITURR PEMBULATAN / ROUNDING
        public string CekRound(string round)
        {
            int finalInt = 0;
            if (round != "0"  && Convert.ToInt32(round) > 100)
            {
                //2300
                string awal = round;
                int intawal = Convert.ToInt32(awal);
                //300
                string digitlast = round.Substring(round.Length - 3);
                int lastINt = Convert.ToInt32(digitlast);
                int sub = 0;
                if (lastINt == 0)
                {
                    finalInt = intawal;
                }
                else
                {
                    if (lastINt <= 500)
                    {
                        sub = lastINt - 500;
                    }
                    else if (lastINt > 500 && lastINt < 1000)
                    {
                        sub = lastINt - 1000;
                    }
                    finalInt = intawal - (sub);
                }
            }
            return finalInt.ToString();
        }

        internal void directPrint2(string nomerTrans)
        {
            nomerTransgb = nomerTrans;
            //printStruk2();
            PrintRdlc();
            //PrinterESC();
        }

        internal void rdlcPrint(string nomerTrans)
        {
            nomerTransgb = nomerTrans;
            PrintRdlc();
        }

        private void PrintRdlc()
        {
            double RowCount = 0;

            //Take Row count to Height
            using (var cmd = new MySqlCommand($"SELECT COUNT(*) FROM histori_penjualan where nomerTrans = '{nomerTransgb}'", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    RowCount = Convert.ToDouble(rd["COUNT(*)"].ToString());
                }
            }

            double stHeigtBd = 6.5;
            double stHeight = 18.6;

            double incremental = 0.6;

            double totalBody = stHeigtBd + (incremental * RowCount);
            double TotalHgt = stHeight + (incremental * RowCount);

            Console.WriteLine("count : " + RowCount);
            Console.WriteLine("body : " + totalBody);
            Console.WriteLine("height : " + TotalHgt);

            var doc = new XmlDocument();
            // Load the RDLC file
            doc.Load($"{op.pathReport("Struk.rdlc")}");

            // Set up the namespace manager
            XmlNamespaceManager namesps = new XmlNamespaceManager(doc.NameTable);
            namesps.AddNamespace("ns1", "http://schemas.microsoft.com/sqlserver/reporting/2016/01/reportdefinition"); // Use the correct namespace

            // Select the nodes
            XmlNode bodyNode = doc.SelectSingleNode("ns1:Report/ns1:ReportSections/ns1:ReportSection/ns1:Body/ns1:Height", namesps);
            XmlNode heightNode = doc.SelectSingleNode("ns1:Report/ns1:ReportSections/ns1:ReportSection/ns1:Page/ns1:PageHeight", namesps);

            if (bodyNode == null)
            {
                Console.WriteLine("Body Height node not found.");
            }
            else
            {
                Console.WriteLine("Body Node before : " + bodyNode.InnerText);
                NumberFormatInfo nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };
                bodyNode.InnerText = $"{totalBody.ToString(nfi)}cm";
                Console.WriteLine("Body Node after : " + bodyNode.InnerText);

            }

            if (heightNode == null)
            {
                Console.WriteLine("Page Height node not found.");
            }
            else
            {
                Console.WriteLine("Height Node before : " + heightNode.InnerText);
                NumberFormatInfo nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };
                heightNode.InnerText = $"{TotalHgt.ToString(nfi)}cm";
                Console.WriteLine("Height Node after : " + heightNode.InnerText);
            }

            // Save the modified RDLC file
            doc.Save($"{op.pathReport("Struk.rdlc")}");

            Console.WriteLine("RDLC file updated successfully.");

            PopulateRDLC();
        }

        public void PopulateRDLC()
        {
            //rows list
            DataTable dt = new DataTable();
            string tanggal = "";
            string user = "";
            string nomerTrans = "";

            using (var cmd = new MySqlCommand($"SELECT * FROM view_report_penjualan WHERE nomerTrans = '{nomerTransgb}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    dt.Load(rd);
                }
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    tanggal = rd["tanggalnota"].ToString();
                    user = rd["User"].ToString();
                    nomerTrans = rd["nomerTrans"].ToString();
                }
            }

            var config = op.CabangConfig();

            var param = new ReportParameter[8];
            param[0] = new ReportParameter("Cabang", config.Nama);
            param[1] = new ReportParameter("Alamat", config.Alamat);
            param[2] = new ReportParameter("Baris1", config.Baris1);
            param[3] = new ReportParameter("Baris2", config.Baris2);
            param[4] = new ReportParameter("Tanggal", op.convertDate(tanggal));
            param[5] = new ReportParameter("Waktu", op.convertDateHours(tanggal));
            param[6] = new ReportParameter("User", user);
            param[7] = new ReportParameter("NomerTrans", nomerTrans);

            var source = new ReportDataSource("Struk", dt);

            PrintOutRdlc($"{op.pathReport("Struk.rdlc")}", source, param);
        }

        private void PrintOutRdlc(string path, ReportDataSource source, ReportParameter[] param)
        {
            ReportViewer InvoiceReport = new ReportViewer();
            InvoiceReport.LocalReport.ReportPath = path;

            InvoiceReport.LocalReport.DataSources.Add(source);
            InvoiceReport.LocalReport.SetParameters(param);

            LocalReport lr = InvoiceReport.LocalReport;
            lr.PrintToPrinter();
            InvoiceReport.Clear();
        }

        public void PrintPrinter(PembayaranModel model, RootMember mem, userDataModel user)
        {
            usr = mem;
            nomerTransgb = model.NomorPJ;
            //Cek apakah menggunakan Member
            if (mem == null || Convert.ToInt32(model.Subtotal) < Convert.ToInt32(op.CabangConfig().Minimalcash))
            {
                PrintRdlc();
            }
            else if (mem != null && Convert.ToInt32(model.Subtotal) >= Convert.ToInt32(op.CabangConfig().Minimalcash))
            {
                PrintRDLCKupon();
            }
        }

        private void PrintRDLCKupon()
        {
            double RowCount = 0;

            //Take Row count to Height
            using (var cmd = new MySqlCommand($"SELECT COUNT(*) FROM histori_penjualan where nomerTrans = '{nomerTransgb}'", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    RowCount = Convert.ToDouble(rd["COUNT(*)"].ToString());
                }
            }

            double stHeigtBd = 7;
            double stHeight = 23.4;

            double incremental = 0.8;

            double totalBody = stHeigtBd + (incremental * RowCount);
            double TotalHgt = stHeight + (incremental * RowCount);

            var doc = new XmlDocument();
            var namesps = new XmlNamespaceManager(doc.NameTable);
            namesps.AddNamespace("ns1", "http://schemas.microsoft.com/sqlserver/reporting/2016/01/reportdefinition");
            namesps.AddNamespace("ns2", "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner");

            doc.Load($"{op.pathReport("StrukKupon.rdlc")}");

            XmlNode bodyNode = doc.SelectSingleNode("ns1:Report/ns1:ReportSections/ns1:ReportSection/ns1:Body/ns1:Height", namesps);
            var heightNode = doc.SelectSingleNode("ns1:Report/ns1:ReportSections/ns1:ReportSection/ns1:Page/ns1:PageHeight", namesps);

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            bodyNode.InnerText = $"{totalBody.ToString(nfi)}cm";
            heightNode.InnerText = $"{TotalHgt.ToString(nfi)}cm";

            doc.Save($"{op.pathReport("StrukKupon.rdlc")}");

            PopulateRDLCkupon();
        }

        private void PopulateRDLCkupon()
        {
            //rows list
            DataTable dt = new DataTable();
            string tanggal = "";
            string user = "";
            string nomerTrans = "";

            using (var cmd = new MySqlCommand($"SELECT * FROM view_report_penjualan WHERE nomerTrans = '{nomerTransgb}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    dt.Load(rd);
                }
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    tanggal = rd["tanggalnota"].ToString();
                    user = rd["User"].ToString();
                    nomerTrans = rd["nomerTrans"].ToString();
                }
            }

            var config = op.CabangConfig();

            var param = new ReportParameter[11];
            param[0] = new ReportParameter("Cabang", config.Nama);
            param[1] = new ReportParameter("Alamat", config.Alamat);
            param[2] = new ReportParameter("Baris1", config.Baris1);
            param[3] = new ReportParameter("Baris2", config.Baris2);
            param[4] = new ReportParameter("Tanggal", op.convertDate(tanggal));
            param[5] = new ReportParameter("Waktu", op.convertDateHours(tanggal));
            param[6] = new ReportParameter("User", user);
            param[7] = new ReportParameter("NomerTrans", nomerTrans);
            param[8] = new ReportParameter("NamaMem", usr.member.name);
            param[9] = new ReportParameter("NoMem", usr.member.phone);
            param[10] = new ReportParameter("IdentitasMem", usr.member.email);

            var source = new ReportDataSource("Struk", dt);

            PrintOutRdlc($"{op.pathReport("StrukKupon.rdlc")}", source, param);
        }

        public void printStruk2()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = new PrinterSettings().PrinterName;
            pd.PrintPage += new PrintPageEventHandler(this.onPrintpage);

            pd.Print();
        }


        //ESC POS printing 
        public int takeheight(string nomerTrans)
        {
            int heightreturn = 0;
            using (var cmd = new MySqlCommand($"SELECT * FROM view_report_penjualan WHERE nomerTrans='{nomerTransgb}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    heightreturn = Convert.ToInt32(rd.FieldCount) * 40;
                }
            }
            return 410 + heightreturn;
        }

        //Printing
        public void onPrintpage(object sender, PrintPageEventArgs e)
        {
            string subtotal = "";
            string bayar = "";
            string diskonmem = "";
            string diskontotal = "";
            string totalbiaya = "";
            string kembali = "";
            string tanggal = "";
            string usernama = ""; 
            
            var config = op.CabangConfig();
            var listmodel = new List<TransaksiModel>();

            using (var cmd = new MySqlCommand($"SELECT * FROM view_report_penjualan WHERE nomerTrans='{nomerTransgb}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while(rd.Read())
                    {
                        var model = new TransaksiModel();
                        model.Nama = rd["nama"].ToString();
                        model.Harga = rd["harga_jual"].ToString();
                        model.Quantity = rd["quantity"].ToString();
                        model.Total = rd["total"].ToString();
                        subtotal = rd["subtotal"].ToString();
                        bayar = rd["bayar"].ToString();
                        diskontotal = rd["diskonTotal"].ToString();
                        diskonmem = rd["diskonMember"].ToString();
                        totalbiaya = rd["totalBiaya"].ToString();
                        kembali = rd["kembali"].ToString();
                        tanggal = rd["tanggalnota"].ToString();
                        usernama = rd["User"].ToString();
                        listmodel.Add(model);
                    }
                }
            }
            Graphics g = e.Graphics;

            if (tanggal == "")
            {
                tanggal = op.myDatetime;
            }

            Font font = new Font("Cambria", 12);
            Font uang = new Font("Cambria", 11);
            Font header = new Font("Cambria", 16);
            Font alamat = new Font("Cambria", 8);
            Font alamat1 = new Font("Cambria", 10);
            SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);
            Brush bg = new SolidBrush(System.Drawing.Color.White);
            Pen blackPen = new Pen(System.Drawing.Color.Black, 1);

            var right = new StringFormat() { Alignment = StringAlignment.Far };
            var mid = new StringFormat() { Alignment = StringAlignment.Center };
            var left = new StringFormat() { Alignment = StringAlignment.Near };

            float width = 433f;
            float halfWidth = 215f;

            var rect = new RectangleF(0, 0, width, 300f);

            PointF point1 = new PointF(0f, 50f);
            //line 11,5cm
            //PointF point2 = new PointF(453f, 50f);
            PointF point2 = new PointF(433f, 50f);

            // Draw line to screen.
            g.DrawString(config.Nama, header, brush, CusRec(0, 0, width, 100f), mid);
            g.DrawString(config.Alamat, alamat, brush, CusRec(0, 25, width, 100f), mid);
            g.DrawLine(blackPen, point1, point2);
            g.DrawString(usernama, font, brush, CusRec(143, 55, halfWidth + 70, 100f), right);
            g.DrawString(nomerTransgb, font, brush, CusRec(0, 55, halfWidth, 100f), left);
            g.DrawString(op.convertDateHours(tanggal), font, brush, CusRec(213, 80, halfWidth, 100f), right);
            g.DrawString(op.convertDate(tanggal), font, brush, CusRec(0, 80, halfWidth, 100f), left);
            g.DrawLine(blackPen, new PointF(0f, 105f), new PointF(width, 105f));

            float yta = listmodel.Count * 40;
            //Loop Disini
            g.DrawString("Nama", font, brush, CusRec(0, 110f, 112f, 100f), left);
            g.DrawString("Harga", font, brush, CusRec(112f, 110f, 112f, 100f), mid);
            g.DrawString("Qty", font, brush, CusRec(224f, 110f, 112f, 100f), mid);
            g.DrawString("Total", font, brush, CusRec(316f, 110f, 112f, 100f), right);
            g.DrawLine(blackPen, new PointF(0f, 135f), new PointF(width, 135f));

            float ylist = 0;
            foreach (var item in listmodel)
            {
                g.DrawString(item.Nama, font, brush, CusRec(0, 150f + ylist, 112f, 100f), left);
                g.DrawString($"{Convert.ToInt32(item.Harga):n0}", font, brush, CusRec(112f, 150f + ylist, 112f, 100f), mid);
                g.DrawString(item.Quantity, font, brush, CusRec(224f, 150f + ylist, 112f, 100f), mid);
                g.DrawString($"{Convert.ToInt32(item.Total):n0}", font, brush, CusRec(316f, 150f + ylist, 112f, 100f), right);
                ylist = ylist + 40;
            }

            g.DrawLine(blackPen, new PointF(320, 170f + yta), new PointF(410F, 170f + yta));
            //Jarak Y = 40
            g.DrawString("Subtotal :", font, brush, CusRec(163, 180 + yta, 150, 100), right);
            g.DrawString("Diskon :", font, brush, CusRec(163, 200 + yta, 150, 100), right);
            g.DrawString("Diskon Member :", font, brush, CusRec(133, 220 + yta, 150 + 30, 100), right);
            g.DrawString("Total Biaya :", font, brush, CusRec(163, 240 + yta, 150, 100), right);
            g.DrawString("Bayar :", font, brush, CusRec(163, 260 + yta, 150, 100), right);
            g.DrawString("Kembali :", font, brush, CusRec(163, 280 + yta, 150, 100), right);

            g.DrawString($"Rp.{Convert.ToInt32(subtotal):n0}", uang, brush, CusRec(320, 180 + yta, 110, 100), left);
            g.DrawString($"Rp.{Convert.ToInt32(diskontotal):n0}", uang, brush, CusRec(320, 200 + yta, 110, 100), left);
            g.DrawString($"Rp.{Convert.ToInt32(diskonmem):n0}", uang, brush, CusRec(320, 220 + yta, 110, 100), left);
            g.DrawString($"Rp.{Convert.ToInt32(totalbiaya):n0}", uang, brush, CusRec(320, 240 + yta, 110, 100), left);
            g.DrawString($"Rp.{Convert.ToInt32(bayar):n0}", uang, brush, CusRec(320, 260 + yta, 110, 100), left);
            g.DrawString($"Rp.{Convert.ToInt32(kembali):n0}", uang, brush, CusRec(320, 280 + yta, 110, 100), left);

            g.DrawLine(blackPen, new PointF(320f, 310f + yta), new PointF(410F, 310f + yta));

            g.DrawLine(blackPen, new PointF(0, 350 + yta), new PointF(width, 350 + yta));
            g.DrawString(config.Baris1, font, brush, CusRec(0, 370 + yta, width, 100f), mid);
            g.DrawString(config.Baris2, alamat1, brush, CusRec(0, 390 + yta, width, 100f), mid);
            g.DrawString(config.Baris3, alamat1, brush, CusRec(0, 410 + yta, width, 50f), mid);

            e.HasMorePages = false;
        }

        public void PrintStrukKupon()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = new PrinterSettings().PrinterName;
            pd.PrintPage += new PrintPageEventHandler(this.onPrintpageKupon);
            pd.DefaultPageSettings.PaperSize = new PaperSize("CustomSize", 453, Convert.ToInt32(pageHeight)- 100);
            pd.Print();
            pd.Dispose();
        }

        public void onPrintpageKupon(object sender, PrintPageEventArgs e)
        {
            string subtotal = "";
            string bayar = "";
            string diskonmem = "";
            string diskontotal = "";
            string totalbiaya = "";
            string kembali = "";
            string tanggal = "";
            string usernama = "";
             
            var config = op.CabangConfig();
            var listmodel = new List<TransaksiModel>();

            using (var cmd = new MySqlCommand($"SELECT * FROM view_report_penjualan WHERE nomerTrans='{nomerTransgb}'", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var model = new TransaksiModel();
                        model.Nama = rd["nama"].ToString();
                        model.Harga = rd["harga_jual"].ToString();
                        model.Quantity = rd["quantity"].ToString();
                        model.Total = rd["total"].ToString();
                        subtotal = rd["subtotal"].ToString();
                        bayar = rd["bayar"].ToString();
                        diskontotal = rd["diskonTotal"].ToString();
                        diskonmem = rd["diskonMember"].ToString();
                        totalbiaya = rd["totalBiaya"].ToString();
                        kembali = rd["kembali"].ToString();
                        usernama = rd["User"].ToString();
                        tanggal = rd["tanggalnota"].ToString();
                        listmodel.Add(model);
                    }
                }
            }
            Graphics g = e.Graphics;

            Font font = new Font("Cambria", 12);
            Font uang = new Font("Cambria", 11);
            Font header = new Font("Cambria", 16);
            Font alamat = new Font("Cambria", 8);
            Font alamat1 = new Font("Cambria", 10);
            SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);
            Pen blackPen = new Pen(System.Drawing.Color.Black, 1);

            float[] dashValues = { 5, 2, 15, 4 };
            Pen DashedPen = new Pen(System.Drawing.Color.Black, 1);
            DashedPen.DashPattern = dashValues;

            var right = new StringFormat() { Alignment = StringAlignment.Far };
            var mid = new StringFormat() { Alignment = StringAlignment.Center };
            var left = new StringFormat() { Alignment = StringAlignment.Near };

            float width = 433f;
            float halfWidth = 215f;

            var rect = new RectangleF(0, 0, width, 300f);

            PointF point1 = new PointF(0f, 50f);
            //Garis 11,5cm
            PointF point2 = new PointF(433f, 50f);

            // Draw line to screen.
            g.DrawString(config.Nama, header, brush, CusRec(0, 0, width, 100f), mid);
            g.DrawString(config.Alamat, alamat, brush, CusRec(0, 25, width, 100f), mid);
            g.DrawLine(blackPen, point1, point2);
            g.DrawString(usernama, font, brush, CusRec(143, 55, halfWidth + 70, 100f), right);
            g.DrawString(nomerTransgb, font, brush, CusRec(0, 55, halfWidth, 100f), left);
            g.DrawString(op.convertDateHours(tanggal), font, brush, CusRec(213, 80, halfWidth, 100f), right);
            g.DrawString(op.convertDate(tanggal), font, brush, CusRec(0, 80, halfWidth, 100f), left);
            g.DrawLine(blackPen, new PointF(0f, 105f), new PointF(width, 105f));

            float yta = listmodel.Count * 40;
            //Loop Disini
            g.DrawString("Nama", font, brush, CusRec(0, 110f, 112f, 100f), left);
            g.DrawString("Harga", font, brush, CusRec(112f, 110f, 112f, 100f), mid);
            g.DrawString("Qty", font, brush, CusRec(224f, 110f, 112f, 100f), mid);
            g.DrawString("Total", font, brush, CusRec(316f, 110f, 112f, 100f), right);
            g.DrawLine(blackPen, new PointF(0f, 135f), new PointF(width, 135f));

            float ylist = 0;
            foreach (var item in listmodel)
            {
                g.DrawString(item.Nama, font, brush, CusRec(0, 150f + ylist, 112f, 100f), left);
                g.DrawString($"{Convert.ToInt32(item.Harga):n0}", font, brush, CusRec(112f, 150f + ylist, 112f, 100f), mid);
                g.DrawString(item.Quantity, font, brush, CusRec(224f, 150f + ylist, 112f, 100f), mid);
                g.DrawString($"{Convert.ToInt32(item.Total):n0}", font, brush, CusRec(316f, 150f + ylist, 112f, 100f), right);
                ylist = ylist + 40;
            }

            g.DrawLine(blackPen, new PointF(320, 170f + yta), new PointF(410F, 170f + yta));
            //Jarak Y = 40
            g.DrawString("Subtotal :", font, brush, CusRec(163, 180 + yta, 150, 100), right);
            g.DrawString("Diskon :", font, brush, CusRec(163, 220 + yta, 150, 100), right);
            g.DrawString("Diskon Member :", font, brush, CusRec(163, 260 + yta, 150, 100), right);
            g.DrawString("Total Biaya :", font, brush, CusRec(163, 300 + yta, 150, 100), right);
            g.DrawString("Bayar :", font, brush, CusRec(163, 340 + yta, 150, 100), right);
            g.DrawString("Kembali :", font, brush, CusRec(163, 380 + yta, 150, 100), right);

            g.DrawString($"Rp.{Convert.ToInt32(subtotal):n0}", uang, brush, CusRec(320, 180 + yta, 110, 100), left);
            g.DrawString($"Rp.{Convert.ToInt32(diskontotal):n0}", uang, brush, CusRec(320, 220 + yta, 110, 100), left);
            g.DrawString($"Rp.{Convert.ToInt32(diskonmem):n0}", uang, brush, CusRec(320, 260 + yta, 110, 100), left);
            g.DrawString($"Rp.{Convert.ToInt32(totalbiaya):n0}", uang, brush, CusRec(320, 300 + yta, 110, 100), left);
            g.DrawString($"Rp.{Convert.ToInt32(bayar):n0}", uang, brush, CusRec(320, 340 + yta, 110, 100), left);
            g.DrawString($"Rp.{Convert.ToInt32(kembali):n0}", uang, brush, CusRec(320, 380 + yta, 110, 100), left);

            g.DrawLine(blackPen, new PointF(320f, 410f + yta), new PointF(410F, 410f + yta));

            g.DrawLine(blackPen, new PointF(0, 430 + yta), new PointF(width, 430 + yta));
            g.DrawString(config.Baris1, font, brush, CusRec(0, 440 + yta, width, 100f), mid);
            g.DrawString(config.Baris2, alamat1, brush, CusRec(0, 460 + yta, width, 100f), mid);
            g.DrawString(config.Baris3, alamat1, brush, CusRec(0, 475 + yta, width, 100f), mid);

            g.DrawLine(DashedPen, new PointF(0f, 500 + yta), new PointF(width, 500 + yta));
            g.DrawString(config.Header, font, brush, CusRec(0, 510 + yta, width, 100), mid);
            g.DrawString("Nama :", font, brush, CusRec(0, 530 + yta, 130, 100), right);
            g.DrawString("Identitas :", font, brush, CusRec(0, 550 + yta, 130, 100), right);
            g.DrawString("NoMember :", font, brush, CusRec(0, 570 + yta, 130, 100), right);

            g.DrawString(usr.member.name, font, brush, CusRec(125, 530 + yta, 310, 100), left);
            g.DrawString(usr.member.email, font, brush, CusRec(125, 550 + yta, 310, 100), left);
            g.DrawString(usr.member.phone, font, brush, CusRec(125, 570 + yta, 310, 100), left);

            pageHeight = 570 + yta;

            // Indicate that there are no more pages to print
            e.HasMorePages = false;
        }


        public RectangleF CusRec(float x, float y, float w, float h)
        {
            var rc = new RectangleF(x, y, w, h);
            return rc;
        }

        public class RawPrinterHelper
        {

            [System.Runtime.InteropServices.DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                IntPtr pname;
                int dwCount;

                dwCount = szString.Length;

                pname = Marshal.StringToCoTaskMemAnsi(szPrinterName);
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                WritePrinter(pname, pBytes, dwCount, out _);
                Marshal.FreeCoTaskMem(pBytes);

                return true;
            }
        }

        private static void SendStopRollingCommand(string printerName)
        {
            try
            {
                // ESC C: Cancel paper feed
                string stopRollingCommand = "\x1B" + "C";

                RawPrinterHelper.SendStringToPrinter(printerName, stopRollingCommand);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending stop rolling command: " + ex.Message);
            }
        }
    }
}
