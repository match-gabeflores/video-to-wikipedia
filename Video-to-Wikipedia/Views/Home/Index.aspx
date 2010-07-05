<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage"   %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Content/Site.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <div class="page">

        <div id="header">
            <div id="title">
                <h1>Video to Wikipedia</h1>
                <%= ViewData["key"] %>
            </div>
               
            <div>
            <span>Please enter the url for the video:</span><br />
            <form method="post" action="<%= Url.Action("Submit", "Home") %>">
            <p class="input-item">
            <input id="videoUrl" name="videoUrl" type="text" size="40"/>
            </p>
            <input id="submitUrl" type="submit" value="Next" />
            </form>
            </div>

            
        </div>
        <div id="main">
           

            <div id="footer">
            </div>
        </div>
    </div>
</body>
</html>
