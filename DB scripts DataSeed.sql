/*************DataSeed****************/

-- ========================================
-- POBLAR MODULOS INICIALES E ÍCONOS 
-- Asignar cada módulo a su categoría con íconos SVG
-- ========================================

USE CRUD_HOSPITALES
GO

INSERT INTO Modulos
(Modulo, ClaseCSS, Enlace, Categoria, Orden_Categoria,
 Icono_Categoria, ViewBox_Categoria, SvgPath, ViewBox)
VALUES
('Gestión Hospitales','', 'frmConsultaHospitales.aspx','Infraestructura',1,
 'M224 248.8H134C120.4 248.8 109.2 237.6 109.2 223.6V208H32C18.4 208 6.8 196.8 6.8 182.8V32C6.8 18.4 18 6.8 32 6.8H224C237.6 6.8 249.2 18 249.2 32V224C249.2 237.6 237.6 248.8 224 248.8zM108.8 24.8H32C28 24.8 24.8 28 24.8 32V183.2C24.8 187.2 28 190.4 32 190.4H108.8V24.8zM231.2 32C231.2 28 228 24.8 224 24.8H126.8V224C126.8 228 130 231.2 133.6 231.2H224C228 231.2 231.2 228 231.2 224V32zM56 143.6H78.4C83.2 143.6 87.6 147.6 87.6 152.8S83.6 162 78.4 162H56C51.2 162 46.8 158 46.8 152.8S51.2 143.6 56 143.6zM56 98.8H78.4C83.2 98.8 87.6 102.8 87.6 108S83.6 117.2 78.4 117.2H56C51.2 117.2 46.8 113.2 46.8 108S51.2 98.8 56 98.8zM55.6 53.6H78C82.8 53.6 87.2 57.6 87.2 62.8S83.2 72 78 72H55.6C50.8 72 46.4 68 46.4 62.8S50.8 53.6 55.6 53.6zM190.4 197.2H168C163.2 197.2 158.8 193.2 158.8 188S162.8 178.8 168 178.8H190.4C195.2 178.8 199.6 182.8 199.6 188S195.2 197.2 190.4 197.2zM190.4 139.6H168C163.2 139.6 158.8 135.6 158.8 130.4C158.8 125.6 162.8 121.2 168 121.2H190.4C195.2 121.2 199.6 125.2 199.6 130.4C199.2 135.6 195.2 139.6 190.4 139.6zM190 82H167.6C162.8 82 158.4 78 158.4 72.8S162.4 63.6 167.6 63.6H190C194.8 63.6 199.2 67.6 199.2 72.8S194.8 82 190 82z',
 '0 0 256 256', NULL, NULL),

('Gestión Consultorios','', 'frmConsultaConsultorios.aspx','Infraestructura',1,
 'M224 248.8H134C120.4 248.8 109.2 237.6 109.2 223.6V208H32C18.4 208 6.8 196.8 6.8 182.8V32C6.8 18.4 18 6.8 32 6.8H224C237.6 6.8 249.2 18 249.2 32V224C249.2 237.6 237.6 248.8 224 248.8zM108.8 24.8H32C28 24.8 24.8 28 24.8 32V183.2C24.8 187.2 28 190.4 32 190.4H108.8V24.8zM231.2 32C231.2 28 228 24.8 224 24.8H126.8V224C126.8 228 130 231.2 133.6 231.2H224C228 231.2 231.2 228 231.2 224V32zM56 143.6H78.4C83.2 143.6 87.6 147.6 87.6 152.8S83.6 162 78.4 162H56C51.2 162 46.8 158 46.8 152.8S51.2 143.6 56 143.6zM56 98.8H78.4C83.2 98.8 87.6 102.8 87.6 108S83.6 117.2 78.4 117.2H56C51.2 117.2 46.8 113.2 46.8 108S51.2 98.8 56 98.8zM55.6 53.6H78C82.8 53.6 87.2 57.6 87.2 62.8S83.2 72 78 72H55.6C50.8 72 46.4 68 46.4 62.8S50.8 53.6 55.6 53.6zM190.4 197.2H168C163.2 197.2 158.8 193.2 158.8 188S162.8 178.8 168 178.8H190.4C195.2 178.8 199.6 182.8 199.6 188S195.2 197.2 190.4 197.2zM190.4 139.6H168C163.2 139.6 158.8 135.6 158.8 130.4C158.8 125.6 162.8 121.2 168 121.2H190.4C195.2 121.2 199.6 125.2 199.6 130.4C199.2 135.6 195.2 139.6 190.4 139.6zM190 82H167.6C162.8 82 158.4 78 158.4 72.8S162.4 63.6 167.6 63.6H190C194.8 63.6 199.2 67.6 199.2 72.8S194.8 82 190 82z',
 '0 0 256 256', NULL, NULL),

