<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdAndLifeWebsite.DefaultPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

	<div class="rubric-menu">
		<div class="rubric-menu-title">
			<%= RubricMenuTitle %> <i class="arrow-down"></i>
		</div>
		<div class="rubric-list">
			<% if (Rubric != null)	{ %>
				<a href="/">Все рубрики</a>
  			    <hr />
			<% } %>
			<%foreach (var r in Rubrics) { %>
				<a href="?rubric=<%= r.Id %>"><%= r.Name %></a>
			<% } %>
		</div>
	</div>


	<h1 class="main"><span>Реклама и Жизнь - </span> <%= HeaderTitle %></h1>

	
    <ul class="article-list"> 
		<%
			var i = 0;
			foreach (var art in Articles) { %>

                <li>
					<div class="article-cat">
						<a href="?rubricId=<%= art.Rubric.Id %>"><%= art.Rubric %></a> 
						<%= art.ArticleInfo %>
					</div>
					<a class="article-link" href="/article.aspx?id=<%= art.Id %>">
						<%= art.Name %>
						<div class="art-summary">
							<%= art.SummaryText %> 
						</div>
					</a>
                </li> 
				
			<%
				if (Ads.Count > 0 && i++ % 2 == 0)
				{
					var ad = Ads[0];
					Ads.RemoveAt(0);
					%>

					<li class="classified-hp">
						<div class="class-hp-cat">
							<a href="/classified.aspx?rubric=<%= ad.Rubric.Id %>"><%= ad.Rubric %></a> 
						</div>
						<%= ad.Text %>
					</li>
			<% } %>

		<% } %>

    </ul>

	<% if (TotalPages > 1)	{ %>
	<div class="pager">
		<span>Страницы: </span>
		<% for (var p = 1; p < TotalPages; p++) { %>
			<a href="<%= GetPageLink(p) %>" <%= p == PageNumber ? "class='current'" : "" %>><%= p %></a>
		<% } %>
	</div>
	<% } %>

</asp:Content>
