using System;
using System.IO;
using System.Windows.Forms;

namespace FamilyMoneyApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var dirInfo = new DirectoryInfo("save");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            
            var cutOffDate = DateTime.Now.AddDays(-5);
            var directoryInfo = new DirectoryInfo("logs\\");
            FileInfo[] fileInfos = directoryInfo.GetFiles();

            foreach (var fileInfo in fileInfos)
            {
                if (fileInfo.LastWriteTime < cutOffDate)
                {
                    File.Delete(fileInfo.FullName);
                }
            }

            MyLogger.Logger.Info("приложение запущено");

            try
            {
                Application.Run(new MainForm());
                MyLogger.Logger.Info("приложение окончило свою работу успешно");
            }
            catch (Exception e)
            {
                MyLogger.Logger.Error(e.ToString);
            }
        }
    }
}