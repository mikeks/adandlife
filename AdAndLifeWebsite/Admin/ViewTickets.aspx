<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" MasterPageFile="admin.Master" CodeBehind="ViewTickets.aspx.cs" Inherits="AdAndLifeWebsite.Admin.ViewTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
<style>
	table {
		border-collapse: collapse;
	}
	table td {
		border: solid 1px;
		padding: 6px;
	}
	table a {
		font-size: 12px;
		color: black;
	}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

    <h1>Транзакции для "<%= Sale.EventName %>"</h1>


	<table>
		<tr>
			<td>Покупатель</td>
			<td>Email</td>
			<td>Дата входа на сайт</td>
			<td>Дата покупки</td>
			<td>Дата проверки билета</td>
			<td>Как узнал о нас</td>
			<td>Подписался на новости</td>
			<td>Опции</td>
		</tr>

	<%foreach (var tr in Transactions)
		{ %>

		<tr>
			<td><%= tr.Name %></td>
			<td><%= tr.Email %></td>
			<td><%= tr.Created %></td>
			<td><%= tr.PurchaseDate %></td>
			<td><%= tr.RedeemDateTime %></td>
			<td><%= tr.UserRefferer %></td>
			<td><%= tr.Subscribe %></td>
			<td><a href="ResendTicket.aspx?tid=<%= tr.Id %>">Переслать билет на e-mail</a></td>
		</tr>


	<%	} %>
	</table>



</asp:Content>
