using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCCLUSTERSEWA.Forms
{
    public partial class FormSetting : Form
    {
        //List<String> param = new List<string>() { "DirBackup", "FtpServer", "FtpUser", "FtpPass",
        //                                              "FtpPort", "FtpDir", "PemisahCSV", "NamaFileNPB",
        //                                              "NamaFileRPB"};
        
        /// <summary>
        /// Update - 26 Oktober 2021
        /// Usulan Pak Ridwan: Form FTP dihilangkan karena tidak digunakan.
        /// </summary>
        List<String> param = new List<string>() { "DirBackup", "PemisahCSV", "NamaFileNPB",
                                                      "NamaFileRPB"};

        public FormSetting()
        {
            InitializeComponent();
        }
        #region Load Theme Color
        /// <summary>
        /// Set warna button sesuai dengan warna tema
        /// </summary>
        private void LoadTheme()
        {
            foreach (Control ctrls in this.Controls)
            {
                if (ctrls.GetType() == typeof(Button))
                {
                    Button btn = (Button)ctrls;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                if (ctrls.GetType() == typeof(GroupBox))
                {
                    GroupBox gb = (GroupBox)ctrls;
                    foreach (Control btns in gb.Controls)
                    {
                        if (btns.GetType() == typeof(Button))
                        {
                            Button btn = (Button)btns;
                            btn.BackColor = ThemeColor.PrimaryColor;
                            btn.ForeColor = Color.White;
                            btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                        }
                    }
                }
            }
        }
        #endregion
        private void FormSetting_Load(object sender, EventArgs e)
        {
            LoadTheme();
            Master.GetTbSettingVariabel();
            LoadInfoDC();
            LoadInfoKoneksi();
            LoadTextBoxSetting();
        }

        private void LoadTextBoxSetting()
        {
            //Dir. Backup
            tbDirBackup.Text = Master.DirBackup;

            /*
                26 Oktober 2021 - Update
                Usulan Pak Ridwan: Form FTP dihilangkan karena secara data tidak digunakan.
            */
            ////Server FTP
            //tbServerFTP.Text = Master.ServerFtp;

            ////User FTP
            //tbUserFTP.Text = Master.UserFtp;

            ////Password FTP
            //tbPassFTP.Text = Master.PasswordFtp;

            ////Port FTP
            //tbPortFTP.Text = Master.PortFtp;

            ////Dir. FTP
            //tbDirFTP.Text = Master.DirFtp;

            //Pemisah CSV
            if (Master.PemisahCSV == ",")
            {
                rbKoma.Checked = true;
                rbPipe.Checked = false;
            }
            else if (Master.PemisahCSV == "|")
            {
                rbKoma.Checked = false;
                rbPipe.Checked = true;
            }
            else
            {
                rbKoma.Checked = false;
                rbPipe.Checked = false;
            }


            //Nama File NPB
            tbNmFileNPB.Text = Master.NamaFileNPB;

            //Nama File RPB
            tbNmFileRPB.Text = Master.NamaFileRPB;
        }

        private void LoadInfoDC()
        {
            tbKodeDC.Text = Master.KodeDC;
            tbNamaDC.Text = Master.NamaDC;
        }

        private void LoadInfoKoneksi()
        {
            tbServer.Text = Master.ServerOracle;
            tbUser.Text = Master.UserOracle;
            tbPassword.Text = Master.PasswordOracle;
        }

        private void btnDirBackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();

            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                tbDirBackup.Text = browserDialog.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var pemisahCSV = rbPipe.Checked == true ? "|" : ",";
            
            List<String> nilai = new List<string>();
            nilai.Add(tbDirBackup.Text);
            //nilai.Add(tbServerFTP.Text);
            //nilai.Add(tbUserFTP.Text);
            //nilai.Add(tbPassFTP.Text);
            //nilai.Add(tbPortFTP.Text);
            //nilai.Add(tbDirFTP.Text);
            nilai.Add(pemisahCSV);
            nilai.Add(tbNmFileNPB.Text);
            nilai.Add(tbNmFileRPB.Text);
            //nilai.Add(.Text);
            //nilai.Add(tbDirFTP.Text);


            for(int i= 0; i < param.Count; i++)
            {
                bool isExist = IsParamExist(param[i]);
                if (isExist == true)
                {
                    //update
                    bool updateNilai = Master.ExecQuery(Master.updateNilaiSetting(param[i], nilai[i]), Master.ConnString);
                }
                else
                {
                    //insert
                    bool insertNilai = Master.ExecQuery(Master.insertParamSetting(param[i], nilai[i]), Master.ConnString);
                }
            }
            MessageBox.Show("Data berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool IsParamExist(string param)
        {
            object paramExist = Master.ExecScalar(Master.selectParamSetting(param), Master.ConnString);
            return Convert.ToBoolean(paramExist);
        }
        public bool IsPassLamaSama(string param, string passLama)
        {
            string queryPassLama = "SELECT NILAI FROM CLUSTER_TBSETTING WHERE param='" + param + "' AND KDDC = '" + Master.KodeDC + "'";
            string passOld = Master.ExecScalar(queryPassLama, Master.ConnString).ToString();

            if (passLama == passOld)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnNewPassMobil_Click(object sender, EventArgs e)
        {
            FormNewPassMobil frmPassMobil = new FormNewPassMobil();
            frmPassMobil.ShowDialog(this);
        }

        private void btnNewPassKunci_Click(object sender, EventArgs e)
        {
            FormNewPassKunci frmPassKunci = new FormNewPassKunci();
            frmPassKunci.ShowDialog();
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            if(Master.DBConnected == true)
            {
                MessageBox.Show("Koneksi berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Koneksi gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