('Gestión Médicos','', 'frmConsultaMedicos.aspx','Medicos',2,
 'M127.6 182.4C144.4 182.4 157.6 196 157.6 212.4S144 242.4 127.6 242.4S97.6 228.8 97.6 212.4S110.8 182.4 127.6 182.4zM127.6 224.8C134.4 224.8 139.6 219.2 139.6 212.8S134 200.8 127.6 200.8S115.6 206.4 115.6 212.8S120.8 224.8 127.6 224.8zM94.4 142C102.8 151.2 115.2 156.8 128 156.8S153.2 151.6 161.6 142C163.2 140 165.6 139.2 168.4 139.2C170.4 139.2 172.8 140 174.4 141.6C178 144.8 178.4 150.8 174.8 154.4C162.8 167.2 145.6 174.8 128 174.8S93.2 167.2 81.2 154.4C78 150.8 78 145.2 81.6 141.6C85.2 138 90.8 138.4 94.4 142zM53.6 55.6C70.4 55.6 83.6 69.2 83.6 85.6C83.6 102.4 70 115.6 53.6 115.6S23.6 102 23.6 85.6C23.2 68.8 36.8 55.6 53.6 55.6zM53.6 98C60.4 98 65.6 92.4 65.6 86C65.6 79.2 60 74 53.6 74S41.6 79.6 41.6 86C41.2 92.4 46.8 98 53.6 98zM52.4 48.8C34.8 48.8 17.6 41.2 5.6 28.4C2.4 24.8 2.4 19.2 6 15.6C9.6 12 15.2 12.4 18.8 16C27.2 25.2 39.6 30.8 52.4 30.8S77.6 25.6 86 16C87.6 14 90 13.2 92.8 13.2C94.8 13.2 97.2 14 98.8 15.6C102.4 18.8 102.8 24.8 99.2 28.4C87.2 41.2 70 48.8 52.4 48.8zM201.6 55.6C218.4 55.6 231.6 69.2 231.6 85.6C231.6 102.4 218 115.6 201.6 115.6C184.8 115.6 171.6 102 171.6 85.6C171.6 68.8 185.2 55.6 201.6 55.6zM201.6 98C208.4 98 213.6 92.4 213.6 86C213.6 79.2 208 74 201.6 74C194.8 74 189.6 79.6 189.6 86S195.2 98 201.6 98zM250.8 28C238.8 40.8 221.6 48.4 204 48.4S169.2 40.8 157.2 28C154 24.4 154 18.8 157.6 15.2C161.2 12 166.8 12 170.4 15.6C178.8 24.8 191.2 30.4 204 30.4S229.2 25.2 237.6 15.6C239.2 13.6 241.6 12.8 244.4 12.8C246.4 12.8 248.8 13.6 250.4 15.2C253.6 18.8 254 24.4 250.8 28zM156.8 92.4C158.8 96.8 156.8 102.4 152.4 104.4L136.8 111.6V128C136.8 132.8 132.8 137.2 128 137.2S118.8 133.2 118.8 128V112L102.8 104.4C98.4 102.4 96.4 96.8 98.4 92.4S106 86 110.4 88L127.2 96L145.2 88C146.4 87.6 147.6 87.2 148.8 87.2C152 87.2 155.2 89.2 156.8 92.4z',
 '0 0 256 256', NULL, NULL),

('Gestión Pacientes','', 'frmConsultaPacientes.aspx','Pacientes y Citas',3,
 'M128 20C122.8 20 117.6 22 113.6 25.6C104.4 33.6 96 40.8 88.4 47.2C65.6 66.8 45.6 83.2 31.6 100C15.2 120 7.2 138.8 7.2 160C7.2 180.4 14.4 199.6 27.2 213.6C40.4 228 58.8 236 78.4 236C93.2 236 107.2 231.2 119.2 222C122.4 219.6 125.2 217.2 128 214C130.8 216.8 133.6 219.6 136.8 222C148.8 231.2 162.4 236 177.6 236C197.6 236 215.6 228 228.8 213.6C242 199.6 248.8 180.4 248.8 160C248.8 138.8 241.2 120 224.4 100C210.4 83.2 190.4 66.4 167.6 47.2C160 40.8 151.2 33.2 142 25.6C138.4 22 133.2 20 128 20zM78.4 218C63.6 218 50 212 40 201.6C30.4 190.8 25.2 176 25.2 160C25.2 143.6 31.6 128 45.2 111.6C58.4 96 77.6 79.6 99.6 60.8C107.2 54.4 116 46.8 125.2 38.8C126.8 37.6 129.2 37.6 130.8 38.8C140 46.8 148.8 54 156.4 60.8C178.8 80 198 96 210.8 111.6C224.4 128 230.8 143.6 230.8 160C230.8 176 225.2 190.8 215.6 201.2C205.6 212 192 218 177.6 218C166.8 218 156.8 214.4 148 208C144.4 205.2 141.2 202 138 198.4C135.6 195.6 132 193.6 128 193.6S120.8 195.2 118 198.4C114.8 202 111.6 205.2 108 208C99.6 214.4 89.6 218 78.4 218z',
 '0 0 256 256', NULL, NULL),

