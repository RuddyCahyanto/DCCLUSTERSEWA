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
    public partial class FormTipeMobil : Form
    {
        DataTable dataTable;
        public FormTipeMobil()
        {
            InitializeComponent();
            dataTable = new Datasets.Dataset.TIPE_MOBILDataTable();
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

        private void FormTipeMobil_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadTabelTipeMobil();
        }

        private void LoadTabelTipeMobil()
        {
            dataTable = Master.GetDT(Master.selectTipeMobil(), Master.ConnString);
            dgvMasterTipeMobil.DataSource = dataTable;
        }
    }
}
