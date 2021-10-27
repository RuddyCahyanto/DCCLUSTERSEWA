//Application:   ZipCode class
//
//Purpose:       Uses ICSharpCode SharpZipLib to zip files
//
//Author:        Wade Brooks
//
//Change History:
//   Date        Developer       Description
//09/06/2002     Wade Brooks     Initial Creation
//06/09/2009     Wade Brooks     Fixed zip file format to not include file folder info
//09/03/2009     Wade Brooks     Upgraded to 2008, Cleaned up code
//4/23/2010      Wade Brooks     Added search pattern of *.txt to skip zip files
//4/26/2010      Wade Brooks     Passed Zip search pattern to zip class to only zip text files, not previous zip files.

using System;
using System.IO;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.VisualBasic;

namespace DCCLUSTERSEWA
{
    public static class ZipCompress
    {
        /// <summary>
        /// Zip files in directory to sZipFileName
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="zipFileName"></param>
        /// <param name="searchPattern"></param>
        /// <param name="nmFile1"></param>
        /// <param name="nmFile2"></param>
        /// <param name="nmFile3"></param>
        internal static void zipFiles(string sourceDir, string zipFileName, string searchPattern, string nmFile1, string nmFile2, string nmFile3)
        {
            string[] astrFileNames = Directory.GetFiles(sourceDir, searchPattern);

            Crc32 objCrc32 = new Crc32();
            ZipOutputStream strmZipOutputStream;
            ZipEntry objZipEntry;

            try
            {
                strmZipOutputStream = new ZipOutputStream(File.Create(zipFileName.ToString()));
                strmZipOutputStream.SetLevel(6);
                // Compression Level: 0 - 9;
                // 0: no(Compression);
                // 9: maximum compression;

                foreach (string strFile in astrFileNames)
                {
                    if (Convert.ToBoolean(Strings.InStr(strFile, sourceDir + nmFile1)) || Convert.ToBoolean(Strings.InStr(strFile, sourceDir + nmFile2)) || Convert.ToBoolean(Strings.InStr(strFile, sourceDir + nmFile3)))
                    {
                        FileStream strmFile = File.OpenRead(strFile);
                        byte[] abyBuffer = new byte[strmFile.Length - 1];

                        strmFile.Read(abyBuffer, 0, abyBuffer.Length);
                        objZipEntry = new ZipEntry(Path.GetFileName(strFile));

                        objZipEntry.DateTime = DateTime.Now;
                        objZipEntry.Size = strmFile.Length;
                        strmFile.Close();
                        objCrc32.Reset();
                        objCrc32.Update(abyBuffer);
                        objZipEntry.Crc = objCrc32.Value;
                        strmZipOutputStream.PutNextEntry(objZipEntry);
                        strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length);
                    }
                }
                strmZipOutputStream.Finish();
                strmZipOutputStream.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
