<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="admin.Master" CodeBehind="ArticleList.aspx.cs" Inherits="AdAndLifeWebsite.Admin.ArticleList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
    <h1>Статьи</h1>
    <div>
        <a href="EditArticle.aspx">Добавить новую статью</a><br />
		<ul>
			<asp:Repeater runat="server" ID="ArticlesRepeater">
				<ItemTemplate>
					<li class="art-list">
                        <span class="art-name"><%# Eval("Name") %></span>
						<a href="EditArticle.aspx?id=<%# Eval("Id") %>">Редактировать</a> |
                        <a target="_blank" href="/article.aspx?id=<%# Eval("Id") %>">Открыть на сайте</a> |
						<a style="color:red" onclick="return confirm('Удалить статью?');" href="ArticleList.aspx?del=<%# Eval("Id") %>">Удалить</a> 
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>    
    </div>

</asp:Content>

