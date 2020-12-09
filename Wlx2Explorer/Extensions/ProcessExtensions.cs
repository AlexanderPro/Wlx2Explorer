using System;
using System.Diagnostics;
using Wlx2Explorer.Native;

namespace Wlx2Explorer.Extensions
{
    static class ProcessExtensions
    {
        public static bool ExistProcessWithSameNameAndDesktop(this Process currentProcess)
        {
            foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (currentProcess.Id != process.Id)
                {
                    var processThreadId = process.GetMainThreadId();
                    var currentProcessThreadId = currentProcess.GetMainThreadId();
                    var processDesktop = NativeMethods.GetThreadDesktop(processThreadId);
                    var currentProcessDesktop = NativeMethods.GetThreadDesktop(currentProcessThreadId);
                    if (currentProcessDesktop == processDesktop) return true;
                }
            }
            return false;
        }

        public static int GetMainThreadId(this Process currentProcess)
        {
            var mainThreadId = -1;
            var startTime = DateTime.MaxValue;
            foreach (ProcessThread thread in currentProcess.Threads)
            {
                if (thread.StartTime < startTime)
                {
                    startTime = thread.StartTime;
                    mainThreadId = thread.Id;
                }
            }
            return mainThreadId;
        }
    }
}
