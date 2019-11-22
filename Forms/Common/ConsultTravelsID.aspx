<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/PageContent.Master" AutoEventWireup="true" CodeBehind="ConsultTravelsID.aspx.cs" Inherits="WebVehicles.Forms.Common.ConsultTravelsID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Consultar Viaje por ID - Sistema Vehicular</title>
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
                    <div class="panel-heading h3">Consulta de viajes por ID</div>
                    <div class="panel-body">
                         <div class="form-row">
                             <div class="col-md-3 mb-3 md-form">
                                <label for="TxtTravelID">ID de viaje:</label>
                            </div>
                            <div class="col-md-4 mb-4 md-form">
                                <asp:TextBox ID="TxtTravelID" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                            </div>
                            <div class="col-md-2 mb-2 md-form">
                                <asp:LinkButton ID="BtnBuscarT" CssClass="form-control form-control-sm btn btn-info btn-sm" runat="server" Text="Buscar" OnClick="BtnBuscarT_click"></asp:LinkButton>
                            </div>
                             <div class="col-md-2 mb-2 md-form">
                                <asp:LinkButton ID="BtnImprimir" CssClass="form-control form-control-sm btn btn-info btn-sm" runat="server" Text="Imprimir" OnClick="BtnImprimir_click"></asp:LinkButton>
                            </div>
                        </div>
                       
                        <div class="form-row">
                            <div class="col-md-6 mb-6 md-form">
                                <label for="TxtUserID">Cédula: </label>
                                <asp:Label ID="TxtUserID" BackColor="#FFFFCC" BorderColor="Black" runat="server">[cédula del usuario]</asp:Label>
                            </div>
                             <div class="col-md-6 mb-6 md-form">
                                <label for="TxtVehicleID">Placa: </label>
                                <asp:Label ID="TxtVehicleID" BackColor="#FFFFCC" BorderColor="Black" runat="server">[placa del vehiculo]</asp:Label>
                            </div>
                        </div>  

                         <div class="form-row">
                             <div class="col-md-6 mb-6 md-form">
                                <label for="TxtContidionID">Estado: </label>
                                <asp:Label ID="TxtContidionID" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Estado]</asp:Label>
                            </div>

                            <div class="col-md-6 mb-6 md-form">
                                <label for="TxtCreated_at">Ingreso: </label>
                                <asp:Label ID="TxtCreated_at" BackColor="#FFFFCC" BorderColor="Black" runat="server">[Ingreso]</asp:Label>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                                <div class="table-responsive">
                                    <asp:GridView ID="GridViewLocationsTravelID" runat="server" CssClass="table table-striped table-bordered table-hover"
                                        EmptyDataText="No posee registros de localizaciones" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="LocationID" HeaderText="Ubicacion ID"/>
                                            <asp:BoundField DataField="name" HeaderText="Lugar"/>
                                            <asp:BoundField DataField="address" HeaderText="Direccion"/>
                                            <asp:BoundField DataField="latitude" HeaderText="Latitud"/>
                                            <asp:BoundField DataField="longitude" HeaderText="Longitud"/>
                                        </Columns>
                                    </asp:GridView>
                                </div>
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
        var mymap = L.map('mapid').setView([9.988, -85.330], 7);
           
        L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw', {
            maxZoom: 18,
            attribution: '&copy <a href="https://www.openstreetmap.org/">OpenStreetMap</a>, ' +
                '<a >Implementado por: Eddie Alfaro</a> ',
            id: 'mapbox.streets'
        }).addTo(mymap);

        <% for (int i=0;i<GridViewLocationsTravelID.Rows.Count;i++) {%>
        let name<%=i%> = '<%= GridViewLocationsTravelID.Rows[i].Cells[1].Text %>';
        let address<%=i%> = '<%= GridViewLocationsTravelID.Rows[i].Cells[2].Text %>';
        let lat<%=i%> = <%= GridViewLocationsTravelID.Rows[i].Cells[3].Text %>;
        let lng<%=i%> = <%= GridViewLocationsTravelID.Rows[i].Cells[4].Text %>;
            
        var marker<%=i%> = L.marker([lat<%=i%>, lng<%=i%>]).addTo(mymap);
        marker<%=i%>.bindPopup("Lugar: " + name<%=i%> + ", Dirección: " + address<%=i%> + ".").openPopup();

        <% } %>
    });    
</script>
</asp:Content>
