using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Shared.Helper
{
    public static class TimeSpanHelper
    {
        public static long GetTimeSpan(this Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action?.Invoke();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static async Task<double> GetTimeSpanAsync(this Action action)
        {
            /*Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();*/
            Stopwatch stopwatch=Stopwatch.StartNew();//简化写法，等同于上面注释掉的两行
            await Task.Run(() =>
            {
                action?.Invoke();
            });
            stopwatch.Stop();
            
            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}
