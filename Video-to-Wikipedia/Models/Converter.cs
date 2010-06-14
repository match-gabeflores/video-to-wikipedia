using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using log4net;

namespace Video_to_Wikipedia.Models
{
    public class Converter
    {
        private static ILog logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public bool Convert(string filepath)
        {
            logger.Info("Beginning conversion");
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            // path.. = "C:\\Users\\w3stfa11\\Documents\\Visual Studio 2010\\Projects\\video-to-wikipedia.git\\Video-to-Wikipedia\\"
            string serverpath1 = HttpContext.Current.Server.MapPath(".");
            string serverpath = HttpContext.Current.Server.MapPath("..\\");
            string ffmpegLocation = serverpath + "ffmpeg2theora.exe";
            processStartInfo.FileName = ffmpegLocation;


            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.Arguments = "\"" + serverpath + "video.mp4" + "\"";

            Process conversionProcess = Process.Start(processStartInfo);
            if (conversionProcess != null)
            {
                conversionProcess.EnableRaisingEvents = true;
                conversionProcess.Exited += new System.EventHandler(conversionProcess_Exited);
            }
            /*
            StreamReader sr;
            if (conversionProcess != null)
            {
                sr = conversionProcess.StandardOutput;
                F   ileInfo info = new FileInfo( serverpath + "output.txt");

                StreamWriter tw = info.CreateText();
                tw.WriteLine(sr.ReadToEnd());
                tw.Close();
            }
 */
            return true;
        }

        private void conversionProcess_Exited(object sender, EventArgs e)
        {
            // start uploading to wikipedia
            logger.Info("Uploading to Wikipedia");
            throw new NotImplementedException();
        }
    }

}
