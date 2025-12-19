using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_CRUD_HOSPITALES.Mantenimientos;
using DAL_CRUD_HOSPITALES.Mantenimientos;

namespace PL_CRUD_HOSPITALES.Mantenimientos
{
    public partial class frmConsultaAuditoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static string CargaListaAuditoria(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Auditoria_DAL obj_Auditoria_DAL = new cls_Auditoria_DAL();
                cls_Auditoria_BLL obj_Auditoria_BLL = new cls_Auditoria_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Auditoria_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Auditoria_DAL.sAccion = obj_Parametros_JS[1].ToString();
                obj_Auditoria_DAL.dFechaDD = Convert.ToDateTime(obj_Parametros_JS[2].ToString());
                obj_Auditoria_DAL.dFechaHH = Convert.ToDateTime(obj_Parametros_JS[3].ToString());

                //Ejecutar en lógica de negocio el proceso o la accion necesaria
                obj_Auditoria_BLL.listarFiltrarAuditoria(ref obj_Auditoria_DAL);

                //Evaluar los resultados de la ejecución de la lógica de negocio
                if (obj_Auditoria_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>Fecha / Hora</th>" +
                        "<th>Acción</th>" +
                        "<th>Descripción</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Auditoria_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr>" +
                                    "<td>" + obj_Auditoria_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                                    "<td>" + obj_Auditoria_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                    "<td>" + obj_Auditoria_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
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
        public static string CargaListaUsuariosCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad Usuarios
                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

                //Asignamos el parámetro de usuario global
                obj_Usuarios_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutar lógica de negocio para listar usuarios
                obj_Usuarios_BLL.ListarUsuarios(ref obj_Usuarios_DAL);

                //Evaluar los resultados
                if (obj_Usuarios_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "<option value='0'>Todos</option>";

                    for (int i = 0; i < obj_Usuarios_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<option value='" +
                                    obj_Usuarios_DAL.dtDatos.Rows[i][0].ToString() + "'>" +
                                    obj_Usuarios_DAL.dtDatos.Rows[i][1].ToString() + " " +
                                    obj_Usuarios_DAL.dtDatos.Rows[i][2].ToString() +
                                    "</option>";
                    }
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