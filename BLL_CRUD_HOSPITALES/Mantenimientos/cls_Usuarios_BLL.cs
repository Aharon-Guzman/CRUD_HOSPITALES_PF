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
    public class cls_Usuarios_BLL
    {
        public void Inicio_Sesion_Usuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Usuarios_DAL.sCorreo);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Password", "6", obj_Usuarios_DAL.sPassword);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LogIn_Usuarios"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Obtiene_Informacion_Usuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iId_Usuario);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Usuarios"];
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;
                //Definimos un nombre lógico del data table de respuesta de la base de datos 
                obj_BD_DAL.sNomTabla = "Usuarios";

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Usuarios_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void listarFiltrarUsuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                //Listar Datos
                if (
                    ((obj_Usuarios_DAL.sCorreo == string.Empty) || (obj_Usuarios_DAL.sCorreo == null))
                    &&
                     ((obj_Usuarios_DAL.sNombre == string.Empty) || (obj_Usuarios_DAL.sNombre == null))
                     &&
                     ((obj_Usuarios_DAL.sEstado == string.Empty) || (obj_Usuarios_DAL.sEstado == null))
                    )
                {
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Usuarios"];
                    obj_BD_DAL.DT_Parametros = null;
                    obj_BD_DAL.sNomTabla = "Usuarios";
                }
                else //Filtrar Datos
                {
                    /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                    obj_Usuarios_DAL.dtParametros = null;
                    obj_Usuarios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                    //agregar los parámetros que requiere el procedimiento almacenado
                    //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                    obj_Usuarios_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Usuarios_DAL.sCorreo);
                    obj_Usuarios_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Usuarios_DAL.sNombre);
                    obj_Usuarios_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Usuarios_DAL.sEstado);

                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FIL_Usuarios"];
                    //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                    obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;
                    //Definimos un nombre de tabla lógico 
                    obj_BD_DAL.sNomTabla = "Usuarios";
                }

                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Usuarios_DAL.dtDatos = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void crearUsuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Usuarios_DAL.sNombre);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Prim_Apellido", "6", obj_Usuarios_DAL.sPrim_Apellido);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Seg_Apellido", "6", obj_Usuarios_DAL.sSeg_Apellido);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Usuarios_DAL.sCorreo);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Usuarios_DAL.sEstado);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Password", "6", obj_Usuarios_DAL.sPassword);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Usuarios_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Usuarios"];
                //Determinar el tipo de axión a ejecutar
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarUsuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iId_Usuario);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Usuarios_DAL.sNombre);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Prim_Apellido", "6", obj_Usuarios_DAL.sPrim_Apellido);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Seg_Apellido", "6", obj_Usuarios_DAL.sSeg_Apellido);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Usuarios_DAL.sCorreo);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Usuarios_DAL.sEstado);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Password", "6", obj_Usuarios_DAL.sPassword);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Usuarios_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Usuarios"];
                //Determinar el tipo de axión a ejecutar
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarUsuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iId_Usuario);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Usuarios_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Delete_Usuarios"];
                //Determinar el tipo de axión a ejecutar
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Cerrar_Sesion_Usuario(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iId_Usuario);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_CierraSesion_Usuarios"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                Obj_BD_BLL.EjecutaProcesosComando(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = Obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void carga_Lista_Opciones_Menu_Usuario(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iId_Usuario);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_ModulosXUsuario"];
                Obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;
                Obj_BD_DAL.sNomTabla = "Opciones";
                Obj_BD_BLL.EjecutaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Usuarios_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
