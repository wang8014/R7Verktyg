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
    public class CheckFile: CustomizedThread
    {
        int CheckNumber = 0;
        public CheckFile(CustomizedLog _log, CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_log, _tokenSource, _threadParameter)
        {
            CheckNumber = 0;
        }

        public override bool CheckParameter()
        {
            CheckFileParameter paramCheckFile = (CheckFileParameter)ThreadParameter;
            if (!PathCheck(paramCheckFile)) { return false; }
            return true;
        }
        private bool PathCheck(CheckFileParameter param)
        {
            DirectoryInfo originalFold = new DirectoryInfo(param.OriginalDirectory);
            DirectoryInfo destinationFold = new DirectoryInfo(param.OutputDirectory);
            if (!originalFold.Exists) { log.Log("Original Path is not exists."); return false; }
            if (!destinationFold.Exists) { log.Log("Destination Path is not exists."); return false; }
            return true;
        }
        public override void DoSomethingAfterRunSub()
        {
            base.DoSomethingAfterRunSub();
            log.Log("number\tValid\tOriginal Size\tSize(Ori) Abbreviation\tOouput Size\tSize(Out) Abbreviation\ttOriginal Extension\tOutput Extension\tOriginal FileName\tOriginal Path\tDestination FileName\tDestination Path");

        }

        public override void RunSub(ICloneable _threadParameter)
        {
            this.JudgeTaskCancelFlag();
            CheckFileParameter param = (CheckFileParameter)_threadParameter;
            MatchFile.CheckDirectoryIsExists(param.OriginalDirectory, true);
            MatchFile.CheckDirectoryIsExists(param.OutputDirectory, true);

            DirectoryInfo originalFold = new DirectoryInfo(param.OriginalDirectory);
            DirectoryInfo destinationFold = new DirectoryInfo(param.OutputDirectory);


            var originalfiles = originalFold.GetFiles();
            var destinationfiles = destinationFold.GetFiles();
            List<CheckResult> listCheckResult = new List<CheckResult>();
            List<PairFile> convertingFileList = MatchFile.GetPairFileList(param);

            // Check Original First
            foreach (FileInfo file in originalfiles)
            {
                this.JudgeTaskCancelFlag();
                CheckResult checkresult = this.AnalyzeandReturnCheckResult(file,convertingFileList,destinationfiles);
                listCheckResult.Add(checkresult);
            }
            //check destination
            foreach (FileInfo file in destinationfiles)
            {
                this.JudgeTaskCancelFlag();
                CheckResult checkresult ;
                try
                {
                    checkresult = listCheckResult.First(f =>
                    {
                        return (f.DestinationFileNameWithExtension == Path.GetFileNameWithoutExtension(file.Name)) && (f.DestinationExtension == Path.GetExtension(file.Name));
                    });
                    if (checkresult == null)
                    {
                        // Destination is more than original
                        listCheckResult.Add(GetDestinationCheckResult(file));
                    }
                }
                catch (InvalidOperationException ex)
                {
                    // no equal item
                    listCheckResult.Add(GetDestinationCheckResult(file));
                }
                catch (Exception ex)
                {
                    
                }

            }
            LogCheckResult(listCheckResult);
            foreach (DirectoryInfo dir in originalFold.GetDirectories())
            {
                CheckFileParameter paramSub = (CheckFileParameter)param.Clone();
                paramSub.OriginalDirectory = dir.FullName;
                paramSub.OutputDirectory += "\\" + dir.Name;
                RunSub(paramSub);
            }
        }


        

        private CheckResult GetDestinationCheckResult(FileInfo file)
        {
            CheckResult checkresult = new CheckResult();
            checkresult.DestinationExtension = Path.GetExtension(file.Name);
            checkresult.DestinationFileSize = file.Length;
            checkresult.DestinationFileNameWithExtension = Path.GetFileNameWithoutExtension(file.Name);
            checkresult.DestinationPath = file.Directory.FullName;
            return checkresult;
        }

        private CheckResult AnalyzeandReturnCheckResult(FileInfo file, List<PairFile> convertingFileList, IEnumerable<FileInfo> destinationfiles)
        {
            CheckResult checkresult = new CheckResult();


            PairFile pFile = null;
            try
            {
                pFile = convertingFileList.First(s => s.originalFile.Name == file.Name);
            }
            catch(InvalidOperationException ex)
            {
                // no equal item
            }
            catch(Exception ex)
            {
                // others bug
            }
            if (pFile != null)
            {
                // file that LibreOffice support.
                checkresult.OriginalExtension = Path.GetExtension(pFile.originalFile.Name);
                checkresult.OriginalFileSize = pFile.originalFile.Length;
                checkresult.OriginalFileNameWithExtension = Path.GetFileNameWithoutExtension(pFile.originalFile.Name);
                checkresult.OriginalPath = pFile.originalFile.Directory.FullName;

                FileInfo outputFile;
                try
                {
                    outputFile = destinationfiles.First(f => Path.GetFileNameWithoutExtension(f.Name) == Path.GetFileNameWithoutExtension(pFile.outputFileName));
                    if (outputFile != null)
                    {
                        checkresult.DestinationExtension = Path.GetExtension(outputFile.Name);
                        checkresult.DestinationFileSize = outputFile.Length;
                        checkresult.DestinationFileNameWithExtension = Path.GetFileNameWithoutExtension(outputFile.Name);
                        checkresult.DestinationPath = outputFile.Directory.FullName;
                        checkresult.isValid = true;

                    }
                }
                catch (InvalidOperationException ex)
                {
                    // no equal item
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                //Files that LibreOffice doesn't support 
                checkresult.OriginalExtension = Path.GetExtension(file.Name);
                checkresult.OriginalFileSize = file.Length;
                checkresult.OriginalFileNameWithExtension = Path.GetFileNameWithoutExtension(file.Name);
                checkresult.OriginalPath = file.Directory.FullName;

                FileInfo outputFile;
                try
                {
                    outputFile = destinationfiles.First(f => Path.GetFileNameWithoutExtension(f.Name) == Path.GetFileNameWithoutExtension(file.Name));
                    if (outputFile != null)
                    {
                        checkresult.DestinationExtension = Path.GetExtension(outputFile.Name);
                        checkresult.DestinationFileSize = outputFile.Length;
                        checkresult.DestinationFileNameWithExtension = Path.GetFileNameWithoutExtension(outputFile.Name);
                        checkresult.DestinationPath = outputFile.Directory.FullName;
                        checkresult.isValid = (file.Name==outputFile.Name);

                    }
                }
                catch (InvalidOperationException ex)
                {
                    // no equal item
                }
                catch (Exception ex)
                {

                }

            }
            return checkresult;
        }
        private void LogCheckResult(List<CheckResult> list)
        {
            CheckNumber = 0;
            foreach(CheckResult result in list)
            {
                LogCheckResult(result);
            }
        }
        private void LogCheckResult(CheckResult result)
        {
            if (result != null)
            {
                //log.Log((result.isValid ? "OK" : "No") + "\t"  + result.OriginalFileSize.ToString("F2") + "KB" + "\t" + result.DestinationFileSize.ToString("F2") + "KB" + "\t" + result.OriginalExtension  + "\t" + result.DestinationExtension + "\t" + result.OriginalFileNameWithExtension + "\t" + result.DestinationPath);
                // Mike add Number, Exact Size
                CheckNumber += 1;
                log.RecordWhitelog(CheckNumber.ToString() + "\t");
                if (result.isValid)
                {
                    log.RecordWhitelog("OK", false);
                }
                else
                {
                    log.RecordRedlog("No", false);
                }
                log.RecordWhitelog("\t", false);
                log.RecordWhitelog(result.OriginalFileSize.ToString("N0"), false);

                log.RecordWhitelog("\t", false);
                log.RecordWhitelog(CustomizedLog.GetByteDescription(result.OriginalFileSize), false);

                log.RecordWhitelog("\t", false);
                log.RecordWhitelog(result.DestinationFileSize.ToString("N0"), false);

                log.RecordWhitelog("\t", false);
                log.RecordWhitelog(CustomizedLog.GetByteDescription(result.DestinationFileSize), false);

                log.RecordWhitelog("\t", false);
                if (result.isValid)
                {
                    log.RecordWhitelog(result.OriginalExtension, false);
                }
                else
                {
                    log.RecordRedlog(result.OriginalExtension, false);
                }

                log.RecordWhitelog("\t", false);
                if (result.isValid)
                { log.RecordWhitelog(result.DestinationExtension, false); }
                else
                { log.RecordBluelog(result.DestinationExtension, false); }

                log.RecordWhitelog("\t", false);
                if (result.isValid)
                {
                    log.RecordWhitelog(result.OriginalFileNameWithExtension, false);
                }
                else
                {
                    log.RecordRedlog(result.OriginalFileNameWithExtension, false);
                }


                log.RecordWhitelog("\t", false);
                if (result.isValid)
                { log.RecordWhitelog(result.OriginalPath, false); }
                else
                { log.RecordRedlog(result.OriginalPath, false); }

                log.RecordWhitelog("\t", false);
                if (result.isValid)
                {
                    log.RecordWhitelog(result.DestinationFileNameWithExtension, false);
                }
                else
                {
                    log.RecordBluelog(result.DestinationFileNameWithExtension, false);
                }


                log.RecordWhitelog("\t", false);
                if (result.isValid)
                { log.RecordWhitelog(result.DestinationPath, false); }
                else
                { log.RecordBluelog(result.DestinationPath, false); }

                log.RecordWhitelog("", true);
            }
        }
    }
}
