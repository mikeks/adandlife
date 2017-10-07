<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="AdAndLifeWebsite.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
<h1>Реклама и Жизнь</h1>
<p>
    Приветствуем Вас на сайте газет <strong>«Реклама и Жизнь»</strong> и <strong>«Еврейская Жизнь»</strong>. Тут вы найдете 
    <a href="/classified.aspx">рекламные объявления</a>, <a href="/articles.aspx">статьи</a> и многое другое.
</p>
<p>
    Газеты <strong>«Реклама и Жизнь»</strong> и <strong>«Еврейская жизнь»</strong> выходят в свет почти 20 лет!
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
    <div class="p">
        На сайте доступны электронные версии газет в разделе <a href="/archive.aspx">архив</a>: 
        <ul>
            <li>
                Последний выпуск газеты "Реклама и Жизнь" в Филадельфии и New Jersey <a target="_blank" href="<%= lastPhila.Url%>">номер <%= lastPhila.Number %></a>.
            </li>
            <li>
                Последний выпуск газеты "Реклама и Жизнь" в Baltimore и Washington, D.C. <a target="_blank" href="<%= lastBalt.Url%>">номер <%= lastBalt.Number %></a>.
            </li>
            <li>
                Последний выпуск газеты "Еврейская Жизнь" <a target="_blank" href="<%= lastJL.Url%>">номер <%= lastJL.Number %></a>.
            </li>
        </ul>
    </div>
</asp:Content>
