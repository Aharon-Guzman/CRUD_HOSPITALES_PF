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
    public partial class frmConsultaTiposConsultorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string CargaListaTiposConsultorio(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Tipos_Consultorio_DAL obj_Tipos_Consultorio_DAL = new cls_Tipos_Consultorio_DAL();
                cls_Tipos_Consultorio_BLL obj_Tipos_Consultorio_BLL = new cls_Tipos_Consultorio_BLL();

                //Descomponemos parámetros de búsqueda
                obj_Tipos_Consultorio_DAL.sTipo_Consultorio = obj_Parametros_JS[0].ToString();
                obj_Tipos_Consultorio_DAL.sEstado = obj_Parametros_JS[1].ToString();
                obj_Tipos_Consultorio_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[2].ToString());

                //Ejecutar
                obj_Tipos_Consultorio_BLL.listarFiltrarTipos_Consultorio(ref obj_Tipos_Consultorio_DAL);

                //Construir HTML de la tabla
                if (obj_Tipos_Consultorio_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>ID</th>" +
                        "<th>Tipo de Consultorio</th>" +
                        "<th>Estado</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Tipos_Consultorio_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript: defineTipoConsultorio(" + obj_Tipos_Consultorio_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                            obj_Tipos_Consultorio_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                            "<td>" + obj_Tipos_Consultorio_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                            "<td>" + obj_Tipos_Consultorio_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                            "<td style='text-align:center'><i class='lni lni-trash-can' onclick='javascript: eliminaTipoConsultorio(" + obj_Tipos_Consultorio_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
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