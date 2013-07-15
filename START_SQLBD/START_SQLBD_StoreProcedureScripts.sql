-- Change the database here
USE [START_SQLBD]
GO

--------------------------------------------------
PRINT ('Creating store procedure for [ClienteEstados]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ClienteEstados_Insertar]'))
DROP PROCEDURE [dbo].[SP_ClienteEstados_Insertar]
GO

CREATE PROCEDURE SP_ClienteEstados_Insertar
 (
  @pcest_id uniqueidentifier,
  @pcest_descripcion varchar(50)
 )

AS

 INSERT INTO [ClienteEstados]
  (
   [cest_id],
   [cest_descripcion]
  )
 VALUES
  (
   @pcest_id,
   @pcest_descripcion
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ClienteEstados_Actualizar]'))
DROP PROCEDURE [dbo].[SP_ClienteEstados_Actualizar]
GO

CREATE PROCEDURE SP_ClienteEstados_Actualizar
 (
  @pcest_id uniqueidentifier,
  @pcest_descripcion varchar(50)
 )

AS

 UPDATE
  [ClienteEstados]
 SET
  [cest_id] = @pcest_id,
  [cest_descripcion] = @pcest_descripcion
 WHERE
  [cest_id] = @pcest_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ClienteEstados_Borrar]'))
DROP PROCEDURE [dbo].[SP_ClienteEstados_Borrar]
GO

CREATE PROCEDURE SP_ClienteEstados_Borrar
 (
  @pcest_id uniqueidentifier
 )

AS

 DELETE FROM
  [ClienteEstados]
 WHERE
  (
   [cest_id] = @pcest_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ClienteEstados_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_ClienteEstados_ConsultarTodos]
GO

CREATE PROCEDURE SP_ClienteEstados_ConsultarTodos

AS

 SELECT
  [cest_id],
  [cest_descripcion]
 FROM
  [ClienteEstados]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ClienteEstados_Consultar]'))
DROP PROCEDURE [dbo].[SP_ClienteEstados_Consultar]
GO

CREATE PROCEDURE SP_ClienteEstados_Consultar
 (
  @pcest_id uniqueidentifier
 )

AS

 SELECT
  [cest_id],
  [cest_descripcion]
 FROM
  [ClienteEstados]
 WHERE
  (
   [cest_id] = @pcest_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ClienteEstados_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_ClienteEstados_ConsultarPor]
GO

CREATE PROCEDURE SP_ClienteEstados_ConsultarPor
 (
  @pcest_id uniqueidentifier = NULL,
  @pcest_descripcion varchar(50) = NULL
 )

AS

  SELECT
   [cest_id],
   [cest_descripcion]
  FROM
   [ClienteEstados] WITH(NOLOCK)
  WHERE
   (
    (@pcest_id IS NULL OR [cest_id] = @pcest_id)
     AND
    (@pcest_descripcion IS NULL OR [cest_descripcion] LIKE ('%' + @pcest_descripcion + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [CondicionIVA]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_CondicionIVA_Insertar]'))
DROP PROCEDURE [dbo].[SP_CondicionIVA_Insertar]
GO

CREATE PROCEDURE SP_CondicionIVA_Insertar
 (
  @pciva_id uniqueidentifier,
  @pciva_descripcion varchar(50)
 )

AS

 INSERT INTO [CondicionIVA]
  (
   [civa_id],
   [civa_descripcion]
  )
 VALUES
  (
   @pciva_id,
   @pciva_descripcion
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_CondicionIVA_Actualizar]'))
DROP PROCEDURE [dbo].[SP_CondicionIVA_Actualizar]
GO

CREATE PROCEDURE SP_CondicionIVA_Actualizar
 (
  @pciva_id uniqueidentifier,
  @pciva_descripcion varchar(50)
 )

AS

 UPDATE
  [CondicionIVA]
 SET
  [civa_id] = @pciva_id,
  [civa_descripcion] = @pciva_descripcion
 WHERE
  [civa_id] = @pciva_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_CondicionIVA_Borrar]'))
DROP PROCEDURE [dbo].[SP_CondicionIVA_Borrar]
GO

CREATE PROCEDURE SP_CondicionIVA_Borrar
 (
  @pciva_id uniqueidentifier
 )

AS

 DELETE FROM
  [CondicionIVA]
 WHERE
  (
   [civa_id] = @pciva_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_CondicionIVA_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_CondicionIVA_ConsultarTodos]
GO

CREATE PROCEDURE SP_CondicionIVA_ConsultarTodos

AS

 SELECT
  [civa_id],
  [civa_descripcion]
 FROM
  [CondicionIVA]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_CondicionIVA_Consultar]'))
DROP PROCEDURE [dbo].[SP_CondicionIVA_Consultar]
GO

CREATE PROCEDURE SP_CondicionIVA_Consultar
 (
  @pciva_id uniqueidentifier
 )

AS

 SELECT
  [civa_id],
  [civa_descripcion]
 FROM
  [CondicionIVA]
 WHERE
  (
   [civa_id] = @pciva_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_CondicionIVA_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_CondicionIVA_ConsultarPor]
GO

CREATE PROCEDURE SP_CondicionIVA_ConsultarPor
 (
  @pciva_id uniqueidentifier = NULL,
  @pciva_descripcion varchar(50) = NULL
 )

AS

  SELECT
   [civa_id],
   [civa_descripcion]
  FROM
   [CondicionIVA] WITH(NOLOCK)
  WHERE
   (
    (@pciva_id IS NULL OR [civa_id] = @pciva_id)
     AND
    (@pciva_descripcion IS NULL OR [civa_descripcion] LIKE ('%' + @pciva_descripcion + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Contactos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Contactos_Insertar]'))
DROP PROCEDURE [dbo].[SP_Contactos_Insertar]
GO

CREATE PROCEDURE SP_Contactos_Insertar
 (
  @pcon_id uniqueidentifier,
  @pcon_usu_id uniqueidentifier,
  @pcon_fecha datetime,
  @pcon_tipo varchar(50),
  @pcon_mensaje varchar(500),
  @pcon_respuesta varchar(500),
  @pcon_DVH int
 )

AS

 INSERT INTO [Contactos]
  (
   [con_id],
   [con_usu_id],
   [con_fecha],
   [con_tipo],
   [con_mensaje],
   [con_respuesta],
   [con_DVH]
  )
 VALUES
  (
   @pcon_id,
   @pcon_usu_id,
   @pcon_fecha,
   @pcon_tipo,
   @pcon_mensaje,
   @pcon_respuesta,
   @pcon_DVH
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Contactos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Contactos_Actualizar]
GO

CREATE PROCEDURE SP_Contactos_Actualizar
 (
  @pcon_id uniqueidentifier,
  @pcon_usu_id uniqueidentifier,
  @pcon_fecha datetime,
  @pcon_tipo varchar(50),
  @pcon_mensaje varchar(500),
  @pcon_respuesta varchar(500),
  @pcon_DVH int
 )

AS

 UPDATE
  [Contactos]
 SET
  [con_id] = @pcon_id,
  [con_usu_id] = @pcon_usu_id,
  [con_fecha] = @pcon_fecha,
  [con_tipo] = @pcon_tipo,
  [con_mensaje] = @pcon_mensaje,
  [con_respuesta] = @pcon_respuesta,
  [con_DVH] = @pcon_DVH
 WHERE
  [con_id] = @pcon_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Contactos_Borrar]'))
DROP PROCEDURE [dbo].[SP_Contactos_Borrar]
GO

CREATE PROCEDURE SP_Contactos_Borrar
 (
  @pcon_id uniqueidentifier
 )

AS

 DELETE FROM
  [Contactos]
 WHERE
  (
   [con_id] = @pcon_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Contactos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Contactos_ConsultarTodos]
GO

CREATE PROCEDURE SP_Contactos_ConsultarTodos

AS

 SELECT
  [con_id],
  [con_usu_id],
  [con_fecha],
  [con_tipo],
  [con_mensaje],
  [con_respuesta],
  [con_DVH]
 FROM
  [Contactos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Contactos_Consultar]'))
DROP PROCEDURE [dbo].[SP_Contactos_Consultar]
GO

CREATE PROCEDURE SP_Contactos_Consultar
 (
  @pcon_id uniqueidentifier
 )

AS

 SELECT
  [con_id],
  [con_usu_id],
  [con_fecha],
  [con_tipo],
  [con_mensaje],
  [con_respuesta],
  [con_DVH]
 FROM
  [Contactos]
 WHERE
  (
   [con_id] = @pcon_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Contactos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Contactos_ConsultarPor]
GO

CREATE PROCEDURE SP_Contactos_ConsultarPor
 (
  @pcon_id uniqueidentifier = NULL,
  @pcon_usu_id uniqueidentifier = NULL,
  @pcon_fecha datetime = NULL,
  @pcon_tipo varchar(50) = NULL,
  @pcon_mensaje varchar(500) = NULL,
  @pcon_respuesta varchar(500) = NULL,
  @pcon_DVH int = NULL
 )

AS

  SELECT
   [con_id],
   [con_usu_id],
   [con_fecha],
   [con_tipo],
   [con_mensaje],
   [con_respuesta],
   [con_DVH]
  FROM
   [Contactos] WITH(NOLOCK)
  WHERE
   (
    (@pcon_id IS NULL OR [con_id] = @pcon_id)
     AND
    (@pcon_usu_id IS NULL OR [con_usu_id] = @pcon_usu_id)
     AND
    (@pcon_fecha IS NULL OR [con_fecha] = @pcon_fecha)
     AND
    (@pcon_tipo IS NULL OR [con_tipo] LIKE ('%' + @pcon_tipo + '%'))
     AND
    (@pcon_mensaje IS NULL OR [con_mensaje] LIKE ('%' + @pcon_mensaje + '%'))
     AND
    (@pcon_respuesta IS NULL OR [con_respuesta] LIKE ('%' + @pcon_respuesta + '%'))
     AND
    (@pcon_DVH IS NULL OR [con_DVH] = @pcon_DVH)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Desarrolladores]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Desarrolladores_Insertar]'))
DROP PROCEDURE [dbo].[SP_Desarrolladores_Insertar]
GO

CREATE PROCEDURE SP_Desarrolladores_Insertar
 (
  @pusud_id uniqueidentifier,
  @pusud_usu_id uniqueidentifier,
  @pusud_descrip_prod varchar(100),
  @pusud_razon_social varchar(50),
  @pusud_aviso varchar(100),
  @pusud_comentarios varchar(100),
  @pusud_imagen image
 )

AS

 INSERT INTO [Desarrolladores]
  (
   [usud_id],
   [usud_usu_id],
   [usud_descrip_prod],
   [usud_razon_social],
   [usud_aviso],
   [usud_comentarios],
   [usud_imagen]
  )
 VALUES
  (
   @pusud_id,
   @pusud_usu_id,
   @pusud_descrip_prod,
   @pusud_razon_social,
   @pusud_aviso,
   @pusud_comentarios,
   @pusud_imagen
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Desarrolladores_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Desarrolladores_Actualizar]
GO

CREATE PROCEDURE SP_Desarrolladores_Actualizar
 (
  @pusud_id uniqueidentifier,
  @pusud_usu_id uniqueidentifier,
  @pusud_descrip_prod varchar(100),
  @pusud_razon_social varchar(50),
  @pusud_aviso varchar(100),
  @pusud_comentarios varchar(100),
  @pusud_imagen image
 )

AS

 UPDATE
  [Desarrolladores]
 SET
  [usud_id] = @pusud_id,
  [usud_usu_id] = @pusud_usu_id,
  [usud_descrip_prod] = @pusud_descrip_prod,
  [usud_razon_social] = @pusud_razon_social,
  [usud_aviso] = @pusud_aviso,
  [usud_comentarios] = @pusud_comentarios,
  [usud_imagen] = @pusud_imagen
 WHERE
  [usud_id] = @pusud_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Desarrolladores_Borrar]'))
DROP PROCEDURE [dbo].[SP_Desarrolladores_Borrar]
GO

CREATE PROCEDURE SP_Desarrolladores_Borrar
 (
  @pusud_id uniqueidentifier
 )

AS

 DELETE FROM
  [Desarrolladores]
 WHERE
  (
   [usud_id] = @pusud_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Desarrolladores_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Desarrolladores_ConsultarTodos]
GO

CREATE PROCEDURE SP_Desarrolladores_ConsultarTodos

AS

 SELECT
  [usud_id],
  [usud_usu_id],
  [usud_descrip_prod],
  [usud_razon_social],
  [usud_aviso],
  [usud_comentarios],
  [usud_imagen]
 FROM
  [Desarrolladores]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Desarrolladores_Consultar]'))
DROP PROCEDURE [dbo].[SP_Desarrolladores_Consultar]
GO

CREATE PROCEDURE SP_Desarrolladores_Consultar
 (
  @pusud_id uniqueidentifier
 )

AS

 SELECT
  [usud_id],
  [usud_usu_id],
  [usud_descrip_prod],
  [usud_razon_social],
  [usud_aviso],
  [usud_comentarios],
  [usud_imagen]
 FROM
  [Desarrolladores]
 WHERE
  (
   [usud_id] = @pusud_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Desarrolladores_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Desarrolladores_ConsultarPor]
GO

CREATE PROCEDURE SP_Desarrolladores_ConsultarPor
 (
  @pusud_id uniqueidentifier = NULL,
  @pusud_usu_id uniqueidentifier = NULL,
  @pusud_descrip_prod varchar(100) = NULL,
  @pusud_razon_social varchar(50) = NULL,
  @pusud_aviso varchar(100) = NULL,
  @pusud_comentarios varchar(100) = NULL
 )

AS

  SELECT
   [usud_id],
   [usud_usu_id],
   [usud_descrip_prod],
   [usud_razon_social],
   [usud_aviso],
   [usud_comentarios],
   [usud_imagen]
  FROM
   [Desarrolladores] WITH(NOLOCK)
  WHERE
   (
    (@pusud_id IS NULL OR [usud_id] = @pusud_id)
     AND
    (@pusud_usu_id IS NULL OR [usud_usu_id] = @pusud_usu_id)
     AND
    (@pusud_descrip_prod IS NULL OR [usud_descrip_prod] LIKE ('%' + @pusud_descrip_prod + '%'))
     AND
    (@pusud_razon_social IS NULL OR [usud_razon_social] LIKE ('%' + @pusud_razon_social + '%'))
     AND
    (@pusud_aviso IS NULL OR [usud_aviso] LIKE ('%' + @pusud_aviso + '%'))
     AND
    (@pusud_comentarios IS NULL OR [usud_comentarios] LIKE ('%' + @pusud_comentarios + '%'))
    
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Descargas]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Descargas_Insertar]'))
DROP PROCEDURE [dbo].[SP_Descargas_Insertar]
GO

CREATE PROCEDURE SP_Descargas_Insertar
 (
  @pdes_id uniqueidentifier,
  @pdes_tipo_archivo varchar(50),
  @pdes_ruta varchar(50),
  @pdes_descrip varchar(50),
  @pdes_especificaciones varchar(100),
  @pdes_fecha_actualizacion datetime
 )

AS

 INSERT INTO [Descargas]
  (
   [des_id],
   [des_tipo_archivo],
   [des_ruta],
   [des_descrip],
   [des_especificaciones],
   [des_fecha_actualizacion]
  )
 VALUES
  (
   @pdes_id,
   @pdes_tipo_archivo,
   @pdes_ruta,
   @pdes_descrip,
   @pdes_especificaciones,
   @pdes_fecha_actualizacion
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Descargas_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Descargas_Actualizar]
GO

CREATE PROCEDURE SP_Descargas_Actualizar
 (
  @pdes_id uniqueidentifier,
  @pdes_tipo_archivo varchar(50),
  @pdes_ruta varchar(50),
  @pdes_descrip varchar(50),
  @pdes_especificaciones varchar(100),
  @pdes_fecha_actualizacion datetime
 )

AS

 UPDATE
  [Descargas]
 SET
  [des_id] = @pdes_id,
  [des_tipo_archivo] = @pdes_tipo_archivo,
  [des_ruta] = @pdes_ruta,
  [des_descrip] = @pdes_descrip,
  [des_especificaciones] = @pdes_especificaciones,
  [des_fecha_actualizacion] = @pdes_fecha_actualizacion
 WHERE
  [des_id] = @pdes_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Descargas_Borrar]'))
DROP PROCEDURE [dbo].[SP_Descargas_Borrar]
GO

CREATE PROCEDURE SP_Descargas_Borrar
 (
  @pdes_id uniqueidentifier
 )

AS

 DELETE FROM
  [Descargas]
 WHERE
  (
   [des_id] = @pdes_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Descargas_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Descargas_ConsultarTodos]
GO

CREATE PROCEDURE SP_Descargas_ConsultarTodos

AS

 SELECT
  [des_id],
  [des_tipo_archivo],
  [des_ruta],
  [des_descrip],
  [des_especificaciones],
  [des_fecha_actualizacion]
 FROM
  [Descargas]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Descargas_Consultar]'))
DROP PROCEDURE [dbo].[SP_Descargas_Consultar]
GO

CREATE PROCEDURE SP_Descargas_Consultar
 (
  @pdes_id uniqueidentifier
 )

AS

 SELECT
  [des_id],
  [des_tipo_archivo],
  [des_ruta],
  [des_descrip],
  [des_especificaciones],
  [des_fecha_actualizacion]
 FROM
  [Descargas]
 WHERE
  (
   [des_id] = @pdes_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Descargas_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Descargas_ConsultarPor]
GO

CREATE PROCEDURE SP_Descargas_ConsultarPor
 (
  @pdes_id uniqueidentifier = NULL,
  @pdes_tipo_archivo varchar(50) = NULL,
  @pdes_ruta varchar(50) = NULL,
  @pdes_descrip varchar(50) = NULL,
  @pdes_especificaciones varchar(100) = NULL,
  @pdes_fecha_actualizacion datetime = NULL
 )

AS

  SELECT
   [des_id],
   [des_tipo_archivo],
   [des_ruta],
   [des_descrip],
   [des_especificaciones],
   [des_fecha_actualizacion]
  FROM
   [Descargas] WITH(NOLOCK)
  WHERE
   (
    (@pdes_id IS NULL OR [des_id] = @pdes_id)
     AND
    (@pdes_tipo_archivo IS NULL OR [des_tipo_archivo] LIKE ('%' + @pdes_tipo_archivo + '%'))
     AND
    (@pdes_ruta IS NULL OR [des_ruta] LIKE ('%' + @pdes_ruta + '%'))
     AND
    (@pdes_descrip IS NULL OR [des_descrip] LIKE ('%' + @pdes_descrip + '%'))
     AND
    (@pdes_especificaciones IS NULL OR [des_especificaciones] LIKE ('%' + @pdes_especificaciones + '%'))
     AND
    (@pdes_fecha_actualizacion IS NULL OR [des_fecha_actualizacion] = @pdes_fecha_actualizacion)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Domicilios]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Domicilios_Insertar]'))
DROP PROCEDURE [dbo].[SP_Domicilios_Insertar]
GO

CREATE PROCEDURE SP_Domicilios_Insertar
 (
  @pdom_id uniqueidentifier,
  @pdom_tipo varchar(50),
  @pdom_calle varchar(50),
  @pdom_nro varchar(50),
  @pdom_loc_id uniqueidentifier,
  @pdom_usu_id uniqueidentifier
 )

AS

 INSERT INTO [Domicilios]
  (
   [dom_id],
   [dom_tipo],
   [dom_calle],
   [dom_nro],
   [dom_loc_id],
   [dom_usu_id]
  )
 VALUES
  (
   @pdom_id,
   @pdom_tipo,
   @pdom_calle,
   @pdom_nro,
   @pdom_loc_id,
   @pdom_usu_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Domicilios_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Domicilios_Actualizar]
GO

CREATE PROCEDURE SP_Domicilios_Actualizar
 (
  @pdom_id uniqueidentifier,
  @pdom_tipo varchar(50),
  @pdom_calle varchar(50),
  @pdom_nro varchar(50),
  @pdom_loc_id uniqueidentifier,
  @pdom_usu_id uniqueidentifier
 )

AS

 UPDATE
  [Domicilios]
 SET
  [dom_id] = @pdom_id,
  [dom_tipo] = @pdom_tipo,
  [dom_calle] = @pdom_calle,
  [dom_nro] = @pdom_nro,
  [dom_loc_id] = @pdom_loc_id,
  [dom_usu_id] = @pdom_usu_id
 WHERE
  [dom_id] = @pdom_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Domicilios_Borrar]'))
DROP PROCEDURE [dbo].[SP_Domicilios_Borrar]
GO

CREATE PROCEDURE SP_Domicilios_Borrar
 (
  @pdom_id uniqueidentifier
 )

AS

 DELETE FROM
  [Domicilios]
 WHERE
  (
   [dom_id] = @pdom_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Domicilios_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Domicilios_ConsultarTodos]
GO

CREATE PROCEDURE SP_Domicilios_ConsultarTodos

AS

 SELECT
  [dom_id],
  [dom_tipo],
  [dom_calle],
  [dom_nro],
  [dom_loc_id],
  [dom_usu_id]
 FROM
  [Domicilios]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Domicilios_Consultar]'))
DROP PROCEDURE [dbo].[SP_Domicilios_Consultar]
GO

CREATE PROCEDURE SP_Domicilios_Consultar
 (
  @pdom_id uniqueidentifier
 )

AS

 SELECT
  [dom_id],
  [dom_tipo],
  [dom_calle],
  [dom_nro],
  [dom_loc_id],
  [dom_usu_id]
 FROM
  [Domicilios]
 WHERE
  (
   [dom_id] = @pdom_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Domicilios_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Domicilios_ConsultarPor]
GO

CREATE PROCEDURE SP_Domicilios_ConsultarPor
 (
  @pdom_id uniqueidentifier = NULL,
  @pdom_tipo varchar(50) = NULL,
  @pdom_calle varchar(50) = NULL,
  @pdom_nro varchar(50) = NULL,
  @pdom_loc_id uniqueidentifier = NULL,
  @pdom_usu_id uniqueidentifier = NULL
 )

AS

  SELECT
   [dom_id],
   [dom_tipo],
   [dom_calle],
   [dom_nro],
   [dom_loc_id],
   [dom_usu_id]
  FROM
   [Domicilios] WITH(NOLOCK)
  WHERE
   (
    (@pdom_id IS NULL OR [dom_id] = @pdom_id)
     AND
    (@pdom_tipo IS NULL OR [dom_tipo] LIKE ('%' + @pdom_tipo + '%'))
     AND
    (@pdom_calle IS NULL OR [dom_calle] LIKE ('%' + @pdom_calle + '%'))
     AND
    (@pdom_nro IS NULL OR [dom_nro] LIKE ('%' + @pdom_nro + '%'))
     AND
    (@pdom_loc_id IS NULL OR [dom_loc_id] = @pdom_loc_id)
     AND
    (@pdom_usu_id IS NULL OR [dom_usu_id] = @pdom_usu_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Familias]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Familias_Insertar]'))
DROP PROCEDURE [dbo].[SP_Familias_Insertar]
GO

CREATE PROCEDURE SP_Familias_Insertar
 (
  @pfam_id uniqueidentifier,
  @pfam_descrip varchar(50)
 )

AS

 INSERT INTO [Familias]
  (
   [fam_id],
   [fam_descrip]
  )
 VALUES
  (
   @pfam_id,
   @pfam_descrip
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Familias_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Familias_Actualizar]
GO

CREATE PROCEDURE SP_Familias_Actualizar
 (
  @pfam_id uniqueidentifier,
  @pfam_descrip varchar(50)
 )

