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
using System.Diagnostics;

namespace Verktyg.Threading
{
    public class LibreOfficeConvert: CustomizedThread
    {
        List<string> commandList = new List<string>();
        // int CheckNumber;
        public LibreOfficeConvert(CustomizedLog _log, CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_log, _tokenSource, _threadParameter)
        {
            List<string> commandList = new List<string>();
            //CheckNumber = 0;
        }

        public override bool CheckParameter()
        {
            LibreOfficeParameter librparam = (LibreOfficeParameter)this.ThreadParameter;
            if (!CheckLibreOfficeParamter(librparam)) { return false; }
            return true;
        }


        public override void RunSub(ICloneable _threadParameter)
        {
            JudgeTaskCancelFlag();
            LibreOfficeParameter librparam = (LibreOfficeParameter)_threadParameter;
            MatchFile.CheckDirectoryIsExists(librparam.OriginalDirectory, true);
            MatchFile.CheckDirectoryIsExists(librparam.OutputDirectory, true);
            DirectoryInfo originalFold = new DirectoryInfo(librparam.OriginalDirectory);
            DirectoryInfo destinationFold = new DirectoryInfo(librparam.OutputDirectory);
            if (!originalFold.Exists) { return; }
            if (!destinationFold.Exists) { return; }

            //Get pairfile
            List<PairFile> convertingFileList = MatchFile.GetPairFileList(librparam);

            //Convert file
            foreach (PairFile file in convertingFileList)
            {
                try
                {
                    JudgeTaskCancelFlag();
                    string temp = GetCommand(librparam, file);
                    commandList.Add(temp);
                    DateTime dtStart = System.DateTime.Now;
                    log.Log("Convert file [" + file.originalFile.FullName + "][" + CustomizedLog.GetByteDescription(file.originalFile.Length) + "]");
                    log.LogContinue();


                    //if (token.IsCancellationRequested)
                    //{
                    //    // Clean up here, then...
                    //    log.DeleteLog(3);
                    //    log.LogTaskCancel("Converting");
                    //    // this.BeginInvoke(new SetbuttonStatus(SetLibreOfficeButtonStatus), new object[] { true });
                    //    token.ThrowIfCancellationRequested();
                    //}
                    if (file.IsRename)
                    {
                        file.CreateSerialNumberFile();
                    }

                    bool isNeedConvert = true;
                    if (!librparam.Isoverwrite)
                    {
                        if (System.IO.File.Exists(librparam.OutputDirectory + "\\" + file.outputFileName))
                        {
                            isNeedConvert = false;
                        }
                    }
                    if (isNeedConvert)
                    {
                        Process pr = new Process();//声明一个进程类对象
                        pr.StartInfo.FileName = "\"" + librparam.Path + "\"";
                        pr.StartInfo.Arguments = " " + librparam.Command + " " + librparam.OutputFileExtension + " " + "\"" + file.GetRightOriginalName() + "\" " + " --outdir \"" + librparam.OutputDirectory + "\"";
                        pr.Start();
                        pr.WaitForExit();

                        //DateTime dtConvertStart = System.DateTime.Now;
                        //// Console.WriteLine("LibreOffice Process is finished");
                        //while (!System.IO.File.Exists(librparam.OutputDirectory + "\\" + file.outputFileName)) {
                        //    // Console.WriteLine(librparam.OutputFileExtension + " is not created");
                        //    Thread.Sleep(100);
                        //}
                        //DateTime dtConvertEnd = System.DateTime.Now;
                        // Console.WriteLine("wait for the pdf file time: " + (dtConvertEnd - dtConvertStart).TotalSeconds.ToString("F0") + "s");
                    }

                    // delete serialNumber file
                    if (file.IsRename)
                    {
                        file.DeleteSerialNumberFile();
                    }
                    DateTime dtEnd = System.DateTime.Now;
                    log.DeleteLog(3);
                    log.Log((dtEnd - dtStart).TotalSeconds.ToString("F0") + "s" + (isNeedConvert ? "" : "(N)") + "\t\t" + file.originalFile.FullName);


                }
                catch (System.OperationCanceledException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    log.Log("error:" + ex.Message);
                }
            }
            if (librparam.IsincludSubfolder)
            {
                foreach (DirectoryInfo dir in originalFold.GetDirectories())
                {
                    LibreOfficeParameter libreparamSub = (LibreOfficeParameter)librparam.Clone();
                    libreparamSub.OriginalDirectory = dir.FullName;
                    libreparamSub.OutputDirectory += "\\" + dir.Name;
                    RunSub(libreparamSub);

                }
            }
        }

