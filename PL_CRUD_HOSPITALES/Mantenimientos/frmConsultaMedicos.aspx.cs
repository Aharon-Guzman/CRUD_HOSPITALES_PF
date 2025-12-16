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
    public partial class frmConsultaMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaMedicos(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Medicos_DAL obj_Medicos_DAL = new cls_Medicos_DAL();
                cls_Medicos_BLL obj_Medicos_BLL = new cls_Medicos_BLL();

                //Descomponemos parámetros de búsqueda
                obj_Medicos_DAL.sNombre = obj_Parametros_JS[0].ToString();
                obj_Medicos_DAL.sPrim_Apellido = obj_Parametros_JS[1].ToString();
                obj_Medicos_DAL.iTipo_Identificacion = Convert.ToInt32(obj_Parametros_JS[2].ToString());
                obj_Medicos_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[3].ToString());

                //Ejecutar
                obj_Medicos_BLL.listarFiltrarMedicos(ref obj_Medicos_DAL);

                //Construir HTML de la tabla
                if (obj_Medicos_DAL.dtDatos.Rows.Count != 0)
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

                    for (int i = 0; i < obj_Medicos_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript: defineMedico(" + obj_Medicos_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                            obj_Medicos_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                            "<td>" + obj_Medicos_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                            "<td>" + obj_Medicos_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                            "<td>" + obj_Medicos_DAL.dtDatos.Rows[i][3].ToString() + "</td>" +
                            "<td>" + obj_Medicos_DAL.dtDatos.Rows[i][4].ToString() + "</td>" +
                            "<td>" + obj_Medicos_DAL.dtDatos.Rows[i][5].ToString() + "</td>" +
                            "<td style='text-align:center'><i class='lni lni-trash-can' onclick='javascript: eliminaMedico(" + obj_Medicos_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
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

                //Objetos de la entidad
                cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL = new cls_Tipos_Identificacion_DAL();
                cls_Tipos_Identificacion_BLL obj_Tipos_Identificacion_BLL = new cls_Tipos_Identificacion_BLL();

                //Solo listar tipos activos
                obj_Tipos_Identificacion_DAL.sTipo_Identificacion = string.Empty;
                obj_Tipos_Identificacion_DAL.sEstado = "Activo";
                obj_Tipos_Identificacion_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutar
                obj_Tipos_Identificacion_BLL.listarFiltrarTipos_Identificacion(ref obj_Tipos_Identificacion_DAL);

                //Construir HTML de options
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