AS

 UPDATE
  [Familias]
 SET
  [fam_id] = @pfam_id,
  [fam_descrip] = @pfam_descrip
 WHERE
  [fam_id] = @pfam_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Familias_Borrar]'))
DROP PROCEDURE [dbo].[SP_Familias_Borrar]
GO

CREATE PROCEDURE SP_Familias_Borrar
 (
  @pfam_id uniqueidentifier
 )

AS

 DELETE FROM
  [Familias]
 WHERE
  (
   [fam_id] = @pfam_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Familias_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Familias_ConsultarTodos]
GO

CREATE PROCEDURE SP_Familias_ConsultarTodos

AS

 SELECT
  [fam_id],
  [fam_descrip]
 FROM
  [Familias]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Familias_Consultar]'))
DROP PROCEDURE [dbo].[SP_Familias_Consultar]
GO

CREATE PROCEDURE SP_Familias_Consultar
 (
  @pfam_id uniqueidentifier
 )

AS

 SELECT
  [fam_id],
  [fam_descrip]
 FROM
  [Familias]
 WHERE
  (
   [fam_id] = @pfam_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Familias_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Familias_ConsultarPor]
GO

CREATE PROCEDURE SP_Familias_ConsultarPor
 (
  @pfam_id uniqueidentifier = NULL,
  @pfam_descrip varchar(50) = NULL
 )

AS

  SELECT
   [fam_id],
   [fam_descrip]
  FROM
   [Familias] WITH(NOLOCK)
  WHERE
   (
    (@pfam_id IS NULL OR [fam_id] = @pfam_id)
     AND
    (@pfam_descrip IS NULL OR [fam_descrip] LIKE ('%' + @pfam_descrip + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [FamiliasPatentes]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_FamiliasPatentes_Insertar]'))
DROP PROCEDURE [dbo].[SP_FamiliasPatentes_Insertar]
GO

CREATE PROCEDURE SP_FamiliasPatentes_Insertar
 (
  @pfp_fam_id uniqueidentifier,
  @pfp_pat_id uniqueidentifier
 )

AS

 INSERT INTO [FamiliasPatentes]
  (
   [fp_fam_id],
   [fp_pat_id]
  )
 VALUES
  (
   @pfp_fam_id,
   @pfp_pat_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_FamiliasPatentes_Actualizar]'))
DROP PROCEDURE [dbo].[SP_FamiliasPatentes_Actualizar]
GO

CREATE PROCEDURE SP_FamiliasPatentes_Actualizar
 (
  @pfp_fam_id uniqueidentifier,
  @pfp_pat_id uniqueidentifier
 )

AS

 UPDATE
  [FamiliasPatentes]
 SET
  [fp_fam_id] = @pfp_fam_id,
  [fp_pat_id] = @pfp_pat_id
 WHERE
  (
   [fp_fam_id] = @pfp_fam_id
    AND
   [fp_pat_id] = @pfp_pat_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_FamiliasPatentes_Borrar]'))
DROP PROCEDURE [dbo].[SP_FamiliasPatentes_Borrar]
GO

CREATE PROCEDURE SP_FamiliasPatentes_Borrar
 (
  @pfp_fam_id uniqueidentifier,
  @pfp_pat_id uniqueidentifier
 )

AS

 DELETE FROM
  [FamiliasPatentes]
 WHERE
  (
   [fp_fam_id] = @pfp_fam_id
    AND
   [fp_pat_id] = @pfp_pat_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_FamiliasPatentes_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_FamiliasPatentes_ConsultarTodos]
GO

CREATE PROCEDURE SP_FamiliasPatentes_ConsultarTodos

AS

 SELECT
  [fp_fam_id],
  [fp_pat_id]
 FROM
  [FamiliasPatentes]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_FamiliasPatentes_Consultar]'))
DROP PROCEDURE [dbo].[SP_FamiliasPatentes_Consultar]
GO

CREATE PROCEDURE SP_FamiliasPatentes_Consultar
 (
  @pfp_fam_id uniqueidentifier,
  @pfp_pat_id uniqueidentifier
 )

AS

 SELECT
  [fp_fam_id],
  [fp_pat_id]
 FROM
  [FamiliasPatentes]
 WHERE
  (
   [fp_fam_id] = @pfp_fam_id
    AND
   [fp_pat_id] = @pfp_pat_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_FamiliasPatentes_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_FamiliasPatentes_ConsultarPor]
GO

CREATE PROCEDURE SP_FamiliasPatentes_ConsultarPor
 (
  @pfp_fam_id uniqueidentifier = NULL,
  @pfp_pat_id uniqueidentifier = NULL
 )

AS

  SELECT
   [fp_fam_id],
   [fp_pat_id]
  FROM
   [FamiliasPatentes] WITH(NOLOCK)
  WHERE
   (
    (@pfp_fam_id IS NULL OR [fp_fam_id] = @pfp_fam_id)
     AND
    (@pfp_pat_id IS NULL OR [fp_pat_id] = @pfp_pat_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [FormatosCulturas]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_FormatosCulturas_Insertar]'))
DROP PROCEDURE [dbo].[SP_FormatosCulturas_Insertar]
GO

CREATE PROCEDURE SP_FormatosCulturas_Insertar
 (
  @pfc_id uniqueidentifier,
  @pfc_hora varchar(25),
  @pfc_fecha varchar(25),
  @pfc_numeros varchar(25),
  @pfc_idioma_id uniqueidentifier
 )

AS

 INSERT INTO [FormatosCulturas]
  (
   [fc_id],
   [fc_hora],
   [fc_fecha],
   [fc_numeros],
   [fc_idioma_id]
  )
 VALUES
  (
   @pfc_id,
   @pfc_hora,
   @pfc_fecha,
   @pfc_numeros,
   @pfc_idioma_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_FormatosCulturas_Actualizar]'))
DROP PROCEDURE [dbo].[SP_FormatosCulturas_Actualizar]
GO

CREATE PROCEDURE SP_FormatosCulturas_Actualizar
 (
  @pfc_id uniqueidentifier,
  @pfc_hora varchar(25),
  @pfc_fecha varchar(25),
  @pfc_numeros varchar(25),
  @pfc_idioma_id uniqueidentifier
 )

AS

 UPDATE
  [FormatosCulturas]
 SET
  [fc_id] = @pfc_id,
  [fc_hora] = @pfc_hora,
  [fc_fecha] = @pfc_fecha,
  [fc_numeros] = @pfc_numeros,
  [fc_idioma_id] = @pfc_idioma_id
 WHERE
  [fc_id] = @pfc_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_FormatosCulturas_Borrar]'))
DROP PROCEDURE [dbo].[SP_FormatosCulturas_Borrar]
GO

CREATE PROCEDURE SP_FormatosCulturas_Borrar
 (
  @pfc_id uniqueidentifier
 )

AS

 DELETE FROM
  [FormatosCulturas]
 WHERE
  (
   [fc_id] = @pfc_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_FormatosCulturas_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_FormatosCulturas_ConsultarTodos]
GO

CREATE PROCEDURE SP_FormatosCulturas_ConsultarTodos

AS

 SELECT
  [fc_id],
  [fc_hora],
  [fc_fecha],
  [fc_numeros],
  [fc_idioma_id]
 FROM
  [FormatosCulturas]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_FormatosCulturas_Consultar]'))
DROP PROCEDURE [dbo].[SP_FormatosCulturas_Consultar]
GO

CREATE PROCEDURE SP_FormatosCulturas_Consultar
 (
  @pfc_id uniqueidentifier
 )

AS

 SELECT
  [fc_id],
  [fc_hora],
  [fc_fecha],
  [fc_numeros],
  [fc_idioma_id]
 FROM
  [FormatosCulturas]
 WHERE
  (
   [fc_id] = @pfc_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_FormatosCulturas_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_FormatosCulturas_ConsultarPor]
GO

CREATE PROCEDURE SP_FormatosCulturas_ConsultarPor
 (
  @pfc_id uniqueidentifier = NULL,
  @pfc_hora varchar(25) = NULL,
  @pfc_fecha varchar(25) = NULL,
  @pfc_numeros varchar(25) = NULL,
  @pfc_idioma_id uniqueidentifier = NULL
 )

AS

  SELECT
   [fc_id],
   [fc_hora],
   [fc_fecha],
   [fc_numeros],
   [fc_idioma_id]
  FROM
   [FormatosCulturas] WITH(NOLOCK)
  WHERE
   (
    (@pfc_id IS NULL OR [fc_id] = @pfc_id)
     AND
    (@pfc_hora IS NULL OR [fc_hora] LIKE ('%' + @pfc_hora + '%'))
     AND
    (@pfc_fecha IS NULL OR [fc_fecha] LIKE ('%' + @pfc_fecha + '%'))
     AND
    (@pfc_numeros IS NULL OR [fc_numeros] LIKE ('%' + @pfc_numeros + '%'))
     AND
    (@pfc_idioma_id IS NULL OR [fc_idioma_id] = @pfc_idioma_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [ForoComentarios]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ForoComentarios_Insertar]'))
DROP PROCEDURE [dbo].[SP_ForoComentarios_Insertar]
GO

CREATE PROCEDURE SP_ForoComentarios_Insertar
 (
  @pfc_id uniqueidentifier,
  @pfc_fecha datetime,
  @pfc_usu_id uniqueidentifier,
  @pfc_ft_id uniqueidentifier,
  @pfc_mensaje varchar(500)
 )

AS

 INSERT INTO [ForoComentarios]
  (
   [fc_id],
   [fc_fecha],
   [fc_usu_id],
   [fc_ft_id],
   [fc_mensaje]
  )
 VALUES
  (
   @pfc_id,
   @pfc_fecha,
   @pfc_usu_id,
   @pfc_ft_id,
   @pfc_mensaje
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ForoComentarios_Actualizar]'))
DROP PROCEDURE [dbo].[SP_ForoComentarios_Actualizar]
GO

CREATE PROCEDURE SP_ForoComentarios_Actualizar
 (
  @pfc_id uniqueidentifier,
  @pfc_fecha datetime,
  @pfc_usu_id uniqueidentifier,
  @pfc_ft_id uniqueidentifier,
  @pfc_mensaje varchar(500)
 )

AS

 UPDATE
  [ForoComentarios]
 SET
  [fc_id] = @pfc_id,
  [fc_fecha] = @pfc_fecha,
  [fc_usu_id] = @pfc_usu_id,
  [fc_ft_id] = @pfc_ft_id,
  [fc_mensaje] = @pfc_mensaje
 WHERE
  [fc_id] = @pfc_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ForoComentarios_Borrar]'))
DROP PROCEDURE [dbo].[SP_ForoComentarios_Borrar]
GO

CREATE PROCEDURE SP_ForoComentarios_Borrar
 (
  @pfc_id uniqueidentifier
 )

AS

 DELETE FROM
  [ForoComentarios]
 WHERE
  (
   [fc_id] = @pfc_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ForoComentarios_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_ForoComentarios_ConsultarTodos]
GO

CREATE PROCEDURE SP_ForoComentarios_ConsultarTodos

AS

 SELECT
  [fc_id],
  [fc_fecha],
  [fc_usu_id],
  [fc_ft_id],
  [fc_mensaje]
 FROM
  [ForoComentarios]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ForoComentarios_Consultar]'))
DROP PROCEDURE [dbo].[SP_ForoComentarios_Consultar]
GO

CREATE PROCEDURE SP_ForoComentarios_Consultar
 (
  @pfc_id uniqueidentifier
 )

AS

 SELECT
  [fc_id],
  [fc_fecha],
  [fc_usu_id],
  [fc_ft_id],
  [fc_mensaje]
 FROM
  [ForoComentarios]
 WHERE
  (
   [fc_id] = @pfc_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ForoComentarios_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_ForoComentarios_ConsultarPor]
GO

CREATE PROCEDURE SP_ForoComentarios_ConsultarPor
 (
  @pfc_id uniqueidentifier = NULL,
  @pfc_fecha datetime = NULL,
  @pfc_usu_id uniqueidentifier = NULL,
  @pfc_ft_id uniqueidentifier = NULL,
  @pfc_mensaje varchar(500) = NULL
 )

AS

  SELECT
   [fc_id],
   [fc_fecha],
   [fc_usu_id],
   [fc_ft_id],
   [fc_mensaje]
  FROM
   [ForoComentarios] WITH(NOLOCK)
  WHERE
   (
    (@pfc_id IS NULL OR [fc_id] = @pfc_id)
     AND
    (@pfc_fecha IS NULL OR [fc_fecha] = @pfc_fecha)
     AND
    (@pfc_usu_id IS NULL OR [fc_usu_id] = @pfc_usu_id)
     AND
    (@pfc_ft_id IS NULL OR [fc_ft_id] = @pfc_ft_id)
     AND
    (@pfc_mensaje IS NULL OR [fc_mensaje] LIKE ('%' + @pfc_mensaje + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [ForoTopicos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ForoTopicos_Insertar]'))
DROP PROCEDURE [dbo].[SP_ForoTopicos_Insertar]
GO

CREATE PROCEDURE SP_ForoTopicos_Insertar
 (
  @pft_id uniqueidentifier,
  @pft_fecha_alta datetime,
  @pft_usu_id uniqueidentifier,
  @pft_descrip varchar(150),
  @pft_activo varchar(50)
 )

AS

 INSERT INTO [ForoTopicos]
  (
   [ft_id],
   [ft_fecha_alta],
   [ft_usu_id],
   [ft_descrip],
   [ft_activo]
  )
 VALUES
  (
   @pft_id,
   @pft_fecha_alta,
   @pft_usu_id,
   @pft_descrip,
   @pft_activo
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ForoTopicos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_ForoTopicos_Actualizar]
GO

CREATE PROCEDURE SP_ForoTopicos_Actualizar
 (
  @pft_id uniqueidentifier,
  @pft_fecha_alta datetime,
  @pft_usu_id uniqueidentifier,
  @pft_descrip varchar(150),
  @pft_activo varchar(50)
 )

AS

 UPDATE
  [ForoTopicos]
 SET
  [ft_id] = @pft_id,
  [ft_fecha_alta] = @pft_fecha_alta,
  [ft_usu_id] = @pft_usu_id,
  [ft_descrip] = @pft_descrip,
  [ft_activo] = @pft_activo
 WHERE
  [ft_id] = @pft_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ForoTopicos_Borrar]'))
DROP PROCEDURE [dbo].[SP_ForoTopicos_Borrar]
GO

CREATE PROCEDURE SP_ForoTopicos_Borrar
 (
  @pft_id uniqueidentifier
 )

AS

 DELETE FROM
  [ForoTopicos]
 WHERE
  (
   [ft_id] = @pft_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ForoTopicos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_ForoTopicos_ConsultarTodos]
GO

CREATE PROCEDURE SP_ForoTopicos_ConsultarTodos

AS

 SELECT
  [ft_id],
  [ft_fecha_alta],
  [ft_usu_id],
  [ft_descrip],
  [ft_activo]
 FROM
  [ForoTopicos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ForoTopicos_Consultar]'))
DROP PROCEDURE [dbo].[SP_ForoTopicos_Consultar]
GO

CREATE PROCEDURE SP_ForoTopicos_Consultar
 (
  @pft_id uniqueidentifier
 )

AS

 SELECT
  [ft_id],
  [ft_fecha_alta],
  [ft_usu_id],
  [ft_descrip],
  [ft_activo]
 FROM
  [ForoTopicos]
 WHERE
  (
   [ft_id] = @pft_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ForoTopicos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_ForoTopicos_ConsultarPor]
GO

CREATE PROCEDURE SP_ForoTopicos_ConsultarPor
 (
  @pft_id uniqueidentifier = NULL,
  @pft_fecha_alta datetime = NULL,
  @pft_usu_id uniqueidentifier = NULL,
  @pft_descrip varchar(150) = NULL,
  @pft_activo varchar(50) = NULL
 )

AS

  SELECT
   [ft_id],
   [ft_fecha_alta],
   [ft_usu_id],
   [ft_descrip],
   [ft_activo]
  FROM
   [ForoTopicos] WITH(NOLOCK)
  WHERE
   (
    (@pft_id IS NULL OR [ft_id] = @pft_id)
     AND
    (@pft_fecha_alta IS NULL OR [ft_fecha_alta] = @pft_fecha_alta)
     AND
    (@pft_usu_id IS NULL OR [ft_usu_id] = @pft_usu_id)
     AND
    (@pft_descrip IS NULL OR [ft_descrip] LIKE ('%' + @pft_descrip + '%'))
     AND
    (@pft_activo IS NULL OR [ft_activo] LIKE ('%' + @pft_activo + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Idiomas]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Idiomas_Insertar]'))
DROP PROCEDURE [dbo].[SP_Idiomas_Insertar]
GO

CREATE PROCEDURE SP_Idiomas_Insertar
 (
  @pidioma_id uniqueidentifier,
  @pidioma_nombre varchar(20)
 )

AS

 INSERT INTO [Idiomas]
  (
   [idioma_id],
   [idioma_nombre]
  )
 VALUES
  (
   @pidioma_id,
   @pidioma_nombre
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Idiomas_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Idiomas_Actualizar]
GO

CREATE PROCEDURE SP_Idiomas_Actualizar
 (
  @pidioma_id uniqueidentifier,
  @pidioma_nombre varchar(20)
 )

AS

 UPDATE
  [Idiomas]
 SET
  [idioma_id] = @pidioma_id,
  [idioma_nombre] = @pidioma_nombre
 WHERE
  [idioma_id] = @pidioma_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Idiomas_Borrar]'))
DROP PROCEDURE [dbo].[SP_Idiomas_Borrar]
GO

CREATE PROCEDURE SP_Idiomas_Borrar
 (
  @pidioma_id uniqueidentifier
 )

AS

 DELETE FROM
  [Idiomas]
 WHERE
  (
   [idioma_id] = @pidioma_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Idiomas_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Idiomas_ConsultarTodos]
GO

CREATE PROCEDURE SP_Idiomas_ConsultarTodos

AS

 SELECT
  [idioma_id],
  [idioma_nombre]
 FROM
  [Idiomas]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Idiomas_Consultar]'))
DROP PROCEDURE [dbo].[SP_Idiomas_Consultar]
GO

CREATE PROCEDURE SP_Idiomas_Consultar
 (
  @pidioma_id uniqueidentifier
 )

AS

 SELECT
  [idioma_id],
  [idioma_nombre]
 FROM
  [Idiomas]
 WHERE
  (
   [idioma_id] = @pidioma_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Idiomas_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Idiomas_ConsultarPor]
GO

CREATE PROCEDURE SP_Idiomas_ConsultarPor
 (
  @pidioma_id uniqueidentifier = NULL,
  @pidioma_nombre varchar(20) = NULL
 )

AS

  SELECT
   [idioma_id],
   [idioma_nombre]
  FROM
   [Idiomas] WITH(NOLOCK)
  WHERE
   (
    (@pidioma_id IS NULL OR [idioma_id] = @pidioma_id)
     AND
    (@pidioma_nombre IS NULL OR [idioma_nombre] LIKE ('%' + @pidioma_nombre + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Leyendas]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Leyendas_Insertar]'))
DROP PROCEDURE [dbo].[SP_Leyendas_Insertar]
GO

CREATE PROCEDURE SP_Leyendas_Insertar
 (
  @pley_id uniqueidentifier,
  @pley_clase_contenedor varchar(30),
  @pley_objeto varchar(30),
  @pley_indice int,
  @pley_idioma_id uniqueidentifier,
  @pley_texto1 varchar(500),
  @pley_texto2 varchar(500),
  @pley_texto3 varchar(500),
  @pley_tooltip varchar(200),
  @pley_typeof varchar(50)
 )

AS

 INSERT INTO [Leyendas]
  (
   [ley_id],
   [ley_clase_contenedor],
   [ley_objeto],
   [ley_indice],
   [ley_idioma_id],
   [ley_texto1],
   [ley_texto2],
   [ley_texto3],
   [ley_tooltip],
   [ley_typeof]
  )
 VALUES
  (
   @pley_id,
   @pley_clase_contenedor,
   @pley_objeto,
   @pley_indice,
   @pley_idioma_id,
   @pley_texto1,
   @pley_texto2,
   @pley_texto3,
   @pley_tooltip,
   @pley_typeof
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Leyendas_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Leyendas_Actualizar]
GO

CREATE PROCEDURE SP_Leyendas_Actualizar
 (
  @pley_id uniqueidentifier,
  @pley_clase_contenedor varchar(30),
  @pley_objeto varchar(30),
  @pley_indice int,
  @pley_idioma_id uniqueidentifier,
  @pley_texto1 varchar(500),
  @pley_texto2 varchar(500),
  @pley_texto3 varchar(500),
  @pley_tooltip varchar(200),
  @pley_typeof varchar(50)
 )

AS

 UPDATE
  [Leyendas]
 SET
  [ley_id] = @pley_id,
  [ley_clase_contenedor] = @pley_clase_contenedor,
  [ley_objeto] = @pley_objeto,
  [ley_indice] = @pley_indice,
  [ley_idioma_id] = @pley_idioma_id,
  [ley_texto1] = @pley_texto1,
  [ley_texto2] = @pley_texto2,
  [ley_texto3] = @pley_texto3,
  [ley_tooltip] = @pley_tooltip,
  [ley_typeof] = @pley_typeof
 WHERE
  [ley_id] = @pley_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Leyendas_Borrar]'))
DROP PROCEDURE [dbo].[SP_Leyendas_Borrar]
GO

CREATE PROCEDURE SP_Leyendas_Borrar
 (
  @pley_id uniqueidentifier
 )

AS

 DELETE FROM
  [Leyendas]
 WHERE
  (
   [ley_id] = @pley_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Leyendas_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Leyendas_ConsultarTodos]
GO

CREATE PROCEDURE SP_Leyendas_ConsultarTodos

AS

 SELECT
  [ley_id],
  [ley_clase_contenedor],
  [ley_objeto],
  [ley_indice],
  [ley_idioma_id],
  [ley_texto1],
  [ley_texto2],
  [ley_texto3],
  [ley_tooltip],
  [ley_typeof]
 FROM
  [Leyendas]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Leyendas_Consultar]'))
DROP PROCEDURE [dbo].[SP_Leyendas_Consultar]
GO

CREATE PROCEDURE SP_Leyendas_Consultar
 (
  @pley_id uniqueidentifier
 )

AS

 SELECT
  [ley_id],
  [ley_clase_contenedor],
  [ley_objeto],
  [ley_indice],
  [ley_idioma_id],
  [ley_texto1],
  [ley_texto2],
  [ley_texto3],
  [ley_tooltip],
  [ley_typeof]
 FROM
  [Leyendas]
 WHERE
  (
   [ley_id] = @pley_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Leyendas_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Leyendas_ConsultarPor]
GO

CREATE PROCEDURE SP_Leyendas_ConsultarPor
 (
  @pley_id uniqueidentifier = NULL,
  @pley_clase_contenedor varchar(30) = NULL,
  @pley_objeto varchar(30) = NULL,
  @pley_indice int = NULL,
  @pley_idioma_id uniqueidentifier = NULL,
  @pley_texto1 varchar(500) = NULL,
  @pley_texto2 varchar(500) = NULL,
  @pley_texto3 varchar(500) = NULL,
  @pley_tooltip varchar(200) = NULL,
  @pley_typeof varchar(50) = NULL
 )

