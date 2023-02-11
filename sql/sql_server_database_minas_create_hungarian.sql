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
    [IntIdProveedor]                    INT                 NOT NULL IDENTITY,
    [StrRfid]                           VARCHAR(50)         NOT NULL,
    [IntCodigoPartida]                  INT                 NOT NULL,
    [IntNumeroMuestra]                  INT                 NOT NULL,
    [IntEstadoPartida]                  INT                 NOT NULL,
    [DtFechaHoraEntrada]                DATETIME            NOT NULL,
    [FltPesoBruto]                      FLOAT               NOT NULL,
    [FltPesoNeto]                       FLOAT               NOT NULL,
    [StrTipoVehiculo]                   VARCHAR(20)         NOT NULL,
    [StrMssCodigoPartida]               VARCHAR(100)        NOT NULL,
    [DtMssFechaHoraTomaMuestra]         DATETIME            NOT NULL,
    PRIMARY KEY CLUSTERED ([IntIdProveedor])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Categoria')
CREATE TABLE [dbo].[Categoria] (
    [IntIdCategoria]                    INT                 NOT NULL IDENTITY,
    [StrTipoVehiculo]                   VARCHAR(50)             NULL,
    [FltPesoMaximo]                     FLOAT                   NULL,
    [FltTolerancia]                     FLOAT                   NULL,
    [StrDescripcion]                    VARCHAR(300)            NULL,
    [FltEjeSencillo]                    FLOAT                   NULL DEFAULT 0,
    [FltEjeTandem]                      FLOAT                   NULL DEFAULT 0,
    [FltEjeTridem]                      FLOAT                   NULL DEFAULT 0,
    [IntTotalEjes]                      INT                     NULL,
    PRIMARY KEY CLUSTERED ([IntIdCategoria])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'CierrePartida')
