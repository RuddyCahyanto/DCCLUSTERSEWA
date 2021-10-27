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

namespace DCCLUSTERSEWA.Forms
{
    public partial class FormCreateUlangNPB : Form
    {
        public FormCreateUlangNPB()
        {
            InitializeComponent();
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();

            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                tbFolderBackup.Text = browserDialog.SelectedPath;
            }
        }

        private void btnCreateNPB_Click(object sender, EventArgs e)
        {
            DataTable dtToko = new DataTable();
            string tanggal = Convert.ToDateTime(dtpTanggal.Value).ToString("yyyyMMddHHmm");
            string direktori = tbFolderBackup.Text.ToUpper();
            string kdtoko = tbKodeToko.Text.ToUpper();
            if(direktori == "")
            {
                MessageBox.Show("Direktori kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string queryToko = "";
                string tgl = Convert.ToDateTime(dtpTanggal.Value).ToString("dd/MM/yyyy");
                if(kdtoko == "")
                {
                    queryToko = "Select Distinct Tok_Kode,NPB_NO,NPB_DATE,to_char(npb_date,'yyyymmddhhmi') times From Dc_Pick_Hdr_H " + 
                                "Where To_Date(NPB_Date,'DD/MM/RR')=To_Date('" + tgl + "','DD/MM/RR')";
                }
                else
                {
                    queryToko = "Select Distinct Tok_Kode,NPB_NO,NPB_DATE,to_char(npb_date,'yyyymmddhhmi') times From Dc_Pick_Hdr_H " + 
                                "Where To_Date(NPB_Date,'DD/MM/RR')=To_Date('" + tgl + "','DD/MM/RR') " + 
                                "AND UPPER(Tok_Kode) = '" + kdtoko + "'";
                }
                dtToko.Clear();
                dtToko = Master.GetDT(queryToko, Master.ConnString);


                if (dtToko.Rows.Count > 0)
                {
                    //Show progress bar
                    progressBarCreateNPB.Value = 0;
                    progressBarCreateNPB.Minimum = 0;
                    progressBarCreateNPB.Maximum = dtToko.Rows.Count;
                    progressBarCreateNPB.Visible = true;
                    loadingSpinnerCreateNPB.Visible = true;
                    Cursor = Cursors.WaitCursor;

                    for (int i=0; i<dtToko.Rows.Count; i++)
                    {
                        progressBarCreateNPB.Value += 1;

                        string kodetoko = dtToko.Rows[i]["Tok_Kode"].ToString();
                        string noNPB = dtToko.Rows[i]["Npb_No"].ToString();
                        string tglNPB = dtToko.Rows[i]["Npb_Date"].ToString();


                        if (Master.IsNPBWeb())
                        {
                            string query = "SELECT count(*) FROM DC_NPBTOKO_LOG_V WHERE log_tok_kode='" + dtToko.Rows[i]["Tok_Kode"] + "' " + 
                             " AND  log_jenis='NPB' and log_no_npb=" + dtToko.Rows[i]["npb_no"] + " and status='Y'";
                            int count = Convert.ToInt32(Master.ExecScalar(query, Master.ConnString));
                            
                            if(count > 0)
                            {
                                tanggal = dtToko.Rows[i]["times"].ToString();
                                if (Master.IsNPBWeb())
                                {
                                    Master.CreateUlangNPB(kodetoko, noNPB, tglNPB);
                                    BuatUlangFileNPB(kodetoko, dtpTanggal.Value, direktori, tanggal);
                                }
                                else if (Master.IsTokoNPBWeb(kodetoko))
                                {
                                    Master.CreateUlangNPB(kodetoko, noNPB, tglNPB);
                                    BuatUlangFileNPB(kodetoko, dtpTanggal.Value, direktori, tanggal);
                                }
                            }
                            else
                            {
                                MessageBox.Show(kodetoko + " ini sudah ambil data npb sewa via web.....");
                            }
                        }
                        else
                        {
                            if (Master.IsTokoNPBWeb(kodetoko))
                            {
                                string query = "SELECT count(*) " +
                                               "FROM DC_NPBTOKO_LOG " +
                                               "WHERE log_tok_kode='" + kodetoko + "' AND  " +
                                               "      log_stat_rcv is not null  AND " +
                                               "      log_stat_get is null   and   " +
                                               "      log_jenis='NPB' and " +
                                               "      log_no_npb=" + noNPB;
                                int count = Convert.ToInt32(Master.ExecScalar(query, Master.ConnString));
                                if(count > 0)
                                {
                                    Master.CreateUlangNPB(kodetoko, noNPB, tglNPB);
                                    BuatUlangFileNPB(kodetoko, dtpTanggal.Value, direktori, tanggal);
                                }
                                else
                                {
                                    MessageBox.Show(kodetoko + " ini sudah ambil data npb sewa via web.....");
                                }
                            }
                            else
                            {
                                BuatUlangFileNPB(kodetoko, dtpTanggal.Value, direktori, tanggal);
                            }
                        }
                    }

                    MessageBox.Show("Selesai...");

                    //Show progress bar
                    progressBarCreateNPB.Value = 0;
                    progressBarCreateNPB.Visible = false;
                    loadingSpinnerCreateNPB.Visible = false;
                    Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Tidak ada data!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Hide progress bar
            loadingSpinnerCreateNPB.Visible = false;
            Cursor = Cursors.Default;
        }

        private void FormCreateNPB_Load(object sender, EventArgs e)
        {
            Master.GetTbSettingVariabel();
        }

        private void BuatUlangFileNPB(string kdtoko, DateTime tglNPB, string dirBackup, string tglStr)
        {
            string ConnStringTxt = Master.KoneksiToTxt(dirBackup);
            string NamaFileNPB, NamaFileRPB;
            int NoSeqKering, NoSeqAlokasi;
            bool Pas1 = false;
            DataTable DataNPB = new DataTable();
            DataTable DataRpb = new DataTable();
            DataTable DataHeader = new DataTable();
            DataTable DataKoli = new DataTable();
            try
            {
                string query = "SELECT NPB_NO,NPB_DATE,DOC_NO,DOC_DATE,SEQ_NO,PIC_Kubik,TOK_KODE," +
                               "AlokasiId,Dc_Kode,Keter FROM DC_PICK_HDR_H WHERE DC_KODE = '" + Master.KodeDC + "' AND " +
                               "Tok_Kode = '" + kdtoko + "' AND To_Date(NPB_Date,'DD/MM/RR')=To_Date('" + tglNPB.ToString("dd/MM/yyyy") + "','DD/MM/RR') AND (Keter <> 'PROFORMA' OR Keter IS NULL) ";
                DataHeader.Clear();
                DataHeader = Master.GetDT(query, Master.ConnString);
                
                if(DataHeader.Rows.Count > 0)
                {
                    NamaFileNPB = Master.NamaFileNPB + Master.KodeDC + kdtoko + tglStr;
                    NamaFileRPB = Master.NamaFileRPB + Master.KodeDC + kdtoko + tglStr;

                    Master.CreateNPBFile(NamaFileNPB, dirBackup);
                    Master.CreateRPBFile(NamaFileRPB, dirBackup);

                    for(int i = 0; i<DataHeader.Rows.Count; i++)
                    {
                        #region START NPB
                        int seqno = Convert.ToInt32(DataHeader.Rows[i][4]);
                        using (StreamWriter sw = new StreamWriter(dirBackup + "/" + NamaFileNPB + ".CSV", true))
                        {
                            string[] kolom = new string[27];
                            string baris = "";

                            string queryNPB = "Select SEQ_FK_NO, PLU_ID, PLU_KODE, BTYPE, QTY, QTY_PICK, LENGTH, WIDTH, HEIGHT, "  + 
                                              "       UPDREC_ID, UPDREC_DATE, MINOR, LOK_FK_LINEKODE, SJ_QTY, LOK_CELL_ID, " +
                                              "       PRICE_NPB, PPN_JUAL, DUS_NO, KETER, LOKID, FLAG_UPDATE, PICKDTL_ID, RECID, " +
                                              "       QTY_PICK_DUMMY, PRICE_NPB_ROUND, np_keter('NPB',NVL(keter1,keter))  Keter1, " +
                                              "       FLAG_ALOK_DPD, MAX, PKM_G, QTYM1, SPD, PRICE, GROSS, PTAG, QTY_MAN, PPN, KM, " +
                                              "       JAMIN, JAMOUT, NO_SJ, PKM_AKH, SEQ_DATE, HPP, QTY_KUBIK_DTL, PIC_KUBIK_DTL, " +
                                              "       LOK_ZONA, LOK_TIPE, QTY_PICK_REAL, TIME_PICK_REAL, NIK_PICK_REAL, QTY_SCAN, "  + 
                                              "       TIME_SCAN, NIK_SCAN, TIPE_PACKING, MBR_SAT_DIMENSI, MBR_PCS_BELI, a.PLA_ZONABARANG," +
                                              "       TGLEXP,b.Mbr_Singkatan,b.Mbr_Fk_Div,b.Mbr_Acost,c.Pla_Id_DPD,c.Pla_Rak,c.Pla_Shelf," +
                                              "       c.Pla_Cell,Pla_Line,tglexp "  + 
                                              "FROM DC_PICK_DTL_H a, " +
                                              "     DC_BARANG_DC_ALL b, " +
                                              "     Dc_Planogram_T c " +
                                              "WHERE a.PLU_ID = b.MBR_FK_PLUID AND "  + 
                                              "      b.MBR_FK_PLUID = c.Pla_Fk_PluId AND " +
                                              "      c.Pla_Display = 'Y' AND " +
                                              "      b.Tbl_Dc_kode = '"  +  Master.KodeDC  +  "' AND "  + 
                                              "      a.SEQ_FK_NO = "  +  seqno  +  " AND " +
                                              "      (a.SJ_QTY > 0) AND " +
                                              "      (NOT a.SJ_QTY IS NULL)";
                            DataNPB.Clear();
                            DataNPB = Master.GetDT(queryNPB, Master.ConnString);
                            NoSeqKering = 0;
                            NoSeqAlokasi = 0;

                            if(DataNPB.Rows.Count > 0)
                            {
                                for(int j=0; j<DataNPB.Rows.Count; j++)
                                {
                                    baris = "";
                                    bool DusnoLebihDariSatu;
                                    if(DataNPB.Rows[j]["DUS_NO"] == null)
                                    {
                                        DusnoLebihDariSatu = false;
                                    }
                                    else
                                    {
                                        if(DataNPB.Rows[j]["DUS_NO"].ToString() == "HEADER")
                                        {
                                            DusnoLebihDariSatu = true;
                                        }
                                        else
                                        {
                                            DusnoLebihDariSatu = false;
                                        }
                                    }

                                    #region START Insert NPBCSV
                                    if(DataHeader.Rows[i]["AlokasiId"] == null)
                                    {
                                        NoSeqKering += 1;

                                        if(DusnoLebihDariSatu == true)
                                        {
                                            DataTable DataDetailDusNo = new DataTable();
                                            string qDtlDusno = "SELECT DISTINCT Qty,Dusno " +
                                                               "FROM Cluster_Dusno2 " +
                                                               "WHERE PRDCD = '" + DataNPB.Rows[j]["PLU_KODE"] + "' AND " +
                                                               "      Seq_NO = " + seqno + " AND " +
                                                               "      Qty <> 0 AND " +
                                                               "      QTY IS NOT NULL";
                                            DataDetailDusNo.Clear();
                                            DataDetailDusNo = Master.GetDT(qDtlDusno, Master.ConnString);
                                            if(DataDetailDusNo.Rows.Count > 0)
                                            {
                                                for(int k=0; k<DataDetailDusNo.Rows.Count; k++)
                                                {
                                                    baris = "";
                                                    kolom[0] = "*" + "|";
                                                    kolom[1] = "|";
                                                    kolom[2] = DataHeader.Rows[i]["NPB_NO"] + "|";
                                                    kolom[3] = NoSeqKering.ToString() + "|";
                                                    kolom[4] = DataNPB.Rows[j]["Seq_Fk_No"] + "|";
                                                    kolom[5] = "|";
                                                    kolom[6] = Convert.ToDateTime(DataHeader.Rows[i]["NPB_Date"]).ToString("dd-MM-yyyy") + "|";
                                                    kolom[7] = DataNPB.Rows[j]["PLU_KODE"] + "|";
                                                    kolom[8] = DataNPB.Rows[j]["Mbr_Singkatan"] + "|";
                                                    kolom[9] = DataNPB.Rows[j]["MBR_FK_DIV"] + "|";
                                                    kolom[10] = DataDetailDusNo.Rows[k]["Qty"] + "|";
                                                    kolom[11] = DataDetailDusNo.Rows[k]["Qty"] + "|";
                                                    kolom[12] = DataNPB.Rows[j]["Price_NPB"] + "|";
                                                    kolom[13] = Math.Round(Convert.ToDouble(DataDetailDusNo.Rows[k]["Qty"]) * Convert.ToDouble(DataNPB.Rows[j]["Price_NPB"]), 0, MidpointRounding.AwayFromZero) + "|";
                                                    
                                                    if(Convert.ToInt32(DataNPB.Rows[j]["PPn_Jual"]) == 0)
                                                    {
                                                        kolom[14] = DataNPB.Rows[j]["PPn_Jual"] + "|";
                                                    }
                                                    else
                                                    {
                                                        kolom[14] = (Math.Round(Convert.ToDouble(DataDetailDusNo.Rows[k]["Qty"]) * Convert.ToDouble(DataNPB.Rows[j]["Price_NPB"]), 0, MidpointRounding.AwayFromZero) * 0.1) + "|";
                                                    }
                                                    
                                                    
                                                    kolom[15] = DataNPB.Rows[j]["Mbr_Acost"] + "|";
                                                    kolom[16] = DataHeader.Rows[i]["Tok_Kode"] + "|";

                                                    if (DataNPB.Rows[j]["Keter1"] == DBNull.Value)
                                                    {
                                                        kolom[17] = DataHeader.Rows[i]["Keter"].ToString().Replace(",", " ") + "|";
                                                    }
                                                    else
                                                    {
                                                        kolom[17] = DataNPB.Rows[j]["Keter1"].ToString().Replace(",", " ") + "|";
                                                    }


                                                    kolom[18] = Convert.ToDateTime(DataHeader.Rows[i]["NPB_Date"]).ToString("dd-MM-yyyy") + "|";
                                                    kolom[19] = Convert.ToDateTime(DataHeader.Rows[i]["Doc_Date"]).ToString("dd-MM-yyyy") + "|";
                                                    kolom[20] = DataHeader.Rows[i]["Doc_No"] + "|";
                                                    kolom[21] = DataNPB.Rows[j]["Pla_Line"] + "|";
                                                    kolom[22] = DataNPB.Rows[j]["Pla_Rak"] + "|";
                                                    kolom[23] = DataNPB.Rows[j]["Pla_Shelf"] + "|";
                                                    kolom[24] = DataHeader.Rows[i]["Dc_Kode"] + "|";
                                                    kolom[25] = (DataDetailDusNo.Rows[k]["DusNo"] == null ? "" : DataDetailDusNo.Rows[k]["DusNo"]) + "|";

                                                    if (DataNPB.Rows[j]["tglexp"] == DBNull.Value)
                                                    {
                                                        kolom[26] = "";
                                                    }
                                                    else
                                                    {
                                                        kolom[26] = Convert.ToDateTime(DataNPB.Rows[i]["tglexp"]).ToString("dd-MM-yyyy");
                                                    }

                                                    baris = string.Join("", kolom);
                                                    sw.WriteLine(baris);

                                                    NoSeqKering += 1;
                                                }
                                            }
                                            DataDetailDusNo = null;
                                        }
                                        else //jika dusnolebihdarisatu == false
                                        {
                                            kolom[0] = "*" + "|";
                                            kolom[1] = "|";
                                            kolom[2] = DataHeader.Rows[i]["NPB_NO"] + "|";
                                            kolom[3] = NoSeqKering.ToString() + "|";
                                            kolom[4] = DataNPB.Rows[j]["Seq_Fk_No"] + "|";
                                            kolom[5] = "|";
                                            kolom[6] = Convert.ToDateTime(DataHeader.Rows[i]["NPB_Date"]).ToString("dd-MM-yyyy") + "|";
                                            kolom[7] = DataNPB.Rows[j]["PLU_KODE"] + "|";
                                            kolom[8] = DataNPB.Rows[j]["Mbr_Singkatan"] + "|";
                                            kolom[9] = DataNPB.Rows[j]["MBR_FK_DIV"] + "|";
                                            kolom[10] = DataNPB.Rows[j]["Qty"] + "|";
                                            kolom[11] = DataNPB.Rows[j]["Sj_Qty"] + "|";
                                            kolom[12] = DataNPB.Rows[j]["Price_NPB"] + "|";
                                            kolom[13] = Math.Round(Convert.ToDouble(DataNPB.Rows[j]["Sj_Qty"]) * Convert.ToDouble(DataNPB.Rows[j]["Price_NPB"]), 0, MidpointRounding.AwayFromZero) + "|";
                                        
                                            kolom[14] = DataNPB.Rows[j]["PPn_Jual"] + "|";

                                            kolom[15] = DataNPB.Rows[j]["Mbr_Acost"] + "|";
                                            kolom[16] = DataHeader.Rows[i]["Tok_Kode"] + "|";

                                            if (DataNPB.Rows[j]["Keter1"] == DBNull.Value)
                                            {
                                                kolom[17] = DataHeader.Rows[i]["Keter"].ToString().Replace(",", " ") + "|";
                                            }
                                            else
                                            {
                                                kolom[17] = DataNPB.Rows[j]["Keter1"].ToString().Replace(",", " ") + "|";
                                            }

                                            kolom[18] = Convert.ToDateTime(DataHeader.Rows[i]["NPB_Date"]).ToString("dd-MM-yyyy") + "|";
                                            kolom[19] = Convert.ToDateTime(DataHeader.Rows[i]["Doc_Date"]).ToString("dd-MM-yyyy") + "|";
                                            kolom[20] = DataHeader.Rows[i]["Doc_No"] + "|";
                                            kolom[21] = DataNPB.Rows[j]["Pla_Line"] + "|";
                                            kolom[22] = DataNPB.Rows[j]["Pla_Rak"] + "|";
                                            kolom[23] = DataNPB.Rows[j]["Pla_Shelf"] + "|";
                                            kolom[24] = DataHeader.Rows[i]["Dc_Kode"] + "|";
                                            kolom[25] = (DataNPB.Rows[i]["DUS_NO"] == null ? "" : DataNPB.Rows[i]["DUS_NO"]) + "|";

                                            if (DataNPB.Rows[j]["tglexp"] == DBNull.Value)
                                            {
                                                kolom[26] = "";
                                            }
                                            else
                                            {
                                                kolom[26] = Convert.ToDateTime(DataNPB.Rows[i]["tglexp"]).ToString("dd-MM-yyyy");
                                            }

                                            baris = string.Join("", kolom);
                                            sw.WriteLine(baris);

                                            NoSeqKering += 1;
                                        }
                                    }
                                    else //if dataheader !=null
                                    {
                                        kolom[0] = "*" + "|";
                                        kolom[1] = "|";
                                        kolom[2] = DataHeader.Rows[i]["NPB_NO"] + "|";
                                        kolom[3] = NoSeqAlokasi.ToString() + "|";
                                        kolom[4] = DataNPB.Rows[j]["Seq_Fk_No"] + "|";
                                        kolom[5] = "|";
                                        kolom[6] = Convert.ToDateTime(DataHeader.Rows[i]["NPB_Date"]).ToString("dd-MM-yyyy") + "|";
                                        kolom[7] = DataNPB.Rows[j]["PLU_KODE"] + "|";
                                        kolom[8] = DataNPB.Rows[j]["Mbr_Singkatan"] + "|";
                                        kolom[9] = DataNPB.Rows[j]["MBR_FK_DIV"] + "|";
                                        kolom[10] = DataNPB.Rows[j]["Qty"] + "|";
                                        kolom[11] = DataNPB.Rows[j]["Sj_Qty"] + "|";
                                        kolom[12] = DataNPB.Rows[j]["Price_NPB"] + "|";
                                        kolom[13] = Math.Round(Convert.ToDouble(DataNPB.Rows[j]["Sj_Qty"]) * Convert.ToDouble(DataNPB.Rows[j]["Price_NPB"]), 0, MidpointRounding.AwayFromZero).ToString() + "|";

                                        kolom[14] = DataNPB.Rows[j]["PPn_Jual"] + "|";

                                        kolom[15] = DataNPB.Rows[j]["Mbr_Acost"] + "|";
                                        kolom[16] = DataHeader.Rows[i]["Tok_Kode"] + "|";

                                        if (DataNPB.Rows[j]["Keter1"] == DBNull.Value)
                                        {
                                            kolom[17] = DataHeader.Rows[i]["Keter"].ToString().Replace(",", " ") + "|";
                                        }
                                        else
                                        {
                                            kolom[17] = DataNPB.Rows[j]["Keter1"].ToString().Replace(",", " ") + "|";
                                        }

                                        kolom[18] = Convert.ToDateTime(DataHeader.Rows[i]["NPB_Date"]).ToString("dd-MM-yyyy") + "|";
                                        kolom[19] = Convert.ToDateTime(DataHeader.Rows[i]["Doc_Date"]).ToString("dd-MM-yyyy") + "|";
                                        kolom[20] = DataHeader.Rows[i]["Doc_No"] + "|";
                                        kolom[21] = DataNPB.Rows[j]["Pla_Line"] + "|";
                                        kolom[22] = DataNPB.Rows[j]["Pla_Rak"] + "|";
                                        kolom[23] = DataNPB.Rows[j]["Pla_Shelf"] + "|";
                                        kolom[24] = DataHeader.Rows[i]["Dc_Kode"] + "|";
                                        kolom[25] = "|";

                                        if (DataNPB.Rows[j]["tglexp"] == DBNull.Value)
                                        {
                                            kolom[26] = "";
                                        }
                                        else
                                        {
                                            kolom[26] = Convert.ToDateTime(DataNPB.Rows[i]["tglexp"]).ToString("dd-MM-yyyy");
                                        }

                                        baris = string.Join("", kolom);
                                        sw.WriteLine(baris);

                                        NoSeqAlokasi += 1;
                                    }
                                    #endregion
                                }
                            }

                            #region START Input Retur Proforma
                            if (!Pas1)
                            {
                                DataTable DataProHdr = new DataTable();
                                int NoSeqPro;

                                string qDataProHdr = "SELECT NPB_NO,NPB_DATE,DOC_NO,DOC_DATE,SEQ_NO,PIC_Kubik," +
                                                  "       TOK_KODE,AlokasiId,Dc_Kode,Keter " +
                                                  "FROM DC_PICK_HDR_H " +
                                                  "WHERE DC_KODE = '" + Master.KodeDC + "' AND " +
                                                  "      Tok_Kode = '" + kdtoko + "' AND " +
                                                  "      To_Date(NPB_Date,'DD/MM/RR')=To_Date('" + tglNPB.ToString("dd/MM/yyyy") + "','DD/MM/RR') AND " +
                                                  "      Keter = 'PROFORMA'";
                                DataProHdr = Master.GetDT(qDataProHdr, Master.ConnString);

                                if(DataProHdr.Rows.Count > 0)
                                {
                                    for(int j=0; j<DataProHdr.Rows.Count; j++)
                                    {
                                        DataTable DataProDtl = new DataTable();
                                        string qDataProDtl = "Select a.*,b.Mbr_Singkatan,b.Mbr_Fk_Div,b.Mbr_Acost," +
                                                             "       c.Pla_Id_Dpd,c.Pla_Rak,c.Pla_Shelf,c.Pla_Cell,c.Pla_Line,tglexp " +
                                                             "FROM DC_PICK_DTL_H a, " +
                                                             "     DC_BARANG_DC_ALL b, " +
                                                             "     Dc_Planogram_T c " +
                                                             "WHERE a.PLU_ID = b.MBR_FK_PLUID AND " +
                                                             "      b.MBR_FK_PLUID = c.Pla_Fk_PluId AND " +
                                                             "      c.Pla_Display = 'Y' AND " +
                                                             "      b.Tbl_Dc_kode = '" + Master.KodeDC + "' AND " +
                                                             "      a.SEQ_FK_NO = " + DataProHdr.Rows[j]["Seq_No"] + " AND " +
                                                             "      (a.SJ_QTY > 0) AND " +
                                                             "      (NOT a.SJ_QTY IS NULL)";
                                        DataProDtl = Master.GetDT(qDataProDtl, Master.ConnString);

                                        if(DataProDtl.Rows.Count > 0)
                                        {
                                            NoSeqPro = 1;
                                            for(int k=0; k<DataProDtl.Rows.Count; k++)
                                            {
                                                baris = "";
                                                kolom[0] = "*" + "|";
                                                kolom[1] = "|";
                                                kolom[2] = DataProHdr.Rows[j]["NPB_NO"] + "|";
                                                kolom[3] = NoSeqPro.ToString() + "|";
                                                kolom[4] = DataProHdr.Rows[j]["Seq_No"] + "|";
                                                kolom[5] = "|";
                                                kolom[6] = Convert.ToDateTime(DataProHdr.Rows[j]["NPB_Date"]).ToString("dd-MM-yyyy") + "|";
                                                kolom[7] = DataProDtl.Rows[k]["PLU_KODE"] + "|";
                                                kolom[8] = DataProDtl.Rows[k]["Mbr_Singkatan"] + "|";
                                                kolom[9] = DataProDtl.Rows[k]["MBR_FK_DIV"] + "|";
                                                kolom[10] = DataProDtl.Rows[k]["Qty"] + "|";
                                                kolom[11] = DataProDtl.Rows[k]["Sj_Qty"] + "|";
                                                kolom[12] = DataProDtl.Rows[k]["Price_NPB"] + "|";
                                                kolom[13] = Math.Round(Convert.ToDouble(DataProDtl.Rows[k]["Sj_Qty"]) * Convert.ToDouble(DataProDtl.Rows[k]["Price_NPB"]), 0, MidpointRounding.AwayFromZero).ToString() + "|";

                                                kolom[14] = DataProDtl.Rows[k]["PPn_Jual"] + "|";

                                                kolom[15] = DataProDtl.Rows[k]["Mbr_Acost"] + "|";
                                                kolom[16] = DataProHdr.Rows[j]["Tok_Kode"] + "|";

                                                if (DataProDtl.Rows[k]["Keter1"] == DBNull.Value)
                                                {
                                                    kolom[17] = DataProHdr.Rows[j]["Keter"].ToString().Replace(",", " ") + "|";
                                                }
                                                else
                                                {
                                                    kolom[17] = DataProDtl.Rows[k]["Keter1"].ToString().Replace(",", " ") + "|";
                                                }

                                                kolom[18] = Convert.ToDateTime(DataProHdr.Rows[j]["NPB_Date"]).ToString("dd-MM-yyyy") + "|";
                                                kolom[19] = Convert.ToDateTime(DataProHdr.Rows[j]["Doc_Date"]).ToString("dd-MM-yyyy") + "|";
                                                kolom[20] = DataProHdr.Rows[j]["Doc_No"] + "|";
                                                kolom[21] = DataProDtl.Rows[k]["Pla_Line"] + "|";
                                                kolom[22] = DataProDtl.Rows[k]["Pla_Rak"] + "|";
                                                kolom[23] = DataProDtl.Rows[k]["Pla_Shelf"] + "|";
                                                kolom[24] = DataProHdr.Rows[j]["Dc_Kode"] + "|";
                                                kolom[25] = "|" + "|";
                                                kolom[26] = Convert.ToDateTime(DataProDtl.Rows[k]["tglexp"]).ToString("dd-MM-yyyy");

                                                baris = string.Join("", kolom);
                                                sw.WriteLine(baris);

                                                NoSeqPro += 1;
                                            }
                                        }
                                        DataProDtl = null;
                                    }
                                }
                                Pas1 = true;
                                DataProHdr = null;
                            }
                            #endregion
                        }
                        #endregion
                    }

                    #region START RPB New Procedure
                    DataTable DataNPBNew = new DataTable();
                    DataTable DataDocnoNew = new DataTable();
                    string[] kolomList = new string[27];

                    if (File.Exists(dirBackup + "/" + NamaFileNPB + ".CSV"))
                    {
                        kolomList[0] = "RECID" + " char";
                        kolomList[1] = "RTYPE" + " char";
                        kolomList[2] = "DOCNO" + " char";
                        kolomList[3] = "SEQNO" + " char";
                        kolomList[4] = "PICNO" + " char";
                        kolomList[5] = "PICNOT" + " char";
                        kolomList[6] = "PICTGL" + " char";
                        kolomList[7] = "PRDCD" + " char";
                        kolomList[8] = "NAMA" + " char";
                        kolomList[9] = "DIV" + " char";
                        kolomList[10] = "QTY" + " char";
                        kolomList[11] = "SJ_QTY" + " char";
                        kolomList[12] = "PRICE" + " char";
                        kolomList[13] = "GROSS" + " char";
                        kolomList[14] = "PPNRP" + " char";
                        kolomList[15] = "HPP" + " char";
                        kolomList[16] = "TOKO" + " char";
                        kolomList[17] = "KETER" + " char";
                        kolomList[18] = "TANGGAL1" + " char";
                        kolomList[19] = "TANGGAL2" + " char";
                        kolomList[20] = "DOCNO2" + " char";
                        kolomList[21] = "LT" + " char";
                        kolomList[22] = "RAK" + " char";
                        kolomList[23] = "BAR" + " char";
                        kolomList[24] = "KIRIM" + " char";
                        kolomList[25] = "DUS_NO" + " char";
                        kolomList[26] = "TGLEXP" + " char";

                        Master.CreateSchemaIni(NamaFileNPB + ".CSV", dirBackup, 25, kolomList, true);

                        string qDataNpbNew = "SELECT DocNo FROM `" + NamaFileNPB + ".CSV` GROUP BY Docno";
                        DataNPBNew.Clear();
                        DataNPBNew = Master.GetDTFromTxt(qDataNpbNew, ConnStringTxt);

                        if(DataNPBNew.Rows.Count > 0)
                        {
                            string qDtDocnoNew = "SELECT Toko,Docno,Tanggal1,Sum(Sj_Qty) as xQty ,Sum(Gross) as xGross, Count(*) as Item " +
                                                 "FROM `" + NamaFileNPB + ".CSV` " +
                                                 "GROUP BY Toko,Docno,Tanggal1";
                            DataDocnoNew.Clear();
                            DataDocnoNew = Master.GetDTFromTxt(qDtDocnoNew, ConnStringTxt);
                            if(DataDocnoNew.Rows.Count > 0)
                            {
                                string tanggal;
                                string[] tgl;
                                DateTime hasil;
                                string baris;
                                for(int i=0; i<DataDocnoNew.Rows.Count; i++)
                                {
                                    DataTable dataCari = new DataTable();
                                    string[] kolom = new string[7];

                                    tanggal = DataDocnoNew.Rows[i]["Tanggal1"].ToString();
                                    tgl = tanggal.Split('-');
                                    hasil = new DateTime(Convert.ToInt32(tgl[2]), Convert.ToInt32(tgl[1]), Convert.ToInt32(tgl[0]));

                                    kolom[0] = DataDocnoNew.Rows[i]["DocNo"].ToString() + "|";
                                    kolom[1] = hasil.ToString("dd/MM/yyyy") + "|";
                                    kolom[2] = DataDocnoNew.Rows[i]["Toko"].ToString() + "|";
                                    kolom[3] = Master.KodeDC + "|";
                                    kolom[4] = DataDocnoNew.Rows[i]["Item"].ToString() + "|";
                                    kolom[5] = DataDocnoNew.Rows[i]["xQty"].ToString().Trim() + "|";
                                    kolom[6] = DataDocnoNew.Rows[i]["xGross"].ToString().Trim();

                                    baris = string.Join("", kolom);
                                    using(StreamWriter sw = new StreamWriter(dirBackup + "/" + NamaFileRPB + ".CSV", true))
                                    {
                                        sw.WriteLine(baris);
                                    }
                                }
                            }
                        }
                    }
                    DataNPBNew = null;
                    DataDocnoNew = null;
                    #endregion

                    #region START Zipping
                    if (File.Exists(dirBackup + "/" + NamaFileNPB + ".CSV"))
                    {
                        if (File.Exists(dirBackup + "/" + NamaFileRPB + ".CSV"))
                        {
                            string nmFile1 = dirBackup + "/" + NamaFileNPB + ".ZIP";
                            string nmFile2 = dirBackup + "/" + NamaFileNPB + ".CSV";
                            string nmFile3 = dirBackup + "/" + NamaFileRPB + ".CSV";
                            string nmFile5 = dirBackup + "/VCR" + kdtoko + ".CSV";
                            ZipCompress.zipFiles(dirBackup + "/", nmFile1, " *.* ", NamaFileNPB + ".CSV", NamaFileRPB + ".CSV", "XXX999.XX999");

                            if (!Directory.Exists("D:/AMS"))
                            {
                                Directory.CreateDirectory("D:/AMS");
                            }

                            if (File.Exists(nmFile1))
                            {
                                File.Copy(nmFile1, "D:/AMS/" + NamaFileNPB + ".ZIP", true);
                            }
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Master.ShowError("Error - BuatUlangNPB", ex);
            }
        }
    }
}
