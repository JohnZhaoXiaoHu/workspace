using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Core.Extension
{
    public static class TimerHelper
    {
        public static async Task<double> GetTimer(this Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await Task.Run(() =>
            {
                action.Invoke();
            });
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}
