//using BLL_CRUD_HOSPITALES.Mantenimientos;
//using DAL_CRUD_HOSPITALES.Mantenimientos;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.Services;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace PL_CRUD_HOSPITALES.Login
//{
//    public partial class frmInicioSesion : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {

//        }
//        [WebMethod]
//        public static string InicioSesionUsuarios(List<string> obj_Parametros_JS)
//        {
//            try
//            {
//                string _mensaje = string.Empty;

//                //Objetos de la entidad con la que estamos trabajando
//                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
//                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

//                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
//                obj_Usuarios_DAL.sCorreo = obj_Parametros_JS[0].ToString();
//                obj_Usuarios_DAL.sPassword = obj_Parametros_JS[1].ToString();

//                //Ejecutar en la lógica de negocio el proceso o la acción necesaria
//                obj_Usuarios_BLL.Inicio_Sesion_Usuarios(ref obj_Usuarios_DAL);

//                //Recuperamos y evaluamos los valores scalares y / o de respuesta de BD 
//                if (obj_Usuarios_DAL.sValorScalar == "-1")
//                {
//                    _mensaje = "-1" + "<SPLITER>" + "El usuario se encuentra inactivo, por favor contacte al administrador del sistema.";
//                }
//                else if (obj_Usuarios_DAL.sValorScalar == "0")
//                {
//                    _mensaje = "0" + "<SPLITER>" + "Las credenciaes de acceso no son válidas. Verifique!!!.";
//                }
//                else
//                {
//                    obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Usuarios_DAL.sValorScalar);

//                    obj_Usuarios_BLL.Obtiene_Informacion_Usuarios(ref obj_Usuarios_DAL);

//                    _mensaje = obj_Usuarios_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
//                            "Bienvenido de nuevo: " + obj_Usuarios_DAL.dtDatos.Rows[0][1].ToString() + " " +
//                                                      obj_Usuarios_DAL.dtDatos.Rows[0][2].ToString() + " " +
//                                                      obj_Usuarios_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
//                            obj_Usuarios_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
//                            obj_Usuarios_DAL.dtDatos.Rows[0][1].ToString() + " " +
//                            obj_Usuarios_DAL.dtDatos.Rows[0][2].ToString() + " " +
//                            obj_Usuarios_DAL.dtDatos.Rows[0][3].ToString();
//                }
//                return _mensaje;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        [WebMethod]
//        public static string CierreSesionUsuarios(List<string> obj_Parametros_JS)
//        {
//            try
//            {
//                String _mensaje = string.Empty;

//                cls_Usuarios_DAL Obj_Usuarios_DAL = new cls_Usuarios_DAL();
//                cls_Usuarios_BLL Obj_Usuarios_BLL = new cls_Usuarios_BLL();

//                //establecemos los atributos que necesitamos del usuario
//                Obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0].ToString());

//                //Ejecutamos la logica de negocio de usuarios
//                Obj_Usuarios_BLL.Cerrar_Sesion_Usuario(ref Obj_Usuarios_DAL);

//                if (Obj_Usuarios_DAL.sValorScalar != "0")
//                {
//                    _mensaje = Obj_Usuarios_DAL.sValorScalar;
//                }

//                return _mensaje;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        //[WebMethod]
//        //public static string cargaOpcionesMenuUsuarios(List<string> obj_Parametros_JS)
//        //{
//        //    try
//        //    {
//        //        string _mensaje = string.Empty;

//        //        cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
//        //        cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

//        //        obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0]);

//        //        obj_Usuarios_BLL.carga_Lista_Opciones_Menu_Usuario(ref obj_Usuarios_DAL);

//        //        if (obj_Usuarios_DAL.dtDatos.Rows.Count != 0)
//        //        {
//        //            DataView dv_opciones = obj_Usuarios_DAL.dtDatos.DefaultView;
//        //            dv_opciones.Sort = obj_Usuarios_DAL.dtDatos.Columns[4] + " ASC";

//        //            foreach (DataRowView row_view in dv_opciones)
//        //            {
//        //                _mensaje += "<li><a href='" + row_view[3].ToString() + "'><i class='" + row_view[2].ToString() + "'></i><span>" + row_view[1].ToString() + "</span></a></li>";
//        //            }
//        //        }
//        //        else
//        //        {
//        //            _mensaje = "No se encontraron registros";
//        //        }

