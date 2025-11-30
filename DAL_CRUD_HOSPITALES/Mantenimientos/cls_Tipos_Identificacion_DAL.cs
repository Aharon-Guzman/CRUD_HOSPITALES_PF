using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_HOSPITALES.Mantenimientos
{
    public class cls_Tipos_Identificacion_DAL
    {
        #region Variables Privadas
        //Sección de campos de la tabla (NOMBRES EXACTOS DE LA BD)
        private int _iId_TipoIdentificacion;
        private string _sTipo_Identificacion;
        private string _sEstado;

        //Sección presente en todas las clases 
        private string _sValorScalar, _sAXN, _sMSJError;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        //Sección presente en todas las clases 
        #endregion

        #region Variables Públicas o Constructores
        // Campos de la tabla
        public int iId_TipoIdentificacion { get => _iId_TipoIdentificacion; set => _iId_TipoIdentificacion = value; }
        public string sTipo_Identificacion { get => _sTipo_Identificacion; set => _sTipo_Identificacion = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }

        // Campos auxiliares (presentes en todas las clases)
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}
