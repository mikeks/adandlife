<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="articles.aspx.cs" Inherits="AdAndLifeWebsite.ArticlesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
    <h1>Статьи</h1>
    <ul class="article-list"> 
        <asp:Repeater runat="server" ID="ARep">
            <ItemTemplate>
                <li>
                    <section>
                        <h1><a href="/article.aspx?id=<%# Eval("Id") %>"><%# Eval("Name") %></a></h1>

                    </section>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

</asp:Content>
