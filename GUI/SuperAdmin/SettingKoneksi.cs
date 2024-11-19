using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using KasirApp.Model;
using System.IO;
using Newtonsoft.Json;

namespace KasirApp.GUI.SuperAdmin
{
    public partial class SettingKoneksi : Form
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        SettingModel newSetting = new SettingModel();

        public SettingKoneksi()
        {
            InitializeComponent();

            string path = Path.GetDirectoryName(Application.ExecutablePath);

            string filePath = Path.GetDirectoryName(Application.ExecutablePath) + $@"\Model\config.json";

            string jsonfile = File.ReadAllText(filePath);
            var setting = JsonConvert.DeserializeObject<SettingModel>(jsonfile);

            txtServer.Text = setting.Server ?? "";
            txtDatabase.Text = setting.Database ?? "";
            txtPort.Text = setting.Port ?? "";
            txtUser.Text = setting.User ?? "";
            txtPassword.Text = setting.Password ?? "";
            txtEndpoint.Text = setting.Endpoint ?? "";
            txtCabang.Text = setting.Cabang ?? "";

            newSetting = setting;
        }

        public void NumericOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtEndpoint.Text == "" || txtDatabase.Text == "" || txtPassword.Text == "" || txtUser.Text == "" || txtPort.Text == "" || txtServer.Text == "")
            {
                mb.PeringatanOK("Tolong Lengkapi Data!");
            }
            else
            {
                string path = Path.GetDirectoryName(Application.ExecutablePath);

                string filePath = Path.GetDirectoryName(Application.ExecutablePath) + $@"\Model\config.json";

                newSetting.Database = txtDatabase.Text;
                newSetting.Server = txtServer.Text;
                newSetting.Port = txtPort.Text;
                newSetting.User = txtUser.Text;
                newSetting.Password = txtPassword.Text;
                newSetting.Endpoint = txtEndpoint.Text;
                newSetting.Cabang = txtCabang.Text;

                string jsonString = JsonConvert.SerializeObject(newSetting, Formatting.Indented);
                File.WriteAllText(filePath, jsonString);

                mb.InformasiOK("Data berhasil Di edit");
            }
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            try
            {
                //Buka File Dialog Untuk Memilih File yang benar
                var fileResult = openFile();

                //cek apakah File ada
                if (File.Exists(fileResult.Filepath))
                {
                    //Process data yang terimport
                    var processedData = JsonConvert.DeserializeObject<SettingModel>(fileResult.Filecontent);

                    //spesifikan path file default
                    string path = Path.GetDirectoryName(Application.ExecutablePath);

                    //read file default
                    string filePath = Path.GetDirectoryName(Application.ExecutablePath) + $@"\Model\config.json";

                    //assign data terimport ke file default
                    newSetting.Database = processedData.Database ?? "";
                    newSetting.Server = processedData.Server ?? "";
                    newSetting.Port = processedData.Port ?? "";
                    newSetting.User = processedData.User ?? "";
                    newSetting.Password = processedData.Password ?? "";
                    newSetting.Endpoint = processedData.Endpoint ?? "";
                    newSetting.Cabang = processedData.Cabang ?? "";
                    newSetting.LokasiConfig = fileResult.Filepath ?? "";

                    //Formatting dan simpan Data yang ter update
                    string jsonString = JsonConvert.SerializeObject(newSetting, Formatting.Indented);
                    File.WriteAllText(filePath, jsonString);

                    //re assign data ke textbox
                    reAssign(processedData);

                    mb.InformasiOK("Sukses import Konfigurasi!");
                }
            }
            catch (Exception ex)
            {
                mb.peringatanError(ex.Message);
            }
        }

        public FileModel openFile()
        {
            var finalFile = new FileModel();

            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                ofd.Title = "Pilih File Configurasi";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var result = new FileModel()
                    {
                        Filepath = ofd.FileName,
                        Filecontent = File.ReadAllText(ofd.FileName)
                    };

                    finalFile = result;
                }

            }

            return finalFile;
        }

        public void reAssign(SettingModel setting)
        {
            txtServer.Text = setting.Server ?? "";
            txtDatabase.Text = setting.Database ?? "";
            txtPort.Text = setting.Port ?? "";
            txtUser.Text = setting.User ?? "";
            txtPassword.Text = setting.Password ?? "";
            txtEndpoint.Text = setting.Endpoint ?? "";
            txtCabang.Text = setting.Cabang ?? "";
        }
    }

    public class FileModel {
        string filepath;
        string filecontent;

        public string Filepath { get => filepath; set => filepath = value; }
        public string Filecontent { get => filecontent; set => filecontent = value; }
    }
}