AS

  SELECT
   [ley_id],
   [ley_clase_contenedor],
   [ley_objeto],
   [ley_indice],
   [ley_idioma_id],
   [ley_texto1],
   [ley_texto2],
   [ley_texto3],
   [ley_tooltip],
   [ley_typeof]
  FROM
   [Leyendas] WITH(NOLOCK)
  WHERE
   (
    (@pley_id IS NULL OR [ley_id] = @pley_id)
     AND
    (@pley_clase_contenedor IS NULL OR [ley_clase_contenedor] LIKE ('%' + @pley_clase_contenedor + '%'))
     AND
    (@pley_objeto IS NULL OR [ley_objeto] LIKE ('%' + @pley_objeto + '%'))
     AND
    (@pley_indice IS NULL OR [ley_indice] = @pley_indice)
     AND
    (@pley_idioma_id IS NULL OR [ley_idioma_id] = @pley_idioma_id)
     AND
    (@pley_texto1 IS NULL OR [ley_texto1] LIKE ('%' + @pley_texto1 + '%'))
     AND
    (@pley_texto2 IS NULL OR [ley_texto2] LIKE ('%' + @pley_texto2 + '%'))
     AND
    (@pley_texto3 IS NULL OR [ley_texto3] LIKE ('%' + @pley_texto3 + '%'))
     AND
    (@pley_tooltip IS NULL OR [ley_tooltip] LIKE ('%' + @pley_tooltip + '%'))
     AND
    (@pley_typeof IS NULL OR [ley_typeof] LIKE ('%' + @pley_typeof + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Localidades]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Localidades_Insertar]'))
DROP PROCEDURE [dbo].[SP_Localidades_Insertar]
GO

CREATE PROCEDURE SP_Localidades_Insertar
 (
  @ploc_id uniqueidentifier,
  @ploc_nombre varchar(50),
  @ploc_cp varchar(50),
  @ploc_prov_id uniqueidentifier
 )

AS

 INSERT INTO [Localidades]
  (
   [loc_id],
   [loc_nombre],
   [loc_cp],
   [loc_prov_id]
  )
 VALUES
  (
   @ploc_id,
   @ploc_nombre,
   @ploc_cp,
   @ploc_prov_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Localidades_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Localidades_Actualizar]
GO

CREATE PROCEDURE SP_Localidades_Actualizar
 (
  @ploc_id uniqueidentifier,
  @ploc_nombre varchar(50),
  @ploc_cp varchar(50),
  @ploc_prov_id uniqueidentifier
 )

AS

 UPDATE
  [Localidades]
 SET
  [loc_id] = @ploc_id,
  [loc_nombre] = @ploc_nombre,
  [loc_cp] = @ploc_cp,
  [loc_prov_id] = @ploc_prov_id
 WHERE
  [loc_id] = @ploc_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Localidades_Borrar]'))
DROP PROCEDURE [dbo].[SP_Localidades_Borrar]
GO

CREATE PROCEDURE SP_Localidades_Borrar
 (
  @ploc_id uniqueidentifier
 )

AS

 DELETE FROM
  [Localidades]
 WHERE
  (
   [loc_id] = @ploc_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Localidades_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Localidades_ConsultarTodos]
GO

CREATE PROCEDURE SP_Localidades_ConsultarTodos

AS

 SELECT
  [loc_id],
  [loc_nombre],
  [loc_cp],
  [loc_prov_id]
 FROM
  [Localidades]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Localidades_Consultar]'))
DROP PROCEDURE [dbo].[SP_Localidades_Consultar]
GO

CREATE PROCEDURE SP_Localidades_Consultar
 (
  @ploc_id uniqueidentifier
 )

AS

 SELECT
  [loc_id],
  [loc_nombre],
  [loc_cp],
  [loc_prov_id]
 FROM
  [Localidades]
 WHERE
  (
   [loc_id] = @ploc_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Localidades_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Localidades_ConsultarPor]
GO

CREATE PROCEDURE SP_Localidades_ConsultarPor
 (
  @ploc_id uniqueidentifier = NULL,
  @ploc_nombre varchar(50) = NULL,
  @ploc_cp varchar(50) = NULL,
  @ploc_prov_id uniqueidentifier = NULL
 )

AS

  SELECT
   [loc_id],
   [loc_nombre],
   [loc_cp],
   [loc_prov_id]
  FROM
   [Localidades] WITH(NOLOCK)
  WHERE
   (
    (@ploc_id IS NULL OR [loc_id] = @ploc_id)
     AND
    (@ploc_nombre IS NULL OR [loc_nombre] LIKE ('%' + @ploc_nombre + '%'))
     AND
    (@ploc_cp IS NULL OR [loc_cp] LIKE ('%' + @ploc_cp + '%'))
     AND
    (@ploc_prov_id IS NULL OR [loc_prov_id] = @ploc_prov_id)
   )

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

--------------------------------------------------
PRINT ('Creating store procedure for [MesaAyuda]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_MesaAyuda_Insertar]'))
DROP PROCEDURE [dbo].[SP_MesaAyuda_Insertar]
GO

CREATE PROCEDURE SP_MesaAyuda_Insertar
 (
  @payu_id uniqueidentifier,
  @payu_pregunta varchar(500),
  @payu_psi int,
  @payu_pno int,
  @payu_res_id uniqueidentifier
 )

AS

 INSERT INTO [MesaAyuda]
  (
   [ayu_id],
   [ayu_pregunta],
   [ayu_psi],
   [ayu_pno],
   [ayu_res_id]
  )
 VALUES
  (
   @payu_id,
   @payu_pregunta,
   @payu_psi,
   @payu_pno,
   @payu_res_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_MesaAyuda_Actualizar]'))
DROP PROCEDURE [dbo].[SP_MesaAyuda_Actualizar]
GO

CREATE PROCEDURE SP_MesaAyuda_Actualizar
 (
  @payu_id uniqueidentifier,
  @payu_pregunta varchar(500),
  @payu_psi int,
  @payu_pno int,
  @payu_res_id uniqueidentifier
 )

AS

 UPDATE
  [MesaAyuda]
 SET
  [ayu_id] = @payu_id,
  [ayu_pregunta] = @payu_pregunta,
  [ayu_psi] = @payu_psi,
  [ayu_pno] = @payu_pno,
  [ayu_res_id] = @payu_res_id
 WHERE
  [ayu_id] = @payu_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_MesaAyuda_Borrar]'))
DROP PROCEDURE [dbo].[SP_MesaAyuda_Borrar]
GO

CREATE PROCEDURE SP_MesaAyuda_Borrar
 (
  @payu_id uniqueidentifier
 )

AS

 DELETE FROM
  [MesaAyuda]
 WHERE
  (
   [ayu_id] = @payu_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_MesaAyuda_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_MesaAyuda_ConsultarTodos]
GO

CREATE PROCEDURE SP_MesaAyuda_ConsultarTodos

AS

 SELECT
  [ayu_id],
  [ayu_pregunta],
  [ayu_psi],
  [ayu_pno],
  [ayu_res_id]
 FROM
  [MesaAyuda]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_MesaAyuda_Consultar]'))
DROP PROCEDURE [dbo].[SP_MesaAyuda_Consultar]
GO

CREATE PROCEDURE SP_MesaAyuda_Consultar
 (
  @payu_id uniqueidentifier
 )

AS

 SELECT
  [ayu_id],
  [ayu_pregunta],
  [ayu_psi],
  [ayu_pno],
  [ayu_res_id]
 FROM
  [MesaAyuda]
 WHERE
  (
   [ayu_id] = @payu_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_MesaAyuda_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_MesaAyuda_ConsultarPor]
GO

CREATE PROCEDURE SP_MesaAyuda_ConsultarPor
 (
  @payu_id uniqueidentifier = NULL,
  @payu_pregunta varchar(500) = NULL,
  @payu_psi int = NULL,
  @payu_pno int = NULL,
  @payu_res_id uniqueidentifier = NULL
 )

AS

  SELECT
   [ayu_id],
   [ayu_pregunta],
   [ayu_psi],
   [ayu_pno],
   [ayu_res_id]
  FROM
   [MesaAyuda] WITH(NOLOCK)
  WHERE
   (
    (@payu_id IS NULL OR [ayu_id] = @payu_id)
     AND
    (@payu_pregunta IS NULL OR [ayu_pregunta] LIKE ('%' + @payu_pregunta + '%'))
     AND
    (@payu_psi IS NULL OR [ayu_psi] = @payu_psi)
     AND
    (@payu_pno IS NULL OR [ayu_pno] = @payu_pno)
     AND
    (@payu_res_id IS NULL OR [ayu_res_id] = @payu_res_id)
   )

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
  @pmon_cambio_dolar int
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
  @pmon_cambio_dolar int
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
  @pmon_cambio_dolar int = NULL
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

--------------------------------------------------
PRINT ('Creating store procedure for [MovimientosStock]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_MovimientosStock_Insertar]'))
DROP PROCEDURE [dbo].[SP_MovimientosStock_Insertar]
GO

CREATE PROCEDURE SP_MovimientosStock_Insertar
 (
  @pms_id uniqueidentifier,
  @pms_fecha datetime,
  @pms_prod_id uniqueidentifier,
  @pms_vent_id uniqueidentifier,
  @pms_tipo varchar(50),
  @pms_cantidad int,
  @pms_monto numeric(18,0),
  @pms_oc_id uniqueidentifier
 )

AS

 INSERT INTO [MovimientosStock]
  (
   [ms_id],
   [ms_fecha],
   [ms_prod_id],
   [ms_vent_id],
   [ms_tipo],
   [ms_cantidad],
   [ms_monto],
   [ms_oc_id]
  )
 VALUES
  (
   @pms_id,
   @pms_fecha,
   @pms_prod_id,
   @pms_vent_id,
   @pms_tipo,
   @pms_cantidad,
   @pms_monto,
   @pms_oc_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_MovimientosStock_Actualizar]'))
DROP PROCEDURE [dbo].[SP_MovimientosStock_Actualizar]
GO

CREATE PROCEDURE SP_MovimientosStock_Actualizar
 (
  @pms_id uniqueidentifier,
  @pms_fecha datetime,
  @pms_prod_id uniqueidentifier,
  @pms_vent_id uniqueidentifier,
  @pms_tipo varchar(50),
  @pms_cantidad int,
  @pms_monto numeric(18,0),
  @pms_oc_id uniqueidentifier
 )

AS

 UPDATE
  [MovimientosStock]
 SET
  [ms_id] = @pms_id,
  [ms_fecha] = @pms_fecha,
  [ms_prod_id] = @pms_prod_id,
  [ms_vent_id] = @pms_vent_id,
  [ms_tipo] = @pms_tipo,
  [ms_cantidad] = @pms_cantidad,
  [ms_monto] = @pms_monto,
  [ms_oc_id] = @pms_oc_id
 WHERE
  [ms_id] = @pms_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_MovimientosStock_Borrar]'))
DROP PROCEDURE [dbo].[SP_MovimientosStock_Borrar]
GO

CREATE PROCEDURE SP_MovimientosStock_Borrar
 (
  @pms_id uniqueidentifier
 )

AS

 DELETE FROM
  [MovimientosStock]
 WHERE
  (
   [ms_id] = @pms_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_MovimientosStock_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_MovimientosStock_ConsultarTodos]
GO

CREATE PROCEDURE SP_MovimientosStock_ConsultarTodos

AS

 SELECT
  [ms_id],
  [ms_fecha],
  [ms_prod_id],
  [ms_vent_id],
  [ms_tipo],
  [ms_cantidad],
  [ms_monto],
  [ms_oc_id]
 FROM
  [MovimientosStock]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_MovimientosStock_Consultar]'))
DROP PROCEDURE [dbo].[SP_MovimientosStock_Consultar]
GO

CREATE PROCEDURE SP_MovimientosStock_Consultar
 (
  @pms_id uniqueidentifier
 )

AS

 SELECT
  [ms_id],
  [ms_fecha],
  [ms_prod_id],
  [ms_vent_id],
  [ms_tipo],
  [ms_cantidad],
  [ms_monto],
  [ms_oc_id]
 FROM
  [MovimientosStock]
 WHERE
  (
   [ms_id] = @pms_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_MovimientosStock_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_MovimientosStock_ConsultarPor]
GO

CREATE PROCEDURE SP_MovimientosStock_ConsultarPor
 (
  @pms_id uniqueidentifier = NULL,
  @pms_fecha datetime = NULL,
  @pms_prod_id uniqueidentifier = NULL,
  @pms_vent_id uniqueidentifier = NULL,
  @pms_tipo varchar(50) = NULL,
  @pms_cantidad int = NULL,
  @pms_monto numeric(18,0) = NULL,
  @pms_oc_id uniqueidentifier = NULL
 )

AS

  SELECT
   [ms_id],
   [ms_fecha],
   [ms_prod_id],
   [ms_vent_id],
   [ms_tipo],
   [ms_cantidad],
   [ms_monto],
   [ms_oc_id]
  FROM
   [MovimientosStock] WITH(NOLOCK)
  WHERE
   (
    (@pms_id IS NULL OR [ms_id] = @pms_id)
     AND
    (@pms_fecha IS NULL OR [ms_fecha] = @pms_fecha)
     AND
    (@pms_prod_id IS NULL OR [ms_prod_id] = @pms_prod_id)
     AND
    (@pms_vent_id IS NULL OR [ms_vent_id] = @pms_vent_id)
     AND
    (@pms_tipo IS NULL OR [ms_tipo] LIKE ('%' + @pms_tipo + '%'))
     AND
    (@pms_cantidad IS NULL OR [ms_cantidad] = @pms_cantidad)
     AND
    (@pms_monto IS NULL OR [ms_monto] = @pms_monto)
     AND
    (@pms_oc_id IS NULL OR [ms_oc_id] = @pms_oc_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Navegaciones]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Navegaciones_Insertar]'))
DROP PROCEDURE [dbo].[SP_Navegaciones_Insertar]
GO

CREATE PROCEDURE SP_Navegaciones_Insertar
 (
  @pnav_log_id uniqueidentifier,
  @pnav_pag_id uniqueidentifier
 )

AS

 INSERT INTO [Navegaciones]
  (
   [nav_log_id],
   [nav_pag_id]
  )
 VALUES
  (
   @pnav_log_id,
   @pnav_pag_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Navegaciones_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Navegaciones_Actualizar]
GO

CREATE PROCEDURE SP_Navegaciones_Actualizar
 (
  @pnav_log_id uniqueidentifier,
  @pnav_pag_id uniqueidentifier
 )

AS

 UPDATE
  [Navegaciones]
 SET
  [nav_log_id] = @pnav_log_id,
  [nav_pag_id] = @pnav_pag_id
 WHERE
  (
   [nav_log_id] = @pnav_log_id
    AND
   [nav_pag_id] = @pnav_pag_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Navegaciones_Borrar]'))
DROP PROCEDURE [dbo].[SP_Navegaciones_Borrar]
GO

CREATE PROCEDURE SP_Navegaciones_Borrar
 (
  @pnav_log_id uniqueidentifier,
  @pnav_pag_id uniqueidentifier
 )

AS

 DELETE FROM
  [Navegaciones]
 WHERE
  (
   [nav_log_id] = @pnav_log_id
    AND
   [nav_pag_id] = @pnav_pag_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Navegaciones_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Navegaciones_ConsultarTodos]
GO

CREATE PROCEDURE SP_Navegaciones_ConsultarTodos

AS

 SELECT
  [nav_log_id],
  [nav_pag_id]
 FROM
  [Navegaciones]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Navegaciones_Consultar]'))
DROP PROCEDURE [dbo].[SP_Navegaciones_Consultar]
GO

CREATE PROCEDURE SP_Navegaciones_Consultar
 (
  @pnav_log_id uniqueidentifier,
  @pnav_pag_id uniqueidentifier
 )

AS

 SELECT
  [nav_log_id],
  [nav_pag_id]
 FROM
  [Navegaciones]
 WHERE
  (
   [nav_log_id] = @pnav_log_id
    AND
   [nav_pag_id] = @pnav_pag_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Navegaciones_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Navegaciones_ConsultarPor]
GO

CREATE PROCEDURE SP_Navegaciones_ConsultarPor
 (
  @pnav_log_id uniqueidentifier = NULL,
  @pnav_pag_id uniqueidentifier = NULL
 )

AS

  SELECT
   [nav_log_id],
   [nav_pag_id]
  FROM
   [Navegaciones] WITH(NOLOCK)
  WHERE
   (
    (@pnav_log_id IS NULL OR [nav_log_id] = @pnav_log_id)
     AND
    (@pnav_pag_id IS NULL OR [nav_pag_id] = @pnav_pag_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Novedades]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Novedades_Insertar]'))
DROP PROCEDURE [dbo].[SP_Novedades_Insertar]
GO

CREATE PROCEDURE SP_Novedades_Insertar
 (
  @pnov_id uniqueidentifier,
  @pnov_titulo varchar(500),
  @pnov_descripcion varchar(max),
  @pnov_fecha_actualizacion datetime,
  @pnov_imagen image
 )

AS

 INSERT INTO [Novedades]
  (
   [nov_id],
   [nov_titulo],
   [nov_descripcion],
   [nov_fecha_actualizacion],
   [nov_imagen]
  )
 VALUES
  (
   @pnov_id,
   @pnov_titulo,
   @pnov_descripcion,
   @pnov_fecha_actualizacion,
   @pnov_imagen
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Novedades_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Novedades_Actualizar]
GO

CREATE PROCEDURE SP_Novedades_Actualizar
 (
  @pnov_id uniqueidentifier,
  @pnov_titulo varchar(500),
  @pnov_descripcion varchar(max),
  @pnov_fecha_actualizacion datetime,
  @pnov_imagen image
 )

AS

 UPDATE
  [Novedades]
 SET
  [nov_id] = @pnov_id,
  [nov_titulo] = @pnov_titulo,
  [nov_descripcion] = @pnov_descripcion,
  [nov_fecha_actualizacion] = @pnov_fecha_actualizacion,
  [nov_imagen] = @pnov_imagen
 WHERE
  [nov_id] = @pnov_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Novedades_Borrar]'))
DROP PROCEDURE [dbo].[SP_Novedades_Borrar]
GO

CREATE PROCEDURE SP_Novedades_Borrar
 (
  @pnov_id uniqueidentifier
 )

AS

 DELETE FROM
  [Novedades]
 WHERE
  (
   [nov_id] = @pnov_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Novedades_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Novedades_ConsultarTodos]
GO

CREATE PROCEDURE SP_Novedades_ConsultarTodos

AS

 SELECT
  [nov_id],
  [nov_titulo],
  [nov_descripcion],
  [nov_fecha_actualizacion],
  [nov_imagen]
 FROM
  [Novedades]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Novedades_Consultar]'))
DROP PROCEDURE [dbo].[SP_Novedades_Consultar]
GO

CREATE PROCEDURE SP_Novedades_Consultar
 (
  @pnov_id uniqueidentifier
 )

AS

 SELECT
  [nov_id],
  [nov_titulo],
  [nov_descripcion],
  [nov_fecha_actualizacion],
  [nov_imagen]
 FROM
  [Novedades]
 WHERE
  (
   [nov_id] = @pnov_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Novedades_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Novedades_ConsultarPor]
GO

CREATE PROCEDURE SP_Novedades_ConsultarPor
 (
  @pnov_id uniqueidentifier = NULL,
  @pnov_titulo varchar(500) = NULL,
  @pnov_descripcion varchar(max) = NULL,
  @pnov_fecha_actualizacion datetime = NULL
 )

AS

  SELECT
   [nov_id],
   [nov_titulo],
   [nov_descripcion],
   [nov_fecha_actualizacion],
   [nov_imagen]
  FROM
   [Novedades] WITH(NOLOCK)
  WHERE
   (
    (@pnov_id IS NULL OR [nov_id] = @pnov_id)
     AND
    (@pnov_titulo IS NULL OR [nov_titulo] LIKE ('%' + @pnov_titulo + '%'))
     AND
    (@pnov_descripcion IS NULL OR [nov_descripcion] LIKE ('%' + @pnov_descripcion + '%'))
     AND
    (@pnov_fecha_actualizacion IS NULL OR [nov_fecha_actualizacion] = @pnov_fecha_actualizacion)
    
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [OrdenesCompra]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_OrdenesCompra_Insertar]'))
DROP PROCEDURE [dbo].[SP_OrdenesCompra_Insertar]
GO

CREATE PROCEDURE SP_OrdenesCompra_Insertar
 (
  @poc_id uniqueidentifier,
  @poc_pagp_id uniqueidentifier,
  @poc_prov_id uniqueidentifier,
  @poc_fecha datetime,
  @poc_fecha_entrega datetime,
  @poc_monto_total numeric(18,0),
  @poc_condiciones_pago varchar(50),
  @poc_comentarios varchar(500),
  @poc_usu_id uniqueidentifier
 )

AS

 INSERT INTO [OrdenesCompra]
  (
   [oc_id],
   [oc_pagp_id],
   [oc_prov_id],
   [oc_fecha],
   [oc_fecha_entrega],
   [oc_monto_total],
   [oc_condiciones_pago],
   [oc_comentarios],
   [oc_usu_id]
  )
 VALUES
  (
   @poc_id,
   @poc_pagp_id,
   @poc_prov_id,
   @poc_fecha,
   @poc_fecha_entrega,
   @poc_monto_total,
   @poc_condiciones_pago,
   @poc_comentarios,
   @poc_usu_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_OrdenesCompra_Actualizar]'))
DROP PROCEDURE [dbo].[SP_OrdenesCompra_Actualizar]
GO

CREATE PROCEDURE SP_OrdenesCompra_Actualizar
 (
  @poc_id uniqueidentifier,
  @poc_pagp_id uniqueidentifier,
  @poc_prov_id uniqueidentifier,
  @poc_fecha datetime,
  @poc_fecha_entrega datetime,
  @poc_monto_total numeric(18,0),
  @poc_condiciones_pago varchar(50),
  @poc_comentarios varchar(500),
  @poc_usu_id uniqueidentifier
 )

AS

 UPDATE
  [OrdenesCompra]
 SET
  [oc_id] = @poc_id,
  [oc_pagp_id] = @poc_pagp_id,
  [oc_prov_id] = @poc_prov_id,
  [oc_fecha] = @poc_fecha,
  [oc_fecha_entrega] = @poc_fecha_entrega,
  [oc_monto_total] = @poc_monto_total,
  [oc_condiciones_pago] = @poc_condiciones_pago,
  [oc_comentarios] = @poc_comentarios,
  [oc_usu_id] = @poc_usu_id
 WHERE
  [oc_id] = @poc_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_OrdenesCompra_Borrar]'))
DROP PROCEDURE [dbo].[SP_OrdenesCompra_Borrar]
GO

CREATE PROCEDURE SP_OrdenesCompra_Borrar
 (
  @poc_id uniqueidentifier
 )

AS

 DELETE FROM
  [OrdenesCompra]
 WHERE
  (
   [oc_id] = @poc_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_OrdenesCompra_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_OrdenesCompra_ConsultarTodos]
GO

CREATE PROCEDURE SP_OrdenesCompra_ConsultarTodos

AS

 SELECT
  [oc_id],
  [oc_pagp_id],
  [oc_prov_id],
  [oc_fecha],
  [oc_fecha_entrega],
  [oc_monto_total],
  [oc_condiciones_pago],
  [oc_comentarios],
  [oc_usu_id]
 FROM
  [OrdenesCompra]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_OrdenesCompra_Consultar]'))
DROP PROCEDURE [dbo].[SP_OrdenesCompra_Consultar]
GO

CREATE PROCEDURE SP_OrdenesCompra_Consultar
 (
  @poc_id uniqueidentifier
 )

AS

 SELECT
  [oc_id],
  [oc_pagp_id],
  [oc_prov_id],
  [oc_fecha],
  [oc_fecha_entrega],
  [oc_monto_total],
  [oc_condiciones_pago],
  [oc_comentarios],
  [oc_usu_id]
 FROM
  [OrdenesCompra]
 WHERE
  (
   [oc_id] = @poc_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_OrdenesCompra_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_OrdenesCompra_ConsultarPor]
