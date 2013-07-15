-- Change the database here
USE [START_SQLBD]
GO

--------------------------------------------------
PRINT ('Creating store procedure for [Monedas]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Monedas_Insertar]'))
DROP PROCEDURE [dbo].[SP_Monedas_Insertar]
GO

CREATE PROCEDURE SP_Monedas_Insertar
 (
  @pmon_id uniqueidentifier,
  @pmon_nombre varchar(50),
  @pmon_simbolo varchar(50),
  @pmon_cambio_dolar uniqueidentifier
 )

AS

 INSERT INTO [Monedas]
  (
   [mon_id],
   [mon_nombre],
   [mon_simbolo],
   [mon_cambio_dolar]
  )
 VALUES
  (
   @pmon_id,
   @pmon_nombre,
   @pmon_simbolo,
   @pmon_cambio_dolar
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Monedas_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Monedas_Actualizar]
GO

CREATE PROCEDURE SP_Monedas_Actualizar
 (
  @pmon_id uniqueidentifier,
  @pmon_nombre varchar(50),
  @pmon_simbolo varchar(50),
  @pmon_cambio_dolar uniqueidentifier
 )

AS

 UPDATE
  [Monedas]
 SET
  [mon_id] = @pmon_id,
  [mon_nombre] = @pmon_nombre,
  [mon_simbolo] = @pmon_simbolo,
  [mon_cambio_dolar] = @pmon_cambio_dolar
 WHERE
  [mon_id] = @pmon_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Monedas_Borrar]'))
DROP PROCEDURE [dbo].[SP_Monedas_Borrar]
GO

CREATE PROCEDURE SP_Monedas_Borrar
 (
  @pmon_id uniqueidentifier
 )

AS

 DELETE FROM
  [Monedas]
 WHERE
  (
   [mon_id] = @pmon_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Monedas_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Monedas_ConsultarTodos]
GO

CREATE PROCEDURE SP_Monedas_ConsultarTodos

AS

 SELECT
  [mon_id],
  [mon_nombre],
  [mon_simbolo],
  [mon_cambio_dolar]
 FROM
  [Monedas]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Monedas_Consultar]'))
DROP PROCEDURE [dbo].[SP_Monedas_Consultar]
GO

CREATE PROCEDURE SP_Monedas_Consultar
 (
  @pmon_id uniqueidentifier
 )

AS

 SELECT
  [mon_id],
  [mon_nombre],
  [mon_simbolo],
  [mon_cambio_dolar]
 FROM
  [Monedas]
 WHERE
  (
   [mon_id] = @pmon_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Monedas_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Monedas_ConsultarPor]
GO

CREATE PROCEDURE SP_Monedas_ConsultarPor
 (
  @pmon_id uniqueidentifier = NULL,
  @pmon_nombre varchar(50) = NULL,
  @pmon_simbolo varchar(50) = NULL,
  @pmon_cambio_dolar uniqueidentifier = NULL
 )

AS

  SELECT
   [mon_id],
   [mon_nombre],
   [mon_simbolo],
   [mon_cambio_dolar]
  FROM
   [Monedas] WITH(NOLOCK)
  WHERE
   (
    (@pmon_id IS NULL OR [mon_id] = @pmon_id)
     AND
    (@pmon_nombre IS NULL OR [mon_nombre] LIKE ('%' + @pmon_nombre + '%'))
     AND
    (@pmon_simbolo IS NULL OR [mon_simbolo] LIKE ('%' + @pmon_simbolo + '%'))
     AND
    (@pmon_cambio_dolar IS NULL OR [mon_cambio_dolar] = @pmon_cambio_dolar)
   )

GO

