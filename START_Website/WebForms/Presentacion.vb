Public MustInherit Class WebForms_Presentacion
    Inherits System.Web.UI.Page

#Region "Metodos comunes"
    ''' <summary>
    ''' Procedimiento para instanciar todos los objetos internos a la pantalla implementadora
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub Inicializacion()

    ''' <summary>
    ''' Procedimiento para consultar los datos necesario para la utilizacion de la pantalla
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub LlenarControles()
    ''' <summary>
    ''' Function que valida la consistencia de los datos que van a ser ingresados por el usuario
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function ValidarConsistencia() As Boolean
    ''' <summary>
    ''' Procedimiento que ejecuta la acción principal de la pantalla
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub EjecutarAccion()
    ''' <summary>
    ''' Procedimiento para mostrar mensajes de alerta, error o informacion si se necesitaran
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub MostrarMensaje(ByVal pMensaje As String)

    ''' <summary>
    ''' Procedimiento en el cual se va a realizar una impresion si se necesitara
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub Imprimir()

    ''' <summary>
    ''' Procedimiento en el cual se matan a los objetos internos a la pantalla implementadora
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub Finalizacion()

#End Region
End Class