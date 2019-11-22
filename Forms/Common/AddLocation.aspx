<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/PageContent.Master" AutoEventWireup="true" CodeBehind="AddLocation.aspx.cs" Inherits="WebVehicles.Forms.Common.AddLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Agregar Localización - Sistema Vehicular</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CustomStyle" runat="server">
    <link href="../../Content/css/Main.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.6.0/dist/leaflet.css"/>
    <!-- Make sure you put this AFTER Leaflet's CSS -->
    <script src="https://unpkg.com/leaflet@1.6.0/dist/leaflet.js"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
<div class="container" style="background:#FFF">    
    <br />
    <div class="row">
        <div class="col-2"></div>
        <div class="col-8">
            <div class="panel panel-primary">
                   <form runat="server" id="form1">
                    <div class="panel-heading h3">Agregar una localización</div>
                    <div class="panel-body">
                        <div class="form-row">
                            <div class="col-md-4 mb-4 md-form">
                                <label for="inputTravelID">ID de Viaje</label>
                                <asp:TextBox ID="inputTravelID" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                <asp:Button ID="BtnBuscar" runat="server" CssClass="form-control form-control-sm btn btn-outline-success btn-sm" Text="Buscar" OnClick="BtnBuscar_Click"/>                            
                            </div>
                            <div class="col-md-8 mb-8 md-form">
                                <label for="inputName">Nombre</label>
                                <asp:TextBox ID="inputName" runat="server" CssClass="form-control form-control-sm" placeholder="nombre del lugar"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-12 mb-12 md-form">
                                <label for="inputAddress">Dirección local</label>
                                <asp:TextBox ID="inputAddress" runat="server" CssClass="form-control form-control-sm" placeholder="direccion del lugar"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="col-md-6 mb-6 md-form">
                                <label for="inputLatitude">Latitud</label>
                                <asp:TextBox ID="inputLatitude" runat="server" CssClass="form-control form-control-sm" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-6 md-form">
                                <label for="inputLongitude">Longitud</label>
                                <asp:TextBox ID="inputLongitude" runat="server" CssClass="form-control form-control-sm" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>  

                        <div class="form-row">
                            <div class="col-sm-12 col-md-12 md-form">
                                <div id="mapid" style="min-width: 300px; min-height: 500px;"></div>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="col-md-8 mb-3 md-form"></div>
                            <div class="col-md-2 mb-3 md-form">
                                 <label>_</label>
                                <asp:Button ID="BtnCancelar" runat="server" CssClass="form-control form-control-sm btn btn-outline-secondary btn-sm" Text="Cancelar" OnClick="BtnCancelar_Click"/>
                            </div>
                            <div class="col-md-2 mb-3 md-form">
                                 <label>_</label>
                                <asp:Button ID="BtnAddLocation" runat="server" CssClass="form-control form-control-sm btn btn-outline-success btn-sm" Text="Agregar" OnClick="BtnAddLocation_Click"/>
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
<script>

    var mymap = L.map('mapid').setView([9.988, -85.330], 7);

    L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw', {
        maxZoom: 18,
        attribution: '&copy <a href="https://www.openstreetmap.org/">OpenStreetMap</a>, ' +
            '<a >Implementado por: Eddie Alfaro</a> ',
        id: 'mapbox.streets'
    }).addTo(mymap);

    var popup = L.popup();

    function onMapClick(e) {
        popup
            .setLatLng(e.latlng)
            .setContent("Esta es la posición: " + e.latlng.toString())
            .openOn(mymap);
        $("input[id$='inputLatitude']").val(e.latlng.lat.toString());
        $("input[id$='inputLongitude']").val(e.latlng.lng.toString());
  
    }

    mymap.on('click', onMapClick);
           
</script>
</asp:Content>
