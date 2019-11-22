<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/PageContent.Master" AutoEventWireup="true" CodeBehind="ConsultVehiclesID.aspx.cs" Inherits="WebVehicles.Forms.Common.ConsultVehiclesID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Consultar Vehiculos por Placa - Sistema Vehicular</title>
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
                    <div class="panel-heading h3">Consulta de vehiculo por placa</div>
                    <div class="panel-body">
                         <div class="form-row">
                             <div class="col-md-3 mb-3 md-form">
                                <label for="TxtVehicleID">Placa:</label>
                            </div>
                            <div class="col-md-5 mb-5 md-form">
                                <asp:TextBox ID="TxtVehicleID" runat="server" CssClass="form-control form-control-sm" placeholder="xxx xxx"></asp:TextBox>
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
                                <label for="TxtType">Tipo:</label>
                                <asp:Label ID="TxtType" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Tipo]</asp:Label>
                            </div>
                            <div class="col-md-4 mb-4 md-form">
                                <label for="TxtBrand">Marca: </label>
                                <asp:Label ID="TxtBrand" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Marca]</asp:Label>
                            </div>
                            <div class="col-md-3 mb-3 md-form">
                                <label for="TxtYear">Modelo: </label>
                                <asp:Label ID="TxtYear" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Modelo]</asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-6 mb-6 md-form">
                                <label for="TxtEngine">Motor: </label>
                                <asp:Label ID="TxtEngine" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Motor]</asp:Label>
                            </div>
                             <div class="col-md-6 mb-6 md-form">
                                <label for="TxtTransmission">Transmisión: </label>
                                <asp:Label ID="TxtTransmission" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Transmisión]</asp:Label>
                            </div>
                        </div>  

                         <div class="form-row">
                             <div class="col-md-6 mb-6 md-form">
                                <label for="TxtFuel">Combustible: </label>
                                <asp:Label ID="TxtFuel" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Combustible]</asp:Label>
                            </div>

                            <div class="col-md-3 mb-3 md-form">
                                <label for="TxtFuelTank">Tanque: </label>
                                <asp:Label ID="TxtFuelTank" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Tanque]</asp:Label>
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
