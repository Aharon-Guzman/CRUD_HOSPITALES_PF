$(document).ready(function () {
        cargaHospitalesCombo();
        cargaTiposConsultorioCombo();
        cargaHospitalesComboMantenimiento();
        cargaTiposConsultorioComboMantenimiento();

    //Evaluamos la página en la que estamos para determinar si ejecuto o no una función o proceso específico
    var pageName = window.location.pathname.split('/').pop();
    //Esperamos 1.5 segundos para cargar la información de los combos y luego cargar la lista de consultorios o el detalle del consultorio
    if (pageName == "frmConsultaConsultorios.aspx") {
        setTimeout(function (){
            cargaListaConsultorios();
        }, 1500);
    }
    else if (pageName == "frmMantenimientoConsultorios.aspx") {
        setTimeout(function () {
            obtieneDetalleConsultorio();
        }, 1500);
    }
});

function crearConsultorio() {
    //Al crear un registro nuevo, la cookie del identificador de la entidad vamos a ponerla en 0 
    //nombre, valor, [expiracion, path, domain]
    $.cookie("CONSUUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoConsultorios.aspx";
}

function regresar() {
    location.href = "frmConsultaConsultorios.aspx";
}

function cargaHospitalesCombo() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaConsultorios.aspx/CargaListaHospitalesCombo",
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
                    $("#bsqHospital").html(res);
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

function cargaTiposConsultorioCombo() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaConsultorios.aspx/CargaListaTiposConsultorioCombo",
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
                    $("#bsqTipoConsultorio").html(res);
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

function cargaListaConsultorios() {
    //nombre, valor, [expiracion, path, domain]
    $.cookie("CONSUUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });

    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $("#bsqHospital").val();
    obj_Parametros_JS[1] = $("#bsqTipoConsultorio").val();
    obj_Parametros_JS[2] = $("#bsqDescripcion").val();
    obj_Parametros_JS[3] = $("#bsqEstado").val();
    obj_Parametros_JS[4] = $.cookie("GLBUNI");
    //if (obj_Parametros_JS[0] == null) {
    //    obj_Parametros_JS[0] = 0
    //}
    //if (obj_Parametros_JS[1] == null) {
    //    obj_Parametros_JS[1] = 0
    //}
    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[4] != 0) && (obj_Parametros_JS[4] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaConsultorios.aspx/CargaListaConsultorios",
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

                        $("#tblConsultorios").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        $("#tblConsultorios").html(res);
                        paginar("#tblConsultorios");
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

function defineConsultorio(uni) {
    $.cookie("CONSUUNI", uni, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoConsultorios.aspx";
}

function cargaHospitalesComboMantenimiento() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoConsultorios.aspx/CargaListaHospitalesCombo",
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
                    $("#cboHospital").html(res);
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

function cargaTiposConsultorioComboMantenimiento() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[0] != 0) && (obj_Parametros_JS[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoConsultorios.aspx/CargaListaTiposConsultorioCombo",
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
                    $("#cboTipoConsultorio").html(res);
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

function obtieneDetalleConsultorio() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("CONSUUNI");
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoConsultorios.aspx/CargaInfoConsultorio",
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
                            $("#cboHospital").val(arreglo[1]);
                            $("#cboTipoConsultorio").val(arreglo[2]);
                            $("#txtDescripcion").val(arreglo[3]);
                            $("#cboSts").val(arreglo[4]);
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

function mantenimientoConsultorio() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("CONSUUNI");
    obj_Parametros_JS[1] = $("#cboHospital").val();
    obj_Parametros_JS[2] = $("#cboTipoConsultorio").val();
    obj_Parametros_JS[3] = $("#txtDescripcion").val();
    obj_Parametros_JS[4] = $("#cboSts").val();
    obj_Parametros_JS[5] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[5] != 0) && (obj_Parametros_JS[5] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoConsultorios.aspx/MantenimientoConsultorio",
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
                            location.href = "frmConsultaConsultorios.aspx";
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


function eliminaConsultorio(uni) {
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
            url: "frmMantenimientoConsultorios.aspx/EliminarConsultorios",
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
                            cargaListaConsultorios();
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