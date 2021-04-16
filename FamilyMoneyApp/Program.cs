using System;
using System.IO;
using System.Windows.Forms;
using NLog;

namespace NewFamilyMoney
{
    static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DirectoryInfo dirInfo = new DirectoryInfo("save");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            
            DateTime CutOffDate = DateTime.Now.AddDays(-5);
            DirectoryInfo di = new DirectoryInfo("logs\\");
            FileInfo[] fi = di.GetFiles();

            for (int i = 0; i < fi.Length; i++)
            {
                if (fi[i].LastWriteTime < CutOffDate)
                {
                    File.Delete(fi[i].FullName);
                }
            }

            logger.Info("приложение запущено");

            try
            {
                Application.Run(new MainForm());
                logger.Info("приложение окончило свою работу успешно");
            }
            catch (Exception e)
            {
                logger.Error(e.ToString);
            }
        }
    }
}