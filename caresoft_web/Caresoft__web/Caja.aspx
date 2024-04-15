<%@ Page Title="Caja" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Caja.aspx.cs" Inherits="Caresoft__web.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="css/.css" type="text/css" />
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
        <div class="infopago">
          <h3> Tarjeta de crédito:<asp:TextBox ID="tarjetabox" runat="server" Enabled="True" Placeholder="XXXX-XXXX-XXXX" MaxLength="12"></asp:TextBox>
            </h3>
        <h3>CVV: <asp:TextBox ID="CVV" runat="server" Enabled="true" Placeholder="XXX" MaxLength="3"></asp:TextBox>
        </h3>
            <h3> Fecha de exp. <asp:TextBox ID="MM" runat="server" Placeholder="MM" MaxLength="2" Width="50px"></asp:TextBox><asp:TextBox ID="DD" runat="server" Placeholder="DD" MaxLength="2" Width="50px"></asp:TextBox><asp:TextBox ID="YY" runat="server" Placeholder="YYYY" MaxLength="4" Width="75px"></asp:TextBox>
           </h3>
        <asp:Button ID="btnRealizarPago" runat="server" Text="Realizar pago" OnClick="btnRealizarPago_Click" />
        </div>
    </div>
</asp:Content>
