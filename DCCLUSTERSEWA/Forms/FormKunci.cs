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
    public partial class FormKunci : Form
    {
        DataTable dataTable;
        public FormKunci()
        {
            InitializeComponent();
            dataTable = new Datasets.Dataset.KunciDataTable();
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

        private void FormKunci_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadTabelKunci();
        }

        private void LoadTabelKunci()
        {
            this.Cursor = Cursors.WaitCursor;
            dataTable = Master.GetDT(Master.selectTabelKunci(), Master.ConnString);
            dgvMasterKunci.DataSource = dataTable;
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// DELETE / INSERT jika status = 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string kddc, no_kunci, pass, pass_old, tgl_update_pass, status;

            DataTable xDataTable = dataTable.GetChanges();

            //Jagaan kalau tidak ada perubahan data
            if (xDataTable == null)
            {
                MessageBox.Show("Tidak ada perubahan data!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool adaError = false;

            for(int i = 0; i < xDataTable.Rows.Count; i++)
            {
                string query = "";
                if(xDataTable.Rows[i].RowState == DataRowState.Added)
                {
                    //New Value
                    kddc = xDataTable.Rows[i][0].ToString().ToUpper();
                    no_kunci = xDataTable.Rows[i][1].ToString().ToUpper();
                    pass = xDataTable.Rows[i][2].ToString().ToUpper();
                    //pass_old = xDataTable.Rows[i][3, DataRowVersion.Original].ToString().ToUpper();
                    //tgl_update_pass = xDataTable.Rows[i][4].ToString().ToUpper();
                    status = xDataTable.Rows[i][5].ToString().ToUpper() == "" ? "0" : xDataTable.Rows[i][5].ToString().ToUpper();

                    if (status != "0")
                    {
                        MessageBox.Show("Hanya dapat menambahkan kunci dengan status = 0.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    //INSERT
                    query = "INSERT INTO CLUSTER_TBKUNCI (kddc, nokunci, pass, tgl_updpass, status) " +
                            "VALUES ('" + kddc + "'," +
                            "        '" + no_kunci + "'," +
                            "        '" + pass +"'," +
                            "        SYSDATE," +
                            "        '" + status +"')";
                }
                else if(xDataTable.Rows[i].RowState == DataRowState.Modified)
                {
                    //New Value
                    kddc = xDataTable.Rows[i][0].ToString().ToUpper();
                    no_kunci = xDataTable.Rows[i][1].ToString().ToUpper();
                    pass = xDataTable.Rows[i][2].ToString().ToUpper();
                    pass_old = xDataTable.Rows[i][2, DataRowVersion.Original].ToString().ToUpper();
                    //tgl_update_pass = xDataTable.Rows[i][4].ToString().ToUpper();
                    status = xDataTable.Rows[i][5].ToString().ToUpper();

                    //Old Value
                    string kddc_old = xDataTable.Rows[i][0, DataRowVersion.Original].ToString();
                    string nokunci_old = xDataTable.Rows[i][1, DataRowVersion.Original].ToString();

                    //UPDATE
                    if(pass != pass_old)
                    {
                        query = "UPDATE CLUSTER_TBKUNCI SET kddc='" + kddc + "'," +
                            "                           nokunci='" + no_kunci + "'," +
                            "                           pass='" + pass + "'," +
                            "                           pass_old='" + pass_old + "'," +
                            "                           tgl_updpass=SYSDATE," +
                            "                           status='" + status + "' " +
                            "WHERE kddc='" + kddc_old + "' AND nokunci='" + nokunci_old + "'";
                    }
                    else
                    {
                        query = "UPDATE CLUSTER_TBKUNCI SET kddc='" + kddc + "'," +
                            "                           nokunci='" + no_kunci + "'," +
                            "                           pass='" + pass + "'," +
                            "                           status='" + status + "' " +
                            "WHERE kddc='" + kddc_old + "' AND nokunci='" + nokunci_old + "'";
                    }
                }
                else if(xDataTable.Rows[i].RowState == DataRowState.Deleted)
                {
                    //Old Value
                    string kddc_old = xDataTable.Rows[i][0, DataRowVersion.Original].ToString();
                    string nokunci_old = xDataTable.Rows[i][1, DataRowVersion.Original].ToString();
                    string status_old = xDataTable.Rows[i][5, DataRowVersion.Original].ToString();
                    if(status_old != "0")
                    {
                        MessageBox.Show("Hanya dapat menghapus kunci dengan status = 0.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    //DELETE
                    query = "DELETE FROM CLUSTER_TBKUNCI WHERE kddc='" + kddc_old + "' AND nokunci='" + nokunci_old + "'";
                }

                bool execute = Master.ExecQuery(query, Master.ConnString);
                if(adaError == false && execute == false)
                {
                    adaError = true;
                }
            }

            if (adaError == false)
            {
                MessageBox.Show("Data berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTabelKunci();
            }
            else
            {
                MessageBox.Show("Terjadi kesalahan. Data gagal tersimpan!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
