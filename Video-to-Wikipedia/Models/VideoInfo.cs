using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlickrNet;

namespace Video_to_Wikipedia.Models
{
    public class VideoInfo
    {
        public string VideoId { get; set; }
        public string SourceUrl { get; set; }
        public string DownloadUrl { get; set; }
        public LicenseType License { get; set; }
        public string Filename { get; set; }
        //public List<string> Categories { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}