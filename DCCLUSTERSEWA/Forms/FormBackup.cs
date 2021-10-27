using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentAce.Compression.Archiver;
using ComponentAce.Compression.ZipForge;

namespace DCCLUSTERSEWA.Forms
{
    public partial class FormBackup : Form
    {
        DataTable dataTable;
        string msgCreateCluster;
        string msgCreateTransaksi;
        List<string> KodeToko;
        string NamaFileNPB, NamaFileRPB;
        public FormBackup()
        {
            InitializeComponent();
            dataTable = new Datasets.Dataset.BACKUPDataTable();
            KodeToko = new List<string>();
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

        private void FormBackup_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadTabelBackup();
            Master.GetTbSettingVariabel();
        }

        private void btnCreateUlangNPB_Click(object sender, EventArgs e)
        {
            FormCreateUlangNPB frm = new FormCreateUlangNPB();
            frm.ShowDialog(this);
        }

        private void LoadTabelBackup()
        {
            dataTable = Master.GetDT(Master.selectTabelBackup(), Master.ConnString);
            dgvProsesBackup.DataSource = dataTable;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if(dgvProsesBackup.Rows.Count == 0)
            {
                MessageBox.Show("Data kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            for (int i = 0; i < dgvProsesBackup.Rows.Count; i++)
            {
                string kdtoko = dgvProsesBackup.Rows[i].Cells[0].Value.ToString();
                KodeToko.Add(kdtoko);
            }

            //Create Cluster
            Master.runprocCreateCluster();

            //Create File NPB RPB
            CreateNPBRPB(KodeToko);

            LoadTabelBackup();
            MessageBox.Show("Selesai...");
        }

        //private void CreateCluster()
        //{
        //    if(Master.runprocCreateCluster() == true)
        //    {
        //        msgCreateCluster = "Pembuatan cluster berhasil. ";
        //    }
        //}

        private void CreateNPBRPB(List<string> KodeToko)
        {
            try
            {
                DataTable dataHeader = new DataTable();
                DataTable dataNPB = new DataTable();
                DataTable noTglNPB = new DataTable();
                string ConnStringTxt = Master.KoneksiToTxt(Application.StartupPath);
                int NoSeqAlokasi;
                string NoNPB = "";
                string TglNPB = "";
                string TimeStr = DateTime.Now.ToString("yyyyMMddHHmm");

                //Show loading spin
                loadingSpinnerBackup.Visible = true;
                progressBarBackup.Style = ProgressBarStyle.Blocks;
                progressBarBackup.Value = 0;
                progressBarBackup.Minimum = 0;
                progressBarBackup.Maximum = KodeToko.Count;
                progressBarBackup.Visible = true;

                for (int i=0; i<KodeToko.Count; i++)
                {
                    //Progress label show
                    progressBarBackup.Value += 1;
                    lblProgressBackup.Text = "Process NPB " + (i + 1) + "/" + KodeToko.Count + " - " + KodeToko[i];
                    lblProgressBackup.Visible = true;
                    Application.DoEvents();

                    dataHeader.Clear();
                    dataHeader = Master.GetDT(Master.selectDataHeader(KodeToko[i]), Master.ConnString);
                    if(dataHeader.Rows.Count > 0)
                    {
                        for(int j=0; j < dataHeader.Rows.Count; j++)
                        {
                            NoSeqAlokasi = 1;
                            int seqno = Convert.ToInt32(dataHeader.Rows[j]["Seq_No"]);

                            if (Master.runprocNPB_PBSL_SEWA2(KodeToko[i], seqno) == true)
                            {
                                dataNPB.Clear();
                                dataNPB = Master.GetDT(Master.selectDataNPB(seqno), Master.ConnString);
                                if(dataNPB.Rows.Count > 0)
                                {
                                    //Ambil no npb dan tgl npb
                                    noTglNPB.Clear();
                                    noTglNPB = Master.GetDT(Master.selectNoTglNPB(KodeToko[i], seqno), Master.ConnString);
                                    if(noTglNPB.Rows.Count > 0)
                                    {
                                        NoNPB = noTglNPB.Rows[0]["NPB_NO"].ToString();
                                        TglNPB = noTglNPB.Rows[0]["NPB_DATE"].ToString();
                                        TimeStr = noTglNPB.Rows[0]["times"].ToString();
                                    }

                                    if(Master.IsNPBWeb() == true)
                                    {
                                        Master.CreateNPB(KodeToko[i], NoNPB, TglNPB);
                                    }
                                    else
                                    {
                                        if(Master.IsTokoNPBWeb(KodeToko[i]) == true)
                                        {
                                            Master.CreateNPB(KodeToko[i], NoNPB, TglNPB);
                                        }
                                        else
                                        {
                                            //Create NPB File
                                            NamaFileNPB = Master.NamaFileNPB + Master.KodeDC + KodeToko[i] + TimeStr;
                                            NamaFileRPB = Master.NamaFileRPB + Master.KodeDC + KodeToko[i] + TimeStr;

                                            //Create File
                                            Master.CreateNPBFile(NamaFileNPB, Application.StartupPath);
                                            Master.CreateRPBFile(NamaFileRPB, Application.StartupPath);

                                            string[] dataPerKolom = new string[27];
                                            for(int k = 0; k < dataNPB.Rows.Count; k++)
                                            {
                                                dataPerKolom[0] = "*" + "|";
                                                dataPerKolom[1] = "|";
                                                dataPerKolom[2] = NoNPB + "|";
                                                dataPerKolom[3] = NoSeqAlokasi.ToString() + "|";
                                                dataPerKolom[4] = dataNPB.Rows[k]["Seq_Fk_No"] + "|";
                                                dataPerKolom[5] = "|";
                                                dataPerKolom[6] = Convert.ToDateTime(TglNPB).ToString("dd-MM-yyyy") + "|";
                                                dataPerKolom[7] = dataNPB.Rows[k]["PLU_KODE"] + "|";
                                                dataPerKolom[8] = dataNPB.Rows[k]["Mbr_Singkatan"] + "|";
                                                dataPerKolom[9] = dataNPB.Rows[k]["MBR_FK_DIV"] + "|";
                                                dataPerKolom[10] = dataNPB.Rows[k]["Qty"] + "|";
                                                dataPerKolom[11] = dataNPB.Rows[k]["Sj_Qty"] + "|";
                                                dataPerKolom[12] = dataNPB.Rows[k]["Price_NPB"] + "|";
                                                dataPerKolom[13] = Math.Round(Convert.ToDecimal(dataNPB.Rows[k]["Sj_Qty"]) * Convert.ToDecimal(dataNPB.Rows[k]["Price_NPB"]),0, MidpointRounding.AwayFromZero) + "|";
                                                dataPerKolom[14] = dataNPB.Rows[k]["PPn_Jual"] + "|";
                                                dataPerKolom[15] = dataNPB.Rows[k]["Mbr_Acost"] + "|";
                                                dataPerKolom[16] = dataHeader.Rows[j]["Tok_Kode"] + "|";

                                                if(dataNPB.Rows[k]["Keter1"] == null)
                                                {
                                                    dataPerKolom[17] = dataHeader.Rows[j]["Keter"].ToString().Replace(",", " ") + "|";
                                                }
                                                else
                                                {
                                                    dataPerKolom[17] = dataNPB.Rows[k]["Keter1"].ToString().Replace(",", " ") + "|";
                                                }
                                                
                                                
                                                dataPerKolom[18] = Convert.ToDateTime(TglNPB).ToString("dd-MM-yyyy") + "|";
                                                dataPerKolom[19] = Convert.ToDateTime(dataHeader.Rows[j]["Doc_Date"]).ToString("dd-MM-yyyy") + "|";
                                                dataPerKolom[20] = dataHeader.Rows[j]["Doc_No"] + "|";
                                                dataPerKolom[21] = dataNPB.Rows[k]["Pla_Line"] + "|";
                                                dataPerKolom[22] = dataNPB.Rows[k]["Pla_Rak"] + "|";
                                                dataPerKolom[23] = dataNPB.Rows[k]["Pla_Shelf"] + "|";
                                                dataPerKolom[24] = dataHeader.Rows[j]["Dc_Kode"] + "|";
                                                dataPerKolom[25] = "|";

                                                if(dataNPB.Rows[k]["tglexp"] == DBNull.Value)
                                                {
                                                    dataPerKolom[26] = "";
                                                }
                                                else
                                                {
                                                    dataPerKolom[26] = Convert.ToDateTime(dataNPB.Rows[i]["tglexp"]).ToString("dd-MM-yyyy");
                                                }

                                                //Write per baris
                                                string dataPerBaris = string.Join("", dataPerKolom);
                                                using (StreamWriter sw = new StreamWriter(Application.StartupPath + "/" + NamaFileNPB + ".CSV", true))
                                                {
                                                    sw.WriteLine(dataPerBaris);
                                                }
                                                NoSeqAlokasi += 1;
                                            }
                                        }
                                    }
                                }
                                //END IF DataNPB.Rows.Count > 0

                                //Start delete data oracle
                                string queryDtl = "Delete From Dc_Pick_Dtl_NPB Where Seq_Fk_no = " + seqno;
                                bool deleteDtl = Master.ExecQuery(queryDtl, Master.ConnString);

                                string queryHdr = "Delete From Dc_Pick_Hdr_NPB Where Seq_no = " + seqno;
                                bool deleteHdr = Master.ExecQuery(queryHdr, Master.ConnString);
                            }
                        }
                        //End For loop dataHeader.Rows

                        #region START Buat RPB
                        DataTable DataNPBNew = new DataTable();
                        DataTable DataDocnoNew = new DataTable();
                        string[] FieldList = new string[26];

                        if(File.Exists(Application.StartupPath + "/" + NamaFileNPB + ".CSV"))
                        {
                            FieldList[0] = "RECID" + " char";
                            FieldList[1] = "RTYPE" + " char";
                            FieldList[2] = "DOCNO" + " char";
                            FieldList[3] = "SEQNO" + " char";
                            FieldList[4] = "PICNO" + " char";
                            FieldList[5] = "PICNOT" + " char";
                            FieldList[6] = "PICTGL" + " char";
                            FieldList[7] = "PRDCD" + " char";
                            FieldList[8] = "NAMA" + " char";
                            FieldList[9] = "DIV" + " char";
                            FieldList[10] = "QTY" + " char";
                            FieldList[11] = "SJ_QTY" + " char";
                            FieldList[12] = "PRICE" + " char";
                            FieldList[13] = "GROSS" + " char";
                            FieldList[14] = "PPNRP" + " char";
                            FieldList[15] = "HPP" + " char";
                            FieldList[16] = "TOKO" + " char";
                            FieldList[17] = "KETER" + " char";
                            FieldList[18] = "TANGGAL1" + " char";
                            FieldList[19] = "TANGGAL2" + " char";
                            FieldList[20] = "DOCNO2" + " char";
                            FieldList[21] = "LT" + " char";
                            FieldList[22] = "RAK" + " char";
                            FieldList[23] = "BAR" + " char";
                            FieldList[24] = "KIRIM" + " char";
                            FieldList[25] = "DUS_NO" + " char";

                            Master.CreateSchemaIni(NamaFileNPB + ".CSV", Application.StartupPath, 25, FieldList, true);

                            DataNPBNew = Master.GetDTFromTxt("SELECT DocNo FROM `" + NamaFileNPB + ".CSV` GROUP BY Docno", ConnStringTxt);
                            if(DataNPBNew.Rows.Count > 0)
                            {
                                string qDocnoNew = "SELECT Toko,Docno,Tanggal1,Sum(Sj_Qty) as xQty ,Sum(Gross) as xGross," + 
                                                     "Count(*) as Item FROM `" + NamaFileNPB + ".CSV` GROUP BY " + 
                                                     "Toko,Docno,Tanggal1";
                                DataDocnoNew = Master.GetDTFromTxt(qDocnoNew, ConnStringTxt);

                                if(DataDocnoNew.Rows.Count > 0)
                                {
                                    string tanggal;
                                    string[] tgl;
                                    DateTime hasil;
                                    using(StreamWriter sw = new StreamWriter(Application.StartupPath + "/" + NamaFileRPB + ".CSV", true))
                                    {
                                        for (int idx = 0; idx < DataDocnoNew.Rows.Count; idx++)
                                        {
                                            DataTable dataCari = new DataTable();
                                            string[] fStr = new string[7];

                                            tanggal = DataDocnoNew.Rows[idx]["Tanggal1"].ToString();
                                            tgl = tanggal.Split('-');
                                            hasil = new DateTime(Convert.ToInt32(tgl[2]), Convert.ToInt32(tgl[1]), Convert.ToInt32(tgl[0]));

                                            fStr[0] = DataDocnoNew.Rows[idx]["DocNo"].ToString() + "|";
                                            fStr[1] = hasil.ToString("dd-MM-yyyy") + "|";
                                            fStr[2] = DataDocnoNew.Rows[idx]["Toko"] + "|";
                                            fStr[3] = Master.KodeDC + "|";
                                            fStr[4] = DataDocnoNew.Rows[idx]["Item"].ToString() + "|";
                                            fStr[5] = DataDocnoNew.Rows[idx]["xQty"].ToString().Trim() + "|";
                                            fStr[6] = DataDocnoNew.Rows[idx]["xGross"].ToString().Trim();

                                            string str = string.Join("", fStr);
                                            sw.WriteLine(str);
                                        }
                                    }
                                }

                            }
                        }
                        DataNPBNew = null;
                        DataDocnoNew = null;
                        #endregion

                        #region START ZIPPING DATA
                        string nmFileNPBZIP = Application.StartupPath + "/" + NamaFileNPB + ".ZIP";
                        string nmFileNPBCSV = Application.StartupPath + "/" + NamaFileNPB + ".CSV";
                        string nmFileRPBCSV = Application.StartupPath + "/" + NamaFileRPB + ".CSV";
                        bool zipBerhasil = ZippingData(nmFileNPBCSV, nmFileRPBCSV, nmFileNPBZIP);

                        if(zipBerhasil == true)
                        {
                            //Update Data CLUSTER_TBBACKUPSEWA
                            string query = "UPDATE CLUSTER_TBBACKUPSEWA SET NAMAFILE='" + NamaFileNPB + "', " +
                                           "                                TGLCREATEORIGINAL=SYSDATE " +
                                           "WHERE kdtoko='" + KodeToko[i] + "' AND kddc='" + Master.KodeDC + "'";
                            bool updateTBBackup = Master.ExecQuery(query, Master.ConnString);
                        }
                        #endregion

                        #region Start Backup Data sebelum kirim data ke ftp
                        string DirekBackup = Master.DirBackup + "/" + DateTime.Today.Day.ToString();
                        string filePath = Application.StartupPath + "/" + NamaFileNPB + ".ZIP";
                        BackupData(DirekBackup, filePath);
                        #endregion

                        #region Start Delete NPB File yg di lokal
                        if(File.Exists(Application.StartupPath + "/" + NamaFileNPB + ".ZIP")){
                            File.Delete(Application.StartupPath + "/" + NamaFileNPB + ".ZIP");
                        }
                        if (File.Exists(Application.StartupPath + "/" + NamaFileNPB + ".CSV"))
                        {
                            File.Delete(Application.StartupPath + "/" + NamaFileNPB + ".CSV");
                        }
                        if (File.Exists(Application.StartupPath + "/" + NamaFileRPB + ".CSV"))
                        {
                            File.Delete(Application.StartupPath + "/" + NamaFileRPB + ".CSV");
                        }
                        if (File.Exists(Application.StartupPath + "/SCHEMA.INI"))
                        {
                            File.Delete(Application.StartupPath + "/SCHEMA.INI");
                        }
                        #endregion
                    }
                }

                //Hide Progress Bar
                progressBarBackup.Value = 0;
                lblProgressBackup.Visible = false;
                progressBarBackup.Visible = false;
                loadingSpinnerBackup.Visible = false;
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Master.ShowError("Error - BuatNPBGudangSewa", ex);
            }
        }

        private bool ZippingData(string nmFileNPBCSV, string nmFileRPBCSV, string nmFileNPBZIP)
        {
            if (File.Exists(nmFileNPBCSV))
            {
                if (File.Exists(nmFileRPBCSV))
                {
                    ZipForge archiver = new ZipForge();
                    try
                    {
                        // The name of the ZIP file to be created
                        archiver.FileName = nmFileNPBZIP;
                        // Specify FileMode.Create to create a new ZIP file
                        // or FileMode.Open to open an existing archive
                        archiver.OpenArchive(System.IO.FileMode.Create);
                        // Default path for all operations                
                        //archiver.BaseDir = "C:\"
                        // Add file C:\file.txt the archive; wildcards can be used as well                
                        archiver.AddFiles(nmFileNPBCSV);
                        archiver.AddFiles(nmFileRPBCSV);
                        // Close archive
                        archiver.CloseArchive();

                        return true;
                        // Catch all exceptions of the ArchiverException type
                    }
                    catch (ArchiverException ex)
                    {
                        Console.WriteLine("Message: {0} Error code: {1}", ex.Message, ex.ErrorCode);
                        //Wait for keypress
                        Console.ReadLine();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Handle click event untuk button Hapus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProsesBackup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Jika klik row header, langsung return
            if(e.RowIndex < 0)
            {
                return;
            }
            
            if(e.ColumnIndex == dgvProsesBackup.Columns["x"].Index)
            {
                string kdtoko = dgvProsesBackup.Rows[e.RowIndex].Cells[0].Value.ToString();
                string seqno = Master.ExecScalar("select seq_no from dc_pick_hdr_t where tok_kode='" + kdtoko + "'", Master.ConnString).ToString();

                DialogResult result = MessageBox.Show("Apakah Anda yakin?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;

                    //Delete DTL
                    string queryDelDtl = "DELETE FROM DC_PICK_DTL_T WHERE SEQ_FK_NO='" + seqno + "'";
                    bool deleteDtl = Master.ExecQuery(queryDelDtl, Master.ConnString);

                    //Delete HDR
                    string queryDelHdr = "DELETE FROM DC_PICK_HDR_T WHERE TOK_KODE = '" + kdtoko + "' AND SEQ_NO='" + seqno + "'";
                    bool deleteHdr = Master.ExecQuery(queryDelHdr, Master.ConnString);

                    if (deleteHdr == true && deleteDtl == true)
                    {
                        //Update Flag Unpick
                        string queryUpdFlag = "UPDATE dc_pick_hdr_npb SET UNPICK='Y' " +
                                              "WHERE TOK_KODE='" + kdtoko + "' AND SEQ_NO='" + seqno + "'";
                        bool updFlag = Master.ExecQuery(queryUpdFlag, Master.ConnString);

                        MessageBox.Show("Data berhasil dihapus...", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTabelBackup();
                    }
                    else
                    {
                        MessageBox.Show("Terjadi kesalahan...", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadTabelBackup();
                    }

                    Cursor = Cursors.Default;
                }
                else
                {
                    return;
                }

                

                //MessageBox.Show("Toko: " + kdtoko + "\nSeqno: " + seqno);
            }
        }

        private void BackupData(string DirekBackup, string filePath)
        {
            if (!Directory.Exists(DirekBackup))
            {
                Directory.CreateDirectory(DirekBackup);
            }

            if (File.Exists(filePath))
            {
                if (!File.Exists(DirekBackup + "/" + NamaFileNPB + ".ZIP"))
                {
                    File.Copy(filePath, DirekBackup + "/" + NamaFileNPB + ".ZIP", true);
                }
                else
                {
                    for (int counter = 1; counter <= 100; counter++)
                    {
                        if (!File.Exists(DirekBackup + "/" + NamaFileNPB + "(" + counter.ToString().Trim() + ").ZIP"))
                        {
                            File.Copy(filePath, DirekBackup + "/" + NamaFileNPB + "(" + counter.ToString().Trim() + ").ZIP", true);
                            break;
                        }
                    }
                }
            }
        }
    }
}
