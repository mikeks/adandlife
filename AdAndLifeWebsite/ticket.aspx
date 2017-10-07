<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="ticket.aspx.cs" Inherits="AdAndLifeWebsite.Ticket" %>

<%@ Import Namespace="AdAndLifeWebsite.Classes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentAreaNoForm" runat="server">

    <h1>
        <%=Sale.EventName %>
    </h1>
    <div class="event-description">
        <%= Sale.EventDescription %>
        <br /><br />
        Нажмите на кнопку <strong>Buy Now</strong>, чтобы купить билет. Вы можете оплатить кредитной карточкой <strong>Visa</strong>, <strong>Master Card</strong>, <strong>Discover</strong> или напрямую через PayPal. 
    </div>

    

<%-- PRODUCTION: Хрен в ступе
	<form target="paypal" action="https://www.paypal.com/cgi-bin/webscr" method="post">
<input type="hidden" name="cmd" value="_s-xclick">
<input type="hidden" name="custom" value="5400615">
<input type="hidden" name="hosted_button_id" value="4LST3AKX2CMHG">
<input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_cart_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
<img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
</form>--%>

<%--Sandbox: Африканская оргия--%>

<form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post" target="_top">
<input type="hidden" name="cmd" value="_s-xclick">
<input type="hidden" name="custom" value="5400615">
<input type="hidden" name="hosted_button_id" value="R85J3RWJT3QYU">
<input type="image" src="https://www.sandbox.paypal.com/en_US/i/btn/btn_buynowCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
<img alt="" border="0" src="https://www.sandbox.paypal.com/en_US/i/scr/pixel.gif" width="1" height="1">
</form>


</asp:Content>