GO

CREATE PROCEDURE SP_OrdenesCompra_ConsultarPor
 (
  @poc_id uniqueidentifier = NULL,
  @poc_pagp_id uniqueidentifier = NULL,
  @poc_prov_id uniqueidentifier = NULL,
  @poc_fecha datetime = NULL,
  @poc_fecha_entrega datetime = NULL,
  @poc_monto_total numeric(18,0) = NULL,
  @poc_condiciones_pago varchar(50) = NULL,
  @poc_comentarios varchar(500) = NULL,
  @poc_usu_id uniqueidentifier = NULL
 )

AS

  SELECT
   [oc_id],
   [oc_pagp_id],
   [oc_prov_id],
   [oc_fecha],
   [oc_fecha_entrega],
   [oc_monto_total],
   [oc_condiciones_pago],
   [oc_comentarios],
   [oc_usu_id]
  FROM
   [OrdenesCompra] WITH(NOLOCK)
  WHERE
   (
    (@poc_id IS NULL OR [oc_id] = @poc_id)
     AND
    (@poc_pagp_id IS NULL OR [oc_pagp_id] = @poc_pagp_id)
     AND
    (@poc_prov_id IS NULL OR [oc_prov_id] = @poc_prov_id)
     AND
    (@poc_fecha IS NULL OR [oc_fecha] = @poc_fecha)
     AND
    (@poc_fecha_entrega IS NULL OR [oc_fecha_entrega] = @poc_fecha_entrega)
     AND
    (@poc_monto_total IS NULL OR [oc_monto_total] = @poc_monto_total)
     AND
    (@poc_condiciones_pago IS NULL OR [oc_condiciones_pago] LIKE ('%' + @poc_condiciones_pago + '%'))
     AND
    (@poc_comentarios IS NULL OR [oc_comentarios] LIKE ('%' + @poc_comentarios + '%'))
     AND
    (@poc_usu_id IS NULL OR [oc_usu_id] = @poc_usu_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [OrdenesCompraProductos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_OrdenesCompraProductos_Insertar]'))
DROP PROCEDURE [dbo].[SP_OrdenesCompraProductos_Insertar]
GO

CREATE PROCEDURE SP_OrdenesCompraProductos_Insertar
 (
  @pocp_id uniqueidentifier,
  @pocp_oc_id uniqueidentifier,
  @pocp_prod_id uniqueidentifier,
  @pocp_cantidad int
 )

AS

 INSERT INTO [OrdenesCompraProductos]
  (
   [ocp_id],
   [ocp_oc_id],
   [ocp_prod_id],
   [ocp_cantidad]
  )
 VALUES
  (
   @pocp_id,
   @pocp_oc_id,
   @pocp_prod_id,
   @pocp_cantidad
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_OrdenesCompraProductos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_OrdenesCompraProductos_Actualizar]
GO

CREATE PROCEDURE SP_OrdenesCompraProductos_Actualizar
 (
  @pocp_id uniqueidentifier,
  @pocp_oc_id uniqueidentifier,
  @pocp_prod_id uniqueidentifier,
  @pocp_cantidad int
 )

AS

 UPDATE
  [OrdenesCompraProductos]
 SET
  [ocp_id] = @pocp_id,
  [ocp_oc_id] = @pocp_oc_id,
  [ocp_prod_id] = @pocp_prod_id,
  [ocp_cantidad] = @pocp_cantidad
 WHERE
  [ocp_id] = @pocp_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_OrdenesCompraProductos_Borrar]'))
DROP PROCEDURE [dbo].[SP_OrdenesCompraProductos_Borrar]
GO

CREATE PROCEDURE SP_OrdenesCompraProductos_Borrar
 (
  @pocp_id uniqueidentifier
 )

AS

 DELETE FROM
  [OrdenesCompraProductos]
 WHERE
  (
   [ocp_id] = @pocp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_OrdenesCompraProductos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_OrdenesCompraProductos_ConsultarTodos]
GO

CREATE PROCEDURE SP_OrdenesCompraProductos_ConsultarTodos

AS

 SELECT
  [ocp_id],
  [ocp_oc_id],
  [ocp_prod_id],
  [ocp_cantidad]
 FROM
  [OrdenesCompraProductos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_OrdenesCompraProductos_Consultar]'))
DROP PROCEDURE [dbo].[SP_OrdenesCompraProductos_Consultar]
GO

CREATE PROCEDURE SP_OrdenesCompraProductos_Consultar
 (
  @pocp_id uniqueidentifier
 )

AS

 SELECT
  [ocp_id],
  [ocp_oc_id],
  [ocp_prod_id],
  [ocp_cantidad]
 FROM
  [OrdenesCompraProductos]
 WHERE
  (
   [ocp_id] = @pocp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_OrdenesCompraProductos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_OrdenesCompraProductos_ConsultarPor]
GO

CREATE PROCEDURE SP_OrdenesCompraProductos_ConsultarPor
 (
  @pocp_id uniqueidentifier = NULL,
  @pocp_oc_id uniqueidentifier = NULL,
  @pocp_prod_id uniqueidentifier = NULL,
  @pocp_cantidad int = NULL
 )

AS

  SELECT
   [ocp_id],
   [ocp_oc_id],
   [ocp_prod_id],
   [ocp_cantidad]
  FROM
   [OrdenesCompraProductos] WITH(NOLOCK)
  WHERE
   (
    (@pocp_id IS NULL OR [ocp_id] = @pocp_id)
     AND
    (@pocp_oc_id IS NULL OR [ocp_oc_id] = @pocp_oc_id)
     AND
    (@pocp_prod_id IS NULL OR [ocp_prod_id] = @pocp_prod_id)
     AND
    (@pocp_cantidad IS NULL OR [ocp_cantidad] = @pocp_cantidad)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Paginas]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Paginas_Insertar]'))
DROP PROCEDURE [dbo].[SP_Paginas_Insertar]
GO

CREATE PROCEDURE SP_Paginas_Insertar
 (
  @ppag_id uniqueidentifier,
  @ppag_nombre varchar(50),
  @ppag_descrip varchar(50)
 )

AS

 INSERT INTO [Paginas]
  (
   [pag_id],
   [pag_nombre],
   [pag_descrip]
  )
 VALUES
  (
   @ppag_id,
   @ppag_nombre,
   @ppag_descrip
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Paginas_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Paginas_Actualizar]
GO

CREATE PROCEDURE SP_Paginas_Actualizar
 (
  @ppag_id uniqueidentifier,
  @ppag_nombre varchar(50),
  @ppag_descrip varchar(50)
 )

AS

 UPDATE
  [Paginas]
 SET
  [pag_id] = @ppag_id,
  [pag_nombre] = @ppag_nombre,
  [pag_descrip] = @ppag_descrip
 WHERE
  [pag_id] = @ppag_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Paginas_Borrar]'))
DROP PROCEDURE [dbo].[SP_Paginas_Borrar]
GO

CREATE PROCEDURE SP_Paginas_Borrar
 (
  @ppag_id uniqueidentifier
 )

AS

 DELETE FROM
  [Paginas]
 WHERE
  (
   [pag_id] = @ppag_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Paginas_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Paginas_ConsultarTodos]
GO

CREATE PROCEDURE SP_Paginas_ConsultarTodos

AS

 SELECT
  [pag_id],
  [pag_nombre],
  [pag_descrip]
 FROM
  [Paginas]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Paginas_Consultar]'))
DROP PROCEDURE [dbo].[SP_Paginas_Consultar]
GO

CREATE PROCEDURE SP_Paginas_Consultar
 (
  @ppag_id uniqueidentifier
 )

AS

 SELECT
  [pag_id],
  [pag_nombre],
  [pag_descrip]
 FROM
  [Paginas]
 WHERE
  (
   [pag_id] = @ppag_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Paginas_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Paginas_ConsultarPor]
GO

CREATE PROCEDURE SP_Paginas_ConsultarPor
 (
  @ppag_id uniqueidentifier = NULL,
  @ppag_nombre varchar(50) = NULL,
  @ppag_descrip varchar(50) = NULL
 )

AS

  SELECT
   [pag_id],
   [pag_nombre],
   [pag_descrip]
  FROM
   [Paginas] WITH(NOLOCK)
  WHERE
   (
    (@ppag_id IS NULL OR [pag_id] = @ppag_id)
     AND
    (@ppag_nombre IS NULL OR [pag_nombre] LIKE ('%' + @ppag_nombre + '%'))
     AND
    (@ppag_descrip IS NULL OR [pag_descrip] LIKE ('%' + @ppag_descrip + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [PagosProveedores]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PagosProveedores_Insertar]'))
DROP PROCEDURE [dbo].[SP_PagosProveedores_Insertar]
GO

CREATE PROCEDURE SP_PagosProveedores_Insertar
 (
  @ppagp_id uniqueidentifier,
  @ppagp_proveedor_id uniqueidentifier,
  @ppagp_fecha datetime,
  @ppagp_monto numeric(18,0),
  @ppagp_nro_factura varchar(50),
  @ppagp_comentarios varchar(500)
 )

AS

 INSERT INTO [PagosProveedores]
  (
   [pagp_id],
   [pagp_proveedor_id],
   [pagp_fecha],
   [pagp_monto],
   [pagp_nro_factura],
   [pagp_comentarios]
  )
 VALUES
  (
   @ppagp_id,
   @ppagp_proveedor_id,
   @ppagp_fecha,
   @ppagp_monto,
   @ppagp_nro_factura,
   @ppagp_comentarios
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PagosProveedores_Actualizar]'))
DROP PROCEDURE [dbo].[SP_PagosProveedores_Actualizar]
GO

CREATE PROCEDURE SP_PagosProveedores_Actualizar
 (
  @ppagp_id uniqueidentifier,
  @ppagp_proveedor_id uniqueidentifier,
  @ppagp_fecha datetime,
  @ppagp_monto numeric(18,0),
  @ppagp_nro_factura varchar(50),
  @ppagp_comentarios varchar(500)
 )

AS

 UPDATE
  [PagosProveedores]
 SET
  [pagp_id] = @ppagp_id,
  [pagp_proveedor_id] = @ppagp_proveedor_id,
  [pagp_fecha] = @ppagp_fecha,
  [pagp_monto] = @ppagp_monto,
  [pagp_nro_factura] = @ppagp_nro_factura,
  [pagp_comentarios] = @ppagp_comentarios
 WHERE
  [pagp_id] = @ppagp_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PagosProveedores_Borrar]'))
DROP PROCEDURE [dbo].[SP_PagosProveedores_Borrar]
GO

CREATE PROCEDURE SP_PagosProveedores_Borrar
 (
  @ppagp_id uniqueidentifier
 )

AS

 DELETE FROM
  [PagosProveedores]
 WHERE
  (
   [pagp_id] = @ppagp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PagosProveedores_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_PagosProveedores_ConsultarTodos]
GO

CREATE PROCEDURE SP_PagosProveedores_ConsultarTodos

AS

 SELECT
  [pagp_id],
  [pagp_proveedor_id],
  [pagp_fecha],
  [pagp_monto],
  [pagp_nro_factura],
  [pagp_comentarios]
 FROM
  [PagosProveedores]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PagosProveedores_Consultar]'))
DROP PROCEDURE [dbo].[SP_PagosProveedores_Consultar]
GO

CREATE PROCEDURE SP_PagosProveedores_Consultar
 (
  @ppagp_id uniqueidentifier
 )

AS

 SELECT
  [pagp_id],
  [pagp_proveedor_id],
  [pagp_fecha],
  [pagp_monto],
  [pagp_nro_factura],
  [pagp_comentarios]
 FROM
  [PagosProveedores]
 WHERE
  (
   [pagp_id] = @ppagp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PagosProveedores_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_PagosProveedores_ConsultarPor]
GO

CREATE PROCEDURE SP_PagosProveedores_ConsultarPor
 (
  @ppagp_id uniqueidentifier = NULL,
  @ppagp_proveedor_id uniqueidentifier = NULL,
  @ppagp_fecha datetime = NULL,
  @ppagp_monto numeric(18,0) = NULL,
  @ppagp_nro_factura varchar(50) = NULL,
  @ppagp_comentarios varchar(500) = NULL
 )

AS

  SELECT
   [pagp_id],
   [pagp_proveedor_id],
   [pagp_fecha],
   [pagp_monto],
   [pagp_nro_factura],
   [pagp_comentarios]
  FROM
   [PagosProveedores] WITH(NOLOCK)
  WHERE
   (
    (@ppagp_id IS NULL OR [pagp_id] = @ppagp_id)
     AND
    (@ppagp_proveedor_id IS NULL OR [pagp_proveedor_id] = @ppagp_proveedor_id)
     AND
    (@ppagp_fecha IS NULL OR [pagp_fecha] = @ppagp_fecha)
     AND
    (@ppagp_monto IS NULL OR [pagp_monto] = @ppagp_monto)
     AND
    (@ppagp_nro_factura IS NULL OR [pagp_nro_factura] LIKE ('%' + @ppagp_nro_factura + '%'))
     AND
    (@ppagp_comentarios IS NULL OR [pagp_comentarios] LIKE ('%' + @ppagp_comentarios + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Paises]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Paises_Insertar]'))
DROP PROCEDURE [dbo].[SP_Paises_Insertar]
GO

CREATE PROCEDURE SP_Paises_Insertar
 (
  @ppais_id uniqueidentifier,
  @ppais_nacion varchar(50)
 )

AS

 INSERT INTO [Paises]
  (
   [pais_id],
   [pais_nacion]
  )
 VALUES
  (
   @ppais_id,
   @ppais_nacion
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Paises_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Paises_Actualizar]
GO

CREATE PROCEDURE SP_Paises_Actualizar
 (
  @ppais_id uniqueidentifier,
  @ppais_nacion varchar(50)
 )

AS

 UPDATE
  [Paises]
 SET
  [pais_id] = @ppais_id,
  [pais_nacion] = @ppais_nacion
 WHERE
  [pais_id] = @ppais_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Paises_Borrar]'))
DROP PROCEDURE [dbo].[SP_Paises_Borrar]
GO

CREATE PROCEDURE SP_Paises_Borrar
 (
  @ppais_id uniqueidentifier
 )

AS

 DELETE FROM
  [Paises]
 WHERE
  (
   [pais_id] = @ppais_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Paises_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Paises_ConsultarTodos]
GO

CREATE PROCEDURE SP_Paises_ConsultarTodos

AS

 SELECT
  [pais_id],
  [pais_nacion]
 FROM
  [Paises]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Paises_Consultar]'))
DROP PROCEDURE [dbo].[SP_Paises_Consultar]
GO

CREATE PROCEDURE SP_Paises_Consultar
 (
  @ppais_id uniqueidentifier
 )

AS

 SELECT
  [pais_id],
  [pais_nacion]
 FROM
  [Paises]
 WHERE
  (
   [pais_id] = @ppais_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Paises_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Paises_ConsultarPor]
GO

CREATE PROCEDURE SP_Paises_ConsultarPor
 (
  @ppais_id uniqueidentifier = NULL,
  @ppais_nacion varchar(50) = NULL
 )

AS

  SELECT
   [pais_id],
   [pais_nacion]
  FROM
   [Paises] WITH(NOLOCK)
  WHERE
   (
    (@ppais_id IS NULL OR [pais_id] = @ppais_id)
     AND
    (@ppais_nacion IS NULL OR [pais_nacion] LIKE ('%' + @ppais_nacion + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Patentes]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Patentes_Insertar]'))
DROP PROCEDURE [dbo].[SP_Patentes_Insertar]
GO

CREATE PROCEDURE SP_Patentes_Insertar
 (
  @ppat_id uniqueidentifier,
  @ppat_descrip varchar(50)
 )

AS

 INSERT INTO [Patentes]
  (
   [pat_id],
   [pat_descrip]
  )
 VALUES
  (
   @ppat_id,
   @ppat_descrip
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Patentes_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Patentes_Actualizar]
GO

CREATE PROCEDURE SP_Patentes_Actualizar
 (
  @ppat_id uniqueidentifier,
  @ppat_descrip varchar(50)
 )

AS

 UPDATE
  [Patentes]
 SET
  [pat_id] = @ppat_id,
  [pat_descrip] = @ppat_descrip
 WHERE
  [pat_id] = @ppat_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Patentes_Borrar]'))
DROP PROCEDURE [dbo].[SP_Patentes_Borrar]
GO

CREATE PROCEDURE SP_Patentes_Borrar
 (
  @ppat_id uniqueidentifier
 )

AS

 DELETE FROM
  [Patentes]
 WHERE
  (
   [pat_id] = @ppat_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Patentes_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Patentes_ConsultarTodos]
GO

CREATE PROCEDURE SP_Patentes_ConsultarTodos

AS

 SELECT
  [pat_id],
  [pat_descrip]
 FROM
  [Patentes]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Patentes_Consultar]'))
DROP PROCEDURE [dbo].[SP_Patentes_Consultar]
GO

CREATE PROCEDURE SP_Patentes_Consultar
 (
  @ppat_id uniqueidentifier
 )

AS

 SELECT
  [pat_id],
  [pat_descrip]
 FROM
  [Patentes]
 WHERE
  (
   [pat_id] = @ppat_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Patentes_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Patentes_ConsultarPor]
GO

CREATE PROCEDURE SP_Patentes_ConsultarPor
 (
  @ppat_id uniqueidentifier = NULL,
  @ppat_descrip varchar(50) = NULL
 )

AS

  SELECT
   [pat_id],
   [pat_descrip]
  FROM
   [Patentes] WITH(NOLOCK)
  WHERE
   (
    (@ppat_id IS NULL OR [pat_id] = @ppat_id)
     AND
    (@ppat_descrip IS NULL OR [pat_descrip] LIKE ('%' + @ppat_descrip + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [PatentesHabilitaciones]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PatentesHabilitaciones_Insertar]'))
DROP PROCEDURE [dbo].[SP_PatentesHabilitaciones_Insertar]
GO

CREATE PROCEDURE SP_PatentesHabilitaciones_Insertar
 (
  @pph_id uniqueidentifier,
  @pph_pat_id uniqueidentifier,
  @pph_objeto varchar(50),
  @pph_habilitado varchar(50)
 )

AS

 INSERT INTO [PatentesHabilitaciones]
  (
   [ph_id],
   [ph_pat_id],
   [ph_objeto],
   [ph_habilitado]
  )
 VALUES
  (
   @pph_id,
   @pph_pat_id,
   @pph_objeto,
   @pph_habilitado
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PatentesHabilitaciones_Actualizar]'))
DROP PROCEDURE [dbo].[SP_PatentesHabilitaciones_Actualizar]
GO

CREATE PROCEDURE SP_PatentesHabilitaciones_Actualizar
 (
  @pph_id uniqueidentifier,
  @pph_pat_id uniqueidentifier,
  @pph_objeto varchar(50),
  @pph_habilitado varchar(50)
 )

AS

 UPDATE
  [PatentesHabilitaciones]
 SET
  [ph_id] = @pph_id,
  [ph_pat_id] = @pph_pat_id,
  [ph_objeto] = @pph_objeto,
  [ph_habilitado] = @pph_habilitado
 WHERE
  [ph_id] = @pph_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PatentesHabilitaciones_Borrar]'))
DROP PROCEDURE [dbo].[SP_PatentesHabilitaciones_Borrar]
GO

CREATE PROCEDURE SP_PatentesHabilitaciones_Borrar
 (
  @pph_id uniqueidentifier
 )

AS

 DELETE FROM
  [PatentesHabilitaciones]
 WHERE
  (
   [ph_id] = @pph_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PatentesHabilitaciones_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_PatentesHabilitaciones_ConsultarTodos]
GO

CREATE PROCEDURE SP_PatentesHabilitaciones_ConsultarTodos

AS

 SELECT
  [ph_id],
  [ph_pat_id],
  [ph_objeto],
  [ph_habilitado]
 FROM
  [PatentesHabilitaciones]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PatentesHabilitaciones_Consultar]'))
DROP PROCEDURE [dbo].[SP_PatentesHabilitaciones_Consultar]
GO

CREATE PROCEDURE SP_PatentesHabilitaciones_Consultar
 (
  @pph_id uniqueidentifier
 )

AS

 SELECT
  [ph_id],
  [ph_pat_id],
  [ph_objeto],
  [ph_habilitado]
 FROM
  [PatentesHabilitaciones]
 WHERE
  (
   [ph_id] = @pph_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PatentesHabilitaciones_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_PatentesHabilitaciones_ConsultarPor]
GO

CREATE PROCEDURE SP_PatentesHabilitaciones_ConsultarPor
 (
  @pph_id uniqueidentifier = NULL,
  @pph_pat_id uniqueidentifier = NULL,
  @pph_objeto varchar(50) = NULL,
  @pph_habilitado varchar(50) = NULL
 )

AS

  SELECT
   [ph_id],
   [ph_pat_id],
   [ph_objeto],
   [ph_habilitado]
  FROM
   [PatentesHabilitaciones] WITH(NOLOCK)
  WHERE
   (
    (@pph_id IS NULL OR [ph_id] = @pph_id)
     AND
    (@pph_pat_id IS NULL OR [ph_pat_id] = @pph_pat_id)
     AND
    (@pph_objeto IS NULL OR [ph_objeto] LIKE ('%' + @pph_objeto + '%'))
     AND
    (@pph_habilitado IS NULL OR [ph_habilitado] LIKE ('%' + @pph_habilitado + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [PedidosCotizacion]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosCotizacion_Insertar]'))
DROP PROCEDURE [dbo].[SP_PedidosCotizacion_Insertar]
GO

CREATE PROCEDURE SP_PedidosCotizacion_Insertar
 (
  @ppc_id uniqueidentifier,
  @ppc_prov_id uniqueidentifier,
  @ppc_fecha datetime,
  @ppc_comentarios varchar(500),
  @ppc_usu_id uniqueidentifier
 )

AS

 INSERT INTO [PedidosCotizacion]
  (
   [pc_id],
   [pc_prov_id],
   [pc_fecha],
   [pc_comentarios],
   [pc_usu_id]
  )
 VALUES
  (
   @ppc_id,
   @ppc_prov_id,
   @ppc_fecha,
   @ppc_comentarios,
   @ppc_usu_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosCotizacion_Actualizar]'))
DROP PROCEDURE [dbo].[SP_PedidosCotizacion_Actualizar]
GO

CREATE PROCEDURE SP_PedidosCotizacion_Actualizar
 (
  @ppc_id uniqueidentifier,
  @ppc_prov_id uniqueidentifier,
  @ppc_fecha datetime,
  @ppc_comentarios varchar(500),
  @ppc_usu_id uniqueidentifier
 )

AS

 UPDATE
  [PedidosCotizacion]
 SET
  [pc_id] = @ppc_id,
  [pc_prov_id] = @ppc_prov_id,
  [pc_fecha] = @ppc_fecha,
  [pc_comentarios] = @ppc_comentarios,
  [pc_usu_id] = @ppc_usu_id
 WHERE
  [pc_id] = @ppc_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosCotizacion_Borrar]'))
DROP PROCEDURE [dbo].[SP_PedidosCotizacion_Borrar]
GO

CREATE PROCEDURE SP_PedidosCotizacion_Borrar
 (
  @ppc_id uniqueidentifier
 )

AS

 DELETE FROM
  [PedidosCotizacion]
 WHERE
  (
   [pc_id] = @ppc_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosCotizacion_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_PedidosCotizacion_ConsultarTodos]
GO

CREATE PROCEDURE SP_PedidosCotizacion_ConsultarTodos

AS

 SELECT
  [pc_id],
  [pc_prov_id],
  [pc_fecha],
  [pc_comentarios],
  [pc_usu_id]
 FROM
  [PedidosCotizacion]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosCotizacion_Consultar]'))
