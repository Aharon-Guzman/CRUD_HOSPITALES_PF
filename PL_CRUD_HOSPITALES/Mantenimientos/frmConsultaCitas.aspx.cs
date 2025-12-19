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
    public partial class frmConsultaCitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidacionAcceso.ValidarYRedirigir();
        }

        [WebMethod]
        public static string CargaListaCitas(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Citas_DAL obj_Citas_DAL = new cls_Citas_DAL();
                cls_Citas_BLL obj_Citas_BLL = new cls_Citas_BLL();

                //Descomponemos parámetros de búsqueda (AHORA SON TEXTOS)
                obj_Citas_DAL.sNombrePaciente = obj_Parametros_JS[0].ToString();
                obj_Citas_DAL.sApellidoPaciente = obj_Parametros_JS[1].ToString();
                obj_Citas_DAL.sNombreMedico = obj_Parametros_JS[2].ToString();
                obj_Citas_DAL.iId_Consultorio = Convert.ToInt32(obj_Parametros_JS[3].ToString());
                obj_Citas_DAL.iId_TipoCita = Convert.ToInt32(obj_Parametros_JS[4].ToString());
                obj_Citas_DAL.sEstado = obj_Parametros_JS[5].ToString();
                obj_Citas_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[6].ToString());

                //Ejecutar
                obj_Citas_BLL.listarFiltrarCitas(ref obj_Citas_DAL);

                //Construir HTML de la tabla
                if (obj_Citas_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>ID</th>" +
                        "<th>Paciente</th>" +
                        "<th>Médico</th>" +
                        "<th>Consultorio</th>" +
                        "<th>Tipo de Cita</th>" +
                        "<th>Fecha</th>" +
                        "<th>Estado</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Citas_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript: defineCita(" + obj_Citas_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                            obj_Citas_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                            "<td>" + obj_Citas_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                            "<td>" + obj_Citas_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                            "<td>" + obj_Citas_DAL.dtDatos.Rows[i][3].ToString() + "</td>" +
                            "<td>" + obj_Citas_DAL.dtDatos.Rows[i][4].ToString() + "</td>" +
                            "<td>" + obj_Citas_DAL.dtDatos.Rows[i][5].ToString() + "</td>" +
                            "<td>" + obj_Citas_DAL.dtDatos.Rows[i][6].ToString() + "</td>" +
                            "<td style='text-align:center'><i class='lni lni-trash-can' onclick='javascript: eliminaCita(" + obj_Citas_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
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
        public static string CargaListaConsultoriosCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Consultorios_DAL obj_Consultorios_DAL = new cls_Consultorios_DAL();
                cls_Consultorios_BLL obj_Consultorios_BLL = new cls_Consultorios_BLL();

                //Listar todos
                obj_Consultorios_DAL.sDescripcion = string.Empty;
                obj_Consultorios_DAL.iId_Hospital = 0;
                obj_Consultorios_DAL.iId_TipoConsultorio = 0;
                obj_Consultorios_DAL.sEstado = string.Empty;
                obj_Consultorios_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutar
                obj_Consultorios_BLL.listarFiltrarConsultorios(ref obj_Consultorios_DAL);

                //Construir HTML de options CON HOSPITAL
                _mensaje = "<option value='0'>Todos</option>";

                if (obj_Consultorios_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Consultorios_DAL.dtDatos.Rows.Count; i++)
                    {
                        //CONCATENAR: Hospital - Consultorio
                        string textoCombo = obj_Consultorios_DAL.dtDatos.Rows[i][1].ToString() + " - " +
                                            obj_Consultorios_DAL.dtDatos.Rows[i][3].ToString();

                        _mensaje += "<option value='" + obj_Consultorios_DAL.dtDatos.Rows[i][0].ToString() + "'>" +
                                    textoCombo + "</option>";
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
        public static string CargaListaTiposCitaCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Tipos_Cita_DAL obj_Tipos_Cita_DAL = new cls_Tipos_Cita_DAL();
                cls_Tipos_Cita_BLL obj_Tipos_Cita_BLL = new cls_Tipos_Cita_BLL();

                //Listar solo activos
                obj_Tipos_Cita_DAL.sTipo_Cita = string.Empty;
                obj_Tipos_Cita_DAL.sEstado = "Activo";
                obj_Tipos_Cita_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutar
                obj_Tipos_Cita_BLL.listarFiltrarTipos_Cita(ref obj_Tipos_Cita_DAL);

                //Construir HTML de options
                _mensaje = "<option value='0'>Todos</option>";

                if (obj_Tipos_Cita_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Tipos_Cita_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<option value='" + obj_Tipos_Cita_DAL.dtDatos.Rows[i][0].ToString() + "'>" +
                            obj_Tipos_Cita_DAL.dtDatos.Rows[i][1].ToString() + "</option>";
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


