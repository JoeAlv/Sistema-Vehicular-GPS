<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/External.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="WebVehicles.Forms.Common.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Recuperar Contraseña - Sistema Vehicular</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CustomStyle" runat="server">
        <link href="../../Content/css/Login.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
<div class="container" id="app">
    <img id="ilogo" class="mb-4 fadeIn" src="../../Content/img/Logo.png" alt="" width="122" height="72">
    <h1 class="h3 mb-3 font-weight-normal">Sistema Vehicular</h1>
    <form id="form1" runat="server" class="form-signin">
        <div id="messages"></div>
        <label for="inputID" class="sr-only">Nueva contraseña</label>
        <asp:TextBox ID="inputPW" TextMode="Password" runat="server" CssClass="form-control" placeholder="Nueva contraseña" required="true"></asp:TextBox>
        <label for="inputPW" class="sr-only">Confirmación</label>
        <asp:TextBox ID="inputCF" TextMode="Password" runat="server" CssClass="form-control" placeholder="confirmación" required="true"></asp:TextBox>

        <br /><br />
        <asp:Button ID="btnChange" CssClass="btn btn-lg btn-outline-primary btn-block" runat="server" OnClick="Btn_Change_click" Text="Establecer"/>
    </form>
    <p class="mt-5 mb-3">Copyright &copy; 2019 Derechos Reservados. Desarrollado por <a href="#" onclick="javascript:showMsg('El Desarrollador <strong>Eddie Alfaro</strong> le ofrece la más cordial bienvenida.', 'success', 5000);">Eddie Alfaro</a>.</p>
</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CustomScript" runat="server">

</asp:Content>
