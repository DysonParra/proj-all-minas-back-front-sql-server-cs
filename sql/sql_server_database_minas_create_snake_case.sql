USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Minas') DROP DATABASE [Minas]
GO
CREATE DATABASE [Minas];
GO
USE [Minas];
GO

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Bascula')
CREATE TABLE [dbo].[Bascula] (
    [Id_Proveedor]                      INT                 NOT NULL IDENTITY,
    [Rfid]                              VARCHAR(50)         NOT NULL,
    [Codigo_Partida]                    INT                 NOT NULL,
    [Numero_Muestra]                    INT                 NOT NULL,
    [Estado_Partida]                    INT                 NOT NULL,
    [Fecha_Hora_Entrada]                DATETIME            NOT NULL,
    [Peso_Bruto]                        FLOAT               NOT NULL,
    [Peso_Neto]                         FLOAT               NOT NULL,
    [Tipo_Vehiculo]                     VARCHAR(20)         NOT NULL,
    [Mss_Codigo_Partida]                VARCHAR(100)        NOT NULL,
    [Mss_Fecha_Hora_Toma_Muestra]       DATETIME            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Proveedor])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Categoria')
CREATE TABLE [dbo].[Categoria] (
    [Id_Categoria]                      INT                 NOT NULL IDENTITY,
    [Tipo_Vehiculo]                     VARCHAR(50)             NULL,
    [Peso_Maximo]                       FLOAT                   NULL,
    [Tolerancia]                        FLOAT                   NULL,
    [Descripcion]                       VARCHAR(300)            NULL,
    [Eje_Sencillo]                      FLOAT                   NULL DEFAULT 0,
    [Eje_Tandem]                        FLOAT                   NULL DEFAULT 0,
    [Eje_Tridem]                        FLOAT                   NULL DEFAULT 0,
    [Total_Ejes]                        INT                     NULL,
    PRIMARY KEY CLUSTERED ([Id_Categoria])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Cierre_Partida')
CREATE TABLE [dbo].[Cierre_Partida] (
    [Consecutivo]                       INT                 NOT NULL IDENTITY,
    [Codigo_Partida]                    INT                     NULL,
    [Cif_Proveedor]                     VARCHAR(50)             NULL,
    [Codigo_Vehiculo]                   INT                     NULL,
    [Rfid]                              VARCHAR(100)            NULL,
    [Peso]                              INT                     NULL,
    [Fecha]                             DATETIME                NULL,
    [Estado]                            VARCHAR(50)             NULL,
    [Peso_Estimado]                     INT                     NULL,
    [Tipo]                              VARCHAR(50)             NULL,
    PRIMARY KEY CLUSTERED ([Consecutivo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Codigo_Origen')
CREATE TABLE [dbo].[Codigo_Origen] (
    [Id]                                INT                 NOT NULL IDENTITY,
    [Codigo]                            VARCHAR(10)             NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Conductor')
CREATE TABLE [dbo].[Conductor] (
    [Identificacion]                    VARCHAR(30)         NOT NULL,
    [Nombre_Conductor]                  VARCHAR(200)        NOT NULL,
    [Fecha_Nacimiento]                  DATE                    NULL,
    [Licencia_Conduccion]               VARCHAR(50)             NULL,
    [Fecha_Vencimiento]                 DATE                    NULL,
    [Observaciones]                     VARCHAR(200)            NULL,
    [Tipo_Sancion]                      VARCHAR(100)            NULL,
    [Fecha_Inicio_Sancion]              DATE                    NULL,
    [Fecha_Final_Sancion]               DATE                    NULL,
    [Dias_Sancion]                      VARCHAR(20)             NULL,
    PRIMARY KEY CLUSTERED ([Identificacion])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Configuracion')
CREATE TABLE [dbo].[Configuracion] (
    [Id]                                INT                 NOT NULL IDENTITY,
    [Tipo]                              NVARCHAR(50)            NULL,
    [Indicador]                         NVARCHAR(500)           NULL,
    [Baudios]                           NVARCHAR(50)            NULL,
    [Bits_Datos]                        NVARCHAR(50)            NULL,
    [Bits_Parada]                       NVARCHAR(50)            NULL,
    [Paridad]                           NVARCHAR(50)            NULL,
    [Ip]                                NVARCHAR(50)            NULL,
    [Puerto]                            NVARCHAR(50)            NULL,
    [Usuario]                           NVARCHAR(50)            NULL,
    [Contrasena]                        NVARCHAR(50)            NULL,
    [Estado]                            BIT                     NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Consecutivo_Diario')
CREATE TABLE [dbo].[Consecutivo_Diario] (
    [Rfid]                              VARCHAR(50)         NOT NULL,
    [Nro_Tiquete]                       INT                 NOT NULL,
    [Consecutivo_Dia]                   INT                 NOT NULL,
    PRIMARY KEY CLUSTERED ([Rfid])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Contrato')
CREATE TABLE [dbo].[Contrato] (
    [Id_Contrato]                       INT                 NOT NULL IDENTITY,
    [Id_Parque]                         VARCHAR(30)         NOT NULL,
    [Centro_Produccion]                 VARCHAR(200)        NOT NULL,
    [Carburante]                        VARCHAR(200)        NOT NULL,
    [Tipo_Agrupacion]                   VARCHAR(200)            NULL,
    [Partida_Maestra]                   BIT                 NOT NULL,
    [Tipo_Existencia]                   INT                 NOT NULL,
    [Descripcion]                       VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([Id_Contrato])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Control_Acceso')
CREATE TABLE [dbo].[Control_Acceso] (
    [Id_Control]                        INT                 NOT NULL IDENTITY,
    [Id_Contrato]                       INT                     NULL,
    [Id_Mina]                           VARCHAR(50)             NULL,
    [Id_Destino]                        VARCHAR(50)             NULL,
    [Rfid]                              VARCHAR(100)            NULL,
    [Placa]                             VARCHAR(10)             NULL,
    [Conductor]                         VARCHAR(200)            NULL,
    [Cif_Proveedor]                     VARCHAR(50)             NULL,
    [Fecha_Ingreso]                     DATETIME                NULL,
    [Fecha_Salida]                      DATETIME                NULL,
    [Tope_Mensual]                      INT                     NULL,
    [Acumulado]                         INT                     NULL,
    [Fecha_Validez]                     DATE                    NULL,
    [Tipo_Tarjeta]                      VARCHAR(100)            NULL,
    PRIMARY KEY CLUSTERED ([Id_Control])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Destino')
CREATE TABLE [dbo].[Destino] (
    [Id_Destino]                        VARCHAR(50)         NOT NULL,
    [Nombre]                            VARCHAR(100)            NULL,
    [Telefono]                          VARCHAR(20)             NULL,
    [Direccion]                         VARCHAR(200)            NULL,
    [Observaciones]                     VARCHAR(200)            NULL,
    [Seleccionado]                      VARCHAR(50)             NULL,
    PRIMARY KEY CLUSTERED ([Id_Destino])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Ficheros_Proveedor')
CREATE TABLE [dbo].[Ficheros_Proveedor] (
    [Cif]                               VARCHAR(50)         NOT NULL,
    [Nombre]                            VARCHAR(200)            NULL,
    [Tope_Mensual]                      INT                     NULL,
    [Fecha_Hora_Carga]                  DATETIME                NULL,
    [Id_Usuario]                        VARCHAR(20)             NULL,
    PRIMARY KEY CLUSTERED ([Cif])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Generador_Partida')
CREATE TABLE [dbo].[Generador_Partida] (
    [Consecutivo]                       INT                 NOT NULL IDENTITY,
    [Codigo_Partida]                    INT                     NULL,
    [Cif_Proveedor]                     VARCHAR(50)             NULL,
    [Codigo_Vehiculo]                   INT                     NULL,
    [Rfid]                              VARCHAR(100)            NULL,
    [Peso]                              INT                     NULL,
    [Fecha]                             DATETIME                NULL,
    [Estado]                            VARCHAR(50)             NULL,
    [Peso_Estimado]                     INT                     NULL,
    [Tipo]                              VARCHAR(50)             NULL,
    PRIMARY KEY CLUSTERED ([Consecutivo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Indicador')
CREATE TABLE [dbo].[Indicador] (
    [Codigo]                            NVARCHAR(50)        NOT NULL,
    [Nombre]                            VARCHAR(500)            NULL,
    [Tamano_Trama]                      VARCHAR(10)             NULL,
    [Posicion_Inicial]                  VARCHAR(10)             NULL,
    [Total_Datos_Peso]                  VARCHAR(10)             NULL,
    [Caracter_Fin_Trama]                VARCHAR(10)             NULL,
    [Caracter_Inicio_Trama]             VARCHAR(10)             NULL,
    PRIMARY KEY CLUSTERED ([Codigo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Mina')
CREATE TABLE [dbo].[Mina] (
    [Id_Mina]                           VARCHAR(50)         NOT NULL,
    [Nombre]                            VARCHAR(200)            NULL,
    [Localidad]                         VARCHAR(100)            NULL,
    [Telefono]                          VARCHAR(30)             NULL,
    [Id_Titulo_Minero]                  VARCHAR(50)             NULL,
    [Observaciones]                     VARCHAR(200)            NULL,
    [Producto]                          VARCHAR(100)            NULL,
    [Ticket]                            VARCHAR(50)             NULL,
    PRIMARY KEY CLUSTERED ([Id_Mina])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Muestra')
CREATE TABLE [dbo].[Muestra] (
    [Id_Muestra]                        INT                 NOT NULL IDENTITY,
    [Rfid]                              VARCHAR(100)            NULL,
    [Partida]                           VARCHAR(10)             NULL,
    [Camion]                            VARCHAR(10)             NULL,
    [Fecha_Hora]                        DATETIME                 NULL,
    [Observaciones]                     VARCHAR(300)            NULL,
    PRIMARY KEY CLUSTERED ([Id_Muestra])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Origen')
CREATE TABLE [dbo].[Origen] (
    [Id_Origen]                         VARCHAR(50)         NOT NULL,
    [Nombre]                            VARCHAR(100)            NULL,
    [Codigo_Rfid]                       VARCHAR(20)             NULL,
    [Direccion]                         VARCHAR(200)            NULL,
    [Observaciones]                     VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([Id_Origen])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Parque')
CREATE TABLE [dbo].[Parque] (
    [Id_Parque]                         INT                 NOT NULL IDENTITY,
    [Nombre_Parque]                     VARCHAR(100)        NOT NULL,
    [Observaciones]                     VARCHAR(200)            NULL,
    [Ubicacion]                         VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([Id_Parque])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Producto')
CREATE TABLE [dbo].[Producto] (
    [Id_Producto]                       INT                 NOT NULL IDENTITY,
    [Producto]                          VARCHAR(100)            NULL,
    PRIMARY KEY CLUSTERED ([Id_Producto])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Proveedor')
CREATE TABLE [dbo].[Proveedor] (
    [Cif]                               VARCHAR(50)         NOT NULL,
    [Nombre]                            VARCHAR(200)        NOT NULL,
    [Direccion]                         VARCHAR(200)            NULL,
    [Pais]                              VARCHAR(100)            NULL,
    [Poblacion]                         VARCHAR(100)            NULL,
    [Codigo_Proveedor]                  VARCHAR(50)             NULL,
    [Correo_Electronico]                VARCHAR(200)            NULL,
    [Patio]                             VARCHAR(20)             NULL,
    [Tope_Mensual]                      INT                     NULL,
    [Acumulado]                         INT                     NULL,
    [Observaciones]                     VARCHAR(300)            NULL,
    [Tope_Opcional]                     INT                     NULL,
    [Tope_Adicional]                    INT                     NULL,
    [Tope_Spot]                         INT                     NULL,
    [Tope_Otros]                        INT                     NULL,
    PRIMARY KEY CLUSTERED ([Cif])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Registro_Entrada_Salida')
CREATE TABLE [dbo].[Registro_Entrada_Salida] (
    [Id_Entrada]                        INT                 NOT NULL IDENTITY,
    [Id_Parque]                         INT                     NULL,
    [Transporte]                        VARCHAR(10)             NULL,
    [Ticket]                            VARCHAR(20)             NULL,
    [Matricula]                         VARCHAR(10)             NULL,
    [Vagon]                             VARCHAR(50)             NULL,
    [Fecha_Entrada]                     DATETIME                NULL,
    [Fecha_Salida]                      DATETIME                NULL,
    [Combustible]                       VARCHAR(50)             NULL,
    [Tipo_Movimiento]                   VARCHAR(20)             NULL,
    [Nombre]                            VARCHAR(200)            NULL,
    [Parva_Anterior]                    VARCHAR(50)             NULL,
    [Fecha_Fin_Parva]                   DATE                    NULL,
    [Patio]                             VARCHAR(100)            NULL,
    [Fecha_Inicio_Parva]                DATE                    NULL,
    [Muestras]                          VARCHAR(100)            NULL,
    [Nro_Bolsa]                         VARCHAR(50)             NULL,
    [Codigo_Partida]                    VARCHAR(10)             NULL,
    [Consecutivo_Vehiculo]              VARCHAR(50)             NULL,
    [Peso_Entrada]                      INT                     NULL,
    [Peso_Salida]                       INT                     NULL,
    [Peso_Neto]                         INT                     NULL,
    [Unidad]                            VARCHAR(5)              NULL,
    [Descripcion]                       VARCHAR(300)            NULL,
    [Ruta_Fotos]                        VARCHAR(MAX)            NULL,
    [Rfid]                              VARCHAR(100)            NULL,
    [Proceso_Manual]                    BIT                     NULL,
    [Usuario]                           VARCHAR(100)            NULL,
    [Vehiculo_Devuelto]                 BIT                     NULL,
    [Cif]                               VARCHAR(50)             NULL,
    [Id_Destino]                        VARCHAR(50)             NULL,
    [Id_Origen]                         VARCHAR(50)             NULL,
    [Estado]                            VARCHAR(50)             NULL,
    [Id_Por_Dia]                        INT                     NULL,
    PRIMARY KEY CLUSTERED ([Id_Entrada])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Sancion')
CREATE TABLE [dbo].[Sancion] (
    [Numero]                            INT                 NOT NULL IDENTITY,
    [Item]                              VARCHAR(200)            NULL,
    [Sancion_Conductor]                 BIT                     NULL,
    [Sancion_Vehiculo]                  BIT                     NULL,
    [Tiempo]                            VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([Numero])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Temporal')
CREATE TABLE [dbo].[Temporal] (
    [Id_Temporal]                       INT                 NOT NULL IDENTITY,
    [Placa]                             VARCHAR(10)             NULL,
    [Rfid]                              VARCHAR(50)             NULL,
    [Proveedor]                         VARCHAR(100)            NULL,
    [Tope]                              VARCHAR(20)             NULL,
    [Acumulado]                         INT                     NULL,
    [Fecha_Entrada]                     DATETIME                NULL,
    [Fecha_Salida]                      DATETIME                NULL,
    [Estado]                            VARCHAR(500)            NULL,
    PRIMARY KEY CLUSTERED ([Id_Temporal])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Titulo_Minero')
CREATE TABLE [dbo].[Titulo_Minero] (
    [Id_Titulo]                         VARCHAR(50)         NOT NULL,
    [Nombre]                            VARCHAR(200)        NOT NULL,
    [Localidad]                         VARCHAR(100)            NULL,
    [Telefono]                          VARCHAR(50)             NULL,
    [Cif_Proveedor]                     VARCHAR(50)             NULL,
    [Observaciones]                     VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([Id_Titulo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Usuario')
CREATE TABLE [dbo].[Usuario] (
    [Cedula]                            INT                 NOT NULL IDENTITY,
    [Nombre]                            VARCHAR(100)        NOT NULL,
    [Apellido]                          VARCHAR(100)        NOT NULL,
    [Email]                             NVARCHAR(100)           NULL,
    [Telefono]                          NVARCHAR(50)            NULL,
    [Rh]                                NCHAR(10)               NULL,
    [Seudonimo]                         VARCHAR(50)             NULL,
    [Tipo]                              VARCHAR(100)            NULL,
    [Cargo]                             NVARCHAR(50)            NULL,
    [Contrasena]                        VARCHAR(MAX)            NULL,
    [Foto]                              VARCHAR(MAX)            NULL,
    PRIMARY KEY CLUSTERED ([Cedula])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Vehiculo')
CREATE TABLE [dbo].[Vehiculo] (
    [Rfid]                              VARCHAR(100)        NOT NULL,
    [Placa]                             VARCHAR(10)         NOT NULL,
    [Transporte]                        VARCHAR(10)             NULL,
    [Revision_Tecnomecanica]            DATE                    NULL,
    [Seguro]                            VARCHAR(50)             NULL,
    [Tara]                              INT                 NOT NULL,
    [Capacidad]                         INT                 NOT NULL,
    [Categoria]                         VARCHAR(300)            NULL,
    [Id_Conductor]                      VARCHAR(30)             NULL,
    [Cif]                               VARCHAR(50)             NULL,
    [Id_Mina]                           VARCHAR(50)             NULL,
    [Patio]                             VARCHAR(50)             NULL,
    [Tope]                              VARCHAR(100)            NULL,
    PRIMARY KEY CLUSTERED ([Rfid])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Vehiculo_En_Transito')
CREATE TABLE [dbo].[Vehiculo_En_Transito] (
    [Id_Entrada]                        INT                 NOT NULL IDENTITY,
    [Id_Parque]                         INT                     NULL,
    [Transporte]                        VARCHAR(10)             NULL,
    [Ticket]                            VARCHAR(20)             NULL,
    [Matricula]                         VARCHAR(10)             NULL,
    [Vagon]                             VARCHAR(50)             NULL,
    [Fecha_Entrada]                     DATETIME                NULL,
    [Fecha_Salida]                      DATETIME                NULL,
    [Combustible]                       VARCHAR(50)             NULL,
    [Tipo_Movimiento]                   VARCHAR(20)             NULL,
    [Nombre]                            VARCHAR(200)            NULL,
    [Parva_Anterior]                    VARCHAR(50)             NULL,
    [Fecha_Fin_Parva]                   DATE                    NULL,
    [Patio]                             VARCHAR(100)            NULL,
    [Fecha_Inicio_Parva]                DATE                    NULL,
    [Muestras]                          VARCHAR(100)            NULL,
    [Nro_Bolsa]                         VARCHAR(50)             NULL,
    [Codigo_Partida]                    VARCHAR(10)             NULL,
    [Consecutivo_Vehiculo]              VARCHAR(50)             NULL,
    [Peso_Entrada]                      INT                     NULL,
    [Peso_Salida]                       INT                     NULL,
    [Peso_Neto]                         INT                     NULL,
    [Unidad]                            VARCHAR(5)              NULL,
    [Descripcion]                       VARCHAR(300)            NULL,
    [Ruta_Fotos]                        VARCHAR(MAX)            NULL,
    [Rfid]                              VARCHAR(100)            NULL,
    [Proceso_Manual]                    BIT                     NULL,
    [Usuario]                           VARCHAR(100)            NULL,
    [Vehiculo_Devuelto]                 BIT                     NULL,
    [Cif]                               VARCHAR(50)             NULL,
    [Id_Destino]                        VARCHAR(50)             NULL,
    [Id_Origen]                         VARCHAR(50)             NULL,
    [Estado]                            VARCHAR(50)             NULL,
    [Id_Por_Dia]                        INT                 NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Entrada])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Control_Acceso]
   ADD CONSTRAINT [Fk_Control_Acceso_Contrato]
        FOREIGN KEY ([Id_Contrato])
        REFERENCES [Contrato] ([Id_Contrato]),
    CONSTRAINT [Fk_Control_Acceso_Mina]
        FOREIGN KEY ([Id_Mina])
        REFERENCES [Mina] ([Id_Mina]),
    CONSTRAINT [Fk_Control_Acceso_Proveedor]
        FOREIGN KEY ([Cif_Proveedor])
        REFERENCES [Proveedor] ([Cif]),
    CONSTRAINT [Fk_Control_Acceso_Vehiculo]
        FOREIGN KEY ([Rfid])
        REFERENCES [Vehiculo] ([Rfid]);
/*
ALTER TABLE [Ficheros_Proveedor]
    ADD CONSTRAINT [Fk_Ficheros_Proveedor_Proveedor]
        FOREIGN KEY ([Cif])
        REFERENCES [Proveedor] ([Cif]);
*/
ALTER TABLE [Generador_Partida]
    ADD CONSTRAINT [Fk_Generador_Partida_Proveedor]
        FOREIGN KEY ([Cif_Proveedor])
        REFERENCES [Proveedor] ([Cif]),
    CONSTRAINT [Fk_Generador_Partida_Vehiculo]
        FOREIGN KEY ([Rfid])
        REFERENCES [Vehiculo] ([Rfid]);

ALTER TABLE [Mina]
    ADD CONSTRAINT [Fk_Mina_Titulo_Minero]
        FOREIGN KEY ([Id_Titulo_Minero])
        REFERENCES [Titulo_Minero] ([Id_Titulo]);

ALTER TABLE [Muestra]
    ADD CONSTRAINT [Fk_Muestra_Vehiculo]
        FOREIGN KEY ([Rfid])
        REFERENCES [Vehiculo] ([Rfid]);

ALTER TABLE [Registro_Entrada_Salida]
    ADD CONSTRAINT [Fk_Registro_Entrada_Salida_Parque]
        FOREIGN KEY ([Id_Parque])
        REFERENCES [Parque] ([Id_Parque]);

ALTER TABLE [Titulo_Minero]
    ADD CONSTRAINT [Fk_Titulo_Minero_Proveedor]
        FOREIGN KEY ([Cif_Proveedor])
        REFERENCES [Proveedor] ([Cif]);

ALTER TABLE [Vehiculo]
    ADD CONSTRAINT [Fk_Vehiculo_Conductor]
        FOREIGN KEY ([Id_Conductor])
        REFERENCES [Conductor] ([Identificacion]),
    CONSTRAINT [Fk_Vehiculo_Proveedor]
        FOREIGN KEY ([Cif])
        REFERENCES [Proveedor] ([Cif]);
