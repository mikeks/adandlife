<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="classified.aspx.cs" Inherits="AdAndLifeWebsite.ClassifiedPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script>
        var ww = window.innerWidth || document.documentElement.clientWidth;
        function openPopup(u) { if (ww < 760) location = u; else open(u, '_blank', 'width=600,height=400,resizable=1,top=' + Math.max(0, screen.height / 2 - 300) + ',left=' + Math.max(0, screen.width / 2 - 200)) }
        function shareFb(s) { openPopup('https://www.facebook.com/sharer/sharer.php?u=' + encodeURIComponent(s)) }
    </script>
    <meta property="og:title" content="<%= OgTitle %>" />
    <meta property="og:type" content="article" /> 
    <meta property="og:url" content="<%= CanonicalUrl %>" />
    <meta property="og:image" content="http://adandlife.com/Img/aal_fb.jpg"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

<%--    <div id="fb-root"></div>
    <script>(function(d, s, id) {
      var js, fjs = d.getElementsByTagName(s)[0];
      if (d.getElementById(id)) return;
      js = d.createElement(s); js.id = id;
      js.src = "//connect.facebook.net/ru_RU/sdk.js#xfbml=1&version=v2.10&appId=1519165781479119";
      fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));</script>--%>


        <div>
            <input class="search-bar" type="text" name="txtFirstName" id="SearchBar" placeholder="Поиск" runat="server" />
            <asp:Button class="search-button" Text="Поиск" runat="server" />
            <a class="new-classified-ad" href="/contacts.aspx?msgTopic=%D0%9D%D0%BE%D0%B2%D0%BE%D0%B5+%D0%BE%D0%B1%D1%8A%D1%8F%D0%B2%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5">
                Дать объявление
            </a>
        </div>

        <div>
            <asp:Repeater runat="server" ID="RubricRepeater">
                <ItemTemplate>
                    <a class="ad-rubric<%# (int)Eval("Id") == CurrentRubricId ? "-sel" : "" %>" href="?rubric=<%# Eval("Id") %>"><%# Eval("Name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    <div class="classified-note">
        Показаны объявления в <%= AdAndLifeWebsite.Classes.Utility.IsBaltimore ? "Baltimore & Washington, DC" : "Philadelphia и New Jersey" %>. Переключить штат можно в верхней части сайта.
    </div>

        <div class="classified-ad-container">
            <asp:Repeater runat="server" ID="ClassifiedRepeater">
                <ItemTemplate>
                    <div class="classified-ad<%# (bool)Eval("IsPromoting") ? " premium" : "" %>">
                    <%# Eval("Text") %>
                    <a href="#" onclick="shareFb('http://adandlife.com/classified.aspx?ad=<%# Eval("Id") %>');return false;">Поделитесь этим объявлением на Facebook</a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

</asp:Content>
