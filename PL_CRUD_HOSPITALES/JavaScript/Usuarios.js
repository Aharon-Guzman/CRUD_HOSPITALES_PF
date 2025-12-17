//$(document).ready(function () {
//    var pageName = window.location.pathname.split('/').pop();

//    if (pageName == "frmConsultaUsuarios.aspx") {
//        setTimeout(function () {
//            cargaListaUsuarios();
//        }, 1500);
//    }
//    else if (pageName == "frmMantenimientoUsuarios.aspx") {
//        setTimeout(function () {
//            obtieneDetalleUsuario();
//        }, 1500);
//    }
//});

//function modulosUsuario(uni) {
//    $.cookie("USRUNI", uni, { expires: TLTC, path: '/', domain: g_Dominio });
//    location.href = "frmMantenimientoModulosXUsuario.aspx";
//}
//function cargaListaUsuarios() {
//    // Resetear cookie
//    $.cookie("USRUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });

//    var obj_Parametros_JS = new Array();
//    obj_Parametros_JS[0] = $("#bsqNombre").val();
//    obj_Parametros_JS[1] = $("#bsqCorreo").val();
//    obj_Parametros_JS[2] = $("#bsqEstado").val();
//    obj_Parametros_JS[3] = $.cookie("GLBUNI");

//    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

//    if ((obj_Parametros_JS[3] != 0) && (obj_Parametros_JS[3] != undefined)) {
//        jQuery.ajax({
//            type: "POST",
//            url: "frmConsultaUsuarios.aspx/CargaListaUsuarios",
//            data: parametros,
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            cache: false,
//            success: function (msg) {
//                var res = msg.d;

//                if (res === undefined) {
//                    Swal.fire({
//                        title: "Error en la conexión",
//                        text: "Error de conexión a la base de datos",
//                        icon: "error"
//                    });
//                }
//                else {
//                    if (res === "No se encontraron registros") {
//                        $("#tblUsuarios").html("");
//                        Swal.fire({
//                            title: "Búsqueda de Registros",
//                            text: res,
//                            icon: "info"
//                        });
//                    }
//                    else {
//                        $("#tblUsuarios").html(res);
//                        paginar("#tblUsuarios");
//                    }
//                }
//            },
//            failure: function (msg) {

//            },
//            error: function (msg) {

//            }
//        });
//    }
//    else {
//        Swal.fire({
//            position: 'center-center',
//            icon: 'error',
//            title: "Error en la conexión",
//            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
//            showConfirmButton: false,
//            timer: 4500,
//            timerProgressBar: true
//        });
//        setTimeout(function () {
//            location.href = "../Login/frmInicioSesion.aspx";
//        }, 4000);
//    }
//}

//function crearUsuario() {
//    $.cookie("USRUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });
//    location.href = "frmMantenimientoUsuarios.aspx";
//}

//function defineUsuario(uni) {
//    $.cookie("USRUNI", uni, { expires: TLTC, path: '/', domain: g_Dominio });
//    location.href = "frmMantenimientoUsuarios.aspx";
//}

//function modulosUsuario(uni) {
//    $.cookie("USRUNI", uni, { expires: TLTC, path: '/', domain: g_Dominio });
//    location.href = "frmMantenimientoModulosXUsuario.aspx";
//}

//function obtieneDetalleUsuario() {
//    var obj_Parametros_JS = new Array();
//    obj_Parametros_JS[0] = $.cookie("USRUNI");
//    obj_Parametros_JS[1] = $.cookie("GLBUNI");

//    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

//    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
//        jQuery.ajax({
//            type: "POST",
//            url: "frmMantenimientoUsuarios.aspx/CargaInfoUsuario",
//            data: parametros,
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            cache: false,
//            success: function (msg) {
//                var res = msg.d;

//                if (res === undefined) {
//                    Swal.fire({
//                        title: "Error en la conexión",
//                        text: "Error de conexión a la base de datos",
//                        icon: "error"
//                    });
//                }
//                else {
//                    var arreglo = new Array();
//                    var str;

//                    str = res;
//                    arreglo = (str.split("<SPLITER>"));
//                    var resultado = arreglo[0];

//                    if (resultado === "No se encontraron registros") {
//                        Swal.fire({
//                            title: "Información de Registros",
//                            text: res,
//                            icon: "info"
//                        });
//                    }
//                    else {
//                        if (resultado != "") {
//                            // Orden: Id, Nombre, Prim_Apellido, Seg_Apellido, Correo, Password, Estado
//                            $("#txtNombre").val(arreglo[1]);
//                            $("#txtPrimerApellido").val(arreglo[2]);
//                            $("#txtSegundoApellido").val(arreglo[3]);
//                            $("#txtCorreo").val(arreglo[4]);
//                            $("#txtPassword").val(arreglo[5]);
//                            $("#cboEstado").val(arreglo[6]);
//                        }
//                    }
//                }
//            },
//            failure: function (msg) {

//            },
//            error: function (msg) {