DROP PROCEDURE [dbo].[SP_PedidosCotizacion_Consultar]
GO

CREATE PROCEDURE SP_PedidosCotizacion_Consultar
 (
  @ppc_id uniqueidentifier
 )

AS

 SELECT
  [pc_id],
  [pc_prov_id],
  [pc_fecha],
  [pc_comentarios],
  [pc_usu_id]
 FROM
  [PedidosCotizacion]
 WHERE
  (
   [pc_id] = @ppc_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosCotizacion_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_PedidosCotizacion_ConsultarPor]
GO

CREATE PROCEDURE SP_PedidosCotizacion_ConsultarPor
 (
  @ppc_id uniqueidentifier = NULL,
  @ppc_prov_id uniqueidentifier = NULL,
  @ppc_fecha datetime = NULL,
  @ppc_comentarios varchar(500) = NULL,
  @ppc_usu_id uniqueidentifier = NULL
 )

AS

  SELECT
   [pc_id],
   [pc_prov_id],
   [pc_fecha],
   [pc_comentarios],
   [pc_usu_id]
  FROM
   [PedidosCotizacion] WITH(NOLOCK)
  WHERE
   (
    (@ppc_id IS NULL OR [pc_id] = @ppc_id)
     AND
    (@ppc_prov_id IS NULL OR [pc_prov_id] = @ppc_prov_id)
     AND
    (@ppc_fecha IS NULL OR [pc_fecha] = @ppc_fecha)
     AND
    (@ppc_comentarios IS NULL OR [pc_comentarios] LIKE ('%' + @ppc_comentarios + '%'))
     AND
    (@ppc_usu_id IS NULL OR [pc_usu_id] = @ppc_usu_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [PedidosCotizacionProductos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosCotizacionProductos_Insertar]'))
DROP PROCEDURE [dbo].[SP_PedidosCotizacionProductos_Insertar]
GO

CREATE PROCEDURE SP_PedidosCotizacionProductos_Insertar
 (
  @ppcp_id uniqueidentifier,
  @ppcp_pc_id uniqueidentifier,
  @ppcp_cantidad int
 )

AS

 INSERT INTO [PedidosCotizacionProductos]
  (
   [pcp_id],
   [pcp_pc_id],
   [pcp_cantidad]
  )
 VALUES
  (
   @ppcp_id,
   @ppcp_pc_id,
   @ppcp_cantidad
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosCotizacionProductos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_PedidosCotizacionProductos_Actualizar]
GO

CREATE PROCEDURE SP_PedidosCotizacionProductos_Actualizar
 (
  @ppcp_id uniqueidentifier,
  @ppcp_pc_id uniqueidentifier,
  @ppcp_cantidad int
 )

AS

 UPDATE
  [PedidosCotizacionProductos]
 SET
  [pcp_id] = @ppcp_id,
  [pcp_pc_id] = @ppcp_pc_id,
  [pcp_cantidad] = @ppcp_cantidad
 WHERE
  [pcp_id] = @ppcp_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosCotizacionProductos_Borrar]'))
DROP PROCEDURE [dbo].[SP_PedidosCotizacionProductos_Borrar]
GO

CREATE PROCEDURE SP_PedidosCotizacionProductos_Borrar
 (
  @ppcp_id uniqueidentifier
 )

AS

 DELETE FROM
  [PedidosCotizacionProductos]
 WHERE
  (
   [pcp_id] = @ppcp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosCotizacionProductos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_PedidosCotizacionProductos_ConsultarTodos]
GO

CREATE PROCEDURE SP_PedidosCotizacionProductos_ConsultarTodos

AS

 SELECT
  [pcp_id],
  [pcp_pc_id],
  [pcp_cantidad]
 FROM
  [PedidosCotizacionProductos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosCotizacionProductos_Consultar]'))
DROP PROCEDURE [dbo].[SP_PedidosCotizacionProductos_Consultar]
GO

CREATE PROCEDURE SP_PedidosCotizacionProductos_Consultar
 (
  @ppcp_id uniqueidentifier
 )

AS

 SELECT
  [pcp_id],
  [pcp_pc_id],
  [pcp_cantidad]
 FROM
  [PedidosCotizacionProductos]
 WHERE
  (
   [pcp_id] = @ppcp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosCotizacionProductos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_PedidosCotizacionProductos_ConsultarPor]
GO

CREATE PROCEDURE SP_PedidosCotizacionProductos_ConsultarPor
 (
  @ppcp_id uniqueidentifier = NULL,
  @ppcp_pc_id uniqueidentifier = NULL,
  @ppcp_cantidad int = NULL
 )

AS

  SELECT
   [pcp_id],
   [pcp_pc_id],
   [pcp_cantidad]
  FROM
   [PedidosCotizacionProductos] WITH(NOLOCK)
  WHERE
   (
    (@ppcp_id IS NULL OR [pcp_id] = @ppcp_id)
     AND
    (@ppcp_pc_id IS NULL OR [pcp_pc_id] = @ppcp_pc_id)
     AND
    (@ppcp_cantidad IS NULL OR [pcp_cantidad] = @ppcp_cantidad)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [PedidosReaprovisionamiento]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosReaprovisionamiento_Insertar]'))
DROP PROCEDURE [dbo].[SP_PedidosReaprovisionamiento_Insertar]
GO

CREATE PROCEDURE SP_PedidosReaprovisionamiento_Insertar
 (
  @ppra_id uniqueidentifier,
  @ppra_oc_id uniqueidentifier,
  @ppra_usu_id uniqueidentifier,
  @ppra_fecha datetime
 )

AS

 INSERT INTO [PedidosReaprovisionamiento]
  (
   [pra_id],
   [pra_oc_id],
   [pra_usu_id],
   [pra_fecha]
  )
 VALUES
  (
   @ppra_id,
   @ppra_oc_id,
   @ppra_usu_id,
   @ppra_fecha
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosReaprovisionamiento_Actualizar]'))
DROP PROCEDURE [dbo].[SP_PedidosReaprovisionamiento_Actualizar]
GO

CREATE PROCEDURE SP_PedidosReaprovisionamiento_Actualizar
 (
  @ppra_id uniqueidentifier,
  @ppra_oc_id uniqueidentifier,
  @ppra_usu_id uniqueidentifier,
  @ppra_fecha datetime
 )

AS

 UPDATE
  [PedidosReaprovisionamiento]
 SET
  [pra_id] = @ppra_id,
  [pra_oc_id] = @ppra_oc_id,
  [pra_usu_id] = @ppra_usu_id,
  [pra_fecha] = @ppra_fecha
 WHERE
  [pra_id] = @ppra_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosReaprovisionamiento_Borrar]'))
DROP PROCEDURE [dbo].[SP_PedidosReaprovisionamiento_Borrar]
GO

CREATE PROCEDURE SP_PedidosReaprovisionamiento_Borrar
 (
  @ppra_id uniqueidentifier
 )

AS

 DELETE FROM
  [PedidosReaprovisionamiento]
 WHERE
  (
   [pra_id] = @ppra_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosReaprovisionamiento_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_PedidosReaprovisionamiento_ConsultarTodos]
GO

CREATE PROCEDURE SP_PedidosReaprovisionamiento_ConsultarTodos

AS

 SELECT
  [pra_id],
  [pra_oc_id],
  [pra_usu_id],
  [pra_fecha]
 FROM
  [PedidosReaprovisionamiento]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosReaprovisionamiento_Consultar]'))
DROP PROCEDURE [dbo].[SP_PedidosReaprovisionamiento_Consultar]
GO

CREATE PROCEDURE SP_PedidosReaprovisionamiento_Consultar
 (
  @ppra_id uniqueidentifier
 )

AS

 SELECT
  [pra_id],
  [pra_oc_id],
  [pra_usu_id],
  [pra_fecha]
 FROM
  [PedidosReaprovisionamiento]
 WHERE
  (
   [pra_id] = @ppra_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosReaprovisionamiento_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_PedidosReaprovisionamiento_ConsultarPor]
GO

CREATE PROCEDURE SP_PedidosReaprovisionamiento_ConsultarPor
 (
  @ppra_id uniqueidentifier = NULL,
  @ppra_oc_id uniqueidentifier = NULL,
  @ppra_usu_id uniqueidentifier = NULL,
  @ppra_fecha datetime = NULL
 )

AS

  SELECT
   [pra_id],
   [pra_oc_id],
   [pra_usu_id],
   [pra_fecha]
  FROM
   [PedidosReaprovisionamiento] WITH(NOLOCK)
  WHERE
   (
    (@ppra_id IS NULL OR [pra_id] = @ppra_id)
     AND
    (@ppra_oc_id IS NULL OR [pra_oc_id] = @ppra_oc_id)
     AND
    (@ppra_usu_id IS NULL OR [pra_usu_id] = @ppra_usu_id)
     AND
    (@ppra_fecha IS NULL OR [pra_fecha] = @ppra_fecha)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [PedidosReaprovisionamientoProductos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosReaprovisionamientoProductos_Insertar]'))
DROP PROCEDURE [dbo].[SP_PedidosReaprovisionamientoProductos_Insertar]
GO

CREATE PROCEDURE SP_PedidosReaprovisionamientoProductos_Insertar
 (
  @pprap_id uniqueidentifier,
  @pprap_pra_id uniqueidentifier,
  @pprap_prod_id uniqueidentifier,
  @pprap_cantidad int
 )

AS

 INSERT INTO [PedidosReaprovisionamientoProductos]
  (
   [prap_id],
   [prap_pra_id],
   [prap_prod_id],
   [prap_cantidad]
  )
 VALUES
  (
   @pprap_id,
   @pprap_pra_id,
   @pprap_prod_id,
   @pprap_cantidad
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosReaprovisionamientoProductos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_PedidosReaprovisionamientoProductos_Actualizar]
GO

CREATE PROCEDURE SP_PedidosReaprovisionamientoProductos_Actualizar
 (
  @pprap_id uniqueidentifier,
  @pprap_pra_id uniqueidentifier,
  @pprap_prod_id uniqueidentifier,
  @pprap_cantidad int
 )

AS

 UPDATE
  [PedidosReaprovisionamientoProductos]
 SET
  [prap_id] = @pprap_id,
  [prap_pra_id] = @pprap_pra_id,
  [prap_prod_id] = @pprap_prod_id,
  [prap_cantidad] = @pprap_cantidad
 WHERE
  [prap_id] = @pprap_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosReaprovisionamientoProductos_Borrar]'))
DROP PROCEDURE [dbo].[SP_PedidosReaprovisionamientoProductos_Borrar]
GO

CREATE PROCEDURE SP_PedidosReaprovisionamientoProductos_Borrar
 (
  @pprap_id uniqueidentifier
 )

AS

 DELETE FROM
  [PedidosReaprovisionamientoProductos]
 WHERE
  (
   [prap_id] = @pprap_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosReaprovisionamientoProductos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_PedidosReaprovisionamientoProductos_ConsultarTodos]
GO

CREATE PROCEDURE SP_PedidosReaprovisionamientoProductos_ConsultarTodos

AS

 SELECT
  [prap_id],
  [prap_pra_id],
  [prap_prod_id],
  [prap_cantidad]
 FROM
  [PedidosReaprovisionamientoProductos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosReaprovisionamientoProductos_Consultar]'))
DROP PROCEDURE [dbo].[SP_PedidosReaprovisionamientoProductos_Consultar]
GO

CREATE PROCEDURE SP_PedidosReaprovisionamientoProductos_Consultar
 (
  @pprap_id uniqueidentifier
 )

AS

 SELECT
  [prap_id],
  [prap_pra_id],
  [prap_prod_id],
  [prap_cantidad]
 FROM
  [PedidosReaprovisionamientoProductos]
 WHERE
  (
   [prap_id] = @pprap_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PedidosReaprovisionamientoProductos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_PedidosReaprovisionamientoProductos_ConsultarPor]
GO

CREATE PROCEDURE SP_PedidosReaprovisionamientoProductos_ConsultarPor
 (
  @pprap_id uniqueidentifier = NULL,
  @pprap_pra_id uniqueidentifier = NULL,
  @pprap_prod_id uniqueidentifier = NULL,
  @pprap_cantidad int = NULL
 )

AS

  SELECT
   [prap_id],
   [prap_pra_id],
   [prap_prod_id],
   [prap_cantidad]
  FROM
   [PedidosReaprovisionamientoProductos] WITH(NOLOCK)
  WHERE
   (
    (@pprap_id IS NULL OR [prap_id] = @pprap_id)
     AND
    (@pprap_pra_id IS NULL OR [prap_pra_id] = @pprap_pra_id)
     AND
    (@pprap_prod_id IS NULL OR [prap_prod_id] = @pprap_prod_id)
     AND
    (@pprap_cantidad IS NULL OR [prap_cantidad] = @pprap_cantidad)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Productos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Productos_Insertar]'))
DROP PROCEDURE [dbo].[SP_Productos_Insertar]
GO

CREATE PROCEDURE SP_Productos_Insertar
 (
  @pprod_id uniqueidentifier,
  @pprod_nombre varchar(50),
  @pprod_descrip varchar(max),
  @pprod_cantidad int,
  @pprod_moneda varchar(50),
  @pprod_precio numeric(18,0),
  @pprod_PMR int,
  @pprod_dimension varchar(50),
  @pprod_nacionalidad varchar(25),
  @pprod_fabricante varchar(50),
  @pprod_especificaciones varchar(max),
  @pprod_garantia varchar(50),
  @pprod_imagen image,
  @pprod_tprod_id uniqueidentifier
 )

AS

 INSERT INTO [Productos]
  (
   [prod_id],
   [prod_nombre],
   [prod_descrip],
   [prod_cantidad],
   [prod_moneda],
   [prod_precio],
   [prod_PMR],
   [prod_dimension],
   [prod_nacionalidad],
   [prod_fabricante],
   [prod_especificaciones],
   [prod_garantia],
   [prod_imagen],
   [prod_tprod_id]
  )
 VALUES
  (
   @pprod_id,
   @pprod_nombre,
   @pprod_descrip,
   @pprod_cantidad,
   @pprod_moneda,
   @pprod_precio,
   @pprod_PMR,
   @pprod_dimension,
   @pprod_nacionalidad,
   @pprod_fabricante,
   @pprod_especificaciones,
   @pprod_garantia,
   @pprod_imagen,
   @pprod_tprod_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Productos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Productos_Actualizar]
GO

CREATE PROCEDURE SP_Productos_Actualizar
 (
  @pprod_id uniqueidentifier,
  @pprod_nombre varchar(50),
  @pprod_descrip varchar(max),
  @pprod_cantidad int,
  @pprod_moneda varchar(50),
  @pprod_precio numeric(18,0),
  @pprod_PMR int,
  @pprod_dimension varchar(50),
  @pprod_nacionalidad varchar(25),
  @pprod_fabricante varchar(50),
  @pprod_especificaciones varchar(max),
  @pprod_garantia varchar(50),
  @pprod_imagen image,
  @pprod_tprod_id uniqueidentifier
 )

AS

 UPDATE
  [Productos]
 SET
  [prod_id] = @pprod_id,
  [prod_nombre] = @pprod_nombre,
  [prod_descrip] = @pprod_descrip,
  [prod_cantidad] = @pprod_cantidad,
  [prod_moneda] = @pprod_moneda,
  [prod_precio] = @pprod_precio,
  [prod_PMR] = @pprod_PMR,
  [prod_dimension] = @pprod_dimension,
  [prod_nacionalidad] = @pprod_nacionalidad,
  [prod_fabricante] = @pprod_fabricante,
  [prod_especificaciones] = @pprod_especificaciones,
  [prod_garantia] = @pprod_garantia,
  [prod_imagen] = @pprod_imagen,
  [prod_tprod_id] = @pprod_tprod_id
 WHERE
  [prod_id] = @pprod_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Productos_Borrar]'))
DROP PROCEDURE [dbo].[SP_Productos_Borrar]
GO

CREATE PROCEDURE SP_Productos_Borrar
 (
  @pprod_id uniqueidentifier
 )

AS

 DELETE FROM
  [Productos]
 WHERE
  (
   [prod_id] = @pprod_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Productos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Productos_ConsultarTodos]
GO

CREATE PROCEDURE SP_Productos_ConsultarTodos

AS

 SELECT
  [prod_id],
  [prod_nombre],
  [prod_descrip],
  [prod_cantidad],
  [prod_moneda],
  [prod_precio],
  [prod_PMR],
  [prod_dimension],
  [prod_nacionalidad],
  [prod_fabricante],
  [prod_especificaciones],
  [prod_garantia],
  [prod_imagen],
  [prod_tprod_id]
 FROM
  [Productos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Productos_Consultar]'))
DROP PROCEDURE [dbo].[SP_Productos_Consultar]
GO

CREATE PROCEDURE SP_Productos_Consultar
 (
  @pprod_id uniqueidentifier
 )

AS

 SELECT
  [prod_id],
  [prod_nombre],
  [prod_descrip],
  [prod_cantidad],
  [prod_moneda],
  [prod_precio],
  [prod_PMR],
  [prod_dimension],
  [prod_nacionalidad],
  [prod_fabricante],
  [prod_especificaciones],
  [prod_garantia],
  [prod_imagen],
  [prod_tprod_id]
 FROM
  [Productos]
 WHERE
  (
   [prod_id] = @pprod_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Productos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Productos_ConsultarPor]
GO

CREATE PROCEDURE SP_Productos_ConsultarPor
 (
  @pprod_id uniqueidentifier = NULL,
  @pprod_nombre varchar(50) = NULL,
  @pprod_descrip varchar(max) = NULL,
  @pprod_cantidad int = NULL,
  @pprod_moneda varchar(50) = NULL,
  @pprod_precio numeric(18,0) = NULL,
  @pprod_PMR int = NULL,
  @pprod_dimension varchar(50) = NULL,
  @pprod_nacionalidad varchar(25) = NULL,
  @pprod_fabricante varchar(50) = NULL,
  @pprod_especificaciones varchar(max) = NULL,
  @pprod_garantia varchar(50) = NULL ,
  @pprod_tprod_id uniqueidentifier = NULL
 )

AS

  SELECT
   [prod_id],
   [prod_nombre],
   [prod_descrip],
   [prod_cantidad],
   [prod_moneda],
   [prod_precio],
   [prod_PMR],
   [prod_dimension],
   [prod_nacionalidad],
   [prod_fabricante],
   [prod_especificaciones],
   [prod_garantia],
   [prod_imagen],
   [prod_tprod_id]
  FROM
   [Productos] WITH(NOLOCK)
  WHERE
   (
    (@pprod_id IS NULL OR [prod_id] = @pprod_id)
     AND
    (@pprod_nombre IS NULL OR [prod_nombre] LIKE ('%' + @pprod_nombre + '%'))
     AND
    (@pprod_descrip IS NULL OR [prod_descrip] LIKE ('%' + @pprod_descrip + '%'))
     AND
    (@pprod_cantidad IS NULL OR [prod_cantidad] = @pprod_cantidad)
     AND
    (@pprod_moneda IS NULL OR [prod_moneda] LIKE ('%' + @pprod_moneda + '%'))
     AND
    (@pprod_precio IS NULL OR [prod_precio] = @pprod_precio)
     AND
    (@pprod_PMR IS NULL OR [prod_PMR] = @pprod_PMR)
     AND
    (@pprod_dimension IS NULL OR [prod_dimension] LIKE ('%' + @pprod_dimension + '%'))
     AND
    (@pprod_nacionalidad IS NULL OR [prod_nacionalidad] LIKE ('%' + @pprod_nacionalidad + '%'))
     AND
    (@pprod_fabricante IS NULL OR [prod_fabricante] LIKE ('%' + @pprod_fabricante + '%'))
     AND
    (@pprod_especificaciones IS NULL OR [prod_especificaciones] LIKE ('%' + @pprod_especificaciones + '%'))
     AND
    (@pprod_garantia IS NULL OR [prod_garantia] LIKE ('%' + @pprod_garantia + '%'))    
     AND
    (@pprod_tprod_id IS NULL OR [prod_tprod_id] = @pprod_tprod_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Promociones]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Promociones_Insertar]'))
DROP PROCEDURE [dbo].[SP_Promociones_Insertar]
GO

CREATE PROCEDURE SP_Promociones_Insertar
 (
  @ppromo_id uniqueidentifier,
  @ppromo_nombre varchar(50),
  @ppromo_expiracion datetime,
  @ppromo_requisitos varchar(500)
 )

AS

 INSERT INTO [Promociones]
  (
   [promo_id],
   [promo_nombre],
   [promo_expiracion],
   [promo_requisitos]
  )
 VALUES
  (
   @ppromo_id,
   @ppromo_nombre,
   @ppromo_expiracion,
   @ppromo_requisitos
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Promociones_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Promociones_Actualizar]
GO

CREATE PROCEDURE SP_Promociones_Actualizar
 (
  @ppromo_id uniqueidentifier,
  @ppromo_nombre varchar(50),
  @ppromo_expiracion datetime,
  @ppromo_requisitos varchar(500)
 )

AS

 UPDATE
  [Promociones]
 SET
  [promo_id] = @ppromo_id,
  [promo_nombre] = @ppromo_nombre,
  [promo_expiracion] = @ppromo_expiracion,
  [promo_requisitos] = @ppromo_requisitos
 WHERE
  [promo_id] = @ppromo_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Promociones_Borrar]'))
DROP PROCEDURE [dbo].[SP_Promociones_Borrar]
GO

CREATE PROCEDURE SP_Promociones_Borrar
 (
  @ppromo_id uniqueidentifier
 )

AS

 DELETE FROM
  [Promociones]
 WHERE
  (
   [promo_id] = @ppromo_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Promociones_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Promociones_ConsultarTodos]
GO

CREATE PROCEDURE SP_Promociones_ConsultarTodos

AS

 SELECT
  [promo_id],
  [promo_nombre],
  [promo_expiracion],
  [promo_requisitos]
 FROM
  [Promociones]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Promociones_Consultar]'))
DROP PROCEDURE [dbo].[SP_Promociones_Consultar]
GO

CREATE PROCEDURE SP_Promociones_Consultar
 (
  @ppromo_id uniqueidentifier
 )

AS

 SELECT
  [promo_id],
  [promo_nombre],
  [promo_expiracion],
  [promo_requisitos]
 FROM
  [Promociones]
 WHERE
  (
   [promo_id] = @ppromo_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Promociones_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Promociones_ConsultarPor]
GO

CREATE PROCEDURE SP_Promociones_ConsultarPor
 (
  @ppromo_id uniqueidentifier = NULL,
  @ppromo_nombre varchar(50) = NULL,
  @ppromo_expiracion datetime = NULL,
  @ppromo_requisitos varchar(500) = NULL
 )

