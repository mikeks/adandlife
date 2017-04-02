<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="classified.aspx.cs" Inherits="AdAndLifeWebsite.classified" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Repeater runat="server" ID="RubricRepeater">
                <ItemTemplate>
                    <a class="classifiedRubric" href="?rubric=<%# Eval("Id") %>">
                    <%# Eval("Name") %>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div>

            Поиск по объявлениям: <asp:TextBox ID="SearchBar" runat="server"></asp:TextBox> 
            <asp:Button Text="Поиск" runat="server" />
        </div>

        <asp:Repeater runat="server" ID="ClassifiedRepeater">
            <ItemTemplate>
                <div class="classifiedAd">
                <%# Eval("Text") %>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    </form>
</body>
</html>
