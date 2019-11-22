$(document).ready(function () {

    // Added Header
    AddHeader();

    // Added Navbar
    AddNavbar();

    // Added Footer
    AddFooter();

    $('#420').on('click', function () {
        showMsg('El desarrollador <strong>Eddy Alfaro</strong> le ofrece la más cordial bienvenida.', 'success', 5000);
    });

});

function AddHeader() {
    $('header').addClass('bg-transparent');
    var h = '<div class="logo">'
        + '<img class="" src="../../Content/img/Logo.png" style="width: 20%;">'
        + '<a style="padding:1px;">FREEDOM S.A</a> - <a style="padding:1px;">Sistema Vehicular</a>'
        + '</div>';
    $('header').html(h);
}

function AddNavbar() {
    $('nav').addClass('navbar navbar-expand-lg navbar-dark');
}

function AddFooter() {
    var f = $('footer');
    f.addClass('site-footer');

    var a = $('<div class="container">'
        + '<div class="row">'
        + '<div class="col-md-8 col-sm-6 col-xs-12">'
        + '<p class="copyright-text">Copyright &copy; 2019 All Rights Reserved. Desarrollado por <a id="420" href="#">Eddy Alfaro</a>.</p>'
        + '</div>'
        + '<div class="col-md-4 col-sm-6 col-xs-12">'
        + '<ul class="social-icons">'
        + '<li><a class="facebook" href="https://github.com/JoeAlv"><i class="fa fa-github"></i></a></li>'
        + '<li><a class="dribbble" href="https://www.instagram.com/joealv02/"><i class="fa fa-instagram"></i></a></li>'
        + '<li><a class="linkedin" href="https://www.linkedin.com/in/eddy-alfaro-10332397/"><i class="fa fa-linkedin"></i></a></li>'
        + '</ul>'
        + '</div>'
        + '</div >'
        + '</div >');
    f.html(a);
}

function showMsg(message, type, closeDelay) {
    var m = $('#messages');
    var h = '<div id="msg" class="alert alert-' + type + ' alert-dismissible fade show" role="alert">'
        + message + '.'
        + '<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>'
        + '</div>';
    m.after(h);
    if (closeDelay) window.setTimeout(function () { $('#msg').alert("close") }, closeDelay);
}