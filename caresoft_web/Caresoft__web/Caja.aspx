<%@ Page Title="Caja" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Caja.aspx.cs" Inherits="Caresoft__web.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Caja</h1>
    <div class="menu">
        <table id="tblDatos" class="table" runat="server">
            <thead>
                <tr>
                    <th>Concepto</th>
                    <th>Monto</th>
                </tr>
            </thead>
            <tbody>
                <!-- Data rows will be added dynamically from code-behind -->
            </tbody>
        </table>
        <asp:Button ID="btnPagar" runat="server" Text="Pagar" OnClick="pagar_Click" />
    </div>
</asp:Content>
