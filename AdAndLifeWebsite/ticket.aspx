<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="ticket.aspx.cs" Inherits="AdAndLifeWebsite.TicketPage" %>

<%@ Import Namespace="AdAndLifeWebsite.Classes" %>
<%@ Register Src="~/Controls/HallMaps/HallMapKleinLife.ascx" TagPrefix="uc1" TagName="HallMapKleinLife" %>
<%@ Register Src="~/Controls/HallMaps/HallMapArchWood.ascx" TagPrefix="uc1" TagName="HallMapArchWood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
  <meta property="og:type"   content="product" /> 
  <meta property="og:url"    content="http://adandlife.com/ticket/<%= Sale.UrlName %>" /> 
  <meta property="og:title"  content="<%= Sale.EventName %>" /> 
  <meta property="og:image"  content="http://adandlife.com/ArticleImages/events/<%= Sale.EventImage %>" /> 

	<script src="/js/tickets.js"></script>
    <script>
		var ww = window.innerWidth || document.documentElement.clientWidth;
		function openPopup(u) { if (ww < 760) location = u; else open(u, '_blank', 'width=600,height=400,resizable=1,top=' + Math.max(0, screen.height / 2 - 300) + ',left=' + Math.max(0, screen.width / 2 - 200)) }
		function shareFb(s) { openPopup('https://www.facebook.com/sharer/sharer.php?u=' + encodeURIComponent(s)) }
    </script>
	<style>
		.coontent-area {
			max-width: 10000px!important;
		}
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentAreaNoForm" runat="server">
	<script>
		var handlingFee = <%= Sale.HandlingFee %>;
		var eventId = <%= Sale.Id %>;
		var avaliableTickets = [<% 
		var f = true;
		foreach (var t in Sale.AvaliableTickets)
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

	<div id="step0" <%= StartStep1 ? "style='display:none'" : "" %>>
		<img src="/ArticleImages/events/<%= Sale.EventImage %>" class="event-image" alt="<%= Sale.EventName %>" />
		<div class="event-description">
			<%= Sale.EventDescription %>

			<div style="margin-top: 15px">
				<strong>Мероприятие состоится:</strong> <%= Sale.EventDate %><br />
				<strong>Место проведения:</strong> <%= Sale.Location.Name %><br />
				<strong>Адрес:</strong> <%= Sale.Location.Address %><br />
			</div>
		</div>
		<div style="margin-top:5px;width:100%">
			<a class="button" href='#' onclick="buyStep1();return false">Купить билеты</a>
			<a href="#" onclick="shareFb('http://adandlife.com/ticket/<%= Sale.UrlName %>');return false;">
				<img class="fb-share-button-img" src="/img/facebook-share-button.png" alt="Рассказать друзьям на Facebook" />
			</a>

		</div>
	</div>

	<div id="step1" <%= !StartStep1 ? "style='display:none'" : "" %>>
		<div class="ticket-price-box0">
			<strong>Выберите места на карте зала.</strong>
			<div class="note">Зеленым цветом обозначены доступные для покупки места. Спешите! Осталось билетов: <%= Sale.AvaliableTickets.Count() %> шт.</div>

		</div>
		<div id="ticketInfoBox" style="display:none" class="ticket-price-box">
		</div>
		<uc1:HallMapKleinLife runat="server" ID="hmKleinLife" />
		<uc1:HallMapArchWood runat="server" ID="hmArchWood" />
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
					<td>
						<div class="note">На этот e-mail будет выслан Ваш электронный билет</div>
					</td>
				</tr>
				<tr>
					<td>
						<div class="buy-form-label">Как вы о нас узнали:</div>
					</td>
					<td>
						<select class="ticket-buy-input" id="userRefferer" name="userRefferer">
							<option value="notSet">Выберите</option>
							<option value="facebook">Через Facebook</option>
							<option value="newspaper">Через газету "Реклама и Жизнь"</option>
							<option value="friends">От друзей</option>
							<option value="other">Другое</option>
						</select>
					</td>
				</tr>
			</table>
			<input type="checkbox" id="cbSubscribe" name="subscribe" checked="checked" /><label for="cbSubscribe">Получать уведомления о новых концертах на e-mail.</label>
			<div style="margin-top: 10px">
				<div class="buy-form-label">Условия продажи билетов</div>
				<textarea class="ticket-agreement" readonly="readonly">Купленные билеты возврату и обмену не подлежат. Исключением является только отмена мероприятия. В случае отмены мероприятия, возврат денег происходит в течение двух недель.
Мы рекомендуем распечатать электронный билет. Изображение электронного билета в читаемом качестве с четким штрих-кодом должно быть предоставлено перед входом на мероприятие. При отсутствии билета вход на мероприятие невозможен.</textarea>
			</div>
			<input type="checkbox" id="cbAgreed" /><label for="cbAgreed">Я согласен с этими условиями.</label>
			<div style="margin-top:18px">
				<a class="button" href='#' onclick="submitForm();return false">Перейти к оплате *</a>
				<div class="note" style="margin-top:5px">
				* - для оплаты кредитной картой выберите пункт <strong>"Pay with Debit or Credit Card"</strong>.
				</div>
			</div>
		</form>
	</div>



</asp:Content>


