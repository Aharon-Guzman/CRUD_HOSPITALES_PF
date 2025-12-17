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
    public partial class frmConsultaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaUsuarios(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

                //Descomponemos parámetros de búsqueda
                obj_Usuarios_DAL.sNombre = obj_Parametros_JS[0].ToString();
                obj_Usuarios_DAL.sCorreo = obj_Parametros_JS[1].ToString();
                obj_Usuarios_DAL.sEstado = obj_Parametros_JS[2].ToString();
                obj_Usuarios_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[3].ToString());

                //Ejecutar
                obj_Usuarios_BLL.listarFiltrarUsuarios(ref obj_Usuarios_DAL);

                //Construir HTML de la tabla
                if (obj_Usuarios_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>ID</th>" +
                        "<th>Nombre Completo</th>" +
                        "<th>Correo</th>" +
                        "<th>Estado</th>" +
                        "<th style='text-align:center'>Módulos</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Usuarios_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript: defineUsuario(" + obj_Usuarios_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                            obj_Usuarios_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                            "<td>" + obj_Usuarios_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                            "<td>" + obj_Usuarios_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                            "<td>" + obj_Usuarios_DAL.dtDatos.Rows[i][3].ToString() + "</td>" +
                            "<td style='text-align:center'><i class='lni lni-laptop' onclick='javascript: modulosUsuario(" + obj_Usuarios_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
                            "<td style='text-align:center'><i class='lni lni-trash-can' onclick='javascript: eliminaUsuario(" + obj_Usuarios_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
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
    }
}