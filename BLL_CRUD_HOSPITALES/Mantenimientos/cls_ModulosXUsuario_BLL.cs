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
    public class cls_ModulosXUsuario_BLL
    {
        /// <summary>
        /// Método para listar módulos asignados a un usuario
        /// </summary>
        public void listarModulosXUsuario(ref cls_ModulosXUsuario_DAL obj_ModulosXUsuario_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                /*Dar forma al atributo de Data Table de Parámetros*/
                obj_ModulosXUsuario_DAL.dtParametros = null;
                obj_ModulosXUsuario_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_ModulosXUsuario_DAL.dtParametros);

                //Agregar parámetros
                obj_ModulosXUsuario_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_ModulosXUsuario_DAL.iId_Usuario);

                //Definir SP
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_ModulosXUsuario"];
                obj_BD_DAL.DT_Parametros = obj_ModulosXUsuario_DAL.dtParametros;
                obj_BD_DAL.sNomTabla = "ModulosXUsuario";

                //Ejecutar
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar resultados
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_ModulosXUsuario_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_ModulosXUsuario_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para ASIGNAR un módulo a un usuario
        /// </summary>
        public void asignarModuloXUsuario(ref cls_ModulosXUsuario_DAL obj_ModulosXUsuario_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                /*Dar forma al DataTable de Parámetros*/
                obj_ModulosXUsuario_DAL.dtParametros = null;
                obj_ModulosXUsuario_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_ModulosXUsuario_DAL.dtParametros);

                //Agregar parámetros
                obj_ModulosXUsuario_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_ModulosXUsuario_DAL.iId_Usuario);
                obj_ModulosXUsuario_DAL.dtParametros.Rows.Add("@IdModulo", "1", obj_ModulosXUsuario_DAL.iId_Modulo);
                obj_ModulosXUsuario_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_ModulosXUsuario_DAL.iIdUsuarioGlobal);

                //Definir SP
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_ModulosXUsuario"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_ModulosXUsuario_DAL.dtParametros;

                //Ejecutar
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar resultados
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_ModulosXUsuario_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_ModulosXUsuario_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_ModulosXUsuario_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_ModulosXUsuario_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para ELIMINAR asignación de módulo
        /// </summary>
        /// <summary>
        /// Método para ELIMINAR asignación de módulo
        /// </summary>
        public void eliminarModuloXUsuario(ref cls_ModulosXUsuario_DAL obj_ModulosXUsuario_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                /*Dar forma al DataTable de Parámetros*/
                obj_ModulosXUsuario_DAL.dtParametros = null;
                obj_ModulosXUsuario_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_ModulosXUsuario_DAL.dtParametros);

                //Agregar SOLO 2 parámetros
                obj_ModulosXUsuario_DAL.dtParametros.Rows.Add("@IdModuloUsuario", "1", obj_ModulosXUsuario_DAL.iId_Modulo_Usuario);
                obj_ModulosXUsuario_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_ModulosXUsuario_DAL.iIdUsuarioGlobal);

                //Definir SP
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Delete_ModulosXUsuario"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_ModulosXUsuario_DAL.dtParametros;

                //Ejecutar
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar resultados
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_ModulosXUsuario_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_ModulosXUsuario_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_ModulosXUsuario_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_ModulosXUsuario_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}