using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.IO;
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
        private static readonly string PATH = HttpContext.Current.Server.MapPath("..\\");
        private static ILog logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private string filepath;
        public Process ConversionProcess { get; set; }

        public bool Convert(string filepath, bool removeSound)
        {
            logger.Info("Beginning conversion: " + filepath);
            string ffmpegLocation = string.Empty;
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                // path.. = "C:\\Users\\w3stfa11\\Documents\\Visual Studio 2010\\Projects\\video-to-wikipedia.git\\Video-to-Wikipedia\\"
                this.filepath = filepath;
                //string serverpath1 = HttpContext.Current.Server.MapPath(".");
                string serverpath = HttpContext.Current.Server.MapPath("..\\");
                ffmpegLocation = serverpath + "ffmpeg2theora.exe";
                processStartInfo.FileName = ffmpegLocation;

                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.UseShellExecute = false;
                processStartInfo.Arguments = "\"" + serverpath + Path.GetFileName(filepath) + "\"";
                if (removeSound)
                    processStartInfo.Arguments += " --noaudio";
                ConversionProcess = Process.Start(processStartInfo);
                
            }
            catch (Exception e)
            {
                logger.Error("Error in convert: " + e.Message + Environment.NewLine + filepath + Environment.NewLine + ffmpegLocation);
                throw;
            }
            return true;
        }
/*
        private void conversionProcess_Exited(object sender, EventArgs e)
        {
            
            // start uploading to wikipedia
            UploadFile(Path.ChangeExtension(filepath, "ogv"));
        }
 * */
    }

}
