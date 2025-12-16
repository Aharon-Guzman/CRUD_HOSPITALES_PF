using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_HOSPITALES.Mantenimientos
{
    public class cls_Medicos_DAL
    {
        #region Atributos Privados de la Entidad

        // Campos de la tabla Medicos
        private int _iId_Medico;
        private string _sNombre;
        private string _sPrim_Apellido;
        private string _sSeg_Apellido;
        private int _iTipo_Identificacion;
        private string _sIdentificacion;
        private string _sTelefono;
        private string _sCorreo;
        private string _sCod_Profesional;

        // Campos auxiliares (presentes en todas las clases DAL)
        private string _sValorScalar;
        private string _sAXN;
        private string _sMSJError;
        private DataTable _dtDatos;
        private DataTable _dtParametros;
        private int _iIdUsuarioGlobal;

        #endregion

        #region Propiedades Públicas de la Entidad

        public int iId_Medico { get => _iId_Medico; set => _iId_Medico = value; }
        public string sNombre { get => _sNombre; set => _sNombre = value; }
        public string sPrim_Apellido { get => _sPrim_Apellido; set => _sPrim_Apellido = value; }
        public string sSeg_Apellido { get => _sSeg_Apellido; set => _sSeg_Apellido = value; }
        public int iTipo_Identificacion { get => _iTipo_Identificacion; set => _iTipo_Identificacion = value; }
        public string sIdentificacion { get => _sIdentificacion; set => _sIdentificacion = value; }
        public string sTelefono { get => _sTelefono; set => _sTelefono = value; }
        public string sCorreo { get => _sCorreo; set => _sCorreo = value; }
        public string sCod_Profesional { get => _sCod_Profesional; set => _sCod_Profesional = value; }

        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }

        #endregion
    }
}