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
    public partial class frmMantenimientoModulosXUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaModulos(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Modulos_DAL obj_Modulos_DAL = new cls_Modulos_DAL();
                cls_Modulos_BLL obj_Modulos_BLL = new cls_Modulos_BLL();

                //Ejecutar
                obj_Modulos_BLL.listarModulos(ref obj_Modulos_DAL);

                //Construir HTML de la tabla
                if (obj_Modulos_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>Módulo</th>" +
                        "<th style='text-align:center'>Asignar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Modulos_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr>" +
                            "<td>" + obj_Modulos_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                            "<td style='text-align:center'><i class='lni lni-circle-plus' onclick='javascript: asignaModuloXUsuario(" + obj_Modulos_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer; font-size: 20px;'></i></td>" +
                            "</tr>";
                    }

                    _mensaje += "</tbody>";
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

        [WebMethod]
        public static string CargaListaModulosXUsuario(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_ModulosXUsuario_DAL obj_ModulosXUsuario_DAL = new cls_ModulosXUsuario_DAL();
                cls_ModulosXUsuario_BLL obj_ModulosXUsuario_BLL = new cls_ModulosXUsuario_BLL();

                //Asignar parámetro
                obj_ModulosXUsuario_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutar
                obj_ModulosXUsuario_BLL.listarModulosXUsuario(ref obj_ModulosXUsuario_DAL);

                //Construir HTML de la tabla
                if (obj_ModulosXUsuario_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>Módulo</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_ModulosXUsuario_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr>" +
                            "<td>" + obj_ModulosXUsuario_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                            "<td style='text-align:center'><i class='lni lni-trash-can' onclick='javascript: eliminaModuloXUsuario(" + obj_ModulosXUsuario_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
                            "</tr>";
                    }

                    _mensaje += "</tbody>";
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

        [WebMethod]
        public static string AsignarModuloXUsuario(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_ModulosXUsuario_DAL obj_ModulosXUsuario_DAL = new cls_ModulosXUsuario_DAL();
                cls_ModulosXUsuario_BLL obj_ModulosXUsuario_BLL = new cls_ModulosXUsuario_BLL();

                //Descomponemos valores
                obj_ModulosXUsuario_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_ModulosXUsuario_DAL.iId_Modulo = Convert.ToInt32(obj_Parametros_JS[1].ToString());
                obj_ModulosXUsuario_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[2].ToString());

                //Ejecutar
                obj_ModulosXUsuario_BLL.asignarModuloXUsuario(ref obj_ModulosXUsuario_DAL);

                //Evaluar respuesta
                if (obj_ModulosXUsuario_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1<SPLITER>El módulo ya está asignado a este usuario.";
                }
                else if (obj_ModulosXUsuario_DAL.sValorScalar == "0")
                {
                    _mensaje = "0<SPLITER>Ocurrió un error al intentar asignar el módulo. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_ModulosXUsuario_DAL.sValorScalar + "<SPLITER>Módulo asignado correctamente.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string EliminarModuloXUsuario(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_ModulosXUsuario_DAL obj_ModulosXUsuario_DAL = new cls_ModulosXUsuario_DAL();
                cls_ModulosXUsuario_BLL obj_ModulosXUsuario_BLL = new cls_ModulosXUsuario_BLL();

                //Descomponemos valores - SOLO 2 parámetros
                obj_ModulosXUsuario_DAL.iId_Modulo_Usuario = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_ModulosXUsuario_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                //Ejecutar
                obj_ModulosXUsuario_BLL.eliminarModuloXUsuario(ref obj_ModulosXUsuario_DAL);

                //Evaluar respuesta
                if (obj_ModulosXUsuario_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1<SPLITER>No se pudo completar el proceso.";
                }
                else if (obj_ModulosXUsuario_DAL.sValorScalar == "0")
                {
                    _mensaje = "0<SPLITER>Ocurrió un error al intentar eliminar el módulo. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_ModulosXUsuario_DAL.sValorScalar + "<SPLITER>Módulo eliminado correctamente.";
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