<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="classified-paid.aspx.cs" Inherits="AdAndLifeWebsite.NewClassifiedPaidPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script>
        function selectPremium(el) {
            if (el.checked) {
                document.getElementById('premiumAd').style.display='';
                document.getElementById('regAd').style.display = 'none';
            } else {
                document.getElementById('premiumAd').style.display = 'none';
                document.getElementById('regAd').style.display = '';
            }
        }
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

    <h1>Оплата объявления</h1>

    Нажмите на кнопку <strong>Buy Now</strong> ниже, чтобы оплатить объявление. 
    Вы можете оплатить кредитной карточкой <strong>Visa</strong>, <strong>Master Card</strong>, <strong>Discover</strong> или напрямую через PayPal. 

<%--        <div>

            <input type="checkbox" id="chPremiumAd" checked onchange="selectPremium(this)" /><label for="PremiumAd">Premium ad</label>
            <div>
                При выборе этого пункта, ваше объявление привлечет большее количество откликов, за счет того, что оно:
                <ul>
                    <li>будет выделено цветом на сайте</li>
                    <li>будет выделено в газете (белый текст на черном фоне)</li>
                    <li>Объявление будет поднято в поиске на сайте</li>
                    <li>Объявление будет опубликовано на Facebook</li>
                </ul>
            </div>

            <div id="premiumAd">
                <form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
                <input type="hidden" name="cmd" value="_s-xclick">
                <input type="hidden" name="hosted_button_id" value="7N2N3CZM73DLS">
                <table>
                <tr><td><input type="hidden" name="on0" value="&#1056;а&#1079;ме&#1089;&#1090;&#1080;&#1090;&#1100; на &#1089;&#1088;&#1086;&#1082;">&#1056;а&#1079;ме&#1089;&#1090;&#1080;&#1090;&#1100; на &#1089;&#1088;&#1086;&#1082;</td></tr><tr><td><select name="os0">
	                <option value="1 недел&#1103;">1 недел&#1103; $13.00 USD</option>
	                <option value="2 недел&#1080;">2 недел&#1080; $26.00 USD</option>
	                <option value="3 недел&#1080;">3 недел&#1080; $39.00 USD</option>
	                <option value="1 ме&#1089;&#1103;&#1094;">1 ме&#1089;&#1103;&#1094; $47.00 USD</option>
	                <option value="2 ме&#1089;&#1103;&#1094;а">2 ме&#1089;&#1103;&#1094;а $90.00 USD</option>
                </select> </td></tr>
                </table>
                <input type="hidden" name="currency_code" value="USD">
                <input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_buynowCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
                <img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
                </form>
            </div>

            <div id="regAd" style="display:none">
                <form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
                <input type="hidden" name="cmd" value="_s-xclick">
                <input type="hidden" name="hosted_button_id" value="CX93EK952ZMJQ">
                <table>
                <tr><td><input type="hidden" name="on0" value="&#1056;а&#1079;ме&#1089;&#1090;&#1080;&#1090;&#1100; на &#1089;&#1088;&#1086;&#1082;">&#1056;а&#1079;ме&#1089;&#1090;&#1080;&#1090;&#1100; на &#1089;&#1088;&#1086;&#1082;</td></tr><tr><td><select name="os0">
	                <option value="1 недел&#1103;">1 недел&#1103; $10.00 USD</option>
	                <option value="2 недел&#1080;">2 недел&#1080; $20.00 USD</option>
	                <option value="3 недел&#1080;">3 недел&#1080; $30.00 USD</option>
	                <option value="1 ме&#1089;&#1103;&#1094;">1 ме&#1089;&#1103;&#1094; $35.00 USD</option>
	                <option value="2 ме&#1089;&#1103;&#1094;а">2 ме&#1089;&#1103;&#1094;а $70.00 USD</option>
                </select> </td></tr>
                </table>
                <input type="hidden" name="currency_code" value="USD">
                <input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_buynowCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
                <img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
                </form>
            </div>

        </div>--%>
    </div>


    <input type="submit" class="button" name="submitMessage" value="Далее" />




</asp:Content>
