using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_HOSPITALES.Mantenimientos
{
    public class cls_Citas_DAL
    {
        #region Atributos Privados de la Entidad

        // Campos de la tabla Citas (7 campos)
        private int _iId_Cita;
        private int _iId_TipoCita;
        private int _iId_Medico;
        private int _iId_Paciente;
        private int _iId_Consultorio;
        private DateTime _dFecha;
        private string _sEstado;
        private string _sNombrePaciente;
        private string _sApellidoPaciente;
        private string _sNombreMedico;

        // Campos auxiliares (presentes en todas las clases DAL)
        private string _sValorScalar;
        private string _sAXN;
        private string _sMSJError;
        private DataTable _dtDatos;
        private DataTable _dtParametros;
        private int _iIdUsuarioGlobal;

        #endregion

        #region Propiedades Públicas de la Entidad

        public int iId_Cita { get => _iId_Cita; set => _iId_Cita = value; }
        public int iId_TipoCita { get => _iId_TipoCita; set => _iId_TipoCita = value; }
        public int iId_Medico { get => _iId_Medico; set => _iId_Medico = value; }
        public int iId_Paciente { get => _iId_Paciente; set => _iId_Paciente = value; }
        public int iId_Consultorio { get => _iId_Consultorio; set => _iId_Consultorio = value; }
        public DateTime dFecha { get => _dFecha; set => _dFecha = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public string sNombrePaciente { get => _sNombrePaciente; set => _sNombrePaciente = value; }
        public string sApellidoPaciente { get => _sApellidoPaciente; set => _sApellidoPaciente = value; }
        public string sNombreMedico { get => _sNombreMedico; set => _sNombreMedico = value; }

        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }

        #endregion
    }
}