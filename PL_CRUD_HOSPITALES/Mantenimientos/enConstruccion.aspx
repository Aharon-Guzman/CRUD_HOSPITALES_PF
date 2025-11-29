<%@ Page Title="En Construcción" Language="C#" MasterPageFile="~/Mantenimientos/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="enConstruccion.aspx.cs" Inherits="PL_CRUD_HOSPITALES.Mantenimientos.enConstruccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Contenedor principal centrado */
        .construccion-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            min-height: 70vh;
            text-align: center;
            padding: 40px 20px;
        }

        /* Ícono de construcción */
        .icono-construccion {
            width: 120px;
            height: 120px;
            margin-bottom: 30px;
            color: #f59e0b;
        }

        /* Título principal */
        .construccion-titulo {
            font-size: 2.5rem;
            font-weight: 700;
            color: #1f2937;
            margin-bottom: 15px;
        }

        /* Subtítulo */
        .construccion-subtitulo {
            font-size: 1.25rem;
            color: #6b7280;
            margin-bottom: 30px;
            max-width: 600px;
        }

        /* Botón de regreso */
        .btn-volver {
            display: inline-block;
            padding: 12px 30px;
            background-color: #3b82f6;
            color: white;
            text-decoration: none;
            border-radius: 8px;
            font-weight: 600;
            transition: background-color 0.3s;
        }

        .btn-volver:hover {
            background-color: #2563eb;
        }

        /* Animación opcional para el ícono */
        @keyframes bounce {
            0%, 100% {
                transform: translateY(0);
            }
            50% {
                transform: translateY(-10px);
            }
        }

        .icono-construccion svg {
            animation: bounce 2s infinite;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="construccion-container">
        
        <!-- Ícono SVG de construcción -->
        <div class="icono-construccion">
            <svg viewBox="0 0 256 256" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                <path d="M128 24C74.98 24 32 66.98 32 120c0 25.36 9.84 48.88 27.66 66.12L48 208h160l-11.66-21.88C214.16 168.88 224 145.36 224 120c0-53.02-42.98-96-96-96zm0 16c44.11 0 80 35.89 80 80 0 20.64-7.83 39.43-20.67 53.64l-8.66 16.26H85.33l-8.66-16.26C63.83 159.43 56 140.64 56 120c0-44.11 35.89-80 80-80zm-16 48v48h-16v16h64v-16h-16V88h-32z"/>
                <rect x="64" y="216" width="128" height="16" rx="4"/>
            </svg>
        </div>

        <!-- Título -->
        <h1 class="construccion-titulo">Sitio en Construcción</h1>

        <!-- Subtítulo -->
        <p class="construccion-subtitulo">
            Esta página está actualmente en desarrollo. Estamos trabajando para ofrecerte la mejor experiencia posible.
        </p>

        <!-- Botón de regreso -->
        <a href="javascript:history.back()" class="btn-volver">
            ← Volver Atrás
        </a>

    </div>
</asp:Content>