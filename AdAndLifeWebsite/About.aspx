<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="AdAndLifeWebsite.AboutPage" %>
<%@ Import Namespace="AdAndLifeWebsite.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
<h1>Реклама&nbsp;и&nbsp;Жизнь</h1>
<p>
    Газеты <strong>«Реклама и Жизнь»</strong> и <strong>«Еврейская жизнь»</strong> выходят в свет более 20 лет!
    Издатель – <strong>Виталий Рахман</strong>, поэт, художник и профессиональный дизайнер. Газеты пользуются 
    заслуженным вниманием читателей и распространяются в Greater Philadelphia, NJ, Baltimore, Washington DC и VA.
</p>
<p>
    С компанией успешно сотрудничают <strong>ведущие прозаики</strong>, <strong>журналисты</strong> и <strong>поэты</strong> русского Зарубежья. 
    Широко освещаются культурные и политические новости в мире, и особенно подробно - США, Израиля и России. 
    Особое внимание уделяется местным новостям, в том числе непосредственным событиям, происходящим внутри общины. 
</p>
<p>
    В газетах публикуются рекламы известнейших в общине врачей, юристов, социальных и детских учреждений, компаний, 
    распространяющих товары и услуги для населения, популярных агентств по продаже автомашин, ресторанов, аптек, спортивных клубов и целый ряд других бизнесов.
</p>
<p>
    Только в течение одной недели в секции <a href="/classified.aspx">Classified</a> указанных изданий публикуется несколько сотен различных объявлений, 
    в том числе предложений по трудоустройству на работу, Real Estate услуг, занятиях, о покупке и продаже, туризме, широком спектре услуг для населения и
    многих других.
</p>
<p>
    Для <strong>рекламодателей</strong>, размещающих рекламу в газетах, установлены гибкие системы цен и скидок.
</p>


<h1>Ad and Life</h1>
<p>
    The newspapers <strong>Ad and Life</strong> and <strong>Jewish Life</strong> have been in publication for over 20 years!
    The publisher is <strong>Vitaliy Rakhman</strong>, a poet, artist, and professional designer. The newspapers enjoy well-deserved attention from readers and are distributed in Greater Philadelphia, NJ, Baltimore, Washington DC, and VA.
</p>
<p>
    The company successfully collaborates with <strong>leading prose writers</strong>, <strong>journalists</strong>, and <strong>poets</strong> from the Russian diaspora. 
    Cultural and political news from around the world is widely covered, with particular focus on the USA, Israel, and Russia. 
    Special attention is given to local news, including direct events occurring within the community.
</p>
<p>
    The newspapers feature advertisements from the most renowned doctors, lawyers, social and child institutions, companies providing goods and services to the population, popular car dealerships, restaurants, pharmacies, sports clubs, and many other businesses within the community.
</p>
<p>
    Only within one week, the <a href="/classified.aspx">Classified</a> section of these publications includes several hundred different announcements, 
    including job offers, real estate services, classes, buying and selling, tourism, a wide range of services for the population, and much more.
</p>
<p>
    For <strong>advertisers</strong> placing ads in the newspapers, flexible pricing and discount systems are available.
</p>



<%--	<%foreach (var bnr in SiteBanner.BannersForHomepage) { %>
		<a target="_blank" href="/ArticleImages/banners/<%= bnr.FullscreenFilename %>"><img class="bannerBottom" src="ArticleImages/banners/<%= bnr.HomepageFilename %>" /></a>
	<% } %>--%>


</asp:Content>
