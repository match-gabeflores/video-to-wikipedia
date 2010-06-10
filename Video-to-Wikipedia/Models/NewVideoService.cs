using System;
using Video_to_Wikipedia.Abstract;

namespace Video_to_Wikipedia.Models
{
    public class NewVideoService :IVideoService
    {
        private static string ExtractIdFromUrl(string url)
        {
            throw new NotImplementedException();
        }

        public string GetVideoDownloadUrl(string url)
        {
            throw new NotImplementedException();
        }

        public string PhotoId
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }

}