('Gestión Citas','', 'frmConsultaCitas.aspx','Pacientes y Citas',3,
 'M128 20C122.8 20 117.6 22 113.6 25.6C104.4 33.6 96 40.8 88.4 47.2C65.6 66.8 45.6 83.2 31.6 100C15.2 120 7.2 138.8 7.2 160C7.2 180.4 14.4 199.6 27.2 213.6C40.4 228 58.8 236 78.4 236C93.2 236 107.2 231.2 119.2 222C122.4 219.6 125.2 217.2 128 214C130.8 216.8 133.6 219.6 136.8 222C148.8 231.2 162.4 236 177.6 236C197.6 236 215.6 228 228.8 213.6C242 199.6 248.8 180.4 248.8 160C248.8 138.8 241.2 120 224.4 100C210.4 83.2 190.4 66.4 167.6 47.2C160 40.8 151.2 33.2 142 25.6C138.4 22 133.2 20 128 20zM78.4 218C63.6 218 50 212 40 201.6C30.4 190.8 25.2 176 25.2 160C25.2 143.6 31.6 128 45.2 111.6C58.4 96 77.6 79.6 99.6 60.8C107.2 54.4 116 46.8 125.2 38.8C126.8 37.6 129.2 37.6 130.8 38.8C140 46.8 148.8 54 156.4 60.8C178.8 80 198 96 210.8 111.6C224.4 128 230.8 143.6 230.8 160C230.8 176 225.2 190.8 215.6 201.2C205.6 212 192 218 177.6 218C166.8 218 156.8 214.4 148 208C144.4 205.2 141.2 202 138 198.4C135.6 195.6 132 193.6 128 193.6S120.8 195.2 118 198.4C114.8 202 111.6 205.2 108 208C99.6 214.4 89.6 218 78.4 218z',
 '0 0 256 256', NULL, NULL),

('Catálogo Tipos Identificaciones','', 'frmConsultaTiposIdentificacion.aspx','Catálogos',4,
 'M200 248.8H56C38.8 248.8 24.8 234.8 24.8 217.6V38.4C24.8 21.2 38.8 7.2 56 7.2H148C149.6 7.2 151.2 8 152.4 8.8L227.2 83.6C228 84.8 228.8 86.4 228.8 88V217.6C231.2 234.8 217.2 248.8 200 248.8zM56 25.2C48 25.2 42.8 30.4 42.8 38.4V217.6C42.8 225.6 48 230.8 56 230.8H200C208 230.8 213.2 225.6 213.2 217.6V91.6L142.4 25.2H56zM164.8 179.6H91.2C86.4 179.6 82.4 175.6 82.4 170.8S86.4 162 91.2 162H164.8C169.6 162 173.6 166 173.6 170.8S169.6 179.6 164.8 179.6zM164.8 134H91.2C86.4 134 82.4 130 82.4 125.2S86.4 116.4 91.2 116.4H164.8C169.6 116.4 173.6 120.4 173.6 125.2S169.6 134 164.8 134z',
 '0 0 256 256', NULL, NULL),

('Catálogo Tipos Consultorios','', 'frmConsultaTiposConsultorio.aspx','Catálogos',4,
 'M200 248.8H56C38.8 248.8 24.8 234.8 24.8 217.6V38.4C24.8 21.2 38.8 7.2 56 7.2H148C149.6 7.2 151.2 8 152.4 8.8L227.2 83.6C228 84.8 228.8 86.4 228.8 88V217.6C231.2 234.8 217.2 248.8 200 248.8zM56 25.2C48 25.2 42.8 30.4 42.8 38.4V217.6C42.8 225.6 48 230.8 56 230.8H200C208 230.8 213.2 225.6 213.2 217.6V91.6L142.4 25.2H56zM164.8 179.6H91.2C86.4 179.6 82.4 175.6 82.4 170.8S86.4 162 91.2 162H164.8C169.6 162 173.6 166 173.6 170.8S169.6 179.6 164.8 179.6zM164.8 134H91.2C86.4 134 82.4 130 82.4 125.2S86.4 116.4 91.2 116.4H164.8C169.6 116.4 173.6 120.4 173.6 125.2S169.6 134 164.8 134z',
 '0 0 256 256', NULL, NULL),

('Catálogo Tipos Especialidades','', 'frmConsultaTiposEspecialidad.aspx','Catálogos',4,
 'M200 248.8H56C38.8 248.8 24.8 234.8 24.8 217.6V38.4C24.8 21.2 38.8 7.2 56 7.2H148C149.6 7.2 151.2 8 152.4 8.8L227.2 83.6C228 84.8 228.8 86.4 228.8 88V217.6C231.2 234.8 217.2 248.8 200 248.8zM56 25.2C48 25.2 42.8 30.4 42.8 38.4V217.6C42.8 225.6 48 230.8 56 230.8H200C208 230.8 213.2 225.6 213.2 217.6V91.6L142.4 25.2H56zM164.8 179.6H91.2C86.4 179.6 82.4 175.6 82.4 170.8S86.4 162 91.2 162H164.8C169.6 162 173.6 166 173.6 170.8S169.6 179.6 164.8 179.6zM164.8 134H91.2C86.4 134 82.4 130 82.4 125.2S86.4 116.4 91.2 116.4H164.8C169.6 116.4 173.6 120.4 173.6 125.2S169.6 134 164.8 134z',
 '0 0 256 256', NULL, NULL),

('Catálogo Tipos Citas','', 'frmConsultaTiposCita.aspx','Catálogos',4,
 'M200 248.8H56C38.8 248.8 24.8 234.8 24.8 217.6V38.4C24.8 21.2 38.8 7.2 56 7.2H148C149.6 7.2 151.2 8 152.4 8.8L227.2 83.6C228 84.8 228.8 86.4 228.8 88V217.6C231.2 234.8 217.2 248.8 200 248.8zM56 25.2C48 25.2 42.8 30.4 42.8 38.4V217.6C42.8 225.6 48 230.8 56 230.8H200C208 230.8 213.2 225.6 213.2 217.6V91.6L142.4 25.2H56zM164.8 179.6H91.2C86.4 179.6 82.4 175.6 82.4 170.8S86.4 162 91.2 162H164.8C169.6 162 173.6 166 173.6 170.8S169.6 179.6 164.8 179.6zM164.8 134H91.2C86.4 134 82.4 130 82.4 125.2S86.4 116.4 91.2 116.4H164.8C169.6 116.4 173.6 120.4 173.6 125.2S169.6 134 164.8 134z',
 '0 0 256 256', NULL, NULL),

