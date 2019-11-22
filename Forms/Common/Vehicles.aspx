<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/PageContent.Master" AutoEventWireup="true" CodeBehind="Vehicles.aspx.cs" Inherits="WebVehicles.Forms.Common.Vehicles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Vehiculos - Sistema Vehicular</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CustomStyle" runat="server">
    <link href="../../Content/css/Main.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div class="container" style="background:#FFF">
        <br />
        <div class="panel panel-primary">
            <div class="panel-heading h3 text-center">Gestión de Vehiculos</div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                        <main role="main" class="container">
                            <div class="my-3 p-3 bg-white rounded shadow-sm">
                            <h6 class="border-bottom border-gray pb-2 mb-0">Operaciones</h6>

                            <div class="media text-muted pt-3">
                                <i class="fa fa-plus fa-2x rounded mr-2"></i>
                                <div class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
                                    <div class="d-flex justify-content-between align-items-center w-100">
                                        <strong class="text-gray-dark">Agregar un vehiculo</strong>
                                        <a class="btn btn-outline-info btn-sm" href="AddVehicle.aspx">Agregar</a>
                                    </div>
                                    <span class="d-block ">@AddVehicle</span>
                                </div>
                            </div>

                            <div class="media text-muted pt-3">
                                <i class="fa fa-wrench fa-2x rounded mr-2"></i>
                                <div class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
                                    <div class="d-flex justify-content-between align-items-center w-100">
                                        <strong class="text-gray-dark">Actualizar un vehiculo</strong>
                                        <a class="btn btn-outline-info btn-sm" href="UpdateVehicle.aspx">Actualizar</a>
                                    </div>
                                    <span class="d-block ">@UpdateVehicle</span>
                                </div>
                            </div>

                            <div class="media text-muted pt-3">
                                <i class="fa fa-trash fa-2x rounded mr-2"></i>
                                <div class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
                                    <div class="d-flex justify-content-between align-items-center w-100">
                                        <strong class="text-gray-dark">Eliminar un vehiculo</strong>
                                        <a class="btn btn-outline-info btn-sm" href="#" data-toggle="modal" data-target="#DelVehicleModal"><span class=""></span> Eliminar</a>
                                    </div>
                                    <span class="d-block ">@DeleteVehicle</span>
                                </div>
                            </div>

                        </div>
                    </main> 
                </div>
            </div>
            <br />
        </div>
    </div>
</div>

<!-- Start of DelVehicleModal -->
<div class="modal fade alert-danger bg-transparent show" id="DelVehicleModal" tabindex="-3" role="dialog" aria-labelledby="DelVehicleModalLab" aria-hidden="false">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="DelVehicleModalLab">Eliminar Vehiculo</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body modalMsg">
                <form id="formDelVehicle" runat="server">
                    <div class="form-group">
                        <label for="inputVehicleID" class="col-form-label">Placa:</label>
                        <asp:TextBox ID="inputVehicleID" CssClass="form-control" runat="server"></asp:TextBox>
                        <small id="emailHelp2" class="form-text text-muted">Esta acción no se puede deshacer.</small>
                    </div>
                    <div class="form-group">
                        <button type="button" class="form-control form-control-sm btn btn-outline-secondary btn-sm" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="BtnDelVehicle" runat="server" CssClass="form-control form-control-sm btn btn-outline-danger btn-sm" Text="Eliminar" OnClick="BtnDelVehicle_Click"/>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>
<!-- End of DelUserModal -->

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CustomScript" runat="server">
<script src="../../Content/js/Main.js"></script>  
</asp:Content>