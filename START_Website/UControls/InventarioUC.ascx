<%@ Control Language="VB" AutoEventWireup="false"  Inherits="START_Website.WebForms_UControls_InventarioUC" Codebehind="InventarioUC.ascx.vb" %>
<asp:GridView ID="grvInventario"  runat="server" AutoGenerateColumns="False" 
    Width="100%" BorderStyle="None" GridLines="None" 
    style="padding-right:5px; " cellpadding="0" cellspacing="0" 
    class="LetraGeneral" BorderWidth="0px" AllowPaging="True" PageSize="3" 
    Font-Bold="False" Font-Names="Arial" Font-Size="XX-Small" 
    Font-Underline="False" >
    <Columns>
    <asp:TemplateField>
        <ItemTemplate>
         <table style="padding-right:5px; " 
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td>
                        </td>
                    <td rowspan="4">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/webForms/hlrImageLoader.ashx?Table=Productos&Id=" & DataBinder.Eval(Container.DataItem, "Identificador").ToString()%>'/> 
                    </td>
                    <td>
                        <a>
                            <asp:Label ID="lblTitulo" class="LetraFormateadaNegraBold" runat="server"><%#DataBinder.Eval(Container.DataItem, "Nombre")%></asp:Label>                        
                    </td>
                    <td>
                            <asp:ImageButton  ID="Image11" runat="server" Visible=<%# UsuarioLogueado %> PostBackUrl=<%# "~/webForms/VentaForm.aspx?IdProducto=" & DataBinder.Eval(Container.DataItem, "Identificador").ToString()%> ImageUrl= "~/Images/carrito.jpg"  />
                    </td>
                </tr>
                <tr>
                    <td style="height: 48px">
                        </td>
                    <td style="height: 48px">
                        Precio: <asp:Label ID="lblPrecio" runat="server"><%#DataBinder.Eval(Container.DataItem, "Precio")%></asp:Label><br />
                        Fabricante: <asp:Label ID="lblFabricante" runat="server"><%#DataBinder.Eval(Container.DataItem, "Fabricante")%></asp:Label>
                        <br />
                        Orígen: <asp:Label ID="Origen" runat="server"><%#DataBinder.Eval(Container.DataItem, "Nacionalidad")%></asp:Label>
                    </td>
                    <td style="height: 48px">
                    </td>
                </tr>
                <tr>
                    <td>
                        </td>
                    <td>
                        <span><asp:Label ID="lblDescripcion" runat="server"><%#DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:Label></span></td>
                    <td>
                        </td>
                </tr>
                <tr>
                    <td style="height: 16px">
                        </td>
                   <td style="height: 16px">
                        <asp:HyperLink ID="hlEspecificaciones" runat="server" CssClass="gral_link" NavigateUrl='<%# "~/webForms/DetalleForm.aspx?Table=Productos&Id="& DataBinder.Eval(Container.DataItem, "Identificador").ToString()%>'>Especificaciones técnicas</asp:HyperLink>
                    </td>
                   <td style="height: 16px">
                        </td>
                </tr>
                  <tr>
                    <td>
                        </td>
                    <td colspan="2" 
                        style="background-image: url('../images/menu_separator.gif')" 
                        height="1"></td>
                    <td 
                        style="background-image: url('../images/menu_separator.gif')" 
                        height="1"></td>
                </tr>
                </table>
        </ItemTemplate>        
        </asp:TemplateField>
    </Columns>
    <PagerStyle HorizontalAlign="Center" Font-Size="X-Small" Font-Underline="False" 
          />
</asp:GridView>
