<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmPrincipal.aspx.cs" Inherits="PL_CRUD_HOSPITALES.Mantenimientos.frmPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <!-- ========== section start ========== -->
    <section class="section">
        <div class="container-fluid">
            <!-- ========== title-wrapper start ========== -->
            <div class="title-wrapper pt-30">
                <div class="row align-items-center">
                    <div class="col-md-6">
                        <div class="title">
                            <h2>Dashboard CRUD Hospitales</h2>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="breadcrumb-wrapper">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item">
                                        <a href="#0">Dashboard</a>
                                    </li>
                                    <li class="breadcrumb-item active" aria-current="page">Principal
                                    </li>
                                </ol>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
            <!-- ========== title-wrapper end ========== -->

            <!-- ========== TARJETAS DE ESTADÍSTICAS ========== -->
            <div class="row">
                <div class="col-xl-3 col-lg-4 col-sm-6">
                    <div class="icon-card mb-30">
                        <div class="icon purple">
                            <i class="lni lni-users"></i>
                        </div>
                        <div class="content">
                            <h6 class="mb-10">Total Pacientes</h6>
                            <h3 class="text-bold mb-10" id="totalPacientes">0</h3>
                            <p class="text-sm text-gray">Pacientes registrados</p>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-sm-6">
                    <div class="icon-card mb-30">
                        <div class="icon success">
                            <i class="lni lni-calendar"></i>
                        </div>
                        <div class="content">
                            <h6 class="mb-10">Citas Hoy</h6>
                            <h3 class="text-bold mb-10" id="citasHoy">0</h3>
                            <p class="text-sm text-gray">Citas programadas</p>
                        </div>
                    </div>
                </div>

                <div class="col-xl-3 col-lg-4 col-sm-6">
                    <div class="icon-card mb-30">
                        <div class="icon primary">
                            <i class="lni lni-heart-monitor"></i>
                        </div>
                        <div class="content">
                            <h6 class="mb-10">Total Médicos</h6>
                            <h3 class="text-bold mb-10" id="totalMedicos">0</h3>
                            <p class="text-sm text-gray">Médicos activos</p>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-sm-6">
                    <div class="icon-card mb-30">
                        <div class="icon orange">
                            <i class="lni lni-hospital"></i>
                        </div>
                        <div class="content">
                            <h6 class="mb-10">Hospitales</h6>
                            <h3 class="text-bold mb-10" id="totalHospitales">0</h3>
                            <p class="text-sm text-gray">Hospitales activos</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5">
                    <div class="card-style mb-30">
                        <div class="title d-flex justify-content-between align-items-center">
                            <div class="left">
                                <h6 class="text-medium mb-30">Clientes extranjeros</h6>
                            </div>
                        </div>
                        <!-- End Title -->
                        <div id="map" style="width: 100%; height: 400px; overflow: hidden;"></div>
                        <p>Actualizado: Hoy</p>
                    </div>
                </div>
                <div class="col-lg-5">
                    <div class="card-style calendar-card mb-30">
                        <div id="calendar-mini"></div>
                    </div>
                </div>

            </div>
            <!-- ========== FIN TARJETAS ========== -->
    </section>
    <!-- ========== section end ========== -->

    <script src="../JavaScript/Dashboard.js"></script>
</asp:Content>
