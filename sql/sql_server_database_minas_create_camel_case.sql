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
    [IdProveedor]                       INT                 NOT NULL IDENTITY,
    [Rfid]                              VARCHAR(50)         NOT NULL,
    [CodigoPartida]                     INT                 NOT NULL,
    [NumeroMuestra]                     INT                 NOT NULL,
    [EstadoPartida]                     INT                 NOT NULL,
    [FechaHoraEntrada]                  DATETIME            NOT NULL,
    [PesoBruto]                         FLOAT               NOT NULL,
    [PesoNeto]                          FLOAT               NOT NULL,
    [TipoVehiculo]                      VARCHAR(20)         NOT NULL,
    [MssCodigoPartida]                  VARCHAR(100)        NOT NULL,
    [MssFechaHoraTomaMuestra]           DATETIME            NOT NULL,
    PRIMARY KEY CLUSTERED ([IdProveedor])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Categoria')
CREATE TABLE [dbo].[Categoria] (
    [IdCategoria]                       INT                 NOT NULL IDENTITY,
    [TipoVehiculo]                      VARCHAR(50)             NULL,
    [PesoMaximo]                        FLOAT                   NULL,
    [Tolerancia]                        FLOAT                   NULL,
    [Descripcion]                       VARCHAR(300)            NULL,
    [EjeSencillo]                       FLOAT                   NULL DEFAULT 0,
    [EjeTandem]                         FLOAT                   NULL DEFAULT 0,
    [EjeTridem]                         FLOAT                   NULL DEFAULT 0,
    [TotalEjes]                         INT                     NULL,
    PRIMARY KEY CLUSTERED ([IdCategoria])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'CierrePartida')
