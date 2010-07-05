using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FlickrNet;
using log4net;
using Video_to_Wikipedia.Abstract;
using Video_to_Wikipedia.Controllers;
using Video_to_Wikipedia.Helpers;
using License = FlickrNet.License;

namespace Video_to_Wikipedia.Models
{
    public class FlickrService : IVideoService
    {
        Flickr flickr = new Flickr(Configuration.FlickrKey, Configuration.FlickrSecret);
        private ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));
        private VideoInfo videoInfo;

        public VideoInfo GetVideoInfo(string url)
        {
            
            videoInfo = new VideoInfo();
            videoInfo.SourceUrl = url;
            videoInfo.VideoId = ExtractIdFromUrl(url);
            logger.Info("Getting video info for: " + videoInfo.VideoId + "--" + url);
            if (!String.IsNullOrEmpty(videoInfo.VideoId))
            {
                //PhotoInfo photosGetInfo;
                try
                {
                    //img with location
                    //photosGetInfo = flickr.PhotosGetInfo("233508614", Configuration.FlickrSecret);
                    // regular img 4521474634
                    //photosGetInfo = flickr.PhotosGetInfo("4521474634", Configuration.FlickrSecret);
                    //photosGetInfo = flickr.PhotosGetInfo(videoInfo.VideoId, Configuration.FlickrSecret);
                    var photosGetInfo = flickr.PhotosGetInfo(videoInfo.VideoId, Configuration.FlickrSecret);
                    videoInfo.Author = photosGetInfo.OwnerUserName;
                    videoInfo.Author += String.IsNullOrEmpty(photosGetInfo.OwnerRealName)
                                             ? ""
                                             : " (" + photosGetInfo.OwnerRealName + ")";
                    videoInfo.Description = photosGetInfo.Description;
                    videoInfo.Title = photosGetInfo.Title;
                    videoInfo.Filename = photosGetInfo.Title + ".ogv";
                    char[] BAD_CHARS = new char[] { '!', '@', '#', '$', '%', '_', '"' }; //simple example
                    videoInfo.Filename =
                        string.Concat(videoInfo.Filename.Split(BAD_CHARS, StringSplitOptions.RemoveEmptyEntries));
                    videoInfo.Filename = Regex.Replace(videoInfo.Filename, "[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]", String.Empty);
                    videoInfo.License = photosGetInfo.License;
                    videoInfo.DownloadUrl = GetDownloadUrl(videoInfo.VideoId);
                    videoInfo.Date = photosGetInfo.DateTaken;
                    // videoInfo.Categories = new List<string>() { "cat1", "cat2" };
                    if (photosGetInfo.Location != null)
                    {
                        videoInfo.Latitude = photosGetInfo.Location.Latitude;
                        videoInfo.Longitude = photosGetInfo.Location.Longitude;
                    }
                }
                catch (Exception e)
                {
                    logger.Error("Error in FlickrService: " + e.Message + Environment.NewLine + videoInfo.SourceUrl);
                    throw;
                }
            }

            return videoInfo;
        }

        private string ExtractIdFromUrl(string url)
        {
            string videoId = String.Empty;

            if (url.Contains("flickr.com"))
            {
                try
                {
                    videoId = Regex.Match(url, "[/]([\\d]+)[/]").Groups[1].Value;
                }
                catch (ArgumentException ex)
                {
                    // Syntax error in the regular expression
                    throw new Exception();
                }
                catch (Exception e)
                {
                    logger.Error("could not capture videoId");
                    throw;
                }
            }
            else
            {
                // only given the id
                videoId = url;
            }

            return videoId;
        }

        private string GetDownloadUrl(string videoId)
        {
            SizeCollection sc = flickr.PhotosGetSizes(videoId);

            if (sc[sc.Count - 1].Label.Contains("HD"))
                return sc[sc.Count-1].Source;

            int maxIndex = 0;
            int maxValue = 0;
            int currentIndex = 0;
            foreach (Size size in sc)
            {
                if (size.MediaType == MediaType.Videos && size.Label != "Video Player")
                {
                    if (size.Width > maxValue)
                    {
                        maxValue = size.Width;
                        maxIndex = currentIndex;
                    }
                    
                }
                else
                    currentIndex++;
            }
            logger.Info("Getting download url: " + sc[maxIndex].Source);
            return sc[maxIndex].Source;
        }
    }



}
