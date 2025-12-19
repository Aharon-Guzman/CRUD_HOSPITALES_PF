$(document).ready(function () {
    cargarEstadisticas();
});

function cargarEstadisticas() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmPrincipal.aspx/ObtenerEstadisticasDashboard",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;
                if (res !== undefined && res !== "0<SPLITER>0<SPLITER>0<SPLITER>0") {
                    var datos = res.split("<SPLITER>");

                    // Actualizar valores
                    $("#totalPacientes").text(datos[0]);
                    $("#citasHoy").text(datos[1]);
                    $("#totalMedicos").text(datos[2]);
                    $("#totalHospitales").text(datos[3]);
                }
            },
            failure: function (msg) { },
            error: function (msg) { }
        });
    }
}