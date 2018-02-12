<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="UsersMVC.user.create" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <ajx:ToolkitScriptManager ID="toolScriptManageer1" runat="server"></ajx:ToolkitScriptManager>  
        <div style="width: 389px">
            Заполните данные для регистрации:<br />
            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Имя"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextName" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255" OnTextChanged="TextName_TextChanged"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Фамилия"></asp:Label>
            <asp:TextBox ID="TextLastName" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextEmail" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255" TextMode="Email"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Телефон"></asp:Label>
            <asp:TextBox ID="TextPhone" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255" TextMode="Phone" OnTextChanged="TextPhone_TextChanged" ValidateRequestMode="Enabled"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Пароль"></asp:Label>
            <asp:TextBox ID="TextPassword1" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Потверждение пароля"></asp:Label>
            <asp:TextBox ID="TextPassword2" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonSendData" runat="server" OnClick="ButtonSendData_Click" Text="Регистрация" Width="250px" />
            <br />
            <br />
            <!-- Скрипт маски  -->
            <ajx:MaskedEditExtender TargetControlID="TextPhone" Mask="+999-99-9999-999"
                ErrorTooltipEnabled="True" runat="server" ID="mskD" />         
            <asp:Button ID="ButtonToLogin" runat="server" OnClick="ButtonToLogin_Click" Text="Войти" Width="105px" />
        </div>
    </form>
</body>
</html>