//            }
//        });
//    }
//    else {
//        Swal.fire({
//            position: 'center-center',
//            icon: 'error',
//            title: "Error en la conexión",
//            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
//            showConfirmButton: false,
//            timer: 4500,
//            timerProgressBar: true
//        });
//        setTimeout(function () {
//            location.href = "../Login/frmInicioSesion.aspx";
//        }, 4000);
//    }
//}

//function mantenimientoUsuario() {
//    var obj_Parametros_JS = new Array();
//    obj_Parametros_JS[0] = $.cookie("USRUNI");
//    obj_Parametros_JS[1] = $("#txtNombre").val();
//    obj_Parametros_JS[2] = $("#txtPrimerApellido").val();
//    obj_Parametros_JS[3] = $("#txtSegundoApellido").val();
//    obj_Parametros_JS[4] = $("#txtCorreo").val();
//    obj_Parametros_JS[5] = $("#txtPassword").val();
//    obj_Parametros_JS[6] = $("#cboEstado").val();
//    obj_Parametros_JS[7] = $.cookie("GLBUNI");

//    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

//    if ((obj_Parametros_JS[7] != 0) && (obj_Parametros_JS[7] != undefined)) {
//        jQuery.ajax({
//            type: "POST",
//            url: "frmMantenimientoUsuarios.aspx/MantenimientoUsuario",
//            data: parametros,
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            cache: false,
//            success: function (msg) {
//                var res = msg.d;

//                if (res === undefined) {
//                    Swal.fire({
//                        title: "Error en la conexión",
//                        text: "Error de conexión a la base de datos",
//                        icon: "error"
//                    });
//                }
//                else {
//                    var arreglo = new Array();
//                    var str;

//                    str = res;
//                    arreglo = (str.split("<SPLITER>"));
//                    var resultado = arreglo[0];

//                    if ((resultado != "0") && (resultado != "-1")) {
//                        Swal.fire({
//                            position: "center-center",
//                            icon: "success",
//                            title: "Información de Registros",
//                            text: arreglo[1],
//                            showConfirmButton: false,
//                            timer: 4500,
//                            timerProgressBar: true
//                        });

//                        setTimeout(function () {
//                            location.href = "frmConsultaUsuarios.aspx";
//                        }, 5000);
//                    }
//                    else {
//                        Swal.fire({
//                            title: "Información de Registros",
//                            text: arreglo[1],
//                            icon: "info"
//                        });
//                    }
//                }
//            },
//            failure: function (msg) {

//            },
//            error: function (msg) {

//            }
//        });
//    }
//    else {
//        Swal.fire({
//            position: 'center-center',
//            icon: 'error',
//            title: "Error en la conexión",
//            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
//            showConfirmButton: false,
//            timer: 4500,
//            timerProgressBar: true
//        });
//        setTimeout(function () {
//            location.href = "../Login/frmInicioSesion.aspx";
//        }, 4000);
//    }
//}

//function eliminaUsuario(uni) {
//    var obj_Parametros_JS = new Array();
//    obj_Parametros_JS[0] = uni;
//    obj_Parametros_JS[1] = $.cookie("GLBUNI");

//    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

//    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
//        jQuery.ajax({
//            type: "POST",
//            url: "frmMantenimientoUsuarios.aspx/EliminarUsuarios",
//            data: parametros,
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            cache: false,
//            success: function (msg) {
//                var res = msg.d;

//                if (res === undefined) {
//                    Swal.fire({
//                        title: "Error en la conexión",
//                        text: "Error de conexión a la base de datos",
//                        icon: "error"
//                    });
//                }
//                else {
//                    var arreglo = new Array();
//                    var str;

//                    str = res;
//                    arreglo = (str.split("<SPLITER>"));
//                    var resultado = arreglo[0];

//                    if ((resultado != "0") && (resultado != "-1")) {
//                        Swal.fire({
//                            position: "center-center",
//                            icon: "success",
//                            title: "Información de Registros",
//                            text: arreglo[1],
//                            showConfirmButton: false,
//                            timer: 4500,
//                            timerProgressBar: true
//                        });

//                        setTimeout(function () {
//                            cargaListaUsuarios();
//                        }, 3000);
//                    }
//                    else {
//                        Swal.fire({
//                            title: "Información de Registros",
//                            text: arreglo[1],
//                            icon: "info"
//                        });
//                    }
//                }
//            },
//            failure: function (msg) {

//            },
//            error: function (msg) {

//            }
//        });
//    }
//    else {
//        Swal.fire({
//            position: 'center-center',
//            icon: 'error',
//            title: "Error en la conexión",
//            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
//            showConfirmButton: false,
//            timer: 4500,
//            timerProgressBar: true
//        });
//        setTimeout(function () {
//            location.href = "../Login/frmInicioSesion.aspx";
//        }, 4000);
//    }
//}

//function regresar() {
//    location.href = "frmConsultaUsuarios.aspx";
//}

//function paginar(elemento) {
//    var table;

