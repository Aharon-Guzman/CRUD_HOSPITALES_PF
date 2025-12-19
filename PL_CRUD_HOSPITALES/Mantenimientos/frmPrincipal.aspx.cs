using BLL_CRUD_HOSPITALES.Mantenimientos;
using DAL_CRUD_HOSPITALES.Mantenimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_CRUD_HOSPITALES.Mantenimientos
{
    public partial class frmPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ValidacionAcceso.ValidarYRedirigir();
        }

        [WebMethod]
        public static string ObtenerEstadisticasDashboard(List<string> obj_Parametros_JS)
        {
            try
            {
                cls_Dashboard_DAL obj_Dashboard_DAL = new cls_Dashboard_DAL();
                cls_Dashboard_BLL obj_Dashboard_BLL = new cls_Dashboard_BLL();

                obj_Dashboard_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[0]);

                // Ejecutar los 4 SPs
                obj_Dashboard_BLL.ObtenerEstadisticas(ref obj_Dashboard_DAL);

                // Retornar formato: TotalPacientes<SPLITER>CitasHoy<SPLITER>TotalMedicos<SPLITER>TotalHospitales
                string _mensaje = obj_Dashboard_DAL.iTotalPacientes + "<SPLITER>" +
                                  obj_Dashboard_DAL.iCitasHoy + "<SPLITER>" +
                                  obj_Dashboard_DAL.iTotalMedicos + "<SPLITER>" +
                                  obj_Dashboard_DAL.iTotalHospitales;

                return _mensaje;
            }
            catch (Exception ex)
            {
                return "0<SPLITER>0<SPLITER>0<SPLITER>0";
            }
        }
    }
}