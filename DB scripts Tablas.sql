use master 
go

create database CRUD_HOTELES
go

use CRUD_HOTELES
go


--Crear Tabla Usuarios
CREATE TABLE [dbo].[Usuarios](
	[Id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Prim_Apellido] [nvarchar](50) NOT NULL,
	[Seg_Apellido] [nvarchar](50) NOT NULL,
	[Estado] [char](1) NOT NULL,
	[Password] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único de usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuarios', @level2type=N'COLUMN',@level2name=N'Id_Usuario'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Correo electrónico' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuarios', @level2type=N'COLUMN',@level2name=N'Correo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuarios', @level2type=N'COLUMN',@level2name=N'Nombre'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primer Apellido ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuarios', @level2type=N'COLUMN',@level2name=N'Prim_Apellido'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Segundo apellido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuarios', @level2type=N'COLUMN',@level2name=N'Seg_Apellido'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado (A: activo , I: inactivo)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuarios', @level2type=N'COLUMN',@level2name=N'Estado'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Password de usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuarios', @level2type=N'COLUMN',@level2name=N'Password'
GO


--Crear tabla Auditoria


CREATE TABLE [dbo].[Auditoria](
	[Id_Auditoria] [int] IDENTITY(1,1) NOT NULL,
	[Id_Usuario] [int] NOT NULL,
	[Accion] [char](1) NOT NULL,
	[Descripción] [nvarchar](500) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Auditoria] PRIMARY KEY CLUSTERED 
(
	[Id_Auditoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Auditoria]  WITH CHECK ADD  CONSTRAINT [FK_Auditoria_Usuarios] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuarios] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Auditoria] CHECK CONSTRAINT [FK_Auditoria_Usuarios]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único de registro de auditoría' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Auditoria', @level2type=N'COLUMN',@level2name=N'Id_Auditoria'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de Usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Auditoria', @level2type=N'COLUMN',@level2name=N'Id_Usuario'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Acción realizada (A: Actualizar , E: Eliminar , I: Insertar)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Auditoria', @level2type=N'COLUMN',@level2name=N'Accion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción de la acción realizada' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Auditoria', @level2type=N'COLUMN',@level2name=N'Descripción'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora de la acción realizada' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Auditoria', @level2type=N'COLUMN',@level2name=N'Fecha'
GO

--Crear tabla tipos de identificacion


CREATE TABLE [dbo].[Tipos_Identificacion](
	[Id_TipoIdentificacion] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Identificacion] [nvarchar](50) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Tipos_Identificacion] PRIMARY KEY CLUSTERED 
