using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using log4net;

namespace Video_to_Wikipedia.Models
{
    public class WikiUploader
    {
        private static ILog logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public bool UploadFile(string filepath)
        {

            return true;
        }
    }
}