using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlickrNet;
using Video_to_Wikipedia.Helpers;
using Video_to_Wikipedia.Models;
using Video_to_Wikipedia.Abstract;
using log4net;
using System.Web;
using VideoInfo = Video_to_Wikipedia.Models.VideoInfo;


namespace Video_to_Wikipedia.Controllers
{

    [HandleError]
    [ValidateInput(false)]
    public class HomeController : Controller
    {

        private ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));
        private IVideoService videoService;
        private VideoInfo videoInfo;
        private readonly string PATH = System.Web.HttpContext.Current.Server.MapPath(".\\");

        public ViewResult Index()
        {
            logger.Info(System.Web.HttpContext.Current.Server.MapPath("~"));
            return View();
        }

        public RedirectToRouteResult Submit(string videoUrl)
        {
            videoService = VideoServiceFactory.GetVideoService(videoUrl);
            videoInfo = videoService.GetVideoInfo(videoUrl);
            TempData["videoInfo"] = videoInfo;
            
            return RedirectToAction("VideoForm");
        }
        public ViewResult VideoForm()
        {
            videoInfo = (VideoInfo)TempData["videoInfo"];
            ViewData["copyrighted"] = false;
            if (VideoDownloader.GetLicenseTemplate(videoInfo.License).Contains("Unknown"))
                ViewData["copyrighted"] = true;
            ViewData["videoInfo"] = videoInfo;
            return View("VideoForm", videoInfo);
        }


        public ViewResult ProcessVideo(VideoInfo videoInfoInput, bool? RemoveSound)
        {
            videoInfo = videoInfoInput;
            //converterOptions object class?
            bool removeSound;
            if (RemoveSound == null)
                removeSound = false;
            else
                removeSound = RemoveSound.HasValue ? RemoveSound.Value : false;
            
            try
            {
                VideoDownloader.ProcessVideo(videoInfo, removeSound);
                // download video
                // convert video
                // upload video
            }
            catch (Exception ex)
            {   
                logger.Error("Process video exception: " + ex.Message + Environment.NewLine + videoInfo.SourceUrl);
                throw;
            }
            
            return View("ProcessVideo", videoInfo);
        }

        // helper function
        public IList<string> GetFilenamesFromPath(string filepath)
        {
            DirectoryInfo directory = new DirectoryInfo(filepath);
            FileInfo[] files = directory.GetFiles();
            IList<string> filenameStrings = new List<string>();
            foreach (FileInfo file in files)
            {
                filenameStrings.Add(file.Name);
            }

            return filenameStrings;
        }

        
    }

}
