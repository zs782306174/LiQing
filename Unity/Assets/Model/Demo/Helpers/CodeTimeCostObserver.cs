



using System.Diagnostics;

namespace ETModel
{
    /// <summary>
    /// 代码片段耗时检测器
    /// </summary>
    public static class CodeTimeCostObserver
    {
        static Stopwatch _stopwatch;

        public static void StartObserve()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public static void StopObserve()
        {
            _stopwatch.Stop();
            Log.Info($"本次观测耗时为：{_stopwatch.Elapsed}");
        }
    }
}