<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Acceso Denegado</title>
    <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
    <style>
        body {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            font-family: 'Plus Jakarta Sans', sans-serif;
        }
        .access-denied-container {
            background: white;
            padding: 60px 40px;
            border-radius: 20px;
            box-shadow: 0 20px 60px rgba(0,0,0,0.3);
            text-align: center;
            max-width: 500px;
            width: 90%;
        }
        .icon-container {
            margin-bottom: 30px;
        }
        .icon-container svg {
            width: 100px;
            height: 100px;
            color: #dc3545;
        }
        h1 {
            color: #2c3e50;
            font-size: 32px;
            font-weight: 700;
            margin-bottom: 20px;
        }
        p {
            color: #6c757d;
            font-size: 16px;
            line-height: 1.6;
            margin-bottom: 30px;
        }
        .btn-back {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 12px 40px;
            border-radius: 50px;
            text-decoration: none;
            display: inline-block;
            font-weight: 600;
            transition: transform 0.2s, box-shadow 0.2s;
        }
        .btn-back:hover {
            transform: translateY(-2px);
            box-shadow: 0 10px 20px rgba(0,0,0,0.2);
            color: white;
        }
    </style>
</head>
<body>
    <div class="access-denied-container">
        <div class="icon-container">
            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" />
            </svg>
        </div>
        
        <h1>🚫 Acceso Denegado</h1>
        
        <p>
            No tienes permisos para acceder a este módulo del sistema.
        </p>
        
        <p style="margin-bottom: 40px;">
            Si crees que esto es un error, por favor contacta al administrador del sistema.
        </p>
        
        <a href="frmPrincipal.aspx" class="btn-back">
            ← Volver al Panel de Control
        </a>
    </div>
</body>
</html>
