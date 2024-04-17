<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Caresoft__web.Registrar" %>

<!DOCTYPE html>
<link rel="stylesheet" href="css/Registrar.css" type="text/css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrarse</title>
</head>
    <body>
        <form id="form1" runat="server">
        <div class="registrar">
            <h1> Registrarse</h1>
            <div class="input-box">
                Nombre: <input type="text" placeholder="Nombre" ID="userbox" runat="server"  />
            </div>
            <div class="input-box">
                Apellido: <input type="text" placeholder="Apellido" ID="apellidobox" runat="server"  />
            </div>
            <div class="input-box">
                Correo: <input type="text" placeholder="Correo" ID="correobox" runat="server"  />
            </div>
            <div class="input-box">
                Identificación: <input type="text" placeholder="Cedula" ID="idbox" runat="server" MaxLength="11" />
            </div>
             <div class="input-box">
                Telefono: <input type="text" placeholder="Telefono" ID="telbox" runat="server" MaxLength="10" />
            </div>
            <div class="input-box">
                Contraseña: <input type="password" placeholder="Contraseña" ID="passwordbox" runat="server" />
            </div>
            <div class="input-box">
                 Contraseña: <input type="password" placeholder="Confirmar contraseña" id="confirmpassbox" runat="server" />
            </div>
            <div class="boton">
                <asp:Button ID="Button1" runat="server" Text="Registrarse" OnClick="Button1_Click" />
            </div>
        </div>
        </form>
    </body>
</html>
