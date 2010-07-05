using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using log4net;
using DotNetWikiBot;

/*
namespace Video_to_Wikipedia.Models
{
    public class WikiUploader
    {
        private static ILog logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string PATH = AppDomain.CurrentDomain.BaseDirectory;
        private static string filepath;
        
        public bool UploadFile(VideoInfo videoInfo, string filepath)
        {
            //filepath = PATH + "image321abc4.jpg";
            //filepath = PATH + "testimage-w3s.jpg";
            //string siteurl = @"http://en.wikipedia.org";
            //string siteurl = "http://commons.wikimedia.org";
            //string siteurl = "http://vgsales.wikia.com";
            string siteurl = "http://w3stfa11.limewebs.com/wiki/index.php?title=Main_Page";
            Site wikiSite = new Site(siteurl, "abc", "123");
            Page page = new Page(wikiSite);

            string fileNamespace = "6";
            string fileName = Path.GetFileName(filepath);
            page.title = wikiSite.namespaces[fileNamespace] + ":" + fileName;



            try
            {
                page.Load();
            }
            catch(Exception ex)
            {
                return false;
            }

            if (page.Exists())
            {
                return false;
            }

            try
            {
                logger.Info("Uploading to Wiki");
                page.UploadImage(filepath, "mydesc", "license", "copystatus", "sourceurl");
            }
            catch (Exception ex)
            {
                logger.Error("Error in UploadFile: " + ex.Message + Environment.NewLine + "filename: " + fileName);
            }
            logger.Info("Complete upload to Wiki");
            return true;
        }
    }
}*/