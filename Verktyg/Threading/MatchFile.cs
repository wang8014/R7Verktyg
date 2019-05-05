using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Verktyg.Tools;
using Verktyg.Threading;
using Verktyg.Log;
using System.Threading.Tasks;
using System.IO;

namespace Verktyg.Threading
{
    public class MatchFile
    {
        public static List<PairFile> GetPairFileList(CheckFileParameter param)
        {
            List<PairFile> pairFileList = new List<PairFile>();
            DirectoryInfo originalFold = new DirectoryInfo(param.OriginalDirectory);
            DirectoryInfo destinationFold = new DirectoryInfo(param.OutputDirectory);
            if (!originalFold.Exists) { return pairFileList; }
            if (!destinationFold.Exists) { return pairFileList; }

            //
            
            //Get original files list
            var originalFileList = originalFold.GetFiles().Where(s => {
                bool rtn = false;
                var extensionlist = param.OriginalExtension.Split(';');
                foreach (string item in extensionlist)
                {
                    rtn = rtn || s.Name.EndsWith("." + item);
                }

                return rtn;
            });
            //Get LibreOffice support list
            var LibreOfficeSupportFileList = originalFold.GetFiles().Where(s => {
                bool rtn = false;
                var extensionlist = param.AllExtensionOfLibreOfficeSupporting.Split(';');
                foreach (string item in extensionlist)
                {
                    rtn = rtn || s.Name.EndsWith("." + item);
                }

                return rtn;
            });

            //Create converting File List
            while (originalFileList.Count() > 0)  // (FileInfo item in originalFileList)
            {
                FileInfo file = originalFileList.First();
                // originalFileList = originalFileList.Except(new FileInfo[] { file }, new FileInfoComparer());

                IEnumerable<FileInfo> result = LibreOfficeSupportFileList.Where(s =>
                {
                    return Path.GetFileNameWithoutExtension(file.Name) == Path.GetFileNameWithoutExtension(s.Name);
                });
                originalFileList = originalFileList.Except(result, new FileInfoComparer());

                if (result.Count() == 1)
                {
                    //no conflict
                    //reduce originalFileList 
                    PairFile pairFile = GetPairFile(param, result.First(), false, 0);
                    pairFileList.Add(pairFile);
                }
                else
                {
                    //result.Count() must >1 , no possible it is < 1
                    //conflict happens
                    byte index = 1;
                    foreach (FileInfo item in result)
                    {
                        PairFile pairFile = GetPairFile(param, item, true, index);
                        //pairFile.CreateSerialNumberFile();
                        pairFileList.Add(pairFile);
                        index += 1;
                    }
                }
            }
            return pairFileList;
        }

        private static PairFile GetPairFile(CheckFileParameter librparam, FileInfo file, bool IsRename, byte Index)
        {
            PairFile pairFile = new PairFile(file.FullName);
            // pairFile.originalFile = new FileInfo();
            pairFile.outputDir = librparam.OutputDirectory;
            pairFile.outputFileExtension = librparam.OutputFileExtension;
            pairFile.IsRename = IsRename;
            pairFile.serialNumber = Index;
            // pairFile.CreateSerialNumberFile();
            return pairFile;
        }


        public static bool CheckDirectoryIsExists(string path, bool isCreate)
        {
            if (System.IO.File.Exists(path)) { return true; }
            else
            {
                if (isCreate)
                {
                    System.IO.Directory.CreateDirectory(path);
                    if (System.IO.File.Exists(path)) { return true; }
                    else
                    { return false; }
                }
                else
                { return false; }
            }
        }

    }
}
