$(document).ready(function () {

    $('#btnAddVehicle').on('click', function () {
        var VehicleID = $("#inputVehicleID").val();
        var type = $("#inputType").val();
        var brand = $("#inputBrand").val();
        var year = $("#inputYear").val();
        var engine = $("#inputEngine").val();
        var transmission = $("#inputTransmission").val();
        var fuel = $("#inputFuel").val();
        var fueltank = $("#inputFuelTank").val();
        var ConditionID = $("#inputConditionID").val();
        _AddVehicle(VehicleID, type, brand, year, engine, transmission, fuel, fueltank, ConditionID);
    });

    $('#btnDelVehicle').on('click', function () {
        let VehicleID = $("#inputVehicleID")
        if (VehicleID.val().length > 6)
            _DelVehicle(VehicleID)
        else
            VehicleID.trigger('focus')
            showMsgModal('modalMsg', 'El numero de placa debe mayor de 6 caracteres')
    });
});


function clear_form_elements(ele) {
    $(ele).find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'select-multiple':
            case 'select-one':
            case 'text':
            case 'textarea':
                $(this).val('');
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}

function _AddVehicle(VehicleID, type, brand, year, engine, transmission, fuel, fueltank, ConditionID) {
    $("#AddVehicleModal").modal("hide");
    $.ajax({
        type: "POST",
        url: "Vehicles.aspx/AddVehicle",
        data: '{VehicleID: "' + VehicleID + '", type: "' + type
            + '", brand: "' + brand + '", year: "' + year + '", engine: "' + engine + '", transmission: "' + transmission
            + '", fuel: "' + fuel + '", fueltank: "' + fueltank + '", ConditionID: "' + ConditionID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            showMsg('Vehiculo creado correctamente', 'success', 5000);
        },
        error: function () {
            showMsg('Error al intentar crear vehiculo', 'danger', 5000);
        }
    });

}

function _DelVehicle(VehicleID) {
    $("#DelVehicleModal").modal("hide");
    $.ajax({
        type: "POST",
        url: "Vehicles.aspx/DeleteVehicle",
        data: '{VehicleID: "' + VehicleID + '" }',
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