<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaTiposIdentificacion.aspx.cs" Inherits="PL_CRUD_HOSPITALES.Mantenimientos.frmConsultaTiposIdentificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
     <!-- ========== title-wrapper start ========== -->
    <div class="title-wrapper pt-30">
        <div class="row align-items-center">
            <div class="col-md-6">
                <div class="title mb-30">
                    <h2>Gestión de Tipos de Identificación</h2>
                </div>
            </div>
            <div class="col-md-6">
                <div class="breadcrumb-wrapper mb-30">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item">
                                <a href="frmPrincipal.aspx">Dashboard</a>
                            </li>
                            <li class="breadcrumb-item">
                                <a href="#0">Catálogos</a>
                            </li>
                            <li class="breadcrumb-item active" aria-current="page">
                                Tipos de Identificación
                            </li>
                        </ol>
                    </nav>
                </div>
            </div>
        </div>

    <!-- ========== title-wrapper end ========== -->

    <!-- ========== form-elements-wrapper start ========== -->
    <div class="form-elements-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <!-- ========== Formulario de Búsqueda ========== -->
                <div class="card-style mb-30">
                    <h6 class="mb-25">Búsqueda de Tipos de Identificación</h6>
                    <form action="javascript: cargaListaTiposIdentificacion()" method="post" id="frmBusqueda">
                        <div class="row">
                            <div class="col-md-5">
                                <div class="input-style-1">
                                    <label>Tipo de Identificación</label>
                                    <input type="text" class="form-control" id="bsqTipo_Identificacion" placeholder="Ej: Cédula, Pasaporte, DIMEX" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="select-style-1">
                                    <label for="bsqEstado" class="input__label">Estado</label>
                                    <div class="select-position">
                                        <select id="bsqEstado">
                                            <option value="">Todos</option>
                                            <option value="Activo">Activo</option>
                                            <option value="Inactivo">Inactivo</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="input-style-1">
                                    <label>&nbsp;</label>
                                    <button type="button" class="main-btn primary-btn btn-hover" onclick="cargaListaTipos_Identificacion()">
                                        <i class="lni lni-search-alt"></i> Buscar
                                    </button>
                                    <button type="button" class="main-btn success-btn btn-hover ms-2" onclick="crearTipo_Identificacion()">
                                        <i class="lni lni-plus"></i> Nuevo
                                    </button>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
                <!-- ========== Fin Formulario de Búsqueda ========== -->

                <!-- ========== Tabla de Resultados ========== -->
                <div class="card-style mb-30">
                    <h6 class="mb-25">Listado de Tipos de Identificación</h6>
<%--                    <div class="table-wrapper table-responsive" id="divTablaTipos_Identificacion">
                        <!-- La tabla se carga dinámicamente desde JavaScript -->
                  </div>--%>
                    <div class="table-wrapper table-responsive">
                       <table id="tblTiposIdentificacion">
             <%--Aquí se carga el contenido dinámico de la tabla--%>
                        </table>
                    </div>
                </div>
                <!-- ========== Fin Tabla de Resultados ========== -->
            </div>
        </div>
    </div>
    <!-- ========== form-elements-wrapper end ========== -->

    <!-- ========== Modal Mantenimiento ========== -->
    <div class="modal fade" id="modalMantenimiento" tabindex="-1" aria-labelledby="modalMantenimientoLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalMantenimientoLabel">Mantenimiento de Tipo de Identificación</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form id="frmMantenimiento">
                        <input type="hidden" id="txtId_TipoIdentificacion" value="0" />
                        
                        <div class="input-style-1">
                            <label>Tipo de Identificación <span class="text-danger">*</span></label>
                            <input type="text" class="form-control" id="txtTipo_Identificacion" 
                                   placeholder="Ej: Cédula Nacional, Pasaporte, DIMEX" 
                                   maxlength="50" required />
                        </div>

                        <div class="select-style-1">
                            <label>Estado <span class="text-danger">*</span></label>
                            <div class="select-position">
                                <select id="cboEstado" required>
                                    <option value="A">Activo</option>
                                    <option value="I">Inactivo</option>
                                </select>
                            </div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="main-btn danger-btn-outline btn-hover" data-bs-dismiss="modal">Cancelar</button>
                    <button type="button" class="main-btn primary-btn btn-hover" onclick="guardarTipo_Identificacion()">
                        <i class="lni lni-save"></i> Guardar
                    </button>
                </div>
            </div>
        </div>
    </div>
    </div>
    <!-- ========== Fin Modal Mantenimiento ========== -->

    <!-- ========== JavaScript ========== -->
    <script src="../JavaScript/Identificacion.js"></script>

</asp:Content>
