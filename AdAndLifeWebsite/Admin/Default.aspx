<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="admin.Master" Inherits="AdAndLifeWebsite.Admin.Default" %>
<%@ Import Namespace="AdAndLifeWebsite.Models" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
    <style>
        ul li {
            margin-top: 20px;
            font-size: 20px;
        }
    </style>
    <h1>Админка РИЖ</h1>
    <ul>

		<%if (SiteUser.CheckAccess("edit")) { %>
        <li>
            <a href="/archive.aspx">Выпуски газет</a>
        </li>
        <li>
            <a href="ArticleList.aspx">Статьи</a>
        </li>
		<% } %>
		<%if (SiteUser.CheckAccess("tickets")) { %>
        <li>
            <a href="Tickets.aspx">Билеты</a>
        </li>
		<% } %>
		<%if (SiteUser.CheckAccess("banners")) { %>
        <li>
            <a href="Banners.aspx">Баннеры</a>
        </li>
		<% } %>
		<%if (SiteUser.CheckAccess("money")) { %>
        <li>
            <a href="Money.aspx">Финансы</a>
        </li>
		<% } %>
    </ul>

</asp:Content>
