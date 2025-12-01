<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoTiposEspecialidad.aspx.cs" Inherits="PL_CRUD_HOSPITALES.Mantenimientos.frmMantenimientoTiposEspecialidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <!-- ========== title-wrapper start ========== -->
    <div class="title-wrapper pt-30">
        <div class="row align-items-center">
            <div class="col-md-6">
                <div class="title mb-30">
                    <h2>Mantenimiento de Tipo de Especialidad</h2>
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
                                <a href="frmConsultaTiposEspecialidad.aspx">Tipos de Especialidad</a>
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
                    <h6 class="mb-25">Información del Tipo de Especialidad</h6>
                    <form action="javascript: mantenimientoTipoEspecialidad()" method="post">
                        
                        <div class="row">
                            <!-- Campo: Tipo de Especialidad -->
                            <div class="col-md-6">
                                <div class="input-style-1">
                                    <label>Tipo de Especialidad <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" id="txtTipo_Especialidad"
                                        placeholder="Ej: Cardiología, Neurología" 
                                        maxlength="50" required />
                                </div>
                            </div>

                            <!-- Campo: Estado -->
                            <div class="col-md-6">
                                <div class="select-style-1">
                                    <label>Estado <span class="text-danger">*</span></label>
                                    <div class="select-position">
                                        <select id="cboEstado" required>
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
    <script src="../JavaScript/Especialidad.js"></script>
</asp:Content>