AS

  SELECT
   [promo_id],
   [promo_nombre],
   [promo_expiracion],
   [promo_requisitos]
  FROM
   [Promociones] WITH(NOLOCK)
  WHERE
   (
    (@ppromo_id IS NULL OR [promo_id] = @ppromo_id)
     AND
    (@ppromo_nombre IS NULL OR [promo_nombre] LIKE ('%' + @ppromo_nombre + '%'))
     AND
    (@ppromo_expiracion IS NULL OR [promo_expiracion] = @ppromo_expiracion)
     AND
    (@ppromo_requisitos IS NULL OR [promo_requisitos] LIKE ('%' + @ppromo_requisitos + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [PromocionesProductos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PromocionesProductos_Insertar]'))
DROP PROCEDURE [dbo].[SP_PromocionesProductos_Insertar]
GO

CREATE PROCEDURE SP_PromocionesProductos_Insertar
 (
  @ppromp_id uniqueidentifier,
  @ppromp_prod_id uniqueidentifier,
  @ppromp_promo_id uniqueidentifier,
  @ppromp_regalo bit,
  @ppromp_descuento int
 )

AS

 INSERT INTO [PromocionesProductos]
  (
   [promp_id],
   [promp_prod_id],
   [promp_promo_id],
   [promp_regalo],
   [promp_descuento]
  )
 VALUES
  (
   @ppromp_id,
   @ppromp_prod_id,
   @ppromp_promo_id,
   @ppromp_regalo,
   @ppromp_descuento
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PromocionesProductos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_PromocionesProductos_Actualizar]
GO

CREATE PROCEDURE SP_PromocionesProductos_Actualizar
 (
  @ppromp_id uniqueidentifier,
  @ppromp_prod_id uniqueidentifier,
  @ppromp_promo_id uniqueidentifier,
  @ppromp_regalo bit,
  @ppromp_descuento int
 )

AS

 UPDATE
  [PromocionesProductos]
 SET
  [promp_id] = @ppromp_id,
  [promp_prod_id] = @ppromp_prod_id,
  [promp_promo_id] = @ppromp_promo_id,
  [promp_regalo] = @ppromp_regalo,
  [promp_descuento] = @ppromp_descuento
 WHERE
  [promp_id] = @ppromp_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PromocionesProductos_Borrar]'))
DROP PROCEDURE [dbo].[SP_PromocionesProductos_Borrar]
GO

CREATE PROCEDURE SP_PromocionesProductos_Borrar
 (
  @ppromp_id uniqueidentifier
 )

AS

 DELETE FROM
  [PromocionesProductos]
 WHERE
  (
   [promp_id] = @ppromp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PromocionesProductos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_PromocionesProductos_ConsultarTodos]
GO

CREATE PROCEDURE SP_PromocionesProductos_ConsultarTodos

AS

 SELECT
  [promp_id],
  [promp_prod_id],
  [promp_promo_id],
  [promp_regalo],
  [promp_descuento]
 FROM
  [PromocionesProductos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PromocionesProductos_Consultar]'))
DROP PROCEDURE [dbo].[SP_PromocionesProductos_Consultar]
GO

CREATE PROCEDURE SP_PromocionesProductos_Consultar
 (
  @ppromp_id uniqueidentifier
 )

AS

 SELECT
  [promp_id],
  [promp_prod_id],
  [promp_promo_id],
  [promp_regalo],
  [promp_descuento]
 FROM
  [PromocionesProductos]
 WHERE
  (
   [promp_id] = @ppromp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_PromocionesProductos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_PromocionesProductos_ConsultarPor]
GO

CREATE PROCEDURE SP_PromocionesProductos_ConsultarPor
 (
  @ppromp_id uniqueidentifier = NULL,
  @ppromp_prod_id uniqueidentifier = NULL,
  @ppromp_promo_id uniqueidentifier = NULL,
  @ppromp_regalo bit = NULL,
  @ppromp_descuento int = NULL
 )

AS

  SELECT
   [promp_id],
   [promp_prod_id],
   [promp_promo_id],
   [promp_regalo],
   [promp_descuento]
  FROM
   [PromocionesProductos] WITH(NOLOCK)
  WHERE
   (
    (@ppromp_id IS NULL OR [promp_id] = @ppromp_id)
     AND
    (@ppromp_prod_id IS NULL OR [promp_prod_id] = @ppromp_prod_id)
     AND
    (@ppromp_promo_id IS NULL OR [promp_promo_id] = @ppromp_promo_id)
     AND
    (@ppromp_regalo IS NULL OR [promp_regalo] = @ppromp_regalo)
     AND
    (@ppromp_descuento IS NULL OR [promp_descuento] = @ppromp_descuento)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Proveedores]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Proveedores_Insertar]'))
DROP PROCEDURE [dbo].[SP_Proveedores_Insertar]
GO

CREATE PROCEDURE SP_Proveedores_Insertar
 (
  @pprov_id uniqueidentifier,
  @pprov_nombre varchar(100),
  @pprov_email varchar(50),
  @pprov_telefono varchar(50),
  @pprov_dom_id uniqueidentifier
 )

AS

 INSERT INTO [Proveedores]
  (
   [prov_id],
   [prov_nombre],
   [prov_email],
   [prov_telefono],
   [prov_dom_id]
  )
 VALUES
  (
   @pprov_id,
   @pprov_nombre,
   @pprov_email,
   @pprov_telefono,
   @pprov_dom_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Proveedores_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Proveedores_Actualizar]
GO

CREATE PROCEDURE SP_Proveedores_Actualizar
 (
  @pprov_id uniqueidentifier,
  @pprov_nombre varchar(100),
  @pprov_email varchar(50),
  @pprov_telefono varchar(50),
  @pprov_dom_id uniqueidentifier
 )

AS

 UPDATE
  [Proveedores]
 SET
  [prov_id] = @pprov_id,
  [prov_nombre] = @pprov_nombre,
  [prov_email] = @pprov_email,
  [prov_telefono] = @pprov_telefono,
  [prov_dom_id] = @pprov_dom_id
 WHERE
  [prov_id] = @pprov_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Proveedores_Borrar]'))
DROP PROCEDURE [dbo].[SP_Proveedores_Borrar]
GO

CREATE PROCEDURE SP_Proveedores_Borrar
 (
  @pprov_id uniqueidentifier
 )

AS

 DELETE FROM
  [Proveedores]
 WHERE
  (
   [prov_id] = @pprov_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Proveedores_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Proveedores_ConsultarTodos]
GO

CREATE PROCEDURE SP_Proveedores_ConsultarTodos

AS

 SELECT
  [prov_id],
  [prov_nombre],
  [prov_email],
  [prov_telefono],
  [prov_dom_id]
 FROM
  [Proveedores]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Proveedores_Consultar]'))
DROP PROCEDURE [dbo].[SP_Proveedores_Consultar]
GO

CREATE PROCEDURE SP_Proveedores_Consultar
 (
  @pprov_id uniqueidentifier
 )

AS

 SELECT
  [prov_id],
  [prov_nombre],
  [prov_email],
  [prov_telefono],
  [prov_dom_id]
 FROM
  [Proveedores]
 WHERE
  (
   [prov_id] = @pprov_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Proveedores_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Proveedores_ConsultarPor]
GO

CREATE PROCEDURE SP_Proveedores_ConsultarPor
 (
  @pprov_id uniqueidentifier = NULL,
  @pprov_nombre varchar(100) = NULL,
  @pprov_email varchar(50) = NULL,
  @pprov_telefono varchar(50) = NULL,
  @pprov_dom_id uniqueidentifier = NULL
 )

AS

  SELECT
   [prov_id],
   [prov_nombre],
   [prov_email],
   [prov_telefono],
   [prov_dom_id]
  FROM
   [Proveedores] WITH(NOLOCK)
  WHERE
   (
    (@pprov_id IS NULL OR [prov_id] = @pprov_id)
     AND
    (@pprov_nombre IS NULL OR [prov_nombre] LIKE ('%' + @pprov_nombre + '%'))
     AND
    (@pprov_email IS NULL OR [prov_email] LIKE ('%' + @pprov_email + '%'))
     AND
    (@pprov_telefono IS NULL OR [prov_telefono] LIKE ('%' + @pprov_telefono + '%'))
     AND
    (@pprov_dom_id IS NULL OR [prov_dom_id] = @pprov_dom_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [ProveedoresProductos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ProveedoresProductos_Insertar]'))
DROP PROCEDURE [dbo].[SP_ProveedoresProductos_Insertar]
GO

CREATE PROCEDURE SP_ProveedoresProductos_Insertar
 (
  @ppp_id uniqueidentifier,
  @ppp_prov_id uniqueidentifier,
  @ppp_prod_id uniqueidentifier,
  @ppp_costo numeric(18,0)
 )

AS

 INSERT INTO [ProveedoresProductos]
  (
   [pp_id],
   [pp_prov_id],
   [pp_prod_id],
   [pp_costo]
  )
 VALUES
  (
   @ppp_id,
   @ppp_prov_id,
   @ppp_prod_id,
   @ppp_costo
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ProveedoresProductos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_ProveedoresProductos_Actualizar]
GO

CREATE PROCEDURE SP_ProveedoresProductos_Actualizar
 (
  @ppp_id uniqueidentifier,
  @ppp_prov_id uniqueidentifier,
  @ppp_prod_id uniqueidentifier,
  @ppp_costo numeric(18,0)
 )

AS

 UPDATE
  [ProveedoresProductos]
 SET
  [pp_id] = @ppp_id,
  [pp_prov_id] = @ppp_prov_id,
  [pp_prod_id] = @ppp_prod_id,
  [pp_costo] = @ppp_costo
 WHERE
  [pp_id] = @ppp_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ProveedoresProductos_Borrar]'))
DROP PROCEDURE [dbo].[SP_ProveedoresProductos_Borrar]
GO

CREATE PROCEDURE SP_ProveedoresProductos_Borrar
 (
  @ppp_id uniqueidentifier
 )

AS

 DELETE FROM
  [ProveedoresProductos]
 WHERE
  (
   [pp_id] = @ppp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ProveedoresProductos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_ProveedoresProductos_ConsultarTodos]
GO

CREATE PROCEDURE SP_ProveedoresProductos_ConsultarTodos

AS

 SELECT
  [pp_id],
  [pp_prov_id],
  [pp_prod_id],
  [pp_costo]
 FROM
  [ProveedoresProductos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ProveedoresProductos_Consultar]'))
DROP PROCEDURE [dbo].[SP_ProveedoresProductos_Consultar]
GO

CREATE PROCEDURE SP_ProveedoresProductos_Consultar
 (
  @ppp_id uniqueidentifier
 )

AS

 SELECT
  [pp_id],
  [pp_prov_id],
  [pp_prod_id],
  [pp_costo]
 FROM
  [ProveedoresProductos]
 WHERE
  (
   [pp_id] = @ppp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ProveedoresProductos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_ProveedoresProductos_ConsultarPor]
GO

CREATE PROCEDURE SP_ProveedoresProductos_ConsultarPor
 (
  @ppp_id uniqueidentifier = NULL,
  @ppp_prov_id uniqueidentifier = NULL,
  @ppp_prod_id uniqueidentifier = NULL,
  @ppp_costo numeric(18,0) = NULL
 )

AS

  SELECT
   [pp_id],
   [pp_prov_id],
   [pp_prod_id],
   [pp_costo]
  FROM
   [ProveedoresProductos] WITH(NOLOCK)
  WHERE
   (
    (@ppp_id IS NULL OR [pp_id] = @ppp_id)
     AND
    (@ppp_prov_id IS NULL OR [pp_prov_id] = @ppp_prov_id)
     AND
    (@ppp_prod_id IS NULL OR [pp_prod_id] = @ppp_prod_id)
     AND
    (@ppp_costo IS NULL OR [pp_costo] = @ppp_costo)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Provincias]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Provincias_Insertar]'))
DROP PROCEDURE [dbo].[SP_Provincias_Insertar]
GO

CREATE PROCEDURE SP_Provincias_Insertar
 (
  @pprov_id uniqueidentifier,
  @pprov_nombre varchar(50),
  @pprov_pais_id uniqueidentifier
 )

AS

 INSERT INTO [Provincias]
  (
   [prov_id],
   [prov_nombre],
   [prov_pais_id]
  )
 VALUES
  (
   @pprov_id,
   @pprov_nombre,
   @pprov_pais_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Provincias_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Provincias_Actualizar]
GO

CREATE PROCEDURE SP_Provincias_Actualizar
 (
  @pprov_id uniqueidentifier,
  @pprov_nombre varchar(50),
  @pprov_pais_id uniqueidentifier
 )

AS

 UPDATE
  [Provincias]
 SET
  [prov_id] = @pprov_id,
  [prov_nombre] = @pprov_nombre,
  [prov_pais_id] = @pprov_pais_id
 WHERE
  [prov_id] = @pprov_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Provincias_Borrar]'))
DROP PROCEDURE [dbo].[SP_Provincias_Borrar]
GO

CREATE PROCEDURE SP_Provincias_Borrar
 (
  @pprov_id uniqueidentifier
 )

AS

 DELETE FROM
  [Provincias]
 WHERE
  (
   [prov_id] = @pprov_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Provincias_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Provincias_ConsultarTodos]
GO

CREATE PROCEDURE SP_Provincias_ConsultarTodos

AS

 SELECT
  [prov_id],
  [prov_nombre],
  [prov_pais_id]
 FROM
  [Provincias]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Provincias_Consultar]'))
DROP PROCEDURE [dbo].[SP_Provincias_Consultar]
GO

CREATE PROCEDURE SP_Provincias_Consultar
 (
  @pprov_id uniqueidentifier
 )

AS

 SELECT
  [prov_id],
  [prov_nombre],
  [prov_pais_id]
 FROM
  [Provincias]
 WHERE
  (
   [prov_id] = @pprov_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Provincias_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Provincias_ConsultarPor]
GO

CREATE PROCEDURE SP_Provincias_ConsultarPor
 (
  @pprov_id uniqueidentifier = NULL,
  @pprov_nombre varchar(50) = NULL,
  @pprov_pais_id uniqueidentifier = NULL
 )

AS

  SELECT
   [prov_id],
   [prov_nombre],
   [prov_pais_id]
  FROM
   [Provincias] WITH(NOLOCK)
  WHERE
   (
    (@pprov_id IS NULL OR [prov_id] = @pprov_id)
     AND
    (@pprov_nombre IS NULL OR [prov_nombre] LIKE ('%' + @pprov_nombre + '%'))
     AND
    (@pprov_pais_id IS NULL OR [prov_pais_id] = @pprov_pais_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Reparaciones]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Reparaciones_Insertar]'))
DROP PROCEDURE [dbo].[SP_Reparaciones_Insertar]
GO

CREATE PROCEDURE SP_Reparaciones_Insertar
 (
  @prep_id uniqueidentifier,
  @prep_usu_id uniqueidentifier,
  @prep_fecha_recepcion datetime,
  @prep_fecha_devolucion datetime,
  @prep_importe_total numeric(18,0),
  @prep_tpago_id uniqueidentifier,
  @prep_estado varchar(50)
 )

AS

 INSERT INTO [Reparaciones]
  (
   [rep_id],
   [rep_usu_id],
   [rep_fecha_recepcion],
   [rep_fecha_devolucion],
   [rep_importe_total],
   [rep_tpago_id],
   [rep_estado]
  )
 VALUES
  (
   @prep_id,
   @prep_usu_id,
   @prep_fecha_recepcion,
   @prep_fecha_devolucion,
   @prep_importe_total,
   @prep_tpago_id,
   @prep_estado
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Reparaciones_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Reparaciones_Actualizar]
GO

CREATE PROCEDURE SP_Reparaciones_Actualizar
 (
  @prep_id uniqueidentifier,
  @prep_usu_id uniqueidentifier,
  @prep_fecha_recepcion datetime,
  @prep_fecha_devolucion datetime,
  @prep_importe_total numeric(18,0),
  @prep_tpago_id uniqueidentifier,
  @prep_estado varchar(50)
 )

AS

 UPDATE
  [Reparaciones]
 SET
  [rep_id] = @prep_id,
  [rep_usu_id] = @prep_usu_id,
  [rep_fecha_recepcion] = @prep_fecha_recepcion,
  [rep_fecha_devolucion] = @prep_fecha_devolucion,
  [rep_importe_total] = @prep_importe_total,
  [rep_tpago_id] = @prep_tpago_id,
  [rep_estado] = @prep_estado
 WHERE
  [rep_id] = @prep_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Reparaciones_Borrar]'))
DROP PROCEDURE [dbo].[SP_Reparaciones_Borrar]
GO

CREATE PROCEDURE SP_Reparaciones_Borrar
 (
  @prep_id uniqueidentifier
 )

AS

 DELETE FROM
  [Reparaciones]
 WHERE
  (
   [rep_id] = @prep_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Reparaciones_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Reparaciones_ConsultarTodos]
GO

CREATE PROCEDURE SP_Reparaciones_ConsultarTodos

AS

 SELECT
  [rep_id],
  [rep_usu_id],
  [rep_fecha_recepcion],
  [rep_fecha_devolucion],
  [rep_importe_total],
  [rep_tpago_id],
  [rep_estado]
 FROM
  [Reparaciones]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Reparaciones_Consultar]'))
DROP PROCEDURE [dbo].[SP_Reparaciones_Consultar]
GO

CREATE PROCEDURE SP_Reparaciones_Consultar
 (
  @prep_id uniqueidentifier
 )

AS

 SELECT
  [rep_id],
  [rep_usu_id],
  [rep_fecha_recepcion],
  [rep_fecha_devolucion],
  [rep_importe_total],
  [rep_tpago_id],
  [rep_estado]
 FROM
  [Reparaciones]
 WHERE
  (
   [rep_id] = @prep_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Reparaciones_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Reparaciones_ConsultarPor]
GO

CREATE PROCEDURE SP_Reparaciones_ConsultarPor
 (
  @prep_id uniqueidentifier = NULL,
  @prep_usu_id uniqueidentifier = NULL,
  @prep_fecha_recepcion datetime = NULL,
  @prep_fecha_devolucion datetime = NULL,
  @prep_importe_total numeric(18,0) = NULL,
  @prep_tpago_id uniqueidentifier = NULL,
  @prep_estado varchar(50) = NULL
 )

