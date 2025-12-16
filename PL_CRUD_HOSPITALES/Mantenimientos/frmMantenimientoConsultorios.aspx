<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoConsultorios.aspx.cs" Inherits="PL_CRUD_HOSPITALES.Mantenimientos.frmMantenimientoConsultorios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <!-- ========== title-wrapper start ========== -->
    <div class="title-wrapper pt-30">
        <div class="row align-items-center">
            <div class="col-md-6">
                <div class="title mb-30">
                    <h2>Mantenimiento de Consultorio</h2>
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
                                <a href="frmConsultaConsultorios.aspx">Consultorios</a>
                            </li>
                            <li class="breadcrumb-item active" aria-current="page">
                                Mantenimiento
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
                <div class="card-style mb-30">
                    <h6 class="mb-25">Información del Consultorio</h6>
                    <form action="javascript: mantenimientoConsultorio()" method="post">
                        
                        <div class="row">
                            <!-- Campo: Hospital -->
                            <div class="col-md-6">
                                <div class="select-style-1">
                                    <label>Hospital <span class="text-danger">*</span></label>
                                    <div class="select-position">
                                        <select id="cboHospital" required>
                                            <%-- Se llena dinámicamente --%>
                                        </select>
                                    </div>
                                </div>
                            </div>

                            <!-- Campo: Tipo de Consultorio -->
                            <div class="col-md-6">
                                <div class="select-style-1">
                                    <label>Tipo de Consultorio <span class="text-danger">*</span></label>
                                    <div class="select-position">
                                        <select id="cboTipoConsultorio" required>
                                            <%-- Se llena dinámicamente --%>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <!-- Campo: Descripción -->
                            <div class="col-md-8">
                                <div class="input-style-1">
                                    <label>Descripción del Consultorio <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" id="txtDescripcion"
                                        placeholder="Ej: Consulta General" 
                                        maxlength="50" required />
                                </div>
                            </div>

                            <!-- Campo: Estado -->
                            <div class="col-md-4">
                                <div class="select-style-1">
                                    <label>Estado <span class="text-danger">*</span></label>
                                    <div class="select-position">
                                        <select id="cboSts" required>
                                            <option value="A">Activo</option>
                                            <option value="I">Inactivo</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Botones -->
                        <div class="row">
                            <div class="col-12">
                                <button type="submit" class="main-btn primary-btn btn-hover mt-4">
                                    <i class="lni lni-save"></i> Guardar
                                </button>
                                <button type="button" class="main-btn danger-btn-outline btn-hover mt-4 ms-2" onclick="javascript: regresar()">
                                    <i class="lni lni-arrow-left"></i> Regresar
                                </button>
                            </div>
                        </div>

                    </form>
                </div>
            </div>
        </div>
    </div>
    <!-- ========== form-elements-wrapper end ========== -->

    <!-- ========== JavaScript ========== -->
    <script src="../JavaScript/Consultorios.js"></script>
</asp:Content>
