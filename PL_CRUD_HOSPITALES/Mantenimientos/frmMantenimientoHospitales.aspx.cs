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
    public partial class frmMantenimientoHospitales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidacionAcceso.ValidarYRedirigir();

        }
        [WebMethod]
        public static string MantenimientoHospital(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad
                cls_Hospitales_DAL obj_Hospitales_DAL = new cls_Hospitales_DAL();
                cls_Hospitales_BLL obj_Hospitales_BLL = new cls_Hospitales_BLL();

                //Descomponemos los valores
                obj_Hospitales_DAL.iId_Hospital = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Hospitales_DAL.sCod_Hospital = obj_Parametros_JS[1].ToString();
                obj_Hospitales_DAL.sDescripcion = obj_Parametros_JS[2].ToString();
                obj_Hospitales_DAL.sDireccion = obj_Parametros_JS[3].ToString();
                obj_Hospitales_DAL.sTelefono = obj_Parametros_JS[4].ToString();
                obj_Hospitales_DAL.sCorreo = obj_Parametros_JS[5].ToString();
                obj_Hospitales_DAL.sWeb = obj_Parametros_JS[6].ToString();
                obj_Hospitales_DAL.iArea = Convert.ToInt32(obj_Parametros_JS[7].ToString());
                obj_Hospitales_DAL.dFecha_Construccion = Convert.ToDateTime(obj_Parametros_JS[8].ToString());
                obj_Hospitales_DAL.sEstado = obj_Parametros_JS[9].ToString();
                obj_Hospitales_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[10].ToString());

                /*Si el ID es 0: es nuevo (INSERTAR)*/
                if (obj_Hospitales_DAL.iId_Hospital == 0)
                {
                    obj_Hospitales_BLL.crearHospitales(ref obj_Hospitales_DAL);
                }
                else
                {
                    obj_Hospitales_BLL.modificarHospitales(ref obj_Hospitales_DAL);
                }

                //Evaluar respuesta
                if (obj_Hospitales_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1<SPLITER>Ya existe un hospital con el mismo código.";
                }
                else if (obj_Hospitales_DAL.sValorScalar == "0")
                {
                    _mensaje = "0<SPLITER>Ocurrió un error al intentar guardar la información. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Hospitales_DAL.sValorScalar + "<SPLITER>Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public static string CargaInfoHospital(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Hospitales_DAL obj_Hospitales_DAL = new cls_Hospitales_DAL();
                cls_Hospitales_BLL obj_Hospitales_BLL = new cls_Hospitales_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Hospitales_DAL.iId_Hospital = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Hospitales_DAL.iId_Hospital != 0)
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Hospitales_BLL.Obtiene_Informacion_Hospitales(ref obj_Hospitales_DAL);

                    //Evaluamos la respuesta de la lógica de negocio
                    if (obj_Hospitales_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Hospitales_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                                    obj_Hospitales_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                                    obj_Hospitales_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" +
                                    obj_Hospitales_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                                    obj_Hospitales_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
                                    obj_Hospitales_DAL.dtDatos.Rows[0][5].ToString() + "<SPLITER>" +
                                    obj_Hospitales_DAL.dtDatos.Rows[0][6].ToString() + "<SPLITER>" +
                                    obj_Hospitales_DAL.dtDatos.Rows[0][7].ToString() + "<SPLITER>" +
                                    obj_Hospitales_DAL.dtDatos.Rows[0][8].ToString() + "<SPLITER>" +
                                    obj_Hospitales_DAL.dtDatos.Rows[0][9].ToString();
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
        public static string EliminarHospitales(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Hospitales_DAL obj_Hospitales_DAL = new cls_Hospitales_DAL();
                cls_Hospitales_BLL obj_Hospitales_BLL = new cls_Hospitales_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Hospitales_DAL.iId_Hospital = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Hospitales_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                obj_Hospitales_BLL.eliminarHospitales(ref obj_Hospitales_DAL);

                //Evaluamos la respuesta de la lógica de negocio
                if (obj_Hospitales_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Existen registros con dependencia asociados a la información que desea eliminar. Verifique!!!";
                }
                else if (obj_Hospitales_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del registro. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Hospitales_DAL.sValorScalar + "<SPLITER>" + "Información eliminada de forma correcta.";
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