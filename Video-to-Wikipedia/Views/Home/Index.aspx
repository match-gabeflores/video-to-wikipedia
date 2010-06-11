<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" Trace="true"   %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Content/Site.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <div class="page">

        <div id="header">
            <div id="title">
                <h1>My MVC Application</h1>
                <%= ViewData["key"] %>
            </div>
               
            <div>
            <span>Please enter the url for the video:</span><br />
            <form method="post" action="<%= Url.Action("Submit", "Home") %>">
            <p class="input-item">
            <input id="url" name="videoUrl" type="text" size="40"/>
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
