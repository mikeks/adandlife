<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" MasterPageFile="admin.Master" CodeBehind="EditEvent.aspx.cs" Inherits="AdAndLifeWebsite.Admin.EditEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
	<style>
		div {
			margin-bottom: 20px;
		}
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

    <h1>Редактирование продажи билетов</h1>

    <%if (IsSaved)
        { %>
    <div style="font-size: 26px; color: green; margin: 15px 0">Изменения сохранены</div>
    <% } %>

    <div style="font-size: 26px; color: red; margin: 15px 0"><%= ErrorMessage %></div>

    <div>
        Название мероприятия (кратко, можно по-русски, например "Ян Левинзон - Мужчина перед зеркалом"):<br />
        <asp:TextBox runat="server" ID="EventName" Width="300" />
    </div>

    <div>
        Название по-английски (только латинские буквы, это название отображается в билетах и транзакциях. Например: "Yan Levinzon"):<br />
        <asp:TextBox runat="server" ID="EventNameEng" MaxLength="16" Width="300" />
    </div>

    <div>
        Адрес URL (сокращенное название мероприятия латинскими буквами без пробелов, например "levinzon"):<br />
        <asp:TextBox runat="server" ID="UrlName" MaxLength="14" Width="300" />
    </div>

	<div style="margin:15px 0;">
	    Афиша. Загрузите изображение. Допускается формат PNG или JPG.<br />
	    <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>

    <div>
        Описание событие. Скопируйте сюда анонс:<br />
        <textarea runat="server" id="EventDescription" style="width: 1000px; height: 400px;">
	</textarea>
    </div>

    <br />
    <div>
        <asp:CheckBox ID="IsAvaliable" Text="Доступно для покупки" runat="server" />
    </div>
    <br />

    <asp:Button runat="server" Text="Сохранить" />

</asp:Content>
