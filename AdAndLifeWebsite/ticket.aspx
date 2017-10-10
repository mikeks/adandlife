<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="ticket.aspx.cs" Inherits="AdAndLifeWebsite.TicketPage" %>

<%@ Import Namespace="AdAndLifeWebsite.Classes" %>
<%@ Register Src="~/Controls/HallMap.ascx" TagPrefix="uc1" TagName="HallMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
	<script src="/js/tickets.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentAreaNoForm" runat="server">
	<script>
		var handlingFee = <%= Sale.HandlingFee %>;
		var eventId = <%= Sale.Id %>;
		var avaliableTickets = [<% 
		var f = true;
		foreach (var t in Sale.Tickets)
		{
			if (!f) Response.Write(",");
			Response.Write("{seat:\"" + t.Seat + "\",pr:\"" + t.Price + "\"}");
			f = false;
		}
		%>]
	</script>

	<h1>
		<%=Sale.EventName %>
	</h1>

	<div id="step0">
		<img src="/ArticleImages/events/<%= Sale.EventImage %>" class="event-image" alt="<%= Sale.EventName %>" />
		<div class="event-description">
			Дата/время: <%= Sale.EventDate %><br />
			Место проведения: <%= Sale.EventLocation %><br />
			Адрес: <%= Sale.EventAddress %><br />
			<br />
			<%= Sale.EventDescription %>
			<div style="margin-top:18px">
				<a class="button" href='#' onclick="buyStep1()">Купить билеты</a>
			</div>
		</div>
	</div>

	<div id="step1" style="display:none">
		<div class="ticket-price-box">
			Выберите места на карте зала.
		</div>
		<uc1:HallMap runat="server" ID="HallMap" />
		<div id="ticketInfoBox" class="ticket-price-box">
		</div>
	</div>

	<div id="step2" style="display:none">
		<div class="ticket-step2note">
			<span id="ticketInfoShort"></span> (<a href="#" onclick="buyStep1()">выбрать другие билеты</a>)
		</div>
		<form method="post" id="buyForm" action="/ticketBuyRequest.aspx">
			<input type="hidden" name="eventId" value="<%= Sale.Id %>"/>
			<input type="hidden" name="seats" id="hSeats" value=""/>
			<div class="error" id="ticketFormError"></div>
			<table class="ticket-uinfo-table">
				<tr>
					<td>
						<div class="buy-form-label">Ваше имя:</div>
					</td>
					<td>
						<input class="ticket-buy-input" type="text" maxlength="100" id="buyerName" name="buyerName" value=""/>
					</td>
				</tr>
				<tr>
					<td>
						<div class="buy-form-label">Email:</div>
					</td>
					<td>
						<input class="ticket-buy-input" type="text" maxlength="250" id="buyerEmail" name="buyerEmail" value=""/>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<div class="note">На этот e-mail будет выслан Ваш электронный билет</div>
					</td>
				</tr>
			</table>
			<div style="margin-top: 10px">
				<div class="buy-form-label">Условия продажи билетов</div>
				<textarea class="ticket-agreement" readonly="readonly">Купленные билеты возврату не подлежат.
После оплаты мы рекомендуем распечатать электронный билет. 
Изображение электронного билета в читаемом качестве должно быть предоставлено перед входом на мероприятие. В противном случае вход на мероприятие невозможен.</textarea>
			</div>
			<input type="checkbox" id="cbAgreed" /><label for="cbAgreed">Я согласен с этими условиями.</label>
			<div style="margin-top:18px">
				<a class="button" href='#' onclick="submitForm()">Далее</a>
			</div>
		</form>
	</div>



</asp:Content>


