-- Change the database here
USE [START_SQLBD]
GO

--------------------------------------------------
PRINT ('Getting data for [ClienteEstados]')
--------------------------------------------------

DELETE FROM ClienteEstados
SET IDENTITY_INSERT [ClienteEstados] ON
SET IDENTITY_INSERT [ClienteEstados] OFF
--------------------------------------------------
PRINT ('Getting data for [CondicionIVA]')
--------------------------------------------------

DELETE FROM CondicionIVA
SET IDENTITY_INSERT [CondicionIVA] ON
SET IDENTITY_INSERT [CondicionIVA] OFF
--------------------------------------------------
PRINT ('Getting data for [Contactos]')
--------------------------------------------------

DELETE FROM Contactos
SET IDENTITY_INSERT [Contactos] ON
SET IDENTITY_INSERT [Contactos] OFF
--------------------------------------------------
PRINT ('Getting data for [Desarrolladores]')
--------------------------------------------------

DELETE FROM Desarrolladores
SET IDENTITY_INSERT [Desarrolladores] ON
SET IDENTITY_INSERT [Desarrolladores] OFF
--------------------------------------------------
PRINT ('Getting data for [Descargas]')
--------------------------------------------------

DELETE FROM Descargas
SET IDENTITY_INSERT [Descargas] ON
SET IDENTITY_INSERT [Descargas] OFF
--------------------------------------------------
PRINT ('Getting data for [Domicilios]')
--------------------------------------------------

DELETE FROM Domicilios
SET IDENTITY_INSERT [Domicilios] ON
SET IDENTITY_INSERT [Domicilios] OFF
--------------------------------------------------
PRINT ('Getting data for [Familias]')
--------------------------------------------------

DELETE FROM Familias
SET IDENTITY_INSERT [Familias] ON
SET IDENTITY_INSERT [Familias] OFF
--------------------------------------------------
PRINT ('Getting data for [FamiliasPatentes]')
--------------------------------------------------

DELETE FROM FamiliasPatentes
SET IDENTITY_INSERT [FamiliasPatentes] ON
SET IDENTITY_INSERT [FamiliasPatentes] OFF
--------------------------------------------------
PRINT ('Getting data for [FormatosCulturas]')
--------------------------------------------------

DELETE FROM FormatosCulturas
SET IDENTITY_INSERT [FormatosCulturas] ON
SET IDENTITY_INSERT [FormatosCulturas] OFF
--------------------------------------------------
PRINT ('Getting data for [ForoComentarios]')
--------------------------------------------------

DELETE FROM ForoComentarios
SET IDENTITY_INSERT [ForoComentarios] ON
SET IDENTITY_INSERT [ForoComentarios] OFF
--------------------------------------------------
PRINT ('Getting data for [ForoTopicos]')
--------------------------------------------------

DELETE FROM ForoTopicos
SET IDENTITY_INSERT [ForoTopicos] ON
SET IDENTITY_INSERT [ForoTopicos] OFF
--------------------------------------------------
PRINT ('Getting data for [Idiomas]')
--------------------------------------------------

DELETE FROM Idiomas
SET IDENTITY_INSERT [Idiomas] ON
SET IDENTITY_INSERT [Idiomas] OFF
--------------------------------------------------
PRINT ('Getting data for [Leyendas]')
--------------------------------------------------

DELETE FROM Leyendas
SET IDENTITY_INSERT [Leyendas] ON
SET IDENTITY_INSERT [Leyendas] OFF
--------------------------------------------------
PRINT ('Getting data for [Localidades]')
--------------------------------------------------

DELETE FROM Localidades
SET IDENTITY_INSERT [Localidades] ON
SET IDENTITY_INSERT [Localidades] OFF
--------------------------------------------------
PRINT ('Getting data for [Logueos]')
--------------------------------------------------

DELETE FROM Logueos
SET IDENTITY_INSERT [Logueos] ON
SET IDENTITY_INSERT [Logueos] OFF
--------------------------------------------------
PRINT ('Getting data for [MesaAyuda]')
--------------------------------------------------

DELETE FROM MesaAyuda
SET IDENTITY_INSERT [MesaAyuda] ON
SET IDENTITY_INSERT [MesaAyuda] OFF
--------------------------------------------------
PRINT ('Getting data for [Monedas]')
--------------------------------------------------

DELETE FROM Monedas
SET IDENTITY_INSERT [Monedas] ON
SET IDENTITY_INSERT [Monedas] OFF
--------------------------------------------------
PRINT ('Getting data for [MovimientosStock]')
--------------------------------------------------

