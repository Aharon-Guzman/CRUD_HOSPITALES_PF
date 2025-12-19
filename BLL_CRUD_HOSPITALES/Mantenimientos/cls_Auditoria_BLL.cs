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
    public class cls_Auditoria_BLL
    {
        /// <summary>
        /// Método para filtrar registros de auditoría según criterios
        /// </summary>
        /// <param name="obj_Auditoria_DAL">Objeto con los parámetros de búsqueda</param>
        public void listarFiltrarAuditoria(ref cls_Auditoria_DAL obj_Auditoria_DAL)
        {
            try
            {
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                obj_Auditoria_DAL.dtParametros = null;
                obj_Auditoria_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Auditoria_DAL.dtParametros);

                obj_Auditoria_DAL.dtParametros.Rows.Add("@Usuario", "1", obj_Auditoria_DAL.iId_Usuario);
                obj_Auditoria_DAL.dtParametros.Rows.Add("@Accion", "6", obj_Auditoria_DAL.sAccion);
                obj_Auditoria_DAL.dtParametros.Rows.Add("@Desde", "8", obj_Auditoria_DAL.dFechaDD);
                obj_Auditoria_DAL.dtParametros.Rows.Add("@Hasta", "8", obj_Auditoria_DAL.dFechaHH);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FILL_Auditoria"];
                obj_BD_DAL.DT_Parametros = obj_Auditoria_DAL.dtParametros;
                obj_BD_DAL.sNomTabla = "Auditoria";

                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Auditoria_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Auditoria_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}