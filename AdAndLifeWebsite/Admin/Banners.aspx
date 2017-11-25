<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" MasterPageFile="admin.Master" CodeBehind="Banners.aspx.cs" Inherits="AdAndLifeWebsite.Admin.Banners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
	<style>
		div {
			margin-bottom: 20px;
		}
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
		.vis {
		}
		.hid {
			background-color: lightgray;
		}
	</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

    <h1>Баннеры</h1>

	<a href="EditBanner.aspx">Новый баннер</a><br /><br />

	<table>
		<tr>
			<th>Название баннера</th>
			<th>Позиция в правой колонке</th>
			<th>Позиция на главной</th>
			<th>Цена</th>
			<th>Дата снятия</th>
			<th>Операции</th>
		</tr>
		<asp:Repeater ID="RepeaterBanners" runat="server">
			<ItemTemplate>
				<tr <%# IsBannerActive(Container.DataItem) ? "class='vis'": "class='hid'" %>>
					<td><%# Eval("Name") %></td>
					<td><%# PosToStr(Eval("PositionRight")) %></td>
					<td><%# PosToStr(Eval("PositionHomepage")) %></td>
					<td><%# Eval("Price") %></td>
					<td><%# ((DateTime)Eval("EndDate")).ToShortDateString() %></td>
					<td>
						<a href="EditBanner.aspx?id=<%# Eval("Id") %>">редактировать</a><br />
						<a onclick="return confirm('Удалить баннер <%# Eval("Name") %>?');" href="Banners.aspx?del=<%# Eval("Id") %>" style="color:red">удалить</a><br />
					</td>
				</tr>
			</ItemTemplate>
		</asp:Repeater>
	</table>


</asp:Content>
