$(document).ready(function () {
    cargaTiposEspecialidadesCombo();

    setTimeout(function () {
        cargaListaEspecialidadesMedico();
    }, 1500);
});

function regresar() {
    location.href = "frmConsultaMedicos.aspx";
}

function cargaTiposEspecialidadesCombo() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmAsignarEspecialidades.aspx/CargaListaTiposEspecialidadesCombo",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;

                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de conexión a la base de datos",
                        icon: "error"
                    });
                }
                else {
                    $("#cboEspecialidad").html(res);
                }
            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        setTimeout(function () {
            location.href = "../Login/frmInicioSesion.aspx";
        }, 4000);
    }
}

function cargaListaEspecialidadesMedico() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("MEDUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmAsignarEspecialidades.aspx/CargaListaEspecialidadesMedico",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;

                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de conexión a la base de datos",
                        icon: "error"
                    });
                }
                else {
                    if (res === "No se encontraron registros") {
                        $("#tblEspecialidades").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        $("#tblEspecialidades").html(res);
                        paginar("#tblEspecialidades");
                    }
                }
            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        setTimeout(function () {
            location.href = "../Login/frmInicioSesion.aspx";
        }, 4000);
    }
}

function asignaEspecialidad() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("MEDUNI");
    obj_Parametros_JS[1] = $("#cboEspecialidad").val();
    obj_Parametros_JS[2] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[2] != 0) && (obj_Parametros_JS[2] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmAsignarEspecialidades.aspx/AsignaEspecialidad",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;

                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de conexión a la base de datos",
                        icon: "error"
                    });
                }
                else {
                    var arreglo = new Array();
                    var str;

                    str = res;
                    arreglo = (str.split("<SPLITER>"));
                    var resultado = arreglo[0];

                    if ((resultado != "0") && (resultado != "-1")) {
                        Swal.fire({
                            position: "center-center",
                            icon: "success",
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true
                        });

                        setTimeout(function () {
                            cargaListaEspecialidadesMedico();
                        }, 3500);
                    }
                    else {
                        Swal.fire({
                            title: "Información de Registros",
                            text: arreglo[1],
                            icon: "info"
                        });
                    }
                }
            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        setTimeout(function () {
            location.href = "../Login/frmInicioSesion.aspx";
        }, 4000);
    }
}

function eliminaEspecialidad(uni) {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = uni;
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmAsignarEspecialidades.aspx/EliminaEspecialidad",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;

                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de conexión a la base de datos",
                        icon: "error"
                    });
                }
                else {
                    var arreglo = new Array();
                    var str;

                    str = res;
                    arreglo = (str.split("<SPLITER>"));
                    var resultado = arreglo[0];

                    if ((resultado != "0") && (resultado != "-1")) {
                        Swal.fire({
                            position: "center-center",
                            icon: "success",
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true
                        });

                        setTimeout(function () {
                            cargaListaEspecialidadesMedico();
                        }, 3500);
                    }
                    else {
                        Swal.fire({
                            title: "Información de Registros",
                            text: arreglo[1],
                            icon: "info"
                        });
                    }
                }
            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        setTimeout(function () {
            location.href = "../Login/frmInicioSesion.aspx";
        }, 4000);
    }
}

function paginar(elemento) {
    var table;

    if ($.fn.DataTable.isDataTable(elemento)) {
        table = $(elemento).DataTable({
            "iDisplayLength": 5,
            "aLengthMenu": [[5, 10, 50, 100], [5, 10, 50, 100]],
            "oLanguage":
            {
                "sLengthMenu": " Mostrar _MENU_  registros por p&aacute;gina",
                "sProcessing": "Procesando...",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            },
            paging: true,
            destroy: true
        });
    }
    else {
        table = $(elemento).DataTable({
            "iDisplayLength": 5,
            "aLengthMenu": [[5, 10, 50, 100], [5, 10, 50, 100]],
            "oLanguage":
            {
                "sLengthMenu": " Mostrar _MENU_  registros por p&aacute;gina",
                "sProcessing": "Procesando...",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            },
            paging: true,
            destroy: true
        });
    }
}