CREATE TABLE [dbo].[CierrePartida] (
    [Consecutivo]                       INT                 NOT NULL IDENTITY,
    [CodigoPartida]                     INT                     NULL,
    [CifProveedor]                      VARCHAR(50)             NULL,
    [CodigoVehiculo]                    INT                     NULL,
    [Rfid]                              VARCHAR(100)            NULL,
    [Peso]                              INT                     NULL,
    [Fecha]                             DATETIME                NULL,
    [Estado]                            VARCHAR(50)             NULL,
    [PesoEstimado]                      INT                     NULL,
    [Tipo]                              VARCHAR(50)             NULL,
    PRIMARY KEY CLUSTERED ([Consecutivo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'CodigoOrigen')
CREATE TABLE [dbo].[CodigoOrigen] (
    [Id]                                INT                 NOT NULL IDENTITY,
    [Codigo]                            VARCHAR(10)             NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Conductor')
CREATE TABLE [dbo].[Conductor] (
    [Identificacion]                    VARCHAR(30)         NOT NULL,
    [NombreConductor]                   VARCHAR(200)        NOT NULL,
    [FechaNacimiento]                   DATE                    NULL,
    [LicenciaConduccion]                VARCHAR(50)             NULL,
    [FechaVencimiento]                  DATE                    NULL,
    [Observaciones]                     VARCHAR(200)            NULL,
    [TipoSancion]                       VARCHAR(100)            NULL,
    [FechaInicioSancion]                DATE                    NULL,
    [FechaFinalSancion]                 DATE                    NULL,
    [DiasSancion]                       VARCHAR(20)             NULL,
    PRIMARY KEY CLUSTERED ([Identificacion])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Configuracion')
CREATE TABLE [dbo].[Configuracion] (
    [Id]                                INT                 NOT NULL IDENTITY,
    [Tipo]                              NVARCHAR(50)            NULL,
    [Indicador]                         NVARCHAR(500)           NULL,
    [Baudios]                           NVARCHAR(50)            NULL,
    [BitsDatos]                         NVARCHAR(50)            NULL,
    [BitsParada]                        NVARCHAR(50)            NULL,
    [Paridad]                           NVARCHAR(50)            NULL,
    [Ip]                                NVARCHAR(50)            NULL,
    [Puerto]                            NVARCHAR(50)            NULL,
    [Usuario]                           NVARCHAR(50)            NULL,
    [Contrasena]                        NVARCHAR(50)            NULL,
    [Estado]                            BIT                     NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ConsecutivoDiario')
CREATE TABLE [dbo].[ConsecutivoDiario] (
    [Rfid]                              VARCHAR(50)         NOT NULL,
    [NroTiquete]                        INT                 NOT NULL,
    [ConsecutivoDia]                    INT                 NOT NULL,
    PRIMARY KEY CLUSTERED ([Rfid])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Contrato')
CREATE TABLE [dbo].[Contrato] (
    [IdContrato]                        INT                 NOT NULL IDENTITY,
    [IdParque]                          VARCHAR(30)         NOT NULL,
    [CentroProduccion]                  VARCHAR(200)        NOT NULL,
    [Carburante]                        VARCHAR(200)        NOT NULL,
    [TipoAgrupacion]                    VARCHAR(200)            NULL,
    [PartidaMaestra]                    BIT                 NOT NULL,
    [TipoExistencia]                    INT                 NOT NULL,
    [Descripcion]                       VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([IdContrato])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ControlAcceso')
CREATE TABLE [dbo].[ControlAcceso] (
    [IdControl]                         INT                 NOT NULL IDENTITY,
    [IdContrato]                        INT                     NULL,
    [IdMina]                            VARCHAR(50)             NULL,
    [IdDestino]                         VARCHAR(50)             NULL,
    [Rfid]                              VARCHAR(100)            NULL,
    [Placa]                             VARCHAR(10)             NULL,
    [Conductor]                         VARCHAR(200)            NULL,
    [CifProveedor]                      VARCHAR(50)             NULL,
    [FechaIngreso]                      DATETIME                NULL,
    [FechaSalida]                       DATETIME                NULL,
    [TopeMensual]                       INT                     NULL,
    [Acumulado]                         INT                     NULL,
    [FechaValidez]                      DATE                    NULL,
    [TipoTarjeta]                       VARCHAR(100)            NULL,
    PRIMARY KEY CLUSTERED ([IdControl])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Destino')
CREATE TABLE [dbo].[Destino] (
    [IdDestino]                         VARCHAR(50)         NOT NULL,
    [Nombre]                            VARCHAR(100)            NULL,
    [Telefono]                          VARCHAR(20)             NULL,
    [Direccion]                         VARCHAR(200)            NULL,
    [Observaciones]                     VARCHAR(200)            NULL,
    [Seleccionado]                      VARCHAR(50)             NULL,
    PRIMARY KEY CLUSTERED ([IdDestino])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'FicherosProveedor')
CREATE TABLE [dbo].[FicherosProveedor] (
    [Cif]                               VARCHAR(50)         NOT NULL,
    [Nombre]                            VARCHAR(200)            NULL,
    [TopeMensual]                       INT                     NULL,
    [FechaHoraCarga]                    DATETIME                NULL,
    [IdUsuario]                         VARCHAR(20)             NULL,
    PRIMARY KEY CLUSTERED ([Cif])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'GeneradorPartida')
CREATE TABLE [dbo].[GeneradorPartida] (
    [Consecutivo]                       INT                 NOT NULL IDENTITY,
    [CodigoPartida]                     INT                     NULL,
    [CifProveedor]                      VARCHAR(50)             NULL,
    [CodigoVehiculo]                    INT                     NULL,
    [Rfid]                              VARCHAR(100)            NULL,
    [Peso]                              INT                     NULL,
    [Fecha]                             DATETIME                NULL,
    [Estado]                            VARCHAR(50)             NULL,
    [PesoEstimado]                      INT                     NULL,
    [Tipo]                              VARCHAR(50)             NULL,
    PRIMARY KEY CLUSTERED ([Consecutivo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Indicador')
CREATE TABLE [dbo].[Indicador] (
    [Codigo]                            NVARCHAR(50)        NOT NULL,
    [Nombre]                            VARCHAR(500)            NULL,
    [TamanoTrama]                       VARCHAR(10)             NULL,
    [PosicionInicial]                   VARCHAR(10)             NULL,
    [TotalDatosPeso]                    VARCHAR(10)             NULL,
    [CaracterFinTrama]                  VARCHAR(10)             NULL,
    [CaracterInicioTrama]               VARCHAR(10)             NULL,
    PRIMARY KEY CLUSTERED ([Codigo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Mina')
CREATE TABLE [dbo].[Mina] (
    [IdMina]                            VARCHAR(50)         NOT NULL,
    [Nombre]                            VARCHAR(200)            NULL,
    [Localidad]                         VARCHAR(100)            NULL,
    [Telefono]                          VARCHAR(30)             NULL,
    [IdTituloMinero]                    VARCHAR(50)             NULL,
    [Observaciones]                     VARCHAR(200)            NULL,
    [Producto]                          VARCHAR(100)            NULL,
    [Ticket]                            VARCHAR(50)             NULL,
    PRIMARY KEY CLUSTERED ([IdMina])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Muestra')
CREATE TABLE [dbo].[Muestra] (
    [IdMuestra]                         INT                 NOT NULL IDENTITY,
    [Rfid]                              VARCHAR(100)            NULL,
    [Partida]                           VARCHAR(10)             NULL,
    [Camion]                            VARCHAR(10)             NULL,
    [FechaHora]                         DATETIME                NULL,
    [Observaciones]                     VARCHAR(300)            NULL,
    PRIMARY KEY CLUSTERED ([IdMuestra])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Origen')
CREATE TABLE [dbo].[Origen] (
    [IdOrigen]                          VARCHAR(50)         NOT NULL,
    [Nombre]                            VARCHAR(100)            NULL,
    [CodigoRfid]                        VARCHAR(20)             NULL,
    [Direccion]                         VARCHAR(200)            NULL,
    [Observaciones]                     VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([IdOrigen])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Parque')
CREATE TABLE [dbo].[Parque] (
    [IdParque]                          INT                 NOT NULL IDENTITY,
    [NombreParque]                      VARCHAR(100)        NOT NULL,
    [Observaciones]                     VARCHAR(200)            NULL,
    [Ubicacion]                         VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([IdParque])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Producto')
CREATE TABLE [dbo].[Producto] (
    [IdProducto]                        INT                 NOT NULL IDENTITY,
    [Producto]                          VARCHAR(100)            NULL,
    PRIMARY KEY CLUSTERED ([IdProducto])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Proveedor')
CREATE TABLE [dbo].[Proveedor] (
    [Cif]                               VARCHAR(50)         NOT NULL,
    [Nombre]                            VARCHAR(200)        NOT NULL,
    [Direccion]                         VARCHAR(200)            NULL,
    [Pais]                              VARCHAR(100)            NULL,
    [Poblacion]                         VARCHAR(100)            NULL,
    [CodigoProveedor]                   VARCHAR(50)             NULL,
    [CorreoElectronico]                 VARCHAR(200)            NULL,
    [Patio]                             VARCHAR(20)             NULL,
    [TopeMensual]                       INT                     NULL,
    [Acumulado]                         INT                     NULL,
    [Observaciones]                     VARCHAR(300)            NULL,
    [TopeOpcional]                      INT                     NULL,
    [TopeAdicional]                     INT                     NULL,
    [TopeSpot]                          INT                     NULL,
    [TopeOtros]                         INT                     NULL,
    PRIMARY KEY CLUSTERED ([Cif])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'RegistroEntradaSalida')
CREATE TABLE [dbo].[RegistroEntradaSalida] (
    [IdEntrada]                         INT                 NOT NULL IDENTITY,
    [IdParque]                          INT                     NULL,
    [Transporte]                        VARCHAR(10)             NULL,
    [Ticket]                            VARCHAR(20)             NULL,
    [Matricula]                         VARCHAR(10)             NULL,
    [Vagon]                             VARCHAR(50)             NULL,
    [FechaEntrada]                      DATETIME                NULL,
    [FechaSalida]                       DATETIME                NULL,
    [Combustible]                       VARCHAR(50)             NULL,
    [TipoMovimiento]                    VARCHAR(20)             NULL,
    [Nombre]                            VARCHAR(200)            NULL,
    [ParvaAnterior]                     VARCHAR(50)             NULL,
    [FechaFinParva]                     DATE                    NULL,
    [Patio]                             VARCHAR(100)            NULL,
    [FechaInicioParva]                  DATE                    NULL,
    [Muestras]                          VARCHAR(100)            NULL,
    [NroBolsa]                          VARCHAR(50)             NULL,
    [CodigoPartida]                     VARCHAR(10)             NULL,
    [ConsecutivoVehiculo]               VARCHAR(50)             NULL,
    [PesoEntrada]                       INT                     NULL,
    [PesoSalida]                        INT                     NULL,
    [PesoNeto]                          INT                     NULL,
    [Unidad]                            VARCHAR(5)              NULL,
    [Descripcion]                       VARCHAR(300)            NULL,
    [RutaFotos]                         VARCHAR(MAX)            NULL,
    [Rfid]                              VARCHAR(100)            NULL,
    [ProcesoManual]                     BIT                     NULL,
    [Usuario]                           VARCHAR(100)            NULL,
    [VehiculoDevuelto]                  BIT                     NULL,
    [Cif]                               VARCHAR(50)             NULL,
    [IdDestino]                         VARCHAR(50)             NULL,
    [IdOrigen]                          VARCHAR(50)             NULL,
    [Estado]                            VARCHAR(50)             NULL,
    [IdPorDia]                          INT                     NULL,
    PRIMARY KEY CLUSTERED ([IdEntrada])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Sancion')
CREATE TABLE [dbo].[Sancion] (
    [Numero]                            INT                 NOT NULL IDENTITY,
    [Item]                              VARCHAR(200)            NULL,
    [SancionConductor]                  BIT                     NULL,
    [SancionVehiculo]                   BIT                     NULL,
    [Tiempo]                            VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([Numero])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Temporal')
CREATE TABLE [dbo].[Temporal] (
    [IdTemporal]                        INT                 NOT NULL IDENTITY,
    [Placa]                             VARCHAR(10)             NULL,
    [Rfid]                              VARCHAR(50)             NULL,
    [Proveedor]                         VARCHAR(100)            NULL,
    [Tope]                              VARCHAR(20)             NULL,
    [Acumulado]                         INT                     NULL,
    [FechaEntrada]                      DATETIME                NULL,
    [FechaSalida]                       DATETIME                NULL,
    [Estado]                            VARCHAR(500)            NULL,
    PRIMARY KEY CLUSTERED ([IdTemporal])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TituloMinero')
CREATE TABLE [dbo].[TituloMinero] (
    [IdTitulo]                          VARCHAR(50)         NOT NULL,
    [Nombre]                            VARCHAR(200)        NOT NULL,
    [Localidad]                         VARCHAR(100)            NULL,
    [Telefono]                          VARCHAR(50)             NULL,
    [CifProveedor]                      VARCHAR(50)             NULL,
    [Observaciones]                     VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([IdTitulo])
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
    [RevisionTecnomecanica]             DATE                    NULL,
    [Seguro]                            VARCHAR(50)             NULL,
    [Tara]                              INT                 NOT NULL,
    [Capacidad]                         INT                 NOT NULL,
    [Categoria]                         VARCHAR(300)            NULL,
    [IdConductor]                       VARCHAR(30)             NULL,
    [Cif]                               VARCHAR(50)             NULL,
    [IdMina]                            VARCHAR(50)             NULL,
    [Patio]                             VARCHAR(50)             NULL,
    [Tope]                              VARCHAR(100)            NULL,
    PRIMARY KEY CLUSTERED ([Rfid])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'VehiculoEnTransito')
CREATE TABLE [dbo].[VehiculoEnTransito] (
    [IdEntrada]                         INT                 NOT NULL IDENTITY,
    [IdParque]                          INT                     NULL,
    [Transporte]                        VARCHAR(10)             NULL,
    [Ticket]                            VARCHAR(20)             NULL,
    [Matricula]                         VARCHAR(10)             NULL,
    [Vagon]                             VARCHAR(50)             NULL,
    [FechaEntrada]                      DATETIME                NULL,
    [FechaSalida]                       DATETIME                NULL,
    [Combustible]                       VARCHAR(50)             NULL,
    [TipoMovimiento]                    VARCHAR(20)             NULL,
    [Nombre]                            VARCHAR(200)            NULL,
    [ParvaAnterior]                     VARCHAR(50)             NULL,
    [FechaFinParva]                     DATE                    NULL,
    [Patio]                             VARCHAR(100)            NULL,
    [FechaInicioParva]                  DATE                    NULL,
    [Muestras]                          VARCHAR(100)            NULL,
    [NroBolsa]                          VARCHAR(50)             NULL,
    [CodigoPartida]                     VARCHAR(10)             NULL,
    [ConsecutivoVehiculo]               VARCHAR(50)             NULL,
    [PesoEntrada]                       INT                     NULL,
    [PesoSalida]                        INT                     NULL,
    [PesoNeto]                          INT                     NULL,
    [Unidad]                            VARCHAR(5)              NULL,
    [Descripcion]                       VARCHAR(300)            NULL,
    [RutaFotos]                         VARCHAR(MAX)            NULL,
    [Rfid]                              VARCHAR(100)            NULL,
    [ProcesoManual]                     BIT                     NULL,
    [Usuario]                           VARCHAR(100)            NULL,
    [VehiculoDevuelto]                  BIT                     NULL,
    [Cif]                               VARCHAR(50)             NULL,
    [IdDestino]                         VARCHAR(50)             NULL,
    [IdOrigen]                          VARCHAR(50)             NULL,
    [Estado]                            VARCHAR(50)             NULL,
    [IdPorDia]                          INT                 NOT NULL,
    PRIMARY KEY CLUSTERED ([IdEntrada])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [ControlAcceso]
   ADD CONSTRAINT [FkControlAccesoContrato]
        FOREIGN KEY ([IdContrato])
        REFERENCES [Contrato] ([IdContrato]),
    CONSTRAINT [FkControlAccesoMina]
        FOREIGN KEY ([IdMina])
        REFERENCES [Mina] ([IdMina]),
    CONSTRAINT [FkControlAccesoProveedor]
        FOREIGN KEY ([CifProveedor])
        REFERENCES [Proveedor] ([Cif]),
    CONSTRAINT [FkControlAccesoVehiculo]
        FOREIGN KEY ([Rfid])
        REFERENCES [Vehiculo] ([Rfid]);
/*
ALTER TABLE [FicherosProveedor]
    ADD CONSTRAINT [FkFicherosProveedorProveedor]
        FOREIGN KEY ([Cif])
        REFERENCES [Proveedor] ([Cif]);
*/
ALTER TABLE [GeneradorPartida]
    ADD CONSTRAINT [FkGeneradorPartidaProveedor]
        FOREIGN KEY ([CifProveedor])
        REFERENCES [Proveedor] ([Cif]),
    CONSTRAINT [FkGeneradorPartidaVehiculo]
        FOREIGN KEY ([Rfid])
        REFERENCES [Vehiculo] ([Rfid]);

ALTER TABLE [Mina]
    ADD CONSTRAINT [FkMinaTituloMinero]
        FOREIGN KEY ([IdTituloMinero])
        REFERENCES [TituloMinero] ([IdTitulo]);

ALTER TABLE [Muestra]
    ADD CONSTRAINT [FkMuestraVehiculo]
        FOREIGN KEY ([Rfid])
        REFERENCES [Vehiculo] ([Rfid]);

ALTER TABLE [RegistroEntradaSalida]
    ADD CONSTRAINT [FkRegistroEntradaSalidaParque]
        FOREIGN KEY ([IdParque])
        REFERENCES [Parque] ([IdParque]);

ALTER TABLE [TituloMinero]
    ADD CONSTRAINT [FkTituloMineroProveedor]
        FOREIGN KEY ([CifProveedor])
        REFERENCES [Proveedor] ([Cif]);

ALTER TABLE [Vehiculo]
    ADD CONSTRAINT [FkVehiculoConductor]
        FOREIGN KEY ([IdConductor])
        REFERENCES [Conductor] ([Identificacion]),
    CONSTRAINT [FkVehiculoProveedor]
        FOREIGN KEY ([Cif])
        REFERENCES [Proveedor] ([Cif]);
