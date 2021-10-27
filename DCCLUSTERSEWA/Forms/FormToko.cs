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
    public partial class FormToko : Form
    {
        DataTable dataTable;
        public FormToko()
        {
            InitializeComponent();
            dataTable = new Datasets.Dataset.TokoDataTable();
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
        private void FormToko_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadTabelToko();
        }

        private void LoadTabelToko()
        {
            //Disable autoresize biar load data lebih cepat
            dgvMasterToko.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvMasterToko.RowHeadersVisible = false;

            //Load data to datagridview
            dataTable = Master.GetDT(Master.selectTabelToko(), Master.ConnString);
            dgvMasterToko.DataSource = dataTable;

            //Enable lagi autoresize
            dgvMasterToko.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dgvMasterToko.RowHeadersVisible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string kode, nama, tgl_buka, tipe_mobil, kota, telp, kantor, ruting, maxcont, maxbronj, maxdoly;
            DataTable xDataTable = dataTable.GetChanges();

            //Jagaan kalau tidak ada perubahan data
            if(xDataTable == null)
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
                    kode = xDataTable.Rows[i][0].ToString().ToUpper();
                    nama = xDataTable.Rows[i][1].ToString().ToUpper();
                    tgl_buka = Convert.ToDateTime(xDataTable.Rows[i][2]).ToString("MM/dd/yyyy");
                    tipe_mobil = xDataTable.Rows[i][3].ToString().ToUpper();
                    kota = xDataTable.Rows[i][4].ToString().ToUpper();
                    telp = xDataTable.Rows[i][5].ToString().ToUpper();
                    kantor = xDataTable.Rows[i][6].ToString().ToUpper();
                    ruting = xDataTable.Rows[i][7].ToString().ToUpper();
                    maxcont = xDataTable.Rows[i][8].ToString().ToUpper();
                    maxbronj = xDataTable.Rows[i][9].ToString().ToUpper();
                    maxdoly = xDataTable.Rows[i][10].ToString().ToUpper();

                    //INSERT
                    query = "INSERT INTO " +
                            "       CLUSTER_TBTOKO (kddc,kdtk,nama,buka,tm,kota,telp,ktr,ruting,maxcontainer,maxbronjong,maxdoly) " +
                            "VALUES ('" + Master.KodeDC + "', " +
                            "        '" + kode + "'," +
                            "        '" + nama + "'," +
                            "        to_date('" + tgl_buka + "', 'MM/dd/yyyy')," +
                            "        '" + tipe_mobil + "'," +
                            "        '" + kota + "'," +
                            "        '" + telp + "'," +
                            "        '" + kantor + "'," +
                            "        '" + ruting + "'," +
                            "        '" + maxcont + "'," +
                            "        '" + maxbronj + "'," +
                            "        '" + maxdoly + "')";
                }
                else if(xDataTable.Rows[i].RowState == DataRowState.Modified)
                {
                    //Modified
                    kode = xDataTable.Rows[i][0].ToString().ToUpper();
                    nama = xDataTable.Rows[i][1].ToString().ToUpper();
                    tgl_buka = Convert.ToDateTime(xDataTable.Rows[i][2]).ToString("MM/dd/yyyy");
                    tipe_mobil = xDataTable.Rows[i][3].ToString().ToUpper();
                    kota = xDataTable.Rows[i][4].ToString().ToUpper();
                    telp = xDataTable.Rows[i][5].ToString().ToUpper();
                    kantor = xDataTable.Rows[i][6].ToString().ToUpper();
                    ruting = xDataTable.Rows[i][7].ToString().ToUpper();
                    maxcont = xDataTable.Rows[i][8].ToString().ToUpper();
                    maxbronj = xDataTable.Rows[i][9].ToString().ToUpper();
                    maxdoly = xDataTable.Rows[i][10].ToString().ToUpper();

                    //Original (before modified)
                    string kodetoko = xDataTable.Rows[i][0, DataRowVersion.Original].ToString().ToUpper();

                    query = "UPDATE CLUSTER_TBTOKO SET kdtk='" + kode + "', " +
                            "                          nama='" + nama + "', " +
                            "                          buka=to_date('" + tgl_buka +"', 'MM/dd/yyyy'), " +
                            "                          tm='" + tipe_mobil +"', " +
                            "                          kota='" + kota + "', " +
                            "                          telp='" + telp + "', " +
                            "                          ktr='" + kantor + "', " +
                            "                          ruting='" + ruting + "', " +
                            "                          maxcontainer='" + maxcont + "', " +
                            "                          maxbronjong='" + maxbronj + "', " +
                            "                          maxdoly='" + maxdoly + "' " +
                            "WHERE kdtk='" + kodetoko + "' AND kddc='" + Master.KodeDC + "'";
                }
                else if(xDataTable.Rows[i].RowState == DataRowState.Deleted)
                {
                    //Original (before modified)
                    string kodetoko = xDataTable.Rows[i][0, DataRowVersion.Original].ToString().ToUpper();

                    query = "DELETE FROM CLUSTER_TBTOKO WHERE kdtk='" + kodetoko + "' AND kddc='" + Master.KodeDC + "'";
                }

                bool execute = Master.ExecQuery(query, Master.ConnString);

                if(execute == false)
                {
                    adaError = true;
                }
            }

            if(adaError == false)
            {
                MessageBox.Show("Data berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.WaitCursor;
                LoadTabelToko();
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Terjadi kesalahan. Data gagal tersimpan!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
