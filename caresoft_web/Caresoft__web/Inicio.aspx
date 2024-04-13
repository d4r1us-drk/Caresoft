<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Caresoft__web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <link rel="stylesheet" href="css/Inicio.css" type="text/css" />
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
                  <asp:Button runat="server" Text="Haz click aquí para realizar tu cita" ID="BotonCita" OnClick="BotonCita_Click1"></asp:Button>
              </div>
          </div>
      </div>
  </div>
</asp:Content>
