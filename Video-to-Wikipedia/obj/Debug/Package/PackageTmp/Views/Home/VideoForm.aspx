<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Video_to_Wikipedia.Models.VideoInfo>" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">

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
    <form method="post" action="<%= Url.Action("ProcessVideo", "Home") %>">
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

        <input type="submit" value="Process video and upload to Wikipedia" />
    </form>
    </div>
</body>
</html>
