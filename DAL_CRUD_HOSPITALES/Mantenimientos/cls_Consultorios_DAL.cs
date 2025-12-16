using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_HOSPITALES.Mantenimientos
{
    public class cls_Consultorios_DAL
    {
        #region Atributos Privados de la Entidad

        // Campos de la tabla Consultorios
        private int _iId_Consultorio;
        private int _iId_Hospital;
        private int _iId_TipoConsultorio;
        private string _sDescripcion;
        private string _sEstado;

        // Campos auxiliares (presentes en todas las clases DAL)
        private string _sValorScalar;
        private string _sAXN;
        private string _sMSJError;
        private DataTable _dtDatos;
        private DataTable _dtParametros;
        private int _iIdUsuarioGlobal;

        #endregion

        #region Propiedades Públicas de la Entidad

        public int iId_Consultorio { get => _iId_Consultorio; set => _iId_Consultorio = value; }
        public int iId_Hospital { get => _iId_Hospital; set => _iId_Hospital = value; }
        public int iId_TipoConsultorio { get => _iId_TipoConsultorio; set => _iId_TipoConsultorio = value; }
        public string sDescripcion { get => _sDescripcion; set => _sDescripcion = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }

        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }

        #endregion
    }
}