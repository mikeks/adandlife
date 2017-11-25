<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="admin.Master" CodeBehind="Money.aspx.cs" Inherits="AdAndLifeWebsite.Admin.MoneyPage" %>
<%@ Import Namespace="AdAndLifeWebsite.Models.Tickets" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
	<style>
		table {
		    border: solid 1px;
			border-collapse: collapse;
		}
		table td, table th {
		    border: solid 1px;
			padding: 5px;
		}
		.tx {
			font-size: 12px;
		}
		.tot {
			padding: 15px;
			padding-left: 0;
			font-size: 18px;
			color: blue;
			font-weight: bold;
		}
	</style>


	<h1>Финансы</h1>

	<h2>Баланс Keskinov, LLC</h2>
	<div class="tot">
		Сумма за услуги: $<%= totalMike.ToString("0.00") %><br />
		Уже получено: $<%= totalChecks.ToString("0.00") %><br />
		<div style="font-size:32px;color:blue">Баланс: $<%= balanceMike.ToString("0.00") %></div>
	</div>

	<h2>Полученные Keskinov, LLC</h2>

	<table>
		<tr>
			<th>Дата</th>
			<th>Сумма</th>
			<th>Операции</th>
		</tr>
		<asp:Repeater ID="RepeaterMikeMoney" runat="server">
			<ItemTemplate>
				<tr>
					<td><%# Eval("Created") %></td>
					<td><%# Eval("Amount", "${0:#}") %></td>
					<td><a href="?delPayment=<%# Eval("Id") %>">удалить платеж</a></td>
				</tr>
			</ItemTemplate>
		</asp:Repeater>
	</table>

	<div style="margin-bottom:20px">
		<h3>Добавить платеж</h3>
		Дата получения: <asp:TextBox runat="server" TextMode="Date" ID="txDate" /><br /><br />
		Сумма ($): <asp:TextBox runat="server" TextMode="Number" ID="txMoney" /><br /><br />
		<asp:Button Text="Добавить платеж" runat="server" ID="AddPayment" />
	</div>

    <h2>Classified</h2>
    <div>

		<table>
			<tr>
				<th>Объявление</th>
				<th>Цена (за сайт)</th>
				<th>Объявление создано</th>
				<th>Окончание promotion</th>
			</tr>
			<asp:Repeater ID="RepeaterClassifedMoney" runat="server">
				<ItemTemplate>
					<tr>
						<td class="tx"><%# Eval("Text") %></td>
						<td><%# Eval("Price", "${0:#}") %></td>
						<td><%# ((DateTime)Eval("Created")).ToShortDateString() %></td>
						<td><%# ((DateTime)Eval("PromotionExpirationDate")).ToShortDateString() %></td>
					</tr>
				</ItemTemplate>
			</asp:Repeater>
		</table>

		<div class="tot">
			Всего за классифайд: $<%= classifiedTotalPrice.ToString("0.00") %><br />
			To Keskinov, LLC (45%): $<%= classifiedMike.ToString("0.00") %>
		</div>
    </div>

	<h2>Билеты</h2>

		<table>
			<tr>
				<th>Концерт</th>
				<th>Дата концерта</th>
				<th>Билетов продано</th>
				<th>Полученная сумма</th>
				<th>Наша доля</th>
			</tr>
			<asp:Repeater ID="RepeaterTickets" runat="server">
				<ItemTemplate>
					<tr>
						<td><%# Eval("EventName") %></td>
						<td><%# Eval("EventDate") %></td>
						<td><%# ((IEnumerable<Ticket>)Eval("SoldTickets")).Count() %></td>
						<td><%# Eval("TotalSoldAmount", "${0:0.00}") %></td>
						<td><%# Eval("OurShareUSD", "${0:0.00}") %> (<%# Eval("OurShare") %>%)</td>
					</tr>
				</ItemTemplate>
			</asp:Repeater>
		</table>

		<div class="tot">
			Всего получено за билеты: $<%= ticketsTotalPrice.ToString("0.00") %><br />
			Наша доля за билеты: $<%= ticketsOurShare.ToString("0.00") %><br />
			To Keskinov, LLC: $<%= ticketsMike.ToString("0.00") %>
		</div>

	<h2>Баннеры</h2>

		<table>
			<tr>
				<th>Название баннера</th>
				<th>Дата создания</th>
				<th>Дата снятия</th>
				<th>Полученная сумма</th>
			</tr>
			<asp:Repeater ID="RepeaterBanners" runat="server">
				<ItemTemplate>
					<tr>
						<td><%# Eval("Name") %></td>
						<td><%# Eval("Created") %></td>
						<td><%# Eval("EndDate") %></td>
						<td><%# Eval("Price") %></td>
					</tr>
				</ItemTemplate>
			</asp:Repeater>
		</table>

		<div class="tot">
			Всего за баннеры: $<%= bannersTotalPrice.ToString("0.00") %><br />
			To Keskinov, LLC (45%): $<%= bannersMike.ToString("0.00") %>
		</div>




</asp:Content>

