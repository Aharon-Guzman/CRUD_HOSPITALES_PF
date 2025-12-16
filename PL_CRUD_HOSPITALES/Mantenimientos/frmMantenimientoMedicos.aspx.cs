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
    public partial class frmMantenimientoMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string MantenimientoMedico(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Medicos_DAL obj_Medicos_DAL = new cls_Medicos_DAL();
                cls_Medicos_BLL obj_Medicos_BLL = new cls_Medicos_BLL();

                //Descomponemos los valores
                obj_Medicos_DAL.iId_Medico = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Medicos_DAL.sNombre = obj_Parametros_JS[1].ToString();
                obj_Medicos_DAL.sPrim_Apellido = obj_Parametros_JS[2].ToString();
                obj_Medicos_DAL.sSeg_Apellido = obj_Parametros_JS[3].ToString();
                obj_Medicos_DAL.iTipo_Identificacion = Convert.ToInt32(obj_Parametros_JS[4].ToString());
                obj_Medicos_DAL.sIdentificacion = obj_Parametros_JS[5].ToString();
                obj_Medicos_DAL.sTelefono = obj_Parametros_JS[6].ToString();
                obj_Medicos_DAL.sCorreo = obj_Parametros_JS[7].ToString();
                obj_Medicos_DAL.sCod_Profesional = obj_Parametros_JS[8].ToString();
                obj_Medicos_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[9].ToString());

                /*Si el ID es 0: es nuevo (INSERTAR)*/
                if (obj_Medicos_DAL.iId_Medico == 0)
                {
                    obj_Medicos_BLL.crearMedicos(ref obj_Medicos_DAL);
                }
                else
                {
                    obj_Medicos_BLL.modificarMedicos(ref obj_Medicos_DAL);
                }

                //Evaluar respuesta
                if (obj_Medicos_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1<SPLITER>Ya existe un médico con el mismo número de identificación.";
                }
                else if (obj_Medicos_DAL.sValorScalar == "0")
                {
                    _mensaje = "0<SPLITER>Ocurrió un error al intentar guardar la información. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Medicos_DAL.sValorScalar + "<SPLITER>Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public static string CargaInfoMedico(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Medicos_DAL obj_Medicos_DAL = new cls_Medicos_DAL();
                cls_Medicos_BLL obj_Medicos_BLL = new cls_Medicos_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Medicos_DAL.iId_Medico = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Medicos_DAL.iId_Medico != 0)
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Medicos_BLL.Obtiene_Informacion_Medicos(ref obj_Medicos_DAL);

                    //Evaluamos la respuesta de la lógica de negocio
                    if (obj_Medicos_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Medicos_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                                    obj_Medicos_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                                    obj_Medicos_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" +
                                    obj_Medicos_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                                    obj_Medicos_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
                                    obj_Medicos_DAL.dtDatos.Rows[0][5].ToString() + "<SPLITER>" +
                                    obj_Medicos_DAL.dtDatos.Rows[0][6].ToString() + "<SPLITER>" +
                                    obj_Medicos_DAL.dtDatos.Rows[0][7].ToString() + "<SPLITER>" +
                                    obj_Medicos_DAL.dtDatos.Rows[0][8].ToString();
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
        public static string EliminarMedicos(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Medicos_DAL obj_Medicos_DAL = new cls_Medicos_DAL();
                cls_Medicos_BLL obj_Medicos_BLL = new cls_Medicos_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Medicos_DAL.iId_Medico = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Medicos_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                obj_Medicos_BLL.eliminarMedicos(ref obj_Medicos_DAL);

                //Evaluamos la respuesta de la lógica de negocio
                if (obj_Medicos_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Existen registros con dependencia asociados a la información que desea eliminar. Verifique!!!";
                }
                else if (obj_Medicos_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del registro. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Medicos_DAL.sValorScalar + "<SPLITER>" + "Información eliminada de forma correcta.";
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