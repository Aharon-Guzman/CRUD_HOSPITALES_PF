using BLL_CRUD_HOSPITALES.Mantenimientos;
using DAL_CRUD_HOSPITALES.Mantenimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_CRUD_HOSPITALES.Mantenimientos
{
    public partial class frmMantenimientoCitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string MantenimientoCita(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Citas_DAL obj_Citas_DAL = new cls_Citas_DAL();
                cls_Citas_BLL obj_Citas_BLL = new cls_Citas_BLL();

                //Descomponemos los valores
                obj_Citas_DAL.iId_Cita = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Citas_DAL.iId_Paciente = Convert.ToInt32(obj_Parametros_JS[1].ToString());
                obj_Citas_DAL.iId_Medico = Convert.ToInt32(obj_Parametros_JS[2].ToString());
                obj_Citas_DAL.iId_Consultorio = Convert.ToInt32(obj_Parametros_JS[3].ToString());
                obj_Citas_DAL.iId_TipoCita = Convert.ToInt32(obj_Parametros_JS[4].ToString());
                obj_Citas_DAL.dFecha = Convert.ToDateTime(obj_Parametros_JS[5].ToString());
                obj_Citas_DAL.sEstado = obj_Parametros_JS[6].ToString();
                obj_Citas_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[7].ToString());

                /*Si el ID es 0: es nuevo (INSERTAR)*/
                if (obj_Citas_DAL.iId_Cita == 0)
                {
                    obj_Citas_BLL.crearCitas(ref obj_Citas_DAL);
                }
                else
                {
                    obj_Citas_BLL.modificarCitas(ref obj_Citas_DAL);
                }

                //Evaluar respuesta
                if (obj_Citas_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1<SPLITER>Ya existe una cita para el mismo paciente, médico y fecha.";
                }
                else if (obj_Citas_DAL.sValorScalar == "0")
                {
                    _mensaje = "0<SPLITER>Ocurrió un error al intentar guardar la información. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Citas_DAL.sValorScalar + "<SPLITER>Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string CargaInfoCita(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Citas_DAL obj_Citas_DAL = new cls_Citas_DAL();
                cls_Citas_BLL obj_Citas_BLL = new cls_Citas_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Citas_DAL.iId_Cita = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Citas_DAL.iId_Cita != 0)
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Citas_BLL.Obtiene_Informacion_Citas(ref obj_Citas_DAL);

                    //Evaluamos la respuesta de la lógica de negocio
                    if (obj_Citas_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Citas_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                                    obj_Citas_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                                    obj_Citas_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" +
                                    obj_Citas_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                                    obj_Citas_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
                                    obj_Citas_DAL.dtDatos.Rows[0][5].ToString() + "<SPLITER>" +
                                    obj_Citas_DAL.dtDatos.Rows[0][6].ToString();
                    }
                    else
                    {
                        _mensaje = "No se encontraron registros";
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
        public static string EliminarCitas(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Citas_DAL obj_Citas_DAL = new cls_Citas_DAL();
                cls_Citas_BLL obj_Citas_BLL = new cls_Citas_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Citas_DAL.iId_Cita = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Citas_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                obj_Citas_BLL.eliminarCitas(ref obj_Citas_DAL);

                //Evaluamos la respuesta de la lógica de negocio
                if (obj_Citas_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "No se pudo completar el proceso.";
                }
                else if (obj_Citas_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del registro. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Citas_DAL.sValorScalar + "<SPLITER>" + "Información eliminada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [WebMethod]
        public static string CargaListaPacientesCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Pacientes_DAL obj_Pacientes_DAL = new cls_Pacientes_DAL();
                cls_Pacientes_BLL obj_Pacientes_BLL = new cls_Pacientes_BLL();

                //Listar todos
                obj_Pacientes_DAL.sNombre = string.Empty;
                obj_Pacientes_DAL.sPrim_Apellido = string.Empty;
                obj_Pacientes_DAL.iTipo_Identificacion = 0;
                obj_Pacientes_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutar
                obj_Pacientes_BLL.listarFiltrarPacientes(ref obj_Pacientes_DAL);

                //Construir HTML de options
                _mensaje = "<option value='0'>Seleccione...</option>";

                if (obj_Pacientes_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Pacientes_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<option value='" + obj_Pacientes_DAL.dtDatos.Rows[i][0].ToString() + "'>" +
                            obj_Pacientes_DAL.dtDatos.Rows[i][1].ToString() + "</option>";
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
        public static string CargaListaMedicosCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Medicos_DAL obj_Medicos_DAL = new cls_Medicos_DAL();
                cls_Medicos_BLL obj_Medicos_BLL = new cls_Medicos_BLL();

                //Listar todos
                obj_Medicos_DAL.sNombre = string.Empty;
                obj_Medicos_DAL.sPrim_Apellido = string.Empty;
                obj_Medicos_DAL.iTipo_Identificacion = 0;
                obj_Medicos_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutar
                obj_Medicos_BLL.listarFiltrarMedicos(ref obj_Medicos_DAL);

                //Construir HTML de options
                _mensaje = "<option value='0'>Seleccione...</option>";

                if (obj_Medicos_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Medicos_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<option value='" + obj_Medicos_DAL.dtDatos.Rows[i][0].ToString() + "'>" +
                            obj_Medicos_DAL.dtDatos.Rows[i][1].ToString() + "</option>";
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
        public static string CargaListaConsultoriosCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Consultorios_DAL obj_Consultorios_DAL = new cls_Consultorios_DAL();
                cls_Consultorios_BLL obj_Consultorios_BLL = new cls_Consultorios_BLL();

                //Listar todos activos
                obj_Consultorios_DAL.sDescripcion = string.Empty;
                obj_Consultorios_DAL.iId_Hospital = 0;
                obj_Consultorios_DAL.iId_TipoConsultorio = 0;
                obj_Consultorios_DAL.sEstado = "Activo";
                obj_Consultorios_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutar
                obj_Consultorios_BLL.listarFiltrarConsultorios(ref obj_Consultorios_DAL);

                //Construir HTML de options CON HOSPITAL
                _mensaje = "<option value='0'>Seleccione...</option>";

                if (obj_Consultorios_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Consultorios_DAL.dtDatos.Rows.Count; i++)
                    {
                        // ⭐ CONCATENAR: Hospital - Consultorio
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
                _mensaje = "<option value='0'>Seleccione...</option>";

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

        [WebMethod]
        public static string CargaNombrePaciente(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Pacientes_DAL obj_Pacientes_DAL = new cls_Pacientes_DAL();
                cls_Pacientes_BLL obj_Pacientes_BLL = new cls_Pacientes_BLL();

                obj_Pacientes_DAL.iId_Paciente = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Pacientes_DAL.iId_Paciente != 0)
                {
                    obj_Pacientes_BLL.Obtiene_Informacion_Pacientes(ref obj_Pacientes_DAL);

                    if (obj_Pacientes_DAL.dtDatos.Rows.Count != 0)
                    {
                        // Concatenar nombre completo
                        string nombreCompleto = obj_Pacientes_DAL.dtDatos.Rows[0][1].ToString() + " " +
                                                obj_Pacientes_DAL.dtDatos.Rows[0][2].ToString() + " " +
                                                obj_Pacientes_DAL.dtDatos.Rows[0][3].ToString();
                        _mensaje = nombreCompleto;
                    }
                    else
                    {
                        _mensaje = "Paciente no encontrado";
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