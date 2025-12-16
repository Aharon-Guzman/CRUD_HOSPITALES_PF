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
    public class cls_Consultorios_BLL
    {
        public void listarFiltrarConsultorios(ref cls_Consultorios_DAL obj_Consultorios_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                //Listar
                if (
                    ((obj_Consultorios_DAL.iId_Hospital == 0))
                    &&
                    ((obj_Consultorios_DAL.iId_TipoConsultorio == 0))
                    &&
                    ((obj_Consultorios_DAL.sDescripcion == string.Empty) || (obj_Consultorios_DAL.sDescripcion == null))
                    &&
                    ((obj_Consultorios_DAL.sEstado == string.Empty) || (obj_Consultorios_DAL.sEstado == null))
                    )
                {
                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Consultorios"];
                    obj_BD_DAL.DT_Parametros = null;
                    //Definimos un nombre lógico del data table de respuesta de la base de datos 
                    obj_BD_DAL.sNomTabla = "Consultorios";
                }
                else //Filtrar
                {
                    /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                    obj_Consultorios_DAL.dtParametros = null;
                    obj_Consultorios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Consultorios_DAL.dtParametros);

                    //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                    //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                    obj_Consultorios_DAL.dtParametros.Rows.Add("@Id_Hospital", "1", obj_Consultorios_DAL.iId_Hospital);
                    obj_Consultorios_DAL.dtParametros.Rows.Add("@Id_TipoConsultorio", "1", obj_Consultorios_DAL.iId_TipoConsultorio);
                    obj_Consultorios_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Consultorios_DAL.sDescripcion);
                    obj_Consultorios_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Consultorios_DAL.sEstado);

                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FIL_Consultorios"];
                    //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                    obj_BD_DAL.DT_Parametros = obj_Consultorios_DAL.dtParametros;
                    //Definimos un nombre lógico del data table de respuesta de la base de datos 
                    obj_BD_DAL.sNomTabla = "Consultorios";
                }

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Consultorios_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Consultorios_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Obtiene_Informacion_Consultorios(ref cls_Consultorios_DAL obj_Consultorios_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Consultorios_DAL.dtParametros = null;
                obj_Consultorios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Consultorios_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Consultorios_DAL.dtParametros.Rows.Add("@IdConsultorio", "1", obj_Consultorios_DAL.iId_Consultorio);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Consultorios"];
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Consultorios_DAL.dtParametros;
                //Definimos un nombre lógico del data table de respuesta de la base de datos 
                obj_BD_DAL.sNomTabla = "Consultorios";

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Consultorios_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Consultorios_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void crearConsultorios(ref cls_Consultorios_DAL obj_Consultorios_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Consultorios_DAL.dtParametros = null;
                obj_Consultorios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Consultorios_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Consultorios_DAL.dtParametros.Rows.Add("@Id_Hospital", "1", obj_Consultorios_DAL.iId_Hospital);
                obj_Consultorios_DAL.dtParametros.Rows.Add("@Id_TipoConsultorio", "1", obj_Consultorios_DAL.iId_TipoConsultorio);
                obj_Consultorios_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Consultorios_DAL.sDescripcion);
                obj_Consultorios_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Consultorios_DAL.sEstado);
                obj_Consultorios_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Consultorios_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Consultorios"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Consultorios_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Consultorios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Consultorios_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Consultorios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Consultorios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void modificarConsultorios(ref cls_Consultorios_DAL obj_Consultorios_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Consultorios_DAL.dtParametros = null;
                obj_Consultorios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Consultorios_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Consultorios_DAL.dtParametros.Rows.Add("@IdConsultorio", "1", obj_Consultorios_DAL.iId_Consultorio);
                obj_Consultorios_DAL.dtParametros.Rows.Add("@Id_Hospital", "1", obj_Consultorios_DAL.iId_Hospital);
                obj_Consultorios_DAL.dtParametros.Rows.Add("@Id_TipoConsultorio", "1", obj_Consultorios_DAL.iId_TipoConsultorio);
                obj_Consultorios_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Consultorios_DAL.sDescripcion);
                obj_Consultorios_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Consultorios_DAL.sEstado);
                obj_Consultorios_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Consultorios_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Consultorios"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Consultorios_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Consultorios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Consultorios_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Consultorios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Consultorios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarConsultorios(ref cls_Consultorios_DAL obj_Consultorios_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Consultorios_DAL.dtParametros = null;
                obj_Consultorios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Consultorios_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Consultorios_DAL.dtParametros.Rows.Add("@IdConsultorio", "1", obj_Consultorios_DAL.iId_Consultorio);
                obj_Consultorios_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Consultorios_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Delete_Consultorios"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Consultorios_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Consultorios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Consultorios_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Consultorios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Consultorios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}