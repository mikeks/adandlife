<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myTicket.aspx.cs" Inherits="AdAndLifeWebsite.MyTicket" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Электронный билет</title>
</head>
<body>
	<h1>Вы успешно купили билет</h1>
	<h2><%= Sale.EventName %></h2>

	<img src="/Img/logo_adal.png" alt="Реклама и Жизнь" />
	<br />
	<img src="/ArticleImages/events/<%= Sale.EventImage %>" class="event-image" alt="<%= Sale.EventName %>" />

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
				Мест:
			</td>
			<td>
				<%= Tickets.Count() %> (<%= Seats %>)
			</td>
		</tr>
	</table>

	<p>Билет отправлен на вашу электронную почту. </p>
	<input type="button" value="РАСПЕЧАТАТЬ" />

</body>
</html>
