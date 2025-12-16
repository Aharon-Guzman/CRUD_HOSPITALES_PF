using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_HOSPITALES.Mantenimientos
{
    public class cls_Especialidades_X_Medicos_DAL
    {
        #region Atributos Privados de la Entidad

        private int _iId_Especialidad_Medico;
        private int _iId_Medico;
        private int _iId_TipoEspecialidad;

        private string _sValorScalar;
        private string _sAXN;
        private string _sMSJError;
        private DataTable _dtDatos;
        private DataTable _dtParametros;
        private int _iIdUsuarioGlobal;

        #endregion

        #region Propiedades Públicas de la Entidad

        public int iId_Especialidad_Medico { get => _iId_Especialidad_Medico; set => _iId_Especialidad_Medico = value; }
        public int iId_Medico { get => _iId_Medico; set => _iId_Medico = value; }
        public int iId_TipoEspecialidad { get => _iId_TipoEspecialidad; set => _iId_TipoEspecialidad = value; }

        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }

        #endregion
    }
}