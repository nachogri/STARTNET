-- Change the database here
USE [START_SQLBD]
GO

--------------------------------------------------
PRINT ('Creating store procedure for [Logueos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Logueos_Insertar]'))
DROP PROCEDURE [dbo].[SP_Logueos_Insertar]
GO

CREATE PROCEDURE SP_Logueos_Insertar
 (
  @plog_id uniqueidentifier,
  @plog_usu_id uniqueidentifier,
  @plog_fecha datetime,
  @plog_hora_in varchar(50),
  @plog_hora_out varchar(50)
 )

AS

 INSERT INTO [Logueos]
  (
   [log_id],
   [log_usu_id],
   [log_fecha],
   [log_hora_in],
   [log_hora_out]
  )
 VALUES
  (
   @plog_id,
   @plog_usu_id,
   @plog_fecha,
   @plog_hora_in,
   @plog_hora_out
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Logueos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Logueos_Actualizar]
GO

CREATE PROCEDURE SP_Logueos_Actualizar
 (
  @plog_id uniqueidentifier,
  @plog_usu_id uniqueidentifier,
  @plog_fecha datetime,
  @plog_hora_in varchar(50),
  @plog_hora_out varchar(50)
 )

AS

 UPDATE
  [Logueos]
 SET
  [log_id] = @plog_id,
  [log_usu_id] = @plog_usu_id,
  [log_fecha] = @plog_fecha,
  [log_hora_in] = @plog_hora_in,
  [log_hora_out] = @plog_hora_out
 WHERE
  [log_id] = @plog_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Logueos_Borrar]'))
DROP PROCEDURE [dbo].[SP_Logueos_Borrar]
GO

CREATE PROCEDURE SP_Logueos_Borrar
 (
  @plog_id uniqueidentifier
 )

AS

 DELETE FROM
  [Logueos]
 WHERE
  (
   [log_id] = @plog_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Logueos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Logueos_ConsultarTodos]
GO

CREATE PROCEDURE SP_Logueos_ConsultarTodos

AS

 SELECT
  [log_id],
  [log_usu_id],
  [log_fecha],
  [log_hora_in],
  [log_hora_out]
 FROM
  [Logueos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Logueos_Consultar]'))
DROP PROCEDURE [dbo].[SP_Logueos_Consultar]
GO

CREATE PROCEDURE SP_Logueos_Consultar
 (
  @plog_id uniqueidentifier
 )

AS

 SELECT
  [log_id],
  [log_usu_id],
  [log_fecha],
  [log_hora_in],
  [log_hora_out]
 FROM
  [Logueos]
 WHERE
  (
   [log_id] = @plog_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Logueos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Logueos_ConsultarPor]
GO

CREATE PROCEDURE SP_Logueos_ConsultarPor
 (
  @plog_id uniqueidentifier = NULL,
  @plog_usu_id uniqueidentifier = NULL,
  @plog_fecha datetime = NULL,
  @plog_hora_in varchar(50) = NULL,
  @plog_hora_out varchar(50) = NULL
 )

AS

  SELECT
   [log_id],
   [log_usu_id],
   [log_fecha],
   [log_hora_in],
   [log_hora_out]
  FROM
   [Logueos] WITH(NOLOCK)
  WHERE
   (
    (@plog_id IS NULL OR [log_id] = @plog_id)
     AND
    (@plog_usu_id IS NULL OR [log_usu_id] = @plog_usu_id)
     AND
    (@plog_fecha IS NULL OR [log_fecha] = @plog_fecha)
     AND
    (@plog_hora_in IS NULL OR [log_hora_in] LIKE ('%' + @plog_hora_in + '%'))
     AND
    (@plog_hora_out IS NULL OR [log_hora_out] LIKE ('%' + @plog_hora_out + '%'))
   )

GO

