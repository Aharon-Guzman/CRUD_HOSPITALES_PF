using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_HOSPITALES.Mantenimientos
{
    public class cls_Tipos_Especialidad_DAL
    {
        #region Atributos Privados de la Entidad

        // Campos de la tabla Tipos_Especialidades
        private int _iId_TipoEspecialidad;
        private string _sTipo_Especialidad;
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

        public int iId_TipoEspecialidad { get => _iId_TipoEspecialidad; set => _iId_TipoEspecialidad = value; }
        public string sTipo_Especialidad { get => _sTipo_Especialidad; set => _sTipo_Especialidad = value; }
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
