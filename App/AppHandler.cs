using System;
using System.Diagnostics;

namespace MinMaximize.App
{
    sealed class AppHandler
    {
        private Window _window = new Window();
        private Process[] Processes { get => Process.GetProcessesByName(_processName); }
        private string _appPath;
        private string _processName;

        public AppHandler(string appPath) : this(appPath, appPath)
        {

        }

        public AppHandler(string appPath, string processName)
        {
            _appPath = appPath;
            _processName = processName;
        }

        public void HandleApp()
        {
            if (Processes.Length == 0)
            {
                StartApp();
            }
            else
            {
                SwitchAppMode();
            }
        }


        private void StartApp()
        {
            try
            {
                Process.Start(_appPath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error when starting app '{e.Message}'");
                Environment.Exit(-3);
            }
        }

        private void SwitchAppMode()
        {
            foreach (var process in Processes)
            {
                _window.SwitchAppMode(process);
            }

        }
    }

}
