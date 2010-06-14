using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Video_to_Wikipedia.Models;
using Video_to_Wikipedia.Abstract;
using log4net;

//todo refactor refactor refactor
//todo  move magic strings to resources (create resource class if necesssary
//todo  move stuff out to helper methods
//todo start downloading video as they fill out details

namespace Video_to_Wikipedia.Controllers
{

    [HandleError]
    public class HomeController : Controller
    {

        private ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));
        private IVideoService videoService;
        private VideoInfo videoInfo;
        private readonly string PATH = System.Web.HttpContext.Current.Server.MapPath(".\\");

        public ViewResult Index()
        {
            ViewData["key"] = Server.MapPath(".\\") + "ffmpeg2theora.exe" + "\r\n<br\\>";
            
            
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
            
            return View("VideoForm", videoInfo);
        }

        public ViewResult ProcessVideo()
        {
            // start downloading video as they fill out information details
            // VideoDownloader.ProcessVideo(videoInfo.DownloadUrl);
            VideoDownloader.ProcessVideo(@"http://www.flickr.com/photos/iriya/4524606136/play/site/271ab481a7/");
            return View();
        }

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
