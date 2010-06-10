using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Video_to_Wikipedia.Abstract;

namespace Video_to_Wikipedia.Models
{
    public class VideoServiceFactory 
    {
        public static IVideoService GetVideoService(string url)
        {
            //Get top-level domain
            string serviceUrl = null;
            serviceUrl = Regex.Match(url, "https?:[/]+([^/]+)[/]").Value;

            if (serviceUrl.Contains("flickr"))
            {
                return new FlickrService();
            }

            return null;
        }

        
    }

}
