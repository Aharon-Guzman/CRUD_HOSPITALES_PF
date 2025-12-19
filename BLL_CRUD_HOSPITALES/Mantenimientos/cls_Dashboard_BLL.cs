using System;
using System.Configuration;
using BLL_CRUD_HOSPITALES.DB;
using DAL_CRUD_HOSPITALES.DB;
using DAL_CRUD_HOSPITALES.Mantenimientos;

namespace BLL_CRUD_HOSPITALES.Mantenimientos
{
    public class cls_Dashboard_BLL
    {
        public void ObtenerEstadisticas(ref cls_Dashboard_DAL obj_Dashboard_DAL)
        {
            try
            {
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                // SP 1: Total Pacientes
                obj_BD_DAL.sNomSP = "USP_Dashboard_TotalPacientes";
                obj_BD_DAL.DT_Parametros = null;
                obj_BD_DAL.sNomTabla = "Dashboard";
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);
                if (obj_BD_DAL.sMsjErrorBD == string.Empty && obj_BD_DAL.DS.Tables[0].Rows.Count > 0)
                    obj_Dashboard_DAL.iTotalPacientes = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][0]);

                // SP 2: Citas Hoy
                obj_BD_DAL.sNomSP = "USP_Dashboard_CitasHoy";
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);
                if (obj_BD_DAL.sMsjErrorBD == string.Empty && obj_BD_DAL.DS.Tables[0].Rows.Count > 0)
                    obj_Dashboard_DAL.iCitasHoy = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0]["Total_Citas_Hoy"]);

                // SP 3: Total Médicos
                obj_BD_DAL.sNomSP = "USP_Dashboard_TotalMedicos";
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);
                if (obj_BD_DAL.sMsjErrorBD == string.Empty && obj_BD_DAL.DS.Tables[0].Rows.Count > 0)
                    obj_Dashboard_DAL.iTotalMedicos = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][0]);

                // SP 4: Total Hospitales
                obj_BD_DAL.sNomSP = "USP_Dashboard_TotalHospitales";
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);
                if (obj_BD_DAL.sMsjErrorBD == string.Empty && obj_BD_DAL.DS.Tables[0].Rows.Count > 0)
                    obj_Dashboard_DAL.iTotalHospitales = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}