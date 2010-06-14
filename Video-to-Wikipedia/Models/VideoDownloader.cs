using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Diagnostics;
using System.Reflection;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.IO;
using log4net;
using Timer = System.Timers.Timer;

namespace Video_to_Wikipedia.Models
{
    public class VideoDownloader
    {
        private static readonly string PATH = HttpContext.Current.Server.MapPath("..\\");
        private static string filepath;
        private static ILog logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly long DownloadTimeout = 60000; // 10 minutes to timeout
        public static bool ProcessVideo(string downloadUrl)
        {
            // todo check if file already exists, else rename
            WebClient webClient = new WebClient();
            string url = @"http://www.flickr.com/photos/iriya/4524606136/play/site/271ab481a7";
           
            filepath = PATH + "video.mp4";
            logger.Info(filepath);
            logger.Info("appdomain: " + AppDomain.CurrentDomain.BaseDirectory);
            try
            {
                webClient.DownloadFileCompleted += DownloadCompleted;
                webClient.DownloadFileAsync(new Uri(url), filepath);
                Timer t = new Timer();
                t.Start();
                t.Interval = DownloadTimeout; 
                t.Elapsed += delegate { webClient.CancelAsync(); };
            }
            catch (WebException ex)
            {
                logger.Info(ex.Status);
                logger.Info(ex.Response);
                
            }
            
            return false;
        }

        private static void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Converter converter = new Converter();
            converter.Convert(filepath);
        }
    }
}