using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace DCCLUSTERSEWA.Forms
{
    public partial class FormGO : Form
    {
        bool newpage;
        string NPBKunci;
        bool paketKirimTerbentuk;
        List<string> KodeToko = new List<string>();
        Dictionary<string, string> PaketPengiriman = new Dictionary<string, string>(); //key: NOPB, value: KodeToko
        public FormGO()
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
                if (ctrls.GetType() == typeof(Panel))
                {
                    Panel panel = (Panel)ctrls;
                    foreach (Control btns in panel.Controls)
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
        private void FormGO_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadTabelGO();
            LoadMobil();
            LoadSupir();
            Loadkunci();
            paketKirimTerbentuk = false;
        }

        private void LoadTabelGO()
        {
            DataTable dt = Master.GetDT(Master.selectTabelGO(), Master.ConnString);
            dgvProsesGO.Rows.Clear();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                dgvProsesGO.Rows.Add();
                dgvProsesGO.Rows[i].Cells[0].Value = Convert.ToDateTime(dt.Rows[i]["tanggal"]).ToString("dd/MM/yyyy");
                dgvProsesGO.Rows[i].Cells[1].Value = dt.Rows[i]["kdtoko"];
                dgvProsesGO.Rows[i].Cells[2].Value = dt.Rows[i]["nama"];
                dgvProsesGO.Rows[i].Cells[3].Value = dt.Rows[i]["nopb"];
                dgvProsesGO.Rows[i].Cells[4].Value = dt.Rows[i]["kubikreal"];
                dgvProsesGO.Rows[i].Cells[5].Value = dt.Rows[i]["kdmobil"];
                dgvProsesGO.Rows[i].Cells[6].Value = dt.Rows[i]["kdsupir1"];
                dgvProsesGO.Rows[i].Cells[7].Value = dt.Rows[i]["nokunci"];
            }
        }

        private void LoadMobil()
        {
            DataTable dt = Master.GetDT(Master.selectDropDownGoMobil(), Master.ConnString);
            cbKodeMobil.Text = "--Pilih Kode Mobil--";
            cbKodeMobil.DisplayMember = "kd_mobil";
            cbKodeMobil.ValueMember = "nopol_tipe";
            cbKodeMobil.DataSource = dt;
        }

        private void LoadSupir()
        {
            DataTable dt = Master.GetDT(Master.selectDropDownGoSupir(), Master.ConnString);
            cbSupir.Text = "--Pilih Supir--";
            cbSupir.DisplayMember = "nik";
            cbSupir.ValueMember = "nama";
            cbSupir.DataSource = dt;
        }

        private void Loadkunci()
        {
            DataTable dt = Master.GetDT(Master.selectDropDownGoKunci(), Master.ConnString);
            cbKunci.Text = "--Pilih Kunci--";
            cbKunci.DisplayMember = "nokunci";
            cbKunci.ValueMember = "pass";
            cbKunci.DataSource = dt;
        }

        private void tbFind_Click(object sender, EventArgs e)
        {
            if(tbFind.Text == "Kode/Nama/NoPB")
            {
                tbFind.Text = "";
            }
        }

        private void tbFind_Leave(object sender, EventArgs e)
        {
            if (tbFind.Text == "")
            {
                tbFind.Text = "Kode/Nama/NoPB";
            }
        }

        private void tbFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                string searchString = tbFind.Text.ToUpper();
                FindSearchValue(searchString);
            }
        }

        private void FindSearchValue(string searchString)
        {
            if (searchString == "")
            {
                LoadTabelGO();
            }
            else
            {
                DataTable dt = Master.GetDT(Master.selectSearchValueTabelGO(searchString), Master.ConnString);
                dgvProsesGO.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvProsesGO.Rows.Add();
                    dgvProsesGO.Rows[i].Cells[0].Value = Convert.ToDateTime(dt.Rows[i]["tanggal"]).ToString("dd/MM/yyyy");
                    dgvProsesGO.Rows[i].Cells[1].Value = dt.Rows[i]["kdtoko"];
                    dgvProsesGO.Rows[i].Cells[2].Value = dt.Rows[i]["nama"];
                    dgvProsesGO.Rows[i].Cells[3].Value = dt.Rows[i]["nopb"];
                    dgvProsesGO.Rows[i].Cells[4].Value = dt.Rows[i]["kubikreal"];
                    dgvProsesGO.Rows[i].Cells[5].Value = dt.Rows[i]["kdmobil"];
                    dgvProsesGO.Rows[i].Cells[6].Value = dt.Rows[i]["kdsupir1"];
                    dgvProsesGO.Rows[i].Cells[7].Value = dt.Rows[i]["nokunci"];
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbKodeMobil.Text == "" || cbSupir.Text == "" || cbKunci.Text == "")
                {
                    MessageBox.Show("Data tidak lengkap!");
                    return;
                }

                bool adaChecked = false;
                int urut = 1;
                string no_kunci = cbKunci.Text;
                string pass = cbKunci.SelectedValue.ToString();
                string tipe_mobil = cbKodeMobil.SelectedValue.ToString().Split('-')[1].Trim();
                string no_polisi = cbKodeMobil.SelectedValue.ToString().Split('-')[0].Trim();
                string kd_mobil = cbKodeMobil.Text;
                string kd_supir = cbSupir.Text;
                string nama_supir = cbSupir.SelectedValue.ToString();

                foreach (DataGridViewRow row in dgvProsesGO.Rows)
                {
                    bool isChecked = (row.Cells["check"].Value == DBNull.Value) || (row.Cells["check"].Value == null) ? false : true;
                    if (isChecked == true)
                    {
                        adaChecked = true;
                        string kdtoko = row.Cells[1].Value.ToString();
                        string nopb = row.Cells[3].Value.ToString();
                        //code here...
                        //UPDATE CLUSTER_TBBACKUPSEWA
                        string queryUpdateBackup = Master.updatePaketKirim(urut.ToString(), no_kunci, pass, tipe_mobil, kd_mobil,no_polisi, kd_supir,nama_supir,kdtoko,nopb);
                        bool updateBackupSewa = Master.ExecQuery(queryUpdateBackup, Master.ConnString);

                        //UPDATE Mobil sedang dipakai
                        string queryMobil = Master.updateStatusMobil(kd_mobil, "1");
                        bool updateStatMobil = Master.ExecQuery(queryMobil, Master.ConnString);

                        //UPDATE Kunci sedang dipakai
                        string queryKunci = Master.updateStatusKunci(no_kunci, "1");
                        bool updateStatKunci = Master.ExecQuery(queryKunci, Master.ConnString);

                        //Jika berhasil terupdate semua, set paketKirimTerbentuk ke true, simpan nopb dan kdtoko
                        if(updateBackupSewa == updateStatMobil == updateStatKunci == true) {
                            //paketKirimTerbentuk = true;
                            //KodeToko.Add(kdtoko);
                            PaketPengiriman[nopb] = kdtoko;
                            urut += 1;
                        }
                        //Jika ada yang error/gagal terupdate, reset tabel yang sebelumnya sudah berhasil di update
                        else
                        {
                            //paketKirimTerbentuk = false;
                            PaketPengiriman[nopb] = kdtoko;
                            foreach (string nomorpb in PaketPengiriman.Keys)
                            {
                                //UPDATE CLUSTER_TBBACKUPSEWA
                                string queryUpdateBackupReset = Master.updatePaketKirim("", "", "", "", "", "", "", "", PaketPengiriman[nomorpb], nomorpb);
                                bool updateBackupSewaReset = Master.ExecQuery(queryUpdateBackupReset, Master.ConnString);

                                //UPDATE Mobil sedang dipakai
                                string queryMobilReset = Master.updateStatusMobil(kd_mobil, "0");
                                bool updateStatMobilReset = Master.ExecQuery(queryMobilReset, Master.ConnString);

                                //UPDATE Kunci sedang dipakai
                                string queryKunciReset = Master.updateStatusKunci(no_kunci, "0");
                                bool updateStatKunciReset = Master.ExecQuery(queryKunciReset, Master.ConnString);
                            }
                            PaketPengiriman.Clear();
                            break;
                        }

                    }
                }

                if (adaChecked == false)
                {
                    MessageBox.Show("Pilih toko terlebih dahulu!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadMobil();
                Loadkunci();
                LoadSupir();
                LoadTabelGO();
                if(PaketPengiriman.Count > 0)
                {
                    MessageBox.Show("Paket pengiriman tersimpan...");
                }
                else 
                {
                    MessageBox.Show("Terjadi kesalahan...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                //paketKirimTerbentuk = false;
                MessageBox.Show("Error: {0}", ex.Message);
            }
        }

        DataTable dtHdrCetak = new DataTable();
        private void btnGO_Click(object sender, EventArgs e)
        {
            if(PaketPengiriman.Count == 0)
            {
                MessageBox.Show("Belum ada paket pengiriman!");
                return;
            }

            //Show Loading Spinner
            loadingSpinnerGO.Visible = true;

            //Generate No SJ
            Master.runprocClusterSewaCreateSJ();

            //Generate Kode Barcode
            if(PaketPengiriman.Count > 0)
            {
                foreach (string nopb in PaketPengiriman.Keys)
                {
                    Master.KdToko = PaketPengiriman[nopb];
                    Master.NmToko = GetNamaToko(Master.KdToko);

                    string queryHeader = " SELECT a.*,b.*,c.mbr_singkatan ,to_char(npb_date,'dd') Tanggal," +
                                         "        to_char(npb_date,'mm') BUlan," +
                                         "        NVL(b.sj_qty,0)/GET_HRGBELI_FRAC(a.DC_KODE,b.PLU_ID) AS sj_qty_ctn," +
                                         "        GET_HRGBELI_FRAC(a.DC_KODE,b.PLU_ID) fraction   " +
                                         " FROM DC_PICK_HDR_h a," +
                                         "      dc_pick_dtl_h b," +
                                         "      dc_barang_dc_v c " +
                                         " WHERE DC_KODE = '" + Master.KodeDC + "' AND ALOKASIID IS NOT NULL" +
                                         " AND a.seq_no=b.seq_fk_no  --and a.seq_no=36583\n " +
                                         " AND Tok_Kode = '" + Master.KdToko + "' and npb_no is not null " +
                                         " AND b.PLU_ID=c.mbr_fk_pluid  ORDER BY npb_date,plu_id";
                    dtHdrCetak = Master.GetDT(queryHeader, Master.ConnString);
                    if(dtHdrCetak.Rows.Count > 0)
                    {
                        string Tok_Kode = dtHdrCetak.Rows[0]["Tok_Kode"].ToString();
                        int npb_no = Convert.ToInt32(dtHdrCetak.Rows[0]["NPB_NO"]);
                        string tglNPB = dtHdrCetak.Rows[0]["tanggal"].ToString();
                        string bulanNPB = dtHdrCetak.Rows[0]["bulan"].ToString();
                        string NPB = string.Format(String.Format("{0:D6}", npb_no) + "9996");
                        NPBKunci = Master.Caesar_Encrypt_AllNumeric(NPB, tglNPB, bulanNPB);

                        //Update Kolom Barcode
                        string query = "UPDATE CLUSTER_TBBACKUPSEWA SET KODE_BARCODE='" + NPBKunci + "' " +
                                       "WHERE kdtoko='" + Tok_Kode + "' AND " +
                                       "      nopb='" + nopb + "'";
                        bool updateBarcode = Master.ExecQuery(query, Master.ConnString);

                        //Cetak Rangkuman
                        LoadPrint(false);
                    }
                }
            }

            //Show Loading Spinner
            loadingSpinnerGO.Visible = false;
            MessageBox.Show("Selesai...");
        }

        /// <summary>
        /// dialog: jika false, maka langsung print
        ///         jika true, maka show print preview dialog
        /// </summary>
        /// <param name="dialog"></param>
        private void LoadPrint(bool dialog)
        {
            newpage = true;
            mRow = 0;

            string printerShare = "";

            if(dialog == false)
            {
                foreach (string prInstall in PrinterSettings.InstalledPrinters)
                {
                    if (printerShare.ToUpper().Contains(prInstall.ToString().ToUpper()))
                    {
                        printDocument1.PrinterSettings.PrinterName = prInstall;
                        printDocument1.Print();
                        break;
                    }
                }
            }
            else
            {
                printPreviewDialog1.Document = printDocument1; //PrintPreviewDialog associate with PrintDocument.
                printPreviewDialog1.WindowState = FormWindowState.Maximized;
                printPreviewDialog1.ShowDialog();
            }

        }

        private string GetNamaToko(string kdtoko)
        {
            string query = "SELECT TOK_NAME FROM DC_TOKO_T WHERE TOK_CODE = '" + kdtoko + "'";
            string namatoko = Master.ExecScalar(query, Master.ConnString).ToString();
            return namatoko;
        }

        /// <summary>
        /// Hide checkbox toko yang sudah buat paket pengiriman
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProsesGO_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //e.RowIndex >= 0, untuk skip bagian header atau judul kolom (index header = -1)
            //columnIndex = 8, index kolom checkbox
            if(e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                string kdmobil = dgvProsesGO.Rows[e.RowIndex].Cells[5].Value == null ? "" : dgvProsesGO.Rows[e.RowIndex].Cells[5].Value.ToString();
                string kdsupir = dgvProsesGO.Rows[e.RowIndex].Cells[6].Value == null ? "" : dgvProsesGO.Rows[e.RowIndex].Cells[6].Value.ToString();
                string nokunci = dgvProsesGO.Rows[e.RowIndex].Cells[7].Value == null ? "" : dgvProsesGO.Rows[e.RowIndex].Cells[7].Value.ToString();

                if(kdmobil != "" && kdsupir != "" && nokunci != "")
                {
                    e.PaintBackground(e.ClipBounds, true);
                    e.Handled = true;
                    dgvProsesGO.Rows[e.RowIndex].Cells[8].ReadOnly = true;
                }
            }
        }

        int mRow;
        int mHal;
        int mBaris = 0;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string Lin1 = "", Lin11 = "", Lin12 = "", Lin13 = "", Lin14 = "";
            string Lin2 = "", Lin21 = "", Lin22 = "", Lin23 = "", Lin24 = "";

            Font FontBarcode = new Font("Free 3 of 9 Extended", 32, FontStyle.Regular);
            Font FontJudul = new Font("Courier", 9, FontStyle.Regular);
            Font FontJudul1 = new Font("Courier", 12, FontStyle.Bold);
            Font FontDetail = new Font("Courier", 8, FontStyle.Regular);
            Font FontDetail2 = new Font("Courier", 8, FontStyle.Regular);
            Single Y = 100;


            Lin1 = "Kode Toko  : " + Master.KdToko;
            Lin2 = "Nama Toko  : " + Master.NmToko;

            e.Graphics.DrawString("*" + NPBKunci + "*", FontBarcode, Brushes.Black, 350, 25);
            e.Graphics.DrawString(NPBKunci, FontJudul, Brushes.Black, 600, 80);
            e.Graphics.DrawString("PT. INDOMARCO PRISMATAMA", FontJudul, Brushes.Black, 30, 100);
            //If MReprint Then
            //    e.Graphics.DrawString(KodeDC & "-" & NamaDC, FontJudul, Brushes.Black, 30, 120);
            //    e.Graphics.DrawString("Reprint", FontJudul, Brushes.Black, 630, 120);
            //Else
            e.Graphics.DrawString(Master.KodeDC + "-" + Master.NamaDC, FontJudul, Brushes.Black, 30, 120);
            //End If
            e.Graphics.DrawString("RANGKUMAN", FontJudul1, Brushes.Black, 300, 135);
            e.Graphics.DrawString("NOTA PENGIRIMAN BARANG", FontJudul1, Brushes.Black, 250, 155);
            e.Graphics.DrawString(Lin1, FontJudul, Brushes.Black, 30, 175);
            e.Graphics.DrawString(Lin11, FontJudul, Brushes.Black, 400, 175);
            e.Graphics.DrawString(Lin12, FontJudul, Brushes.Black, 700, 175);
            e.Graphics.DrawString(Lin2, FontJudul, Brushes.Black, 30, 195);
            e.Graphics.DrawString(Lin21, FontJudul, Brushes.Black, 400, 195);
            e.Graphics.DrawString(Lin22, FontJudul, Brushes.Black, 700, 195);
            e.Graphics.DrawLine(Pens.Black, 30, 215, 700, 215);

            e.Graphics.DrawString("No.Npb", FontJudul, Brushes.Black, 30, 220);
            e.Graphics.DrawString("Tanggal", FontJudul, Brushes.Black, 80, 220);
            e.Graphics.DrawString("PLU", FontJudul, Brushes.Black, 170, 220);
            e.Graphics.DrawString("Nama", FontJudul, Brushes.Black, 250, 220);
            e.Graphics.DrawString("Frac", FontJudul, Brushes.Black, 450, 220);
            e.Graphics.DrawString("Qty", FontJudul, Brushes.Black, 550, 220);
            e.Graphics.DrawString("Ctn", FontJudul, Brushes.Black, 650, 220);

            e.Graphics.DrawLine(Pens.Black, 30, 240, 700, 240);
            if(newpage == true)
            {
                mRow = 0;
            }

            mBaris = 240;
            do
            {
                mBaris = mBaris + 20;
                e.Graphics.DrawString(dtHdrCetak.Rows[mRow]["npb_no"].ToString(), FontJudul, Brushes.Black, 30, mBaris);
                e.Graphics.DrawString(Convert.ToDateTime(dtHdrCetak.Rows[mRow]["npb_date"]).ToString("dd-MM-yyyy"), FontJudul, Brushes.Black, 80, mBaris);
                e.Graphics.DrawString(dtHdrCetak.Rows[mRow]["plu_id"].ToString(), FontJudul, Brushes.Black, 170, mBaris);
                e.Graphics.DrawString(dtHdrCetak.Rows[mRow]["mbr_singkatan"].ToString(), FontJudul, Brushes.Black, 250, mBaris);
                e.Graphics.DrawString(dtHdrCetak.Rows[mRow]["Fraction"].ToString(), FontJudul, Brushes.Black, 460, mBaris);
                e.Graphics.DrawString(MakeStr(String.Format("{0:n0}", Convert.ToInt32(dtHdrCetak.Rows[mRow]["sj_qty"])), 10, 2), FontJudul, Brushes.Black, 550, mBaris);
                e.Graphics.DrawString(MakeStr(String.Format("{0:n0}", Convert.ToInt32(dtHdrCetak.Rows[mRow]["sj_qty_ctn"])), 10, 2), FontJudul, Brushes.Black, 650, mBaris);

                if(mBaris > 740)
                {
                    mBaris = mBaris + 20;
                    mHal += 1;
                    e.Graphics.DrawLine(Pens.Black, 30, mBaris, 600, mBaris);
                    mBaris = mBaris + 15;
                    e.Graphics.DrawString("Page : " + mHal.ToString(), FontDetail, Brushes.Black, 550, mBaris);
                    e.HasMorePages = true;
                    newpage = false;
                    mRow += 1;
                    return;
                }
                mRow += 1;

            }
            while (mRow < dtHdrCetak.Rows.Count);

            mBaris = mBaris + 20;
            e.Graphics.DrawLine(Pens.Black, 30, mBaris, 700, mBaris);
            mBaris = mBaris + 20;
            //e.Graphics.DrawString("   Diterima                 Diserahkan                  Disetujui           Dibuat        ", FontJudul, Brushes.Black, 30, mBaris)
            e.Graphics.DrawString("Diterima", FontJudul, Brushes.Black, 50, mBaris);
            e.Graphics.DrawString("Diserahkan", FontJudul, Brushes.Black, 250, mBaris);
            e.Graphics.DrawString("Disetujui", FontJudul, Brushes.Black, 350, mBaris);
            e.Graphics.DrawString("Dibuat", FontJudul, Brushes.Black, 550, mBaris);

            mBaris = mBaris + 60;
            // e.Graphics.DrawString("   (Ka/Ass/Md Toko Idm)   (Delivery Driver)           (Issuing SPV)   (............)      ", FontJudul, Brushes.Black, 30, mBaris)
            e.Graphics.DrawString("(Ka/Ass/Md Toko Idm) ", FontJudul, Brushes.Black, 35, mBaris);
            e.Graphics.DrawString("(Delivery Driver)", FontJudul, Brushes.Black, 235, mBaris);
            e.Graphics.DrawString("(Issuing SPV) ", FontJudul, Brushes.Black, 335, mBaris);
            e.Graphics.DrawString("(..................) ", FontJudul, Brushes.Black, 535, mBaris);
            mBaris = mBaris + 20;
            e.Graphics.DrawLine(Pens.Black, 30, mBaris, 700, mBaris);

            e.HasMorePages = false;
        }

        private string MakeStr(string W, int panjang, int rata)
        {
            int panjangW = W.Length;
            string result="";

            if(panjangW > panjang)
            {
                result = W.Substring(0, panjang);
            }
            else if(panjangW < panjang)
            {
                if(rata == 1)
                {
                    result = W + Microsoft.VisualBasic.Strings.Space(panjang - panjangW);
                }
                else if(rata == 2)
                {
                    result = Microsoft.VisualBasic.Strings.Space(panjang - panjangW) + W;
                }
            }
            else if(panjangW == panjang)
            {
                result = W;
            }
            return result;
        }
    }
}
