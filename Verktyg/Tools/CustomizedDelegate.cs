﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verktyg.Tools
{
    public delegate void SafeCallDelegateLog(string text);
    public delegate void SafeCallDelegateDeleteLog(int line);
    public delegate void InvokeLogWithoutColor(string text, bool withEnter);
    public delegate void InvokeLogWithColor(string text, System.Drawing.Color color, bool withEnter);
    public delegate void SetbuttonStatus(bool flag);
    
}
