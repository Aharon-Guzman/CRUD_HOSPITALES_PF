<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInicioSesion.aspx.cs" Inherits="PL_CRUD_HOSPITALES.Login.frmInicioSesion" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hospital CRUD - Inicio de Sesión</title>
    
    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    
    <!-- Bootstrap Icons -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.0/font/bootstrap-icons.css">
    
    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700&display=swap" rel="stylesheet">
    
    <!-- Estilos personalizados -->
    <link rel="stylesheet" href="css/login.css">
</head>
<body>
    <div class="login-container">
        <div class="login-row">
            <!-- Panel Izquierdo - Info Hospital -->
            <div class="login-left">
                <div class="login-left-content">
                    <div class="hospital-logo">
                        <i class="bi bi-hospital"></i>
                    </div>
                    <h1 class="hospital-name">Sistema Hospital CRUD</h1>
                    <p class="hospital-subtitle">Gestión Integral de Servicios Hospitalarios</p>
                    
                    <div class="features">
                        <div class="feature-item">
                            <div class="feature-icon">
                                <i class="bi bi-shield-check"></i>
                            </div>
                            <div class="feature-text">
                                <strong>Seguro y Confiable</strong><br>
                                Acceso controlado con auditoría completa
                            </div>
                        </div>
                        
                        <div class="feature-item">
                            <div class="feature-icon">
                                <i class="bi bi-speedometer2"></i>
                            </div>
                            <div class="feature-text">
                                <strong>Rápido y Eficiente</strong><br>
                                Gestión optimizada de pacientes y citas
                            </div>
                        </div>
                        
                        <div class="feature-item">
                            <div class="feature-icon">
                                <i class="bi bi-people"></i>
                            </div>
                            <div class="feature-text">
                                <strong>Gestión Completa</strong><br>
                                Doctores, pacientes y consultorios
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Panel Derecho - Formulario Login -->
            <div class="login-right">
                <div class="login-header">
                    <h2>Bienvenido</h2>
                    <p>Ingrese sus credenciales para acceder al sistema</p>
                </div>

                <!-- Formulario -->
                <form  action="javascript: inicioSesion() "id="loginForm" method="post">
                    <div class="form-group">
                        <label for="username" class="form-label">Usuario</label>
                        <div class="input-group-custom">
                            <i class="bi bi-person input-icon"></i>
                            <input 
                                type="email" 
                                class="form-control" 
                                id="txtUsuario" 
                                name="username"
                                placeholder="Ingrese su correo"
                                required
                                autocomplete="username">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="password" class="form-label">Contraseña</label>
                        <div class="input-group-custom">
                            <i class="bi bi-lock input-icon"></i>
                            <input 
                                type="password" 
                                class="form-control" 
                                id="txtPassword" 
                                name="password"
                                placeholder="Ingrese su contraseña"
                                required
                                autocomplete="current-password">
                            <button type="button" class="toggle-password" id="togglePassword">
                                <i class="bi bi-eye"></i>
                            </button>
                        </div>
                    </div>

                    <button type="submit" class="btn btn-login">
                        <i class="bi bi-box-arrow-in-right"></i>
                        Iniciar Sesión
                    </button>
                </form>

                <!-- Elemento dinámico sutil -->
                <div class="dynamic-footer">
                    <div class="heartbeat-container">
                        <i class="bi bi-heart-pulse heartbeat-icon"></i>
                        <span class="heartbeat-text">Sistema en línea</span>
                    </div>
                    <div class="system-info">
                        <small class="text-muted">
                            <i class="bi bi-shield-check"></i> Conexión segura
                        </small>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap 5 JS Bundle -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
        <!-- //form section start -->
      <!-- js -->
  <script src="js/jquery.min.js"></script>
  <!-- //js -->
    <!-- JavaScript del Login -->
    <script src="js/login.js"></script>
    <script src="../JavaScript/jquery.cookie.js"></script>
    <script src="../JavaScript/InicioSesion.js"></script>
</body>
</html>