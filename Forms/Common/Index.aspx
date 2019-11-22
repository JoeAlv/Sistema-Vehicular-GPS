<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Shared/MainContent.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebVehicles.Forms.Common.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    <title>Inicio - Sistema Vehicular</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CustomStyle" runat="server">
    <link href="../../Content/css/Main.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
<div class="row no-gutters" style="background:#FFF">
    <div class="col-xl-9 col-lg-9 col-md-8 col-sm-8">
        <section class="main">
            <article>
                <h2 class="titulo"><asp:Label ID="welcome" runat="server"></asp:Label></h2>
                <p>Este sitio web es para la administración de la <strong>flotilla vehicular</strong> de la Empresa <strong>FREEDOM S.A</strong></p>
            </article>
            <article>
                <h2 class="titulo">Generalidades del proceso</h2>
                <p>Puedes comunicarte al <strong>+506 87397420</strong> para mayor información.</p>
            </article>
            <article>
                <h2 class="titulo">Avisos</h2>
                <p>Nueva actualización programada - v1.2.3.02 at 15:00</p>
            </article>
        </section>
    </div>
    <div class="col-xl-3 col-lg-3 col-md-4 col-sm-4">
        <aside>
            <div class="list-group">
                <a class="list-group-item list-group-item-action">Privilegio: <asp:Label ID="rol" runat="server"></asp:Label></a>
            </div>
        </aside>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CustomScript" runat="server">
    <script src="../../Content/js/Main.js"></script>
</asp:Content>
