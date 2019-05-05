using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Verktyg.Tools;
using Verktyg.Threading;
using Verktyg.Log;
using System.IO;

namespace Verktyg.Threading
{
    public class DeleteFile: CustomizedThread
    {
        public DeleteFile(CustomizedLog _log, CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_log, _tokenSource, _threadParameter)
        {
            //param = (CopyFileParameter)ThreadParameter;
        }

        public override bool CheckParameter()
        {
            DirectoryInfo originalFold = new DirectoryInfo(((DeleteFileParameter)this.ThreadParameter).OutoutDirectoy);
            if (!originalFold.Exists) { log.Log(originalFold.FullName + " is not exists.Task is finished.");  return false; }
            return true;
        }
        
        public override void RunSub(ICloneable _threadParameter)
        {
            JudgeTaskCancelFlag();
            DirectoryInfo CurrentFold = new DirectoryInfo(((DeleteFileParameter)_threadParameter).OutoutDirectoy);
            log.Log("Folder[" + CurrentFold.FullName + "]");
            foreach (FileInfo file in CurrentFold.GetFiles())
            {
                JudgeTaskCancelFlag();
                try
                {
                    JudgeTaskCancelFlag();
                    file.Delete();
                    log.Log(file.FullName + " is deleted.");
                }
                catch (Exception ex)
                {
                    log.Log(" Don't delete the file[" + file.FullName + "] error:" + ex.Message);
                }
            }
            foreach (DirectoryInfo dirinfo in CurrentFold.GetDirectories())
            {
                log.Log("Folder[" + dirinfo.FullName + "]");
                DeleteFileParameter subparam = (DeleteFileParameter)(_threadParameter.Clone());
                subparam.OutoutDirectoy = dirinfo.FullName;
                RunSub(subparam);
            }
        }
    }
}
