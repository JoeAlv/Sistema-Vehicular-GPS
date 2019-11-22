<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/External.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="WebVehicles.Forms.Common._404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Error 404 - Sistema Vehicular</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CustomStyle" runat="server">
    <link href="../../Content/css/Login.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
<div class="container" id="app">
    <img id="ilogo" class="mb-4 fadeIn" src="../../Content/img/Logo.png" alt="" width="122" height="72">
    <h1 class="h3 mb-3 font-weight-normal">Error 404 - Sistema Vehicular</h1>
    <form id="form1" runat="server" class="form-signin">  
        <h5 class="h5 mb-3 font-weight-normal text-justify">Ha ocurrido un error al solicitar información al servidor ó no tienes suficientes privilegios para ingresar a la página.</h5>
        <br /><br />
        <asp:Button ID="btnBack" CssClass="btn btn-lg btn-outline-primary btn-block" runat="server" OnClick="Btn_Back_click" Text="Volver"/>
    </form>
    <p class="mt-5 mb-3">Copyright &copy; 2019 Derechos Reservados. Desarrollado por <a href="#" onclick="javascript:showMsg('El Desarrollador <strong>Eddie Alfaro</strong> le ofrece la más cordial bienvenida.', 'success', 5000);">Eddie Alfaro</a>.</p>
</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CustomScript" runat="server">

</asp:Content>
