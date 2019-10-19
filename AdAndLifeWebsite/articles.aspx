<%@ Page Title="" Language="C#" MasterPageFile="~/class.Master" AutoEventWireup="true" CodeBehind="articles.aspx.cs" Inherits="AdAndLifeWebsite.ArticlesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">
	
	
	
	<nav class="rubric-list">
		<ul>
			<asp:Repeater runat="server" ID="RepRubric">
				<ItemTemplate>
					<li <%# Rubric != null && (int)Eval("Id") == Rubric.Id ? "class='selected'" : "" %> ><a href="/articles.aspx?rubricId=<%# Eval("Id") %>"><%# Eval("Name") %></a></li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
	</nav>
	
	<%--<h1><%= Rubric == null ? "Статьи" : Rubric.Name %></h1>--%>
    <ul class="article-list"> 
        <asp:Repeater runat="server" ID="ARep">
            <ItemTemplate>
                <li>
					<div class="article-cat">
						<%# Eval("Rubric") %> |
						<%# Eval("IssueNumberAndYear") %>
						<%# Eval("Author") %>
					</div>
					<a class="article-link" href="/article.aspx?id=<%# Eval("Id") %>">
						<%# Eval("Name") %>
						<div class="art-summary">
							<%# Eval("SummaryText") %> 
						</div>
					</a>

                </li> 
            </ItemTemplate>
        </asp:Repeater>
    </ul>

</asp:Content>
