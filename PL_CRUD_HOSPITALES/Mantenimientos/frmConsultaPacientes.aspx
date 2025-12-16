<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaPacientes.aspx.cs" Inherits="PL_CRUD_HOSPITALES.Mantenimientos.frmConsultaPacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <!-- ========== title-wrapper start ========== -->
    <div class="title-wrapper pt-30">
        <div class="row align-items-center">
            <div class="col-md-6">
                <div class="title mb-30">
                    <h2>Gestión de Pacientes</h2>
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
                                <a href="#0">Pacientes</a>
                            </li>
                            <li class="breadcrumb-item active" aria-current="page">Pacientes
                            </li>
                        </ol>
                    </nav>
                </div>
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
                    <h6 class="mb-25">Búsqueda de Pacientes</h6>
                    <form action="javascript: cargaListaPacientes()" method="post" id="frmBusqueda">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="input-style-1">
                                    <label for="bsqNombre">Nombre</label>
                                    <input type="text" class="form-control" id="bsqNombre" placeholder="Ej: María" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="input-style-1">
                                    <label for="bsqApellido">Primer Apellido</label>
                                    <input type="text" class="form-control" id="bsqApellido" placeholder="Ej: Rodríguez" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="select-style-1">
                                    <label for="bsqTipoIdentificacion" class="input__label">Tipo de Identificación</label>
                                    <div class="select-position">
                                        <select id="bsqTipoIdentificacion">
                                            <%-- Se llena dinámicamente --%>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="input-style-1">
                                    <label>&nbsp;</label>
                                    <button type="submit" class="main-btn primary-btn btn-hover">
                                        <i class="lni lni-search-alt"></i>Buscar
                                    </button>
                                    <button type="button" class="main-btn success-btn btn-hover ms-2" onclick="javascript: crearPaciente()">
                                        <i class="lni lni-plus"></i>Nuevo
                                    </button>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
                <!-- ========== Fin Formulario de Búsqueda ========== -->

                <!-- ========== Tabla de Resultados ========== -->
                <div class="card-style mb-30">
                    <h6 class="mb-25">Listado de Pacientes</h6>
                    <div class="table-wrapper table-responsive">
                        <table id="tblPacientes" class="table table-hover" style="width: 100%;">
                            <%-- Aquí se carga el contenido dinámico de la tabla --%>
                        </table>
                    </div>
                </div>
                <!-- ========== Fin Tabla de Resultados ========== -->
            </div>
        </div>
    </div>
    <!-- ========== form-elements-wrapper end ========== -->

    <!-- ========== JavaScript ========== -->
    <script src="../JavaScript/Pacientes.js"></script>
</asp:Content>