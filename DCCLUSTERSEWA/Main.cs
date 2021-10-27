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
    public partial class Main : Form
    {
        private Button currentButton;
        private Button currentParentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public Main()
        {
            InitializeComponent();
            customizeDesign();
            random = new Random();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            SetFormText();
        }

        #region Setting Form Text
        /// <summary>
        /// Set nama aplikasi, versi dan nama form
        /// </summary>
        private void SetFormText()
        {
            string AppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string AppVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = AppName + ".EXE " + "version: " + AppVersion;
        }
        #endregion

        #region customizeDesign
        /// <summary>
        /// Show Hide Submenu
        /// </summary>
        private void customizeDesign()
        {
            panelSubMenuMaster.Visible = false;
            panelSubMenuProses.Visible = false;
        }

        private void hideSubMenu()
        {
            if(panelSubMenuMaster.Visible == true)
            {
                panelSubMenuMaster.Visible = false;
            }
            if(panelSubMenuProses.Visible == true)
            {
                panelSubMenuProses.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnMasterMenu_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuMaster);
        }
        
        private void btnProsesMenu_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuProses);
        }
        #endregion

        #region Theme Color and Navigation Menu Setting
        /// <summary>
        /// Ambil warna #asdasd return as rgb
        /// Warna bisa ditambahkan di class ThemeColor
        /// </summary>
        /// <returns></returns>
        private Color SelectThemeColor()
        {
            return ColorTranslator.FromHtml(ThemeColor.ColorList);
        }

        /// <summary>
        /// Set warna button Menu ketika di klik
        /// 1. Reset warna menu ke default
        /// 2. Set warna menu yang diklik
        /// </summary>
        /// <param name="btnSender">button menu yang diklik</param>
        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        /// <summary>
        /// Reset warna button Menu ke default
        /// </summary>
        private void DisableButton()
        {
            foreach(Control previousButton in panelSubMenuMaster.Controls)
            {
                if(previousButton.GetType() == typeof(Button))
                {
                    previousButton.BackColor = Color.FromArgb(51,51,76);
                    previousButton.ForeColor = Color.Gainsboro;
                    previousButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }

            foreach (Control previousButton in panelSubMenuProses.Controls)
            {
                if (previousButton.GetType() == typeof(Button))
                {
                    previousButton.BackColor = Color.FromArgb(51, 51, 76);
                    previousButton.ForeColor = Color.Gainsboro;
                    previousButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        /// <summary>
        /// Buka halaman menu di template Main.cs
        /// </summary>
        /// <param name="childForm">Form yang akan dibuka</param>
        /// <param name="btnSender">Button menu yang diklik</param>
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        #endregion

        #region Menu Button onClick Event
        private void btnMasterSetting_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenChildForm(new Forms.FormSetting(), sender);
            this.Cursor = Cursors.Default;
        }

        private void btnMasterToko_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenChildForm(new Forms.FormToko(), sender);
            this.Cursor = Cursors.Default;
        }

        private void btnMasterRute_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenChildForm(new Forms.FormRute(), sender);
            this.Cursor = Cursors.Default;
        }

        private void btnMasterTipeMobil_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenChildForm(new Forms.FormTipeMobil(), sender);
            this.Cursor = Cursors.Default;
        }

        private void btnMasterMobil_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (Master.PassMobilAuthenticated == true)
            {
                OpenChildForm(new Forms.FormMobil(), sender);
            }
            else
            {
                Forms.FormPassMobil frmPassMobil = new Forms.FormPassMobil();
                frmPassMobil.ShowDialog();

                if (Master.PassMobilAuthenticated == true)
                {
                    OpenChildForm(new Forms.FormMobil(), sender);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void btnMasterSupir_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenChildForm(new Forms.FormSupir(), sender);
            this.Cursor = Cursors.Default;
        }

        private void btnMasterKunci_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            if(Master.PassKunciAuthenticated == true)
            {
                OpenChildForm(new Forms.FormKunci(), sender);
            }
            else
            {
                Forms.FormPassKunci frm = new Forms.FormPassKunci();
                frm.ShowDialog();

                if (Master.PassKunciAuthenticated == true)
                {
                    OpenChildForm(new Forms.FormKunci(), sender);
                }
            }
            
            this.Cursor = Cursors.Default;
        }

        private void btnProsesBackup_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenChildForm(new Forms.FormBackup(), sender);
            this.Cursor = Cursors.Default;
        }

        private void btnProsesGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenChildForm(new Forms.FormGO(), sender);
            this.Cursor = Cursors.Default;
        }
        #endregion

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Apakah Anda yakin akan keluar?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
