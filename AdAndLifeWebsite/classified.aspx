<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="classified.aspx.cs" Inherits="AdAndLifeWebsite.ClassifiedPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta property="og:title" content="<%= OgTitle %>" />
    <meta property="og:type" content="article" /> 
    <meta property="og:url" content="<%= CanonicalUrl %>" />
    <meta property="og:image" content="http://adandlife.com/Img/aal_fb.jpg"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
	<div class="top-nav" style="visibility: hidden">

		<div class="dropdown-menu font-size">
			<div class="dropdown-menu-title">
				<span class="font-t1">A</span><span class="font-t2">A</span><i class="arrow-down"></i>
			</div>
			<div class="dropdown-list font-change">
				<a class="font-a1" data-size="16" href="#">А</a>
				<a class="font-a2" data-size="18" href="#">А</a>
				<a class="font-a3" data-size="20" href="#">А</a>
			</div>
		</div>

		<div class="dropdown-menu">
			<div class="dropdown-menu-title">
				<%= RubricMenuTitle %> <i class="arrow-down"></i>
			</div>
			<div class="dropdown-list">
				<% if (Rubric != null)	{ %>
					<a href="/classified.aspx">Все рубрики</a>
  					<hr />
				<% } %>
				<%foreach (var r in Rubrics) { %>
					<a href="?rubric=<%= r.Id %>"><%= r.Name %></a>
				<% } %>
			</div>
		</div>
	</div>

		<div class="search-cont" style="visibility: hidden">
			<div class="search-icon">
				<svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="10" height="10" viewBox="0 0 1000 1000" enable-background="new 0 0 1000 1000" xml:space="preserve"><g><path d="M968.2,849.4L667.3,549c83.9-136.5,66.7-317.4-51.7-435.6C477.1-25,252.5-25,113.9,113.4c-138.5,138.3-138.5,362.6,0,501C219.2,730.1,413.2,743,547.6,666.5l301.9,301.4c43.6,43.6,76.9,14.9,104.2-12.4C981,928.3,1011.8,893,968.2,849.4z M524.5,522c-88.9,88.7-233,88.7-321.8,0c-88.9-88.7-88.9-232.6,0-321.3c88.9-88.7,233-88.7,321.8,0C613.4,289.4,613.4,433.3,524.5,522z"/></g></svg>
			</div>
            <input class="search-bar" type="text" name="txtFirstName" id="SearchBar" placeholder="Поиск" runat="server" /><asp:Button class="search-button" Text="Поиск" runat="server" />
			<span class="search-cancel">×</span>
		</div>

		<div class="new-ad">
			Чтобы дать своё объявление, звоните по телефону <div class="pn">215-354-0844</div>
		</div>


	
<%--    <div class="classified-note">
        Показаны объявления в <%= AdAndLifeWebsite.Classes.Utility.IsBaltimore ? "Baltimore & Washington, DC" : "Philadelphia и New Jersey" %>. Переключить штат можно в меню.
    </div>--%>

        <div class="classified-ad-container">
            <asp:Repeater runat="server" ID="ClassifiedRepeater">
                <ItemTemplate>
                    <div class="classified-ad<%# (bool)Eval("IsPromoting") ? " premium" : "" %>">
                    <%# Eval("Text") %>
                    <a href="#" class="share-button" onclick="shareFb('http://adandlife.com/classified.aspx?ad=<%# Eval("Id") %>');return false;">
						<svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 1000 1000" width="14" height="14" enable-background="new 0 0 1000 1000" xml:space="preserve"><g><path d="M464.1,161.2H180.6c-39.6,0-75-2.8-75,37.3v567.6c0,40.1,32.1,72.6,71.7,72.6H751c39.6,0,71.7-32.5,71.7-72.6V621h95.6v242c0,40.1-32.1,72.6-71.7,72.6H81.7C42.1,935.6,10,903.1,10,863V137c0-40.1,32.1-72.6,71.7-72.6h382.4V161.2z"/><path d="M193.2,635.4c0,0,28.8-384.2,489.6-380.9V64.4L990,350.9L682.8,637.4V448.7C682.8,448.7,391.6,398.8,193.2,635.4z"/></g></svg>
                    </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

		<% if (Ads.Count() == 0) { %>
		<div class="no-classified-ads-found">
			Поиск не дал результатов
		</div>
		<% } %>
</asp:Content>