DELETE FROM MovimientosStock
SET IDENTITY_INSERT [MovimientosStock] ON
SET IDENTITY_INSERT [MovimientosStock] OFF
--------------------------------------------------
PRINT ('Getting data for [Navegaciones]')
--------------------------------------------------

DELETE FROM Navegaciones
SET IDENTITY_INSERT [Navegaciones] ON
SET IDENTITY_INSERT [Navegaciones] OFF
--------------------------------------------------
PRINT ('Getting data for [Novedades]')
--------------------------------------------------

DELETE FROM Novedades
SET IDENTITY_INSERT [Novedades] ON
SET IDENTITY_INSERT [Novedades] OFF
--------------------------------------------------
PRINT ('Getting data for [OrdenesCompra]')
--------------------------------------------------

DELETE FROM OrdenesCompra
SET IDENTITY_INSERT [OrdenesCompra] ON
SET IDENTITY_INSERT [OrdenesCompra] OFF
--------------------------------------------------
PRINT ('Getting data for [OrdenesCompraProductos]')
--------------------------------------------------

DELETE FROM OrdenesCompraProductos
SET IDENTITY_INSERT [OrdenesCompraProductos] ON
SET IDENTITY_INSERT [OrdenesCompraProductos] OFF
--------------------------------------------------
PRINT ('Getting data for [Paginas]')
--------------------------------------------------

DELETE FROM Paginas
SET IDENTITY_INSERT [Paginas] ON
SET IDENTITY_INSERT [Paginas] OFF
--------------------------------------------------
PRINT ('Getting data for [PagosProveedores]')
--------------------------------------------------

DELETE FROM PagosProveedores
SET IDENTITY_INSERT [PagosProveedores] ON
SET IDENTITY_INSERT [PagosProveedores] OFF
--------------------------------------------------
PRINT ('Getting data for [Paises]')
--------------------------------------------------

DELETE FROM Paises
SET IDENTITY_INSERT [Paises] ON
SET IDENTITY_INSERT [Paises] OFF
--------------------------------------------------
PRINT ('Getting data for [Patentes]')
--------------------------------------------------

DELETE FROM Patentes
SET IDENTITY_INSERT [Patentes] ON
SET IDENTITY_INSERT [Patentes] OFF
--------------------------------------------------
PRINT ('Getting data for [PatentesHabilitaciones]')
--------------------------------------------------

DELETE FROM PatentesHabilitaciones
SET IDENTITY_INSERT [PatentesHabilitaciones] ON
SET IDENTITY_INSERT [PatentesHabilitaciones] OFF
--------------------------------------------------
PRINT ('Getting data for [PedidosCotizacion]')
--------------------------------------------------

DELETE FROM PedidosCotizacion
SET IDENTITY_INSERT [PedidosCotizacion] ON
SET IDENTITY_INSERT [PedidosCotizacion] OFF
--------------------------------------------------
PRINT ('Getting data for [PedidosCotizacionProductos]')
--------------------------------------------------

DELETE FROM PedidosCotizacionProductos
SET IDENTITY_INSERT [PedidosCotizacionProductos] ON
SET IDENTITY_INSERT [PedidosCotizacionProductos] OFF
--------------------------------------------------
PRINT ('Getting data for [PedidosReaprovisionamiento]')
--------------------------------------------------

DELETE FROM PedidosReaprovisionamiento
SET IDENTITY_INSERT [PedidosReaprovisionamiento] ON
SET IDENTITY_INSERT [PedidosReaprovisionamiento] OFF
--------------------------------------------------
PRINT ('Getting data for [PedidosReaprovisionamientoProductos]')
--------------------------------------------------

DELETE FROM PedidosReaprovisionamientoProductos
SET IDENTITY_INSERT [PedidosReaprovisionamientoProductos] ON
SET IDENTITY_INSERT [PedidosReaprovisionamientoProductos] OFF
--------------------------------------------------
PRINT ('Getting data for [Productos]')
--------------------------------------------------

DELETE FROM Productos
SET IDENTITY_INSERT [Productos] ON
SET IDENTITY_INSERT [Productos] OFF
--------------------------------------------------
PRINT ('Getting data for [Promociones]')
--------------------------------------------------

DELETE FROM Promociones
SET IDENTITY_INSERT [Promociones] ON
SET IDENTITY_INSERT [Promociones] OFF
--------------------------------------------------
PRINT ('Getting data for [PromocionesProductos]')
--------------------------------------------------

DELETE FROM PromocionesProductos
SET IDENTITY_INSERT [PromocionesProductos] ON
SET IDENTITY_INSERT [PromocionesProductos] OFF
--------------------------------------------------
PRINT ('Getting data for [Proveedores]')
--------------------------------------------------

