<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="admin.Master" Inherits="AdAndLifeWebsite.Admin.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
    <style>
        ul li {
            margin-top: 20px;
            font-size: 20px;
        }
    </style>
    <h1>Админка РИЖ</h1>
    <ul>

        <li>
            <a href="/archive.aspx">Выпуски газет</a>
        </li>
        <li>
            <a href="ArticleList.aspx">Статьи</a>
        </li>
        <li>
            <a href="Tickets.aspx">Билеты</a>
        </li>

    </ul>

</asp:Content>
