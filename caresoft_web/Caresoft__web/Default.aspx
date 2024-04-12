<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="Caresoft__web.Ínicio" Title="Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>Inicio</title>
    <link rel="stylesheet" href="css/Default.css" type="text/css" />
    <div>
        <h1>Bienvenido a Caresoft</h1>
    </div>
    <div class="cita">
        <h3>¿Desea realizar una cita?</h3>
        <div class="descripcion">
            <img src="images/Foto doctor.jpg" alt="Cita" />
            <div class="texto">
                <p>No te preocupes, nuestros doctores son expertos</p>
                <div class="boton">
                    <asp:Button runat="server" Text="Haz click aquí para realizar tu cita"></asp:Button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
