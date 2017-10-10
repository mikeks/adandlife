<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkTicket.aspx.cs" Inherits="AdAndLifeWebsite.checkTicket" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Check ticket online service - Ad and Life</title>
</head>
<body>
	<h1 style="color:<%= Color %>"><%= Conclusion %></h1>
	<div>
		<%= ErrorMessage %>
	</div>
	<div>
		<%= Descr %>
	</div>
</body>
</html>
