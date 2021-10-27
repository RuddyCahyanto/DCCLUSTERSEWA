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
    public partial class FormNewMobil : Form
    {
        public FormNewMobil()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load data combobox Supir
        /// Display member dan Value member berisi nama kolom di tabel CLUSTER_TBSUPIR 
        /// </summary>
        private void LoadSupir()
        {
            DataTable dt = Master.GetDT(Master.selectComboBoxSupir(), Master.ConnString);
            cbSupir.Text = "--Pilih Supir--";
            cbSupir.DisplayMember = "nik";
            cbSupir.ValueMember = "nik";
            cbSupir.DataSource = dt;
        }

        /// <summary>
        /// Load data combobox tipe mobil
        /// Display member dan Value member berisi nama kolom di tabel CLUSTER_TBTIPEMOBIL
        /// </summary>
        private void LoadTipe()
        {
            DataTable dt = Master.GetDT(Master.selectComboBoxTipeMobil(), Master.ConnString);
            cbType.Text = "--Pilih Tipe Mobil--";
            cbType.DisplayMember = "tipe";
            cbType.ValueMember = "kode";
            cbType.DataSource = dt;
        }

        private void FormNewMobil_Load(object sender, EventArgs e)
        {
            LoadSupir();
            LoadTipe();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string kdmobil = tbKodeMobil.Text;
            string supir = cbSupir.SelectedValue.ToString();
            string nopol = tbNoPolisi.Text;
            string tipe = cbType.SelectedValue.ToString();

            //Ambil kapasitas atau kubikasi mobil
            string kubikasi = Master.GetKapasitasMobil(tipe);

            //INSERT INTO CLUSTER_TBMOBIL
            bool insert = Master.ExecQuery(Master.insertTabelMobil(kdmobil, supir, nopol, tipe, kubikasi), Master.ConnString);
            if(insert == true)
            {
                MessageBox.Show("Data berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormMobil frm = new FormMobil();
                frm.LoadTabelMobil();
                this.Close();
            }
            else
            {
                MessageBox.Show("Terjadi kesalahan. Data gagal disimpan!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cursor = Cursors.Default;
        }
    }
}
