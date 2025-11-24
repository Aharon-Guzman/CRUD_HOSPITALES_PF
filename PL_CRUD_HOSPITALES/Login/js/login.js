//// ==========================================
//// SCRIPT ESTÉTICO DEL LOGIN
//// Archivo: login.js
//// Descripción: Funcionalidades visuales y de UX del formulario
//// ==========================================

//document.addEventListener('DOMContentLoaded', function () {

//    // ==========================================
//    // REFERENCIAS A ELEMENTOS DEL DOM
//    // ==========================================
//    const usernameInput = document.getElementById('username');
//    const passwordInput = document.getElementById('password');
//    const togglePasswordBtn = document.getElementById('togglePassword');

//    // ==========================================
//    // FUNCIONALIDAD: MOSTRAR/OCULTAR CONTRASEÑA
//    // ==========================================
//    // Permite al usuario ver la contraseña que está escribiendo
//    // Interacción: Click en el ícono del ojo → Cambia tipo de input
//    // Por qué: Mejora la UX permitiendo verificar que escribió correctamente
//    togglePasswordBtn.addEventListener('click', function () {
//        // Obtiene el tipo actual del input (password o text)
//        const currentType = passwordInput.getAttribute('type');

//        // Alterna entre password (oculto) y text (visible)
//        const newType = currentType === 'password' ? 'text' : 'password';
//        passwordInput.setAttribute('type', newType);

//        // Cambia el ícono del botón para reflejar el estado
//        const icon = this.querySelector('i');
//        icon.classList.toggle('bi-eye');      // Ojo abierto (mostrar)
//        icon.classList.toggle('bi-eye-slash'); // Ojo cerrado (ocultar)
//    });

//    // ==========================================
//    // AUTOFOCUS EN CAMPO DE USUARIO
//    // ==========================================
//    // Coloca automáticamente el cursor en el campo de usuario al cargar
//    // Por qué: Permite al usuario empezar a escribir inmediatamente
//    usernameInput.focus();

//}); // Fin de DOMContentLoaded

//// ==========================================
//// NOTA: LÓGICA DE AUTENTICACIÓN
//// ==========================================
//// La lógica de validación y autenticación se manejará desde el backend (C#)
//// Este archivo solo contiene funcionalidades estéticas y de experiencia de usuario



// ==========================================
// SCRIPT ESTÉTICO DEL LOGIN
// Archivo: login.js
// Descripción: Funcionalidades visuales y de UX del formulario
// ==========================================

document.addEventListener('DOMContentLoaded', function () {

    // ==========================================
    // REFERENCIAS A ELEMENTOS DEL DOM
    // ==========================================
    const usernameInput = document.getElementById('username');
    const passwordInput = document.getElementById('password');
    const togglePasswordBtn = document.getElementById('togglePassword');

    // ==========================================
    // FUNCIONALIDAD: MOSTRAR/OCULTAR CONTRASEÑA
    // ==========================================
    // Permite al usuario ver la contraseña que está escribiendo
    // Interacción: Click en el ícono del ojo → Cambia tipo de input
    // Por qué: Mejora la UX permitiendo verificar que escribió correctamente
    togglePasswordBtn.addEventListener('click', function () {
        // Obtiene el tipo actual del input (password o text)
        const currentType = passwordInput.getAttribute('type');

        // Alterna entre password (oculto) y text (visible)
        const newType = currentType === 'password' ? 'text' : 'password';
        passwordInput.setAttribute('type', newType);

        // Cambia el ícono del botón para reflejar el estado
        const icon = this.querySelector('i');
        icon.classList.toggle('bi-eye');      // Ojo abierto (mostrar)
        icon.classList.toggle('bi-eye-slash'); // Ojo cerrado (ocultar)
    });


}); // Fin de DOMContentLoaded

// ==========================================
// NOTA: LÓGICA DE AUTENTICACIÓN
// ==========================================
// La lógica de validación y autenticación se manejará desde el backend (C#)
// Este archivo solo contiene funcionalidades estéticas y de experiencia de usuario