        private bool CheckLibreOfficeParamter(LibreOfficeParameter libreparam)
        {
            bool rtn = false;
            if (!System.IO.File.Exists(libreparam.Path))
            {
                log.Log("LibeOffice is not exists.");
                return rtn;
            }
            if (!System.IO.Directory.Exists(libreparam.OriginalDirectory))
            {
                log.Log("OriginalDirectory is not exists.");
                return rtn;
            }
            if (!System.IO.Directory.Exists(libreparam.OutputDirectory))
            {
                log.Log("OutputDirectory is not exists.");
                return rtn;
            }
            switch (libreparam.OutputFileExtension)
            {
                case "pdf":
                    break;
                default:
                    log.Log("OutputFileExtension[" + libreparam.OutputFileExtension + "] is not supported");
                    return rtn;
                    // break;
            }
            foreach (var extension in libreparam.OriginalExtension.Split(';'))
            {
                switch (extension)
                {
                    #region word
                    case "docx":
                        break;
                    case "doc":
                        break;
                    case "docm":
                        break;
                    case "dot":
                        break;
                    case "dotm":
                        break;
                    case "dotx":
                        break;
                    #endregion word
                    #region Excel
                    case "xlsx":
                        break;
                    case "xls":
                        break;
                    case "xlsb":
                        break;
                    case "xlsm":
                        break;
                    case "xltx":
                        break;
                    #endregion Excel
                    #region RichText
                    case "rtf":
                        break;
                    #endregion RichText
                    #region  PowerPoint
                    case "potm":
                        break;
                    case "potx":
                        break;
                    case "pps":
                        break;
                    case "ppsm":
                        break;
                    case "ppsx":
                        break;
                    case "ppt":
                        break;
                    case "pptm":
                        break;
                    case "pptx":
                        break;
                    #endregion PowerPoint
                    #region  PDF
                    case "pdf":
                        break;
                    #endregion PDF
                    default:
                        log.Log("OriginalExtesnsion[" + extension + "] is not supported");
                        return rtn;
                        // break;
                }
            }
            return true;

        }

        public override void DoSomethingBeforeRunSub()
        {
            base.DoSomethingBeforeRunSub();
            commandList.Clear();
            log.Log("Time\t\tFileName");
            
        }
        public override void DoSomethingAfterRunSub()
        {
            FileInfo finfo = new FileInfo(((LibreOfficeParameter)this.ThreadParameter).BatchFile);

            if (!System.IO.Directory.Exists(finfo.DirectoryName))
            {
                System.IO.Directory.CreateDirectory(finfo.DirectoryName);
            }
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(((LibreOfficeParameter)this.ThreadParameter).BatchFile, false))
            {
                foreach (string line in commandList)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.

                    file.WriteLine(line);

                }
            }
            //DeleteLog(2);
            //log.LogTaskEnd();
        }

        //private PairFile GetPairFile(LibreOfficeParameter librparam, FileInfo file, bool IsRename, byte Index)
        //{
        //    PairFile pairFile = new PairFile(file.FullName);
        //    // pairFile.originalFile = new FileInfo();
        //    pairFile.outputDir = librparam.OutputDirectory;
        //    pairFile.outputFileExtension = librparam.OutputFileExtension;
        //    pairFile.IsRename = IsRename;
        //    pairFile.serialNumber = Index;
        //    pairFile.CreateSerialNumberFile();
        //    return pairFile;
        //}

        
        private string GetCommand(LibreOfficeParameter librparam, PairFile file)
        {
            string command = "\"";
            command += librparam.Path + "\" ";
            command += librparam.Command + " ";
            command += librparam.OutputFileExtension + " ";
            command += "\"" + file.GetRightOriginalName() + "\" ";
            command += " --outdir \"" + librparam.OutputDirectory + "\"";
            return command;
        }

    }
}
