using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using SD3Fungsi;

namespace DCCLUSTERSEWA
{
    public static class Master
    {
        public static string KodeDC { get; set; }
        public static string NamaDC { get; set; }

        public static string KdToko { get; set; }
        public static string NmToko { get; set; }
        public static string ConnString { get; set; }
        public static string UserName { get; set; }
        public static string UserIPAddress { get; set; }
        public static bool PassMobilAuthenticated { get; set; }
        public static bool PassKunciAuthenticated { get; set; }
        //public static bool IsSecureLogin { get; set; } = false;

        public static string ServerOracle, UserOracle, PasswordOracle, TnsOracle;

        //server database
        public static string Server { get; set; }
        public static string UserServer { get; set; }
        public static string PasswordServer { get; set; }
        public static bool DBConnected { get; set; }

        //ftp
        public static string DirBackup { get; set; }
        public static string ServerFtp { get; set; }
        public static string UserFtp { get; set; }
        public static string PasswordFtp { get; set; }
        public static string PortFtp { get; set; }
        public static string DirFtp { get; set; }
        public static string PemisahCSV { get; set; }
        public static string NamaFileNPB { get; set; }
        public static string NamaFileRPB { get; set; }

        //buat cek versi
        private static string product_name = Application.ProductName + ".EXE";
        private static string product_version = Application.ProductVersion;
        private static string ipLokal = IpKomp.GetIPAddress();


        private static string SetConnectionString()
        {
            try
            {
                SettingLib.Class1 libWS = new SettingLib.Class1();
                ServerOracle = libWS.GetVariabel("ServerOrcl");
                UserOracle = libWS.GetVariabel("UserOrcl");
                PasswordOracle = libWS.GetVariabel("PasswordOrcl");
                TnsOracle = libWS.GetVariabel("ODPOrcl");

                DBConnected = true;
                return "Data Source=" + TnsOracle + ";User ID=" + UserOracle + ";Password=" + PasswordOracle + ";";
            }
            catch(Exception ex)
            {
                DBConnected = false;
                MessageBox.Show("Koneksi ke database gagal!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.Message;
            }
        }

        public static string KoneksiToTxt(string path)
        {
            return "Driver={Microsoft Text Driver (*.txt; *.csv)};DriverId=27;FIL=text;DefaultDir=" +
                        path + ";DBQ=" + path;
        }

        public static void Cek_Program_2(string KodeDC)
        {
            string ConnString = SetConnectionString();
            SettingLib.Class1 NewEncrypt = new SettingLib.Class1();
            try
            {
                string ret = NewEncrypt.GetVersiODP(ConnString, KodeDC, product_name, product_version, ipLokal);
                if (ret.ToString().Contains("OKE") == false)
                {
                    MessageBox.Show(ret);
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
        }

        public static string GetIPAddress()
        {
            string strHostName = System.Net.Dns.GetHostName();
            string strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList[0].ToString();

            return strIPAddress;
        }

        public static DataTable GetDT(string query, string connectionString)
        {
            DataTable dt = new DataTable();
            OracleCommand command = new OracleCommand();
            OracleDataAdapter adapter = new OracleDataAdapter();
            command.InitialLONGFetchSize = 5000;
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = query;
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                    connection.Close();
                };

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }

        public static DataTable GetDTFromTxt(string query, string connectionString)
        {
            DataTable dt = new DataTable();
            OdbcCommand command = new OdbcCommand();
            OdbcDataAdapter adapter = new OdbcDataAdapter();
            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = query;
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                    connection.Close();
                };

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }

        public static Boolean ExecQuery(string query, string connectionString)
        {
            OracleCommand command = new OracleCommand();
            int hasil;
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = query;
                    hasil = command.ExecuteNonQuery();
                };

                if (hasil == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static object ExecScalar(string query, string constr)
        {
            OracleCommand command = new OracleCommand();
            object execScalar;
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = query;
                    execScalar = command.ExecuteScalar();
                };

                return execScalar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Gagal: " + ex.Message;
            }
        }

