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
    public partial class FormSupir : Form
    {
        public FormSupir()
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

        private void FormSupir_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadTabelSupir();
            LoadFilterKelompok();
        }

        private void LoadTabelSupir()
        {
            DataTable dt = new Datasets.Dataset.SupirDataTable();
            dt = Master.GetDT(Master.selectTabelSupir(), Master.ConnString);
            dgvMasterSupir.DataSource = dt;
        }

        private void LoadFilterKelompok()
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            dgvFilterKlmpk.Rows.Clear();
            for(int i=0; i<alphabet.Length; i++)
            {
                dgvFilterKlmpk.Rows.Add();
                dgvFilterKlmpk.Rows[i].Cells[0].Value = alphabet[i];
            }

        }

        private void dgvFilterKlmpk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string filter = dgvFilterKlmpk.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.Cursor = Cursors.WaitCursor;
            DataTable dt = new Datasets.Dataset.SupirDataTable();
            dt = Master.GetDT(Master.selectTabelSupir(filter), Master.ConnString);
            dgvMasterSupir.DataSource = dt;
            this.Cursor = Cursors.Default;
        }
    }
}
