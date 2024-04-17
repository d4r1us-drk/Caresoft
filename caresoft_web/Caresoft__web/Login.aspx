<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Caresoft__web.Cuenta" %>

<!DOCTYPE html>
<link rel="stylesheet" href="css/Login.css" type="text/css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login">
            <h1>Login</h1>
                <div class="input-box">
                  <input type="text" placeholder="Cédula" ID="idbox" runat="server" />
                    <asp:Image ID="ImageUser" runat="server" ImageUrl="~/images/user-regular-24.png" />
                 </div>
              <div class="input-box">
                <input type="password" placeholder="Contraseña" id="passwordbox" runat="server"/>
                  <asp:Image ID="ImagePassword" runat="server" ImageUrl="~/images/lock-alt-regular-24.png" />
             </div>
            <div class="button">
        <asp:Button ID="login" runat="server" Text="Iniciar Sesión" Width="200px" OnClick="login_Click"/>             
             </div>
            <div class="register">
        <asp:Button ID="registrarse" runat="server" Text="Registrarse" Width="200px" PostBackUrl="Registrar.aspx" />
            </div>
        </div>
    </form>
        </body>
</html>