('Administración Usuarios','', 'frmConsultaUsuarios.aspx','Administración',5,
 'M180.8 248.8H135.6C125.2 248.8 116.4 240 116.4 229.6V202C116.4 197.2 120.4 193.2 125.2 193.2S134.4 197.2 134.4 202V230C134.4 230.8 134.8 231.2 135.6 231.2H180.8C190.4 231.2 198 223.6 198 214V42.4C198 32.8 190.4 25.2 180.8 25.2H135.6C134.8 25.2 134.4 25.6 134.4 26.4V54C134.4 58.8 130.4 62.8 125.2 62.8S116.4 58.8 116.4 54V26.4C116.4 16 125.2 7.2 135.6 7.2H180.8C200.4 7.2 216 23.2 216 42.4V213.6C216 233.2 200 248.8 180.8 248.8zM70.4 119.2H142C146.8 119.2 150.8 123.2 150.8 128C150.8 132.8 146.8 136.8 142 136.8H70.8L95.6 162C99.2 165.6 99.2 171.2 95.6 174.8C92 178.4 86.4 178.4 82.8 174.8L42.8 134C39.2 130.4 39.2 124.8 42.8 121.2L82.8 80.4C84.4 78.8 86.8 77.6 89.2 77.6C91.6 77.6 93.6 78.4 95.6 80C99.2 83.6 99.2 89.2 95.6 92.8L70.4 119.2z',
 '0 0 256 256', NULL, NULL),

('Módulo Auditoría','', 'frmConsultaAuditoria.aspx','Administración',5,
 'M180.8 248.8H135.6C125.2 248.8 116.4 240 116.4 229.6V202C116.4 197.2 120.4 193.2 125.2 193.2S134.4 197.2 134.4 202V230C134.4 230.8 134.8 231.2 135.6 231.2H180.8C190.4 231.2 198 223.6 198 214V42.4C198 32.8 190.4 25.2 180.8 25.2H135.6C134.8 25.2 134.4 25.6 134.4 26.4V54C134.4 58.8 130.4 62.8 125.2 62.8S116.4 58.8 116.4 54V26.4C116.4 16 125.2 7.2 135.6 7.2H180.8C200.4 7.2 216 23.2 216 42.4V213.6C216 233.2 200 248.8 180.8 248.8zM70.4 119.2H142C146.8 119.2 150.8 123.2 150.8 128C150.8 132.8 146.8 136.8 142 136.8H70.8L95.6 162C99.2 165.6 99.2 171.2 95.6 174.8C92 178.4 86.4 178.4 82.8 174.8L42.8 134C39.2 130.4 39.2 124.8 42.8 121.2L82.8 80.4C84.4 78.8 86.8 77.6 89.2 77.6C91.6 77.6 93.6 78.4 95.6 80C99.2 83.6 99.2 89.2 95.6 92.8L70.4 119.2z',
 '0 0 256 256', NULL, NULL);

 PRINT 'Modulos Insertados correctamenta'
USE CRUD_HOSPITALES;
GO

/* =========================
   1. Tipos_Identificacion
   ========================= */
INSERT INTO Tipos_Identificacion (Tipo_Identificacion, Estado) VALUES
(N'Cédula Nacional', 'A'),
(N'Cédula de Residencia', 'A'),
(N'DIMEX', 'A'),
(N'Pasaporte', 'A'),
(N'Cédula Jurídica', 'A'),
(N'Carné de Seguro', 'A'),
(N'Licencia de Conducir', 'A'),
(N'Cédula Nacional Menor', 'A'),
(N'Documento Temporal', 'A'),
(N'Pasaporte Diplomático', 'A'),
(N'Pasaporte Centroamericano', 'A'),
(N'Documento Estudiantil', 'A'),
(N'Carné Universitario', 'A'),
(N'Carné Funcionario Público', 'A'),
(N'Permiso Trabajo Temporal', 'A'),
(N'Documento Migratorio Especial', 'A'),
(N'Identificación Consular', 'A'),
(N'Carné Caja Costarricense', 'A'),
(N'Cédula Nacional - Antiguo Formato', 'I'),
(N'Documento No Especificado', 'I');

 PRINT 'Tipos de indentificacion Insertados correctamenta'

GO

/* =========================
   2. Tipos_Consultorios
   ========================= */
INSERT INTO Tipos_Consultorios (Tipo_Consultorio, Estado) VALUES
(N'Consulta Externa Medicina General', 'A'),
(N'Consulta Externa Pediatría', 'A'),
(N'Consulta Externa Ginecología', 'A'),
(N'Consulta Externa Cardiología', 'A'),
(N'Consulta Externa Dermatología', 'A'),
(N'Consulta Externa Ortopedia', 'A'),
(N'Consulta Externa Psicología', 'A'),
(N'Consulta Externa Psiquiatría', 'A'),
(N'Sala de Emergencias', 'A'),
(N'Sala de Observación', 'A'),
(N'Unidad de Cuidados Intensivos', 'A'),
(N'Unidad de Cuidados Intermedios', 'A'),
(N'Consulta Odontológica', 'A'),
(N'Consulta Nutrición', 'A'),
(N'Consulta Trabajo Social', 'A'),
(N'Consulta Medicina del Dolor', 'A'),
(N'Consulta Rehabilitación', 'A'),
(N'Consulta Medicina Interna', 'A'),
(N'Consulta Neumología', 'A'),
(N'Consulta Neurología', 'A');

 PRINT 'Tipos de consultorios Insertados correctamenta'

