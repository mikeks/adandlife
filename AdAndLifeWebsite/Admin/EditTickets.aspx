<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" MasterPageFile="admin.Master" CodeBehind="EditTickets.aspx.cs" Inherits="AdAndLifeWebsite.Admin.EditTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
	<style>
		div {
			margin-bottom: 20px;
		}
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

    <h1>Редактирование билетов</h1>

    <%if (IsSaved)
        { %>
    <div style="font-size: 26px; color: green; margin: 15px 0">Изменения сохранены</div>
    <% } %>

    <div style="font-size: 26px; color: red; margin: 15px 0"><%= ErrorMessage %></div>

    <div>
        <h2>Введенные билеты:</h2>
		<%= ExistingTickets %>
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