(
	[Id_TipoIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de tipo de indentificación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tipos_Identificacion', @level2type=N'COLUMN',@level2name=N'Id_TipoIdentificacion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de identificación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tipos_Identificacion', @level2type=N'COLUMN',@level2name=N'Tipo_Identificacion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado (A: activo , I: inactivo)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tipos_Identificacion', @level2type=N'COLUMN',@level2name=N'Estado'
GO

--Crear tabla tipos de consultorios



CREATE TABLE [dbo].[Tipos_Consultorios](
	[Id_TipoConsultorio] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Consultorio] [nvarchar](50) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Tipos_Consultorios] PRIMARY KEY CLUSTERED 
(
	[Id_TipoConsultorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de tipo de consultorio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tipos_Consultorios', @level2type=N'COLUMN',@level2name=N'Id_TipoConsultorio'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de consultorio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tipos_Consultorios', @level2type=N'COLUMN',@level2name=N'Tipo_Consultorio'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado (A: activo , I: inactivo)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tipos_Consultorios', @level2type=N'COLUMN',@level2name=N'Estado'
GO

--Crear tabla tipos de especialidades


CREATE TABLE [dbo].[Tipos_Especialidades](
	[Id_TipoEspecialidad] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Especialidad] [nvarchar](50) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Tipos_Especialidades] PRIMARY KEY CLUSTERED 
(
	[Id_TipoEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de tipo de especialidad' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tipos_Especialidades', @level2type=N'COLUMN',@level2name=N'Id_TipoEspecialidad'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de Especialidad' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tipos_Especialidades', @level2type=N'COLUMN',@level2name=N'Tipo_Especialidad'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado (A: activo , I: inactivo)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tipos_Especialidades', @level2type=N'COLUMN',@level2name=N'Estado'
GO

--Crear tabla tipo de citas

CREATE TABLE [dbo].[Tipos_Citas](
	[Id_TipoCita] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Cita] [nvarchar](50) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Tipos_Citas] PRIMARY KEY CLUSTERED 
(
	[Id_TipoCita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de tipo de cita' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tipos_Citas', @level2type=N'COLUMN',@level2name=N'Id_TipoCita'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de cita' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tipos_Citas', @level2type=N'COLUMN',@level2name=N'Tipo_Cita'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado (A: activo , I: inactivo)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tipos_Citas', @level2type=N'COLUMN',@level2name=N'Estado'
GO

--Crear tabla Pacientes


CREATE TABLE [dbo].[Pacientes](
	[Id_Paciente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Prim_Apellido] [nvarchar](50) NOT NULL,
	[Seg_Apellido] [nvarchar](50) NOT NULL,
	[Tipo_Identificacion] [int] NOT NULL,
	[Identificacion] [nvarchar](25) NOT NULL,
	[Telefono] [nvarchar](8) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Fecha_Nacimiento] [date] NOT NULL,
	[Direccion] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED 
(
	[Id_Paciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Pacientes_Tipos_Identificacion] FOREIGN KEY([Tipo_Identificacion])
REFERENCES [dbo].[Tipos_Identificacion] ([Id_TipoIdentificacion])
GO

ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_Pacientes_Tipos_Identificacion]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único de paciente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacientes', @level2type=N'COLUMN',@level2name=N'Id_Paciente'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacientes', @level2type=N'COLUMN',@level2name=N'Nombre'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primer Apellido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacientes', @level2type=N'COLUMN',@level2name=N'Prim_Apellido'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Segundo Apellido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacientes', @level2type=N'COLUMN',@level2name=N'Seg_Apellido'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de Identificacion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacientes', @level2type=N'COLUMN',@level2name=N'Tipo_Identificacion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de identificación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacientes', @level2type=N'COLUMN',@level2name=N'Identificacion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Teléfono' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacientes', @level2type=N'COLUMN',@level2name=N'Telefono'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Correo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacientes', @level2type=N'COLUMN',@level2name=N'Correo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de Nacimiento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacientes', @level2type=N'COLUMN',@level2name=N'Fecha_Nacimiento'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dirección de residencia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacientes', @level2type=N'COLUMN',@level2name=N'Direccion'
GO


--Crear tabla Modulos (Auxiliar, no requeire CRUD)


CREATE TABLE [dbo].[Modulos](
	[Id_Modulo] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [nvarchar](50) NOT NULL,
	[ClaseCSS] [varchar](100) NULL,
	[Enlace] [varchar](100) NULL,
 CONSTRAINT [PK_Modulos] PRIMARY KEY CLUSTERED 
(
	[Id_Modulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Modulos] ADD  DEFAULT ('') FOR [ClaseCSS]
GO

ALTER TABLE [dbo].[Modulos] ADD  DEFAULT ('') FOR [Enlace]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único de Módulo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Modulos', @level2type=N'COLUMN',@level2name=N'Id_Modulo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción de Módulo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Modulos', @level2type=N'COLUMN',@level2name=N'Modulo'
GO


--Crear tabla modulos por usuario

CREATE TABLE [dbo].[Modulos_X_Usuario](
	[Id_Modulo_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Id_Usuario] [int] NOT NULL,
	[Id_Modulo] [int] NOT NULL,
 CONSTRAINT [PK_Modulos_X_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id_Modulo_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Modulos_X_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Modulos_X_Usuario_Modulos] FOREIGN KEY([Id_Modulo])
REFERENCES [dbo].[Modulos] ([Id_Modulo])
GO

ALTER TABLE [dbo].[Modulos_X_Usuario] CHECK CONSTRAINT [FK_Modulos_X_Usuario_Modulos]
GO

ALTER TABLE [dbo].[Modulos_X_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Modulos_X_Usuario_Usuarios] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuarios] ([Id_Usuario])
GO

ALTER TABLE [dbo].[Modulos_X_Usuario] CHECK CONSTRAINT [FK_Modulos_X_Usuario_Usuarios]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de módulos x Usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Modulos_X_Usuario', @level2type=N'COLUMN',@level2name=N'Id_Modulo_Usuario'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de Usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Modulos_X_Usuario', @level2type=N'COLUMN',@level2name=N'Id_Usuario'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de Modulo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Modulos_X_Usuario', @level2type=N'COLUMN',@level2name=N'Id_Modulo'
GO


--Crear tabla hospitales


CREATE TABLE [dbo].[Hospitales](
	[Id_Hospital] [int] IDENTITY(1,1) NOT NULL,
	[Cod_Hospital] [nvarchar](10) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](500) NOT NULL,
	[Telefono] [nvarchar](8) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Web] [nvarchar](50) NOT NULL,
	[Area] [int] NOT NULL,
	[Fecha_Construccion] [date] NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Hospitales] PRIMARY KEY CLUSTERED 
(
	[Id_Hospital] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único de Hospital' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hospitales', @level2type=N'COLUMN',@level2name=N'Id_Hospital'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Hospital' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hospitales', @level2type=N'COLUMN',@level2name=N'Cod_Hospital'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción de Hospital' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hospitales', @level2type=N'COLUMN',@level2name=N'Descripcion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dirección de ubicación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hospitales', @level2type=N'COLUMN',@level2name=N'Direccion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Teléfono' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hospitales', @level2type=N'COLUMN',@level2name=N'Telefono'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Correo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hospitales', @level2type=N'COLUMN',@level2name=N'Correo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sitio Web' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hospitales', @level2type=N'COLUMN',@level2name=N'Web'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Área de construcción en mts cuadrados' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hospitales', @level2type=N'COLUMN',@level2name=N'Area'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de Construcción' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hospitales', @level2type=N'COLUMN',@level2name=N'Fecha_Construccion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado de Hospital A: Activo I: Inactivo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hospitales', @level2type=N'COLUMN',@level2name=N'Estado'
GO


--Crear tabla medico



CREATE TABLE [dbo].[Medicos](
	[Id_Medico] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Prim_Apellido] [nvarchar](50) NOT NULL,
	[Seg_Apellido] [nvarchar](50) NOT NULL,
	[Tipo_Identificacion] [int] NOT NULL,
	[Identificacion] [nvarchar](25) NOT NULL,
	[Telefono] [nvarchar](8) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Cod_Profesional] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED 
(
	[Id_Medico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Medicos_Tipos_Identificacion] FOREIGN KEY([Tipo_Identificacion])
REFERENCES [dbo].[Tipos_Identificacion] ([Id_TipoIdentificacion])
GO

ALTER TABLE [dbo].[Medicos] CHECK CONSTRAINT [FK_Medicos_Tipos_Identificacion]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único de médico' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medicos', @level2type=N'COLUMN',@level2name=N'Id_Medico'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medicos', @level2type=N'COLUMN',@level2name=N'Nombre'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primer Apellido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medicos', @level2type=N'COLUMN',@level2name=N'Prim_Apellido'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Segundo Apellido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medicos', @level2type=N'COLUMN',@level2name=N'Seg_Apellido'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de Identificacion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medicos', @level2type=N'COLUMN',@level2name=N'Tipo_Identificacion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de identificación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medicos', @level2type=N'COLUMN',@level2name=N'Identificacion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Teléfono' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medicos', @level2type=N'COLUMN',@level2name=N'Telefono'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Correo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medicos', @level2type=N'COLUMN',@level2name=N'Correo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de registro de profesional' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medicos', @level2type=N'COLUMN',@level2name=N'Cod_Profesional'
GO



--crear tabla consultorios



CREATE TABLE [dbo].[Consultorios](
	[Id_Consultorio] [int] IDENTITY(1,1) NOT NULL,
	[Id_Hospital] [int] NOT NULL,
	[Id_TipoConsultorio] [int] NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Consultorios] PRIMARY KEY CLUSTERED 
(
	[Id_Consultorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Consultorios]  WITH CHECK ADD  CONSTRAINT [FK_Consultorios_Hospitales] FOREIGN KEY([Id_Hospital])
REFERENCES [dbo].[Hospitales] ([Id_Hospital])
GO

ALTER TABLE [dbo].[Consultorios] CHECK CONSTRAINT [FK_Consultorios_Hospitales]
GO


ALTER TABLE [dbo].[Consultorios]  WITH CHECK ADD  CONSTRAINT [FK_Consultorios_Tipos_Consultorios] FOREIGN KEY([Id_TipoConsultorio])
REFERENCES [dbo].[Tipos_Consultorios] ([Id_TipoConsultorio])
GO

ALTER TABLE [dbo].[Consultorios] CHECK CONSTRAINT [FK_Consultorios_Tipos_Consultorios]
GO



EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único de consultorio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Consultorios', @level2type=N'COLUMN',@level2name=N'Id_Consultorio'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id de Hospital' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Consultorios', @level2type=N'COLUMN',@level2name=N'Id_Hospital'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id de tipo de consultorio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Consultorios', @level2type=N'COLUMN',@level2name=N'Id_TipoConsultorio'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripcion de consultorio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Consultorios', @level2type=N'COLUMN',@level2name=N'Descripcion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado de Consultorio A: Activo I: Inactivo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Consultorios', @level2type=N'COLUMN',@level2name=N'Estado'
GO


--Crear tabla especialidades por medico


CREATE TABLE [dbo].[Especialidades_X_Medicos](
	[Id_Especialidad_Medico] [int] IDENTITY(1,1) NOT NULL,
	[Id_TipoEspecialidad] [int] NOT NULL,
	[Id_Medico] [int] NOT NULL,
CONSTRAINT [PK_Especialidades_X_Medicos] PRIMARY KEY CLUSTERED 
(
	[Id_Especialidad_Medico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Especialidades_X_Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Especialidades_X_Medicos_Tipos_Especialidades] FOREIGN KEY([Id_TipoEspecialidad])
REFERENCES [dbo].[Tipos_Especialidades] ([Id_TipoEspecialidad])
GO

ALTER TABLE [dbo].[Especialidades_X_Medicos] CHECK CONSTRAINT [FK_Especialidades_X_Medicos_Tipos_Especialidades]
GO

ALTER TABLE [dbo].[Especialidades_X_Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Especialidades_X_Medicos_Medicos] FOREIGN KEY([Id_Medico])
REFERENCES [dbo].[Medicos] ([Id_Medico])
GO

ALTER TABLE [dbo].[Especialidades_X_Medicos] CHECK CONSTRAINT [FK_Especialidades_X_Medicos_Medicos]


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único de especialidades x medico' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Especialidades_X_Medicos', @level2type=N'COLUMN',@level2name=N'Id_Especialidad_Medico'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de especialidad' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Especialidades_X_Medicos', @level2type=N'COLUMN',@level2name=N'Id_TipoEspecialidad'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de medico' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Especialidades_X_Medicos', @level2type=N'COLUMN',@level2name=N'Id_Medico'
GO


--crear tabla citas



CREATE TABLE [dbo].[Citas](
	[Id_Cita] [int] IDENTITY(1,1) NOT NULL,
	[Id_TipoCita] [int] NOT NULL,
	[Id_Medico] [int] NOT NULL,
	[Id_Paciente] [int] NOT NULL,
	[Id_Consultorio] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Citas] PRIMARY KEY CLUSTERED 
(
	[Id_Cita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Tipos_Citas] FOREIGN KEY([Id_TipoCita])
REFERENCES [dbo].[Tipos_Citas] ([Id_TipoCita])
GO

ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Tipos_Citas]
GO

ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Medicos] FOREIGN KEY([Id_Medico])
REFERENCES [dbo].[Medicos] ([Id_Medico])
GO

ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Medicos]
GO

ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Pacientes] FOREIGN KEY([Id_Paciente])
REFERENCES [dbo].[Pacientes] ([Id_Paciente])
GO

ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Pacientes]
GO

ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Consultorios] FOREIGN KEY([Id_Consultorio])
REFERENCES [dbo].[Consultorios] ([Id_Consultorio])
GO

ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Consultorios]
GO



EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único de cita' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Citas', @level2type=N'COLUMN',@level2name=N'Id_Cita'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de Médico' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Citas', @level2type=N'COLUMN',@level2name=N'Id_Medico'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de Paciente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Citas', @level2type=N'COLUMN',@level2name=N'Id_Paciente'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de Consultorio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Citas', @level2type=N'COLUMN',@level2name=N'Id_Consultorio'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de Tipo de Cita' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Citas', @level2type=N'COLUMN',@level2name=N'Id_TipoCita'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de Cita' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Citas', @level2type=N'COLUMN',@level2name=N'Fecha'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado de Cita A: Activo I: Inactivo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Citas', @level2type=N'COLUMN',@level2name=N'Estado'
GO
