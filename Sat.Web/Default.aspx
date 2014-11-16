<%@ Page Title="" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Sat.Web.Default" 
    %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--Enlaces a otro contenido, css, js-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-horizontal" role="form">
            <div class="form-group">
                <label class="col-sm-2 control-label">Email:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtEmail"
                        ClientIDMode="Static"
                        CssClass="form-control"
                        placeholder="Email" runat="server" EnableViewState="False">
                    </asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="El email no tiene formato valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2 control-label">Contraseña:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2 control-label">Nombre:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Este campo es requerido."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2 control-label">Apelldo:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApellido" ErrorMessage="Este campo es requerido. Apellido"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2 control-label">Cédula:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtCedula" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCedula" ErrorMessage="La cédula no puede ser vacia."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCedula" ValidationExpression="\d{3}-\d{6}-\d{4}\w{1}" ErrorMessage="El formato de cedula no es valido"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="chkRemember" Text="Recuerdame" runat="server" />
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnEnviar" CssClass="btn btn-primary" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>




    <!--Cuerpo de la pagina-->

</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="Footer">
    <p>Aqui va el footer</p>
</asp:Content>
