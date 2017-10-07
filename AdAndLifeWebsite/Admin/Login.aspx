<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdAndLifeWebsite.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="admin.css" rel="stylesheet" />
</head>
<body>
    <h1>Админка РИЖ</h1>

    <div class="error" style="font-size: 24px;margin: 20px 0;">
        <%= ErrorMsg %>
    </div>    

     <form method="post">
        <input type="text" placeholder="Логин" style="width:400px;font-size:20px" maxlength="100" name="login" /><br />
        <input type="password" placeholder="Пароль" style="width:400px;font-size:20px;margin-top:20px" maxlength="20" name="password" />
        <div style="margin-top:25px">
            <input type="submit" class="button" name="save" value="Вход" />
        </div>
    </form>
</body>
</html>
