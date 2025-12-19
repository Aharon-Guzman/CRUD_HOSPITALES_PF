using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_HOSPITALES.Mantenimientos
{
    /// <summary>
    /// Clase de Acceso a Datos para Dashboard
    /// </summary>
    public class cls_Dashboard_DAL
    {
        // ========================================
        // Propiedades para Cards (Tarjetas)
        // ========================================
        public DataTable dtTotalPacientes { get; set; }
        public DataTable dtCitasHoy { get; set; }
        public DataTable dtTotalMedicos { get; set; }
        public DataTable dtTotalHospitales { get; set; }

        // ========================================
        // Propiedades para Gráficas
        // ========================================
        public DataTable dtCitasPorMes { get; set; }
        public DataTable dtPacientesPorTipoCita { get; set; }

        // ========================================
        // Propiedades para Tabla
        // ========================================
        public DataTable dtProximasCitas { get; set; }

        // ========================================
        // Propiedades para Info Adicional
        // ========================================
        public DataTable dtTopEspecialidades { get; set; }
        public DataTable dtTopHospitales { get; set; }

        // ========================================
        // Propiedad para manejar errores
        // ========================================
        public string sMensajeError { get; set; }
    }
}