GO

/* =========================
   3. Tipos_Especialidades
   ========================= */
INSERT INTO Tipos_Especialidades (Tipo_Especialidad, Estado) VALUES
(N'Medicina General', 'A'),
(N'Pediatría', 'A'),
(N'Ginecología y Obstetricia', 'A'),
(N'Cardiología', 'A'),
(N'Dermatología', 'A'),
(N'Ortopedia y Traumatología', 'A'),
(N'Psicología Clínica', 'A'),
(N'Psiquiatría', 'A'),
(N'Cirugía General', 'A'),
(N'Anestesiología', 'A'),
(N'Oftalmología', 'A'),
(N'Otorrinolaringología', 'A'),
(N'Neumología', 'A'),
(N'Neurología', 'A'),
(N'Nefrología', 'A'),
(N'Endocrinología', 'A'),
(N'Gastroenterología', 'A'),
(N'Hematología', 'A'),
(N'Medicina Interna', 'A'),
(N'Rehabilitación y Fisiatría', 'A');

 PRINT 'Tipos de Especialidades Insertados correctamenta'

GO

/* =========================
   4. Tipos_Citas
   ========================= */
INSERT INTO Tipos_Citas (Tipo_Cita, Estado) VALUES
(N'Primera vez Medicina General', 'A'),
(N'Control Medicina General', 'A'),
(N'Primera vez Especialidad', 'A'),
(N'Control Especialidad', 'A'),
(N'Urgencia Programada', 'A'),
(N'Control Crónico', 'A'),
(N'Valoración Preoperatoria', 'A'),
(N'Control Postoperatorio', 'A'),
(N'Consulta de Seguimiento', 'A'),
(N'Cita Telemedicina', 'A'),
(N'Vacunación', 'A'),
(N'Curaciones', 'A'),
(N'Valoración Psicología', 'A'),
(N'Valoración Nutrición', 'A'),
(N'Control Nutrición', 'A'),
(N'Control Embarazo', 'A'),
(N'Control Niño Sano', 'A'),
(N'Cita Rehabilitación', 'A'),
(N'Cita de Trabajo Social', 'A'),
(N'Procedimiento Ambulatorio', 'A');

 PRINT 'Tipos de Citas Insertados correctamenta'

GO


/* =========================
   6. Usuarios
   ========================= */
INSERT INTO Usuarios (Correo, Nombre, Prim_Apellido, Seg_Apellido, Estado, [Password]) VALUES
(N'kevin.montes@uamcr.net', N'Kevin', N'Montes', N'Varela', 'A', N'123'),
(N'aharon.guzman@uamcr.net', N'Aharon', N'Guzman', N'Guzman', 'A', N'123'),
(N'carlos.jimenez@hospitalcr.com', N'Carlos', N'Jiménez', N'Rodríguez', 'A', N'123'),
(N'maria.soto@hospitalcr.com', N'María', N'Soto', N'Castro', 'A', N'123'),
(N'jose.lopez@hospitalcr.com', N'José', N'López', N'Ramírez', 'A', N'123'),
(N'ana.mora@hospitalcr.com', N'Ana', N'Mora', N'Solano', 'A', N'123'),
(N'luis.rojas@hospitalcr.com', N'Luis', N'Rojas', N'Vargas', 'A', N'123'),
(N'karla.gonzalez@hospitalcr.com', N'Karla', N'González', N'Hernández', 'A', N'123'),
(N'andrea.alpizar@hospitalcr.com', N'Andrea', N'Alpízar', N'Martínez', 'A', N'123'),
(N'ricardo.cascante@hospitalcr.com', N'Ricardo', N'Cascante', N'Porras', 'A', N'123'),
(N'paola.vega@hospitalcr.com', N'Paola', N'Vega', N'Monge', 'A', N'123'),
(N'fernando.ramirez@hospitalcr.com', N'Fernando', N'Ramírez', N'Quesada', 'A', N'123'),
(N'laura.campos11@hospitalcr.com', N'Laura', N'Campos', N'Jiménez', 'A', N'123'),
(N'adrian.aguilar@hospitalcr.com', N'Adrián', N'Aguilar', N'Castillo', 'A', N'123'),
(N'stephanie.rojas@hospitalcr.com', N'Stephanie', N'Rojas', N'Barrantes', 'A', N'123'),
(N'melissa.quesada@hospitalcr.com', N'Melissa', N'Quesada', N'Fonseca', 'A', N'123'),
(N'randall.alvarado@hospitalcr.com', N'Randall', N'Alvarado', N'Ruiz', 'A', N'123'),
(N'sergio.salas@hospitalcr.com', N'Sergio', N'Salas', N'Flores', 'A', N'123'),
(N'diana.chavarria@hospitalcr.com', N'Diana', N'Chavarría', N'Segura', 'A', N'123'),
(N'natalia.vega@hospitalcr.com', N'Natalia', N'Vega', N'Solís', 'A', N'123'),
(N'pablo.fernandez@hospitalcr.com', N'Pablo', N'Fernández', N'Alpízar', 'I', N'123'),
(N'gabriela.madrigal@hospitalcr.com', N'Gabriela', N'Madrigal', N'Leiva', 'A', N'123');

 PRINT 'Usuarios Insertados correctamenta'