DELETE FROM Proveedores
SET IDENTITY_INSERT [Proveedores] ON
SET IDENTITY_INSERT [Proveedores] OFF
--------------------------------------------------
PRINT ('Getting data for [ProveedoresProductos]')
--------------------------------------------------

DELETE FROM ProveedoresProductos
SET IDENTITY_INSERT [ProveedoresProductos] ON
SET IDENTITY_INSERT [ProveedoresProductos] OFF
--------------------------------------------------
PRINT ('Getting data for [Provincias]')
--------------------------------------------------

DELETE FROM Provincias
SET IDENTITY_INSERT [Provincias] ON
SET IDENTITY_INSERT [Provincias] OFF
--------------------------------------------------
PRINT ('Getting data for [Reparaciones]')
--------------------------------------------------

DELETE FROM Reparaciones
SET IDENTITY_INSERT [Reparaciones] ON
SET IDENTITY_INSERT [Reparaciones] OFF
--------------------------------------------------
PRINT ('Getting data for [ReparacionesProductos]')
--------------------------------------------------

DELETE FROM ReparacionesProductos
SET IDENTITY_INSERT [ReparacionesProductos] ON
SET IDENTITY_INSERT [ReparacionesProductos] OFF
--------------------------------------------------
PRINT ('Getting data for [Resoluciones]')
--------------------------------------------------

DELETE FROM Resoluciones
SET IDENTITY_INSERT [Resoluciones] ON
SET IDENTITY_INSERT [Resoluciones] OFF
--------------------------------------------------
PRINT ('Getting data for [Seguimientos]')
--------------------------------------------------

DELETE FROM Seguimientos
SET IDENTITY_INSERT [Seguimientos] ON
SET IDENTITY_INSERT [Seguimientos] OFF
--------------------------------------------------
PRINT ('Getting data for [Tareas]')
--------------------------------------------------

DELETE FROM Tareas
SET IDENTITY_INSERT [Tareas] ON
SET IDENTITY_INSERT [Tareas] OFF
--------------------------------------------------
PRINT ('Getting data for [TipoPagos]')
--------------------------------------------------

DELETE FROM TipoPagos
SET IDENTITY_INSERT [TipoPagos] ON
SET IDENTITY_INSERT [TipoPagos] OFF
--------------------------------------------------
PRINT ('Getting data for [TipoProductos]')
--------------------------------------------------

DELETE FROM TipoProductos
SET IDENTITY_INSERT [TipoProductos] ON
SET IDENTITY_INSERT [TipoProductos] OFF
--------------------------------------------------
PRINT ('Getting data for [UsuariosFamilias]')
--------------------------------------------------

DELETE FROM UsuariosFamilias
SET IDENTITY_INSERT [UsuariosFamilias] ON
SET IDENTITY_INSERT [UsuariosFamilias] OFF
--------------------------------------------------
PRINT ('Getting data for [UsuariosPatentes]')
--------------------------------------------------

DELETE FROM UsuariosPatentes
SET IDENTITY_INSERT [UsuariosPatentes] ON
SET IDENTITY_INSERT [UsuariosPatentes] OFF
--------------------------------------------------
PRINT ('Getting data for [UsuariosRegistrados]')
--------------------------------------------------

DELETE FROM UsuariosRegistrados
SET IDENTITY_INSERT [UsuariosRegistrados] ON
SET IDENTITY_INSERT [UsuariosRegistrados] OFF
--------------------------------------------------
PRINT ('Getting data for [VentaEstados]')
--------------------------------------------------

DELETE FROM VentaEstados
SET IDENTITY_INSERT [VentaEstados] ON
SET IDENTITY_INSERT [VentaEstados] OFF
--------------------------------------------------
PRINT ('Getting data for [Ventas]')
--------------------------------------------------

DELETE FROM Ventas
SET IDENTITY_INSERT [Ventas] ON
SET IDENTITY_INSERT [Ventas] OFF
--------------------------------------------------
PRINT ('Getting data for [VentasProductos]')
--------------------------------------------------

DELETE FROM VentasProductos
SET IDENTITY_INSERT [VentasProductos] ON
SET IDENTITY_INSERT [VentasProductos] OFF
--------------------------------------------------
PRINT ('Getting data for [VentasSeguimientos]')
--------------------------------------------------

DELETE FROM VentasSeguimientos
SET IDENTITY_INSERT [VentasSeguimientos] ON
SET IDENTITY_INSERT [VentasSeguimientos] OFF