AS

  SELECT
   [rep_id],
   [rep_usu_id],
   [rep_fecha_recepcion],
   [rep_fecha_devolucion],
   [rep_importe_total],
   [rep_tpago_id],
   [rep_estado]
  FROM
   [Reparaciones] WITH(NOLOCK)
  WHERE
   (
    (@prep_id IS NULL OR [rep_id] = @prep_id)
     AND
    (@prep_usu_id IS NULL OR [rep_usu_id] = @prep_usu_id)
     AND
    (@prep_fecha_recepcion IS NULL OR [rep_fecha_recepcion] = @prep_fecha_recepcion)
     AND
    (@prep_fecha_devolucion IS NULL OR [rep_fecha_devolucion] = @prep_fecha_devolucion)
     AND
    (@prep_importe_total IS NULL OR [rep_importe_total] = @prep_importe_total)
     AND
    (@prep_tpago_id IS NULL OR [rep_tpago_id] = @prep_tpago_id)
     AND
    (@prep_estado IS NULL OR [rep_estado] LIKE ('%' + @prep_estado + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [ReparacionesProductos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ReparacionesProductos_Insertar]'))
DROP PROCEDURE [dbo].[SP_ReparacionesProductos_Insertar]
GO

CREATE PROCEDURE SP_ReparacionesProductos_Insertar
 (
  @prp_id uniqueidentifier,
  @prp_rep_id uniqueidentifier,
  @prp_prod_id uniqueidentifier,
  @prp_modelo varchar(50),
  @prp_garantia varchar(50),
  @prp_propio varchar(50),
  @prp_problema varchar(50),
  @prp_solucion varchar(50),
  @prp_comentarios varchar(100),
  @prp_repuestos varchar(50)
 )

AS

 INSERT INTO [ReparacionesProductos]
  (
   [rp_id],
   [rp_rep_id],
   [rp_prod_id],
   [rp_modelo],
   [rp_garantia],
   [rp_propio],
   [rp_problema],
   [rp_solucion],
   [rp_comentarios],
   [rp_repuestos]
  )
 VALUES
  (
   @prp_id,
   @prp_rep_id,
   @prp_prod_id,
   @prp_modelo,
   @prp_garantia,
   @prp_propio,
   @prp_problema,
   @prp_solucion,
   @prp_comentarios,
   @prp_repuestos
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ReparacionesProductos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_ReparacionesProductos_Actualizar]
GO

CREATE PROCEDURE SP_ReparacionesProductos_Actualizar
 (
  @prp_id uniqueidentifier,
  @prp_rep_id uniqueidentifier,
  @prp_prod_id uniqueidentifier,
  @prp_modelo varchar(50),
  @prp_garantia varchar(50),
  @prp_propio varchar(50),
  @prp_problema varchar(50),
  @prp_solucion varchar(50),
  @prp_comentarios varchar(100),
  @prp_repuestos varchar(50)
 )

AS

 UPDATE
  [ReparacionesProductos]
 SET
  [rp_id] = @prp_id,
  [rp_rep_id] = @prp_rep_id,
  [rp_prod_id] = @prp_prod_id,
  [rp_modelo] = @prp_modelo,
  [rp_garantia] = @prp_garantia,
  [rp_propio] = @prp_propio,
  [rp_problema] = @prp_problema,
  [rp_solucion] = @prp_solucion,
  [rp_comentarios] = @prp_comentarios,
  [rp_repuestos] = @prp_repuestos
 WHERE
  [rp_id] = @prp_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ReparacionesProductos_Borrar]'))
DROP PROCEDURE [dbo].[SP_ReparacionesProductos_Borrar]
GO

CREATE PROCEDURE SP_ReparacionesProductos_Borrar
 (
  @prp_id uniqueidentifier
 )

AS

 DELETE FROM
  [ReparacionesProductos]
 WHERE
  (
   [rp_id] = @prp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ReparacionesProductos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_ReparacionesProductos_ConsultarTodos]
GO

CREATE PROCEDURE SP_ReparacionesProductos_ConsultarTodos

AS

 SELECT
  [rp_id],
  [rp_rep_id],
  [rp_prod_id],
  [rp_modelo],
  [rp_garantia],
  [rp_propio],
  [rp_problema],
  [rp_solucion],
  [rp_comentarios],
  [rp_repuestos]
 FROM
  [ReparacionesProductos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ReparacionesProductos_Consultar]'))
DROP PROCEDURE [dbo].[SP_ReparacionesProductos_Consultar]
GO

CREATE PROCEDURE SP_ReparacionesProductos_Consultar
 (
  @prp_id uniqueidentifier
 )

AS

 SELECT
  [rp_id],
  [rp_rep_id],
  [rp_prod_id],
  [rp_modelo],
  [rp_garantia],
  [rp_propio],
  [rp_problema],
  [rp_solucion],
  [rp_comentarios],
  [rp_repuestos]
 FROM
  [ReparacionesProductos]
 WHERE
  (
   [rp_id] = @prp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_ReparacionesProductos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_ReparacionesProductos_ConsultarPor]
GO

CREATE PROCEDURE SP_ReparacionesProductos_ConsultarPor
 (
  @prp_id uniqueidentifier = NULL,
  @prp_rep_id uniqueidentifier = NULL,
  @prp_prod_id uniqueidentifier = NULL,
  @prp_modelo varchar(50) = NULL,
  @prp_garantia varchar(50) = NULL,
  @prp_propio varchar(50) = NULL,
  @prp_problema varchar(50) = NULL,
  @prp_solucion varchar(50) = NULL,
  @prp_comentarios varchar(100) = NULL,
  @prp_repuestos varchar(50) = NULL
 )

AS

  SELECT
   [rp_id],
   [rp_rep_id],
   [rp_prod_id],
   [rp_modelo],
   [rp_garantia],
   [rp_propio],
   [rp_problema],
   [rp_solucion],
   [rp_comentarios],
   [rp_repuestos]
  FROM
   [ReparacionesProductos] WITH(NOLOCK)
  WHERE
   (
    (@prp_id IS NULL OR [rp_id] = @prp_id)
     AND
    (@prp_rep_id IS NULL OR [rp_rep_id] = @prp_rep_id)
     AND
    (@prp_prod_id IS NULL OR [rp_prod_id] = @prp_prod_id)
     AND
    (@prp_modelo IS NULL OR [rp_modelo] LIKE ('%' + @prp_modelo + '%'))
     AND
    (@prp_garantia IS NULL OR [rp_garantia] LIKE ('%' + @prp_garantia + '%'))
     AND
    (@prp_propio IS NULL OR [rp_propio] LIKE ('%' + @prp_propio + '%'))
     AND
    (@prp_problema IS NULL OR [rp_problema] LIKE ('%' + @prp_problema + '%'))
     AND
    (@prp_solucion IS NULL OR [rp_solucion] LIKE ('%' + @prp_solucion + '%'))
     AND
    (@prp_comentarios IS NULL OR [rp_comentarios] LIKE ('%' + @prp_comentarios + '%'))
     AND
    (@prp_repuestos IS NULL OR [rp_repuestos] LIKE ('%' + @prp_repuestos + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Resoluciones]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Resoluciones_Insertar]'))
DROP PROCEDURE [dbo].[SP_Resoluciones_Insertar]
GO

CREATE PROCEDURE SP_Resoluciones_Insertar
 (
  @pres_id uniqueidentifier,
  @pres_solucion varchar(500)
 )

AS

 INSERT INTO [Resoluciones]
  (
   [res_id],
   [res_solucion]
  )
 VALUES
  (
   @pres_id,
   @pres_solucion
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Resoluciones_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Resoluciones_Actualizar]
GO

CREATE PROCEDURE SP_Resoluciones_Actualizar
 (
  @pres_id uniqueidentifier,
  @pres_solucion varchar(500)
 )

AS

 UPDATE
  [Resoluciones]
 SET
  [res_id] = @pres_id,
  [res_solucion] = @pres_solucion
 WHERE
  [res_id] = @pres_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Resoluciones_Borrar]'))
DROP PROCEDURE [dbo].[SP_Resoluciones_Borrar]
GO

CREATE PROCEDURE SP_Resoluciones_Borrar
 (
  @pres_id uniqueidentifier
 )

AS

 DELETE FROM
  [Resoluciones]
 WHERE
  (
   [res_id] = @pres_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Resoluciones_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Resoluciones_ConsultarTodos]
GO

CREATE PROCEDURE SP_Resoluciones_ConsultarTodos

AS

 SELECT
  [res_id],
  [res_solucion]
 FROM
  [Resoluciones]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Resoluciones_Consultar]'))
DROP PROCEDURE [dbo].[SP_Resoluciones_Consultar]
GO

CREATE PROCEDURE SP_Resoluciones_Consultar
 (
  @pres_id uniqueidentifier
 )

AS

 SELECT
  [res_id],
  [res_solucion]
 FROM
  [Resoluciones]
 WHERE
  (
   [res_id] = @pres_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Resoluciones_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Resoluciones_ConsultarPor]
GO

CREATE PROCEDURE SP_Resoluciones_ConsultarPor
 (
  @pres_id uniqueidentifier = NULL,
  @pres_solucion varchar(500) = NULL
 )

AS

  SELECT
   [res_id],
   [res_solucion]
  FROM
   [Resoluciones] WITH(NOLOCK)
  WHERE
   (
    (@pres_id IS NULL OR [res_id] = @pres_id)
     AND
    (@pres_solucion IS NULL OR [res_solucion] LIKE ('%' + @pres_solucion + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Seguimientos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Seguimientos_Insertar]'))
DROP PROCEDURE [dbo].[SP_Seguimientos_Insertar]
GO

CREATE PROCEDURE SP_Seguimientos_Insertar
 (
  @pseg_log_id uniqueidentifier,
  @pseg_tar_id uniqueidentifier
 )

AS

 INSERT INTO [Seguimientos]
  (
   [seg_log_id],
   [seg_tar_id]
  )
 VALUES
  (
   @pseg_log_id,
   @pseg_tar_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Seguimientos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Seguimientos_Actualizar]
GO

CREATE PROCEDURE SP_Seguimientos_Actualizar
 (
  @pseg_log_id uniqueidentifier,
  @pseg_tar_id uniqueidentifier
 )

AS

 UPDATE
  [Seguimientos]
 SET
  [seg_log_id] = @pseg_log_id,
  [seg_tar_id] = @pseg_tar_id
 WHERE
  (
   [seg_log_id] = @pseg_log_id
    AND
   [seg_tar_id] = @pseg_tar_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Seguimientos_Borrar]'))
DROP PROCEDURE [dbo].[SP_Seguimientos_Borrar]
GO

CREATE PROCEDURE SP_Seguimientos_Borrar
 (
  @pseg_log_id uniqueidentifier,
  @pseg_tar_id uniqueidentifier
 )

AS

 DELETE FROM
  [Seguimientos]
 WHERE
  (
   [seg_log_id] = @pseg_log_id
    AND
   [seg_tar_id] = @pseg_tar_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Seguimientos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Seguimientos_ConsultarTodos]
GO

CREATE PROCEDURE SP_Seguimientos_ConsultarTodos

AS

 SELECT
  [seg_log_id],
  [seg_tar_id]
 FROM
  [Seguimientos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Seguimientos_Consultar]'))
DROP PROCEDURE [dbo].[SP_Seguimientos_Consultar]
GO

CREATE PROCEDURE SP_Seguimientos_Consultar
 (
  @pseg_log_id uniqueidentifier,
  @pseg_tar_id uniqueidentifier
 )

AS

 SELECT
  [seg_log_id],
  [seg_tar_id]
 FROM
  [Seguimientos]
 WHERE
  (
   [seg_log_id] = @pseg_log_id
    AND
   [seg_tar_id] = @pseg_tar_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Seguimientos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Seguimientos_ConsultarPor]
GO

CREATE PROCEDURE SP_Seguimientos_ConsultarPor
 (
  @pseg_log_id uniqueidentifier = NULL,
  @pseg_tar_id uniqueidentifier = NULL
 )

AS

  SELECT
   [seg_log_id],
   [seg_tar_id]
  FROM
   [Seguimientos] WITH(NOLOCK)
  WHERE
   (
    (@pseg_log_id IS NULL OR [seg_log_id] = @pseg_log_id)
     AND
    (@pseg_tar_id IS NULL OR [seg_tar_id] = @pseg_tar_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Tareas]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Tareas_Insertar]'))
DROP PROCEDURE [dbo].[SP_Tareas_Insertar]
GO

CREATE PROCEDURE SP_Tareas_Insertar
 (
  @ptar_id uniqueidentifier,
  @ptar_nombre varchar(50),
  @ptar_descrip varchar(500)
 )

AS

 INSERT INTO [Tareas]
  (
   [tar_id],
   [tar_nombre],
   [tar_descrip]
  )
 VALUES
  (
   @ptar_id,
   @ptar_nombre,
   @ptar_descrip
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Tareas_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Tareas_Actualizar]
GO

CREATE PROCEDURE SP_Tareas_Actualizar
 (
  @ptar_id uniqueidentifier,
  @ptar_nombre varchar(50),
  @ptar_descrip varchar(500)
 )

AS

 UPDATE
  [Tareas]
 SET
  [tar_id] = @ptar_id,
  [tar_nombre] = @ptar_nombre,
  [tar_descrip] = @ptar_descrip
 WHERE
  [tar_id] = @ptar_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Tareas_Borrar]'))
DROP PROCEDURE [dbo].[SP_Tareas_Borrar]
GO

CREATE PROCEDURE SP_Tareas_Borrar
 (
  @ptar_id uniqueidentifier
 )

AS

 DELETE FROM
  [Tareas]
 WHERE
  (
   [tar_id] = @ptar_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Tareas_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Tareas_ConsultarTodos]
GO

CREATE PROCEDURE SP_Tareas_ConsultarTodos

AS

 SELECT
  [tar_id],
  [tar_nombre],
  [tar_descrip]
 FROM
  [Tareas]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Tareas_Consultar]'))
DROP PROCEDURE [dbo].[SP_Tareas_Consultar]
GO

CREATE PROCEDURE SP_Tareas_Consultar
 (
  @ptar_id uniqueidentifier
 )

AS

 SELECT
  [tar_id],
  [tar_nombre],
  [tar_descrip]
 FROM
  [Tareas]
 WHERE
  (
   [tar_id] = @ptar_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Tareas_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Tareas_ConsultarPor]
GO

CREATE PROCEDURE SP_Tareas_ConsultarPor
 (
  @ptar_id uniqueidentifier = NULL,
  @ptar_nombre varchar(50) = NULL,
  @ptar_descrip varchar(500) = NULL
 )

AS

  SELECT
   [tar_id],
   [tar_nombre],
   [tar_descrip]
  FROM
   [Tareas] WITH(NOLOCK)
  WHERE
   (
    (@ptar_id IS NULL OR [tar_id] = @ptar_id)
     AND
    (@ptar_nombre IS NULL OR [tar_nombre] LIKE ('%' + @ptar_nombre + '%'))
     AND
    (@ptar_descrip IS NULL OR [tar_descrip] LIKE ('%' + @ptar_descrip + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [TipoPagos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_TipoPagos_Insertar]'))
DROP PROCEDURE [dbo].[SP_TipoPagos_Insertar]
GO

CREATE PROCEDURE SP_TipoPagos_Insertar
 (
  @ptpago_id uniqueidentifier,
  @ptpago_descrip varchar(50),
  @ptpago_disponible varchar(50)
 )

AS

 INSERT INTO [TipoPagos]
  (
   [tpago_id],
   [tpago_descrip],
   [tpago_disponible]
  )
 VALUES
  (
   @ptpago_id,
   @ptpago_descrip,
   @ptpago_disponible
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_TipoPagos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_TipoPagos_Actualizar]
GO

CREATE PROCEDURE SP_TipoPagos_Actualizar
 (
  @ptpago_id uniqueidentifier,
  @ptpago_descrip varchar(50),
  @ptpago_disponible varchar(50)
 )

AS

 UPDATE
  [TipoPagos]
 SET
  [tpago_id] = @ptpago_id,
  [tpago_descrip] = @ptpago_descrip,
  [tpago_disponible] = @ptpago_disponible
 WHERE
  [tpago_id] = @ptpago_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_TipoPagos_Borrar]'))
DROP PROCEDURE [dbo].[SP_TipoPagos_Borrar]
GO

CREATE PROCEDURE SP_TipoPagos_Borrar
 (
  @ptpago_id uniqueidentifier
 )

AS

 DELETE FROM
  [TipoPagos]
 WHERE
  (
   [tpago_id] = @ptpago_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_TipoPagos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_TipoPagos_ConsultarTodos]
GO

CREATE PROCEDURE SP_TipoPagos_ConsultarTodos

AS

 SELECT
  [tpago_id],
  [tpago_descrip],
  [tpago_disponible]
 FROM
  [TipoPagos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_TipoPagos_Consultar]'))
DROP PROCEDURE [dbo].[SP_TipoPagos_Consultar]
GO

CREATE PROCEDURE SP_TipoPagos_Consultar
 (
  @ptpago_id uniqueidentifier
 )

AS

 SELECT
  [tpago_id],
  [tpago_descrip],
  [tpago_disponible]
 FROM
  [TipoPagos]
 WHERE
  (
   [tpago_id] = @ptpago_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_TipoPagos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_TipoPagos_ConsultarPor]
GO

CREATE PROCEDURE SP_TipoPagos_ConsultarPor
 (
  @ptpago_id uniqueidentifier = NULL,
  @ptpago_descrip varchar(50) = NULL,
  @ptpago_disponible varchar(50) = NULL
 )

AS

  SELECT
   [tpago_id],
   [tpago_descrip],
   [tpago_disponible]
  FROM
   [TipoPagos] WITH(NOLOCK)
  WHERE
   (
    (@ptpago_id IS NULL OR [tpago_id] = @ptpago_id)
     AND
    (@ptpago_descrip IS NULL OR [tpago_descrip] LIKE ('%' + @ptpago_descrip + '%'))
     AND
    (@ptpago_disponible IS NULL OR [tpago_disponible] LIKE ('%' + @ptpago_disponible + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [TipoProductos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_TipoProductos_Insertar]'))
DROP PROCEDURE [dbo].[SP_TipoProductos_Insertar]
GO

CREATE PROCEDURE SP_TipoProductos_Insertar
 (
  @ptprod_id uniqueidentifier,
  @ptprod_descrip varchar(50)
 )

AS

 INSERT INTO [TipoProductos]
  (
   [tprod_id],
   [tprod_descrip]
  )
 VALUES
  (
   @ptprod_id,
   @ptprod_descrip
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_TipoProductos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_TipoProductos_Actualizar]
GO

CREATE PROCEDURE SP_TipoProductos_Actualizar
 (
  @ptprod_id uniqueidentifier,
  @ptprod_descrip varchar(50)
 )

AS

 UPDATE
  [TipoProductos]
 SET
  [tprod_id] = @ptprod_id,
  [tprod_descrip] = @ptprod_descrip
 WHERE
  [tprod_id] = @ptprod_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_TipoProductos_Borrar]'))
DROP PROCEDURE [dbo].[SP_TipoProductos_Borrar]
GO

CREATE PROCEDURE SP_TipoProductos_Borrar
 (
  @ptprod_id uniqueidentifier
 )

AS

 DELETE FROM
  [TipoProductos]
 WHERE
  (
   [tprod_id] = @ptprod_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_TipoProductos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_TipoProductos_ConsultarTodos]
GO

CREATE PROCEDURE SP_TipoProductos_ConsultarTodos

AS

 SELECT
  [tprod_id],
  [tprod_descrip]
 FROM
  [TipoProductos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_TipoProductos_Consultar]'))
DROP PROCEDURE [dbo].[SP_TipoProductos_Consultar]
GO

CREATE PROCEDURE SP_TipoProductos_Consultar
 (
  @ptprod_id uniqueidentifier
 )

AS

 SELECT
  [tprod_id],
  [tprod_descrip]
 FROM
  [TipoProductos]
 WHERE
  (
   [tprod_id] = @ptprod_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_TipoProductos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_TipoProductos_ConsultarPor]
GO

CREATE PROCEDURE SP_TipoProductos_ConsultarPor
 (
  @ptprod_id uniqueidentifier = NULL,
  @ptprod_descrip varchar(50) = NULL
 )

AS

  SELECT
   [tprod_id],
   [tprod_descrip]
  FROM
   [TipoProductos] WITH(NOLOCK)
  WHERE
   (
    (@ptprod_id IS NULL OR [tprod_id] = @ptprod_id)
     AND
    (@ptprod_descrip IS NULL OR [tprod_descrip] LIKE ('%' + @ptprod_descrip + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [UsuariosFamilias]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosFamilias_Insertar]'))
DROP PROCEDURE [dbo].[SP_UsuariosFamilias_Insertar]
GO

CREATE PROCEDURE SP_UsuariosFamilias_Insertar
 (
  @puf_usu_id uniqueidentifier,
  @puf_fam_id uniqueidentifier
 )

AS

 INSERT INTO [UsuariosFamilias]
  (
   [uf_usu_id],
   [uf_fam_id]
  )
 VALUES
  (
   @puf_usu_id,
   @puf_fam_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosFamilias_Actualizar]'))
DROP PROCEDURE [dbo].[SP_UsuariosFamilias_Actualizar]
GO

CREATE PROCEDURE SP_UsuariosFamilias_Actualizar
 (
  @puf_usu_id uniqueidentifier,
  @puf_fam_id uniqueidentifier
 )

AS

 UPDATE
  [UsuariosFamilias]
 SET
  [uf_usu_id] = @puf_usu_id,
  [uf_fam_id] = @puf_fam_id
 WHERE
  (
   [uf_usu_id] = @puf_usu_id
    AND
   [uf_fam_id] = @puf_fam_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosFamilias_Borrar]'))
DROP PROCEDURE [dbo].[SP_UsuariosFamilias_Borrar]
GO

CREATE PROCEDURE SP_UsuariosFamilias_Borrar
 (
  @puf_usu_id uniqueidentifier,
  @puf_fam_id uniqueidentifier
 )

AS

 DELETE FROM
  [UsuariosFamilias]
 WHERE
  (
   [uf_usu_id] = @puf_usu_id
    AND
   [uf_fam_id] = @puf_fam_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosFamilias_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_UsuariosFamilias_ConsultarTodos]
GO

CREATE PROCEDURE SP_UsuariosFamilias_ConsultarTodos

AS

 SELECT
  [uf_usu_id],
  [uf_fam_id]
 FROM
  [UsuariosFamilias]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosFamilias_Consultar]'))
DROP PROCEDURE [dbo].[SP_UsuariosFamilias_Consultar]
GO

CREATE PROCEDURE SP_UsuariosFamilias_Consultar
 (
  @puf_usu_id uniqueidentifier,
  @puf_fam_id uniqueidentifier
 )

AS

 SELECT
  [uf_usu_id],
  [uf_fam_id]
 FROM
  [UsuariosFamilias]
 WHERE
  (
   [uf_usu_id] = @puf_usu_id
    AND
   [uf_fam_id] = @puf_fam_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosFamilias_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_UsuariosFamilias_ConsultarPor]
GO

CREATE PROCEDURE SP_UsuariosFamilias_ConsultarPor
 (
  @puf_usu_id uniqueidentifier = NULL,
  @puf_fam_id uniqueidentifier = NULL
 )

AS

  SELECT
   [uf_usu_id],
   [uf_fam_id]
  FROM
   [UsuariosFamilias] WITH(NOLOCK)
  WHERE
   (
    (@puf_usu_id IS NULL OR [uf_usu_id] = @puf_usu_id)
     AND
    (@puf_fam_id IS NULL OR [uf_fam_id] = @puf_fam_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [UsuariosPatentes]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosPatentes_Insertar]'))
DROP PROCEDURE [dbo].[SP_UsuariosPatentes_Insertar]
GO

CREATE PROCEDURE SP_UsuariosPatentes_Insertar
 (
  @pup_usu_id uniqueidentifier,
  @pup_pat_id uniqueidentifier
 )

AS

 INSERT INTO [UsuariosPatentes]
  (
   [up_usu_id],
   [up_pat_id]
  )
 VALUES
  (
   @pup_usu_id,
   @pup_pat_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosPatentes_Actualizar]'))
DROP PROCEDURE [dbo].[SP_UsuariosPatentes_Actualizar]
GO

CREATE PROCEDURE SP_UsuariosPatentes_Actualizar
 (
  @pup_usu_id uniqueidentifier,
  @pup_pat_id uniqueidentifier
 )

AS

 UPDATE
  [UsuariosPatentes]
 SET
  [up_usu_id] = @pup_usu_id,
  [up_pat_id] = @pup_pat_id
 WHERE
  (
   [up_usu_id] = @pup_usu_id
    AND
   [up_pat_id] = @pup_pat_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosPatentes_Borrar]'))
DROP PROCEDURE [dbo].[SP_UsuariosPatentes_Borrar]
GO

CREATE PROCEDURE SP_UsuariosPatentes_Borrar
 (
  @pup_usu_id uniqueidentifier,
  @pup_pat_id uniqueidentifier
 )

AS

 DELETE FROM
  [UsuariosPatentes]
 WHERE
  (
   [up_usu_id] = @pup_usu_id
    AND
   [up_pat_id] = @pup_pat_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosPatentes_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_UsuariosPatentes_ConsultarTodos]
GO

CREATE PROCEDURE SP_UsuariosPatentes_ConsultarTodos

AS

 SELECT
  [up_usu_id],
  [up_pat_id]
 FROM
  [UsuariosPatentes]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosPatentes_Consultar]'))
DROP PROCEDURE [dbo].[SP_UsuariosPatentes_Consultar]
GO

CREATE PROCEDURE SP_UsuariosPatentes_Consultar
 (
  @pup_usu_id uniqueidentifier,
  @pup_pat_id uniqueidentifier
 )

AS

 SELECT
  [up_usu_id],
  [up_pat_id]
 FROM
  [UsuariosPatentes]
 WHERE
  (
   [up_usu_id] = @pup_usu_id
    AND
   [up_pat_id] = @pup_pat_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosPatentes_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_UsuariosPatentes_ConsultarPor]
GO

CREATE PROCEDURE SP_UsuariosPatentes_ConsultarPor
 (
  @pup_usu_id uniqueidentifier = NULL,
  @pup_pat_id uniqueidentifier = NULL
 )

AS

  SELECT
   [up_usu_id],
   [up_pat_id]
  FROM
   [UsuariosPatentes] WITH(NOLOCK)
  WHERE
   (
    (@pup_usu_id IS NULL OR [up_usu_id] = @pup_usu_id)
     AND
    (@pup_pat_id IS NULL OR [up_pat_id] = @pup_pat_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [UsuariosRegistrados]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosRegistrados_Insertar]'))
DROP PROCEDURE [dbo].[SP_UsuariosRegistrados_Insertar]
GO

CREATE PROCEDURE SP_UsuariosRegistrados_Insertar
 (
  @pusu_id uniqueidentifier,
  @pusu_nombre varchar(50),
  @pusu_apellido varchar(50),
  @pusu_nick varchar(50),
  @pusu_password varchar(50),
  @pusu_tipodoc varchar(20),
  @pusu_doc varchar(50),
  @pusu_fecha_nac datetime,
  @pusu_telefono int,
  @pusu_email varchar(50),
  @pusu_desarrolla bit,
  @pusu_interno bit,
  @pusu_suscripcion bit,
  @pusu_CUIT varchar(50),
  @pusu_CUIL varchar(50),
  @pusu_iva_id uniqueidentifier,
  @pusu_estado uniqueidentifier,
  @pusu_idioma_id uniqueidentifier
 )

AS

 INSERT INTO [UsuariosRegistrados]
  (
   [usu_id],
   [usu_nombre],
   [usu_apellido],
   [usu_nick],
   [usu_password],
   [usu_tipodoc],
   [usu_doc],
   [usu_fecha_nac],
   [usu_telefono],
   [usu_email],
   [usu_desarrolla],
   [usu_interno],
   [usu_suscripcion],
   [usu_CUIT],
   [usu_CUIL],
   [usu_iva_id],
   [usu_estado],
   [usu_idioma_id]
  )
 VALUES
  (
   @pusu_id,
   @pusu_nombre,
   @pusu_apellido,
   @pusu_nick,
   @pusu_password,
   @pusu_tipodoc,
   @pusu_doc,
   @pusu_fecha_nac,
   @pusu_telefono,
   @pusu_email,
   @pusu_desarrolla,
   @pusu_interno,
   @pusu_suscripcion,
   @pusu_CUIT,
   @pusu_CUIL,
   @pusu_iva_id,
   @pusu_estado,
   @pusu_idioma_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosRegistrados_Actualizar]'))
DROP PROCEDURE [dbo].[SP_UsuariosRegistrados_Actualizar]
GO

CREATE PROCEDURE SP_UsuariosRegistrados_Actualizar
 (
  @pusu_id uniqueidentifier,
  @pusu_nombre varchar(50),
  @pusu_apellido varchar(50),
  @pusu_nick varchar(50),
  @pusu_password varchar(50),
  @pusu_tipodoc varchar(20),
  @pusu_doc varchar(50),
  @pusu_fecha_nac datetime,
  @pusu_telefono int,
  @pusu_email varchar(50),
  @pusu_desarrolla bit,
  @pusu_interno bit,
  @pusu_suscripcion bit,
  @pusu_CUIT varchar(50),
  @pusu_CUIL varchar(50),
  @pusu_iva_id uniqueidentifier,
  @pusu_estado uniqueidentifier,
  @pusu_idioma_id uniqueidentifier
 )

AS

 UPDATE
  [UsuariosRegistrados]
 SET
  [usu_id] = @pusu_id,
  [usu_nombre] = @pusu_nombre,
  [usu_apellido] = @pusu_apellido,
  [usu_nick] = @pusu_nick,
  [usu_password] = @pusu_password,
  [usu_tipodoc] = @pusu_tipodoc,
  [usu_doc] = @pusu_doc,
  [usu_fecha_nac] = @pusu_fecha_nac,
  [usu_telefono] = @pusu_telefono,
  [usu_email] = @pusu_email,
  [usu_desarrolla] = @pusu_desarrolla,
  [usu_interno] = @pusu_interno,
  [usu_suscripcion] = @pusu_suscripcion,
  [usu_CUIT] = @pusu_CUIT,
  [usu_CUIL] = @pusu_CUIL,
  [usu_iva_id] = @pusu_iva_id,
  [usu_estado] = @pusu_estado,
  [usu_idioma_id] = @pusu_idioma_id
 WHERE
  [usu_id] = @pusu_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosRegistrados_Borrar]'))
DROP PROCEDURE [dbo].[SP_UsuariosRegistrados_Borrar]
GO

CREATE PROCEDURE SP_UsuariosRegistrados_Borrar
 (
  @pusu_id uniqueidentifier
 )

AS

 DELETE FROM
  [UsuariosRegistrados]
 WHERE
  (
   [usu_id] = @pusu_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosRegistrados_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_UsuariosRegistrados_ConsultarTodos]
GO

CREATE PROCEDURE SP_UsuariosRegistrados_ConsultarTodos

AS

 SELECT
  [usu_id],
  [usu_nombre],
  [usu_apellido],
  [usu_nick],
  [usu_password],
  [usu_tipodoc],
  [usu_doc],
  [usu_fecha_nac],
  [usu_telefono],
  [usu_email],
  [usu_desarrolla],
  [usu_interno],
  [usu_suscripcion],
  [usu_CUIT],
  [usu_CUIL],
  [usu_iva_id],
  [usu_estado],
  [usu_idioma_id]
 FROM
  [UsuariosRegistrados]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosRegistrados_Consultar]'))
DROP PROCEDURE [dbo].[SP_UsuariosRegistrados_Consultar]
GO

CREATE PROCEDURE SP_UsuariosRegistrados_Consultar
 (
  @pusu_id uniqueidentifier
 )

AS

 SELECT
  [usu_id],
  [usu_nombre],
  [usu_apellido],
  [usu_nick],
  [usu_password],
  [usu_tipodoc],
  [usu_doc],
  [usu_fecha_nac],
  [usu_telefono],
  [usu_email],
  [usu_desarrolla],
  [usu_interno],
  [usu_suscripcion],
  [usu_CUIT],
  [usu_CUIL],
  [usu_iva_id],
  [usu_estado],
  [usu_idioma_id]
 FROM
  [UsuariosRegistrados]
 WHERE
  (
   [usu_id] = @pusu_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_UsuariosRegistrados_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_UsuariosRegistrados_ConsultarPor]
GO

CREATE PROCEDURE SP_UsuariosRegistrados_ConsultarPor
 (
  @pusu_id uniqueidentifier = NULL,
  @pusu_nombre varchar(50) = NULL,
  @pusu_apellido varchar(50) = NULL,
  @pusu_nick varchar(50) = NULL,
  @pusu_password varchar(50) = NULL,
  @pusu_tipodoc varchar(20) = NULL,
  @pusu_doc varchar(50) = NULL,
  @pusu_fecha_nac datetime = NULL,
  @pusu_telefono int = NULL,
  @pusu_email varchar(50) = NULL,
  @pusu_desarrolla bit = NULL,
  @pusu_interno bit = NULL,
  @pusu_suscripcion bit = NULL,
  @pusu_CUIT varchar(50) = NULL,
  @pusu_CUIL varchar(50) = NULL,
  @pusu_iva_id uniqueidentifier = NULL,
  @pusu_estado uniqueidentifier = NULL,
  @pusu_idioma_id uniqueidentifier = NULL
 )

AS

  SELECT
   [usu_id],
   [usu_nombre],
   [usu_apellido],
   [usu_nick],
   [usu_password],
   [usu_tipodoc],
   [usu_doc],
   [usu_fecha_nac],
   [usu_telefono],
   [usu_email],
   [usu_desarrolla],
   [usu_interno],
   [usu_suscripcion],
   [usu_CUIT],
   [usu_CUIL],
   [usu_iva_id],
   [usu_estado],
   [usu_idioma_id]
  FROM
   [UsuariosRegistrados] WITH(NOLOCK)
  WHERE
   (
    (@pusu_id IS NULL OR [usu_id] = @pusu_id)
     AND
    (@pusu_nombre IS NULL OR [usu_nombre] LIKE ('%' + @pusu_nombre + '%'))
     AND
    (@pusu_apellido IS NULL OR [usu_apellido] LIKE ('%' + @pusu_apellido + '%'))
     AND
    (@pusu_nick IS NULL OR [usu_nick] LIKE ('%' + @pusu_nick + '%'))
     AND
    (@pusu_password IS NULL OR [usu_password] LIKE ('%' + @pusu_password + '%'))
     AND
    (@pusu_tipodoc IS NULL OR [usu_tipodoc] LIKE ('%' + @pusu_tipodoc + '%'))
     AND
    (@pusu_doc IS NULL OR [usu_doc] LIKE ('%' + @pusu_doc + '%'))
     AND
    (@pusu_fecha_nac IS NULL OR [usu_fecha_nac] = @pusu_fecha_nac)
     AND
    (@pusu_telefono IS NULL OR [usu_telefono] = @pusu_telefono)
     AND
    (@pusu_email IS NULL OR [usu_email] LIKE ('%' + @pusu_email + '%'))
     AND
    (@pusu_desarrolla IS NULL OR [usu_desarrolla] = @pusu_desarrolla)
     AND
    (@pusu_interno IS NULL OR [usu_interno] = @pusu_interno)
     AND
    (@pusu_suscripcion IS NULL OR [usu_suscripcion] = @pusu_suscripcion)
     AND
    (@pusu_CUIT IS NULL OR [usu_CUIT] LIKE ('%' + @pusu_CUIT + '%'))
     AND
    (@pusu_CUIL IS NULL OR [usu_CUIL] LIKE ('%' + @pusu_CUIL + '%'))
     AND
    (@pusu_iva_id IS NULL OR [usu_iva_id] = @pusu_iva_id)
     AND
    (@pusu_estado IS NULL OR [usu_estado] = @pusu_estado)
     AND
    (@pusu_idioma_id IS NULL OR [usu_idioma_id] = @pusu_idioma_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [VentaEstados]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentaEstados_Insertar]'))
DROP PROCEDURE [dbo].[SP_VentaEstados_Insertar]
GO

CREATE PROCEDURE SP_VentaEstados_Insertar
 (
  @pve_id uniqueidentifier,
  @pve_descripcion varchar(50)
 )

AS

 INSERT INTO [VentaEstados]
  (
   [ve_id],
   [ve_descripcion]
  )
 VALUES
  (
   @pve_id,
   @pve_descripcion
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentaEstados_Actualizar]'))
DROP PROCEDURE [dbo].[SP_VentaEstados_Actualizar]
GO

CREATE PROCEDURE SP_VentaEstados_Actualizar
 (
  @pve_id uniqueidentifier,
  @pve_descripcion varchar(50)
 )

AS

 UPDATE
  [VentaEstados]
 SET
  [ve_id] = @pve_id,
  [ve_descripcion] = @pve_descripcion
 WHERE
  [ve_id] = @pve_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentaEstados_Borrar]'))
DROP PROCEDURE [dbo].[SP_VentaEstados_Borrar]
GO

CREATE PROCEDURE SP_VentaEstados_Borrar
 (
  @pve_id uniqueidentifier
 )

AS

 DELETE FROM
  [VentaEstados]
 WHERE
  (
   [ve_id] = @pve_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentaEstados_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_VentaEstados_ConsultarTodos]
GO

CREATE PROCEDURE SP_VentaEstados_ConsultarTodos

AS

 SELECT
  [ve_id],
  [ve_descripcion]
 FROM
  [VentaEstados]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentaEstados_Consultar]'))
DROP PROCEDURE [dbo].[SP_VentaEstados_Consultar]
GO

CREATE PROCEDURE SP_VentaEstados_Consultar
 (
  @pve_id uniqueidentifier
 )

AS

 SELECT
  [ve_id],
  [ve_descripcion]
 FROM
  [VentaEstados]
 WHERE
  (
   [ve_id] = @pve_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentaEstados_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_VentaEstados_ConsultarPor]
GO

CREATE PROCEDURE SP_VentaEstados_ConsultarPor
 (
  @pve_id uniqueidentifier = NULL,
  @pve_descripcion varchar(50) = NULL
 )

AS

  SELECT
   [ve_id],
   [ve_descripcion]
  FROM
   [VentaEstados] WITH(NOLOCK)
  WHERE
   (
    (@pve_id IS NULL OR [ve_id] = @pve_id)
     AND
    (@pve_descripcion IS NULL OR [ve_descripcion] LIKE ('%' + @pve_descripcion + '%'))
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [Ventas]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Ventas_Insertar]'))
DROP PROCEDURE [dbo].[SP_Ventas_Insertar]
GO

CREATE PROCEDURE SP_Ventas_Insertar
 (
  @pvent_id uniqueidentifier,
  @pvent_usu_id uniqueidentifier,
  @pvent_fecha datetime,
  @pvent_lugar_entrega varchar(500),
  @pvent_plazo_entrega varchar(50),
  @pvent_importe numeric(18,0),
  @pvent_promocion numeric(18,0),
  @pvent_imp_total numeric(18,0),
  @pvent_tpago_id uniqueidentifier,
  @pvent_iva numeric(18,0)
 )

AS

 INSERT INTO [Ventas]
  (
   [vent_id],
   [vent_usu_id],
   [vent_fecha],
   [vent_lugar_entrega],
   [vent_plazo_entrega],
   [vent_importe],
   [vent_promocion],
   [vent_imp_total],
   [vent_tpago_id],
   [vent_iva]
  )
 VALUES
  (
   @pvent_id,
   @pvent_usu_id,
   @pvent_fecha,
   @pvent_lugar_entrega,
   @pvent_plazo_entrega,
   @pvent_importe,
   @pvent_promocion,
   @pvent_imp_total,
   @pvent_tpago_id,
   @pvent_iva
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Ventas_Actualizar]'))
DROP PROCEDURE [dbo].[SP_Ventas_Actualizar]
GO

CREATE PROCEDURE SP_Ventas_Actualizar
 (
  @pvent_id uniqueidentifier,
  @pvent_usu_id uniqueidentifier,
  @pvent_fecha datetime,
  @pvent_lugar_entrega varchar(500),
  @pvent_plazo_entrega varchar(50),
  @pvent_importe numeric(18,0),
  @pvent_promocion numeric(18,0),
  @pvent_imp_total numeric(18,0),
  @pvent_tpago_id uniqueidentifier,
  @pvent_iva numeric(18,0)
 )

AS

 UPDATE
  [Ventas]
 SET
  [vent_id] = @pvent_id,
  [vent_usu_id] = @pvent_usu_id,
  [vent_fecha] = @pvent_fecha,
  [vent_lugar_entrega] = @pvent_lugar_entrega,
  [vent_plazo_entrega] = @pvent_plazo_entrega,
  [vent_importe] = @pvent_importe,
  [vent_promocion] = @pvent_promocion,
  [vent_imp_total] = @pvent_imp_total,
  [vent_tpago_id] = @pvent_tpago_id,
  [vent_iva] = @pvent_iva
 WHERE
  [vent_id] = @pvent_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Ventas_Borrar]'))
DROP PROCEDURE [dbo].[SP_Ventas_Borrar]
GO

CREATE PROCEDURE SP_Ventas_Borrar
 (
  @pvent_id uniqueidentifier
 )

AS

 DELETE FROM
  [Ventas]
 WHERE
  (
   [vent_id] = @pvent_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Ventas_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_Ventas_ConsultarTodos]
GO

CREATE PROCEDURE SP_Ventas_ConsultarTodos

AS

 SELECT
  [vent_id],
  [vent_usu_id],
  [vent_fecha],
  [vent_lugar_entrega],
  [vent_plazo_entrega],
  [vent_importe],
  [vent_promocion],
  [vent_imp_total],
  [vent_tpago_id],
  [vent_iva]
 FROM
  [Ventas]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Ventas_Consultar]'))
DROP PROCEDURE [dbo].[SP_Ventas_Consultar]
GO

CREATE PROCEDURE SP_Ventas_Consultar
 (
  @pvent_id uniqueidentifier
 )

AS

 SELECT
  [vent_id],
  [vent_usu_id],
  [vent_fecha],
  [vent_lugar_entrega],
  [vent_plazo_entrega],
  [vent_importe],
  [vent_promocion],
  [vent_imp_total],
  [vent_tpago_id],
  [vent_iva]
 FROM
  [Ventas]
 WHERE
  (
   [vent_id] = @pvent_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_Ventas_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_Ventas_ConsultarPor]
GO

CREATE PROCEDURE SP_Ventas_ConsultarPor
 (
  @pvent_id uniqueidentifier = NULL,
  @pvent_usu_id uniqueidentifier = NULL,
  @pvent_fecha datetime = NULL,
  @pvent_lugar_entrega varchar(500) = NULL,
  @pvent_plazo_entrega varchar(50) = NULL,
  @pvent_importe numeric(18,0) = NULL,
  @pvent_promocion numeric(18,0) = NULL,
  @pvent_imp_total numeric(18,0) = NULL,
  @pvent_tpago_id uniqueidentifier = NULL,
  @pvent_iva numeric(18,0) = NULL
 )

AS

  SELECT
   [vent_id],
   [vent_usu_id],
   [vent_fecha],
   [vent_lugar_entrega],
   [vent_plazo_entrega],
   [vent_importe],
   [vent_promocion],
   [vent_imp_total],
   [vent_tpago_id],
   [vent_iva]
  FROM
   [Ventas] WITH(NOLOCK)
  WHERE
   (
    (@pvent_id IS NULL OR [vent_id] = @pvent_id)
     AND
    (@pvent_usu_id IS NULL OR [vent_usu_id] = @pvent_usu_id)
     AND
    (@pvent_fecha IS NULL OR [vent_fecha] = @pvent_fecha)
     AND
    (@pvent_lugar_entrega IS NULL OR [vent_lugar_entrega] LIKE ('%' + @pvent_lugar_entrega + '%'))
     AND
    (@pvent_plazo_entrega IS NULL OR [vent_plazo_entrega] LIKE ('%' + @pvent_plazo_entrega + '%'))
     AND
    (@pvent_importe IS NULL OR [vent_importe] = @pvent_importe)
     AND
    (@pvent_promocion IS NULL OR [vent_promocion] = @pvent_promocion)
     AND
    (@pvent_imp_total IS NULL OR [vent_imp_total] = @pvent_imp_total)
     AND
    (@pvent_tpago_id IS NULL OR [vent_tpago_id] = @pvent_tpago_id)
     AND
    (@pvent_iva IS NULL OR [vent_iva] = @pvent_iva)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [VentasProductos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentasProductos_Insertar]'))
DROP PROCEDURE [dbo].[SP_VentasProductos_Insertar]
GO

CREATE PROCEDURE SP_VentasProductos_Insertar
 (
  @pvp_id uniqueidentifier,
  @pvp_prod_id uniqueidentifier,
  @pvp_vent_id uniqueidentifier
 )

AS

 INSERT INTO [VentasProductos]
  (
   [vp_id],
   [vp_prod_id],
   [vp_vent_id]
  )
 VALUES
  (
   @pvp_id,
   @pvp_prod_id,
   @pvp_vent_id
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentasProductos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_VentasProductos_Actualizar]
GO

CREATE PROCEDURE SP_VentasProductos_Actualizar
 (
  @pvp_id uniqueidentifier,
  @pvp_prod_id uniqueidentifier,
  @pvp_vent_id uniqueidentifier
 )

AS

 UPDATE
  [VentasProductos]
 SET
  [vp_id] = @pvp_id,
  [vp_prod_id] = @pvp_prod_id,
  [vp_vent_id] = @pvp_vent_id
 WHERE
  [vp_id] = @pvp_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentasProductos_Borrar]'))
DROP PROCEDURE [dbo].[SP_VentasProductos_Borrar]
GO

CREATE PROCEDURE SP_VentasProductos_Borrar
 (
  @pvp_id uniqueidentifier
 )

AS

 DELETE FROM
  [VentasProductos]
 WHERE
  (
   [vp_id] = @pvp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentasProductos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_VentasProductos_ConsultarTodos]
GO

CREATE PROCEDURE SP_VentasProductos_ConsultarTodos

AS

 SELECT
  [vp_id],
  [vp_prod_id],
  [vp_vent_id]
 FROM
  [VentasProductos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentasProductos_Consultar]'))
DROP PROCEDURE [dbo].[SP_VentasProductos_Consultar]
GO

CREATE PROCEDURE SP_VentasProductos_Consultar
 (
  @pvp_id uniqueidentifier
 )

AS

 SELECT
  [vp_id],
  [vp_prod_id],
  [vp_vent_id]
 FROM
  [VentasProductos]
 WHERE
  (
   [vp_id] = @pvp_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentasProductos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_VentasProductos_ConsultarPor]
GO

CREATE PROCEDURE SP_VentasProductos_ConsultarPor
 (
  @pvp_id uniqueidentifier = NULL,
  @pvp_prod_id uniqueidentifier = NULL,
  @pvp_vent_id uniqueidentifier = NULL
 )

AS

  SELECT
   [vp_id],
   [vp_prod_id],
   [vp_vent_id]
  FROM
   [VentasProductos] WITH(NOLOCK)
  WHERE
   (
    (@pvp_id IS NULL OR [vp_id] = @pvp_id)
     AND
    (@pvp_prod_id IS NULL OR [vp_prod_id] = @pvp_prod_id)
     AND
    (@pvp_vent_id IS NULL OR [vp_vent_id] = @pvp_vent_id)
   )

GO

--------------------------------------------------
PRINT ('Creating store procedure for [VentasSeguimientos]')
--------------------------------------------------

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentasSeguimientos_Insertar]'))
DROP PROCEDURE [dbo].[SP_VentasSeguimientos_Insertar]
GO

CREATE PROCEDURE SP_VentasSeguimientos_Insertar
 (
  @pvs_id uniqueidentifier,
  @pvs_vent_id uniqueidentifier,
  @pvs_estado_id uniqueidentifier,
  @pvs_nro_fac varchar(50),
  @pvs_comprobante varchar(25),
  @pvs_monto_adeudado numeric(18,0),
  @pvs_calificacion varchar(50),
  @pvs_comentarios varchar(500)
 )

AS

 INSERT INTO [VentasSeguimientos]
  (
   [vs_id],
   [vs_vent_id],
   [vs_estado_id],
   [vs_nro_fac],
   [vs_comprobante],
   [vs_monto_adeudado],
   [vs_calificacion],
   [vs_comentarios]
  )
 VALUES
  (
   @pvs_id,
   @pvs_vent_id,
   @pvs_estado_id,
   @pvs_nro_fac,
   @pvs_comprobante,
   @pvs_monto_adeudado,
   @pvs_calificacion,
   @pvs_comentarios
  )


GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentasSeguimientos_Actualizar]'))
DROP PROCEDURE [dbo].[SP_VentasSeguimientos_Actualizar]
GO

