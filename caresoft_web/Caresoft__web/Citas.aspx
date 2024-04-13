<%@ Page Title="Citas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Citas.aspx.cs" Inherits="Caresoft__web.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Haz tu cita</h1>
        <asp:Panel ID="PanelMensaje" runat="server" Visible="false">
            <p>¡Cita agendada con éxito!</p>
        </asp:Panel>
        <asp:Panel ID="PanelCita" runat="server">
            <asp:Label ID="LabelFecha" runat="server" Text="Fecha de la cita:"></asp:Label>
            <asp:TextBox ID="TextBoxFecha" runat="server"></asp:TextBox><br />
            <asp:Label ID="LabelHora" runat="server" Text="Hora de la cita:"></asp:Label>
            <asp:TextBox ID="TextBoxHora" runat="server"></asp:TextBox><br />
            <asp:Button ID="ButtonAgendarCita" runat="server" Text="Agendar Cita" />
        </asp:Panel>
    </div>
</asp:Content>
