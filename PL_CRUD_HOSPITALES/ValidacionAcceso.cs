using BLL_CRUD_HOSPITALES.Mantenimientos;
using DAL_CRUD_HOSPITALES.Mantenimientos;
using System;
using System.Data;
using System.Web;

namespace PL_CRUD_HOSPITALES
{
    /// <summary>
    /// Clase estática para validar el acceso de usuarios a módulos del sistema
    /// </summary>
    public static class ValidacionAcceso
    {
        /// <summary>
        /// Valida si el usuario actual tiene acceso al módulo (página) actual
        /// </summary>
        /// <returns>True si tiene acceso, False si no tiene acceso</returns>
        public static bool ValidarAccesoModulo()
        {
            try
            {
                // ====================================
                // PASO 1: Obtener ID del usuario de la cookie
                // ====================================
                HttpCookie cookie = HttpContext.Current.Request.Cookies["GLBUNI"];

                if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                {
                    // No hay sesión activa - redirigir a login
                    HttpContext.Current.Response.Redirect("~/Login/frmInicioSesion.aspx", true);
                    return false;
                }

                int idUsuario;
                if (!int.TryParse(cookie.Value, out idUsuario) || idUsuario == 0)
                {
                    // Cookie inválida - redirigir a login
                    HttpContext.Current.Response.Redirect("~/Login/frmInicioSesion.aspx", true);
                    return false;
                }

                // ====================================
                // PASO 2: Obtener nombre del archivo actual
                // ====================================
                string urlActual = System.IO.Path.GetFileName(HttpContext.Current.Request.PhysicalPath);

                // EXCEPCIÓN: frmPrincipal.aspx (Panel de Control) es accesible para todos
                if (urlActual.Equals("frmPrincipal.aspx", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                // EXCEPCIÓN: frmAccesoDenegado.aspx debe ser accesible
                if (urlActual.Equals("frmAccesoDenegado.aspx", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                // ====================================
                // PASO 3: Obtener módulos del usuario desde BD
                // ====================================
                cls_Usuarios_DAL obj_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_BLL = new cls_Usuarios_BLL();

                obj_DAL.iId_Usuario = idUsuario;
                obj_BLL.carga_Lista_Opciones_Menu_Usuario(ref obj_DAL);

                if (obj_DAL.dtDatos == null || obj_DAL.dtDatos.Rows.Count == 0)
                {
                    // Usuario sin módulos asignados
                    return false;
                }

                // ====================================
                // PASO 4: Verificar si la URL actual está en los módulos del usuario
                // ====================================
                foreach (DataRow row in obj_DAL.dtDatos.Rows)
                {
                    string enlaceModulo = row["Enlace"].ToString();

                    if (enlaceModulo.Equals(urlActual, StringComparison.OrdinalIgnoreCase))
                    {
                        // El usuario SÍ tiene acceso a este módulo
                        return true;
                    }
                }

                // ====================================
                // PASO 5: No se encontró el módulo - NO TIENE ACCESO
                // ====================================
                return false;
            }
            catch (Exception ex)
            {
                // En caso de error, denegar acceso por seguridad
                System.Diagnostics.Debug.WriteLine("Error en ValidacionAcceso: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Redirige a la página de acceso denegado si el usuario no tiene permisos
        /// </summary>
        public static void ValidarYRedirigir()
        {
            if (!ValidarAccesoModulo())
            {
                HttpContext.Current.Response.Redirect("~/Mantenimientos/frmAccesoDenegado.aspx", true);
            }
        }
    }
}
