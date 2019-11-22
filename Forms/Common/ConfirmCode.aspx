<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/External.Master" AutoEventWireup="true" CodeBehind="ConfirmCode.aspx.cs" Inherits="WebVehicles.Forms.Common.ConfirmCode" %>

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
        <asp:Label ID="LblName" runat="server" CssClass="form-control"></asp:Label>            
        <div id="messages"></div>
        <label for="inputEmail" class="sr-only">Codigo</label>
        <asp:TextBox ID="inputCode" runat="server" CssClass="form-control" placeholder="el codigo que le enviamos a su correo electronico" required="true"></asp:TextBox>            
        <br /><br />
        <asp:Button ID="btnConfirm" CssClass="btn btn-lg btn-outline-primary btn-block" runat="server" OnClick="Btn_confirm_click" Text="Confirmar"/>
    </form>
    <p class="mt-5 mb-3">Copyright &copy; 2019 Derechos Reservados. Desarrollado por <a href="#" onclick="javascript:showMsg('El equipo de desarrollo de <strong>420 Solutions S.A</strong> le ofrece la más cordial bienvenida.', 'success', 5000);">420 Solutions S.A</a>.</p>
</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CustomScript" runat="server">

</asp:Content>
