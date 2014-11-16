<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sat.Web.Login" %>

<%@ Import Namespace="System.Web.Optimization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <%: Styles.Render("~/bundles/styles") %>
    <%: Scripts.Render("~/bundles/scripts") %>
</head>
<body>
    <style>
        .middle-login {
            width: 430px;
            left: 50%;
            top: 50%;
            position: absolute;
            margin-top: -150px;
            margin-left: -215px;
        }
    </style>
    <div class="middle-login">
        <form id="form1" class="form-horizontal" runat="server">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Login</h4>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="col-sm-12">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                <asp:TextBox ID="txtUsuario" Placehoder="Usuario" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:RequiredFieldValidator CssClass="field-validation-error" ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Usuario no puede ser vacio" ControlToValidate="txtUsuario" Display="Dynamic"></asp:RequiredFieldValidator>

                    <div class="form-group">
                        <div class="col-sm-12">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                <asp:TextBox ID="txtClave" Placehoder="Contraseña" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="field-validation-error" ErrorMessage="Clave no puede ser vacio" ControlToValidate="txtClave" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="panel-footer" style="text-align: right">
                    <asp:Button ID="loginButton" runat="server" class="btn btn-default" data-dismiss="modal" type="button" Text="Entrar" OnClick="loginButton_Click"></asp:Button>
                    <asp:Button ID="btnRecordar" runat="server" CssClass="btn btn-link" Text="Recordar" />
                </div>
            </div>
        </form>
    </div>
</body>
</html>
