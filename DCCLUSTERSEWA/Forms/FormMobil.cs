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
    public partial class FormMobil : Form
    {
        DataTable dataTable;
        public FormMobil()
        {
            InitializeComponent();
            dataTable = new Datasets.Dataset.MobilDataTable();
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

        private void FormMobil_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadTabelMobil();
        }

        internal void LoadTabelMobil()
        {
            //Disable autoresize biar load data lebih cepat
            dgvMasterMobil.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvMasterMobil.RowHeadersVisible = false;

            dataTable = Master.GetDT(Master.selectTabelMobil(), Master.ConnString);
            dgvMasterMobil.DataSource = dataTable;

            //Enable lagi autoresize
            dgvMasterMobil.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dgvMasterMobil.RowHeadersVisible = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormNewMobil frm = new FormNewMobil();
            frm.ShowDialog(this);

            LoadTabelMobil();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            string kdmobil, nopol, supir, tipe, kubikasi, gps;
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
                if(xDataTable.Rows[i].RowState == DataRowState.Modified)
                {
                    //New Value
                    kdmobil = xDataTable.Rows[i]["kd_mobil"].ToString().ToUpper();
                    nopol = xDataTable.Rows[i]["no_polisi"].ToString().ToUpper();
                    supir = xDataTable.Rows[i]["supir"].ToString().ToUpper();
                    tipe = xDataTable.Rows[i]["tipe"].ToString().ToUpper();
                    gps = xDataTable.Rows[i]["gps"].ToString();
                    kubikasi = Master.GetKapasitasMobil(tipe);


                    //Old Value
                    string kdmobil_old = xDataTable.Rows[i]["kd_mobil", DataRowVersion.Original].ToString();
                    string status_old = xDataTable.Rows[i]["status", DataRowVersion.Original].ToString();

                    if(status_old != "0")
                    {
                        MessageBox.Show("Hanya bisa mengupdate mobil dengan status = '0'!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        adaError = true;
                        continue;
                    }

                    //UPDATE
                    query = "UPDATE CLUSTER_TBMOBIL SET kd_mobil='" + kdmobil + "', " +
                            "                           no_polisi='" + nopol + "', " +
                            "                           nik='" + supir + "', " + //supir
                            "                           ukuran='" + tipe + "', " + //tipe
                            "                           kubikasi='" + kubikasi + "', " +
                            "                           gps='" + gps + "' " +
                            "WHERE kd_mobil='" + kdmobil_old + "' AND kddc='" + Master.KodeDC + "' AND status='0'"; 
                }
                else if(xDataTable.Rows[i].RowState == DataRowState.Deleted)
                {
                    //Old Value
                    string kdmobil_old = xDataTable.Rows[i]["kd_mobil", DataRowVersion.Original].ToString();
                    string status_old = xDataTable.Rows[i]["status", DataRowVersion.Original].ToString();

                    if (status_old != "0")
                    {
                        MessageBox.Show("Hanya bisa menghapus mobil dengan status = '0'!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        adaError = true;
                        continue;
                    }

                    //DELETE
                    query = "DELETE FROM CLUSTER_TBMOBIL " +
                            "WHERE kd_mobil='" + kdmobil_old + "' AND kddc='" + Master.KodeDC + "' AND status='0'";
                }

                bool exec = Master.ExecQuery(query, Master.ConnString);
                
                if(exec == false)
                {
                    adaError = true;
                }
            }

            if(adaError == true)
            {
                MessageBox.Show("Terjadi kesalahan. Beberapa data tidak dapat tersimpan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Data berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadTabelMobil();
            Cursor = Cursors.Default;
        }
    }
}
