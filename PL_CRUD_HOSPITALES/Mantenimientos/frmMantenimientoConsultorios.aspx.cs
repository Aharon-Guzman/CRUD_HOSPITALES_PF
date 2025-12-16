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
    public partial class frmMantenimientoConsultorios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string MantenimientoConsultorio(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Consultorios_DAL obj_Consultorios_DAL = new cls_Consultorios_DAL();
                cls_Consultorios_BLL obj_Consultorios_BLL = new cls_Consultorios_BLL();

                //Descomponemos los valores
                obj_Consultorios_DAL.iId_Consultorio = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Consultorios_DAL.iId_Hospital = Convert.ToInt32(obj_Parametros_JS[1].ToString());
                obj_Consultorios_DAL.iId_TipoConsultorio = Convert.ToInt32(obj_Parametros_JS[2].ToString());
                obj_Consultorios_DAL.sDescripcion = obj_Parametros_JS[3].ToString();
                obj_Consultorios_DAL.sEstado = obj_Parametros_JS[4].ToString();
                obj_Consultorios_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[5].ToString());

                /*Si el ID es 0: es nuevo (INSERTAR)*/
                if (obj_Consultorios_DAL.iId_Consultorio == 0)
                {
                    obj_Consultorios_BLL.crearConsultorios(ref obj_Consultorios_DAL);
                }
                else
                {
                    obj_Consultorios_BLL.modificarConsultorios(ref obj_Consultorios_DAL);
                }

                //Evaluar respuesta
                if (obj_Consultorios_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1<SPLITER>Ya existe un consultorio con la misma descripción en este hospital.";
                }
                else if (obj_Consultorios_DAL.sValorScalar == "0")
                {
                    _mensaje = "0<SPLITER>Ocurrió un error al intentar guardar la información. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Consultorios_DAL.sValorScalar + "<SPLITER>Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public static string CargaInfoConsultorio(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Consultorios_DAL obj_Consultorios_DAL = new cls_Consultorios_DAL();
                cls_Consultorios_BLL obj_Consultorios_BLL = new cls_Consultorios_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Consultorios_DAL.iId_Consultorio = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Consultorios_DAL.iId_Consultorio != 0)
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Consultorios_BLL.Obtiene_Informacion_Consultorios(ref obj_Consultorios_DAL);

                    //Evaluamos la respuesta de la lógica de negocio
                    if (obj_Consultorios_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Consultorios_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                                    obj_Consultorios_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                                    obj_Consultorios_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" +
                                    obj_Consultorios_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                                    obj_Consultorios_DAL.dtDatos.Rows[0][4].ToString();
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
        public static string EliminarConsultorios(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Consultorios_DAL obj_Consultorios_DAL = new cls_Consultorios_DAL();
                cls_Consultorios_BLL obj_Consultorios_BLL = new cls_Consultorios_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Consultorios_DAL.iId_Consultorio = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Consultorios_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                obj_Consultorios_BLL.eliminarConsultorios(ref obj_Consultorios_DAL);

                //Evaluamos la respuesta de la lógica de negocio
                if (obj_Consultorios_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Existen registros con dependencia asociados a la información que desea eliminar. Verifique!!!";
                }
                else if (obj_Consultorios_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del registro. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Consultorios_DAL.sValorScalar + "<SPLITER>" + "Información eliminada de forma correcta.";
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
                _mensaje = "<option value='0'>Seleccione...</option>";

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
                _mensaje = "<option value='0'>Seleccione...</option>";

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