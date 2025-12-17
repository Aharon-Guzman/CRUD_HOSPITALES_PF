using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_HOSPITALES.Mantenimientos
{
    public class cls_ModulosXUsuario_DAL
    {
        #region Atributos Privados de la Entidad

        // Campos de la tabla Modulos_X_Usuario
        private int _iId_Modulo_Usuario;
        private int _iId_Usuario;
        private int _iId_Modulo;

        // Campos auxiliares
        private string _sValorScalar;
        private string _sMSJError;
        private DataTable _dtDatos;
        private DataTable _dtParametros;
        private int _iIdUsuarioGlobal;

        #endregion

        #region Propiedades Públicas de la Entidad

        public int iId_Modulo_Usuario { get => _iId_Modulo_Usuario; set => _iId_Modulo_Usuario = value; }
        public int iId_Usuario { get => _iId_Usuario; set => _iId_Usuario = value; }
        public int iId_Modulo { get => _iId_Modulo; set => _iId_Modulo = value; }

        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }

        #endregion
    }
}