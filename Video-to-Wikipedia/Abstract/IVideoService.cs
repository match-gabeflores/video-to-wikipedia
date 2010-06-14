using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Video_to_Wikipedia.Models;

namespace Video_to_Wikipedia.Abstract
{
    public interface IVideoService
    {
        VideoInfo GetVideoInfo(string url);
    }
}
