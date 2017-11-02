<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" MasterPageFile="admin.Master" CodeBehind="EditTickets.aspx.cs" Inherits="AdAndLifeWebsite.Admin.EditTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
	<style>
		div {
			margin-bottom: 20px;
		}
		table td {
			border: solid 1px black;
			padding: 5px;
			text-align: center;
		}
		table {
			border-collapse: collapse;
		}
		.bought {
			background-color: lawngreen;
		}
		.opt {
			font-size: small;
			color: cornflowerblue;
		}
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

    <h1>Билеты на <%= Sale.EventName %></h1>

    <%if (IsSaved)
		{ %>
    <div style="font-size: 26px; color: green; margin: 15px 0">Изменения сохранены</div>
    <% } %>

    <div style="font-size: 26px; color: red; margin: 15px 0"><%= ErrorMessage %></div>

    <div>
        <h2>Введенные билеты:</h2>

		<table>
			<tr>
				<td>Место</td>
				<td>Цена</td>
				<td>Статус</td>
				<td>Покупатель</td>
				<td>Опции</td>
			</tr>
			<asp:Repeater ID="RepeaterExistingTickets" runat="server">
				<HeaderTemplate>
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td><%# Eval("Seat") %></td>
						<td><%# Eval("Price", "${0:#}") %></td>
						<td <%# Eval("PurchaseDate") != null ? "class='bought'" : "" %>><%# Eval("PurchaseDate") == null ? "в продаже" : "куплен " + Eval("PurchaseDate") %></td>
						<td>
							<%# Eval("BuyerName") %>
						</td>
						<td><a class="opt" <%# Eval("PurchaseDate") == null || Eval("TransactionId") == null ? "style='display:none'" : "" %> href="ResendTicket.aspx?tid=<%# Eval("TransactionId") %>">Переслать билет покупателю на e-mail</a></td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>

					</table>
				</FooterTemplate>
			</asp:Repeater>
		</table>

    </div>


    <div>
        <h2>Добавить билеты:</h2>
        Цена: <asp:TextBox runat="server" ID="TicketPrice" TextMode="Number" Width="100" MaxLength="3" /> Места (через запятую):  <asp:TextBox runat="server" ID="TicketsToAdd" Width="300" />
    </div>

    <div>
        <h2>Удалить билеты:</h2>
        Места (через запятую):  <asp:TextBox runat="server" ID="TicketsToDelete" Width="300" />
    </div>


    <asp:Button runat="server" Text="Применить" />

</asp:Content>
