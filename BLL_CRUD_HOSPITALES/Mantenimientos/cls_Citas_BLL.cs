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
    public class cls_Citas_BLL
    {
        /// <summary>
        /// Método que ejecuta LISTAR o FILTRAR según los parámetros recibidos
        /// </summary>
        public void listarFiltrarCitas(ref cls_Citas_DAL obj_Citas_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                //Listar (cuando todos los filtros están vacíos o en 0)
                if (
                    ((obj_Citas_DAL.iId_Paciente == 0))
                    &&
                    ((obj_Citas_DAL.iId_Medico == 0))
                    &&
                    ((obj_Citas_DAL.iId_Consultorio == 0))
                    &&
                    ((obj_Citas_DAL.iId_TipoCita == 0))
                    &&
                    ((obj_Citas_DAL.sEstado == string.Empty) || (obj_Citas_DAL.sEstado == null))
                    )
                {
                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Citas"];
                    obj_BD_DAL.DT_Parametros = null;
                    //Definimos un nombre lógico del data table de respuesta
                    obj_BD_DAL.sNomTabla = "Citas";
                }
                else //Filtrar (cuando al menos un filtro tiene valor)
                {
                    /*Dar forma al atributo de Data Table de Parámetros*/
                    obj_Citas_DAL.dtParametros = null;
                    obj_Citas_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Citas_DAL.dtParametros);

                    //Agregar parámetros
                    //Orden: Nombre, Código Tipo de Dato, Valor
                    obj_Citas_DAL.dtParametros.Rows.Add("@Id_Paciente", "1", obj_Citas_DAL.iId_Paciente);
                    obj_Citas_DAL.dtParametros.Rows.Add("@Id_Medico", "1", obj_Citas_DAL.iId_Medico);
                    obj_Citas_DAL.dtParametros.Rows.Add("@Id_Consultorio", "1", obj_Citas_DAL.iId_Consultorio);
                    obj_Citas_DAL.dtParametros.Rows.Add("@Id_TipoCita", "1", obj_Citas_DAL.iId_TipoCita);
                    obj_Citas_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Citas_DAL.sEstado);

                    //Definimos el SP
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FIL_Citas"];
                    obj_BD_DAL.DT_Parametros = obj_Citas_DAL.dtParametros;
                    obj_BD_DAL.sNomTabla = "Citas";
                }

                //Ejecutar en base de datos
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar resultados
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Citas_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Citas_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para obtener la información de una cita específica
        /// </summary>
        public void Obtiene_Informacion_Citas(ref cls_Citas_DAL obj_Citas_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Citas_DAL.dtParametros = null;
                obj_Citas_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Citas_DAL.dtParametros);

                //Agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Citas_DAL.dtParametros.Rows.Add("@IdCita", "1", obj_Citas_DAL.iId_Cita);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Citas"];
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Citas_DAL.dtParametros;
                //Definimos un nombre lógico del data table de respuesta de la base de datos 
                obj_BD_DAL.sNomTabla = "Citas";

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Citas_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Citas_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para INSERTAR una nueva cita
        /// </summary>
        public void crearCitas(ref cls_Citas_DAL obj_Citas_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                /*Dar forma al DataTable de Parámetros*/
                obj_Citas_DAL.dtParametros = null;
                obj_Citas_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Citas_DAL.dtParametros);

                //Agregar parámetros
                //Orden: Nombre, Código Tipo de Dato, Valor
                obj_Citas_DAL.dtParametros.Rows.Add("@Id_TipoCita", "1", obj_Citas_DAL.iId_TipoCita);
                obj_Citas_DAL.dtParametros.Rows.Add("@Id_Medico", "1", obj_Citas_DAL.iId_Medico);
                obj_Citas_DAL.dtParametros.Rows.Add("@Id_Paciente", "1", obj_Citas_DAL.iId_Paciente);
                obj_Citas_DAL.dtParametros.Rows.Add("@Id_Consultorio", "1", obj_Citas_DAL.iId_Consultorio);
                obj_Citas_DAL.dtParametros.Rows.Add("@Fecha", "8", obj_Citas_DAL.dFecha);
                obj_Citas_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Citas_DAL.sEstado);
                obj_Citas_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Citas_DAL.iIdUsuarioGlobal);

                //Definir SP
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Citas"];
                obj_BD_DAL.sIndAxn = "SCALAR"; // Retorna el ID insertado
                obj_BD_DAL.DT_Parametros = obj_Citas_DAL.dtParametros;

                //Ejecutar
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar resultados
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Citas_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Citas_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Citas_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Citas_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Método para MODIFICAR una cita existente
        /// </summary>
        public void modificarCitas(ref cls_Citas_DAL obj_Citas_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                /*Dar forma al DataTable de Parámetros*/
                obj_Citas_DAL.dtParametros = null;
                obj_Citas_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Citas_DAL.dtParametros);

                //Agregar parámetros
                obj_Citas_DAL.dtParametros.Rows.Add("@IdCita", "1", obj_Citas_DAL.iId_Cita);
                obj_Citas_DAL.dtParametros.Rows.Add("@Id_TipoCita", "1", obj_Citas_DAL.iId_TipoCita);
                obj_Citas_DAL.dtParametros.Rows.Add("@Id_Medico", "1", obj_Citas_DAL.iId_Medico);
                obj_Citas_DAL.dtParametros.Rows.Add("@Id_Paciente", "1", obj_Citas_DAL.iId_Paciente);
                obj_Citas_DAL.dtParametros.Rows.Add("@Id_Consultorio", "1", obj_Citas_DAL.iId_Consultorio);
                obj_Citas_DAL.dtParametros.Rows.Add("@Fecha", "8", obj_Citas_DAL.dFecha);
                obj_Citas_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Citas_DAL.sEstado);
                obj_Citas_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Citas_DAL.iIdUsuarioGlobal);

                //Definir SP
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Citas"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Citas_DAL.dtParametros;

                //Ejecutar
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar resultados
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Citas_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Citas_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Citas_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Citas_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Método para ELIMINAR una cita
        /// </summary>
        public void eliminarCitas(ref cls_Citas_DAL obj_Citas_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                /*Dar forma al DataTable de Parámetros*/
                obj_Citas_DAL.dtParametros = null;
                obj_Citas_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Citas_DAL.dtParametros);

                //Agregar parámetros
                obj_Citas_DAL.dtParametros.Rows.Add("@IdCita", "1", obj_Citas_DAL.iId_Cita);
                obj_Citas_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Citas_DAL.iIdUsuarioGlobal);

                //Definir SP
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Delete_Citas"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Citas_DAL.dtParametros;

                //Ejecutar
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar resultados
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Citas_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Citas_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Citas_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Citas_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}