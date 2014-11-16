<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Sat.Web.Error" %>

<%@ Import Namespace="System.Web.Optimization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página de Error</title>
    <%: Styles.Render("~/bundles/styles") %>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span>Ha ocurrido un error en la aplicación.</span>
            <br />
            Tipo de error:
            <asp:Label ID="lblExceptionType" runat="server" Text="Label"></asp:Label>
            <br/>
            Mensajes:
            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
            <br/>

            <a href="Default2.aspx">Ir a inicio.</a>

        </div>
    </form>
</body>
</html>
