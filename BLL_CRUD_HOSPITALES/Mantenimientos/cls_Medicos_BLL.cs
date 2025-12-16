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
    public class cls_Medicos_BLL
    {
        public void listarFiltrarMedicos(ref cls_Medicos_DAL obj_Medicos_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                //Listar
                if (
                    ((obj_Medicos_DAL.sNombre == string.Empty) || (obj_Medicos_DAL.sNombre == null))
                    &&
                    ((obj_Medicos_DAL.sPrim_Apellido == string.Empty) || (obj_Medicos_DAL.sPrim_Apellido == null))
                    &&
                    ((obj_Medicos_DAL.iTipo_Identificacion == 0))
                    )
                {
                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Medicos"];
                    obj_BD_DAL.DT_Parametros = null;
                    //Definimos un nombre lógico del data table de respuesta de la base de datos 
                    obj_BD_DAL.sNomTabla = "Medicos";
                }
                else //Filtrar
                {
                    /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                    obj_Medicos_DAL.dtParametros = null;
                    obj_Medicos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Medicos_DAL.dtParametros);

                    //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                    //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                    obj_Medicos_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Medicos_DAL.sNombre);
                    obj_Medicos_DAL.dtParametros.Rows.Add("@Prim_Apellido", "6", obj_Medicos_DAL.sPrim_Apellido);
                    obj_Medicos_DAL.dtParametros.Rows.Add("@Tipo_Identificacion", "1", obj_Medicos_DAL.iTipo_Identificacion);

                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FIL_Medicos"];
                    //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                    obj_BD_DAL.DT_Parametros = obj_Medicos_DAL.dtParametros;
                    //Definimos un nombre lógico del data table de respuesta de la base de datos 
                    obj_BD_DAL.sNomTabla = "Medicos";
                }

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Medicos_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Medicos_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Obtiene_Informacion_Medicos(ref cls_Medicos_DAL obj_Medicos_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Medicos_DAL.dtParametros = null;
                obj_Medicos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Medicos_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Medicos_DAL.dtParametros.Rows.Add("@IdMedico", "1", obj_Medicos_DAL.iId_Medico);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Medicos"];
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Medicos_DAL.dtParametros;
                //Definimos un nombre lógico del data table de respuesta de la base de datos 
                obj_BD_DAL.sNomTabla = "Medicos";

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Medicos_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Medicos_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void crearMedicos(ref cls_Medicos_DAL obj_Medicos_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Medicos_DAL.dtParametros = null;
                obj_Medicos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Medicos_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Medicos_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Medicos_DAL.sNombre);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Prim_Apellido", "6", obj_Medicos_DAL.sPrim_Apellido);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Seg_Apellido", "6", obj_Medicos_DAL.sSeg_Apellido);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Tipo_Identificacion", "1", obj_Medicos_DAL.iTipo_Identificacion);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Identificacion", "6", obj_Medicos_DAL.sIdentificacion);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Medicos_DAL.sTelefono);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Medicos_DAL.sCorreo);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Cod_Profesional", "6", obj_Medicos_DAL.sCod_Profesional);
                obj_Medicos_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Medicos_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Medicos"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Medicos_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Medicos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Medicos_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Medicos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Medicos_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void modificarMedicos(ref cls_Medicos_DAL obj_Medicos_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Medicos_DAL.dtParametros = null;
                obj_Medicos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Medicos_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Medicos_DAL.dtParametros.Rows.Add("@IdMedico", "1", obj_Medicos_DAL.iId_Medico);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Medicos_DAL.sNombre);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Prim_Apellido", "6", obj_Medicos_DAL.sPrim_Apellido);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Seg_Apellido", "6", obj_Medicos_DAL.sSeg_Apellido);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Tipo_Identificacion", "1", obj_Medicos_DAL.iTipo_Identificacion);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Identificacion", "6", obj_Medicos_DAL.sIdentificacion);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Medicos_DAL.sTelefono);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Medicos_DAL.sCorreo);
                obj_Medicos_DAL.dtParametros.Rows.Add("@Cod_Profesional", "6", obj_Medicos_DAL.sCod_Profesional);
                obj_Medicos_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Medicos_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Medicos"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Medicos_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Medicos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Medicos_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Medicos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Medicos_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarMedicos(ref cls_Medicos_DAL obj_Medicos_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Medicos_DAL.dtParametros = null;
                obj_Medicos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Medicos_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Medicos_DAL.dtParametros.Rows.Add("@IdMedico", "1", obj_Medicos_DAL.iId_Medico);
                obj_Medicos_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Medicos_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Delete_Medicos"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Medicos_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Medicos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Medicos_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Medicos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Medicos_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}