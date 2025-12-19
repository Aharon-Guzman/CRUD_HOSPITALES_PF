using System;
using System.Data;

namespace DAL_CRUD_HOSPITALES.Mantenimientos
{
    public class cls_Dashboard_DAL
    {
        #region Variables Privadas
        private int _iTotalPacientes, _iCitasHoy, _iTotalMedicos, _iTotalHospitales;
        private string _sMSJError;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion

        #region Propiedades
        public int iTotalPacientes { get => _iTotalPacientes; set => _iTotalPacientes = value; }
        public int iCitasHoy { get => _iCitasHoy; set => _iCitasHoy = value; }
        public int iTotalMedicos { get => _iTotalMedicos; set => _iTotalMedicos = value; }
        public int iTotalHospitales { get => _iTotalHospitales; set => _iTotalHospitales = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}