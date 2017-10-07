<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="contacts.aspx.cs" Inherits="AdAndLifeWebsite.ContactsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

    <h1>Напишите нам</h1>

    <div class="form-msg">
        <div class="error"><%= ErrorMsg %></div>
        <%if (IsSent)
            { %><div class="success">Ваше сообщение успешно отправлено.</div>
        <%} %>
        <div>
            <span>Ваше имя</span>
            <input name="msgName" type="text" value="<%= Name  %>" placeholder="Ваше имя" />
        </div>
        <div>
            <span>Ваш email</span>
            <input name="msgEmail" type="email" value="<%= Email  %>" placeholder="Ваш email" />
        </div>
        <div>
            <span>Телефон для связи</span>
            <input name="msgPhoneNumber" type="number" value="<%= PhoneNumber %>" />
        </div>
        <div>
            <span>Тема сообщения
            </span>
            <input name="msgTopic" type="text" value="<%= Topic %>" placeholder="Тема" />
        </div>
        <div>
            <span>Сообщение
            </span>
            <textarea name="msgText"><%= Msg %></textarea>
        </div>
    </div>


    <input type="submit" class="button" name="submitMessage" value="Отправить" />




</asp:Content>
