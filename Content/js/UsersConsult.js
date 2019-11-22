$(document).ready(function () {

    $('#btnConsultUsersDate').on('click', function () {
        _GetUsersDate()
    });

    var button = $(event.relatedTarget);
    $("#inputDate1").datepicker({
        showButtonPanel: true,
        changeMonth: true,
        changeYear: true,
        dateFormat: "yyyy/mm/dd",
        showAnim: "fadeIn",
        maxDate: "+1D"
    });
    $("#inputDate2").datepicker({
        showButtonPanel: true,
        changeMonth: true,
        changeYear: true,
        dateFormat: "yyyy/mm/dd",
        showAnim: "fadeIn",
        maxDate: "+1D"
    });
});




function _GetUsersDate() {
    var table = $("#tableconsultusersdate").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "Users.aspx/GetUsersDate",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            error: function () {
                showMsg('Error al intentar cargar lista de usuarios', 'danger', 2000);
            },
            response: function (d) {
                return JSON.stringify(d); // Cadena Json
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "UserID" },
            { "data": "email" },
            {
                "data": "created_at",
                render: function (data) {
                    return convertJsonDateToShortDate(data);
                }
            },
            {
                "data": "updated_at",
                render: function (data) {
                    return convertJsonDateToShortDate(data);
                }
            }
        ]
    });
}

function convertJsonDateToShortDate(data) {
    const dateValue = new Date(parseInt(data.substr(6)));
    return dateValue.toLocaleDateString() + " - " + dateValue.toLocaleTimeString();
}

function showMsgModal(bodyModal, message) {
    var m = $('.' + bodyModal + '');
    var h = $('<div id="msg" class="alert alert-warning alert-sm alert-dismissible fade show text-center" role="alert">'
        + message + '.'
        + '<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>'
        + '</div>');
    m.prepend(h);
    if (2000) window.setTimeout(function () { $('#msg').alert("close") }, 2000);
}