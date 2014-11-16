<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataSample.aspx.cs" Inherits="Sat.Web.Modulo.DataAccess.DataSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="container-fluid">
        <label>Seleccione un empleado</label>
        <asp:DropDownList ID="ddlEmpleados" runat="server"
            DataSourceID="EntityDataSource1"
            DataTextField="NombreCompleto"
            DataValueField="cod_emp"
            AutoPostBack="True">
        </asp:DropDownList>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server"
            ConnectionString="name=AsistenciaTecnicaEntities"
            DefaultContainerName="AsistenciaTecnicaEntities"
            EnableFlattening="False"
            EntitySetName="Empleados"
            EntityTypeFilter="Empleados">
        </asp:EntityDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="IdSolicitud" DataSourceID="EntityDataSource2" AllowPaging="True" AllowSorting="True" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEditarManual" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Cod_emp") %>' >Editar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="IdSolicitud" HeaderText="IdSolicitud" ReadOnly="True" SortExpression="IdSolicitud" />
                <asp:BoundField DataField="Cod_emp" HeaderText="Codigo Empleado" SortExpression="Cod_emp" />
                <asp:BoundField DataField="Solicitud1" HeaderText="Solicitud" SortExpression="Solicitud1" />
                <asp:TemplateField HeaderText="FechaCreacion" SortExpression="FechaCreacion">
                    <ItemTemplate>
                        <asp:Label ID="HyperLink1" runat="server" Text='<%# Eval("FechaCreacion", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="HoraCreacion" HeaderText="HoraCreacion" SortExpression="HoraCreacion" />
                <asp:BoundField DataField="FechaAsignacion" HeaderText="FechaAsignacion" SortExpression="FechaAsignacion" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="Empleados" HeaderText="Empleados" SortExpression="Empleados" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>

        <br />

        <asp:DetailsView ID="DetailsView1" CssClass="table" runat="server" AutoGenerateRows="False" DataKeyNames="IdSolicitud" DataSourceID="EntityDataSource3" Height="50px">
            <Fields>
                <asp:BoundField DataField="IdSolicitud" HeaderText="IdSolicitud" ReadOnly="True" SortExpression="IdSolicitud" />
                <asp:BoundField DataField="Cod_emp" HeaderText="Cod_emp" SortExpression="Cod_emp" />
                <asp:BoundField DataField="Solicitud1" HeaderText="Solicitud1" SortExpression="Solicitud1" />
                <asp:BoundField DataField="FechaCreacion" HeaderText="FechaCreacion" SortExpression="FechaCreacion" />
                <asp:BoundField DataField="HoraCreacion" HeaderText="HoraCreacion" SortExpression="HoraCreacion" />
                <asp:TemplateField HeaderText="IdResponsable" SortExpression="IdResponsable">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IdResponsable") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IdResponsable") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("IdResponsable") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="IdTecnico" HeaderText="IdTecnico" SortExpression="IdTecnico" />
                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" SortExpression="Observaciones" />
                <asp:BoundField DataField="FechaAsignacion" HeaderText="FechaAsignacion" SortExpression="FechaAsignacion" />
                <asp:BoundField DataField="HoraAsignacion" HeaderText="HoraAsignacion" SortExpression="HoraAsignacion" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="Cod_Equipo" HeaderText="Cod_Equipo" SortExpression="Cod_Equipo" />
                <asp:BoundField DataField="FechaElaborado" HeaderText="FechaElaborado" SortExpression="FechaElaborado" />
                <asp:BoundField DataField="HolaElaborado" HeaderText="HolaElaborado" SortExpression="HolaElaborado" />
                <asp:BoundField DataField="Evaluacion1" HeaderText="Evaluacion1" SortExpression="Evaluacion1" />
                <asp:BoundField DataField="Evaluacion2" HeaderText="Evaluacion2" SortExpression="Evaluacion2" />
                <asp:BoundField DataField="Evaluacion3" HeaderText="Evaluacion3" SortExpression="Evaluacion3" />
                <asp:BoundField DataField="FechaEvaluacion" HeaderText="FechaEvaluacion" SortExpression="FechaEvaluacion" />
                <asp:BoundField DataField="HoraEvaluacion" HeaderText="HoraEvaluacion" SortExpression="HoraEvaluacion" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>

        <br />

    </div>

    <asp:EntityDataSource ID="EntityDataSource2" runat="server"
        ConnectionString="name=AsistenciaTecnicaEntities"
        DefaultContainerName="AsistenciaTecnicaEntities" EnableDelete="True"
        EnableFlattening="False" EnableInsert="True" EnableUpdate="True"
        EntitySetName="Solicitud" EntityTypeFilter="Solicitud" AutoGenerateWhereClause="True" Select="" Where="" OnSelecting="EntityDataSource2_Selecting" Include="Empleados">
        <WhereParameters>
            <asp:ControlParameter ControlID="ddlEmpleados" Name="Cod_emp" PropertyName="SelectedValue" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>
    <br />

    <asp:EntityDataSource ID="EntityDataSource3" runat="server" ConnectionString="name=AsistenciaTecnicaEntities" DefaultContainerName="AsistenciaTecnicaEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Solicitud" AutoGenerateWhereClause="True" EntityTypeFilter="" Select="" Where="">
        <WhereParameters>
            <asp:ControlParameter ControlID="GridView1" Name="IdSolicitud" PropertyName="SelectedValue" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