//        //        return _mensaje;


//        //    }
//        //    catch (Exception ex)
//        //    {

//        //        throw ex;
//        //    }
//        //}
//    }
//}

using BLL_CRUD_HOSPITALES.Mantenimientos;
using DAL_CRUD_HOSPITALES.Mantenimientos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_CRUD_HOSPITALES.Login
{
    public partial class frmInicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string InicioSesionUsuarios(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Usuarios_DAL.sCorreo = obj_Parametros_JS[0].ToString();
                obj_Usuarios_DAL.sPassword = obj_Parametros_JS[1].ToString();

                //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                obj_Usuarios_BLL.Inicio_Sesion_Usuarios(ref obj_Usuarios_DAL);

                //Recuperamos y evaluamos los valores scalares y / o de respuesta de BD 
                if (obj_Usuarios_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "El usuario se encuentra inactivo, por favor contacte al administrador del sistema.";
                }
                else if (obj_Usuarios_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Las credenciaes de acceso no son válidas. Verifique!!!.";
                }
                else
                {
                    obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Usuarios_DAL.sValorScalar);

                    obj_Usuarios_BLL.Obtiene_Informacion_Usuarios(ref obj_Usuarios_DAL);

                    _mensaje = obj_Usuarios_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                            "Bienvenido de nuevo: " + obj_Usuarios_DAL.dtDatos.Rows[0][1].ToString() + " " +
                                                      obj_Usuarios_DAL.dtDatos.Rows[0][2].ToString() + " " +
                                                      obj_Usuarios_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                            obj_Usuarios_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
                            obj_Usuarios_DAL.dtDatos.Rows[0][1].ToString() + " " +
                            obj_Usuarios_DAL.dtDatos.Rows[0][2].ToString() + " " +
                            obj_Usuarios_DAL.dtDatos.Rows[0][3].ToString();
                }
                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string CierreSesionUsuarios(List<string> obj_Parametros_JS)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Usuarios_DAL Obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL Obj_Usuarios_BLL = new cls_Usuarios_BLL();

                //establecemos los atributos que necesitamos del usuario
                Obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                //Ejecutamos la logica de negocio de usuarios
                Obj_Usuarios_BLL.Cerrar_Sesion_Usuario(ref Obj_Usuarios_DAL);

                if (Obj_Usuarios_DAL.sValorScalar != "0")
                {
                    _mensaje = Obj_Usuarios_DAL.sValorScalar;
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string cargaOpcionesMenuUsuarios(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

                obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0]);

                obj_Usuarios_BLL.carga_Lista_Opciones_Menu_Usuario(ref obj_Usuarios_DAL);

                if (obj_Usuarios_DAL.dtDatos.Rows.Count != 0)
                {
                    // ========================================
                    // MAPEO DE COLUMNAS DEL SP:
                    // ========================================
                    // [0] = Id_Modulo_Usuario
                    // [1] = Modulo (nombre)
                    // [2] = ClaseCss (no se usa)
                    // [3] = Enlace (URL)
                    // [4] = MODL (Id_Modulo para ordenar)
                    // [5] = Categoria
                    // [6] = Orden_Categoria
                    // [7] = SvgPath (ícono del módulo)
                    // [8] = ViewBox (viewBox del módulo)
                    // [9] = Icono_Categoria (SVG de la categoría)
                    // [10] = ViewBox_Categoria

                    DataTable dt = obj_Usuarios_DAL.dtDatos;

                    // ========================================
                    // PASO 1: Agregar Panel de Control (siempre primero)
                    // ========================================
                    DataRow panelRow = dt.Rows.Cast<DataRow>().FirstOrDefault(r => r[5] == DBNull.Value || string.IsNullOrEmpty(r[5].ToString()));
                    if (panelRow != null)
                    {
                        string svgPath = panelRow[7].ToString();
                        string viewBox = panelRow[8].ToString();
                        string svgHtml = ConstruirSVG(svgPath, viewBox, true);

                        _mensaje += "<li class=\"nav-item\">" +
                                    "<a href=\"" + panelRow[3].ToString() + "\">" +
                                    "<span class=\"icon\">" + svgHtml + "</span>" +
                                    "<span class=\"text\">" + panelRow[1].ToString() + "</span>" +
                                    "</a>" +
                                    "</li>";

                        // Agregar divider después del Panel de Control
                        _mensaje += "<span class=\"divider\"><hr /></span>";
                    }

                    // ========================================
                    // PASO 2: Agrupar módulos por categoría
                    // ========================================
                    var categorias = dt.Rows.Cast<DataRow>()
                        .Where(r => r[5] != DBNull.Value && !string.IsNullOrEmpty(r[5].ToString()))
                        .GroupBy(r => new
                        {
                            Categoria = r[5].ToString(),
                            Orden = Convert.ToInt32(r[6]),
                            IconoCategoria = r[9].ToString(),
                            ViewBoxCategoria = r[10].ToString()
                        })
                        .OrderBy(g => g.Key.Orden);

                    // ========================================
                    // PASO 3: Construir HTML por categoría
                    // ========================================
                    int contadorCategoria = 0;
                    foreach (var categoria in categorias)
                    {
                        contadorCategoria++;

                        // Generar ID único para el dropdown
                        string categoriaId = "ddmenu_" + contadorCategoria;

                        // SVG de la categoría
                        string svgCategoriaHtml = ConstruirSVG(categoria.Key.IconoCategoria, categoria.Key.ViewBoxCategoria, false);

                        // Abrir categoría con dropdown
                        _mensaje += "<li class=\"nav-item nav-item-has-children\">" +
                                    "<a href=\"#0\" class=\"collapsed\" " +
                                    "data-bs-toggle=\"collapse\" " +
                                    "data-bs-target=\"#" + categoriaId + "\" " +
                                    "aria-controls=\"" + categoriaId + "\" " +
                                    "aria-expanded=\"false\" " +
                                    "aria-label=\"Toggle navigation\">" +
                                    "<span class=\"icon\">" + svgCategoriaHtml + "</span>" +
                                    "<span class=\"text\">" + categoria.Key.Categoria + "</span>" +
                                    "</a>" +
                                    "<ul id=\"" + categoriaId + "\" class=\"collapse dropdown-nav\">";

                        // Agregar módulos de esta categoría
                        foreach (var modulo in categoria.OrderBy(m => m[1].ToString()))
                        {
                            _mensaje += "<li>" +
                                        "<a href=\"" + modulo[3].ToString() + "\">" +
                                        modulo[1].ToString() +
                                        "</a>" +
                                        "</li>";
                        }

                        // Cerrar categoría
                        _mensaje += "</ul></li>";
                    }
                }
                else
                {
                    _mensaje = "No se encontraron registros";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Construye el HTML del SVG según el formato requerido
        /// </summary>
        /// <param name="svgPath">Path del SVG</param>
        /// <param name="viewBox">ViewBox del SVG</param>
        /// <param name="esMultiplePath">True si el SVG tiene múltiples paths separados por |</param>
        /// <returns>HTML del SVG completo</returns>
        private static string ConstruirSVG(string svgPath, string viewBox, bool esMultiplePath)
        {
            if (string.IsNullOrEmpty(svgPath))
                return "";

            string svgHtml = "";

            if (esMultiplePath && svgPath.Contains("|"))
            {
                // Panel de Control: múltiples paths sin transform
                string[] paths = svgPath.Split('|');
                svgHtml = "<svg width=\"20\" height=\"20\" viewBox=\"" + viewBox + "\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">";
                foreach (string path in paths)
                {
                    svgHtml += "<path d=\"" + path.Trim() + "\" />";
                }
                svgHtml += "</svg>";
            }
            else
            {
                // Categorías y otros módulos: un path con transform
                svgHtml = "<svg width=\"20\" height=\"20\" viewBox=\"" + viewBox + "\" fill=\"currentColor\" xmlns=\"http://www.w3.org/2000/svg\">" +
                          "<g transform=\"scale(1, -1) translate(0, -256)\">" +
                          "<path d=\"" + svgPath + "\" />" +
                          "</g>" +
                          "</svg>";
            }

            return svgHtml;
        }
    }
}