using DAL_CRUD_HOSPITALES.Mantenimientos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_CRUD_HOSPITALES.Mantenimientos
{
    /// <summary>
    /// Clase de Lógica de Negocio para Dashboard
    /// </summary>
    public class cls_Dashboard_BLL
    {
        // ========================================
        // Cadena de conexión
        // ========================================
        private static string sConexion = ConfigurationManager.ConnectionStrings["WIN_AUT"].ConnectionString;

        // ========================================
        // MÉTODO 1: Obtener Total de Pacientes
        // ========================================
        public void ObtenerTotalPacientes(ref cls_Dashboard_DAL obj_DAL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_Dashboard_TotalPacientes", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        obj_DAL.dtTotalPacientes = new DataTable();
                        da.Fill(obj_DAL.dtTotalPacientes);
                    }
                }
            }
            catch (Exception ex)
            {
                obj_DAL.sMensajeError = ex.Message;
            }
        }

        // ========================================
        // MÉTODO 2: Obtener Citas de Hoy
        // ========================================
        public void ObtenerCitasHoy(ref cls_Dashboard_DAL obj_DAL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_Dashboard_CitasHoy", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        obj_DAL.dtCitasHoy = new DataTable();
                        da.Fill(obj_DAL.dtCitasHoy);
                    }
                }
            }
            catch (Exception ex)
            {
                obj_DAL.sMensajeError = ex.Message;
            }
        }

        // ========================================
        // MÉTODO 3: Obtener Total de Médicos
        // ========================================
        public void ObtenerTotalMedicos(ref cls_Dashboard_DAL obj_DAL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_Dashboard_TotalMedicos", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        obj_DAL.dtTotalMedicos = new DataTable();
                        da.Fill(obj_DAL.dtTotalMedicos);
                    }
                }
            }
            catch (Exception ex)
            {
                obj_DAL.sMensajeError = ex.Message;
            }
        }

        // ========================================
        // MÉTODO 4: Obtener Total de Hospitales
        // ========================================
        public void ObtenerTotalHospitales(ref cls_Dashboard_DAL obj_DAL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_Dashboard_TotalHospitales", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        obj_DAL.dtTotalHospitales = new DataTable();
                        da.Fill(obj_DAL.dtTotalHospitales);
                    }
                }
            }
            catch (Exception ex)
            {
                obj_DAL.sMensajeError = ex.Message;
            }
        }

        // ========================================
        // MÉTODO 5: Obtener Citas por Mes
        // ========================================
        public void ObtenerCitasPorMes(ref cls_Dashboard_DAL obj_DAL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_Dashboard_CitasPorMes", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        obj_DAL.dtCitasPorMes = new DataTable();
                        da.Fill(obj_DAL.dtCitasPorMes);
                    }
                }
            }
            catch (Exception ex)
            {
                obj_DAL.sMensajeError = ex.Message;
            }
        }

        // ========================================
        // MÉTODO 6: Obtener Pacientes por Tipo de Cita
        // ========================================
        public void ObtenerPacientesPorTipoCita(ref cls_Dashboard_DAL obj_DAL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_Dashboard_PacientesPorTipoCita", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        obj_DAL.dtPacientesPorTipoCita = new DataTable();
                        da.Fill(obj_DAL.dtPacientesPorTipoCita);
                    }
                }
            }
            catch (Exception ex)
            {
                obj_DAL.sMensajeError = ex.Message;
            }
        }

        // ========================================
        // MÉTODO 7: Obtener Próximas Citas del Día
        // ========================================
        public void ObtenerProximasCitasHoy(ref cls_Dashboard_DAL obj_DAL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_Dashboard_ProximasCitasHoy", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        obj_DAL.dtProximasCitas = new DataTable();
                        da.Fill(obj_DAL.dtProximasCitas);
                    }
                }
            }
            catch (Exception ex)
            {
                obj_DAL.sMensajeError = ex.Message;
            }
        }

        // ========================================
        // MÉTODO 8: Obtener Top Especialidades
        // ========================================
        public void ObtenerTopEspecialidades(ref cls_Dashboard_DAL obj_DAL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_Dashboard_TopEspecialidades", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        obj_DAL.dtTopEspecialidades = new DataTable();
                        da.Fill(obj_DAL.dtTopEspecialidades);
                    }
                }
            }
            catch (Exception ex)
            {
                obj_DAL.sMensajeError = ex.Message;
            }
        }

        // ========================================
        // MÉTODO 9: Obtener Top Hospitales
        // ========================================
        public void ObtenerTopHospitales(ref cls_Dashboard_DAL obj_DAL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_Dashboard_TopHospitales", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        obj_DAL.dtTopHospitales = new DataTable();
                        da.Fill(obj_DAL.dtTopHospitales);
                    }
                }
            }
            catch (Exception ex)
            {
                obj_DAL.sMensajeError = ex.Message;
            }
        }
    }
}
