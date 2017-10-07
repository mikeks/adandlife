<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" MasterPageFile="admin.Master" CodeBehind="EditTicket.aspx.cs" Inherits="AdAndLifeWebsite.Admin.EditTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

    <h1>Редактирование продажи билетов</h1>

    <%if (IsSaved)
        { %>
    <div style="font-size: 26px; color: green; margin: 15px 0">Изменения сохранены</div>
    <% } %>

    <div style="font-size: 26px; color: red; margin: 15px 0"><%= ErrorMessage %></div>

    <div>
        Название мероприятия:<br />
        <asp:TextBox runat="server" ID="EventName" Width="300" />
    </div>

    <br />
    <div>
        Адрес URL (только латинские буквы без пробелов):<br />
        <asp:TextBox runat="server" ID="UrlName" Width="300" />
    </div>
    <br />

    <div>
        Краткое описание:<br />
        <textarea runat="server" id="EventDescription" style="width: 300px; height: 100px;">
	</textarea>
    </div>

    <br />
    <div>
        Код кнопки:<br />
        <textarea runat="server" id="PayPalCodeButton" style="width: 300px; height: 100px;"></textarea>
    </div>


    <br />
    <div>
        <asp:CheckBox ID="IsAvaliable" Text="Доступно для покупки" runat="server" />
    </div>
    <br />

    <asp:Button runat="server" Text="Сохранить" />

</asp:Content>
