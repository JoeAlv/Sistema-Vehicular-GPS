<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/PageContent.Master" AutoEventWireup="true" CodeBehind="UpdateTravel.aspx.cs" Inherits="WebVehicles.Forms.Common.UpdateTravel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Actualizar Viaje - Sistema Vehicular</title>
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
                    <div class="panel-heading h3">Actualizar un viaje</div>
                    <div class="panel-body">
                         <div class="form-row">
                            <div class="col-md-4 mb-4 md-form">
                                <label for="inputTravelID">ID del viaje:</label>
                                <asp:TextBox ID="inputTravelID" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                <asp:Button ID="BtnBuscarT" runat="server" CssClass="form-control form-control-sm btn btn-outline-success btn-sm" Text="Buscar viaje" OnClick="BtnBuscarT_Click"/>                            
                            </div>
                            <div class="col-md-4 mb-4 md-form">
                                <label for="inputUserID">Cédula del usuario:</label>
                                <asp:TextBox ID="inputUserID" runat="server" CssClass="form-control form-control-sm" ReadOnly="true"></asp:TextBox>
                            </div>
                             <div class="col-md-4 mb-4 md-form">
                                <label for="inputVehicleID">Placa del vehiculo:</label>
                                <asp:TextBox ID="inputVehicleID" runat="server" CssClass="form-control form-control-sm" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>

                        
                        <div class="form-row">
                            <div class="col-md-8 mb-3 md-form">
                                <label for="inputConditionID">Estado:</label>
                                <asp:DropDownList ID="inputConditionID" runat="server" CssClass="form-control form-control-sm">
                                    <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Inactivo" Value="2"></asp:ListItem>
                                 </asp:DropDownList>
                            </div>
                            <div class="col-md-2 mb-3 md-form">
                                 <label>_</label>
                                <asp:Button ID="BtnCancelar" runat="server" CssClass="form-control form-control-sm btn btn-outline-secondary btn-sm" Text="Cancelar" OnClick="BtnCancelar_Click"/>
                            </div>
                            <div class="col-md-2 mb-3 md-form">
                                 <label>_</label>
                                <asp:Button ID="BtnUpdateTravel" runat="server" CssClass="form-control form-control-sm btn btn-outline-success btn-sm" Text="Actualizar" OnClick="BtnUpdateTravel_Click"/>
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
