using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MinMaximize.App
{

    public class Window
    {
        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        public AppWindowMode SwitchAppMode(Process process) 
        {
            return GetAppMode(process) switch
            {
                AppWindowMode.SW_SHOWMINIMIZED => SetAppMode(process, AppWindowMode.SW_SHOWNORMAL),
                _ => SetAppMode(process, AppWindowMode.SW_SHOWMINIMIZED)
            };
        }

        public AppWindowMode SetAppMode(Process process, AppWindowMode appWindowMode)
        {
            ShowWindowAsync(process.MainWindowHandle, (int)appWindowMode);
            return appWindowMode;
        } 

        public AppWindowMode GetAppMode(Process process)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            GetWindowPlacement(process.MainWindowHandle, ref placement);
            return placement.showCmd switch
            {
                1 => AppWindowMode.SW_SHOWNORMAL,
                2 => AppWindowMode.SW_SHOWMINIMIZED,
                3 => AppWindowMode.SW_SHOWMAXIMIZED,
                _ => AppWindowMode.SW_UNKNOWN
            };
        }

    }

}
