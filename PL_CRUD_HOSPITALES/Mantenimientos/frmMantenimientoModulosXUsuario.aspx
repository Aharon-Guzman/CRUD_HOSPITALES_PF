<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoModulosXUsuario.aspx.cs" Inherits="PL_CRUD_HOSPITALES.Mantenimientos.frmMantenimientoModulosXUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <!-- ========== title-wrapper start ========== -->
    <div class="title-wrapper pt-30">
        <div class="row align-items-center">
            <div class="col-md-6">
                <div class="title mb-30">
                    <h2>Asignación de Módulos a Usuario</h2>
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
                                <a href="frmConsultaUsuarios.aspx">Usuarios</a>
                            </li>
                            <li class="breadcrumb-item active" aria-current="page">
                                Módulos
                            </li>
                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </div>
    <!-- ========== title-wrapper end ========== -->

    <!-- ========== Módulos Disponibles ========== -->
    <div class="card-style mb-30">
        <h6 class="mb-25">Módulos Disponibles</h6>
        <div class="table-wrapper table-responsive">
            <table id="tblModulosDisponibles" class="table table-hover" style="width: 100%;">
                <%-- Aquí se carga el contenido dinámico de la tabla --%>
            </table>
        </div>
        <div class="row mt-3">
            <div class="col-12">
                <button type="button" class="main-btn danger-btn-outline btn-hover" onclick="javascript: regresar()">
                    <i class="lni lni-arrow-left"></i> Regresar
                </button>
            </div>
        </div>
    </div>
    <!-- ========== Fin Módulos Disponibles ========== -->

    <!-- ========== Módulos Asignados ========== -->
    <div class="card-style mb-30">
        <h6 class="mb-25">Módulos Asignados al Usuario</h6>
        <div class="table-wrapper table-responsive">
            <table id="tblModulosXUsuario" class="table table-hover" style="width: 100%;">
                <%-- Aquí se carga el contenido dinámico de la tabla --%>
            </table>
        </div>
    </div>
    <!-- ========== Fin Módulos Asignados ========== -->

    <!-- ========== JavaScript ========== -->
    <script src="../JavaScript/ModulosXUsuario.js"></script>
</asp:Content>
