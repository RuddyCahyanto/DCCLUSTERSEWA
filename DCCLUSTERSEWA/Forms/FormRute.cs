using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DCCLUSTERSEWA.Forms
{
    /// <summary>
    /// TempDeletedRows:: simpan baris yang dihapus user (temporarily)
    /// </summary>
    public partial class FormRute : Form
    {
        public static bool passwordAuthenticated { get; set; }
        DataTable dataTable;
        private List<int> newRowIndex, changedRowIndex;
        DataTable TempDeletedRows;
        DataTable TempChangedRows;
        DataTable TempAddedRows;

        public FormRute()
        {
            InitializeComponent();
            dataTable = new Datasets.Dataset.RUTEDataTable();
        }

        #region Theme Color
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

        private void FormRute_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadTabelRute();
            ResetTempDeletedRowsDT();
        }
        #region Reset Temporary DataTable
        /// <summary>
        /// Kosongkan temporary datatable
        /// </summary>
        private void ResetTempDeletedRowsDT()
        {
            TempDeletedRows = new DataTable();
            TempDeletedRows.Clear();
            TempDeletedRows.Columns.Add("zona");
            TempDeletedRows.Columns.Add("grup");
            TempDeletedRows.Columns.Add("kdtk");
            TempDeletedRows.Columns.Add("kmasli");
            TempDeletedRows.Columns.Add("jlnkhusus");
            TempDeletedRows.Columns.Add("gage");
        }
        #endregion

        private void LoadTabelRute()
        {
            dataTable = Master.GetDT(Master.selectTabelRute(), Master.ConnString);
            //dgvMasterRute.Rows.Clear();
            passwordAuthenticated = false;
            dgvMasterRute.Columns[4].ReadOnly = true;
            dgvMasterRute.DataSource = dataTable;
        }

        private void dgvMasterRute_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (passwordAuthenticated == false)
                {
                    FormPassJlnKhusus frm = new FormPassJlnKhusus();
                    frm.ShowDialog(this);

                    if(passwordAuthenticated == true)
                    {
                        dgvMasterRute.CurrentCell.ReadOnly = false;
                    }
                }
                else
                {
                    dgvMasterRute.CurrentCell.ReadOnly = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string zona, grup, kdtk, kmasli, jlnkhusus, gage;
            DataTable xDataTable = dataTable.GetChanges();

            //Jagaan kalau tidak ada perubahan data
            if (xDataTable == null)
            {
                MessageBox.Show("Tidak ada perubahan data!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataTable.AcceptChanges();
            OracleDataAdapter da = new OracleDataAdapter();
            bool adaError = false;
            for (int i = 0; i < xDataTable.Rows.Count; i++)
            {
                string query = "";

                if (xDataTable.Rows[i].RowState == DataRowState.Added)
                {
                    zona = xDataTable.Rows[i].ItemArray[0].ToString().ToUpper();
                    grup = xDataTable.Rows[i].ItemArray[1].ToString().ToUpper();
                    kdtk = xDataTable.Rows[i].ItemArray[2].ToString().ToUpper();
                    kmasli = xDataTable.Rows[i].ItemArray[3].ToString().ToUpper();
                    jlnkhusus = xDataTable.Rows[i].ItemArray[4].ToString().ToUpper();
                    gage = xDataTable.Rows[i].ItemArray[5].ToString().ToUpper();
                    //insert
                    query = "INSERT INTO CLUSTER_TBRUTE(kddc,zona,grup,kdtk,kmasli,jlnkhusus,gage) " +
                                   "VALUES ('" + Master.KodeDC + "','" + zona + "', '" + grup + "', '" + kdtk + "', " +
                                   "        '" + kmasli + "', '" + jlnkhusus + "', '" + gage + "')";
                }
                else if(xDataTable.Rows[i].RowState == DataRowState.Modified)
                {
                    //get modified data
                    zona = xDataTable.Rows[i].ItemArray[0].ToString().ToUpper();
                    grup = xDataTable.Rows[i].ItemArray[1].ToString().ToUpper();
                    kdtk = xDataTable.Rows[i].ItemArray[2].ToString().ToUpper();
                    kmasli = xDataTable.Rows[i].ItemArray[3].ToString().ToUpper();
                    jlnkhusus = xDataTable.Rows[i].ItemArray[4].ToString().ToUpper();
                    gage = xDataTable.Rows[i].ItemArray[5].ToString().ToUpper();
                    
                    //get original data (before modified)
                    string originZona = xDataTable.Rows[i][0, DataRowVersion.Original].ToString().ToUpper();
                    string originGrup = xDataTable.Rows[i][1, DataRowVersion.Original].ToString().ToUpper();
                    string originKdTk = xDataTable.Rows[i][2, DataRowVersion.Original].ToString().ToUpper();
                    string whereZona = originZona == "" ? "zona is null" : "zona='" + originZona + "'";
                    string whereGrup = originGrup == "" ? "grup is null" : "grup='" + originGrup + "'";
                    string whereKdTk = originKdTk == "" ? "kdtk is null" : "kdtk='" + originKdTk + "'";
                    query = "UPDATE CLUSTER_TBRUTE set zona='" + zona + "', grup='" + grup + "', " +
                            "                          kdtk='" + kdtk + "', kmasli='" + kmasli + "', " +
                            "                          jlnkhusus='" + jlnkhusus + "', gage='" + gage + "' " +
                            "WHERE " + whereZona +" " +
                            "      AND " + whereGrup + " " +
                            "      AND " + whereKdTk + " " +
                            "      AND kddc='" + Master.KodeDC + "'";
                }
                else if(xDataTable.Rows[i].RowState == DataRowState.Deleted)
                {
                    zona = xDataTable.Rows[i][0, DataRowVersion.Original].ToString();
                    grup = xDataTable.Rows[i][1, DataRowVersion.Original].ToString();
                    kdtk = xDataTable.Rows[i][2, DataRowVersion.Original].ToString();

                    query = "DELETE FROM CLUSTER_TBRUTE where zona='" + zona + "' AND grup='" + grup + "' " +
                            " AND kdtk='" + kdtk + "' AND kddc='" + Master.KodeDC + "'";
                }

                bool execute = Master.ExecQuery(query, Master.ConnString);
                if (execute == false)
                {
                    adaError = true;
                }

            }

            if(adaError == false)
            {
                MessageBox.Show("Data berhasil tersimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Terjadi kesalahan, data tidak tersimpan.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvMasterRute_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            object[] row = new object[e.Row.Cells.Count];
            for(int i=0; i < e.Row.Cells.Count; i++)
            {
                row[i] = e.Row.Cells[i].Value;
            }
            TempDeletedRows.Rows.Add(row);
        }
    }
}
