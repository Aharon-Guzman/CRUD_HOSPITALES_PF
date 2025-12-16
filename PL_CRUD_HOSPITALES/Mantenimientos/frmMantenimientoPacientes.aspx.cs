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
    public partial class frmMantenimientoPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string MantenimientoPaciente(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Pacientes_DAL obj_Pacientes_DAL = new cls_Pacientes_DAL();
                cls_Pacientes_BLL obj_Pacientes_BLL = new cls_Pacientes_BLL();

                obj_Pacientes_DAL.iId_Paciente = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Pacientes_DAL.sNombre = obj_Parametros_JS[1].ToString();
                obj_Pacientes_DAL.sPrim_Apellido = obj_Parametros_JS[2].ToString();
                obj_Pacientes_DAL.sSeg_Apellido = obj_Parametros_JS[3].ToString();
                obj_Pacientes_DAL.iTipo_Identificacion = Convert.ToInt32(obj_Parametros_JS[4].ToString());
                obj_Pacientes_DAL.sIdentificacion = obj_Parametros_JS[5].ToString();
                obj_Pacientes_DAL.sTelefono = obj_Parametros_JS[6].ToString();
                obj_Pacientes_DAL.sCorreo = obj_Parametros_JS[7].ToString();
                obj_Pacientes_DAL.dFecha_Nacimiento = Convert.ToDateTime(obj_Parametros_JS[8].ToString());
                obj_Pacientes_DAL.sDireccion = obj_Parametros_JS[9].ToString();
                obj_Pacientes_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[10].ToString());

                if (obj_Pacientes_DAL.iId_Paciente == 0)
                {
                    obj_Pacientes_BLL.crearPacientes(ref obj_Pacientes_DAL);
                }
                else
                {
                    obj_Pacientes_BLL.modificarPacientes(ref obj_Pacientes_DAL);
                }

                if (obj_Pacientes_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1<SPLITER>Ya existe un paciente con el mismo número de identificación.";
                }
                else if (obj_Pacientes_DAL.sValorScalar == "0")
                {
                    _mensaje = "0<SPLITER>Ocurrió un error al intentar guardar la información. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Pacientes_DAL.sValorScalar + "<SPLITER>Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public static string CargaInfoPaciente(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Pacientes_DAL obj_Pacientes_DAL = new cls_Pacientes_DAL();
                cls_Pacientes_BLL obj_Pacientes_BLL = new cls_Pacientes_BLL();

                obj_Pacientes_DAL.iId_Paciente = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Pacientes_DAL.iId_Paciente != 0)
                {
                    obj_Pacientes_BLL.Obtiene_Informacion_Pacientes(ref obj_Pacientes_DAL);

                    if (obj_Pacientes_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Pacientes_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                                    obj_Pacientes_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                                    obj_Pacientes_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" +
                                    obj_Pacientes_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                                    obj_Pacientes_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
                                    obj_Pacientes_DAL.dtDatos.Rows[0][5].ToString() + "<SPLITER>" +
                                    obj_Pacientes_DAL.dtDatos.Rows[0][6].ToString() + "<SPLITER>" +
                                    obj_Pacientes_DAL.dtDatos.Rows[0][7].ToString() + "<SPLITER>" +
                                    obj_Pacientes_DAL.dtDatos.Rows[0][8].ToString() + "<SPLITER>" +
                                    obj_Pacientes_DAL.dtDatos.Rows[0][9].ToString();
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
        public static string EliminarPacientes(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Pacientes_DAL obj_Pacientes_DAL = new cls_Pacientes_DAL();
                cls_Pacientes_BLL obj_Pacientes_BLL = new cls_Pacientes_BLL();

                obj_Pacientes_DAL.iId_Paciente = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Pacientes_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                obj_Pacientes_BLL.eliminarPacientes(ref obj_Pacientes_DAL);

                if (obj_Pacientes_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Existen registros con dependencia asociados a la información que desea eliminar. Verifique!!!";
                }
                else if (obj_Pacientes_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del registro. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Pacientes_DAL.sValorScalar + "<SPLITER>" + "Información eliminada de forma correcta.";
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

                _mensaje = "<option value='0'>Seleccione...</option>";

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