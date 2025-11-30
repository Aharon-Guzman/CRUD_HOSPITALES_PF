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
    public partial class frmMantenimientoTiposConsultorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string MantenimientoTipoConsultorio(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Tipos_Consultorio_DAL obj_Tipos_Consultorio_DAL = new cls_Tipos_Consultorio_DAL();
                cls_Tipos_Consultorio_BLL obj_Tipos_Consultorio_BLL = new cls_Tipos_Consultorio_BLL();

                //Descomponemos los valores
                obj_Tipos_Consultorio_DAL.iId_TipoConsultorio = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Tipos_Consultorio_DAL.sTipo_Consultorio = obj_Parametros_JS[1].ToString();
                obj_Tipos_Consultorio_DAL.sEstado = obj_Parametros_JS[2].ToString();
                obj_Tipos_Consultorio_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[3].ToString());

                /*Si el ID es 0: es nuevo (INSERTAR)*/
                if (obj_Tipos_Consultorio_DAL.iId_TipoConsultorio == 0)
                {
                    obj_Tipos_Consultorio_BLL.crearTipos_Consultorio(ref obj_Tipos_Consultorio_DAL);
                }
                else
                {
                    obj_Tipos_Consultorio_BLL.modificarTipos_Consultorio(ref obj_Tipos_Consultorio_DAL);
                }

                //Evaluar respuesta
                if (obj_Tipos_Consultorio_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1<SPLITER>Ya existe un tipo de consultorio con el mismo nombre.";
                }
                else if (obj_Tipos_Consultorio_DAL.sValorScalar == "0")
                {
                    _mensaje = "0<SPLITER>Ocurrió un error al intentar guardar la información. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Tipos_Consultorio_DAL.sValorScalar + "<SPLITER>Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public static string CargaInfoTipoConsultorio(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Tipos_Consultorio_DAL obj_Tipos_Consultorio_DAL = new cls_Tipos_Consultorio_DAL();
                cls_Tipos_Consultorio_BLL obj_Tipos_Consultorio_BLL = new cls_Tipos_Consultorio_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Tipos_Consultorio_DAL.iId_TipoConsultorio = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Tipos_Consultorio_DAL.iId_TipoConsultorio != 0)
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Tipos_Consultorio_BLL.Obtiene_Informacion_Tipos_Consultorio(ref obj_Tipos_Consultorio_DAL);

                    //Evaluamos la respuesta de la lógica de negocio
                    if (obj_Tipos_Consultorio_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Tipos_Consultorio_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                                    obj_Tipos_Consultorio_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                                    obj_Tipos_Consultorio_DAL.dtDatos.Rows[0][2].ToString();
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
        public static string EliminarTiposConsultorio(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Tipos_Consultorio_DAL obj_Tipos_Consultorio_DAL = new cls_Tipos_Consultorio_DAL();
                cls_Tipos_Consultorio_BLL obj_Tipos_Consultorio_BLL = new cls_Tipos_Consultorio_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Tipos_Consultorio_DAL.iId_TipoConsultorio = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Tipos_Consultorio_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                obj_Tipos_Consultorio_BLL.eliminarTipos_Consultorio(ref obj_Tipos_Consultorio_DAL);

                //Evaluamos la respuesta de la lógica de negocio
                if (obj_Tipos_Consultorio_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Existen registros con dependencia asociados a la información que desea eliminar. Verifique!!!";
                }
                else if (obj_Tipos_Consultorio_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del registro. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Tipos_Consultorio_DAL.sValorScalar + "<SPLITER>" + "Información eliminada de forma correcta.";
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