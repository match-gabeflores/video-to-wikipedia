using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.IO;
using DotNetWikiBot;
using log4net;
using Video_to_Wikipedia.Helpers;
using Timer = System.Timers.Timer;
//todo - how to hide username/password details (even from web.config?
// todo - move ffmpeg location and video location to web.config and put into configuration
namespace Video_to_Wikipedia.Models
{
    public class VideoDownloader
    {
        private static readonly string PATH = HttpContext.Current.Server.MapPath("..\\");
        private static string filepath;
        private static ILog logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly long DownloadTimeout = 120000; // 20 minutes to timeout
        private static VideoInfo videoInfo;
        private static bool removeSound = false;
        public static bool ProcessVideo(VideoInfo videoInfoInput, bool rmSound)
        {

            WebClient webClient = new WebClient();
            videoInfo = videoInfoInput;
            removeSound = rmSound;
            logger.Info("videoinfo.filename " + videoInfo.Filename + "\n" + videoInfoInput.Filename);
            
            filepath = PATH + videoInfo.Filename;
            
            logger.Info("Server.MapPath(..\\) + filename: " + filepath);
            if (Path.HasExtension(filepath) == false)
                filepath += ".mp4"; // todo change to .mp4
            else
                filepath = Path.ChangeExtension(filepath, "mp4"); // download as mp4 extension
            logger.Info("Download video: " + filepath);
            try
            {
                webClient.DownloadFileCompleted += DownloadCompleted;
                webClient.DownloadFileAsync(new Uri(videoInfo.DownloadUrl), filepath);
                Timer t = new Timer();
                t.Start();
                t.Interval = DownloadTimeout; 
                t.Elapsed += delegate { webClient.CancelAsync(); };
            }
            catch (WebException ex)
            {
                logger.Error(ex.Status);
                logger.Error(ex.Response);
            }
            
            return false;
        }

        private static void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //e.Error, e.Cancelled
            logger.Info("Download complete for " + videoInfo.Filename);
            
            
            Converter converter = new Converter();
            try
            {

                converter.Convert(filepath, removeSound);
                //ConversionProcessExited(null, null); //debugging - skip conversion
                if (converter.ConversionProcess != null)
                {
                    converter.ConversionProcess.EnableRaisingEvents = true;
                    converter.ConversionProcess.Exited += ConversionProcessExited;

                }
            }
            catch (Exception exception)
            {
                logger.Error("Conversion process exception before exiting" + exception.Message);
                throw;
            }
             
            //todo rename file
            //todo  if successfully converted (check exit code, standard error, isresponding
           // filepath = Path.ChangeExtension(filepath, "ogv");
            //UploadFile(videoInfo);
        }

        private static void ConversionProcessExited(object sender, EventArgs e)
        {
            var process = (Process) sender;
            if (process.HasExited)
                if (process.ExitCode != 0)
                {
                    logger.Error("Conversion process exited unexpectedly " + videoInfo.Filename);
                    throw new Exception("Process exited unexpectedly");
                }
                else
                {
                    logger.Info("Conversion process succeeded for " + videoInfo.Filename);
                }
         
            
            UploadFile(Path.ChangeExtension(filepath,"ogv"));
            logger.Info("Finishing video to wikipedia request");
        }

        private static bool UploadFile(string fileToUpload)
        {
            logger.Info("Logging into Wiki");
            string siteurl = "http://commons.wikimedia.org";
            //string siteurl = "http://vgsales.wikia.com";
            //string siteurl = "http://w3stfa11.limewebs.com/wiki/index.php?title=Main_Page";
            Site wikiSite;
            Page page;
            try
            {
                wikiSite = new Site(siteurl, Configuration.WikiUsername, Configuration.WikiPassword);
                //wikiSite = new Site(siteurl, "abc", "123"); //limewebs
                page = new Page(wikiSite,videoInfo.Title);
                

            }
            catch (Exception e)
            {
                logger.Error("Unable to login to: " + siteurl + " error:" + e.Message + e.StackTrace + e.Source + e.InnerException + "\n" +e.Data);
                return false;
            }
            string fileNamespace = "6";
            string fileName = Path.GetFileName(fileToUpload);
            page.title = wikiSite.namespaces[fileNamespace] + ":" + fileName;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{{Information");
            sb.AppendLine("|Description	= {{en|1=" + videoInfo.Description + "}}");
            sb.AppendFormat("|Source		= originally posted to '''[[Flickr]]''' as [{0} {1}]", videoInfo.SourceUrl,
                            videoInfo.Title);
            sb.AppendLine();
            sb.AppendLine("|Date		= " + videoInfo.Date);
            sb.AppendLine("|Author		= " + videoInfo.Author);
            sb.AppendLine("|Permission	= " + GetLicenseTemplate(videoInfo.License));
            sb.AppendLine("|Other versions		= ");
            sb.AppendLine("}}");
            
            string wikitext = sb.ToString();
            logger.Info("--------------\n" + wikitext);
            try {
                page.Load();
            }
            catch(Exception ex)
            {
                return false;
            }

            if (page.Exists())
            {
                int x = 0;
                //return false;
            }

            try {
                logger.InfoFormat("Uploading {0} to Wiki", fileToUpload);
                page.UploadImage(fileToUpload, wikitext, "", "", "");
                
                logger.Info("Complete upload to Wiki");
            }
            catch (Exception ex)
            {
                logger.Error("Error in UploadFile: " + ex.Message + Environment.NewLine + "fileToUpload: " + fileToUpload + ex.GetBaseException());
            }
            
            return true;
        }

        public static string GetLicenseTemplate(FlickrNet.LicenseType licenseType)
        {
            switch (licenseType)
            {
                case FlickrNet.LicenseType.AttributionCC:
                    {
                        return "{{cc-by-2.0}}";
                    }
                case FlickrNet.LicenseType.AttributionShareAlikeCC:
                    {
                        return "{{cc-by-sa-2.0}}";
                    }
                case FlickrNet.LicenseType.UnitedStatesGovernmentWork:
                    {
                        return "{{PD-USGov}}";
                    }
                case FlickrNet.LicenseType.NoKnownCopyrightRestrictions:
                    {
                        return "{{Flickr-no known copyright restrictions}}";
                    }
                default:
                    {
                        logger.Error("GetLicenseTemplate - Unknown copyright: " + licenseType);
                        return "Unknown copyright";
                    }
            }
        }
    }

}
