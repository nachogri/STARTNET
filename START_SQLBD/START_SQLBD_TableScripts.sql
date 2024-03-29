USE [START_SQLBD]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Localidades]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Localidades](
	[loc_id] [uniqueidentifier] NOT NULL,
	[loc_nombre] [nvarchar](50) NOT NULL,
	[loc_cp] [nvarchar](50) NOT NULL,
	[loc_prov_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[loc_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Paises]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Paises](
	[pais_id] [uniqueidentifier] NOT NULL,
	[pais_nacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
(
	[pais_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Provincias]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Provincias](
	[prov_id] [uniqueidentifier] NOT NULL,
	[prov_nombre] [varchar](50) NOT NULL,
	[prov_pais_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[prov_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Paginas]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Paginas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Paginas](
	[pag_id] [uniqueidentifier] NOT NULL,
	[pag_nombre] [nvarchar](50) NOT NULL,
	[pag_descrip] [nvarchar](50) NULL,
 CONSTRAINT [PK_Paginas] PRIMARY KEY CLUSTERED 
(
	[pag_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ClienteEstados]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClienteEstados]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClienteEstados](
	[cest_id] [uniqueidentifier] NOT NULL,
	[cest_descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ClienteEstados] PRIMARY KEY CLUSTERED 
(
	[cest_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CondicionIVA]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CondicionIVA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CondicionIVA](
	[civa_id] [uniqueidentifier] NOT NULL,
	[civa_descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CondicionIVA] PRIMARY KEY CLUSTERED 
(
	[civa_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Monedas]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Monedas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Monedas](
	[mon_id] [uniqueidentifier] NOT NULL,
	[mon_nombre] [nvarchar](50) NOT NULL,
	[mon_simbolo] [nvarchar](50) NOT NULL,
	[mon_cambio_dolar] [int] NOT NULL,
 CONSTRAINT [PK_Monedas] PRIMARY KEY CLUSTERED 
(
	[mon_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[MovimientosStock]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MovimientosStock]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MovimientosStock](
	[ms_id] [uniqueidentifier] NOT NULL,
	[ms_fecha] [datetime] NOT NULL,
	[ms_prod_id] [uniqueidentifier] NOT NULL,
	[ms_vent_id] [uniqueidentifier] NULL,
	[ms_tipo] [nvarchar](50) NOT NULL,
	[ms_cantidad] [int] NOT NULL,
	[ms_monto] [numeric](18, 0) NOT NULL,
	[ms_oc_id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_MovimientosStock] PRIMARY KEY CLUSTERED 
(
	[ms_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[OrdenesCompraProductos]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrdenesCompraProductos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrdenesCompraProductos](
	[ocp_id] [uniqueidentifier] NOT NULL,
	[ocp_oc_id] [uniqueidentifier] NOT NULL,
	[ocp_prod_id] [uniqueidentifier] NOT NULL,
	[ocp_cantidad] [int] NOT NULL,
 CONSTRAINT [PK_OrdenesCompraProductos] PRIMARY KEY CLUSTERED 
(
	[ocp_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PedidosCotizacion]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PedidosCotizacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PedidosCotizacion](
	[pc_id] [uniqueidentifier] NOT NULL,
	[pc_prov_id] [uniqueidentifier] NOT NULL,
	[pc_fecha] [datetime] NOT NULL,
	[pc_comentarios] [nvarchar](500) NULL,
	[pc_usu_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PedidosCotizacion] PRIMARY KEY CLUSTERED 
(
	[pc_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PedidosCotizacionProductos]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PedidosCotizacionProductos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PedidosCotizacionProductos](
	[pcp_id] [uniqueidentifier] NOT NULL,
	[pcp_pc_id] [uniqueidentifier] NOT NULL,
	[pcp_cantidad] [int] NOT NULL,
 CONSTRAINT [PK_PedidosCotizacionProductos] PRIMARY KEY CLUSTERED 
(
	[pcp_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PedidosReaprovisionamiento]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PedidosReaprovisionamiento]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PedidosReaprovisionamiento](
	[pra_id] [uniqueidentifier] NOT NULL,
	[pra_oc_id] [uniqueidentifier] NOT NULL,
	[pra_usu_id] [uniqueidentifier] NOT NULL,
	[pra_fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_PedidosReaprovisionamiento] PRIMARY KEY CLUSTERED 
(
	[pra_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PedidosReaprovisionamientoProductos]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PedidosReaprovisionamientoProductos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PedidosReaprovisionamientoProductos](
	[prap_id] [uniqueidentifier] NOT NULL,
	[prap_pra_id] [uniqueidentifier] NOT NULL,
	[prap_prod_id] [uniqueidentifier] NOT NULL,
	[prap_cantidad] [int] NOT NULL,
 CONSTRAINT [PK_PedidosReaprovisionamientoProductos] PRIMARY KEY CLUSTERED 
(
	[prap_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Promociones]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Promociones]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Promociones](
	[promo_id] [uniqueidentifier] NOT NULL,
	[promo_nombre] [nvarchar](50) NOT NULL,
	[promo_expiracion] [datetime] NOT NULL,
	[promo_requisitos] [nvarchar](500) NULL,
 CONSTRAINT [PK_Promociones] PRIMARY KEY CLUSTERED 
(
	[promo_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PromocionesProductos]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PromocionesProductos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PromocionesProductos](
	[promp_id] [uniqueidentifier] NOT NULL,
	[promp_prod_id] [uniqueidentifier] NOT NULL,
	[promp_promo_id] [uniqueidentifier] NOT NULL,
	[promp_regalo] [bit] NOT NULL,
	[promp_descuento] [int] NOT NULL,
 CONSTRAINT [PK_PromocionesProductos] PRIMARY KEY CLUSTERED 
(
	[promp_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proveedores]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Proveedores](
	[prov_id] [uniqueidentifier] NOT NULL,
	[prov_nombre] [nvarchar](100) NOT NULL,
	[prov_email] [nvarchar](50) NOT NULL,
	[prov_telefono] [nvarchar](50) NOT NULL,
	[prov_dom_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[prov_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UsuariosRegistrados]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuariosRegistrados]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UsuariosRegistrados](
	[usu_id] [uniqueidentifier] NOT NULL,
	[usu_nombre] [nvarchar](50) NOT NULL,
	[usu_apellido] [nvarchar](50) NOT NULL,
	[usu_nick] [nvarchar](50) NOT NULL,
	[usu_password] [nvarchar](50) NOT NULL,
	[usu_tipodoc] [nvarchar](20) NOT NULL,
	[usu_doc] [nvarchar](50) NOT NULL,
	[usu_fecha_nac] [datetime] NOT NULL,
	[usu_telefono] [int] NULL,
	[usu_email] [nvarchar](50) NULL,
	[usu_desarrolla] [bit] NOT NULL,
	[usu_interno] [bit] NOT NULL,
	[usu_suscripcion] [bit] NOT NULL,
	[usu_CUIT] [nvarchar](50) NULL,
	[usu_CUIL] [nvarchar](50) NULL,
	[usu_iva_id] [uniqueidentifier] NOT NULL,
	[usu_estado] [uniqueidentifier] NOT NULL,
	[usu_idioma_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UsuariosRegistrados] PRIMARY KEY CLUSTERED 
(
	[usu_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VentaEstados]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentaEstados]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VentaEstados](
	[ve_id] [uniqueidentifier] NOT NULL,
	[ve_descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_VentaEstados] PRIMARY KEY CLUSTERED 
(
	[ve_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ventas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Ventas](
	[vent_id] [uniqueidentifier] NOT NULL,
	[vent_usu_id] [uniqueidentifier] NOT NULL,
	[vent_fecha] [datetime] NOT NULL,
	[vent_lugar_entrega] [nvarchar](500) NOT NULL,
	[vent_plazo_entrega] [nvarchar](50) NOT NULL,
	[vent_importe] [numeric](18, 0) NOT NULL,
	[vent_promocion] [numeric](18, 0) NULL,
	[vent_imp_total] [numeric](18, 0) NOT NULL,
	[vent_tpago_id] [uniqueidentifier] NULL,
	[vent_iva] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[vent_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProveedoresProductos]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProveedoresProductos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProveedoresProductos](
	[pp_id] [uniqueidentifier] NOT NULL,
	[pp_prov_id] [uniqueidentifier] NOT NULL,
	[pp_prod_id] [uniqueidentifier] NOT NULL,
	[pp_costo] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_ProveedoresProductos] PRIMARY KEY CLUSTERED 
(
	[pp_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PagosProveedores]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PagosProveedores]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PagosProveedores](
	[pagp_id] [uniqueidentifier] NOT NULL,
	[pagp_proveedor_id] [uniqueidentifier] NOT NULL,
	[pagp_fecha] [datetime] NOT NULL,
	[pagp_monto] [numeric](18, 0) NOT NULL,
	[pagp_nro_factura] [nvarchar](50) NOT NULL,
	[pagp_comentarios] [nvarchar](500) NULL,
 CONSTRAINT [PK_PagosProveedores] PRIMARY KEY CLUSTERED 
(
	[pagp_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[OrdenesCompra]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrdenesCompra]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrdenesCompra](
	[oc_id] [uniqueidentifier] NOT NULL,
	[oc_pagp_id] [uniqueidentifier] NOT NULL,
	[oc_prov_id] [uniqueidentifier] NOT NULL,
	[oc_fecha] [datetime] NOT NULL,
	[oc_fecha_entrega] [datetime] NOT NULL,
	[oc_monto_total] [numeric](18, 0) NOT NULL,
	[oc_condiciones_pago] [nvarchar](50) NOT NULL,
	[oc_comentarios] [nvarchar](500) NULL,
	[oc_usu_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_OrdenesCompra] PRIMARY KEY CLUSTERED 
(
	[oc_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VentasSeguimientos]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasSeguimientos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VentasSeguimientos](
	[vs_id] [uniqueidentifier] NOT NULL,
	[vs_vent_id] [uniqueidentifier] NOT NULL,
	[vs_estado_id] [uniqueidentifier] NOT NULL,
	[vs_nro_fac] [nvarchar](50) NOT NULL,
	[vs_comprobante] [nvarchar](25) NOT NULL,
	[vs_monto_adeudado] [numeric](18, 0) NOT NULL,
	[vs_calificacion] [nvarchar](50) NOT NULL,
	[vs_comentarios] [nvarchar](500) NULL,
 CONSTRAINT [PK_VentasSeguimientos] PRIMARY KEY CLUSTERED 
(
	[vs_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FamiliasPatentes]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FamiliasPatentes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FamiliasPatentes](
	[fp_fam_id] [uniqueidentifier] NOT NULL,
	[fp_pat_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_FamiliasPatentes] PRIMARY KEY CLUSTERED 
(
	[fp_fam_id] ASC,
	[fp_pat_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FormatosCulturas]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FormatosCulturas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FormatosCulturas](
	[fc_id] [uniqueidentifier] NOT NULL,
	[fc_hora] [nvarchar](25) NULL,
	[fc_fecha] [nvarchar](25) NULL,
	[fc_numeros] [nvarchar](25) NULL,
	[fc_idioma_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_FormatosCulturas] PRIMARY KEY CLUSTERED 
(
	[fc_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ForoComentarios]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ForoComentarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ForoComentarios](
	[fc_id] [uniqueidentifier] NOT NULL,
	[fc_fecha] [datetime] NOT NULL,
	[fc_usu_id] [uniqueidentifier] NOT NULL,
	[fc_ft_id] [uniqueidentifier] NOT NULL,
	[fc_mensaje] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_ForoComentarios] PRIMARY KEY CLUSTERED 
(
	[fc_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ForoTopicos]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ForoTopicos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ForoTopicos](
	[ft_id] [uniqueidentifier] NOT NULL,
	[ft_fecha_alta] [datetime] NOT NULL,
	[ft_usu_id] [uniqueidentifier] NOT NULL,
	[ft_descrip] [nvarchar](150) NOT NULL,
	[ft_activo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ForoTopicos] PRIMARY KEY CLUSTERED 
(
	[ft_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Idiomas]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Idiomas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Idiomas](
	[idioma_id] [uniqueidentifier] NOT NULL,
	[idioma_nombre] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Idiomas] PRIMARY KEY CLUSTERED 
(
	[idioma_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Leyendas]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Leyendas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Leyendas](
	[ley_id] [uniqueidentifier] NOT NULL,
	[ley_clase_contenedor] [nvarchar](30) NOT NULL,
	[ley_objeto] [nvarchar](30) NOT NULL,
	[ley_indice] [int] NULL,
	[ley_idioma_id] [uniqueidentifier] NOT NULL,
	[ley_texto1] [nvarchar](500) NOT NULL,
	[ley_texto2] [nvarchar](500) NULL,
	[ley_texto3] [nvarchar](500) NULL,
	[ley_tooltip] [nvarchar](200) NULL,
	[ley_typeof] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Leyendas] PRIMARY KEY CLUSTERED 
(
	[ley_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Navegaciones]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Navegaciones]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Navegaciones](
	[nav_log_id] [uniqueidentifier] NOT NULL,
	[nav_pag_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Navegaciones] PRIMARY KEY CLUSTERED 
(
	[nav_log_id] ASC,
	[nav_pag_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Patentes]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Patentes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Patentes](
	[pat_id] [uniqueidentifier] NOT NULL,
	[pat_descrip] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Patentes] PRIMARY KEY CLUSTERED 
(
	[pat_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Reparaciones]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reparaciones]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reparaciones](
	[rep_id] [uniqueidentifier] NOT NULL,
	[rep_usu_id] [uniqueidentifier] NOT NULL,
	[rep_fecha_recepcion] [datetime] NOT NULL,
	[rep_fecha_devolucion] [datetime] NULL,
	[rep_importe_total] [numeric](18, 0) NOT NULL,
	[rep_tpago_id] [uniqueidentifier] NOT NULL,
	[rep_estado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Reparaciones] PRIMARY KEY CLUSTERED 
(
	[rep_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ReparacionesProductos]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReparacionesProductos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReparacionesProductos](
	[rp_id] [uniqueidentifier] NOT NULL,
	[rp_rep_id] [uniqueidentifier] NOT NULL,
	[rp_prod_id] [uniqueidentifier] NOT NULL,
	[rp_modelo] [nvarchar](50) NOT NULL,
	[rp_garantia] [nvarchar](50) NULL,
	[rp_propio] [nvarchar](50) NOT NULL,
	[rp_problema] [nvarchar](50) NOT NULL,
	[rp_solucion] [nvarchar](50) NULL,
	[rp_comentarios] [nvarchar](100) NULL,
	[rp_repuestos] [nvarchar](50) NULL,
 CONSTRAINT [PK_ReparacionesProductos] PRIMARY KEY CLUSTERED 
(
	[rp_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TipoPagos]    Script Date: 08/21/2011 18:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoPagos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TipoPagos](
	[tpago_id] [uniqueidentifier] NOT NULL,
	[tpago_descrip] [nvarchar](50) NOT NULL,
	[tpago_disponible] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoPagos] PRIMARY KEY CLUSTERED 
(
	[tpago_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TipoProductos]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoProductos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TipoProductos](
	[tprod_id] [uniqueidentifier] NOT NULL,
	[tprod_descrip] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoProductos] PRIMARY KEY CLUSTERED 
(
	[tprod_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UsuariosFamilias]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuariosFamilias]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UsuariosFamilias](
	[uf_usu_id] [uniqueidentifier] NOT NULL,
	[uf_fam_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UsuariosFamilias] PRIMARY KEY CLUSTERED 
(
	[uf_usu_id] ASC,
	[uf_fam_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UsuariosPatentes]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuariosPatentes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UsuariosPatentes](
	[up_usu_id] [uniqueidentifier] NOT NULL,
	[up_pat_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UsuariosPatentes] PRIMARY KEY CLUSTERED 
(
	[up_usu_id] ASC,
	[up_pat_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VentasProductos]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasProductos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VentasProductos](
	[vp_id] [uniqueidentifier] NOT NULL,
	[vp_prod_id] [uniqueidentifier] NOT NULL,
	[vp_vent_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_VentasProductos] PRIMARY KEY CLUSTERED 
(
	[vp_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Familias]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Familias]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Familias](
	[fam_id] [uniqueidentifier] NOT NULL,
	[fam_descrip] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Familias] PRIMARY KEY CLUSTERED 
(
	[fam_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Novedades]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Novedades]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Novedades](
	[nov_id] [uniqueidentifier] NOT NULL,
	[nov_titulo] [nvarchar](500) NOT NULL,
	[nov_descripcion] [nvarchar](max) NOT NULL,
	[nov_fecha_actualizacion] [datetime] NOT NULL,
	[nov_imagen] [image] NULL,
 CONSTRAINT [PK_Novedades] PRIMARY KEY CLUSTERED 
(
	[nov_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Domicilios]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Domicilios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Domicilios](
	[dom_id] [uniqueidentifier] NOT NULL,
	[dom_tipo] [nvarchar](50) NULL,
	[dom_calle] [nvarchar](50) NOT NULL,
	[dom_nro] [nvarchar](50) NOT NULL,
	[dom_loc_id] [uniqueidentifier] NOT NULL,
	[dom_usu_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Domicilios] PRIMARY KEY CLUSTERED 
(
	[dom_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Productos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Productos](
	[prod_id] [uniqueidentifier] NOT NULL,
	[prod_nombre] [nvarchar](50) NOT NULL,
	[prod_descrip] [nvarchar](4000) NULL,
	[prod_cantidad] [int] NOT NULL,
	[prod_moneda] [nvarchar](50) NOT NULL,
	[prod_precio] [numeric](18, 0) NOT NULL,
	[prod_PMR] [int] NOT NULL,
	[prod_dimension] [nvarchar](50) NULL,
	[prod_nacionalidad] [nvarchar](25) NULL,
	[prod_fabricante] [nvarchar](50) NULL,
	[prod_especificaciones] [nvarchar](4000) NULL,
	[prod_garantia] [nvarchar](50) NOT NULL,
	[prod_imagen] [image] NULL,
	[prod_tprod_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[prod_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[MesaAyuda]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MesaAyuda]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MesaAyuda](
	[ayu_id] [uniqueidentifier] NOT NULL,
	[ayu_pregunta] [nvarchar](500) NOT NULL,
	[ayu_psi] [int] NOT NULL,
	[ayu_pno] [int] NOT NULL,
	[ayu_res_id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_MesaAyuda] PRIMARY KEY CLUSTERED 
(
	[ayu_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Resoluciones]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Resoluciones]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Resoluciones](
	[res_id] [uniqueidentifier] NOT NULL,
	[res_solucion] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Resoluciones] PRIMARY KEY CLUSTERED 
(
	[res_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Logueos]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Logueos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Logueos](
	[log_id] [uniqueidentifier] NOT NULL,
	[log_usu_id] [uniqueidentifier] NOT NULL,
	[log_fecha] [datetime] NOT NULL,
	[log_hora_in] [nvarchar](50) NOT NULL,
	[log_hora_out] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Logueos] PRIMARY KEY CLUSTERED 
(
	[log_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Seguimientos]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Seguimientos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Seguimientos](
	[seg_log_id] [uniqueidentifier] NOT NULL,
	[seg_tar_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Seguimientos] PRIMARY KEY CLUSTERED 
(
	[seg_log_id] ASC,
	[seg_tar_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tareas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tareas](
	[tar_id] [uniqueidentifier] NOT NULL,
	[tar_nombre] [nvarchar](50) NOT NULL,
	[tar_descrip] [nvarchar](500) NULL,
 CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED 
(
	[tar_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Contactos]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contactos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contactos](
	[con_id] [uniqueidentifier] NOT NULL,
	[con_usu_id] [uniqueidentifier] NOT NULL,
	[con_fecha] [datetime] NOT NULL,
	[con_tipo] [nvarchar](50) NOT NULL,
	[con_mensaje] [nvarchar](500) NOT NULL,
	[con_respuesta] [nvarchar](500) NULL,
	[con_DVH] [int] NOT NULL,
 CONSTRAINT [PK_Contactos] PRIMARY KEY CLUSTERED 
(
	[con_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Desarrolladores]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Desarrolladores]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Desarrolladores](
	[usud_id] [uniqueidentifier] NOT NULL,
	[usud_usu_id] [uniqueidentifier] NOT NULL,
	[usud_descrip_prod] [nvarchar](100) NOT NULL,
	[usud_razon_social] [nvarchar](50) NOT NULL,
	[usud_aviso] [nvarchar](100) NOT NULL,
	[usud_comentarios] [nvarchar](100) NULL,
	[usud_imagen] [image] NULL,
 CONSTRAINT [PK_Desarrolladores] PRIMARY KEY CLUSTERED 
(
	[usud_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Descargas]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Descargas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Descargas](
	[des_id] [uniqueidentifier] NOT NULL,
	[des_tipo_archivo] [nvarchar](50) NOT NULL,
	[des_ruta] [nvarchar](50) NOT NULL,
	[des_descrip] [nvarchar](50) NULL,
	[des_especificaciones] [nvarchar](100) NULL,
	[des_fecha_actualizacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Descargas] PRIMARY KEY CLUSTERED 
(
	[des_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PatentesHabilitaciones]    Script Date: 08/21/2011 18:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PatentesHabilitaciones]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PatentesHabilitaciones](
	[ph_id] [uniqueidentifier] NOT NULL,
	[ph_pat_id] [uniqueidentifier] NOT NULL,
	[ph_objeto] [nvarchar](50) NOT NULL,
	[ph_habilitado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PatentesHabilitaciones] PRIMARY KEY CLUSTERED 
(
	[ph_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Provincias_Provincias]') AND parent_object_id = OBJECT_ID(N'[dbo].[Provincias]'))
ALTER TABLE [dbo].[Provincias]  WITH CHECK ADD  CONSTRAINT [FK_Provincias_Provincias] FOREIGN KEY([prov_id])
REFERENCES [dbo].[Provincias] ([prov_id])
GO
ALTER TABLE [dbo].[Provincias] CHECK CONSTRAINT [FK_Provincias_Provincias]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PatentesHabilitaciones_Patentes]') AND parent_object_id = OBJECT_ID(N'[dbo].[PatentesHabilitaciones]'))
ALTER TABLE [dbo].[PatentesHabilitaciones]  WITH CHECK ADD  CONSTRAINT [FK_PatentesHabilitaciones_Patentes] FOREIGN KEY([ph_pat_id])
REFERENCES [dbo].[Patentes] ([pat_id])
GO
ALTER TABLE [dbo].[PatentesHabilitaciones] CHECK CONSTRAINT [FK_PatentesHabilitaciones_Patentes]
