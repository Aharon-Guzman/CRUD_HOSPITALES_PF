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
    public partial class frmConsultaConsultorios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaConsultorios(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Consultorios_DAL obj_Consultorios_DAL = new cls_Consultorios_DAL();
                cls_Consultorios_BLL obj_Consultorios_BLL = new cls_Consultorios_BLL();

                //Descomponemos parámetros de búsqueda
                obj_Consultorios_DAL.iId_Hospital = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Consultorios_DAL.iId_TipoConsultorio = Convert.ToInt32(obj_Parametros_JS[1].ToString());
                obj_Consultorios_DAL.sDescripcion = obj_Parametros_JS[2].ToString();
                obj_Consultorios_DAL.sEstado = obj_Parametros_JS[3].ToString();
                obj_Consultorios_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[4].ToString());

                //Ejecutar
                obj_Consultorios_BLL.listarFiltrarConsultorios(ref obj_Consultorios_DAL);

                //Construir HTML de la tabla
                if (obj_Consultorios_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>ID</th>" +
                        "<th>Hospital</th>" +
                        "<th>Tipo</th>" +
                        "<th>Consultorio</th>" +
                        "<th>Estado</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Consultorios_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript: defineConsultorio(" + obj_Consultorios_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                            obj_Consultorios_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                            "<td>" + obj_Consultorios_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                            "<td>" + obj_Consultorios_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                            "<td>" + obj_Consultorios_DAL.dtDatos.Rows[i][3].ToString() + "</td>" +
                            "<td>" + obj_Consultorios_DAL.dtDatos.Rows[i][4].ToString() + "</td>" +
                            "<td style='text-align:center'><i class='lni lni-trash-can' onclick='javascript: eliminaConsultorio(" + obj_Consultorios_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
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
        public static string CargaListaHospitalesCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Hospitales_DAL obj_Hospitales_DAL = new cls_Hospitales_DAL();
                cls_Hospitales_BLL obj_Hospitales_BLL = new cls_Hospitales_BLL();

                //Solo listar hospitales activos
                obj_Hospitales_DAL.sDescripcion = string.Empty;
                obj_Hospitales_DAL.sEstado = "Activo";
                obj_Hospitales_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutar
                obj_Hospitales_BLL.listarFiltrarHospitales(ref obj_Hospitales_DAL);

                //Construir HTML de options
                _mensaje = "<option value='0'>Todos</option>";

                if (obj_Hospitales_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Hospitales_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<option value='" + obj_Hospitales_DAL.dtDatos.Rows[i][0].ToString() + "'>" +
                            obj_Hospitales_DAL.dtDatos.Rows[i][1].ToString() + "</option>";
                    }
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string CargaListaTiposConsultorioCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Tipos_Consultorio_DAL obj_Tipos_Consultorio_DAL = new cls_Tipos_Consultorio_DAL();
                cls_Tipos_Consultorio_BLL obj_Tipos_Consultorio_BLL = new cls_Tipos_Consultorio_BLL();

                //Solo listar tipos activos
                obj_Tipos_Consultorio_DAL.sTipo_Consultorio = string.Empty;
                obj_Tipos_Consultorio_DAL.sEstado = "Activo";
                obj_Tipos_Consultorio_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutar
                obj_Tipos_Consultorio_BLL.listarFiltrarTipos_Consultorio(ref obj_Tipos_Consultorio_DAL);

                //Construir HTML de options
                _mensaje = "<option value='0'>Todos</option>";

                if (obj_Tipos_Consultorio_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Tipos_Consultorio_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<option value='" + obj_Tipos_Consultorio_DAL.dtDatos.Rows[i][0].ToString() + "'>" +
                            obj_Tipos_Consultorio_DAL.dtDatos.Rows[i][1].ToString() + "</option>";
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