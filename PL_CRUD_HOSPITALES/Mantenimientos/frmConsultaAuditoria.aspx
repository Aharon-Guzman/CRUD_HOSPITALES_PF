<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaAuditoria.aspx.cs" Inherits="PL_CRUD_HOSPITALES.Mantenimientos.frmConsultaAuditoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <!-- ========== ENCABEZADO Y BREADCRUMB ========== -->
    <div class="title-wrapper pt-30">
        <div class="row align-items-center">
            <div class="col-md-6">
                <div class="title mb-30">
                    <h2>Consulta de Auditoría</h2>
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
                                <a href="#0">Seguridad</a>
                            </li>
                            <li class="breadcrumb-item active" aria-current="page">
                                Auditoría
                            </li>
                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </div>

    <!-- ========== FORMULARIO DE BÚSQUEDA ========== -->
    <div class="form-elements-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <div class="card-style mb-30">
                    <h6 class="mb-25">Filtros de Búsqueda</h6>
                    <form action="javascript: cargaListaAuditoria()" method="post" id="frmBusqueda">
                        <div class="row">
                            <!-- Usuario -->
                            <div class="col-md-6">
                                <div class="select-style-1">
                                    <label>Usuario</label>
                                    <div class="select-position">
                                        <select id="bsqUsuario">
                                            <option value="0">Todos</option>
                                            <%-- Se llena dinámicamente --%>
                                        </select>
                                    </div>
                                </div>
                            </div>

                            <!-- Acción -->
                            <div class="col-md-6">
                                <div class="select-style-1">
                                    <label>Acción</label>
                                    <div class="select-position">
                                        <select id="bsqAccion">
                                            <option value="T">Todas</option>
                                            <option value="I">Insertar</option>
                                            <option value="A">Actualizar</option>
                                            <option value="E">Eliminar</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <!-- Fecha Desde -->
                            <div class="col-md-6">
                                <div class="input-style-1">
                                    <label>Fecha Desde</label>
                                    <input type="date" class="form-control" id="bsqFechaDesde" required />
                                </div>
                            </div>

                            <!-- Fecha Hasta -->
                            <div class="col-md-6">
                                <div class="input-style-1">
                                    <label>Fecha Hasta</label>
                                    <input type="date" class="form-control" id="bsqFechaHasta" required />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <button type="submit" class="main-btn primary-btn btn-hover">
                                    <i class="lni lni-search-alt"></i> Buscar
                                </button>
                            </div>
                        </div>
                    </form>
                </div>

                <!-- ========== TABLA DE RESULTADOS ========== -->
                <div class="card-style mb-30">
                    <h6 class="mb-25">Resultados de Auditoría</h6>
                    <div class="table-wrapper table-responsive">
                        <table id="tblAuditoria" class="table table-hover" style="width: 100%;">
                            <%-- Aquí se carga el contenido dinámico --%>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- ========== JAVASCRIPT ========== -->
    <script src="../JavaScript/Auditoria.js"></script>
</asp:Content>
