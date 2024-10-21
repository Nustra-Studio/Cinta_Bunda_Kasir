using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;
using KasirApp.Presenter;

namespace KasirApp.Repository
{
    class BatalPostRepo
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        userDataModel _user;

        //Constructor
        public BatalPostRepo(userDataModel user)
        {
            _user = user;
        }

        public bool cekRows(string table)
        {
            using (var cmd = new MySqlCommand($"SELECT * FROM {table}", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
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

        public bool cekExist(string Query)
        {
            using (var cmd = new MySqlCommand(Query, op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
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

        public void masukanLaporan(BatalPostModel model)
        {
            using (var cmd = new MySqlCommand($"insert into report_batal_posting VALUES (null,md5(rand()),'{model.NomerTrans}','{model.Alasan}','{op.myDatetime}','{op.myDatetime}')", op.Conn))
            {
                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
        }

        public bool batalPOS(BatalPostModel model)
        {
            if (cekRows("histori_penjualan")==false)
            {
                mb.PeringatanOK("Data tidak ada");
                return false;
            }
            else if (cekExist($"SELECT * FROM histori_penjualan WHERE nomerTrans='{model.NomerTrans}'")==false)
            {
                mb.PeringatanOK("Data tidak ada");
                return false;
            }
            else
            {
                List<TransaksiModel> listbarang = new List<TransaksiModel>();
                //Pengembalian Barangs
                using (var cmd = new MySqlCommand($"SELECT * FROM histori_penjualan WHERE nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var md = new TransaksiModel();
                            md.NomorPJ = model.NomerTrans;
                            md.Nama = rd["nama"].ToString();
                            md.Barkode = rd["barcode"].ToString();
                            md.Quantity = rd["quantity"].ToString();
                            md.Harga_jual = rd["harga_jual"].ToString();
                            md.Harga_pokok = rd["hpp"].ToString();
                            md.Diskon = rd["diskon"].ToString();
                            md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                            listbarang.Add(md);
                        }
                    }
                }

                foreach (var item in listbarang)
                {
                    int qtyawal = 0;
                    using (var cmd = new MySqlCommand($"SELECT * FROM barangs where kode_barang='{item.Barkode}'", op.Conn))
                    {
                        op.KonekDB();
                        using (var rd = cmd.ExecuteReader())
                        {
                            rd.Read();
                            qtyawal = Convert.ToInt32(rd["stok"].ToString());
                        }
                    }

                    int qtyfinal = qtyawal + Convert.ToInt32(item.Quantity);
                    using (var cmd = new MySqlCommand($"Update barangs SET stok={qtyfinal} where kode_barang='{item.Barkode}'", op.Conn))
                    {
                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                    }

                    masukHistori(item, qtyfinal, "Batal POS");
                }

                //Penghapusan Records
                using (var cmd = new MySqlCommand($"DELETE FROM histori_penjualan where nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }

                using (var cmd = new MySqlCommand($"DELETE FROM report_penjualan where id_penjualan='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }

                using (var cmd = new MySqlCommand($"DELETE FROM report_penjualan_retur where nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }

                masukanLaporan(model);
                mb.InformasiOK("Batal Posting Selesai");
                op.insertHistoriUser(_user, "Cinta Bunda - batalPOS", "btl Posting POS");
                return true;
            }
        }

        public bool batalPenyesuaian(BatalPostModel model)
        {
            if (cekRows("penyesuaianstok") == false)
            {
                mb.PeringatanOK("Data tidak ada");
                return false;
            }
            else if (cekExist($"SELECT * FROM penyesuaianstok WHERE nomerTrans='{model.NomerTrans}'") == false)
            {
                mb.PeringatanOK("Data tidak ada");
                return false;
            }
            else
            {
                List<TransaksiModel> listbarang = new List<TransaksiModel>();
                //Pengembalian Barangs
                using (var cmd = new MySqlCommand($"SELECT * FROM penyesuaianstok WHERE nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var md = new TransaksiModel();
                            md.NomorPJ = model.NomerTrans;
                            md.Nama = rd["nama"].ToString();
                            md.Barkode = rd["barcode"].ToString();
                            md.Quantity = rd["selisih"].ToString();
                            md.Harga_jual = rd["harga_jual"].ToString();
                            md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                            listbarang.Add(md);
                        }
                    }
                }

                foreach (var item in listbarang)
                {
                    int qtyawal = 0;
                    using (var cmd = new MySqlCommand($"SELECT * FROM barangs where kode_barang='{item.Barkode}'", op.Conn))
                    {
                        op.KonekDB();
                        using (var rd = cmd.ExecuteReader())
                        {
                            rd.Read();
                            qtyawal = Convert.ToInt32(rd["stok"].ToString());
                        }
                    }

                    int qtyfinal = qtyawal - (Convert.ToInt32(item.Quantity));
                    using (var cmd = new MySqlCommand($"Update barangs SET stok={qtyfinal} where kode_barang='{item.Barkode}'", op.Conn))
                    {
                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                    }

                    masukHistoriNone(item, qtyfinal, "Batal Penyesuaian");
                }

                //Penghapusan Records
                using (var cmd = new MySqlCommand($"DELETE FROM penyesuaianstok where nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }

                using (var cmd = new MySqlCommand($"DELETE FROM report_penyesuaian where id_penyesuaian='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }

                masukanLaporan(model);
                mb.InformasiOK("Batal Posting Selesai");
                op.insertHistoriUser(_user, "Cinta Bunda - batalPenyesuaian", "btl Posting Penyesuaian");
                return true;
            }
        }

        public bool batalOpname(BatalPostModel model)
        {
            if (cekRows("opnames") == false)
            {
                mb.PeringatanOK("Data tidak ada");
                return false;
            }
            else if (cekExist($"select * from opnames WHERE nomerTrans='{model.NomerTrans}'")==false)
            {
                mb.PeringatanOK("Data tidak ada");
                return false;
            }
            else
            {
                List<TransaksiModel> listbarang = new List<TransaksiModel>();
                //Pengembalian Barangs
                using (var cmd = new MySqlCommand($"SELECT * FROM opnames WHERE nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var md = new TransaksiModel();
                            md.NomorPJ = model.NomerTrans;
                            md.Nama = rd["Nama"].ToString();
                            md.Barkode = rd["Barcode"].ToString();
                            md.Quantity = rd["stok"].ToString();
                            md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                            listbarang.Add(md);
                        }
                    }
                }

                foreach (var item in listbarang)
                {
                    int qtyawal = 0;
                    using (var cmd = new MySqlCommand($"SELECT * FROM barangs where kode_barang='{item.Barkode}'", op.Conn))
                    {
                        op.KonekDB();
                        using (var rd = cmd.ExecuteReader())
                        {
                            rd.Read();
                            if (rd.HasRows)
                            {
                                qtyawal = Convert.ToInt32(rd["stok"].ToString());
                                item.Harga_jual = rd["harga_jual"].ToString();
                            }
                        }
                    }

                    using (var cmd = new MySqlCommand($"Update barangs SET stok={item.Quantity} where kode_barang='{item.Barkode}'", op.Conn))
                    {
                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                    }

                    masukHistoriKeluar(item, Convert.ToInt32(item.Quantity), "Batal Opnames");
                }

                //Penghapusan Records
                using (var cmd = new MySqlCommand($"DELETE FROM opnames where nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }

                masukanLaporan(model);
                mb.InformasiOK("Batal Posting Selesai");
                op.insertHistoriUser(_user, "Cinta Bunda - batalOpname", "btl Posting Opname");
                return true;
            }
        }

        public bool batalTransferGudang(BatalPostModel model)
        {
            if (cekRows("histori_transfergudang") == false)
            {
                mb.PeringatanOK("Data tidak ada");
                return false;
            }
            else if (cekExist($"select * from histori_transfergudang WHERE nomerTrans='{model.NomerTrans}'") == false)
            {
                mb.PeringatanOK("Data tidak ada");
                return false;
            }
            else
            {
                List<TransaksiModel> listbarang = new List<TransaksiModel>();
                //Pengembalian Barangs
                using (var cmd = new MySqlCommand($"SELECT * FROM histori_transfergudang WHERE nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var md = new TransaksiModel();
                            md.NomorPJ = model.NomerTrans;
                            md.Nama = rd["name"].ToString();
                            md.Barkode = rd["barcode"].ToString();
                            md.Quantity = rd["stok"].ToString();
                            md.Harga_jual = rd["harga_jual"].ToString();
                            md.Harga_pokok = rd["harga_pokok"].ToString();
                            md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                            listbarang.Add(md);
                        }
                    }
                }

                foreach (var item in listbarang)
                {
                    int qtyawal = 0;
                    using (var cmd = new MySqlCommand($"SELECT * FROM barangs where kode_barang='{item.Barkode}'", op.Conn))
                    {
                        op.KonekDB();
                        using (var rd = cmd.ExecuteReader())
                        {
                            rd.Read();
                            if (rd.HasRows)
                            {
                                qtyawal = Convert.ToInt32(rd["stok"].ToString());
                            }
                        }
                    }

                    int qtyfinal = qtyawal - Convert.ToInt32(item.Quantity);
                    using (var cmd = new MySqlCommand($"Update barangs SET stok={qtyfinal} where kode_barang='{item.Barkode}'", op.Conn))
                    {
                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                    }

                    masukHistoriKeluar(item, qtyfinal, "Batal TrfGudang");
                }

                //Penghapusan Records
                using (var cmd = new MySqlCommand($"DELETE FROM histori_transfergudang where nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }

                using (var cmd = new MySqlCommand($"DELETE FROM report_transfergudang where id_transfer='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }

                masukanLaporan(model);
                mb.InformasiOK("Batal Posting Selesai");
                op.insertHistoriUser(_user, "Cinta Bunda - batalTransferGudang", "btl Posting Tf Gudang");
                return true;
            }
        }

        public bool batalRetur(BatalPostModel model)
        {
            if (cekRows("report_retur_pos") == false)
            {
                mb.PeringatanOK("Data tidak ada");
                return false;
            }
            else if (cekExist($"SELECT * FROM report_retur_pos WHERE nomerTrans='{model.NomerTrans}'") == false)
            {   
                mb.PeringatanOK("Tidak ada retur Dengan Struk Tersebut");
                return false;
            }
            else
            {
                List<TransaksiModel> listbarang = new List<TransaksiModel>();
                //Pengembalian Barangs
                using (var cmd = new MySqlCommand($"SELECT * FROM report_retur_pos WHERE nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var md = new TransaksiModel();
                            md.NomorPJ = model.NomerTrans;
                            md.Nama = rd["nama"].ToString();
                            md.Barkode = rd["barcode"].ToString();
                            md.Quantity = rd["qtyretur"].ToString();
                            md.Harga_jual = rd["harga"].ToString();
                            md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                            listbarang.Add(md);
                        }
                    }
                }

                foreach (var item in listbarang)
                {
                    int qtyawal = 0;
                    using (var cmd = new MySqlCommand($"SELECT * FROM barangs where kode_barang='{item.Barkode}'", op.Conn))
                    {
                        op.KonekDB();
                        using (var rd = cmd.ExecuteReader())
                        {
                            rd.Read();
                            qtyawal = Convert.ToInt32(rd["stok"].ToString());
                        }
                    }

                    int qtyfinal = qtyawal - (Convert.ToInt32(item.Quantity));
                    using (var cmd = new MySqlCommand($"Update barangs SET stok={qtyfinal} where kode_barang='{item.Barkode}'", op.Conn))
                    {
                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                    }

                    masukHistoriNone(item, qtyfinal, "Batal Retur");
                }

                //Penghapusan Records
                using (var cmd = new MySqlCommand($"DELETE FROM report_retur_pos where nomerTrans='{model.NomerTrans}'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }

                using (var cmd = new MySqlCommand($"DELETE FROM report_penjualan_retur where nomerTrans = '{model.NomerTrans}' AND status='retur'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }

                masukanLaporan(model);
                mb.InformasiOK("Batal Posting Selesai");
                op.insertHistoriUser(_user, "Cinta Bunda - batalRetur", "btl Posting Retur");
                return true;
            }
        }

        public void masukHistori(TransaksiModel md, int final, string aktifitas)
        {
            var mdh = new HistoriStokModel();
            mdh.Nama = md.Nama;
            mdh.Barcode = md.Barkode;
            mdh.NomerTrans = md.NomorPJ;
            mdh.Tanggal = op.simpleDate;
            mdh.Diskon = md.Diskon;
            mdh.Harga_jual = md.Harga_jual;
            mdh.Masuk = md.Quantity;
            mdh.Keluar = "0";
            mdh.Saldo = final.ToString();
            mdh.Aktifitas = aktifitas;
            op.masukHistoriBarangs(mdh);
        }

        public void masukHistoriNone(TransaksiModel md, int final, string aktifitas)
        {
            var mdh = new HistoriStokModel();
            mdh.Nama = md.Nama;
            mdh.Barcode = md.Barkode;
            mdh.NomerTrans = md.NomorPJ;
            mdh.Tanggal = op.simpleDate;
            mdh.Diskon = "";
            mdh.Harga_jual = md.Harga_jual;
            mdh.Masuk = "0";
            mdh.Keluar = "0";
            mdh.Saldo = final.ToString();
            mdh.Aktifitas = aktifitas;
            op.masukHistoriBarangs(mdh);
        }

        public void masukHistoriKeluar(TransaksiModel md, int final, string aktifitas)
        {
            var mdh = new HistoriStokModel();
            mdh.Nama = md.Nama;
            mdh.Barcode = md.Barkode;
            mdh.NomerTrans = md.NomorPJ;
            mdh.Tanggal = op.simpleDate;
            mdh.Diskon = "";
            mdh.Harga_jual = md.Harga_jual;
            mdh.Masuk = "0";
            mdh.Keluar = md.Quantity;
            mdh.Saldo = final.ToString();
            mdh.Aktifitas = aktifitas;
            op.masukHistoriBarangs(mdh);
        }
    }
}
