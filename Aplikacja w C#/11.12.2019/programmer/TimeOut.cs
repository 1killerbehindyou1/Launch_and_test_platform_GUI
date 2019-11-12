using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Kucia.sprog.Programmer
{
    public static class TimeOut
    {
        public static void DoWork(Action action, int timeout)
        {
            ManualResetEvent evt = new ManualResetEvent(false);
            AsyncCallback cb = delegate { evt.Set(); };
            IAsyncResult result = action.BeginInvoke(cb, null);
            if (evt.WaitOne(timeout))
            {
                action.EndInvoke(result);
            }
            else
            {
                throw new TimeoutException("Operation timeout. Waited " + timeout.ToString() + "[ms]");
            }
        }
    }
}