//    if ($.fn.DataTable.isDataTable(elemento)) {
//        table = $(elemento).DataTable({
//            "iDisplayLength": 5,
//            "aLengthMenu": [[5, 10, 50, 100], [5, 10, 50, 100]],
//            "oLanguage":
//            {
//                "sLengthMenu": " Mostrar _MENU_  registros por p&aacute;gina",
//                "sProcessing": "Procesando...",
//                "sZeroRecords": "No se encontraron resultados",
//                "sEmptyTable": "Ningún dato disponible en esta tabla",
//                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
//                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
//                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
//                "sInfoPostFix": "",
//                "sSearch": "Filtrar:",
//                "sUrl": "",
//                "sInfoThousands": ",",
//                "sLoadingRecords": "Cargando...",
//                "oPaginate": {
//                    "sFirst": "Primero",
//                    "sLast": "Último",
//                    "sNext": "Siguiente",
//                    "sPrevious": "Anterior"
//                }
//            },
//            paging: true,
//            destroy: true
//        });
//    }
//    else {
//        table = $(elemento).DataTable({
//            "iDisplayLength": 5,
//            "aLengthMenu": [[5, 10, 50, 100], [5, 10, 50, 100]],
//            "oLanguage":
//            {
//                "sLengthMenu": " Mostrar _MENU_  registros por p&aacute;gina",
//                "sProcessing": "Procesando...",
//                "sZeroRecords": "No se encontraron resultados",
//                "sEmptyTable": "Ningún dato disponible en esta tabla",
//                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
//                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
//                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
//                "sInfoPostFix": "",
//                "sSearch": "Filtrar:",
//                "sUrl": "",
//                "sInfoThousands": ",",
//                "sLoadingRecords": "Cargando...",
//                "oPaginate": {
//                    "sFirst": "Primero",
//                    "sLast": "Último",
//                    "sNext": "Siguiente",
//                    "sPrevious": "Anterior"
//                }
//            },
//            paging: true,
//            destroy: true
//        });
//    }
//}

$(document).ready(function () {
    var pageName = window.location.pathname.split('/').pop();

    if (pageName == "frmConsultaUsuarios.aspx") {
        cargaListaUsuarios();
    }
    else if (pageName == "frmMantenimientoUsuarios.aspx") {
        obtieneDetalleUsuario();
    }
});

function cargaListaUsuarios() {
    $.cookie("USRUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });

    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $("#bsqNombre").val();
    obj_Parametros_JS[1] = $("#bsqCorreo").val();
    obj_Parametros_JS[2] = $("#bsqEstado").val();
    obj_Parametros_JS[3] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[3] != 0) && (obj_Parametros_JS[3] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaUsuarios.aspx/CargaListaUsuarios",
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
                        $("#tblUsuarios").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        $("#tblUsuarios").html(res);
                        paginar("#tblUsuarios");
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

function crearUsuario() {
    $.cookie("USRUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoUsuarios.aspx";
}

function defineUsuario(uni) {
    $.cookie("USRUNI", uni, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoUsuarios.aspx";
}

function modulosUsuario(uni) {
    $.cookie("USRUNI", uni, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoModulosXUsuario.aspx";
}

function obtieneDetalleUsuario() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("USRUNI");
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoUsuarios.aspx/CargaInfoUsuario",
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
                            // MAPEO SEGÚN SP:
                            // [0] = Id_Usuario
                            // [1] = Nombre
                            // [2] = Prim_Apellido
                            // [3] = Seg_Apellido
                            // [4] = Correo
                            // [5] = Estado ("Activo" o "Inactivo")
                            // [6] = Password

                            $("#txtNombre").val(arreglo[1]);
                            $("#txtPrimerApellido").val(arreglo[2]);
                            $("#txtSegundoApellido").val(arreglo[3]);
                            $("#txtCorreo").val(arreglo[4]);

                            // CONVERTIR: "Activo" → "A", "Inactivo" → "I"
                            var estadoCodigo = (arreglo[5] === "Activo") ? "A" : "I";
                            $("#cboEstado").val(estadoCodigo);

                            $("#txtPassword").val(arreglo[6]);
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

function mantenimientoUsuario() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("USRUNI");
    obj_Parametros_JS[1] = $("#txtNombre").val();
    obj_Parametros_JS[2] = $("#txtPrimerApellido").val();
    obj_Parametros_JS[3] = $("#txtSegundoApellido").val();
    obj_Parametros_JS[4] = $("#txtCorreo").val();
    obj_Parametros_JS[5] = $("#txtPassword").val();
    obj_Parametros_JS[6] = $("#cboEstado").val();
    obj_Parametros_JS[7] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[7] != 0) && (obj_Parametros_JS[7] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoUsuarios.aspx/MantenimientoUsuario",
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
                            location.href = "frmConsultaUsuarios.aspx";
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

function eliminaUsuario(uni) {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = uni;
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoUsuarios.aspx/EliminarUsuarios",
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
                            cargaListaUsuarios();
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

function regresar() {
    location.href = "frmConsultaUsuarios.aspx";
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