GO

/* =========================
   7. Hospitales
   ========================= */
INSERT INTO Hospitales (Cod_Hospital, Descripcion, Direccion, Telefono, Correo, Web, Area, Fecha_Construccion, Estado) VALUES
(N'HCR001', N'Hospital México', N'La Uruca, San José, Costa Rica', N'22420000', N'mexico@ccss.sa.cr', N'www.hospitalmexico.cr', 35000, '1975-03-15', 'A'),
(N'HCR002', N'Hospital San Juan de Dios', N'Avenida 2, San José, Costa Rica', N'25472000', N'sjdd@ccss.sa.cr', N'www.hospitalsanjuan.cr', 42000, '1845-06-01', 'A'),
(N'HCR003', N'Hospital Calderón Guardia', N'Barrio Aranjuez, San José', N'22122000', N'calderon@ccss.sa.cr', N'www.calderonguardia.cr', 38000, '1960-09-10', 'A'),
(N'HCR004', N'Hospital de Heredia', N'Heredia centro, 200 m norte del parque', N'22607000', N'heredia@ccss.sa.cr', N'www.hospitalheredia.cr', 25000, '1985-02-20', 'A'),
(N'HCR005', N'Hospital de Alajuela', N'Costado norte del aeropuerto, Alajuela', N'24362000', N'alajuela@ccss.sa.cr', N'www.hospitalalajuela.cr', 30000, '1970-11-05', 'A'),
(N'HCR006', N'Hospital de Cartago', N'Cartago centro, contiguo al TEC', N'25502000', N'cartago@ccss.sa.cr', N'www.hospitalcartago.cr', 27000, '1980-08-18', 'A'),
(N'HCR007', N'Hospital de Puntarenas', N'Barrio El Carmen, Puntarenas', N'26302000', N'puntarenas@ccss.sa.cr', N'www.hospitalpuntarenas.cr', 24000, '1988-04-12', 'A'),
(N'HCR008', N'Hospital de Limón', N'Puerto Limón, contiguo al muelle', N'27582000', N'limon@ccss.sa.cr', N'www.hospitallimon.cr', 26000, '1992-07-22', 'A'),
(N'HCR009', N'Hospital de Liberia', N'Liberia, Guanacaste', N'26662000', N'liberia@ccss.sa.cr', N'www.hospitalliberia.cr', 23000, '1995-10-30', 'A'),
(N'HCR010', N'Hospital de San Carlos', N'Ciudad Quesada, Alajuela', N'24602000', N'sancarlos@ccss.sa.cr', N'www.hospitalsancarlos.cr', 22000, '1990-01-25', 'A'),
(N'HCR011', N'Hospital Nacional de Niños', N'Paseo Colón, San José', N'25232000', N'ninos@ccss.sa.cr', N'www.hospitalninos.cr', 28000, '1964-05-09', 'A'),
(N'HCR012', N'Hospital de Nicoya', N'Nicoya centro, Guanacaste', N'26852000', N'nicoya@ccss.sa.cr', N'www.hospitalnicoya.cr', 18000, '1998-03-03', 'A'),
(N'HCR013', N'Hospital de Guápiles', N'Guápiles, Pococí, Limón', N'27102000', N'guapiles@ccss.sa.cr', N'www.hospitalguapiles.cr', 19000, '1997-09-14', 'A'),
(N'HCR014', N'Hospital de Grecia', N'Grecia, Alajuela', N'24952000', N'grecia@ccss.sa.cr', N'www.hospitalgrecia.cr', 16000, '2001-12-01', 'A'),
(N'HCR015', N'Hospital de San Ramón', N'San Ramón, Alajuela', N'24472000', N'sanramon@ccss.sa.cr', N'www.hospitalsanramon.cr', 17000, '2000-06-06', 'A'),
(N'HCR016', N'Hospital de Turrialba', N'Turrialba centro, Cartago', N'25562000', N'turrialba@ccss.sa.cr', N'www.hospitalturrialba.cr', 15000, '1994-11-17', 'A'),
(N'HCR017', N'Hospital de Golfito', N'Golfito, Puntarenas', N'27751000', N'golfito@ccss.sa.cr', N'www.hospitalgolfito.cr', 14000, '1993-02-02', 'A'),
(N'HCR018', N'Hospital de Ciudad Neily', N'Ciudad Neily, Puntarenas', N'27851000', N'neily@ccss.sa.cr', N'www.hospitalneily.cr', 14500, '1996-09-09', 'A'),
(N'HCR019', N'Hospital de Siquirres', N'Siquirres, Limón', N'27682000', N'siquirres@ccss.sa.cr', N'www.hospitalsiquirres.cr', 13000, '2002-04-04', 'A'),
(N'HCR020', N'Hospital de Los Chiles', N'Los Chiles, Alajuela', N'24711000', N'loschiles@ccss.sa.cr', N'www.hospitalloschiles.cr', 12000, '2005-07-07', 'A');
 PRINT 'Hoispitales Insertados correctamenta'

GO

/* =========================
   8. Medicos
   (usa Tipos_Identificacion)
   ========================= */
