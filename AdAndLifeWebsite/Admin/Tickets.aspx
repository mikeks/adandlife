<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="admin.Master" CodeBehind="Tickets.aspx.cs" Inherits="AdAndLifeWebsite.Admin.Tickets" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
    <h1>Билеты</h1>
    <div>
        <a href="EditTicket.aspx">Добавить новую продажу</a><br />
		<ul>
			<asp:Repeater runat="server" ID="SalesRepeater">
				<ItemTemplate>
					<li class="art-list">
                        <span class="art-name"><%# Eval("EventName") %></span>
						<a href="EditEvent.aspx?id=<%# Eval("Id") %>">Редактировать мероприятие</a> |
						<a href="EditTickets.aspx?id=<%# Eval("Id") %>">Редактировать билеты</a> |
                        <a target="_blank" href="/ticket.aspx?id=<%# Eval("Id") %>">Открыть на сайте</a> |
						<a style="color:red" onclick="return confirm('Удалить?');" href="Tickets.aspx?del=<%# Eval("Id") %>">Удалить</a> 
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>    
    </div>

</asp:Content>

