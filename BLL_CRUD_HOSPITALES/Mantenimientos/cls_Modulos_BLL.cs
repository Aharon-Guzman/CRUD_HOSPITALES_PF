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
    public class cls_Modulos_BLL
    {
        /// <summary>
        /// Método para listar todos los módulos activos
        /// </summary>
        public void listarModulos(ref cls_Modulos_DAL obj_Modulos_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Modulos"];
                obj_BD_DAL.DT_Parametros = null;
                //Definimos un nombre lógico del data table de respuesta
                obj_BD_DAL.sNomTabla = "Modulos";

                //Ejecutar en base de datos
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar resultados
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Modulos_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Modulos_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}