<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/PageContent.Master" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="WebVehicles.Forms.Common.Support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
     <title>Soporte - Sistema Vehicular</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CustomStyle" runat="server">
    <link href="../../Content/css/Main.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
<div class="container" style="background:#FFF">
    <br />
    <div class="panel panel-primary">
        <div class="panel-heading h3 text-center">Soporte del sistema</div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                        <main role="main" class="container">
                            <div class="my-3 p-3 bg-white rounded shadow-sm">
                            <h6 class="border-bottom border-gray pb-2 mb-0">Operaciones</h6>

                            <div class="media text-muted pt-3">
                                <i class="fa fa-user-plus fa-2x rounded mr-2"></i>
                                <div class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
                                    <div class="d-flex justify-content-between align-items-center w-100">
                                        <strong class="text-gray-dark">Información del sistema</strong>
                                        <a class="btn btn-outline-info btn-sm" href="#" data-toggle="modal" data-target="#SystemInfoModal">Mostrar</a>
                                    </div>
                                    <span class="d-block ">@SystemInfo</span>
                                </div>
                            </div>

                            <div class="media text-muted pt-3">
                                <i class="fa fa-edit fa-2x rounded mr-2"></i>
                                <div class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
                                    <div class="d-flex justify-content-between align-items-center w-100">
                                        <strong class="text-gray-dark">Documentación</strong>
                                        <a class="btn btn-outline-info btn-sm" href="#" data-toggle="modal" data-target="#DocsModal">Mostrar</a>
                                    </div>
                                    <span class="d-block ">@Docs</span>
                                </div>
                            </div>

                            <div class="media text-muted pt-3">
                                <i class="fa fa-user-times fa-2x rounded mr-2"></i>
                                <div class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
                                    <div class="d-flex justify-content-between align-items-center w-100">
                                        <strong class="text-gray-dark">Reportar problema</strong>
                                        <a class="btn btn-outline-info btn-sm" href="#" data-toggle="modal" data-target="#ReportIssueModal">Reportar</a>
                                    </div>
                                    <span class="d-block ">@ReportIssue</span>
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

<!-- Start of SystemInfoModal -->
<div class="modal fade alert-info bg-transparent" id="SystemInfoModal" tabindex="-3" role="dialog" aria-labelledby="SystemInfoModalLab" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="SystemInfoModalLab">Información de Sistema</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                Universidad Nacional, Campus Nicoya<br />
                Ingeniería en Sistemas de Información, EIF407 Programación III<br />
                Proyecto Final Programado<br />
                Desarrollador: Eddie Alfaro Villegas
                <br />
                <br />
                Generalidades de proyecto:  <br />
                a. El sistema será representando por un aplicativo web, utilizando formularios web / interfaces HTML5/CSS3/Jquery/Bootstrap, entre otros.  <br />
                b. Se deben utilizar capas y servicios web (WCF).  <br />
                c. Las interfaces del aplicativo deben ser responsivas. Tanto el menú como sus formularios.   <br />
                d. Los proyectos serán individuales o máximo en parejas. No se permite, bajo ningún motivo, grupos mayores de 2 personas.  <br />
                e. El sistema deberá dar mantenimiento al menos a dos tablas maestras y una tabla de movimientos para proyectos individuales. <br />
                f. El sistema deberá dar mantenimiento al menos a tres tablas maestras y dos tabla de movimientos para proyectos en parejas.  <br />
                g. Debe realizarse el CRUD para cada tabla. h. Deben crearse las consultas con sus respectivos reportes.
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>
<!-- End of SystemInfoModal -->

<!-- Start of DocsModal -->
<div class="modal fade alert-dark bg-transparent" id="DocsModal" tabindex="-3" role="dialog" aria-labelledby="DocsModalLab" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="DocsModalLab">Documentación de Sistema</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                Documentación General del Sistema
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>
<!-- End of ReportIssueModal -->

<!-- Start of DocsModal -->
<div class="modal fade alert-dark bg-transparent" id="ReportIssueModal" tabindex="-3" role="dialog" aria-labelledby="ReportIssueModalLab" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="ReportIssueModalLab">Reportar Problema</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                Reporte su problema
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>
<!-- End of SystemInfoModal -->
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CustomScript" runat="server">
    <script src="../../Content/js/Main.js"></script> 
</asp:Content>
