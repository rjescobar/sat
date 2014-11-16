<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManualDataAccess.aspx.cs" Inherits="Sat.Web.Modulo.DataAccess.ManualDataAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <table class="table table-condensed" 
        clientidmode="Static" 
        id="tblSolicitudes" runat="server">
        <tr>
            <th>Codigo de Empleado</th>
            <th>Solicitud</th>
            <th>Fecha de Creación</th>
        </tr>
    </table>
</asp:Content>
