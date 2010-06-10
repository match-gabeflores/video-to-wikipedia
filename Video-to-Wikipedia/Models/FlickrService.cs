﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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

namespace Video_to_Wikipedia.Models
{
    public class FlickrService :IVideoService
    {

        private ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));
        private string PhotoId { get; set; }
        // acceptable formats
        // http://www.flickr.com/photos/42917230@N08/4076444545/
        // http://www.flickr.com/photos/username/417646359/
        // 417646359 (just the id)
        private static string ExtractIdFromUrl(string url)
        {
            string photoId = String.Empty;
            
            if (url.Contains("flickr.com"))
            {
                try
                {
                    photoId = Regex.Match(url, "[/]?([\\d]+)[/]?").Groups[1].Value;
                }
                catch (ArgumentException ex)
                {
                    // Syntax error in the regular expression
                    throw new Exception();
                }
            }
            else
            {
                // only given the id
                photoId = url;
            }

            return photoId;
        }

        public string GetVideoDownloadUrl(string url)
        {
            //photoInfo.LargeUrl = @"http://www.flickr.com/photos/42917230@N08/4076444545/sizes/l/";
            //string url2 = @"http://www.flickr.com/photos/42917230@N08/4076444545/";           
            // video - http://www.flickr.com/photos/iriya/4524606136/
            // g video 4685315975

            this.PhotoId = ExtractIdFromUrl(url);

            Flickr flickr = new Flickr(Configuration.FlickrKey, Configuration.FlickrSecret);
            SizeCollection sc = flickr.PhotosGetSizes(PhotoId);
            string str = sc[0].Url;

            var foo = sc.Where(s => s.MediaType == MediaType.Videos).Max(video => video.Width);

            int maxIndex = 0;
            int maxValue = 0;
            int currentIndex = 0;
            foreach (FlickrNet.Size size in sc)
            {
                if (size.Width > maxValue)
                    maxIndex = currentIndex;

                currentIndex++;
            }

            return sc[maxIndex].Source;
        }

       



        /**
        el Video Player
         * site mp4
         * mobile mp4
         * hd mp4
         *
HomeController [(null)] - source http://www.flickr.com/apps/video/stewart.swf?v=71377&photo_id=4524606136&photo_secret=271ab481a7
HomeController [(null)] - url http://www.flickr.com/photos/iriya/4524606136/
HomeController [(null)] - label Site MP4
HomeController [(null)] - source http://www.flickr.com/photos/iriya/4524606136/play/site/271ab481a7/
HomeController [(null)] - url http://www.flickr.com/photos/iriya/4524606136/
HomeController [(null)] - label Mobile MP4
HomeController [(null)] - source http://www.flickr.com/photos/iriya/4524606136/play/mobile/271ab481a7/
HomeController [(null)] - label HD MP4
HomeController [(null)] - url http://www.flickr.com/photos/iriya/4524606136/
HomeController [(null)] - source http://www.flickr.com/photos/iriya/4524606136/play/hd/271ab481a7/


        */

    }

    

}