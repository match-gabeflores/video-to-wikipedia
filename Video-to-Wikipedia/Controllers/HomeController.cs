using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web.Mvc;
using Video_to_Wikipedia.Models;
using Video_to_Wikipedia.Abstract;
using log4net;

//todo refactor refactor refactor
//todo  move magic strings to resources (create resource class if necesssary
//todo  move stuff out to helper methods

namespace Video_to_Wikipedia.Controllers
{

    [HandleError]
    public class HomeController : Controller
    {

        //private ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));
        private IVideoService videoService;
        private VideoInfo videoInfo;
        public ViewResult Index()
        {
            ViewData["key"] = Server.MapPath(".\\") + "ffmpeg2theora.exe" + "\r\n<br\\>";
            string url = @"http://www.flickr.com/photos/iriya/4524606136/";

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
            
            ffmpegProcess();

            return View();
        }

        private void ffmpegProcess()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            // path.. = "C:\\Users\\w3stfa11\\Documents\\Visual Studio 2010\\Projects\\video-to-wikipedia.git\\Video-to-Wikipedia\\"
            string serverpath1 = Server.MapPath(".");
            string serverpath = Server.MapPath("..\\");
            string ffmpegLocation = serverpath + "ffmpeg2theora.exe";
            processStartInfo.FileName = ffmpegLocation;
            

            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.Arguments = "\"" + serverpath + "video.mp4" + "\"";
            
            Process conversionProcess = Process.Start(processStartInfo);
            

            StreamReader sr;
            if (conversionProcess != null)
            {
                sr = conversionProcess.StandardOutput;
                FileInfo info = new FileInfo( serverpath + "output.txt");

                StreamWriter tw = info.CreateText();
                tw.WriteLine(sr.ReadToEnd());
                tw.Close();
            }
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
