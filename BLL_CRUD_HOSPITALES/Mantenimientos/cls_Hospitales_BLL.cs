using BLL_CRUD_HOSPITALES.DB;
using DAL_CRUD_HOSPITALES.DB;
using DAL_CRUD_HOSPITALES.Mantenimientos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_CRUD_HOSPITALES.Mantenimientos
{
    public class cls_Hospitales_BLL
    {
        public void listarFiltrarHospitales(ref cls_Hospitales_DAL obj_Hospitales_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                //Listar
                if (
                    ((obj_Hospitales_DAL.sDescripcion == string.Empty) || (obj_Hospitales_DAL.sDescripcion == null))
                    &&
                    ((obj_Hospitales_DAL.sEstado == string.Empty) || (obj_Hospitales_DAL.sEstado == null))
                    )
                {
                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Hospitales"];
                    obj_BD_DAL.DT_Parametros = null;
                    //Definimos un nombre lógico del data table de respuesta de la base de datos 
                    obj_BD_DAL.sNomTabla = "Hospitales";
                }
                else //Filtrar
                {
                    /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                    obj_Hospitales_DAL.dtParametros = null;
                    obj_Hospitales_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Hospitales_DAL.dtParametros);

                    //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                    //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                    obj_Hospitales_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Hospitales_DAL.sDescripcion);
                    obj_Hospitales_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Hospitales_DAL.sEstado);

                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FIL_Hospitales"];
                    //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                    obj_BD_DAL.DT_Parametros = obj_Hospitales_DAL.dtParametros;
                    //Definimos un nombre lógico del data table de respuesta de la base de datos 
                    obj_BD_DAL.sNomTabla = "Hospitales";
                }

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Hospitales_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Hospitales_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Obtiene_Informacion_Hospitales(ref cls_Hospitales_DAL obj_Hospitales_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Hospitales_DAL.dtParametros = null;
                obj_Hospitales_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Hospitales_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Hospitales_DAL.dtParametros.Rows.Add("@IdHospital", "1", obj_Hospitales_DAL.iId_Hospital);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Hospitales"];
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Hospitales_DAL.dtParametros;
                //Definimos un nombre lógico del data table de respuesta de la base de datos 
                obj_BD_DAL.sNomTabla = "Hospitales";

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Hospitales_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Hospitales_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void crearHospitales(ref cls_Hospitales_DAL obj_Hospitales_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Hospitales_DAL.dtParametros = null;
                obj_Hospitales_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Hospitales_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Cod_Hospital", "6", obj_Hospitales_DAL.sCod_Hospital);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Hospitales_DAL.sDescripcion);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Direccion", "6", obj_Hospitales_DAL.sDireccion);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Hospitales_DAL.sTelefono);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Hospitales_DAL.sCorreo);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Web", "6", obj_Hospitales_DAL.sWeb);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Area", "1", obj_Hospitales_DAL.iArea);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Fecha_Construccion", "8", obj_Hospitales_DAL.dFecha_Construccion);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Hospitales_DAL.sEstado);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Hospitales_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Hospitales"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Hospitales_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Hospitales_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Hospitales_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Hospitales_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Hospitales_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void modificarHospitales(ref cls_Hospitales_DAL obj_Hospitales_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Hospitales_DAL.dtParametros = null;
                obj_Hospitales_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Hospitales_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Hospitales_DAL.dtParametros.Rows.Add("@IdHospital", "1", obj_Hospitales_DAL.iId_Hospital);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Cod_Hospital", "6", obj_Hospitales_DAL.sCod_Hospital);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Hospitales_DAL.sDescripcion);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Direccion", "6", obj_Hospitales_DAL.sDireccion);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Hospitales_DAL.sTelefono);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Hospitales_DAL.sCorreo);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Web", "6", obj_Hospitales_DAL.sWeb);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Area", "1", obj_Hospitales_DAL.iArea);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Fecha_Construccion", "8", obj_Hospitales_DAL.dFecha_Construccion);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Hospitales_DAL.sEstado);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Hospitales_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Hospitales"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Hospitales_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Hospitales_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Hospitales_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Hospitales_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Hospitales_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarHospitales(ref cls_Hospitales_DAL obj_Hospitales_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Hospitales_DAL.dtParametros = null;
                obj_Hospitales_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Hospitales_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Hospitales_DAL.dtParametros.Rows.Add("@IdHospital", "1", obj_Hospitales_DAL.iId_Hospital);
                obj_Hospitales_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Hospitales_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Delete_Hospitales"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Hospitales_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Hospitales_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Hospitales_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Hospitales_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Hospitales_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
