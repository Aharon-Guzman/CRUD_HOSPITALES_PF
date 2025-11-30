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
    public class cls_Tipos_Identificacion_BLL
    {
        /// <summary>
        /// Método que ejecuta LISTAR o FILTRAR según los parámetros recibidos
        /// </summary>
        public void listarFiltrarTipos_Identificacion(ref cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                //Listar
                if (
                    ((obj_Tipos_Identificacion_DAL.sTipo_Identificacion == string.Empty) || (obj_Tipos_Identificacion_DAL.sTipo_Identificacion == null))
                    &&
                    ((obj_Tipos_Identificacion_DAL.sEstado == string.Empty) || (obj_Tipos_Identificacion_DAL.sEstado == null))
                )
                {
                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Tipos_Identificacion"];
                    obj_BD_DAL.DT_Parametros = null;
                    //Definimos un nombre lógico del data table de respuesta
                    obj_BD_DAL.sNomTabla = "Tipos_Identificacion";
                }
                else //Filtrar
                {
                    /*Dar forma al atributo de Data Table de Parámetros*/
                    obj_Tipos_Identificacion_DAL.dtParametros = null;
                    obj_Tipos_Identificacion_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Tipos_Identificacion_DAL.dtParametros);

                    //Agregar parámetros
                    //Orden: Nombre, Código Tipo de Dato, Valor
                    obj_Tipos_Identificacion_DAL.dtParametros.Rows.Add("@Tipo_Identificacion", "7", obj_Tipos_Identificacion_DAL.sTipo_Identificacion);
                    obj_Tipos_Identificacion_DAL.dtParametros.Rows.Add("@Estado", "7", obj_Tipos_Identificacion_DAL.sEstado);

                    //Definimos el SP
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FIL_Tipos_Identificacion"];
                    obj_BD_DAL.DT_Parametros = obj_Tipos_Identificacion_DAL.dtParametros;
                    obj_BD_DAL.sNomTabla = "Tipos_Identificacion";
                }

                //Ejecutar en base de datos
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar resultados
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Tipos_Identificacion_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Tipos_Identificacion_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Obtiene_Informacion_Tipos_Identificacion(ref cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Tipos_Identificacion_DAL.dtParametros = null;
                obj_Tipos_Identificacion_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Tipos_Identificacion_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Tipos_Identificacion_DAL.dtParametros.Rows.Add("@IdTipoIdentificacion", "1", obj_Tipos_Identificacion_DAL.iId_TipoIdentificacion);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Tipos_Identificacion"];
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Tipos_Identificacion_DAL.dtParametros;
                //Definimos un nombre lógico del data table de respuesta de la base de datos 
                obj_BD_DAL.sNomTabla = "Tipos_Identificacion";

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Tipos_Identificacion_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Tipos_Identificacion_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para INSERTAR un nuevo tipo de identificación
        /// </summary>
        public void crearTipos_Identificacion(ref cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                /*Dar forma al DataTable de Parámetros*/
                obj_Tipos_Identificacion_DAL.dtParametros = null;
                obj_Tipos_Identificacion_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Tipos_Identificacion_DAL.dtParametros);

                //Agregar parámetros
                //Orden: Nombre, Código Tipo de Dato, Valor
                obj_Tipos_Identificacion_DAL.dtParametros.Rows.Add("@Tipo_Identificacion", "6", obj_Tipos_Identificacion_DAL.sTipo_Identificacion);
                obj_Tipos_Identificacion_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Tipos_Identificacion_DAL.sEstado);
                obj_Tipos_Identificacion_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Tipos_Identificacion_DAL.iIdUsuarioGlobal);

                //Definir SP
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Tipos_Identificacion"];
                obj_BD_DAL.sIndAxn = "SCALAR"; // Retorna el ID insertado
                obj_BD_DAL.DT_Parametros = obj_Tipos_Identificacion_DAL.dtParametros;

                //Ejecutar
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar resultados
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Tipos_Identificacion_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Tipos_Identificacion_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Tipos_Identificacion_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Tipos_Identificacion_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para MODIFICAR un tipo de identificación existente
        /// </summary>
        public void modificarTipos_Identificacion(ref cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                /*Dar forma al DataTable de Parámetros*/
                obj_Tipos_Identificacion_DAL.dtParametros = null;
                obj_Tipos_Identificacion_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Tipos_Identificacion_DAL.dtParametros);

                //Agregar parámetros
                obj_Tipos_Identificacion_DAL.dtParametros.Rows.Add("@IdTipoIdentificacion", "1", obj_Tipos_Identificacion_DAL.iId_TipoIdentificacion);
                obj_Tipos_Identificacion_DAL.dtParametros.Rows.Add("@Tipo_Identificacion", "6", obj_Tipos_Identificacion_DAL.sTipo_Identificacion);
                obj_Tipos_Identificacion_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Tipos_Identificacion_DAL.sEstado);
                obj_Tipos_Identificacion_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Tipos_Identificacion_DAL.iIdUsuarioGlobal);

                //Definir SP
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Tipos_Identificacion"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Tipos_Identificacion_DAL.dtParametros;

                //Ejecutar
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar resultados
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Tipos_Identificacion_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Tipos_Identificacion_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Tipos_Identificacion_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Tipos_Identificacion_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para ELIMINAR un tipo de identificación
        /// </summary>
        public void eliminarTipos_Identificacion(ref cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                /*Dar forma al DataTable de Parámetros*/
                obj_Tipos_Identificacion_DAL.dtParametros = null;
                obj_Tipos_Identificacion_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Tipos_Identificacion_DAL.dtParametros);

                //Agregar parámetros
                obj_Tipos_Identificacion_DAL.dtParametros.Rows.Add("@IdTipoIdentificacion", "1", obj_Tipos_Identificacion_DAL.iId_TipoIdentificacion);
                obj_Tipos_Identificacion_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Tipos_Identificacion_DAL.iIdUsuarioGlobal);

                //Definir SP
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Delete_Tipos_Identificacion"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Tipos_Identificacion_DAL.dtParametros;

                //Ejecutar
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar resultados
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Tipos_Identificacion_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Tipos_Identificacion_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Tipos_Identificacion_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Tipos_Identificacion_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
