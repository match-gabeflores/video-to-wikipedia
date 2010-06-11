<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Video_to_Wikipedia.Models.VideoInfo>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="content">
    <p id="description">
    Change or remove any of the fields. Don't forget to add categories to the video.
    </p>
    <p class="input-item">
    <%= Html.Label("Source URL") %>
    <%= Html.TextBox("url", Model.SourceUrl)  %>
    </p>

    <p class="input-item">
    <%= Html.Label("Filename") %>
    <%= Html.TextBox("Filename", Model.Filename)  %>
    </p>

    <p class="input-item">
    <%= Html.Label("Description")%>
    <%= Html.TextBox("Description", Model.Description)  %>
    </p>
    
    <p class="input-item">
    <%= Html.Label("License")%>
    <%= Html.TextBox("License", Model.License)  %>
    </p>

    <p class="input-item">
    <%= Html.Label("Categories")%>
    <%= Html.TextBox("Categories", Model.Categories)  %>
    </p>
    </div>
</body>
</html>
