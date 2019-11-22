<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/PageContent.Master" AutoEventWireup="true" CodeBehind="ConsultUsersID.aspx.cs" Inherits="WebVehicles.Forms.Common.ConsultUsersID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Consultar Usuarios por Cedula - Sistema Vehicular</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CustomStyle" runat="server">
    <link href="../../Content/css/Main.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
<div class="container" style="background:#FFF">
    <br />
    <div class="row">
        <div class="col-2"></div>
        <div class="col-8">
            <div class="panel panel-primary">
                   <form runat="server" id="form1">
                    <div class="panel-heading h3">Consulta de usuario por cédula</div>
                    <div class="panel-body">
                         <div class="form-row">
                             <div class="col-md-3 mb-3 md-form">
                                <label for="TxtUserID">Identificación:</label>
                            </div>
                            <div class="col-md-5 mb-5 md-form">
                                <asp:TextBox ID="TxtUserID" runat="server" CssClass="form-control form-control-sm" placeholder="x xxxx xxxx"></asp:TextBox>
                            </div>
                            <div class="col-md2 mb-2 md-form">
                                <asp:LinkButton ID="BtnBuscar" CssClass="form-control form-control-sm btn btn-info btn-sm" runat="server" Text="Buscar" OnClick="BtnBuscar_click"></asp:LinkButton>
                            </div>
                             <div class="col-md2 mb-2 md-form">
                                <asp:LinkButton ID="BtnImprimir" CssClass="form-control form-control-sm btn btn-info btn-sm" runat="server" Text="Imprimir" OnClick="BtnImprimir_click"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-5 mb-5 md-form">
                                <label for="TxtFullname">Nombre:</label>
                                <asp:Label ID="TxtFullname" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Nombre completo]</asp:Label>
                            </div>
                            <div class="col-md-4 mb-4 md-form">
                                <label for="TxtNationality">Nacionalidad: </label>
                                <asp:Label ID="TxtNationality" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Nacionalidad]</asp:Label>
                            </div>
                            <div class="col-md-3 mb-3 md-form">
                                <label for="TxtPhone">Teléfono: </label>
                                <asp:Label ID="TxtPhone" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Telefono]</asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-6 mb-6 md-form">
                                <label for="TxtDateofborn">Fecha de nacimiento: </label>
                                <asp:Label ID="TxtDateofborn" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Cumpleaños]</asp:Label>
                            </div>
                             <div class="col-md-6 mb-6 md-form">
                                <label for="TxtEmail">Email: </label>
                                <asp:Label ID="TxtEmail" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Correo]</asp:Label>
                            </div>
                        </div>  

                         <div class="form-row">
                             <div class="col-md-6 mb-6 md-form">
                                <label for="TxtDriverLicenseID">Licencia de conducir: </label>
                                <asp:Label ID="TxtDriverLicenseID" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Licencia de conducir]</asp:Label>
                            </div>

                            <div class="col-md-3 mb-3 md-form">
                                <label for="TxtRoleID">Rol: </label>
                                <asp:Label ID="TxtRoleID" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Rol]</asp:Label>
                            </div>

                            <div class="col-md-3 mb-3 md-form">
                                <label for="TxtConditionID">Condición: </label>
                                <asp:Label ID="TxtConditionID" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Estado]</asp:Label>
                            </div>
                        </div>

                    </div>
                </form>        
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CustomScript" runat="server">
    <script src="../../Content/js/Main.js"></script> 
</asp:Content>