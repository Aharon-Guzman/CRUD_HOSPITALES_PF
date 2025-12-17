using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_HOSPITALES.Mantenimientos
{
    public class cls_Modulos_DAL
    {
        #region Atributos Privados de la Entidad

        // Campos de la tabla Modulos
        private int _iId_Modulo;
        private string _sNombre_Modulo;
        private string _sRuta;
        private string _sIcono;

        // Campos auxiliares
        private DataTable _dtDatos;
        private int _iIdUsuarioGlobal;

        #endregion

        #region Propiedades Públicas de la Entidad

        public int iId_Modulo { get => _iId_Modulo; set => _iId_Modulo = value; }
        public string sNombre_Modulo { get => _sNombre_Modulo; set => _sNombre_Modulo = value; }
        public string sRuta { get => _sRuta; set => _sRuta = value; }
        public string sIcono { get => _sIcono; set => _sIcono = value; }

        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }

        #endregion
    }
}