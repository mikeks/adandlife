<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" MasterPageFile="admin.Master" CodeBehind="EditBanner.aspx.cs" Inherits="AdAndLifeWebsite.Admin.EditBanner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
	<style>
		div {
			margin-bottom: 20px;
		}
		.note {
			color: gray;
			font-style: italic;
		}
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

	<a href="Banners.aspx">Баннеры</a>

    <h1>Баннер</h1>

    <%if (IsSaved)
        { %>
    <div style="font-size: 26px; color: green; margin: 15px 0">Изменения сохранены</div>
    <% } %>

    <div style="font-size: 26px; color: red; margin: 15px 0"><%= ErrorMessage %></div>

    <div>
        Название (для внутреннего пользования):<br />
        <asp:TextBox runat="server" ID="BannerName" Width="300" />
    </div>

    <div>
        Дата автоматического снятия с сайта:<br />
        <asp:TextBox runat="server" ID="BannerEndDate" TextMode="Date" Width="300" />
    </div>

    <div>
        Цена:<br />
        <asp:TextBox runat="server" ID="BannerPrice" TextMode="Number" Width="300" />
    </div>


	<h2>Изображение</h2>
	<img src="/ArticleImages/banners/<%= Banner.RightColumnFilename %>" />

	<div style="margin:15px 0;">
	    Загрузите изображение. Допускается формат PNG или JPG.<br />
	    <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>

	<h2>Расположение на сайте</h2>
    <div>
		<div class="note">
			Рекомендуется размещать широкие баннеры внизу на главной странице. Квадратные или вытянутые вертикально - в правой колонке.
		</div>
        Позиция на всех страницах в правой колонке (ширина 300 пикселей): 
		<asp:DropDownList ID="ddPositionRight" runat="server">
		</asp:DropDownList>
		<br /><br />
        Позиция внизу на главной странице (ширина 600 пикселей): 
		<asp:DropDownList ID="ddPositionHomepage" runat="server">
		</asp:DropDownList>

    </div>



    <asp:Button runat="server" Text="Сохранить" />

</asp:Content>
