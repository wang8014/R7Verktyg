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
    public class CopyFolder: CustomizedThread
    {
        //private CopyFileParameter param;
        public CopyFolder(CustomizedLog _log, CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_log,_tokenSource, _threadParameter)
        {
            //param = (CopyFileParameter)ThreadParameter;
        }
        //public override Task Run()
        //{
            
        //}
        public override void RunSub(ICloneable _threadParameter)
        {
            JudgeTaskCancelFlag();
            //Thread.Sleep(1000);
            CopyFileParameter param = (CopyFileParameter)_threadParameter;
            DirectoryInfo originalFold = new DirectoryInfo(param.OriginalDirectory);
            DirectoryInfo destinationFold = new DirectoryInfo(param.OutoutDirectoy);
            log.Log(originalFold.Name  + "\t" + originalFold.GetFiles().Length.ToString() + "\t" + param.OutoutDirectoy + "\\" + originalFold.Name);


            if (!System.IO.Directory.Exists(param.OutoutDirectoy + "\\" + originalFold.Name))
            {
                System.IO.Directory.CreateDirectory(param.OutoutDirectoy + "\\" + originalFold.Name);
                //log.Log("Created [" + param.OutoutDirectoy + "\\" + originalFold.Name + "]");
            }
            foreach (DirectoryInfo dir in originalFold.GetDirectories())
            {
                //if (token.IsCancellationRequested)
                //{
                //    // Clean up here, then...
                //    log.DeleteLog(1);
                //    log.LogTaskCancel(this.GetType().Name);
                //    //this.BeginInvoke(new SetbuttonStatus(SetLibreOfficeButtonStatus), new object[] { true });
                //    token.ThrowIfCancellationRequested();
                //}
                JudgeTaskCancelFlag();
                CopyFileParameter subparam = (CopyFileParameter)param.Clone();
                subparam.OriginalDirectory = dir.FullName;
                subparam.OutoutDirectoy = param.OutoutDirectoy + "\\" + originalFold.Name;
                RunSub(subparam);
            }
        }

        public override bool CheckParameter()
        {
            
            DirectoryInfo originalFold = new DirectoryInfo(((CopyFileParameter)this.ThreadParameter).OriginalDirectory);
            DirectoryInfo destinationFold = new DirectoryInfo(((CopyFileParameter)this.ThreadParameter).OutoutDirectoy);
            if (!originalFold.Exists) { log.Log(originalFold.FullName + "is not exists.Task is finished."); return false; }
            if (!destinationFold.Exists) { log.Log(destinationFold.FullName + "is not exists.Task is finished."); return false; }
            return true;
        }
    }
}
