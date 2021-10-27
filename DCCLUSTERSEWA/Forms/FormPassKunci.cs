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
    public partial class FormPassKunci : Form
    {
        public FormPassKunci()
        {
            InitializeComponent();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOK_Click(btnOK, new EventArgs());
                btnOK.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string passKunci = Master.ExecScalar(Master.selectPassKunci(), Master.ConnString).ToString();

            if(tbPassword.Text == passKunci)
            {
                Master.PassKunciAuthenticated = true;
                this.Close();
            }
            else
            {
                Master.PassKunciAuthenticated = false;
                MessageBox.Show("Password salah!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPassword.Text = "";
                tbPassword.Focus();
            }
        }
    }
}
