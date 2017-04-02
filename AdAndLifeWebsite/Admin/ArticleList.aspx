<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="AdAndLifeWebsite.Admin.ArticleList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<ul>
			<asp:Repeater runat="server" ID="ArticlesRepeater">
				<ItemTemplate>
					<li>
						<a href="EditArticle.aspx?id=<%# Eval("Id") %>">
							<%# Eval("Name") %>
						</a>
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>    
    </div>
    </form>
</body>
</html>
