<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="readLog.aspx.cs" Inherits="AdAndLifeWebsite.Listener.readLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="margin-bottom:30px">
		<%= Application["AalLog"] %>
    </div>
	<form action="hook5763.ashx" method="post">
		<input type="text" name="testName" value="testValue" />
		<input type="text" name="testName2" value="testValue2" />
		<input type="submit" />
	</form>
</body>
</html>
