<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="UsersMVC.user.Restricted.update" %>
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
             Персональные данные<br />
             <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>
             <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Имя"></asp:Label>
            <asp:TextBox ID="TextName" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Фамилия"></asp:Label>
            <asp:TextBox ID="TextLastName" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextEmail" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255" TextMode="Email" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Телефон"></asp:Label>
            <asp:TextBox ID="TextPhone" runat="server" style="margin-right: 119px; margin-left: 42px;" Width="200px" MaxLength="255" TextMode="Phone"></asp:TextBox>
            <br />
            <br />
             <asp:Button ID="ButtonSaveData" runat="server" OnClick="ButtonSaveData_Click" Text="Сохранить" style="margin-left: 9px" Width="236px" />
             <br />
             <br />
             <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Удалить" style="margin-left: 12px" Width="106px" />
            <asp:Button ID="ButtonSendData" runat="server" OnClick="ButtonBack_Click" Text="Назад" style="margin-left: 15px" Width="111px" />
            <br />
            <!-- Скрипт маски  -->
            <ajx:MaskedEditExtender TargetControlID="TextPhone" Mask="+999-99-9999-999"
                ErrorTooltipEnabled="True" runat="server" ID="mskD" />  
        </div>
    </form>
</body>
</html>