INSERT INTO Medicos (Nombre, Prim_Apellido, Seg_Apellido, Tipo_Identificacion, Identificacion, Telefono, Correo, Cod_Profesional) VALUES
(N'Juan', N'Rodríguez', N'Mora', 1, N'101230456', N'88881111', N'juan.rodriguez@hospitalcr.com', N'MED0001'),
(N'Patricia', N'Solís', N'García', 1, N'204560789', N'88882222', N'patricia.solis@hospitalcr.com', N'MED0002'),
(N'Mauricio', N'Vargas', N'Campos', 2, N'900123456', N'88883333', N'mauricio.vargas@hospitalcr.com', N'MED0003'),
(N'Roxana', N'Chaves', N'Hernández', 1, N'305670890', N'88884444', N'roxana.chaves@hospitalcr.com', N'MED0004'),
(N'Andrés', N'Alfaro', N'Jiménez', 3, N'DIMEX12345', N'88885555', N'andres.alfaro@hospitalcr.com', N'MED0005'),
(N'Silvia', N'Rojas', N'Vega', 1, N'402340980', N'88886666', N'silvia.rojas@hospitalcr.com', N'MED0006'),
(N'Carlos', N'Méndez', N'Porras', 1, N'503450980', N'88887777', N'carlos.mendez@hospitalcr.com', N'MED0007'),
(N'Natalia', N'Quesada', N'Loaiza', 4, N'P1234567', N'88888899', N'natalia.quesada@hospitalcr.com', N'MED0008'),
(N'Gerardo', N'Hernández', N'Salas', 1, N'108760345', N'89990000', N'gerardo.hernandez@hospitalcr.com', N'MED0009'),
(N'Laura', N'Fernández', N'Zúñiga', 1, N'209870123', N'89991111', N'laura.fernandez@hospitalcr.com', N'MED0010'),
(N'Lucía', N'Campos', N'Ruiz', 1, N'310980234', N'89992222', N'lucia.campos@hospitalcr.com', N'MED0011'),
(N'Jorge', N'Segura', N'Alvarado', 1, N'411230567', N'89993333', N'jorge.segura@hospitalcr.com', N'MED0012'),
(N'Elena', N'Monge', N'Castro', 2, N'900234567', N'89994444', N'elena.monge@hospitalcr.com', N'MED0013'),
(N'Roberto', N'Pérez', N'Carrillo', 1, N'512340678', N'89995555', N'roberto.perez@hospitalcr.com', N'MED0014'),
(N'Sofía', N'Arias', N'Salazar', 1, N'613450789', N'89996666', N'sofia.arias@hospitalcr.com', N'MED0015'),
(N'Cristian', N'Murillo', N'Segura', 3, N'DIMEX98765', N'89997777', N'cristian.murillo@hospitalcr.com', N'MED0016'),
(N'Paola', N'Aguilar', N'Muñoz', 1, N'714560890', N'89998888', N'paola.aguilar@hospitalcr.com', N'MED0017'),
(N'Fabián', N'Castillo', N'Leiva', 1, N'815670901', N'87001111', N'fabian.castillo@hospitalcr.com', N'MED0018'),
(N'Isabel', N'Rojas', N'Solis', 2, N'900345678', N'87002222', N'isabel.rojas@hospitalcr.com', N'MED0019'),
(N'Guillermo', N'Guevara', N'Madrigal', 1, N'916780234', N'87003333', N'guillermo.guevara@hospitalcr.com', N'MED0020');

 PRINT 'Medicos Insertados correctamenta'

GO

/* =========================
   9. Pacientes
   (usa Tipos_Identificacion)
   ========================= */
