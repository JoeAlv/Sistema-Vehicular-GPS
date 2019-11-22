<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/PageContent.Master" AutoEventWireup="true" CodeBehind="ConsultLocationsID.aspx.cs" Inherits="WebVehicles.Forms.Common.ConsultLocationsID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Consultar Localizaciones por ID - Sistema Vehicular</title>
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
                    <div class="panel-heading h3">Consulta de localización por ID</div>
                    <div class="panel-body">
                         <div class="form-row">
                             <div class="col-md-3 mb-3 md-form">
                                <label for="TxtLocationID">ID de la ubicación:</label>
                            </div>
                            <div class="col-md-6 mb-6 md-form">
                                <asp:TextBox ID="TxtLocationID" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                            </div>
                            <div class="col-md-3 mb-3 md-form">
                                <asp:LinkButton ID="BtnBuscar" CssClass="form-control form-control-sm btn btn-info btn-sm" runat="server" Text="Buscar" OnClick="BtnBuscar_click"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-5 mb-5 md-form">
                                <label for="inputName">Nombre:</label>
                                <asp:TextBox ID="inputName" BackColor="#FFFFCC" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-7 mb-7 md-form">
                                <label for="inputAddress">Dirección: </label>
                                <asp:TextBox ID="inputAddress" BackColor="#FFFFCC" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-4 mb-4 md-form">
                                <label for="inputLatitude">Latitud:</label>
                                <asp:TextBox ID="inputLatitude" BackColor="#FFFFCC" BorderColor="Black" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
                            </div>
                             <div class="col-md-4 mb-4 md-form">
                                <label for="inputLongitude">Longitud:</label>
                                <asp:TextBox ID="inputLongitude" BackColor="#FFFFCC" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-4 mb-4 md-form">
                                <label for="TxtTravelID">ID Viaje: </label>
                                <asp:Label ID="TxtTravelID" BackColor="#FFFFCC"  runat="server">[Id Viaje]</asp:Label>
                            </div>
                        </div>  
                        <div class="form-row">
                            <div class="col-sm-3 col-md-9 mb-2 md-form">
                                <a id="BtnShowMap" href="#" class="btn btn-outline-success">Mostrar en Mapa</a>
                            </div>
                            <div class="col-md-9 mb-4 md-form">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-sm-12 col-md-12 md-form">
                                <div id="mapid" style="min-width: 300px; min-height: 500px;"></div>
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

    $('#BtnShowMap').on('click', function () {

        let name = $("input[id$='inputName']").val();
        let address = $("input[id$='inputAddress']").val();

        let lat = $("input[id$='inputLatitude']").val();
        let lng = $("input[id$='inputLongitude']").val();
        var mymap = L.map('mapid').setView([lat, lng], 18);

        L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw', {
            maxZoom: 18,
            attribution: '&copy <a href="https://www.openstreetmap.org/">OpenStreetMap</a>, ' +
                '<a >Implementado por: Eddie Alfaro</a> ',
            id: 'mapbox.streets'
        }).addTo(mymap);

        var marker = L.marker([lat, lng]).addTo(mymap);
        marker.bindPopup("Lugar: " + name + ", Dirección: " + address + ".").openPopup();

       });
    
           
</script>
</asp:Content>
