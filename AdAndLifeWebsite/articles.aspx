<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="articles.aspx.cs" Inherits="AdAndLifeWebsite.ArticlesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

	<div class="rubric-menu">
		<div class="rubric-menu-title">
			<%= RubricMenuTitle %> <i class="arrow-down"></i>
		</div>
		<div class="rubric-list">
			<% if (Rubric != null)	{ %>
				<a href="/articles.aspx">Все рубрики</a>
  			    <hr />
			<% } %>
			<%foreach (var r in Rubrics) { %>
				<a href="?rubricId=<%= r.Id %>"><%= r.Name %></a>
			<% } %>
<%--			<hr />
			<a href="#">По номерам газет</a>--%>
		</div>
	</div>


	<h1 class="articles"><%= HeaderTitle %></h1>


<%--	<nav class="rubric-list">
		<ul>
			<asp:Repeater runat="server" ID="RepRubric">
				<ItemTemplate>
					<li <%# Rubric != null && (int)Eval("Id") == Rubric.Id ? "class='selected'" : "" %>><a href="/articles.aspx?rubricId=<%# Eval("Id") %>"><%# Eval("Name") %></a></li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
	</nav>--%>
	
	<%--<h1><%= Rubric == null ? "Статьи" : Rubric.Name %></h1>--%>
    <ul class="article-list"> 
        <asp:Repeater runat="server" ID="ARep">
            <ItemTemplate>
                <li>
					<div class="article-cat">
						<a href="?rubricId=<%# Eval("Rubric.Id") %>"><%# Eval("Rubric") %></a> 
						<%# Eval("ArticleInfo") %>
					</div>
					<a class="article-link" href="/article.aspx?id=<%# Eval("Id") %>">
						<%# Eval("Name") %>
						<div class="art-summary">
							<%# Eval("SummaryText") %> 
						</div>
					</a>

                </li> 
            </ItemTemplate>
        </asp:Repeater>
    </ul>

</asp:Content>
