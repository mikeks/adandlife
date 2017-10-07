<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="tickets.aspx.cs" Inherits="AdAndLifeWebsite.TicketsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

    <h1>Купить билеты</h1>
    <ul class="article-list">
        <asp:Repeater runat="server" ID="EventsRepeater">
            <ItemTemplate>
                <li>
                    <section>
                        <h1><a href="/ticket/<%# Eval("UrlName") %>"><%# Eval("EventName") %></a></h1>
                    </section>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

</asp:Content>
