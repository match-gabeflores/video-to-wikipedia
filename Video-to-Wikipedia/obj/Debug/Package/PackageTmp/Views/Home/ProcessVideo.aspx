<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Video_to_Wikipedia.Models.VideoInfo>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<div id="content">

<h1>Video will be downloaded and uploaded to Wikipedia.</h1>
<br />

<p>It will be uploaded to <a href="<%= "http://commons.wikimedia.org/wiki/File:" + Model.Filename %>">File:<%=  Model.Filename  %></a> in a few minutes.</p>

<p><a href="<%= Model.SourceUrl %>">Leave a comment</a> thanking the author on the video page while you wait.</p>

</div>
    
</body>
</html>
