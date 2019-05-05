using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;

namespace Verktyg
{
    abstract class Threading
    {
        protected CancellationTokenSource tokenSource;
        public abstract  Task Run();
        public abstract  void SubRun();
    }
}