CREATE TABLE [dbo].[CierrePartida] (
    [IntConsecutivo]                    INT                 NOT NULL IDENTITY,
    [IntCodigoPartida]                  INT                     NULL,
    [StrCifProveedor]                   VARCHAR(50)             NULL,
    [IntCodigoVehiculo]                 INT                     NULL,
    [StrRfid]                           VARCHAR(100)            NULL,
    [IntPeso]                           INT                     NULL,
    [DtFecha]                           DATETIME                NULL,
    [StrEstado]                         VARCHAR(50)             NULL,
    [IntPesoEstimado]                   INT                     NULL,
    [StrTipo]                           VARCHAR(50)             NULL,
    PRIMARY KEY CLUSTERED ([IntConsecutivo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'CodigoOrigen')
CREATE TABLE [dbo].[CodigoOrigen] (
    [IntId]                             INT                 NOT NULL IDENTITY,
    [StrCodigo]                         VARCHAR(10)             NULL,
    PRIMARY KEY CLUSTERED ([IntId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Conductor')
CREATE TABLE [dbo].[Conductor] (
    [StrIdentificacion]                 VARCHAR(30)         NOT NULL,
    [StrNombreConductor]                VARCHAR(200)        NOT NULL,
    [DtFechaNacimiento]                 DATE                    NULL,
    [StrLicenciaConduccion]             VARCHAR(50)             NULL,
    [DtFechaVencimiento]                DATE                    NULL,
    [StrObservaciones]                  VARCHAR(200)            NULL,
    [StrTipoSancion]                    VARCHAR(100)            NULL,
    [DtFechaInicioSancion]              DATE                    NULL,
    [DtFechaFinalSancion]               DATE                    NULL,
    [StrDiasSancion]                    VARCHAR(20)             NULL,
    PRIMARY KEY CLUSTERED ([StrIdentificacion])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Configuracion')
CREATE TABLE [dbo].[Configuracion] (
    [IntId]                             INT                 NOT NULL IDENTITY,
    [StrTipo]                           NVARCHAR(50)            NULL,
    [StrIndicador]                      NVARCHAR(500)           NULL,
    [StrBaudios]                        NVARCHAR(50)            NULL,
    [StrBitsDatos]                      NVARCHAR(50)            NULL,
    [StrBitsParada]                     NVARCHAR(50)            NULL,
    [StrParidad]                        NVARCHAR(50)            NULL,
    [StrIp]                             NVARCHAR(50)            NULL,
    [StrPuerto]                         NVARCHAR(50)            NULL,
    [StrUsuario]                        NVARCHAR(50)            NULL,
    [StrContrasena]                     NVARCHAR(50)            NULL,
    [BitEstado]                         BIT                     NULL,
    PRIMARY KEY CLUSTERED ([IntId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ConsecutivoDiario')
CREATE TABLE [dbo].[ConsecutivoDiario] (
    [StrRfid]                           VARCHAR(50)         NOT NULL,
    [IntNroTiquete]                     INT                 NOT NULL,
    [IntConsecutivoDia]                 INT                 NOT NULL,
    PRIMARY KEY CLUSTERED ([StrRfid])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Contrato')
CREATE TABLE [dbo].[Contrato] (
    [IntIdContrato]                     INT                 NOT NULL IDENTITY,
    [StrIdParque]                       VARCHAR(30)         NOT NULL,
    [StrCentroProduccion]               VARCHAR(200)        NOT NULL,
    [StrCarburante]                     VARCHAR(200)        NOT NULL,
    [StrTipoAgrupacion]                 VARCHAR(200)            NULL,
    [BitPartidaMaestra]                 BIT                 NOT NULL,
    [IntTipoExistencia]                 INT                 NOT NULL,
    [StrDescripcion]                    VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([IntIdContrato])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ControlAcceso')
CREATE TABLE [dbo].[ControlAcceso] (
    [IntIdControl]                      INT                 NOT NULL IDENTITY,
    [IntIdContrato]                     INT                     NULL,
    [StrIdMina]                         VARCHAR(50)             NULL,
    [StrIdDestino]                      VARCHAR(50)             NULL,
    [StrRfid]                           VARCHAR(100)            NULL,
    [StrPlaca]                          VARCHAR(10)             NULL,
    [StrConductor]                      VARCHAR(200)            NULL,
    [StrCifProveedor]                   VARCHAR(50)             NULL,
    [DtFechaIngreso]                    DATETIME                NULL,
    [DtFechaSalida]                     DATETIME                NULL,
    [IntTopeMensual]                    INT                     NULL,
    [IntAcumulado]                      INT                     NULL,
    [DtFechaValidez]                    DATE                    NULL,
    [StrTipoTarjeta]                    VARCHAR(100)            NULL,
    PRIMARY KEY CLUSTERED ([IntIdControl])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Destino')
CREATE TABLE [dbo].[Destino] (
    [StrIdDestino]                      VARCHAR(50)         NOT NULL,
    [StrNombre]                         VARCHAR(100)            NULL,
    [StrTelefono]                       VARCHAR(20)             NULL,
    [StrDireccion]                      VARCHAR(200)            NULL,
    [StrObservaciones]                  VARCHAR(200)            NULL,
    [StrSeleccionado]                   VARCHAR(50)             NULL,
    PRIMARY KEY CLUSTERED ([StrIdDestino])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'FicherosProveedor')
CREATE TABLE [dbo].[FicherosProveedor] (
    [StrCif]                            VARCHAR(50)         NOT NULL,
    [StrNombre]                         VARCHAR(200)            NULL,
    [IntTopeMensual]                    INT                     NULL,
    [DtFechaHoraCarga]                  DATETIME                NULL,
    [StrIdUsuario]                      VARCHAR(20)             NULL,
    PRIMARY KEY CLUSTERED ([StrCif])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'GeneradorPartida')
CREATE TABLE [dbo].[GeneradorPartida] (
    [IntConsecutivo]                    INT                 NOT NULL IDENTITY,
    [IntCodigoPartida]                  INT                     NULL,
    [StrCifProveedor]                   VARCHAR(50)             NULL,
    [IntCodigoVehiculo]                 INT                     NULL,
    [StrRfid]                           VARCHAR(100)            NULL,
    [IntPeso]                           INT                     NULL,
    [DtFecha]                           DATETIME                NULL,
    [StrEstado]                         VARCHAR(50)             NULL,
    [IntPesoEstimado]                   INT                     NULL,
    [StrTipo]                           VARCHAR(50)             NULL,
    PRIMARY KEY CLUSTERED ([IntConsecutivo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Indicador')
CREATE TABLE [dbo].[Indicador] (
    [StrCodigo]                         NVARCHAR(50)        NOT NULL,
    [StrNombre]                         VARCHAR(500)            NULL,
    [StrTamanoTrama]                    VARCHAR(10)             NULL,
    [StrPosicionInicial]                VARCHAR(10)             NULL,
    [StrTotalDatosPeso]                 VARCHAR(10)             NULL,
    [StrCaracterFinTrama]               VARCHAR(10)             NULL,
    [StrCaracterInicioTrama]            VARCHAR(10)             NULL,
    PRIMARY KEY CLUSTERED ([StrCodigo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Mina')
CREATE TABLE [dbo].[Mina] (
    [StrIdMina]                         VARCHAR(50)         NOT NULL,
    [StrNombre]                         VARCHAR(200)            NULL,
    [StrLocalidad]                      VARCHAR(100)            NULL,
    [StrTelefono]                       VARCHAR(30)             NULL,
    [StrIdTituloMinero]                 VARCHAR(50)             NULL,
    [StrObservaciones]                  VARCHAR(200)            NULL,
    [StrProducto]                       VARCHAR(100)            NULL,
    [StrTicket]                         VARCHAR(50)             NULL,
    PRIMARY KEY CLUSTERED ([StrIdMina])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Muestra')
CREATE TABLE [dbo].[Muestra] (
    [IntIdMuestra]                      INT                 NOT NULL IDENTITY,
    [StrRfid]                           VARCHAR(100)            NULL,
    [StrPartida]                        VARCHAR(10)             NULL,
    [StrCamion]                         VARCHAR(10)             NULL,
    [DtFechaHora]                       DATETIME                NULL,
    [StrObservaciones]                  VARCHAR(300)            NULL,
    PRIMARY KEY CLUSTERED ([IntIdMuestra])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Origen')
CREATE TABLE [dbo].[Origen] (
    [StrIdOrigen]                       VARCHAR(50)         NOT NULL,
    [StrNombre]                         VARCHAR(100)            NULL,
    [StrCodigoRfid]                     VARCHAR(20)             NULL,
    [StrDireccion]                      VARCHAR(200)            NULL,
    [StrObservaciones]                  VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([StrIdOrigen])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Parque')
CREATE TABLE [dbo].[Parque] (
    [IntIdParque]                       INT                 NOT NULL IDENTITY,
    [StrNombreParque]                   VARCHAR(100)        NOT NULL,
    [StrObservaciones]                  VARCHAR(200)            NULL,
    [StrUbicacion]                      VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([IntIdParque])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Producto')
CREATE TABLE [dbo].[Producto] (
    [IntIdProducto]                     INT                 NOT NULL IDENTITY,
    [StrProducto]                       VARCHAR(100)            NULL,
    PRIMARY KEY CLUSTERED ([IntIdProducto])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Proveedor')
CREATE TABLE [dbo].[Proveedor] (
    [StrCif]                            VARCHAR(50)         NOT NULL,
    [StrNombre]                         VARCHAR(200)        NOT NULL,
    [StrDireccion]                      VARCHAR(200)            NULL,
    [StrPais]                           VARCHAR(100)            NULL,
    [StrPoblacion]                      VARCHAR(100)            NULL,
    [StrCodigoProveedor]                VARCHAR(50)             NULL,
    [StrCorreoElectronico]              VARCHAR(200)            NULL,
    [StrPatio]                          VARCHAR(20)             NULL,
    [IntTopeMensual]                    INT                     NULL,
    [IntAcumulado]                      INT                     NULL,
    [StrObservaciones]                  VARCHAR(300)            NULL,
    [IntTopeOpcional]                   INT                     NULL,
    [IntTopeAdicional]                  INT                     NULL,
    [IntTopeSpot]                       INT                     NULL,
    [IntTopeOtros]                      INT                     NULL,
    PRIMARY KEY CLUSTERED ([StrCif])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'RegistroEntradaSalida')
CREATE TABLE [dbo].[RegistroEntradaSalida] (
    [IntIdEntrada]                      INT                 NOT NULL IDENTITY,
    [IntIdParque]                       INT                     NULL,
    [StrTransporte]                     VARCHAR(10)             NULL,
    [StrTicket]                         VARCHAR(20)             NULL,
    [StrMatricula]                      VARCHAR(10)             NULL,
    [StrVagon]                          VARCHAR(50)             NULL,
    [DtFechaEntrada]                    DATETIME                NULL,
    [DtFechaSalida]                     DATETIME                NULL,
    [StrCombustible]                    VARCHAR(50)             NULL,
    [StrTipoMovimiento]                 VARCHAR(20)             NULL,
    [StrNombre]                         VARCHAR(200)            NULL,
    [StrParvaAnterior]                  VARCHAR(50)             NULL,
    [DtFechaFinParva]                   DATE                    NULL,
    [StrPatio]                          VARCHAR(100)            NULL,
    [DtFechaInicioParva]                DATE                    NULL,
    [StrMuestras]                       VARCHAR(100)            NULL,
    [StrNroBolsa]                       VARCHAR(50)             NULL,
    [StrCodigoPartida]                  VARCHAR(10)             NULL,
    [StrConsecutivoVehiculo]            VARCHAR(50)             NULL,
    [IntPesoEntrada]                    INT                     NULL,
    [IntPesoSalida]                     INT                     NULL,
    [IntPesoNeto]                       INT                     NULL,
    [StrUnidad]                         VARCHAR(5)              NULL,
    [StrDescripcion]                    VARCHAR(300)            NULL,
    [TxtRutaFotos]                      VARCHAR(MAX)            NULL,
    [StrRfid]                           VARCHAR(100)            NULL,
    [BitProcesoManual]                  BIT                     NULL,
    [StrUsuario]                        VARCHAR(100)            NULL,
    [BitVehiculoDevuelto]               BIT                     NULL,
    [StrCif]                            VARCHAR(50)             NULL,
    [StrIdDestino]                      VARCHAR(50)             NULL,
    [StrIdOrigen]                       VARCHAR(50)             NULL,
    [StrEstado]                         VARCHAR(50)             NULL,
    [IntIdPorDia]                       INT                     NULL,
    PRIMARY KEY CLUSTERED ([IntIdEntrada])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Sancion')
CREATE TABLE [dbo].[Sancion] (
    [IntNumero]                         INT                 NOT NULL IDENTITY,
    [StrItem]                           VARCHAR(200)            NULL,
    [BitSancionConductor]               BIT                     NULL,
    [BitSancionVehiculo]                BIT                     NULL,
    [StrTiempo]                         VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([IntNumero])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Temporal')
CREATE TABLE [dbo].[Temporal] (
    [IntIdTemporal]                     INT                 NOT NULL IDENTITY,
    [StrPlaca]                          VARCHAR(10)             NULL,
    [StrRfid]                           VARCHAR(50)             NULL,
    [StrProveedor]                      VARCHAR(100)            NULL,
    [StrTope]                           VARCHAR(20)             NULL,
    [IntAcumulado]                      INT                     NULL,
    [DtFechaEntrada]                    DATETIME                NULL,
    [DtFechaSalida]                     DATETIME                NULL,
    [StrEstado]                         VARCHAR(500)            NULL,
    PRIMARY KEY CLUSTERED ([IntIdTemporal])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TituloMinero')
CREATE TABLE [dbo].[TituloMinero] (
    [StrIdTitulo]                       VARCHAR(50)         NOT NULL,
    [StrNombre]                         VARCHAR(200)        NOT NULL,
    [StrLocalidad]                      VARCHAR(100)            NULL,
    [StrTelefono]                       VARCHAR(50)             NULL,
    [StrCifProveedor]                   VARCHAR(50)             NULL,
    [StrObservaciones]                  VARCHAR(200)            NULL,
    PRIMARY KEY CLUSTERED ([StrIdTitulo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Usuario')
CREATE TABLE [dbo].[Usuario] (
    [IntCedula]                         INT                 NOT NULL IDENTITY,
    [StrNombre]                         VARCHAR(100)        NOT NULL,
    [StrApellido]                       VARCHAR(100)        NOT NULL,
    [StrEmail]                          NVARCHAR(100)           NULL,
    [StrTelefono]                       NVARCHAR(50)            NULL,
    [CrRh]                              NCHAR(10)               NULL,
    [StrSeudonimo]                      VARCHAR(50)             NULL,
    [StrTipo]                           VARCHAR(100)            NULL,
    [StrCargo]                          NVARCHAR(50)            NULL,
    [TxtContrasena]                     VARCHAR(MAX)            NULL,
    [BtFoto]                            VARCHAR(MAX)            NULL,
    PRIMARY KEY CLUSTERED ([IntCedula])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Vehiculo')
CREATE TABLE [dbo].[Vehiculo] (
    [StrRfid]                           VARCHAR(100)        NOT NULL,
    [StrPlaca]                          VARCHAR(10)         NOT NULL,
    [StrTransporte]                     VARCHAR(10)             NULL,
    [DtRevisionTecnomecanica]           DATE                    NULL,
    [StrSeguro]                         VARCHAR(50)             NULL,
    [IntTara]                           INT                 NOT NULL,
    [IntCapacidad]                      INT                 NOT NULL,
    [StrCategoria]                      VARCHAR(300)            NULL,
    [StrIdConductor]                    VARCHAR(30)             NULL,
    [StrCif]                            VARCHAR(50)             NULL,
    [StrIdMina]                         VARCHAR(50)             NULL,
    [StrPatio]                          VARCHAR(50)             NULL,
    [StrTope]                           VARCHAR(100)            NULL,
    PRIMARY KEY CLUSTERED ([StrRfid])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'VehiculoEnTransito')
CREATE TABLE [dbo].[VehiculoEnTransito] (
    [IntIdEntrada]                      INT                 NOT NULL IDENTITY,
    [IntIdParque]                       INT                     NULL,
    [StrTransporte]                     VARCHAR(10)             NULL,
    [StrTicket]                         VARCHAR(20)             NULL,
    [StrMatricula]                      VARCHAR(10)             NULL,
    [StrVagon]                          VARCHAR(50)             NULL,
    [DtFechaEntrada]                    DATETIME                NULL,
    [DtFechaSalida]                     DATETIME                NULL,
    [StrCombustible]                    VARCHAR(50)             NULL,
    [StrTipoMovimiento]                 VARCHAR(20)             NULL,
    [StrNombre]                         VARCHAR(200)            NULL,
    [StrParvaAnterior]                  VARCHAR(50)             NULL,
    [DtFechaFinParva]                   DATE                    NULL,
    [StrPatio]                          VARCHAR(100)            NULL,
    [DtFechaInicioParva]                DATE                    NULL,
    [StrMuestras]                       VARCHAR(100)            NULL,
    [StrNroBolsa]                       VARCHAR(50)             NULL,
    [StrCodigoPartida]                  VARCHAR(10)             NULL,
    [StrConsecutivoVehiculo]            VARCHAR(50)             NULL,
    [IntPesoEntrada]                    INT                     NULL,
    [IntPesoSalida]                     INT                     NULL,
    [IntPesoNeto]                       INT                     NULL,
    [StrUnidad]                         VARCHAR(5)              NULL,
    [StrDescripcion]                    VARCHAR(300)            NULL,
    [TxtRutaFotos]                      VARCHAR(MAX)            NULL,
    [StrRfid]                           VARCHAR(100)            NULL,
    [BitProcesoManual]                  BIT                     NULL,
    [StrUsuario]                        VARCHAR(100)            NULL,
    [BitVehiculoDevuelto]               BIT                     NULL,
    [StrCif]                            VARCHAR(50)             NULL,
    [StrIdDestino]                      VARCHAR(50)             NULL,
    [StrIdOrigen]                       VARCHAR(50)             NULL,
    [StrEstado]                         VARCHAR(50)             NULL,
    [IntIdPorDia]                       INT                 NOT NULL,
    PRIMARY KEY CLUSTERED ([IntIdEntrada])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [ControlAcceso]
   ADD CONSTRAINT [FkControlAccesoContrato]
        FOREIGN KEY ([IntIdContrato])
        REFERENCES [Contrato] ([IntIdContrato]),
    CONSTRAINT [FkControlAccesoMina]
        FOREIGN KEY ([StrIdMina])
        REFERENCES [Mina] ([StrIdMina]),
    CONSTRAINT [FkControlAccesoProveedor]
        FOREIGN KEY ([StrCifProveedor])
        REFERENCES [Proveedor] ([StrCif]),
    CONSTRAINT [FkControlAccesoVehiculo]
        FOREIGN KEY ([StrRfid])
        REFERENCES [Vehiculo] ([StrRfid]);
/*
ALTER TABLE [FicherosProveedor]
    ADD CONSTRAINT [FkFicherosProveedorProveedor]
        FOREIGN KEY ([StrCif])
        REFERENCES [Proveedor] ([StrCif]);
*/
ALTER TABLE [GeneradorPartida]
    ADD CONSTRAINT [FkGeneradorPartidaProveedor]
        FOREIGN KEY ([StrCifProveedor])
        REFERENCES [Proveedor] ([StrCif]),
    CONSTRAINT [FkGeneradorPartidaVehiculo]
        FOREIGN KEY ([StrRfid])
        REFERENCES [Vehiculo] ([StrRfid]);

ALTER TABLE [Mina]
    ADD CONSTRAINT [FkMinaTituloMinero]
        FOREIGN KEY ([StrIdTituloMinero])
        REFERENCES [TituloMinero] ([StrIdTitulo]);

ALTER TABLE [Muestra]
    ADD CONSTRAINT [FkMuestraVehiculo]
        FOREIGN KEY ([StrRfid])
        REFERENCES [Vehiculo] ([StrRfid]);

ALTER TABLE [RegistroEntradaSalida]
    ADD CONSTRAINT [FkRegistroEntradaSalidaParque]
        FOREIGN KEY ([IntIdParque])
        REFERENCES [Parque] ([IntIdParque]);

ALTER TABLE [TituloMinero]
    ADD CONSTRAINT [FkTituloMineroProveedor]
        FOREIGN KEY ([StrCifProveedor])
        REFERENCES [Proveedor] ([StrCif]);

ALTER TABLE [Vehiculo]
    ADD CONSTRAINT [FkVehiculoConductor]
        FOREIGN KEY ([StrIdConductor])
        REFERENCES [Conductor] ([StrIdentificacion]),
    CONSTRAINT [FkVehiculoProveedor]
        FOREIGN KEY ([StrCif])
        REFERENCES [Proveedor] ([StrCif]);