INSERT INTO Pacientes (Nombre, Prim_Apellido, Seg_Apellido, Tipo_Identificacion, Identificacion, Telefono, Correo, Fecha_Nacimiento, Direccion) VALUES
(N'Kevin', N'Murillo', N'Salas', 1, N'101010101', N'85001111', N'kevin.murillo@gmail.com', '1995-05-10', N'San José, Pavas, Costa Rica'),
(N'Valeria', N'Ramírez', N'Guzmán', 1, N'102020202', N'85002222', N'valeria.ramirez@gmail.com', '1998-08-20', N'Heredia, Mercedes, Costa Rica'),
(N'Esteban', N'Jiménez', N'Chacón', 2, N'900111222', N'85003333', N'esteban.jimenez@gmail.com', '1990-03-15', N'Alajuela centro, Costa Rica'),
(N'Daniela', N'Vargas', N'Fonseca', 1, N'103030303', N'85004444', N'daniela.vargas@gmail.com', '2000-11-01', N'Cartago, Tres Ríos, Costa Rica'),
(N'Andrea', N'Solano', N'Zúñiga', 1, N'104040404', N'85005555', N'andrea.solano@gmail.com', '1992-09-09', N'San José, Curridabat, Costa Rica'),
(N'José', N'Leiva', N'Chavarría', 1, N'105050505', N'85006666', N'jose.leiva@gmail.com', '1988-01-22', N'Puntarenas, Esparza, Costa Rica'),
(N'Fabiola', N'Campos', N'Madrigal', 1, N'106060606', N'85007777', N'fabiola.campos@gmail.com', '1994-07-30', N'Limon, Guápiles, Costa Rica'),
(N'Luis', N'Alvarado', N'Rodríguez', 4, N'P7654321', N'85008888', N'luis.alvarado@gmail.com', '1985-12-05', N'Liberia, Guanacaste, Costa Rica'),
(N'Carolina', N'Castro', N'Vega', 1, N'107070707', N'85009999', N'carolina.castro@gmail.com', '1997-06-18', N'San Carlos, Quesada, Costa Rica'),
(N'Miguel', N'Hernández', N'Monge', 1, N'108080808', N'85101111', N'miguel.hernandez@gmail.com', '1993-10-25', N'Turrialba, Cartago, Costa Rica'),
(N'Adriana', N'Porras', N'Montoya', 1, N'109090909', N'85102222', N'adriana.porras@gmail.com', '1991-04-14', N'San Ramón, Alajuela, Costa Rica'),
(N'Brayan', N'Vargas', N'Rojas', 1, N'110101010', N'85103333', N'brayan.vargas@gmail.com', '1999-02-02', N'Grecia, Alajuela, Costa Rica'),
(N'Genesis', N'Salas', N'Cordero', 2, N'900555666', N'85104444', N'genesis.salas@gmail.com', '2001-09-01', N'Nicoya, Guanacaste, Costa Rica'),
(N'Kimberly', N'Mora', N'Segura', 1, N'111111111', N'85105555', N'kimberly.mora@gmail.com', '1996-05-05', N'Siquirres, Limón, Costa Rica'),
(N'Allan', N'García', N'Jiménez', 1, N'112121212', N'85106666', N'allan.garcia@gmail.com', '1987-11-11', N'Los Chiles, Alajuela, Costa Rica'),
(N'Sharon', N'Rojas', N'Campos', 1, N'113131313', N'85107777', N'sharon.rojas@gmail.com', '1994-03-03', N'Cartago centro, Costa Rica'),
(N'Jonathan', N'Segura', N'Aguilar', 3, N'DIMEX55667', N'85108888', N'jonathan.segura@gmail.com', '1989-08-08', N'San José, Hatillo, Costa Rica'),
(N'Paula', N'Fernández', N'Solís', 1, N'114141414', N'85109999', N'paula.fernandez@gmail.com', '1992-12-12', N'Heredia, San Francisco, Costa Rica'),
(N'Eduardo', N'Martínez', N'Quesada', 1, N'115151515', N'85201111', N'eduardo.martinez@gmail.com', '1986-06-06', N'Alajuela, San Rafael, Costa Rica'),
(N'María', N'Flores', N'Hidalgo', 1, N'116161616', N'85202222', N'maria.flores@gmail.com', '1990-09-19', N'Puntarenas centro, Costa Rica');
 PRINT 'Pacientes Insertados correctamenta'

GO

/* =========================
   10. Consultorios
   (usa Hospitales y Tipos_Consultorios)
   ========================= */
INSERT INTO Consultorios (Id_Hospital, Id_TipoConsultorio, Descripcion, Estado) VALUES
(1, 2,  N'Consulta externa pediatría 1 - Hospital México', 'A'),
(2, 3,  N'Consulta ginecología 1 - San Juan de Dios', 'A'),
(2, 9,  N'Emergencias adulto - San Juan de Dios', 'A'),
(3, 4,  N'Consulta cardiología 1 - Calderón Guardia', 'A'),
(3, 11, N'UCI adultos - Calderón Guardia', 'A'),
(4, 1,  N'Consulta medicina general 1 - Heredia', 'A'),
(4, 13, N'Consulta odontología - Heredia', 'A'),
(5, 5,  N'Consulta dermatología - Alajuela', 'A'),
(5, 9,  N'Emergencias - Alajuela', 'A'),
(6, 2,  N'Consulta pediatría - Cartago', 'A'),
(6, 16, N'Consulta medicina del dolor - Cartago', 'A'),
(7, 1,  N'Consulta medicina general - Puntarenas', 'A'),
(7, 9,  N'Emergencias - Puntarenas', 'A'),
(8, 8,  N'Consulta psiquiatría - Limón', 'A'),
(8, 10, N'Sala de observación - Limón', 'A'),
(9, 1,  N'Consulta general - Liberia', 'A'),
(9, 18, N'Consulta medicina interna - Liberia', 'A'),
(10, 1, N'Consulta general - San Carlos', 'A'),
(10, 19, N'Consulta neumología - San Carlos', 'A');

 PRINT 'Consultorios Insertados correctamenta'
GO

/* =========================
   11. Especialidades_X_Medicos
   (usa Medicos y Tipos_Especialidades)
   ========================= */
INSERT INTO Especialidades_X_Medicos (Id_TipoEspecialidad, Id_Medico) VALUES
(4, 2),
(2, 3),
(3, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10),
(11, 11),
(12, 12),
(13, 13),
(14, 14),
(15, 15),
(16, 16),
(17, 17),
(18, 18),
(19, 19),
(20, 20),
(1,1);

 PRINT 'Especialidades de medicos Insertados correctamenta'

GO
/* =========================
   11. Modulos_X_Usuarios
   (usa Modulos, Usuarios)
   ========================= */
INSERT INTO [dbo].[Modulos_X_Usuario] ([Id_Usuario],[Id_Modulo])
VALUES 
(1,1)
,(1,2)
,(1,3)
,(1,4)
,(1,5)
,(1,6)
,(1,7)
,(1,8)
,(1,9)
,(1,10)
,(2,1)
,(2,2)
,(2,3)
,(2,4)
,(2,5)
,(2,6)
,(2,7)
,(2,8)
,(2,9)
,(2,10)

 PRINT 'Modulos para superusuarios Insertados correctamenta'
 GO

