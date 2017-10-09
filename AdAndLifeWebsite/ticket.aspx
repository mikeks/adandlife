<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="ticket.aspx.cs" Inherits="AdAndLifeWebsite.TicketPage" %>

<%@ Import Namespace="AdAndLifeWebsite.Classes" %>
<%@ Register Src="~/Controls/HallMap.ascx" TagPrefix="uc1" TagName="HallMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
	<script src="/js/tickets.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentAreaNoForm" runat="server">

	<script>
		var eventId = <%= Sale.Id %>;
		var avaliableTickets = [<% 
		var f = true;
		foreach (var t in Sale.Tickets)   {
			if (!f) Response.Write(",");
			Response.Write("{seat:\"" + t.Seat + "\",pr:\"" + t.Price + "\"}");
			f = false;
		}
		%>]
	</script>

    <h1>
        <%=Sale.EventName %>
    </h1>
    <div class="event-description">
        <%= Sale.EventDescription %>
    </div>

	<div id="ticketInfoBox" class="ticket-price-box">
		Выберите места на карте зала.
	</div>


	<uc1:HallMap runat="server" id="HallMap" />








</asp:Content>


