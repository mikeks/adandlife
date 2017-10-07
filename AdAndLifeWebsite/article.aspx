<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="articles.aspx.cs" Inherits="AdAndLifeWebsite.ArticlePage" %>

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

		<h1>
			<%=Article.Name %>
		</h1>
		<section>
			<% Response.Write(Article.Txt); %>
		</section>

        <h2>Ваши комментарии</h2>
        <div class="fb-comments" data-href="<%= CanonicalUrl  %>" data-numposts="5"></div>

</asp:Content>


