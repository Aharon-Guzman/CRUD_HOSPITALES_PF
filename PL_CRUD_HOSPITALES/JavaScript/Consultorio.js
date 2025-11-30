
$(document).ready(function () {
    //Evaluamos la página en la que estamos para determinar si ejecuto o no una función o proceso específico
    var pageName = window.location.pathname.split('/').pop();

    if (pageName == "frmConsultaTiposConsultorio.aspx") {
        cargaListaTiposConsultorio();
    }
    else if (pageName == "frmMantenimientoTiposConsultorio.aspx") {
        obtieneDetalleTipoConsultorio();
    }
});

function crearTipoConsultorio() {
    //Al crear un registro nuevo, la cookie del identificador de la entidad vamos a ponerla en 0 
    //nombre, valor, [expiracion, path, domain]
    $.cookie("CONUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoTiposConsultorio.aspx";
}

function regresar() {
    location.href = "frmConsultaTiposConsultorio.aspx";
}


function cargaListaTiposConsultorio() {
    //nombre, valor, [expiracion, path, domain]
    $.cookie("CONUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });

    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $("#bsqTipo_Consultorio").val();
    obj_Parametros_JS[1] = $("#bsqEstado").val();
    obj_Parametros_JS[2] = $.cookie("GLBUNI");
    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });
    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[2] != 0) && (obj_Parametros_JS[2] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaTiposConsultorio.aspx/CargaListaTiposConsultorio",
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
                        
                        $("#tblTiposConsultorio").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        $("#tblTiposConsultorio").html(res);
                        paginar("#tblTiposConsultorio");
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

function defineTipoConsultorio(uni) {
    $.cookie("CONUNI", uni, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoTiposConsultorio.aspx";
}

function obtieneDetalleTipoConsultorio() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("CONUNI");
    obj_Parametros_JS[1] = $.cookie("GLBUNI");
    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });
    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoTiposConsultorio.aspx/CargaInfoTipoConsultorio",
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
                            $("#txtTipo_Consultorio").val(arreglo[1]);
                            $("#cboEstado").val(arreglo[2]);
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

function formatDate(dateStr) {
    var dateParts = dateStr.split("/");
    var day = dateParts[0].padStart(2, '0');
    var month = dateParts[1].padStart(2, '0');
    var year = dateParts[2];
    return `${year}-${month}-${day}`;
}

function mantenimientoTipoConsultorio() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("CONUNI");
    obj_Parametros_JS[1] = $("#txtTipo_Consultorio").val();
    obj_Parametros_JS[2] = $("#cboEstado").val();
    obj_Parametros_JS[3] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });
    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[3] != 0) && (obj_Parametros_JS[3] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoTiposConsultorio.aspx/MantenimientoTipoConsultorio",
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
                            location.href = "frmConsultaTiposConsultorio.aspx";
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


function eliminaTipoConsultorio(uni) {
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
            url: "frmMantenimientoTiposConsultorio.aspx/EliminarTiposConsultorio",
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
                            cargaListaTiposConsultorio();
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

};