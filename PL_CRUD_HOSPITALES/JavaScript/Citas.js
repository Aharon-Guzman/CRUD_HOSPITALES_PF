$(document).ready(function () {
    var pageName = window.location.pathname.split('/').pop();

    if (pageName == "frmConsultaCitas.aspx") {
        // Cargar combos de BÚSQUEDA
        cargaConsultoriosCombo();
        cargaTiposCitaCombo();

        setTimeout(function () {
            cargaListaCitas();
        }, 1500);
    }
    else if (pageName == "frmMantenimientoCitas.aspx") {
        // Cargar combos de MANTENIMIENTO primero
        cargaMedicosCombo();
        cargaConsultoriosComboMantenimiento();
        cargaTiposCitaComboMantenimiento();

        // Esperar a que los combos carguen
        setTimeout(function () {
            var citaId = $.cookie("CITAUNI");
            var pacienteId = $.cookie("PACUNI");

            if (citaId && citaId != 0) {
                // EDITAR cita existente
                obtieneDetalleCita();
            } else if (pacienteId && pacienteId != 0) {
                // CREAR cita desde Pacientes
                cargaNombrePaciente(pacienteId);
            }
        }, 1500);
    }
});

function cargaNombrePaciente(idPaciente) {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = idPaciente;

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    jQuery.ajax({
        type: "POST",
        url: "frmMantenimientoCitas.aspx/CargaNombrePaciente",
        data: parametros,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (msg) {
            var res = msg.d;

            if (res === undefined || res === "Paciente no encontrado") {
                Swal.fire({
                    title: "Error",
                    text: "No se pudo cargar la información del paciente",
                    icon: "error"
                });
            }
            else {
                $("#txtNombrePaciente").val(res);
                $("#hiddenIdPaciente").val(idPaciente);
                $("#tituloMantenimiento").html("Nueva Cita para <span class='text-primary'>" + res + "</span>");
            }
        },
        failure: function (msg) {

        },
        error: function (msg) {

        }
    });
}

function cargaMedicosCombo() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoCitas.aspx/CargaListaMedicosCombo",
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
                    $("#cboMedico").html(res);
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

function cargaConsultoriosCombo() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaCitas.aspx/CargaListaConsultoriosCombo",
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
                    $("#bsqConsultorio").html(res);
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

function cargaConsultoriosComboMantenimiento() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoCitas.aspx/CargaListaConsultoriosCombo",
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
                    $("#cboConsultorio").html(res);
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

function cargaTiposCitaCombo() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaCitas.aspx/CargaListaTiposCitaCombo",
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
                    $("#bsqTipoCita").html(res);
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

function cargaTiposCitaComboMantenimiento() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoCitas.aspx/CargaListaTiposCitaCombo",
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
                    $("#cboTipoCita").html(res);
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

function cargaListaCitas() {
    $.cookie("CITAUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });

    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $("#bsqNombrePaciente").val();
    obj_Parametros_JS[1] = $("#bsqApellidoPaciente").val();
    obj_Parametros_JS[2] = $("#bsqNombreMedico").val();
    obj_Parametros_JS[3] = $("#bsqConsultorio").val();
    obj_Parametros_JS[4] = $("#bsqTipoCita").val();
    obj_Parametros_JS[5] = $("#bsqEstado").val();
    obj_Parametros_JS[6] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[6] != 0) && (obj_Parametros_JS[6] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaCitas.aspx/CargaListaCitas",
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
                        $("#tblCitas").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        $("#tblCitas").html(res);
                        paginar("#tblCitas");
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

function defineCita(uni) {
    $.cookie("CITAUNI", uni, { expires: TLTC, path: '/', domain: g_Dominio });
    $.cookie("PACUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoCitas.aspx";
}

function obtieneDetalleCita() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("CITAUNI");
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoCitas.aspx/CargaInfoCita",
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

                    if (resultado === "No se encontraron registros") {
                        Swal.fire({
                            title: "Información de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        if (resultado != "") {
                            $("#hiddenIdPaciente").val(arreglo[3]);
                            $("#cboMedico").val(arreglo[2]);
                            $("#cboConsultorio").val(arreglo[4]);
                            $("#cboTipoCita").val(arreglo[1]);
                            $("#txtFecha").val(formatDate(arreglo[5]));
                            $("#cboEstado").val(arreglo[6]);

                            cargaNombrePacienteEdicion(arreglo[3]);
                        }
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

function cargaNombrePacienteEdicion(idPaciente) {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = idPaciente;

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    jQuery.ajax({
        type: "POST",
        url: "frmMantenimientoCitas.aspx/CargaNombrePaciente",
        data: parametros,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (msg) {
            var res = msg.d;

            if (res === undefined || res === "Paciente no encontrado") {
                Swal.fire({
                    title: "Error",
                    text: "No se pudo cargar la información del paciente",
                    icon: "error"
                });
            }
            else {
                $("#txtNombrePaciente").val(res);
                $("#tituloMantenimiento").html("Editar Cita de <span class='text-primary'>" + res + "</span>");
            }
        },
        failure: function (msg) {

        },
        error: function (msg) {

        }
    });
}

function formatDate(dateStr) {
    var dateParts = dateStr.split("/");
    var day = dateParts[0].padStart(2, '0');
    var month = dateParts[1].padStart(2, '0');
    var year = dateParts[2];
    return `${year}-${month}-${day}`;
}

function mantenimientoCita() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("CITAUNI");
    obj_Parametros_JS[1] = $("#hiddenIdPaciente").val();
    obj_Parametros_JS[2] = $("#cboMedico").val();
    obj_Parametros_JS[3] = $("#cboConsultorio").val();
    obj_Parametros_JS[4] = $("#cboTipoCita").val();
    obj_Parametros_JS[5] = $("#txtFecha").val();
    obj_Parametros_JS[6] = $("#cboEstado").val();
    obj_Parametros_JS[7] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[7] != 0) && (obj_Parametros_JS[7] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoCitas.aspx/MantenimientoCita",
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
                            timer: 4500,
                            timerProgressBar: true
                        });

                        setTimeout(function () {
                            regresar();
                        }, 5000);
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

function regresar() {
    var pacienteId = $.cookie("PACUNI");

    if (pacienteId && pacienteId != 0) {
        location.href = "frmConsultaPacientes.aspx";
    } else {
        location.href = "frmConsultaCitas.aspx";
    }
}

function eliminaCita(uni) {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = uni;
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoCitas.aspx/EliminarCitas",
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
                            timer: 4500,
                            timerProgressBar: true
                        });

                        setTimeout(function () {
                            cargaListaCitas();
                        }, 3000);
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