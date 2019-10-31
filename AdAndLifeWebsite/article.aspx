<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="article.aspx.cs" Inherits="AdAndLifeWebsite.ArticlePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
    <div id="fb-root"></div>
    <script>(function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.9&appId=1519165781479119";
        fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
    </script>

	<div class="top-nav art">
		<div class="dropdown-menu font-size">
			<div class="dropdown-menu-title">
				<span class="font-t1">A</span><span class="font-t2">A</span><i class="arrow-down"></i>
			</div>
			<div class="dropdown-list font-change">
				<a class="font-a1" data-size="16" href="#">А</a>
				<a class="font-a2" data-size="18" href="#">А</a>
				<a class="font-a3" data-size="20" href="#">А</a>
			</div>
		</div>
	</div>


	<div class="breadcrumps">
		<a href="/">Статьи</a> &gt; <a href="/?rubric=<%= Article.Rubric.Id %>"><%= Article.Rubric.Name %></a>
	</div>


	<section class="article">
		<% Response.Write(Article.Txt); %>
	</section>

	<button onclick="shareFb(location.href);return false">Share on Facebook</button>

    <h2>Ваши комментарии</h2>
    <div class="fb-comments" data-href="<%= CanonicalUrl  %>" data-numposts="5"></div>

</asp:Content>


