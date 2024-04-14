<%@ Page Title="Caja" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Caja.aspx.cs" Inherits="Caresoft__web.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Caja</h1>
    <div class="menu">
        <asp:Table ID="tblDatos" CssClass="table" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Seleccionar</asp:TableHeaderCell>
                <asp:TableHeaderCell>Concepto</asp:TableHeaderCell>
                <asp:TableHeaderCell>Monto</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <asp:Button ID="btnPagar" runat="server" Text="Pagar" OnClick="pagar_Click" />
    </div>
    <div class="popup" id="popup" Visible="false" runat="server">
        <h1>Pagar</h1>
    </div>
</asp:Content>
