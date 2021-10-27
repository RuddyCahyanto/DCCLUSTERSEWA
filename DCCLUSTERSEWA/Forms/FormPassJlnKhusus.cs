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
    public partial class FormPassJlnKhusus : Form
    {
        private bool klikBtnOK;
        public FormPassJlnKhusus()
        {
            InitializeComponent();
            klikBtnOK = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string passwordJlKhusus = Master.ExecScalar(Master.selectPassJlnKhusus(), Master.ConnString).ToString();
            if(passwordJlKhusus == tbPassword.Text)
            {
                var frmRute = new FormRute();
                frmRute.dgvMasterRute.Columns[4].ReadOnly = false;
                FormRute.passwordAuthenticated = true;
                klikBtnOK = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Password salah!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPassword.Text = "";
                tbPassword.Focus();
            }
        }

        private void FormPassJlnKhusus_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Jika user keluar melalui tombol X (tidak memasukkan password)
            //Kolom tetap readonly
            if(klikBtnOK == false)
            {
                var frmRute = new FormRute();
                frmRute.dgvMasterRute.Columns[4].ReadOnly = true;
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btnOK_Click(btnOK, new EventArgs());
                btnOK.Focus();
            }
        }
    }
}
