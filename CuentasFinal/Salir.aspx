<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salir.aspx.cs" Inherits="CuentasFinal.Salir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <style>
        body{
            text-align:center;
        }
        .auto-style1 {
            width: 952px;
        }
        .auto-style2 {
            width: 952px;
            height: 164px;
        }
    </style>
</head>
<body style="background-image:url(Scripts/fondo2.jpg); background-repeat: no-repeat; background-attachment: fixed">
    <form id="form1" runat="server">
        <div>
            Hola
            <asp:Label ID="lblUserDetails" runat="server" Font-Bold="True" Text="Label"></asp:Label>
&nbsp;Esta seguro de Salir?<br />
            <br />
            <asp:Button ID="btnLogout" runat="server" OnClick="Button1_Click" Text="Aceptar" />
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Cancelar" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
