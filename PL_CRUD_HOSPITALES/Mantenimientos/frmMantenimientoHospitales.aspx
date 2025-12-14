<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoHospitales.aspx.cs" Inherits="PL_CRUD_HOSPITALES.Mantenimientos.frmMantenimientoHospitales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <!-- ========== title-wrapper start ========== -->
    <div class="title-wrapper pt-30">
        <div class="row align-items-center">
            <div class="col-md-6">
                <div class="title mb-30">
                    <h2>Mantenimiento de Hospital</h2>
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
                                <a href="frmConsultaHospitales.aspx">Hospitales</a>
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
                    <h6 class="mb-25">Información del Hospital</h6>
                    <form action="javascript: mantenimientoHospital()" method="post">
                        
                        <div class="row">
                            <!-- Campo: Código Hospital -->
                            <div class="col-md-4">
                                <div class="input-style-1">
                                    <label>Código Hospital <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" id="txtCod_Hospital"
                                        placeholder="Ej: HOSP001" 
                                        maxlength="10" required />
                                </div>
                            </div>

                            <!-- Campo: Descripción -->
                            <div class="col-md-8">
                                <div class="input-style-1">
                                    <label>Descripción <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" id="txtDescripcion"
                                        placeholder="Ej: Hospital Nacional de Niños" 
                                        maxlength="50" required />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <!-- Campo: Dirección -->
                            <div class="col-md-12">
                                <div class="input-style-1">
                                    <label>Dirección <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" id="txtDireccion"
                                        placeholder="Ej: San José, Paseo Colón" 
                                        maxlength="500" required />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <!-- Campo: Teléfono -->
                            <div class="col-md-4">
                                <div class="input-style-1">
                                    <label>Teléfono <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" id="txtTelefono"
                                        placeholder="Ej: 22234567" 
                                        maxlength="8" required />
                                </div>
                            </div>

                            <!-- Campo: Correo -->
                            <div class="col-md-4">
                                <div class="input-style-1">
                                    <label>Correo Electrónico <span class="text-danger">*</span></label>
                                    <input type="email" class="form-control" id="txtCorreo"
                                        placeholder="Ej: contacto@hospital.cr" 
                                        maxlength="50" required />
                                </div>
                            </div>

                            <!-- Campo: Web -->
                            <div class="col-md-4">
                                <div class="input-style-1">
                                    <label>Sitio Web <span class="text-danger">*</span></label>
                                    <input type="text" class="form-control" id="txtWeb"
                                        placeholder="Ej: www.hospital.cr" 
                                        maxlength="50" required />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <!-- Campo: Área -->
                            <div class="col-md-4">
                                <div class="input-style-1">
                                    <label>Área (m²) <span class="text-danger">*</span></label>
                                    <input type="number" class="form-control" id="txtArea"
                                        placeholder="Ej: 15000" 
                                        min="1" required />
                                </div>
                            </div>

                            <!-- Campo: Fecha Construcción -->
                            <div class="col-md-4">
                                <div class="input-style-1">
                                    <label>Fecha de Construcción <span class="text-danger">*</span></label>
                                    <input type="date" class="form-control" id="txtFecha_Construccion"
                                        required />
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
    <script src="../JavaScript/Hospital.js"></script>
</asp:Content>
