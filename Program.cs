using System;
using System.IO;
using MinMaximize.App;

namespace MinMaximize
{

    class Program
    {

        private static bool IsAppPathAndNameValid(string appPath, string appName) => !(string.IsNullOrWhiteSpace(appPath) || string.IsNullOrWhiteSpace(appName));
        private static bool IsProcessNameValid(string processName) => !string.IsNullOrWhiteSpace(processName);

        static void Main(string[] args)
        {
            #region args validation
            if (args.Length < 1)
            {
                Console.WriteLine("Cannot run app without [app_path]");
                Environment.Exit(-1);
            }
            
            var appPath = args[0];
            var appName = Path.GetFileNameWithoutExtension(appPath);

            if (!IsAppPathAndNameValid(appPath, appName))
            {
                Console.WriteLine("Wrong [app_path]");
                Environment.Exit(-2);
            }
            
            var processName = (args.Length >= 2) ? args[1] : appName;

            if (!IsProcessNameValid(processName))
            {
                Console.WriteLine("Wrong [task_name]");
                Environment.Exit(-2);
            }
            #endregion
            
            new AppHandler(appName, processName).HandleApp();
        }

    }

}
