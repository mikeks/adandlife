<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" MasterPageFile="admin.Master" CodeBehind="ResendTicket.aspx.cs" Inherits="AdAndLifeWebsite.Admin.ResendTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
	<style>
		div {
			margin-bottom: 20px;
		}
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

    <h1>Переслать билет</h1>

	<div style="font-size:32px;color:blue;margin-bottom:10px">
		<%= Message %>
	</div>

	<div>
		Мероприятие: <%= Trans.GetSale().EventName %>
	</div>
	<div>
		Покупатель: <%= Trans.Name %>
	</div>
	<div>
		<asp:TextBox runat="server" TextMode="Email" ID="UserEmail" />
		<asp:Button Text="Переслать" runat="server" />
	</div>



</asp:Content>
