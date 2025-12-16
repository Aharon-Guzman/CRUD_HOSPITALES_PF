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
    public class cls_Pacientes_BLL
    {
        public void listarFiltrarPacientes(ref cls_Pacientes_DAL obj_Pacientes_DAL)
        {
            try
            {
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                if (
                    ((obj_Pacientes_DAL.sNombre == string.Empty) || (obj_Pacientes_DAL.sNombre == null))
                    &&
                    ((obj_Pacientes_DAL.sPrim_Apellido == string.Empty) || (obj_Pacientes_DAL.sPrim_Apellido == null))
                    &&
                    ((obj_Pacientes_DAL.iTipo_Identificacion == 0))
                    )
                {
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Pacientes"];
                    obj_BD_DAL.DT_Parametros = null;
                    obj_BD_DAL.sNomTabla = "Pacientes";
                }
                else
                {
                    obj_Pacientes_DAL.dtParametros = null;
                    obj_Pacientes_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Pacientes_DAL.dtParametros);

                    obj_Pacientes_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Pacientes_DAL.sNombre);
                    obj_Pacientes_DAL.dtParametros.Rows.Add("@Prim_Apellido", "6", obj_Pacientes_DAL.sPrim_Apellido);
                    obj_Pacientes_DAL.dtParametros.Rows.Add("@Tipo_Identificacion", "1", obj_Pacientes_DAL.iTipo_Identificacion);

                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FIL_Pacientes"];
                    obj_BD_DAL.DT_Parametros = obj_Pacientes_DAL.dtParametros;
                    obj_BD_DAL.sNomTabla = "Pacientes";
                }

                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Pacientes_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Pacientes_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Obtiene_Informacion_Pacientes(ref cls_Pacientes_DAL obj_Pacientes_DAL)
        {
            try
            {
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                obj_Pacientes_DAL.dtParametros = null;
                obj_Pacientes_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Pacientes_DAL.dtParametros);

                obj_Pacientes_DAL.dtParametros.Rows.Add("@IdPaciente", "1", obj_Pacientes_DAL.iId_Paciente);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Pacientes"];
                obj_BD_DAL.DT_Parametros = obj_Pacientes_DAL.dtParametros;
                obj_BD_DAL.sNomTabla = "Pacientes";

                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Pacientes_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Pacientes_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void crearPacientes(ref cls_Pacientes_DAL obj_Pacientes_DAL)
        {
            try
            {
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                obj_Pacientes_DAL.dtParametros = null;
                obj_Pacientes_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Pacientes_DAL.dtParametros);

                obj_Pacientes_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Pacientes_DAL.sNombre);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Prim_Apellido", "6", obj_Pacientes_DAL.sPrim_Apellido);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Seg_Apellido", "6", obj_Pacientes_DAL.sSeg_Apellido);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Tipo_Identificacion", "1", obj_Pacientes_DAL.iTipo_Identificacion);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Identificacion", "6", obj_Pacientes_DAL.sIdentificacion);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Pacientes_DAL.sTelefono);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Pacientes_DAL.sCorreo);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Fecha_Nacimiento", "8", obj_Pacientes_DAL.dFecha_Nacimiento);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Direccion", "6", obj_Pacientes_DAL.sDireccion);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Pacientes_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Pacientes"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Pacientes_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Pacientes_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Pacientes_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Pacientes_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Pacientes_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void modificarPacientes(ref cls_Pacientes_DAL obj_Pacientes_DAL)
        {
            try
            {
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                obj_Pacientes_DAL.dtParametros = null;
                obj_Pacientes_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Pacientes_DAL.dtParametros);

                obj_Pacientes_DAL.dtParametros.Rows.Add("@IdPaciente", "1", obj_Pacientes_DAL.iId_Paciente);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Pacientes_DAL.sNombre);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Prim_Apellido", "6", obj_Pacientes_DAL.sPrim_Apellido);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Seg_Apellido", "6", obj_Pacientes_DAL.sSeg_Apellido);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Tipo_Identificacion", "1", obj_Pacientes_DAL.iTipo_Identificacion);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Identificacion", "6", obj_Pacientes_DAL.sIdentificacion);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Pacientes_DAL.sTelefono);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Pacientes_DAL.sCorreo);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Fecha_Nacimiento", "8", obj_Pacientes_DAL.dFecha_Nacimiento);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@Direccion", "6", obj_Pacientes_DAL.sDireccion);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Pacientes_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Pacientes"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Pacientes_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Pacientes_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Pacientes_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Pacientes_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Pacientes_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarPacientes(ref cls_Pacientes_DAL obj_Pacientes_DAL)
        {
            try
            {
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();

                obj_Pacientes_DAL.dtParametros = null;
                obj_Pacientes_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Pacientes_DAL.dtParametros);

                obj_Pacientes_DAL.dtParametros.Rows.Add("@IdPaciente", "1", obj_Pacientes_DAL.iId_Paciente);
                obj_Pacientes_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Pacientes_DAL.iIdUsuarioGlobal);

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Delete_Pacientes"];
                obj_BD_DAL.sIndAxn = "SCALAR";
                obj_BD_DAL.DT_Parametros = obj_Pacientes_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Pacientes_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Pacientes_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Pacientes_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Pacientes_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}