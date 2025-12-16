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
    public partial class frmConsultaPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaPacientes(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Pacientes_DAL obj_Pacientes_DAL = new cls_Pacientes_DAL();
                cls_Pacientes_BLL obj_Pacientes_BLL = new cls_Pacientes_BLL();

                obj_Pacientes_DAL.sNombre = obj_Parametros_JS[0].ToString();
                obj_Pacientes_DAL.sPrim_Apellido = obj_Parametros_JS[1].ToString();
                obj_Pacientes_DAL.iTipo_Identificacion = Convert.ToInt32(obj_Parametros_JS[2].ToString());
                obj_Pacientes_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[3].ToString());

                obj_Pacientes_BLL.listarFiltrarPacientes(ref obj_Pacientes_DAL);

                if (obj_Pacientes_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>ID</th>" +
                        "<th>Nombre Completo</th>" +
                        "<th>Tipo ID</th>" +
                        "<th>Identificación</th>" +
                        "<th>Teléfono</th>" +
                        "<th>Correo</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Pacientes_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript: definePaciente(" + obj_Pacientes_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                            obj_Pacientes_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                            "<td>" + obj_Pacientes_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                            "<td>" + obj_Pacientes_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                            "<td>" + obj_Pacientes_DAL.dtDatos.Rows[i][3].ToString() + "</td>" +
                            "<td>" + obj_Pacientes_DAL.dtDatos.Rows[i][4].ToString() + "</td>" +
                            "<td>" + obj_Pacientes_DAL.dtDatos.Rows[i][5].ToString() + "</td>" +
                            "<td style='text-align:center'><i class='lni lni-trash-can' onclick='javascript: eliminaPaciente(" + obj_Pacientes_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
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
        public static string CargaListaTiposIdentificacionCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL = new cls_Tipos_Identificacion_DAL();
                cls_Tipos_Identificacion_BLL obj_Tipos_Identificacion_BLL = new cls_Tipos_Identificacion_BLL();

                obj_Tipos_Identificacion_DAL.sTipo_Identificacion = string.Empty;
                obj_Tipos_Identificacion_DAL.sEstado = "Activo";
                obj_Tipos_Identificacion_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                obj_Tipos_Identificacion_BLL.listarFiltrarTipos_Identificacion(ref obj_Tipos_Identificacion_DAL);

                _mensaje = "<option value='0'>Todos</option>";

                if (obj_Tipos_Identificacion_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Tipos_Identificacion_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<option value='" + obj_Tipos_Identificacion_DAL.dtDatos.Rows[i][0].ToString() + "'>" +
                            obj_Tipos_Identificacion_DAL.dtDatos.Rows[i][1].ToString() + "</option>";
                    }
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