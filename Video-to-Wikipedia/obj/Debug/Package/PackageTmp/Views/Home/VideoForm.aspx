<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Video_to_Wikipedia.Models.VideoInfo>" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="content">
    <h2 style="color:red; font-weight:bold">This file is copyrighted! Unable to upload.</h2>
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
            <%= Html.TextArea("Description", Model.Description, new {rows = 4 })  %>
        </p>
        <p class="input-item">
            <%= Html.Label("Author")%>
            <%= Html.TextBox("Author", Model.Author, new { @readonly = "true" })%>
        </p>
        <p class="input-item">
            <%= Html.Label("Date")%>
            <%= Html.TextBox("Date", Model.Date, new { @readonly = "true" })%>
        </p>
        <p class="input-item">
            <%= Html.Label("License")%>
            <%= Html.TextBox("License",  Model.License, new { @readonly="true"})  %>
        </p>

        <hr />

        <h3>Converter (ffmpeg2theora) options</h3>
        <p>
        <%= Html.Label("Remove Sound")%>
        <%= Html.CheckBox("RemoveSound") %>
        </p>
        <!-- not implemented yet
        <p class="input-item">
        Categories
        </p>
 -->
        <%= Html.HiddenFor(x => x.Title) %>
        <%= Html.HiddenFor(x => x.DownloadUrl) %>
        <%= Html.HiddenFor(x => x.VideoId) %>
        <%= Html.HiddenFor(x => x.SourceUrl) %>
        <%= Html.HiddenFor(x => x.Longitude) %>
        <%= Html.HiddenFor(x => x.Latitude) %>
        <% if (!(bool)ViewData["copyrighted"])
           {%>
        <input type="submit" value="Process video and upload to Wikipedia" />
        <%
           }%>
        </form>
    </div>
</body>
</html>