        public static void ShowError(string errorInfo, Exception error)
        {
            MessageBox.Show(errorInfo + "\r\n" + "Error Prog: " + error.Message + 
                            "\r\n" + "From: " + error.Source + 
                            "\r\n" + "Trace: " + error.StackTrace, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            StreamWriter sw = new StreamWriter(Application.StartupPath + "/ErrorLog.txt", true);

            sw.WriteLine("#Error Tgl: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
            sw.WriteLine("   Error Prog  : " + error.Message);
            sw.WriteLine("   Error From  : " + error.Source);
            sw.WriteLine("   Error Trace : " + error.StackTrace);
            sw.Close();

        }

        private static void GetInfoDC()
        {
            string query = "SELECT TBL_DC_KODE, TBL_DC_NAMA FROM DC_TABEL_DC_T";
            DataTable dt = GetDT(query, ConnString);
            KodeDC = dt.Rows[0]["TBL_DC_KODE"].ToString();
            NamaDC = dt.Rows[0]["TBL_DC_NAMA"].ToString();
        }

        public static bool IsDCSewa()
        {
            ConnString = SetConnectionString();
            string query = "SELECT COUNT(*) FROM DC_TABEL_DC_T WHERE TBL_JENIS_DC='SEWA'";
            //string query = "SELECT COUNT(*) FROM DC_TABEL_DC_T";
            object execute = ExecScalar(query, ConnString);
            if(Convert.ToInt32(execute) > 0)
            {
                GetInfoDC();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsLoggedIn(string username, string password)
        {
            ConnString = SetConnectionString();
            string query = "SELECT COUNT(*) " +
                           "FROM DC_USER_T " +
                           "WHERE USER_NAME='" + username + "' AND USER_PASSWORD='" + password + "'";
            object execute = ExecScalar(query, ConnString);
            if (Convert.ToInt32(execute) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsSecureLogin(string username)
        {
            bool secure = false;
            //Cek IP dan user - get group
            Master.UserIPAddress = Master.GetIPAddress();
            DataTable dt_cekIP = Master.GetDT("SELECT ip_fk_group_name FROM dc_ipaddress_t WHERE ip_fk_user_name = '" + username + "'", Master.ConnString);

            string usergroup = "";
            if (dt_cekIP.Rows.Count == 0)
            {
                MessageBox.Show("IP tidak valid!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //usergroup = dt_cekIP.Rows[0][0].ToString();
                for(int i=0; i<dt_cekIP.Rows.Count; i++)
                {
                    usergroup = dt_cekIP.Rows[i][0].ToString();
                    //cek secure
                    DataTable dt_cekSecure = Master.GetDT("SELECT count(*) FROM dc_security_t WHERE fk_user_name ='" + usergroup + "' and sec_app_name ='" + Application.ProductName.ToUpper() + "'", Master.ConnString);
                    if (dt_cekSecure.Rows[0][0].ToString() == "1")
                    {
                        Master.UserName = username; //isi variable username di Master.cs
                        secure = true;
                        break;
                    }
                }

                if(secure == false)
                {
                    MessageBox.Show("IP tidak terdaftar untuk " + Application.ProductName.ToUpper() + "!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            
            return secure;
        }

        #region Function sering dipakai
        public static string GetKapasitasMobil(string tipe)
        {
            string query = selectKapasitasTipeMobil(tipe);
            DataTable dt = GetDT(query, ConnString);
            string kubikasi = dt.Rows[0][0] == null ? "" : dt.Rows[0][0].ToString();

            return kubikasi;
        }

        public static bool IsNPBWeb()
        {
            string query = "Select nvl(db_npbweb,'N') from dc_setup_db";
            if(ExecScalar(query, ConnString).ToString() == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsTokoNPBWeb(string kdtoko)
        {
            try
            {
                string query = "SELECT count(*) " +
                           "FROM dc_toko_nplweb_t " +
                           "WHERE tipe = 'NPB' AND KODE_TOKO = '" + kdtoko + "' AND TRUNC(tgl_main) <= TRUNC(SYSDATE)";
                if(Convert.ToInt32(ExecScalar(query, ConnString)) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ShowError("Istoko npbweb", ex);
                return false;
            }
        }

        public static void CreateNPBFile(string NamaFileNPB, string path)
        {
            if (File.Exists(path + "/" + NamaFileNPB + ".CSV"))
            {
                File.Delete(path + "/" + NamaFileNPB + ".CSV");
            }

            string header = "RECID" + "|" + "RTYPE" + "|" + "DOCNO" + "|" + "SEQNO" + "|" + "PICNO" + "|" + "PICNOT" + "|" + "PICTGL" + "|" + "PRDCD" + "|" + "NAMA" + "|" + "DIV" + "|" + "QTY" + "|" + "SJ_QTY" + "|" + "PRICE" + "|" + "GROSS" + "|" + "PPNRP" + "|" + "HPP" + "|" + "TOKO" + "|" + "KETER" + "|" + "Tanggal1" + "|" + "Tanggal2" + "|" + "DOCNO2" + "|" + "LT" + "|" + "RAK" + "|" + "BAR" + "|" + "KIRIM" + "|" + "DUS_NO" + "|" + "TGLEXP";
            using (StreamWriter sw = new StreamWriter(path + "/" + NamaFileNPB + ".CSV", true))
            {
                sw.WriteLine(header);
            }
        }

        public static void CreateRPBFile(string NamaFileRPB, string path)
        {
            if (File.Exists(path + "/" + NamaFileRPB + ".CSV"))
            {
                File.Delete(path + "/" + NamaFileRPB + ".CSV");
            }

            string header = "DocNo" + "|" + "Doc_Date" + "|" + "Toko" + "|" + "Gudang" + "|" + "Item" + "|" + "Qty" + "|" + "Gross" + "|" + "Koli" + "|" + "Kubikasi" + "|" + "LPG";
            using (StreamWriter sw = new StreamWriter(path + "/" + NamaFileRPB + ".CSV", true))
            {
                sw.WriteLine(header);
            }
        }

        public static void CreateSchemaIni(string namaTabel, string path, int jmlKolom, string[] FieldList, bool ovr)
        {
            if(ovr == true)
            {
                if(File.Exists(path + "/Schema.Ini"))
                {
                    File.Delete(path + "/Schema.Ini");
                }
            }

            string strLine, wrLine;
            using(StreamWriter sw = new StreamWriter(path + "/Schema.Ini", true))
            {
                sw.WriteLine("[" + namaTabel + "]");
                sw.WriteLine("ColNameHeader=True");
                sw.WriteLine("CharacterSet=ANSI");
                sw.WriteLine("Format=Delimited("+ "|" +")");
                sw.WriteLine("TextDelimiter=none");
                
                for(int i=0; i<=jmlKolom; i++)
                {
                    strLine = "COL" + (i + 1).ToString().Trim() + "=";
                    wrLine = strLine + FieldList[i];
                    sw.WriteLine(wrLine);
                }
            }

        }

        public static void GetTbSettingVariabel()
        {
            string query = "SELECT param, nvl(nilai, '') as nilai FROM CLUSTER_TBSETTING";
            try
            {
                using(OracleConnection conn = new OracleConnection(ConnString))
                {
                    using(OracleCommand cmd = new OracleCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        conn.Open();

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            if(reader["param"].ToString() == "DirBackup")
                            {
                                DirBackup = reader["nilai"].ToString();
                            }
                            else if(reader["param"].ToString() == "FtpServer")
                            {
                                ServerFtp = reader["nilai"].ToString();
                            }
                            else if (reader["param"].ToString() == "FtpUser")
                            {
                                UserFtp = reader["nilai"].ToString();
                            }
                            else if (reader["param"].ToString() == "FtpPass")
                            {
                                PasswordFtp = reader["nilai"].ToString();
                            }
                            else if (reader["param"].ToString() == "FtpPort")
                            {
                                PortFtp = reader["nilai"].ToString();
                            }
                            else if (reader["param"].ToString() == "FtpDir")
                            {
                                DirFtp = reader["nilai"].ToString();
                            }
                            else if (reader["param"].ToString() == "PemisahCSV")
                            {
                                PemisahCSV = reader["nilai"].ToString();
                            }
                            else if (reader["param"].ToString() == "NamaFileNPB")
                            {
                                NamaFileNPB = reader["nilai"].ToString();
                            }
                            else if (reader["param"].ToString() == "NamaFileRPB")
                            {
                                NamaFileRPB = reader["nilai"].ToString();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Error - GetTbSettingVariabel", ex);
            }
        }

        /// <summary>
        /// Generate Kode Barcode
        /// </summary>
        /// <param name="npb"></param>
        /// <param name="tglNPB"></param>
        /// <param name="bulanNPB"></param>
        /// <returns></returns>
        public static string Caesar_Encrypt_AllNumeric(string npb, string tglNPB, string bulanNPB)
        {
            string StringArrangement = "1THE2QUICK3BROWN4FX5JMPS6V7LAZY8DG90";
            string StringArrangementNumeric = "4702583691";

            //Salah satunya dipakai untuk terima barang ( baca rangkuman NPB )
            //Panjang nomor NPB adalah 6 atau 7 digit, panjang kombinasi gembok adalah 4 digit
            string CipherText = "";

            //Password berupa angka hasil penjumlahan tanggal dan bulan dokumen NPB.
            int pass = Convert.ToInt32(tglNPB) + Convert.ToInt32(bulanNPB);
            if(pass % 10 == 0)
            {
                pass = 5;
            }

            //Encryption here:
            for(int i=0; i<npb.Length; i++)
            {
                string currentCharPlain = npb[i].ToString();
                string currentCharCipher = "";
                int indexCharPlain = StringArrangementNumeric.IndexOf(currentCharPlain);
                int indexCharCipher = -1;
                int numberOfStep = pass % StringArrangementNumeric.Length;

                if(indexCharPlain + numberOfStep > (StringArrangementNumeric.Length - 1))
                {
                    indexCharCipher = numberOfStep - (StringArrangementNumeric.Length - 1 - indexCharPlain) - 1;
                }
                else
                {
                    indexCharCipher = indexCharPlain + numberOfStep;
                }
                currentCharCipher = StringArrangementNumeric[indexCharCipher].ToString();
                CipherText = CipherText + currentCharCipher;
            }

            string ciphertext_checksum = CipherText;
            ciphertext_checksum = ciphertext_checksum + pass.ToString().PadLeft(2, '0');

            string checksum = "";
            int numericChecksum = 0;
            for(int i=0; i<ciphertext_checksum.Length; i++)
            {
                string currentCharCipher = ciphertext_checksum[i].ToString();
                int currentNumericCipher = Convert.ToInt32(currentCharCipher);
                numericChecksum = numericChecksum + ((i + 1) * currentNumericCipher);
            }
            if(ciphertext_checksum.Length == 10)
            {
                checksum = (numericChecksum % 13).ToString();
            }
            else
            {
                checksum = (numericChecksum % 23).ToString();
            }

            if(checksum == "0")
            {
                checksum = "9";
            }
            checksum = checksum.PadLeft(2,'0');

            string result = checksum + CipherText + tglNPB.ToString().PadLeft(2, '0');
            return result;
        }
        #endregion

        #region QUERIES
        public static string selectParamSetting(string param)
        {
            return "SELECT COUNT(*) FROM CLUSTER_TBSETTING WHERE param='" + param +"' AND kddc='" + KodeDC + "'";
        }

        public static string updateNilaiSetting(string param, string nilai)
        {
            return "UPDATE CLUSTER_TBSETTING SET nilai='" + nilai + "' WHERE param='" + param + "' AND kddc='" + KodeDC + "'";
        }
        public static string insertParamSetting(string param, string nilai)
        {
            return "INSERT INTO CLUSTER_TBSETTING(KDDC,PARAM,NILAI) " +
                   "       VALUES('" + KodeDC + "','" + param + "','" + nilai + "') ";
        }

        public static string selectTabelToko()
        {
            return "SELECT KDTK AS kode, nama as nama_toko, BUKA AS tgl_buka, TM as tipe_mobil, " +
                   "       kota, telp, ktr as kantor, ruting, maxcontainer as max_cont, " +
                   "       maxbronjong as max_bronj, maxdoly as max_doly " +
                   "FROM CLUSTER_TBTOKO";
        }

        public static string selectTabelRute()
        {
            return "SELECT zona, grup, kdtk, kmasli, jlnkhusus, gage " +
                   "FROM CLUSTER_TBRUTE";
        }

        public static string selectPassJlnKhusus()
        {
            return " SELECT pas_value" +
                   " FROM DC_PASSWORD_T" +
                   " WHERE pas_type = 'JALANKHUSUS'";
        }

        public static string selectTipeMobil()
        {
            return "SELECT alltobox, kode, tipe, tinggi, lebar, panjang, kapasitas " +
                   "FROM CLUSTER_TBTIPEMOBIL";
        }

        public static string selectPassMobil()
        {
            return "SELECT nilai " +
                   "FROM CLUSTER_TBSETTING " +
                   "WHERE param = 'PassMobil'"; 
        }

        public static string selectTabelSupir()
        {
            return "SELECT nik, nama, kelompok, utama, status " +
                   "FROM CLUSTER_TBSUPIR";
        }

        public static string selectTabelSupir(string filterKlmpk)
        {
            return "SELECT nik, nama, kelompok, utama, status " +
                   "FROM CLUSTER_TBSUPIR WHERE kelompok='" + filterKlmpk + "'";
        }

        public static string selectPassKunci()
        {
            return "SELECT nilai " +
                   "FROM CLUSTER_TBSETTING " +
                   "WHERE param = 'PassKunci'";
        }

        public static string selectTabelKunci()
        {
            return "SELECT kddc, nokunci, pass, pass_old, tgl_updpass, status " +
                   "FROM CLUSTER_TBKUNCI";
        }

        public static string selectTabelMobil()
        {
            return "SELECT kd_mobil, no_polisi, nik AS supir, ukuran AS tipe, kubikasi, gps, status " +
                   "FROM CLUSTER_TBMOBIL";
        }

        public static string selectComboBoxSupir()
        {
            return "select distinct(nik) as nik, nama from cluster_tbsupir ORDER BY NAMA ASC";
        }

        public static string selectComboBoxTipeMobil()
        {
            return "SELECT kode, tipe FROM CLUSTER_TBTIPEMOBIL";
        }

        public static string selectKapasitasTipeMobil(string tipe)
        {
            return "SELECT kapasitas FROM CLUSTER_TBTIPEMOBIL WHERE kode='" + tipe + "'";
        }

        public static string insertTabelMobil(string kdmobil, string supir, string nopol, string tipe, string kubikasi)
        {
            return "INSERT INTO CLUSTER_TBMOBIL (kddc, kd_mobil, no_polisi, nik, ukuran, kubikasi, gps, status) " +
                   "VALUES ('" + KodeDC + "'," +
                   "        '" + kdmobil + "'," +
                   "        '" + nopol + "'," +
                   "        '" + supir + "'," +
                   "        '" + tipe + "', " +
                   "        '" + kubikasi + "'," +
                   "        '0'," +
                   "        '0')";
        }

        public static string selectTabelBackup()
        {
            return "SELECT a.tok_kode, b.tok_name " +
                   "FROM DC_PICK_HDR_T a, DC_TOKO_T b " +
                   "WHERE a.ALOKASIID IS NOT NULL " +
                   "      AND a.tok_kode = b.tok_code(+) " +
                   "      AND a.NPB_NO IS NULL " +
                   "GROUP BY a.TOK_KODE, b.tok_name";
        }

        public static string selectDataHeader(string kdtoko)
        {
            return "SELECT DOC_NO,DOC_DATE,SEQ_NO,PIC_Kubik,TOK_KODE,AlokasiId,Dc_Kode,Keter FROM DC_PICK_HDR_T " +
                   "WHERE Tok_Kode = '" + kdtoko + "' AND ALOKASIID  IS NOT NULL" +
                    " UNION " +
                    "SELECT DOC_NO,DOC_DATE,SEQ_NO,PIC_Kubik,TOK_KODE,AlokasiId,Dc_Kode,Keter FROM DC_PICK_HDR_NPB " +
                    "WHERE Tok_Kode = '" + kdtoko + "' AND ALOKASIID  IS NOT NULL";
        }

        public static string selectDataNPB(int seqno)
        {
            string query = "Select SEQ_FK_NO, PLU_ID, PLU_KODE,BTYPE, QTY, QTY_PICK, LENGTH, WIDTH, HEIGHT, UPDREC_ID, UPDREC_DATE, MINOR, " +
                            " LOK_FK_LINEKODE, SJ_QTY, LOK_CELL_ID, ROUND(PRICE_NPB,9) AS PRICE_NPB, PPN_JUAL, DUS_NO, KETER, LOKID, FLAG_UPDATE, PICKDTL_ID, RECID, QTY_PICK_DUMMY," +
                            " PRICE_NPB_ROUND, SEQ_DATE, ROUND(HPP,9) AS HPP, np_keter('NPB',NVL(keter1,keter))  Keter1, QTY_KUBIK_DTL, PIC_KUBIK_DTL, FLAG_ALOK_DPD, MAX, PKM_G, QTYM1, SPD, PRICE," +
                            " GROSS, PTAG, QTY_MAN, PPN, JAMIN, JAMOUT, NO_SJ, KM, PKM_AKH, LOK_ZONA, LOK_TIPE, b.Mbr_Singkatan, b.Mbr_Fk_Div, ROUND(b.Mbr_Acost, 9) AS Mbr_Acost, " +
                            "c.Pla_Id_DPD,c.Pla_Rak,c.Pla_Shelf,c.Pla_Cell,Pla_Line,TglExp " +
                            "FROM DC_PICK_DTL_T a, DC_BARANG_DC_ALL b, Dc_Planogram_T c WHERE a.PLU_ID = b.MBR_FK_PLUID AND " +
                            "b.MBR_FK_PLUID = c.Pla_Fk_PluId AND c.Pla_Display = 'Y' AND " +
                            "a.SEQ_FK_NO = " + seqno + " AND nvl(a.SJ_QTY,0) > 0 " +
                            " UNION " +
                            "Select SEQ_FK_NO, PLU_ID, PLU_KODE,BTYPE, QTY, QTY_PICK, LENGTH, WIDTH, HEIGHT, UPDREC_ID, UPDREC_DATE, MINOR, " +
                            " LOK_FK_LINEKODE, SJ_QTY, LOK_CELL_ID, ROUND(PRICE_NPB,9) AS PRICE_NPB, PPN_JUAL, DUS_NO, KETER, LOKID, FLAG_UPDATE, PICKDTL_ID, RECID, QTY_PICK_DUMMY," +
                            " PRICE_NPB_ROUND, SEQ_DATE, ROUND(HPP,9) AS HPP, np_keter('NPB',NVL(keter1,keter))  Keter1, QTY_KUBIK_DTL, PIC_KUBIK_DTL, FLAG_ALOK_DPD, MAX, PKM_G, QTYM1, SPD, PRICE," +
                            " GROSS, PTAG, QTY_MAN, PPN, JAMIN, JAMOUT, NO_SJ, KM, PKM_AKH, LOK_ZONA, LOK_TIPE,b.Mbr_Singkatan,b.Mbr_Fk_Div,ROUND(b.Mbr_Acost, 9) AS Mbr_Acost," +
                            "c.Pla_Id_DPD,c.Pla_Rak,c.Pla_Shelf,c.Pla_Cell,Pla_Line,TglExp " +
                            "FROM DC_PICK_DTL_NPB a, DC_BARANG_DC_ALL b, Dc_Planogram_T c WHERE a.PLU_ID = b.MBR_FK_PLUID AND " +
                            "b.MBR_FK_PLUID = c.Pla_Fk_PluId AND c.Pla_Display = 'Y' AND " +
                            "a.SEQ_FK_NO = " + seqno + " AND nvl(a.SJ_QTY,0) > 0 ";
            return query;
        }

        public static string selectNoTglNPB(string kdtoko, int seqno)
        {
            return "SELECT NPB_NO,NPB_DATE,to_char(npb_date,'yyyymmddhhmi') times FROM DC_PICK_HDR_T " + 
                               "WHERE Tok_Kode = '" + kdtoko + "' AND Seq_No = " + seqno + 
                               " UNION " + 
                               "SELECT NPB_NO,NPB_DATE,to_char(npb_date,'yyyymmddhhmi') times FROM DC_PICK_HDR_NPB " + 
                               "WHERE Tok_Kode = '" + kdtoko + "' AND Seq_No = " + seqno;
        }

        public static string selectTabelGO()
        {
            string query = "SELECT DISTINCT TRUNC(tglpic) AS tanggal, " +
                           "       kdtoko, nama, nopb, SUM(kubikreal) as kubikreal, kdmobil, " +
                           "       kdsupir1, nmsupir1, nokunci " +
                           "FROM CLUSTER_TBBACKUPSEWA " +
                           "WHERE pilgo IS NULL " +
                           "GROUP BY tglpic, kdtoko, nama, nopb, kdmobil, kdsupir1, nmsupir1, nokunci " +
                           "ORDER BY tanggal";
            return query;
        }

        public static string selectSearchValueTabelGO(string searchString)
        {
            string query = "SELECT DISTINCT TRUNC(tglpic) AS tanggal, " +
                           "       kdtoko, nama, nopb, SUM(kubikreal) as kubikreal, kdmobil, " +
                           "       kdsupir1, nmsupir1, nokunci " +
                           "FROM CLUSTER_TBBACKUPSEWA " +
                           "WHERE pilgo IS NULL AND " +
                           "      (kdtoko like '%" + searchString + "%' OR " +
                           "       nama like '%" + searchString + "%') OR " +
                           "       nopb like '%" + searchString + "%'" +
                           "GROUP BY tglpic, kdtoko, nama, nopb, kdmobil, kdsupir1, nmsupir1, nokunci " +
                           "ORDER BY tanggal";
            return query;
        }

        public static string selectDropDownGoMobil()
        {
            return "SELECT a.kd_mobil, a.no_polisi ||'-'|| a.ukuran as nopol_tipe " +
                   "FROM cluster_tbmobil a " +
                   "WHERE a.status = 0 " +
                   "      AND NOT EXISTS(SELECT 1 FROM dc_his_pengiriman_t WHERE kdlambung = a.kd_mobil)";
        }

        public static string selectDropDownGoSupir()
        {
            return "SELECT nik, nama, id_supir " +
                   "FROM dc_driver_t a " +
                   "WHERE flag_presensi = 'ON-DUTY' AND " +
                   "      f_booking IS NULL AND " +
                   "      NOT EXISTS(SELECT 1 FROM dc_his_pengiriman_t WHERE nik = a.nik)";
        }

        public static string selectDropDownGoKunci()
        {
            return "SELECT nokunci, pass " +
                   "FROM cluster_tbkunci " +
                   "WHERE status = 0";
        }

        public static string updatePaketKirim(string urut, string no_kunci, string pass, string tipe_mobil, string kd_mobil, string no_polisi, string kd_supir, string nama_supir, string kdtoko, string nopb)
        {
            string query = "UPDATE CLUSTER_TBBACKUPSEWA SET urut='" + urut + "'," +
                                       "                                nokunci='" + no_kunci + "'," +
                                       "                                pass='" + pass + "'," +
                                       "                                tipemobil='" + tipe_mobil + "'," +
                                       "                                kdmobil='" + kd_mobil + "'," +
                                       "                                nopol='" + no_polisi + "'," +
                                       "                                kdsupir1='" + kd_supir + "'," +
                                       "                                nmsupir1='" + nama_supir + "' " +
                                       "WHERE kdtoko='" + kdtoko + "' AND " +
                                       "      kddc='" + KodeDC + "' AND " +
                                       "      nopb='" + nopb + "'";
            return query;
        }

        public static string updateStatusMobil(string kd_mobil, string status)
        {
            return "UPDATE CLUSTER_TBMOBIL SET STATUS='" + status + "' " +
                   "WHERE kd_mobil='" + kd_mobil + "' AND " +
                   "      kddc='" + Master.KodeDC + "'";
        }

        public static string updateStatusKunci(string no_kunci, string status)
        {
            return "UPDATE CLUSTER_TBKUNCI SET STATUS='" + status + "' " +
                   "WHERE nokunci='" + no_kunci + "' AND " +
                   "      kddc='" + Master.KodeDC + "'";
        }
        #endregion

        #region Stored Procedures
        public static bool runprocClusterSewaCreateSJ()
        {
            try
            {
                int hasil = 0;
                OracleCommand cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CLUSTERSEWA.CREATE_SJ";
                cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar2, 200, ParameterDirection.Input)).Value = KodeDC;
                cmd.Parameters.Add(new OracleParameter("P_MSG", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    cmd.Connection = conn;
                    hasil = cmd.ExecuteNonQuery();
                }

                if (hasil == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Master.ShowError("Error - CLUSTERSEWA.CREATE_SJ: ", ex);
                return false;
            }
        }

        public static bool runprocCreateCluster()
        {
            try
            {
                int hasil = 0;
                OracleCommand cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CLUSTERSEWA.CREATE_CLUSTER";
                cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar2, 200, ParameterDirection.Input)).Value = KodeDC;
                cmd.Parameters.Add(new OracleParameter("P_MSG", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                using(OracleConnection conn = new OracleConnection(ConnString))
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    cmd.Connection = conn;
                    hasil = cmd.ExecuteNonQuery();
                }

                if(hasil == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool runprocNPB_PBSL_SEWA2(string kdtoko, int seqno)
        {
            try
            {
                int hasil = 0;
                OracleCommand cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NPB_PBSL_SEWA2";
                cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar2, 200, ParameterDirection.Input)).Value = KodeDC;
                cmd.Parameters.Add(new OracleParameter("P_OUTLET", OracleDbType.Varchar2, 200, ParameterDirection.Input)).Value = kdtoko;
                cmd.Parameters.Add(new OracleParameter("C_SQLERRM", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("C_RUN", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    cmd.Connection = conn;
                    hasil = cmd.ExecuteNonQuery();
                }

                if (hasil == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                ShowError("Error - runprocNPB_PBSL_SEWA2 - SeqNo: " + seqno, ex);
                return false;
            }
        }

        public static bool CreateNPB(string kdtoko, string nonpb, string tglnpb)
        {
            try
            {
                tglnpb = Convert.ToDateTime(tglnpb).ToString("MM/dd/yyyy");
                int hasil = 0;
                OracleCommand cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Npbsewaweb.Create_NPB";
                cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar2, 2000, ParameterDirection.Input)).Value = KodeDC;
                cmd.Parameters.Add(new OracleParameter("P_OUTLET", OracleDbType.Varchar2, 2000, ParameterDirection.Input)).Value = kdtoko;
                cmd.Parameters.Add(new OracleParameter("P_TGLNPB", OracleDbType.Date, 2000, ParameterDirection.Input)).Value = tglnpb;
                cmd.Parameters.Add(new OracleParameter("P_NOLINK", OracleDbType.Varchar2, 2000, ParameterDirection.Input)).Value = nonpb;
                cmd.Parameters.Add(new OracleParameter("P_MSG", OracleDbType.Varchar2, 2000)).Direction = ParameterDirection.Output;

                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    cmd.Connection = conn;
                    hasil = cmd.ExecuteNonQuery();
                }

                if (hasil == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                ShowError("Error - Create_NPB", ex);
                return false;
            }
        }

        public static bool CreateUlangNPB(string kdtoko, string nonpb, string tglnpb)
        {
            try
            {
                tglnpb = Convert.ToDateTime(tglnpb).ToString("MM/dd/yyyy");
                int hasil = 0;
                OracleCommand cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Npbsewaweb.Create_Ulang_NPB";
                cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar2, 2000, ParameterDirection.Input)).Value = KodeDC;
                cmd.Parameters.Add(new OracleParameter("P_OUTLET", OracleDbType.Varchar2, 2000, ParameterDirection.Input)).Value = kdtoko;
                cmd.Parameters.Add(new OracleParameter("P_TGLNPB", OracleDbType.Date, 2000, ParameterDirection.Input)).Value = tglnpb;
                cmd.Parameters.Add(new OracleParameter("P_NONPB", OracleDbType.Varchar2, 2000, ParameterDirection.Input)).Value = nonpb;
                cmd.Parameters.Add(new OracleParameter("P_MSG", OracleDbType.Varchar2, 2000)).Direction = ParameterDirection.Output;

                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    cmd.Connection = conn;
                    hasil = cmd.ExecuteNonQuery();
                }

                if(cmd.Parameters[4].Value.ToString() != "")
                {
                    string msg = cmd.Parameters[4].Value.ToString();
                    MessageBox.Show(msg);
                    return false;
                }
                else
                {
                    MessageBox.Show("Sukses Create Ulang NP? WEB...");
                    return true;
                }
            }
            catch (Exception ex)
            {
                ShowError("Error - CreateUlangNPB", ex);
                return false;
            }
        }
        #endregion
    }
}
