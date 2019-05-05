using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using Verktyg.Tools;
using Verktyg.Threading;
using Verktyg.Log;


namespace Verktyg.Threading
{
    interface ICustomizedThread
    {
        Task Run();
        void SubRun();

        bool CheckParameter();
        void JudgeTaskCancelFlag();

    }
    public abstract class CustomizedThread
    {
        protected CancellationTokenSource tokenSource;
        protected CancellationToken token;
        protected CustomizedLog log;
        protected Task task;
        protected ICloneable ThreadParameter;
        // protected string reflectionName;

        public CustomizedThread(CustomizedLog _log, CancellationTokenSource _tokenSource, ICloneable _threadParameter)
        {
            tokenSource = _tokenSource;
            token = tokenSource.Token;
            log = _log;
            ThreadParameter = _threadParameter;
            // reflectionName = _reflectionName;
        }

        public virtual Task Run()
        {
            task = Task.Run(() => {
                if (!CheckParameter()) return;
                DoSomethingBeforeRunSub();
                RunSub(ThreadParameter);
                DoSomethingAfterRunSub();
                log.LogFinish(this.GetType().Name);
            });
            return task;
        }
        public virtual void DoSomethingBeforeRunSub()
        {
        }
        public virtual void DoSomethingAfterRunSub()
        {

        }
        public abstract void RunSub(ICloneable _threadParameter);
        public abstract bool CheckParameter();
        public void JudgeTaskCancelFlag()
        {
            if (token.IsCancellationRequested)
            {
                // Clean up here, then...
                // log.DeleteLog(1);
                //log.LogTaskCancel(this.GetType().Name);
                //this.BeginInvoke(new SetbuttonStatus(SetLibreOfficeButtonStatus), new object[] { true });
                log.LogTaskCancel(this.GetType().Name);
                token.ThrowIfCancellationRequested();
            }
        }
    }
}
