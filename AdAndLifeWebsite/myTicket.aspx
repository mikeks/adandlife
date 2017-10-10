<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myTicket.aspx.cs" Inherits="AdAndLifeWebsite.MyTicket" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Электронный билет</title>
	<style>
		.myticket-logo {
			width: 200px;
			float: right;
		}
		table {
			font-size: 20px;
			margin-top: 15px;
			border: solid 1px;
			border-collapse: collapse;
			width: 100%;
		}
		table td {
		   border: solid 1px black;
			padding: 5px;
		}
		.qr {
			width: 300px;
		}
		@media print {
			.noprint {
				display: none;
			}
		}
		.nfo {
			background-color: #eee;
			width: 600px;
			padding: 10px;
			border: solid 1px #b1e0f0;
			font-size: 20px;
		}
	</style>
</head>
<body>
	<img src="/Img/logo_adal.png" alt="Реклама и Жизнь" class="myticket-logo" />
	<div class="nfo noprint">
		Билет отправлен на вашу электронную почту: <%= Trans.Email %><br />
		Распечатайте Ваш билет сейчас.<br /> <input type="button" onclick="window.print()" value="РАСПЕЧАТАТЬ" />
	</div>
	<h1>Электронный билет</h1>

	<h2><%= Sale.EventName %></h2>

	<br />
	<img src="/ArticleImages/events/<%= Sale.EventImage %>" class="myticket-image" alt="<%= Sale.EventName %>" />

	<table>
		<tr>
			<td>
				Дата/время:
			</td>
			<td>
				<%= Sale.EventDate %>
			</td>
		</tr>
		<tr>
			<td>
				Место проведения:
			</td>
			<td>
				<%= Sale.EventLocation %>
			</td>
		</tr>
		<tr>
			<td>
				Адрес:
			</td>
			<td>
				<%= Sale.EventAddress %>
			</td>
		</tr>
		<tr>
			<td>
				Места в зале:
			</td>
			<td>
				<%= Seats %>
			</td>
		</tr>
		<tr>
			<td>
				Покупатель:
			</td>
			<td>
				<%= Trans.Name %>
			</td>
		</tr>
		<tr>
			<td>
				Email:
			</td>
			<td>
				<%= Trans.Email %>
			</td>
		</tr>		
		<tr>
			<td>
				Код подтверждения:
			</td>
			<td>
				<%= Trans.RedeemCode %> 
			</td>
		</tr>
	</table>
	<br />
	<img class="qr" src="data:image/jpeg;base64,<%= Base64barcode %>" />
	<script>
		window.print();
	</script>
</body>
</html>
