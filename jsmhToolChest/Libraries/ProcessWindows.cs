using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace jsmhToolChest.Libraries.ProcessWindows
{
    internal class ProcessWindows
    {
        const int SW_RESTORE = 9;

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        public class ProcessWindow
        {
            public ProcessWindow(int WindowHandle, string WindowTitle, string className)
            {
                Handle = WindowHandle;
                Title = WindowTitle;
                ClassName = className;
            }
            public int Handle { get; }
            public string Title { get; }
            public string ClassName { get; }

        }

        public static ProcessWindow[] GetProcessWindows(Process process) { 
            List<ProcessWindow> windows = new List<ProcessWindow>();
            if (process == null)
            {
                return null;
            }

            int targetProcessId = process.Id;
            IntPtr mainWindowHandle = IntPtr.Zero;
            EnumWindows((hWnd, lParam) =>
            {
                uint windowProcessId;
                GetWindowThreadProcessId(hWnd, out windowProcessId);
                if (windowProcessId == targetProcessId)
                {
                    StringBuilder className = new StringBuilder(256);
                    StringBuilder windowTitle = new StringBuilder(256);
                    GetClassName(hWnd, className, className.Capacity);
                    string classNameString = className.ToString();
                    GetWindowText(hWnd, windowTitle, windowTitle.Capacity);
                    string windowTitleString = windowTitle.ToString();

                    windows.Add(new ProcessWindow((int)hWnd, windowTitleString, classNameString));
                }
                return true;
            }, IntPtr.Zero);

            return windows.ToArray();
        }
    }
}
