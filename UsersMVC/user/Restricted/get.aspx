<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="get.aspx.cs" Inherits="UsersMVC.user.Restricted.get" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div style="width: 389px">
             Персональные данные<br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Имя"></asp:Label>
            <asp:TextBox ID="TextName" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Фамилия"></asp:Label>
            <asp:TextBox ID="TextLastName" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextEmail" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255" TextMode="Email" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Телефон"></asp:Label>
            <asp:TextBox ID="TextPhone" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255" TextMode="Phone" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonSendData" runat="server" OnClick="ButtonChangeData_Click" Text="Редактировать" />
            <br />
        </div>
    </form>
</body>
</html>
