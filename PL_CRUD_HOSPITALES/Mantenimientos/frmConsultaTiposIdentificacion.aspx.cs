using BLL_CRUD_HOSPITALES.Mantenimientos;
using DAL_CRUD_HOSPITALES.Mantenimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_CRUD_HOSPITALES.Mantenimientos
{
    public partial class frmConsultaTiposIdentificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// WebMethod para cargar información de un tipo de identificación específico
        /// Se usa cuando se va a MODIFICAR (viene con ID desde cookie)
        /// </summary>
        //[WebMethod]
        //public static string CargaInfoTipo_Identificacion(List<string> obj_Parametros_JS)
        //{
        //    try
        //    {
        //        string _mensaje = string.Empty;

        //        //Objetos de la entidad con la que estamos trabajando
        //        cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL = new cls_Tipos_Identificacion_DAL();
        //        cls_Tipos_Identificacion_BLL obj_Tipos_Identificacion_BLL = new cls_Tipos_Identificacion_BLL();

        //        //Descomponemos los valores que nos envíe el js
        //        obj_Tipos_Identificacion_DAL.iId_TipoIdentificacion = Convert.ToInt32(obj_Parametros_JS[0].ToString());

        //        if (obj_Tipos_Identificacion_DAL.iId_TipoIdentificacion != 0)
        //        {
        //            //Cargar datos usando Filtrar (pasando el ID como filtro)
        //            obj_Tipos_Identificacion_DAL.sTipo_Identificacion = "";
        //            obj_Tipos_Identificacion_DAL.sEstado = "";

        //            //Ejecutar en la lógica de negocio
        //            obj_Tipos_Identificacion_BLL.listarFiltrarTipos_Identificacion(ref obj_Tipos_Identificacion_DAL);

        //            //Evaluamos la respuesta
        //            if (obj_Tipos_Identificacion_DAL.dtDatos != null && obj_Tipos_Identificacion_DAL.dtDatos.Rows.Count != 0)
        //            {
        //                // Buscar el registro específico por ID
        //                var rows = obj_Tipos_Identificacion_DAL.dtDatos.Select("Id_TipoIdentificacion = " + obj_Tipos_Identificacion_DAL.iId_TipoIdentificacion);

        //                if (rows.Length > 0)
        //                {
        //                    _mensaje = rows[0]["Id_TipoIdentificacion"].ToString() + "<SPLITER>" +
        //                              rows[0]["Tipo_Identificacion"].ToString() + "<SPLITER>" +
        //                              rows[0]["Estado"].ToString();
        //                }
        //                else
        //                {
        //                    _mensaje = "No se encontraron registros";
        //                }
        //            }
        //            else
        //            {
        //                _mensaje = "No se encontraron registros";
        //            }
        //        }

        //        return _mensaje;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// WebMethod para INSERTAR o MODIFICAR un tipo de identificación
        ///// </summary>
        //[WebMethod]
        //public static string MantenimientoTipo_Identificacion(List<string> obj_Parametros_JS)
        //{
        //    try
        //    {
        //        string _mensaje = string.Empty;

        //        //Objetos de la entidad con la que estamos trabajando
        //        cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL = new cls_Tipos_Identificacion_DAL();
        //        cls_Tipos_Identificacion_BLL obj_Tipos_Identificacion_BLL = new cls_Tipos_Identificacion_BLL();

        //        //Descomponemos los valores que nos envíe el js
        //        obj_Tipos_Identificacion_DAL.iId_TipoIdentificacion = Convert.ToInt32(obj_Parametros_JS[0].ToString());
        //        obj_Tipos_Identificacion_DAL.sTipo_Identificacion = obj_Parametros_JS[1].ToString();
        //        obj_Tipos_Identificacion_DAL.sEstado = obj_Parametros_JS[2].ToString();
        //        obj_Tipos_Identificacion_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[3].ToString());

        //        /*Si el identificador es 0: es un dato nuevo, vamos a insertar*/
        //        if (obj_Tipos_Identificacion_DAL.iId_TipoIdentificacion == 0)
        //        {
        //            //Ejecutar en la lógica de negocio el proceso de INSERTAR
        //            obj_Tipos_Identificacion_BLL.crearTipos_Identificacion(ref obj_Tipos_Identificacion_DAL);
        //        }
        //        else
        //        {
        //            //Ejecutar en la lógica de negocio el proceso de MODIFICAR
        //            obj_Tipos_Identificacion_BLL.modificarTipos_Identificacion(ref obj_Tipos_Identificacion_DAL);
        //        }

        //        //Evaluamos la respuesta de la lógica de negocio
        //        if (obj_Tipos_Identificacion_DAL.sValorScalar == "-1")
        //        {
        //            _mensaje = "-1" + "<SPLITER>" + "Ya existe un tipo de identificación con el mismo nombre.";
        //        }
        //        else if (obj_Tipos_Identificacion_DAL.sValorScalar == "0")
        //        {
        //            _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información. Intente de nuevo.";
        //        }
        //        else
        //        {
        //            _mensaje = obj_Tipos_Identificacion_DAL.sValorScalar + "<SPLITER>" + "Información guardada de forma correcta.";
        //        }

        //        return _mensaje;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// WebMethod para ELIMINAR un tipo de identificación
        ///// </summary>
        //[WebMethod]
        //public static string EliminarTipo_Identificacion(List<string> obj_Parametros_JS)
        //{
        //    try
        //    {
        //        string _mensaje = string.Empty;

        //        //Objetos de la entidad con la que estamos trabajando
        //        cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL = new cls_Tipos_Identificacion_DAL();
        //        cls_Tipos_Identificacion_BLL obj_Tipos_Identificacion_BLL = new cls_Tipos_Identificacion_BLL();

        //        //Descomponemos los valores que nos envíe el js
        //        obj_Tipos_Identificacion_DAL.iId_TipoIdentificacion = Convert.ToInt32(obj_Parametros_JS[0].ToString());
        //        obj_Tipos_Identificacion_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

        //        //Ejecutar en la lógica de negocio el proceso de ELIMINAR
        //        obj_Tipos_Identificacion_BLL.eliminarTipos_Identificacion(ref obj_Tipos_Identificacion_DAL);

        //        //Evaluamos la respuesta de la lógica de negocio
        //        if (obj_Tipos_Identificacion_DAL.sValorScalar == "-1")
        //        {
        //            _mensaje = "-1" + "<SPLITER>" + "No se puede eliminar porque está asociado a médicos o pacientes.";
        //        }
        //        else if (obj_Tipos_Identificacion_DAL.sValorScalar == "0")
        //        {
        //            _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información. Intente de nuevo.";
        //        }
        //        else
        //        {
        //            _mensaje = obj_Tipos_Identificacion_DAL.sValorScalar + "<SPLITER>" + "Tipo de identificación eliminado correctamente.";
        //        }

        //        return _mensaje;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// WebMethod para LISTAR o FILTRAR tipos de identificación
        /// Se usa en la página de consulta (grid)
        /// </summary>
        [WebMethod]
        public static string CargaListaTiposIdentificacion(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL = new cls_Tipos_Identificacion_DAL();
                cls_Tipos_Identificacion_BLL obj_Tipos_Identificacion_BLL = new cls_Tipos_Identificacion_BLL();

                //Descomponemos parámetros de búsqueda
                obj_Tipos_Identificacion_DAL.sTipo_Identificacion = obj_Parametros_JS[0].ToString();
                obj_Tipos_Identificacion_DAL.sEstado = obj_Parametros_JS[1].ToString();
                obj_Tipos_Identificacion_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[2].ToString());

                //Ejecutar
                obj_Tipos_Identificacion_BLL.listarFiltrarTipos_Identificacion(ref obj_Tipos_Identificacion_DAL);

                //Construir HTML de la tabla
                if (obj_Tipos_Identificacion_DAL.dtDatos != null && obj_Tipos_Identificacion_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "<table id='tblTiposIdentificacion' class='table table-striped'>";
                    _mensaje += "<thead>";
                    _mensaje += "<tr>";
                    _mensaje += "<th>ID</th>";
                    _mensaje += "<th>Tipo de Identificación</th>";
                    _mensaje += "<th>Estado</th>";
                    _mensaje += "<th>Acciones</th>";
                    _mensaje += "</tr>";
                    _mensaje += "</thead>";
                    _mensaje += "<tbody>";

                    foreach (System.Data.DataRow row in obj_Tipos_Identificacion_DAL.dtDatos.Rows)
                    {
                        _mensaje += "<tr>";
                        _mensaje += "<td class>" + row["Id_TipoIdentificacion"].ToString() + "</td>";
                        _mensaje += "<td>" + row["Tipo_Identificacion"].ToString() + "</td>";
                        _mensaje += "<td>" + row["Estado"].ToString() + "</td>";
                        _mensaje += "<td>";
                        _mensaje += "<button class='btn btn-sm btn-primary' onclick='defineTipo_Identificacion(" + row["Id_TipoIdentificacion"].ToString() + ")'><i class='fas fa-edit'></i></button> ";
                        _mensaje += "<button class='btn btn-sm btn-danger' onclick='eliminaTipo_Identificacion(" + row["Id_TipoIdentificacion"].ToString() + ")'><i class='lni lni-trash-can'></i></button>";
                        _mensaje += "</td>";
                        _mensaje += "</tr>";
                    }

                    _mensaje += "</tbody>";
                    _mensaje += "</table>";
                    }
                else
                {
                    _mensaje = "No se encontraron registros";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}