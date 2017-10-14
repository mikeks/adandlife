<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="tickets.aspx.cs" Inherits="AdAndLifeWebsite.TicketsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

    <h1>Купить билеты</h1>
	<p>
		Сейчас в продаже есть билеты на следующие мероприятия:
	</p>
<%--				<%# Eval("EventName") %>
				<%# Eval("Location.Name") %>
				<%# ((DateTime)Eval("EventDate")).ToShortDateString() %>--%>
    <asp:Repeater runat="server" ID="EventsRepeater">
        <ItemTemplate>
			<div class="event-cont">
				<a href="/ticket/<%# Eval("UrlName") %>" class="event-big-image">
					<img src="/ArticleImages/events/<%# Eval("EventImage") %>" alt="<%# Eval("EventName") %>" /> 
				</a>
				<div class="event-btns">
					<a href="/ticket/<%# Eval("UrlName") %>?buy" class="button">Купить билет</a></span><a href="/ticket/<%# Eval("UrlName") %>" class="button">Подробнее</a>
				</div>
			</div>

        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
