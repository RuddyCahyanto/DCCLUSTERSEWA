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
    public partial class FormNewPassMobil : Form
    {
        public FormNewPassMobil()
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

        private void FormNewPassMobil_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string passLama = tbPassLama.Text;
            string passBaru = tbPassBaru.Text;
            string passKonf = tbKonfirPass.Text;
            string param = "PassMobil";

            if(passBaru != passKonf)
            {
                MessageBox.Show("Konfirmasi password tidak sama!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbKonfirPass.Focus();
                return;
            }

            FormSetting frmSetting = new FormSetting();
            bool isParamExist = frmSetting.IsParamExist(param);
            bool execute = false;
            if(isParamExist == true)
            {
                //Cek Pass lama apakah sama dengan database
                if (frmSetting.IsPassLamaSama(param, passLama) == false)
                {
                    MessageBox.Show("Password lama tidak ditemukan!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbPassLama.Text = "";
                    tbPassLama.Focus();
                    return;
                }
                execute = Master.ExecQuery(Master.updateNilaiSetting(param, passKonf), Master.ConnString);
            }
            else
            {
                execute = Master.ExecQuery(Master.insertParamSetting(param, passKonf), Master.ConnString);
            }

            if(execute == false)
            {
                MessageBox.Show("Terjadi kesalahan, password gagal tersimpan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Password berhasil tersimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
