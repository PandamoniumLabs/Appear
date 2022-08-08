using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Appear.Services
{
    public class VersionHelper
    {
        private string MSIFilePath = Path.Combine(Environment.CurrentDirectory, "HoustersCrawler.msi");
        private string CmdFilePath = Path.Combine(Environment.CurrentDirectory, "Install.cmd");
        private string MsiUrl = String.Empty;

        public bool CheckForNewVersion()
        {
            MsiUrl = GetNewVersionUrl();
            return MsiUrl.Length > 0;
        }

        public void DownloadNewVersion()
        {
            DownloadNewVersion(MsiUrl);
            CreateCmdFile();
            RunCmdFile();
            ExitApplication();
        }

        private string GetNewVersionUrl()
        {
            //var currentVersion = Convert.ToInt32(Properties.Settings.Default.Release);
            ////get xml from url.
            //var url = Properties.Settings.Default.URL;
            var builder = new StringBuilder();
            using (var stringWriter = new StringWriter(builder))
            {
                
            }
            return String.Empty;
        }

        private void DownloadNewVersion(string url)
        {
            //delete existing msi.
            if (File.Exists(MSIFilePath))
            {
                File.Delete(MSIFilePath);
            }
            //download new msi.
            using (var client = new WebClient())
            {
                client.DownloadFile(url, MSIFilePath);
            }
        }

        private void CreateCmdFile()
        {
            //check if file exists.
            if (File.Exists(CmdFilePath))
                File.Delete(CmdFilePath);
            //create new file.
            var fi = new FileInfo(CmdFilePath);
            var fileStream = fi.Create();
            fileStream.Close();
            //write commands to file.
            using (TextWriter writer = new StreamWriter(CmdFilePath))
            {
                writer.WriteLine(@"msiexec /i HoustersCrawler.msi /quiet");
            }
        }

        private void RunCmdFile()
        {//run command file to reinstall app.
            var p = new Process();
            p.StartInfo = new ProcessStartInfo("cmd.exe", "/c Install.cmd");
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            //p.WaitForExit();
        }

        private void ExitApplication()
        {//exit the app.
            Application.Current.Shutdown();
        }
    }
}
