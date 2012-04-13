<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StandardHtmlUpload.aspx.cs" Inherits="TestUploadApplication.StandardHtmlUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" enctype="multipart/form-data" method="post">
    <div>
        <input id="File1" type="file" name="foo" />
        <input type="submit" value="Click to upload" />
    </div>
    </form>
</body>
</html>
