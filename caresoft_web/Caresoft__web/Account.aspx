<%@ Page Title="Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Caresoft__web.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cuenta</h1>
    <div class="menu">
        <div class="nombre">
             <h3>Nombre:<asp:TextBox ID="nombrebox" runat="server" Enabled="False"></asp:TextBox>
             </h3>
        </div>
        <div class="apellido">
            <h3> Apellido:<asp:TextBox ID="apellidobox" runat="server" Enabled="False"></asp:TextBox>
            </h3>
        </div>
        <div class="correo">
            <h3> Correo:<asp:TextBox ID="correobox" runat="server" Enabled="False"></asp:TextBox>
            </h3>
        </div>
        <div class="cedula">
            <h3> Cedula:<asp:TextBox ID="cedulabox" runat="server" Enabled="False"></asp:TextBox>
            </h3>
</asp:Content>
