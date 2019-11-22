<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/PageContent.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="WebVehicles.Forms.Common.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Agregar Usuario - Sistema Vehicular</title>
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
                    <div class="panel-heading h3">Agregar un usuario</div>
                    <div class="panel-body">
                        <div class="form-row">
                            <div class="col-md-4 mb-3 md-form">
                                <label for="inputUserID">Identificación</label>
                                <asp:TextBox ID="inputUserID" runat="server" CssClass="form-control form-control-sm" placeholder="x xxxx xxxx"></asp:TextBox>
                            </div>
                            <div class="col-md-4 mb-3 md-form">
                                <label for="inputName">Nombre</label>
                                <asp:TextBox ID="inputName" runat="server" CssClass="form-control form-control-sm" placeholder="name"></asp:TextBox>
                            </div>
                            <div class="col-md-4 mb-3 md-form">
                                <label for="inputLastname">Apellido</label>
                                <asp:TextBox ID="inputLastname" runat="server" CssClass="form-control form-control-sm" placeholder="lastname"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-8 mb-3 md-form">
                                <label for="inputEmail">Email</label>
                                <asp:TextBox ID="inputEmail" runat="server" TextMode="Email" CssClass="form-control form-control-sm" placeholder="noreply@example.com"></asp:TextBox>
                            </div>
                            <div class="col-md-4 mb-3 md-form">
                                <label for="inputPhone">Teléfono</label>
                                <asp:TextBox ID="inputPhone" runat="server" CssClass="form-control form-control-sm" placeholder="0000 0000"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-8 mb-3 md-form">
                                <label for="inputDateofborn">Fecha de nacimiento</label>
                                <asp:TextBox ID="inputDateofborn" runat="server" TextMode="Date" CssClass="form-control form-control-sm"></asp:TextBox>
                            </div>
                            <div class="col-md-4 mb-3 md-form">
                                 <label for="inputNationality">Nacionalidad</label>
                                <asp:DropDownList ID="inputNationality" runat="server" CssClass="form-control form-control-sm">
                                    <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Costarricense" Value="Costarricense"></asp:ListItem>
                                 </asp:DropDownList>
                            </div>
                        </div>  

                        <div class="form-row">
                            <div class="col-md-4 mb-3 md-form">
                                <label for="inputRoleID">Rol</label>
                                <asp:DropDownList ID="inputRoleID" runat="server" CssClass="form-control form-control-sm">
                                    <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Administrador" Value ="1"></asp:ListItem>
                                    <asp:ListItem Text="Conductor" Value ="2"></asp:ListItem>
                                    </asp:DropDownList>
                            </div>

                            <div class="col-md-4 mb-3 md-form">
                                <label for="inputConditionID">Condición</label>
                                <asp:DropDownList ID="inputConditionID" runat="server" CssClass="form-control form-control-sm">
                                    <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Activo" Value ="1"></asp:ListItem>
                                    <asp:ListItem Text="Inactivo" Value ="2"></asp:ListItem>
                                 </asp:DropDownList>
                            </div>

                            <div class="col-md-4 mb-3 md-form">
                                <label for="inputDriverLicenseID">Licencia de conducir</label>
                                <asp:DropDownList ID="inputDriverLicenseID" runat="server" CssClass="form-control form-control-sm">
                                    <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                                    <asp:ListItem Text="A2" Value ="1"></asp:ListItem>
                                    <asp:ListItem Text="B1" Value ="2"></asp:ListItem>
                                    <asp:ListItem Text="B2" Value ="3"></asp:ListItem>
                                    <asp:ListItem Text="A2 y B1" Value ="4"></asp:ListItem>
                                    <asp:ListItem Text="A2 y B2" Value ="5"></asp:ListItem>
                                 </asp:DropDownList>
                            </div>

                        </div>
                        <div class="form-row">
                            <div class="col-md-8 mb-3 md-form">
                            </div>
                            <div class="col-md-2 mb-3 md-form">
                                 <label>_</label>
                                <asp:Button ID="Button1" runat="server" CssClass="form-control form-control-sm btn btn-outline-secondary btn-sm" Text="Cancelar" OnClick="BtnCancelar_Click"/>
                            </div>
                            <div class="col-md-2 mb-3 md-form">
                                 <label>_</label>

                                <asp:Button ID="BtnAddUser" runat="server" CssClass="form-control form-control-sm btn btn-outline-success btn-sm" Text="Agregar" OnClick="BtnAddUser_Click"/>
                            </div>
                        </div> 
                    </div>
                       <div class="panel-footer">
                           
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
