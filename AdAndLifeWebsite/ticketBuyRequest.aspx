<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ticketBuyRequest.aspx.cs" Inherits="AdAndLifeWebsite.TicketBuyRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Ad and life</title>
</head>
<body>
	Please wait...

	<form action="https://www.sandbox.paypal.com/cgi-bin/webscr" id="frm" method="post">
		<input type="hidden" name="cmd" value="_cart" />
		<input type="hidden" name="upload" value="1" />
		<input type="hidden" name="business" value="R28N4TKRNCR4E" />
		<input type="hidden" name="currency_code" value="USD" />
		<input type="hidden" name="handling_cart" value="<%= Sale.HandlingFee %>" />

		<%
			int i = 1;
			foreach (var ticket in Tickets) { %>
		<input type="hidden" name="item_name_<%= i %>" value="<%= Sale.EventNameEng %> (seat <%= ticket.Seat %>)" />
		<input type="hidden" name="quantity_<%= i %>" value="1" />
		<input type="hidden" name="amount_<%= i %>" value="<%= ticket.Price %>" />
		<% 
				i++;
			} %>

		<input type="hidden" name="custom" value="<%= TransactionId %>" />
	</form>

	<script>
		document.getElementById('frm').submit();
	</script>


</body>
</html>
