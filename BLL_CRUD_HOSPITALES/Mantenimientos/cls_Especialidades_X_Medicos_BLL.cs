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
    public class cls_Especialidades_X_Medicos_BLL
    {
        public void listarEspecialidadesPorMedico(ref cls_Especialidades_X_Medicos_DAL obj_Especialidades_X_Medicos_DAL)
        {
            try
            {
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                obj_Especialidades_X_Medicos_DAL.dtParametros = null;
                obj_Especialidades_X_Medicos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Especialidades_X_Medicos_DAL.dtParametros);

                obj_Especialidades_X_Medicos_DAL.dtParametros.Rows.Add("@IdMedico", "1", obj_Especialidades_X_Medicos_DAL.iId_Medico);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Especialidades_X_Medicos"];
                obj_BD_DAL.DT_Parametros = obj_Especialidades_X_Medicos_DAL.dtParametros;
                obj_BD_DAL.sNomTabla = "Especialidades_X_Medicos";

                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Especialidades_X_Medicos_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Especialidades_X_Medicos_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void asignarEspecialidadMedico(ref cls_Especialidades_X_Medicos_DAL obj_Especialidades_X_Medicos_DAL)
        {
            try
            {
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                obj_Especialidades_X_Medicos_DAL.dtParametros = null;
                obj_Especialidades_X_Medicos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Especialidades_X_Medicos_DAL.dtParametros);

                obj_Especialidades_X_Medicos_DAL.dtParametros.Rows.Add("@Id_Medico", "1", obj_Especialidades_X_Medicos_DAL.iId_Medico);
                obj_Especialidades_X_Medicos_DAL.dtParametros.Rows.Add("@Id_TipoEspecialidad", "1", obj_Especialidades_X_Medicos_DAL.iId_TipoEspecialidad);
                obj_Especialidades_X_Medicos_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Especialidades_X_Medicos_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Asignar_Especialidad_Medico"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Especialidades_X_Medicos_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Especialidades_X_Medicos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Especialidades_X_Medicos_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Especialidades_X_Medicos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Especialidades_X_Medicos_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarEspecialidadMedico(ref cls_Especialidades_X_Medicos_DAL obj_Especialidades_X_Medicos_DAL)
        {
            try
            {
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                obj_Especialidades_X_Medicos_DAL.dtParametros = null;
                obj_Especialidades_X_Medicos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Especialidades_X_Medicos_DAL.dtParametros);

                obj_Especialidades_X_Medicos_DAL.dtParametros.Rows.Add("@IdEspecialidadMedico", "1", obj_Especialidades_X_Medicos_DAL.iId_Especialidad_Medico);
                obj_Especialidades_X_Medicos_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Especialidades_X_Medicos_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Eliminar_Especialidad_Medico"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Especialidades_X_Medicos_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Especialidades_X_Medicos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Especialidades_X_Medicos_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Especialidades_X_Medicos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Especialidades_X_Medicos_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}