CREATE PROCEDURE SP_VentasSeguimientos_Actualizar
 (
  @pvs_id uniqueidentifier,
  @pvs_vent_id uniqueidentifier,
  @pvs_estado_id uniqueidentifier,
  @pvs_nro_fac varchar(50),
  @pvs_comprobante varchar(25),
  @pvs_monto_adeudado numeric(18,0),
  @pvs_calificacion varchar(50),
  @pvs_comentarios varchar(500)
 )

AS

 UPDATE
  [VentasSeguimientos]
 SET
  [vs_id] = @pvs_id,
  [vs_vent_id] = @pvs_vent_id,
  [vs_estado_id] = @pvs_estado_id,
  [vs_nro_fac] = @pvs_nro_fac,
  [vs_comprobante] = @pvs_comprobante,
  [vs_monto_adeudado] = @pvs_monto_adeudado,
  [vs_calificacion] = @pvs_calificacion,
  [vs_comentarios] = @pvs_comentarios
 WHERE
  [vs_id] = @pvs_id

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentasSeguimientos_Borrar]'))
DROP PROCEDURE [dbo].[SP_VentasSeguimientos_Borrar]
GO

CREATE PROCEDURE SP_VentasSeguimientos_Borrar
 (
  @pvs_id uniqueidentifier
 )

AS

 DELETE FROM
  [VentasSeguimientos]
 WHERE
  (
   [vs_id] = @pvs_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentasSeguimientos_ConsultarTodos]'))
DROP PROCEDURE [dbo].[SP_VentasSeguimientos_ConsultarTodos]
GO

CREATE PROCEDURE SP_VentasSeguimientos_ConsultarTodos

AS

 SELECT
  [vs_id],
  [vs_vent_id],
  [vs_estado_id],
  [vs_nro_fac],
  [vs_comprobante],
  [vs_monto_adeudado],
  [vs_calificacion],
  [vs_comentarios]
 FROM
  [VentasSeguimientos]

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentasSeguimientos_Consultar]'))
DROP PROCEDURE [dbo].[SP_VentasSeguimientos_Consultar]
GO

CREATE PROCEDURE SP_VentasSeguimientos_Consultar
 (
  @pvs_id uniqueidentifier
 )

AS

 SELECT
  [vs_id],
  [vs_vent_id],
  [vs_estado_id],
  [vs_nro_fac],
  [vs_comprobante],
  [vs_monto_adeudado],
  [vs_calificacion],
  [vs_comentarios]
 FROM
  [VentasSeguimientos]
 WHERE
  (
   [vs_id] = @pvs_id
  )

GO

IF EXISTS (SELECT * FROM [sys].[objects] WHERE [object_id] = OBJECT_ID('[dbo].[SP_VentasSeguimientos_ConsultarPor]'))
DROP PROCEDURE [dbo].[SP_VentasSeguimientos_ConsultarPor]
GO

CREATE PROCEDURE SP_VentasSeguimientos_ConsultarPor
 (
  @pvs_id uniqueidentifier = NULL,
  @pvs_vent_id uniqueidentifier = NULL,
  @pvs_estado_id uniqueidentifier = NULL,
  @pvs_nro_fac varchar(50) = NULL,
  @pvs_comprobante varchar(25) = NULL,
  @pvs_monto_adeudado numeric(18,0) = NULL,
  @pvs_calificacion varchar(50) = NULL,
  @pvs_comentarios varchar(500) = NULL
 )

AS

  SELECT
   [vs_id],
   [vs_vent_id],
   [vs_estado_id],
   [vs_nro_fac],
   [vs_comprobante],
   [vs_monto_adeudado],
   [vs_calificacion],
   [vs_comentarios]
  FROM
   [VentasSeguimientos] WITH(NOLOCK)
  WHERE
   (
    (@pvs_id IS NULL OR [vs_id] = @pvs_id)
     AND
    (@pvs_vent_id IS NULL OR [vs_vent_id] = @pvs_vent_id)
     AND
    (@pvs_estado_id IS NULL OR [vs_estado_id] = @pvs_estado_id)
     AND
    (@pvs_nro_fac IS NULL OR [vs_nro_fac] LIKE ('%' + @pvs_nro_fac + '%'))
     AND
    (@pvs_comprobante IS NULL OR [vs_comprobante] LIKE ('%' + @pvs_comprobante + '%'))
     AND
    (@pvs_monto_adeudado IS NULL OR [vs_monto_adeudado] = @pvs_monto_adeudado)
     AND
    (@pvs_calificacion IS NULL OR [vs_calificacion] LIKE ('%' + @pvs_calificacion + '%'))
     AND
    (@pvs_comentarios IS NULL OR [vs_comentarios] LIKE ('%' + @pvs_comentarios + '%'))
   )

GO

