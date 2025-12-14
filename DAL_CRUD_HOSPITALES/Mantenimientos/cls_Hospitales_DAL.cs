using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_HOSPITALES.Mantenimientos
{
    public class cls_Hospitales_DAL
    {
        #region Atributos Privados de la Entidad
        private int _iId_Hospital, _iArea;
        private string _sCod_Hospital, _sDescripcion, _sDireccion, _sTelefono, _sCorreo, _sWeb, _sEstado;
        private DateTime _dFecha_Construccion;

        // Campos auxiliares (presentes en todas las clases DAL)
        private string _sValorScalar;
        private string _sAXN;
        private string _sMSJError;
        private DataTable _dtDatos;
        private DataTable _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion

        #region Propiedades Públicas de la Entidad
        public int iId_Hospital { get => _iId_Hospital; set => _iId_Hospital = value; }
        public int iArea { get => _iArea; set => _iArea = value; }
        public string sCod_Hospital { get => _sCod_Hospital; set => _sCod_Hospital = value; }
        public string sDescripcion { get => _sDescripcion; set => _sDescripcion = value; }
        public string sDireccion { get => _sDireccion; set => _sDireccion = value; }
        public string sTelefono { get => _sTelefono; set => _sTelefono = value; }
        public string sCorreo { get => _sCorreo; set => _sCorreo = value; }
        public string sWeb { get => _sWeb; set => _sWeb = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public DateTime dFecha_Construccion { get => _dFecha_Construccion; set => _dFecha_Construccion = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}
