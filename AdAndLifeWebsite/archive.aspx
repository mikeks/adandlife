<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="archive.aspx.cs" Inherits="AdAndLifeWebsite.ArchivePage" %>

<%@ Import Namespace="AdAndLifeWebsite.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
    <h1>Архив</h1>

    <%if (SiteUser.IsAdmin)
        { %>
    <section class="admin-add-archive">

        <h1>Добавить в архив</h1>

        <div runat="server" id="ErrorDiv" visible="false" class="error">Произошла ошибка. Пожалуйста, проверьте что все поля заполнены верно.</div>
        <table>
            <tr>
                <td>Тип газеты 
                </td>
                <td>
                    <asp:DropDownList ID="ddArticleType" runat="server">
                        <asp:ListItem Value="0" Text="Реклама и Жизнь - Филадельфия" />
                        <asp:ListItem Value="1" Text="Еврейская жизнь" />
                        <asp:ListItem Value="2" Text="Реклама и Жизнь - Балтимор" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Номер: 
                </td>
                <td>
                    <asp:TextBox ID="tbNumber" TextMode="Number" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Год: 
                </td>
                <td>
                    <asp:TextBox ID="tbYear" TextMode="Number" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Адрес газеты в Internet: 
                </td>
                <td>
                    <asp:TextBox ID="tbUrl" Width="300" TextMode="Url" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Добавить выпуск" />

    </section>
    <% } %>

    <p>
        Тут Вы можете почитать выпуски газет <strong>Реклама и Жизнь</strong> и <strong>Еврейская Жизнь</strong>.
    </p>

    <script>
        function sel(i) {
            document.getElementById('archiveALPhila').style.display = (i == 1) ? '' : 'none';
            document.getElementById('archiveALBaltimore').style.display = (i == 2) ? '' : 'none';
            document.getElementById('archiveJL').style.display = (i == 3) ? '' : 'none';
            document.getElementById('bl1').className = document.getElementById('bl1').className.replace('selected', '');
            document.getElementById('bl2').className = document.getElementById('bl2').className.replace('selected', '');
            document.getElementById('bl3').className = document.getElementById('bl3').className.replace('selected', '');
            document.getElementById('bl' + i).className += ' selected';
        }
    </script>

    <div id="bl1" class="archive-block first selected" onclick="sel(1)">
        <div class="archive-title">Реклама и Жизнь</div>
        <div class="archive-title-city">Philadelphia</div>
        <div class="archive-title-city">New Jersey</div>
    </div><div id="bl2" class="archive-block"  onclick="sel(2)">
        <div class="archive-title">Реклама и Жизнь</div>
        <div class="archive-title-city">Baltimore</div>
        <div class="archive-title-city">Washington</div>
    </div><div id="bl3" class="archive-block last" onclick="sel(3)">
        <div class="archive-title">Еврейская Жизнь</div>
    </div>

        
    
    <ul class="archive-list" id="archiveALPhila">
        <asp:Repeater ID="repArchiveALPhila" runat="server">
            <ItemTemplate>
                <li>
                    <a target="_blank" href="<%# Eval("Url") %>">
                        №<%# Eval("Number", "{0:D2}") %> <%# Eval("Year") %>
                    </a>
                    <%if (SiteUser.IsAdmin) { %><a href="?del=<%# Eval("Id") %>">(удалить)</a><% } %>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

    <ul class="archive-list" id="archiveALBaltimore" style="display:none">
        <asp:Repeater ID="repArchiveALBaltimore" runat="server">
            <ItemTemplate>
                <li>
                    <a target="_blank" href="<%# Eval("Url") %>">
                        №<%# Eval("Number", "{0:D2}") %> <%# Eval("Year") %>
                    </a>
                    <%if (SiteUser.IsAdmin) { %><a href="?del=<%# Eval("Id") %>">(удалить)</a><% } %>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

    <ul class="archive-list" id="archiveJL" style="display:none">
        <asp:Repeater ID="repArchiveJL" runat="server">
            <ItemTemplate>
                <li>
                    <a target="_blank" href="<%# Eval("Url") %>">
                        №<%# Eval("Number", "{0:D2}") %> <%# Eval("Year") %>
                    </a>
                    <%if (SiteUser.IsAdmin) { %><a href="?del=<%# Eval("Id") %>">(удалить)</a><% } %>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    


	<img class="bannerBottom" src="ArticleImages/banners/4bc_C_Trucking Co_5343_17_P36.jpg" />


</asp:Content>
