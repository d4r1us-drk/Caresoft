<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cuenta.aspx.cs" Inherits="Caresoft__web.Cuenta" %>

<!DOCTYPE html>
<link rel="stylesheet" href="css/Cuenta.css" type="text/css"

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login">
            <h1>Login</h1>
                <div class="input-box">
                  <input type="text" placeholder="Correo" required ID="userbox"  />
                    <asp:Image ID="ImageUser" runat="server" ImageUrl="~/images/user-regular-24.png" />
                 </div>
              <div class="input-box">
                <input type="password" placeholder="Contraseña" required id="passwordbox" />
                  <asp:Image ID="ImagePassword" runat="server" ImageUrl="~/images/lock-alt-regular-24.png" />
             </div>
            <div class="button">
        <asp:Button ID="Login" runat="server" Text="Iniciar Sesión" Width="200px" OnClick="Login_Click"/>
             </div>
        </div>
    </form>
        </body>
</html>
