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
    public partial class frmAsignarEspecialidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaTiposEspecialidadesCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Tipos_Especialidad_DAL obj_Tipos_Especialidades_DAL = new cls_Tipos_Especialidad_DAL();
                cls_Tipos_Especialidad_BLL obj_Tipos_Especialidades_BLL = new cls_Tipos_Especialidad_BLL();

                obj_Tipos_Especialidades_DAL.sTipo_Especialidad = string.Empty;
                obj_Tipos_Especialidades_DAL.sEstado = "Activo";
                obj_Tipos_Especialidades_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                obj_Tipos_Especialidades_BLL.listarFiltrarTipos_Especialidad(ref obj_Tipos_Especialidades_DAL);

                _mensaje = "<option value='0'>Seleccione...</option>";

                if (obj_Tipos_Especialidades_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Tipos_Especialidades_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<option value='" + obj_Tipos_Especialidades_DAL.dtDatos.Rows[i][0].ToString() + "'>" +
                            obj_Tipos_Especialidades_DAL.dtDatos.Rows[i][1].ToString() + "</option>";
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
        public static string CargaListaEspecialidadesMedico(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Especialidades_X_Medicos_DAL obj_Especialidades_X_Medicos_DAL = new cls_Especialidades_X_Medicos_DAL();
                cls_Especialidades_X_Medicos_BLL obj_Especialidades_X_Medicos_BLL = new cls_Especialidades_X_Medicos_BLL();

                obj_Especialidades_X_Medicos_DAL.iId_Medico = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                obj_Especialidades_X_Medicos_BLL.listarEspecialidadesPorMedico(ref obj_Especialidades_X_Medicos_DAL);

                if (obj_Especialidades_X_Medicos_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>Especialidad</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Especialidades_X_Medicos_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr>" +
                                    "<td>" + obj_Especialidades_X_Medicos_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                    "<td style='text-align:center'><i class='lni lni-trash-can' onclick='javascript: eliminaEspecialidad(" + obj_Especialidades_X_Medicos_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
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
        public static string AsignaEspecialidad(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Especialidades_X_Medicos_DAL obj_Especialidades_X_Medicos_DAL = new cls_Especialidades_X_Medicos_DAL();
                cls_Especialidades_X_Medicos_BLL obj_Especialidades_X_Medicos_BLL = new cls_Especialidades_X_Medicos_BLL();

                obj_Especialidades_X_Medicos_DAL.iId_Medico = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Especialidades_X_Medicos_DAL.iId_TipoEspecialidad = Convert.ToInt32(obj_Parametros_JS[1].ToString());
                obj_Especialidades_X_Medicos_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[2].ToString());

                obj_Especialidades_X_Medicos_BLL.asignarEspecialidadMedico(ref obj_Especialidades_X_Medicos_DAL);

                if (obj_Especialidades_X_Medicos_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1<SPLITER>La especialidad ya ha sido asignada al médico.";
                }
                else if (obj_Especialidades_X_Medicos_DAL.sValorScalar == "0")
                {
                    _mensaje = "0<SPLITER>Ocurrió un error al intentar asignar la especialidad.";
                }
                else
                {
                    _mensaje = obj_Especialidades_X_Medicos_DAL.sValorScalar + "<SPLITER>Especialidad asignada correctamente.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string EliminaEspecialidad(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Especialidades_X_Medicos_DAL obj_Especialidades_X_Medicos_DAL = new cls_Especialidades_X_Medicos_DAL();
                cls_Especialidades_X_Medicos_BLL obj_Especialidades_X_Medicos_BLL = new cls_Especialidades_X_Medicos_BLL();

                obj_Especialidades_X_Medicos_DAL.iId_Especialidad_Medico = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Especialidades_X_Medicos_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                obj_Especialidades_X_Medicos_BLL.eliminarEspecialidadMedico(ref obj_Especialidades_X_Medicos_DAL);

                if (obj_Especialidades_X_Medicos_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1<SPLITER>No se pudo completar el proceso.";
                }
                else if (obj_Especialidades_X_Medicos_DAL.sValorScalar == "0")
                {
                    _mensaje = "0<SPLITER>Ocurrió un error al intentar eliminar la especialidad.";
                }
                else
                {
                    _mensaje = obj_Especialidades_X_Medicos_DAL.sValorScalar + "<SPLITER>Especialidad eliminada correctamente.";
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