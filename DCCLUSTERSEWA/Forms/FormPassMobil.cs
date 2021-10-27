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
    public partial class FormPassMobil : Form
    {
        public FormPassMobil()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string passMobil = Master.ExecScalar(Master.selectPassMobil(), Master.ConnString).ToString();
            if (passMobil == tbPassword.Text)
            {
                Master.PassMobilAuthenticated = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Password salah!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPassword.Text = "";
                tbPassword.Focus();
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
