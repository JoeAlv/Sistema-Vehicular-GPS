$(document).ready(function () {
    $('#DelUserModal').on('show.bs.modal', function (event) {
        var modal = $(this)
        modal.find('.modal-title').text('¿Desea realmente eliminar al usuario ?')
    })

    $('#btnDelUser').on('click', function () {
        $("#DelUserModal").modal("hide");
        $.ajax({
            type: "POST",
            url: "Users.aspx/DeleteUser",
            data: '{UserID: "' + $("#recipient-del")[0].value + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function () {
                showMsg('Error al intentar eliminar usuario', 'danger', 2000);
            },
            data: function (d) {
                if (d == 1)
                    showMsg('Usuario eliminado correctamente', 'success', 2000);
                else {
                    showMsg('Error al intentar eliminar usuario', 'danger', 2000);
                }
            },
        });
    });


});

function showMsgModal(bodyModal, message) {
    var m = $('.' + bodyModal + '');
    var h = $('<div id="msg" class="alert alert-warning alert-sm alert-dismissible fade show text-center" role="alert">'
        + message + '.'
        + '<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>'
        + '</div>');
    m.prepend(h);
    if (2000) window.setTimeout(function () { $('#msg').alert("close") }, 2000);
}