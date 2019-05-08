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
    public class NameConflict: CustomizedThread
    {
        public NameConflict(CustomizedLog _log, CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_log, _tokenSource, _threadParameter)
        {
            //param = (CopyFileParameter)ThreadParameter;
        }

        public override bool CheckParameter()
        {
            if (!NameConflictPathCheck((NameConflictParameter)ThreadParameter)) { return false; }
            return true;
        }

        public override void RunSub(ICloneable _threadParameter)
        {
            JudgeTaskCancelFlag();
            DirectoryInfo originalFold = new DirectoryInfo(((NameConflictParameter)_threadParameter).OriginalDirectory);
            log.Log("Analyzing [" + originalFold.FullName + "]");

            var originalfiles = originalFold.GetFiles().Where(s => {
                bool rtn = false;
                var extensionlist = ((NameConflictParameter)_threadParameter).OriginalExtension.Split(';');
                foreach (string item in extensionlist)
                {
                    rtn = rtn || s.Name.ToLower().EndsWith("." + item.ToLower());
                }

                return rtn;
                //s.Name.EndsWith(".exe") || s.Name.EndsWith(".doc") || s.Name.EndsWith(".docx")
            }
            );
            List<NameConflictResult> listNameConflictResult = new List<NameConflictResult>();
            IEnumerable<FileInfo> ListAllFile = (IEnumerable<FileInfo>)originalfiles.Where<FileInfo>(s => { return true; });


            // Check OrigLinal First
            foreach (FileInfo file in originalfiles)
            {
                JudgeTaskCancelFlag();
                //Thread.Sleep(1000);
                // remove self first
                ListAllFile = (IEnumerable<FileInfo>)ListAllFile.Except(new FileInfo[] { file });
                var conflictList = ListAllFile.Where(item => { return Path.GetFileNameWithoutExtension(file.Name) == Path.GetFileNameWithoutExtension(item.Name); });
                if (conflictList.Count() > 0)
                {
                    NameConflictResult conflictresult = new NameConflictResult();
                    conflictresult.OriginalFileName = file.Name;
                    conflictresult.Path = ((NameConflictParameter)_threadParameter).OriginalDirectory;
                    conflictresult.ExtensionName = Path.GetExtension(file.Name);
                    foreach (FileInfo s in conflictList)
                    {
                        conflictresult.NameConflictFileName += s.Name + " ; ";
                        // remove conflict file
                        ListAllFile = (IEnumerable<FileInfo>)ListAllFile.Except(new FileInfo[] { s });
                    }
                    listNameConflictResult.Add(conflictresult);
                }


            }
            if (((NameConflictParameter)_threadParameter).IsShowFolder)
            {
                if (listNameConflictResult.Count() == 0)
                {
                    // none conflict files under this folder
                    NameConflictResult conflictresult = new NameConflictResult();
                    conflictresult.OriginalFileName = "OK";
                    conflictresult.Path = ((NameConflictParameter)_threadParameter).OriginalDirectory;
                    conflictresult.NameConflictFileName = "none conflicts";
                    listNameConflictResult.Add(conflictresult);
                }
            }
            log.DeleteLog(2);
            LogConflictResult(listNameConflictResult);
            foreach (DirectoryInfo dir in originalFold.GetDirectories())
            {
                NameConflictParameter paramSub = (NameConflictParameter)((NameConflictParameter)_threadParameter).Clone();
                paramSub.OriginalDirectory = dir.FullName;

                RunSub(paramSub);
            }
        }
        public override void DoSomethingBeforeRunSub()
        {
            base.DoSomethingBeforeRunSub();
            log.Log("FileName\tPath\tConflict Files");

        }

        private bool NameConflictPathCheck(NameConflictParameter param)
        {
            DirectoryInfo originalFold = new DirectoryInfo(param.OriginalDirectory);
            if (!originalFold.Exists) { log.Log("Original Path is not exists."); return false; }
            return true;
        }
        private void LogConflictResult(List<NameConflictResult> list)
        {
            foreach (NameConflictResult item in list)
            {
                LogConflictResult(item);

            }
        }
        private void LogConflictResult(NameConflictResult result)
        {
            if (result.OriginalFileName == "OK")
                log.RecordWhitelog(result.OriginalFileName + "\t" + result.Path + "\t" + result.NameConflictFileName, true);
            else
                log.RecordRedlog(result.OriginalFileName + "\t" + result.Path + "\t" + result.NameConflictFileName, true);
        }
    }
}
