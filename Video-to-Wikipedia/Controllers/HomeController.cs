using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Video_to_Wikipedia.Helpers;
using Video_to_Wikipedia.Properties;
using FlickrNet;
using log4net;
using log4net.Config;
using Video_to_Wikipedia.Models;
using Video_to_Wikipedia.Abstract;

//todo refactor refactor refactor
//todo  move magic strings to resources (create resource class if necesssary
//todo  move stuff out to helper methods

namespace Video_to_Wikipedia.Controllers
{

    [HandleError]
    public class HomeController : Controller
    {
       
        private IVideoService videoService;
        public ViewResult Index()
        {
            ViewData["key"] = Server.MapPath(".\\") + "ffmpeg2theora.exe" + "\r\n<br\\>";
            string url = @"http://www.flickr.com/photos/iriya/4524606136/";

            videoService = VideoServiceFactory.GetVideoService(url);
            videoService.GetVideoDownloadUrl(url);
            
            return View();
        }

        public RedirectToRouteResult Submit(string url)
        {
            //GetMetadata
            
            //return View("VideoForm", videoInfo);
            return RedirectToAction("VideoForm");
        }
        public ViewResult VideoForm()
        {
            VideoInfo videoInfo = new VideoInfo();

            return View("VideoForm", videoInfo);
        }

        private void ffmpegProcess()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();

            string ffmpegLocation = Server.MapPath(".\\video-to-wikipedia\\") + "ffmpeg2theora.exe";
            processStartInfo.FileName = ffmpegLocation;
            

            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            Process conversionProcess = Process.Start(processStartInfo);

            StreamReader sr;
            if (conversionProcess != null)
            {
                sr = conversionProcess.StandardOutput;
                FileInfo info = new FileInfo(Server.MapPath(".\\") + "newtext.txt");

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
