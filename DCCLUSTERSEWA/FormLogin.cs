using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCCLUSTERSEWA
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string username = tbUsername.Text.ToUpper();
            string password = tbPassword.Text.ToUpper();

            bool login = Master.IsLoggedIn(username, password);
            if(login == true)
            {
                bool secureLogin = Master.IsSecureLogin(username);
                if(secureLogin == true)
                {
                    Hide();
                    Main frmMain = new Main();
                    frmMain.Show();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    tbPassword.Text = "";
                    tbUsername.Text = "";
                    tbUsername.Focus();
                }
            }
            else
            {
                MessageBox.Show("Username/password salah! Silahkan periksa kembali.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        #region Setting Form Text
        /// <summary>
        /// Set nama aplikasi, versi dan nama form
        /// </summary>
        private void SetFormText()
        {
            string AppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string AppVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = AppName + ".EXE " + "version: " + AppVersion + " | LOGIN";
        }
        #endregion

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //string NPB = String.Format("{0:D6}", 4972) + "9996";
            //MessageBox.Show(NPB);
            if (Master.IsDCSewa() == false)
            {
                MessageBox.Show("Program hanya bisa berjalan di server DC Sewa!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            else
            {
                Master.Cek_Program_2(Master.KodeDC);
                SetFormText();
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(btnLogin, new System.EventArgs());
                btnLogin.Focus();
            }
        }
    }
}
