<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/PageContent.Master" AutoEventWireup="true" CodeBehind="Locations.aspx.cs" Inherits="WebVehicles.Forms.Common.Locations" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Localizaciones - Sistema Vehicular</title>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CustomStyle" runat="server">
    <link href="../../Content/css/Main.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
<%
    User user = new User();
    user = (User)Session["CurrentUser"];
%>
    <div class="container" style="background:#FFF">
        <br />
        <div class="panel panel-primary">
            <div class="panel-heading h3 text-center">Gestión de Localizaciones</div>
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
                                        <strong class="text-gray-dark">Agregar una localizacion</strong>
                                        <a class="btn btn-outline-info btn-sm" href="AddLocation.aspx"><span class=""></span> Agregar</a>
                                    </div>
                                    <span class="d-block ">@AddLocation</span>
                                </div>
                            </div>
                        <% if (user.RoleID == 1) { %> 
                            <div class="media text-muted pt-3">
                                <i class="fa fa-pencil fa-2x rounded mr-2"></i>
                                <div class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
                                    <div class="d-flex justify-content-between align-items-center w-100">
                                        <strong class="text-gray-dark">Actualizar una localizacion</strong>
                                        <a class="btn btn-outline-info btn-sm" href="UpdateLocation.aspx"><span class=""></span> Actualizar</a>
                                    </div>
                                    <span class="d-block ">@UpdateLocation</span>
                                </div>
                            </div>

                            <div class="media text-muted pt-3">
                                <i class="fa fa-trash fa-2x rounded mr-2"></i>
                                <div class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
                                    <div class="d-flex justify-content-between align-items-center w-100">
                                        <strong class="text-gray-dark">Eliminar una localizacion</strong>
                                        <a class="btn btn-outline-info btn-sm" href="#" data-toggle="modal" data-target="#DelLocationModal"><span class=""></span> Eliminar</a>
                                    </div>
                                    <span class="d-block ">@DeleteLocation</span>
                                </div>
                            </div>
                        <% } %>
                        </div>
                    </main> 
                        
                </div>
                     
            </div>
            <br />
        </div>
    </div>
</div>

<!-- Start of DelLocationModal -->
<div class="modal fade alert-danger bg-transparent" id="DelLocationModal" tabindex="-3" role="dialog" aria-labelledby="DelLocationModalLab" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="DelLocationModalLab">Eliminar Localización</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <form>
                    <div class="form-group">
                        <label for="recipient-del" class="col-form-label">ID:</label>
                        <input type="text" class="form-control" id="recipient-del">
                        <small id="emailHelp2" class="form-text text-muted">Esta acción no se puede deshacer.</small>
                    </div>
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                <button id="btnDelLocation" type="button" class="btn btn-danger">Eliminar</button>
            </div>
        </div>
    </div>
</div>
<!-- End of DelUserModal -->
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CustomScript" runat="server">
<script src="../../Content/js/Main.js"></script>  
<script>
    $(function () {
        'use strict';
        window.addEventListener('load', function () {
            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = $('.needs-validation');
            // Loop over them and prevent submission
            var validation = Array.prototype.filter.call(forms, function (form) {
                form.addEventListener('submit', function (event) {
                    if (form.checkValidity() === false) {
                        event.preventDefault();
                        event.stopPropagation();
                    }
                    form.classList.add('was-validated');
                }, false);
            });
        }, false);
    });
</script>
</asp:Content>