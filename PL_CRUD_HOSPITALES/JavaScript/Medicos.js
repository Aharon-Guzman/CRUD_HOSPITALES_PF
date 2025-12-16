$(document).ready(function () {
    // PRIMERO: Cargar TODOS los combos necesarios
    cargaTiposIdentificacionCombo();
    cargaTiposIdentificacionComboMantenimiento();

    // DESPUÉS: Detectar página
    var pageName = window.location.pathname.split('/').pop();

    // FINALMENTE: Ejecutar funciones dependientes con setTimeout
    if (pageName == "frmConsultaMedicos.aspx") {
        setTimeout(function () {
            cargaListaMedicos();
        }, 1500);
    }
    else if (pageName == "frmMantenimientoMedicos.aspx") {
        setTimeout(function () {
            obtieneDetalleMedico();
        }, 1500);
    }
});

function crearMedico() {
    //Al crear un registro nuevo, la cookie del identificador de la entidad vamos a ponerla en 0 
    //nombre, valor, [expiracion, path, domain]
    $.cookie("MEDUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoMedicos.aspx";
}

function regresar() {
    location.href = "frmConsultaMedicos.aspx";
}

function cargaTiposIdentificacionCombo() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaMedicos.aspx/CargaListaTiposIdentificacionCombo",
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
                    $("#bsqTipoIdentificacion").html(res);
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
        //Se redirecciona al Login
        setTimeout(function () {
            location.href = "../Login/frmInicioSesion.aspx";
        }, 4000);
    }
}

function cargaListaMedicos() {
    //nombre, valor, [expiracion, path, domain]
    $.cookie("MEDUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });

    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $("#bsqNombre").val();
    obj_Parametros_JS[1] = $("#bsqApellido").val();
    obj_Parametros_JS[2] = $("#bsqTipoIdentificacion").val();
    obj_Parametros_JS[3] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[3] != 0) && (obj_Parametros_JS[3] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaMedicos.aspx/CargaListaMedicos",
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

                        $("#tblMedicos").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        $("#tblMedicos").html(res);
                        paginar("#tblMedicos");
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
        //Se redirecciona al Login
        setTimeout(function () {
            location.href = "../Login/frmInicioSesion.aspx";
        }, 4000);
    }
}

function defineMedico(uni) {
    $.cookie("MEDUNI", uni, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoMedicos.aspx";
}

function cargaTiposIdentificacionComboMantenimiento() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoMedicos.aspx/CargaListaTiposIdentificacionCombo",
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
                    $("#cboTipoIdentificacion").html(res);
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
        //Se redirecciona al Login
        setTimeout(function () {
            location.href = "../Login/frmInicioSesion.aspx";
        }, 4000);
    }
}

function obtieneDetalleMedico() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("MEDUNI");
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoMedicos.aspx/CargaInfoMedico",
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
                            $("#txtNombre").val(arreglo[1]);
                            $("#txtPrim_Apellido").val(arreglo[2]);
                            $("#txtSeg_Apellido").val(arreglo[3]);
                            $("#cboTipoIdentificacion").val(arreglo[4]);
                            $("#txtIdentificacion").val(arreglo[5]);
                            $("#txtTelefono").val(arreglo[6]);
                            $("#txtCorreo").val(arreglo[7]);
                            $("#txtCod_Profesional").val(arreglo[8]);
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
        //Se redirecciona al Login
        setTimeout(function () {
            location.href = "../Login/frmInicioSesion.aspx";
        }, 4000);
    }
}

function mantenimientoMedico() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("MEDUNI");
    obj_Parametros_JS[1] = $("#txtNombre").val();
    obj_Parametros_JS[2] = $("#txtPrim_Apellido").val();
    obj_Parametros_JS[3] = $("#txtSeg_Apellido").val();
    obj_Parametros_JS[4] = $("#cboTipoIdentificacion").val();
    obj_Parametros_JS[5] = $("#txtIdentificacion").val();
    obj_Parametros_JS[6] = $("#txtTelefono").val();
    obj_Parametros_JS[7] = $("#txtCorreo").val();
    obj_Parametros_JS[8] = $("#txtCod_Profesional").val();
    obj_Parametros_JS[9] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[9] != 0) && (obj_Parametros_JS[9] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoMedicos.aspx/MantenimientoMedico",
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

                        //Se redirecciona a la página de consulta
                        setTimeout(function () {
                            location.href = "frmConsultaMedicos.aspx";
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
        //Se redirecciona al Login
        setTimeout(function () {
            location.href = "../Login/frmInicioSesion.aspx";
        }, 4000);
    }

}

function especialidadesMedico(uni) {
    $.cookie("MEDUNI", uni, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmAsignarEspecialidades.aspx";
}
function eliminaMedico(uni) {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = uni;
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoMedicos.aspx/EliminarMedicos",
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

                        //Se redirecciona a la página de consulta
                        setTimeout(function () {
                            cargaListaMedicos();
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
        //Se redirecciona al Login
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