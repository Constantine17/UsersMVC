<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="UsersMVC.user.create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 389px">
            Заполните данные для регистрации:<br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Имя"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextName" runat="server" style="margin-left: 123px" Width="160px" MaxLength="255"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Фамилия"></asp:Label>
            <asp:TextBox ID="TextLastName" runat="server" style="margin-left: 119px" Width="160px" MaxLength="255"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextEmail" runat="server" style="margin-left: 148px" Width="160px" MaxLength="125"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Телефон"></asp:Label>
            <asp:TextBox ID="TextPhone" runat="server" style="margin-left: 124px" Width="160px" MaxLength="15"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Пароль"></asp:Label>
            <asp:TextBox ID="TextPassword1" runat="server" style="margin-left: 130px" Width="160px" MaxLength="255"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Потверждение пароля"></asp:Label>
            <asp:TextBox ID="TextPassword2" runat="server" style="margin-left: 28px" Width="160px" MaxLength="255"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonSendData" runat="server" OnClick="ButtonSendData_Click" Text="Поттвердить" />
            <br />
        </div>
    </form>
</body>
</html>
