<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="UsersMVC.user.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Login ID="LoginForm" runat="server" OnAuthenticate="LoginForm_Authenticate" UserNameLabelText="Email:">
        </asp:Login>
        <asp:Button ID="ButtonToCreate" runat="server" OnClick="ButtonToCreate_Click" style="margin-left: 83px" Text="Регистрация" Width="134px" />
    </form>
</body>
</html>
