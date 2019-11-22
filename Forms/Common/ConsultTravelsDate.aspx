<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/PageContent.Master" AutoEventWireup="true" CodeBehind="ConsultTravelsDate.aspx.cs" Inherits="WebVehicles.Forms.Common.ConsultTravelsDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Consultar Viajes por fecha - Sistema Vehicular</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CustomStyle" runat="server">
    <link href="../../Content/css/Main.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
<div class="container" style="background:#FFF">
    <br />
    <form runat="server" id="form1">
        <div class="row">
            <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                <div class="h3 text-center">Consulta de viajes por fecha de ingreso</div>
                <div class="form-row">
                    <div class="col-md-4 mb-4 md-form">
                        <label for="TxtFechaInicio" class="col-md-5 control-label">Fecha Inicio:</label>
                        <asp:TextBox ID="TxtFechaInicio" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4 mb-4 md-form">
                        <label for="TxtFechaFinal" class="col-md-5 control-label">Fecha Final:</label>
                        <asp:TextBox ID="TxtFechaFinal" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2 mb-2 md-form">
                        <asp:Button ID="BtnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary" OnClick="BtnConsultar_Click" />
                    </div>
                    <div class="col-md-2 mb-2 md-form">
                        <asp:Button ID="BtnImprimir" runat="server" Text="Imprimir" CssClass="btn btn-success" OnClick="BtnImprimir_Click" />  
                    </div>
                </div>           
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                <asp:GridView ID="GridViewTravels" runat="server" BackColor="White" BorderColor="#CCCCCC" CssClass="table table-responsive table-hover table-sm table-light"
                AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                    <Columns>
                        <asp:BoundField HeaderText="Id Viaje" DataField="TravelID" />
                        <asp:BoundField HeaderText="Cedula" DataField="UserID">
                        <HeaderStyle HorizontalAlign="Center" Width="100px" /></asp:BoundField>
                        <asp:BoundField HeaderText="Placa" DataField="VehicleID" >
                        <HeaderStyle HorizontalAlign="Center" Width="200px" /></asp:BoundField>
                        <asp:BoundField HeaderText="Estado" DataField="ConditionID" >
                        <HeaderStyle Width="400px" /></asp:BoundField>
                        <asp:BoundField HeaderText="Fecha Ingreso" DataField="created_at" DataFormatString="{0:dd-MM-yyyy}">
                        <HeaderStyle Width="400px" Height="100px" /></asp:BoundField>
                    </Columns>
                </asp:GridView>
           </div>
        </div>
    </form>
</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CustomScript" runat="server">
    <script src="../../Content/js/Main.js"></script> 
</asp:Content>
