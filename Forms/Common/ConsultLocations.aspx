﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/PageContent.Master" AutoEventWireup="true" CodeBehind="ConsultLocations.aspx.cs" Inherits="WebVehicles.Forms.Common.ConsultLocations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Consultar Localizaciones - Sistema Vehicular</title>
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
        <div class="panel-heading h3 text-center">Consultas de Localizaciones</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                    <main role="main" class="container">
                        <div class="my-3 p-3 bg-white rounded shadow-sm">
                            <h6 class="border-bottom border-gray pb-2 mb-0">Operaciones</h6>

                             <div class="media text-muted pt-3">
                                <i class="fa fa-search fa-2x rounded mr-2"></i>
                                <div class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
                                    <div class="d-flex justify-content-between align-items-center w-100">
                                        <strong class="text-gray-dark">Consultar por ID</strong>
                                        <a class="btn btn-outline-info btn-sm" href="ConsultLocationsID.aspx"><span class=""></span> Mostrar</a>
                                    </div>
                                    <span class="d-block ">@ConsultLocationsID</span>
                                </div>
                            </div>
                        <% if (user.RoleID == 1) { %> 
                            <div class="media text-muted pt-3">
                                <i class="fa fa-search fa-2x rounded mr-2"></i>
                                <div class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
                                    <div class="d-flex justify-content-between align-items-center w-100">
                                        <strong class="text-gray-dark">Consultar por fecha de ingreso</strong>
                                        <a class="btn btn-outline-info btn-sm" href="ConsultLocationsDate.aspx"><span class=""></span> Mostrar</a>
                                    </div>
                                    <span class="d-block ">@ConsultLocationsDate</span>
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
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CustomScript" runat="server">
    <script src="../../Content/js/Main.js"></script> 
</asp:Content>
