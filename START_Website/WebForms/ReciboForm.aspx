<%@ Page Language="VB" AutoEventWireup="false" Inherits="START_Website.WebForms_ReciboForm"  Codebehind="ReciboForm.aspx.vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Start - Recibo de compra</title>
   
    <link href="../App_Themes/START-theme.css" rel="StyleSheet"  type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" border="0" cellpadding="0" cellspacing="0" 
            style="width: 36px; height: 92px;">
            <tr>
                <td align="left" 
                    style="background-image: url('../resources/images/LogoVGI.jpg');" 
                    class="style1">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/StartLogo.jpg" />
                    <br />
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" class="LetraGeneral" align="left">
                <tr class="LetraFormateadaNegra">
                    <td class="style3">
                      <asp:CustomValidator ID="cuGeneral" runat="server" Visible="False">*</asp:CustomValidator>
                                </td>
                                <td colspan="5">
                                    <asp:ValidationSummary ID="vsMensajes" runat="server" class="gral_Summary" 
                                        CssClass="gral_summary" Visible="False" />
                        </td>
                </tr>
                <tr class="LetraFormateadaNegra">
                    <td class="style5">
                        </td>
                    <td class="LetraGeneral" colspan="5">
                        <b>
                        <span style="FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #789200; FONT-STYLE: normal; FONT-FAMILY: Arial">
                        ¡FELICIDADES 
                        <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                        !</span></b><br />
                        <br />
                        Eres el comprador de:</td>
                </tr>
                <tr class="LetraFormateadaNegra">
                    <td style="width: 88px; ">
                        &nbsp;</td>
                    <td colspan="5">
                        &nbsp;</td>
                </tr>
                <tr class="LetraFormateadaNegra">
                    <td style="width: 88px; ">
                        &nbsp;</td>
                    <td colspan="5">
                        <asp:GridView ID="grvVenta" runat="server" AutoGenerateColumns="False" 
                            BorderColor="#CACACA" BorderWidth="0px" CellPadding="0" CssClass="LetraGeneral" 
                            GridLines="Horizontal" PageSize="5" 
                            Width="100%">
                            <Columns>
                                <asp:BoundField DataField="Producto" HeaderText="Producto">
                                    <ItemStyle CssClass="LetraChicaNegra" Width="50%" />
                                    <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo">
                                    <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                    <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Precio" HeaderText="Precio">
                                    <ItemStyle CssClass="letraGeneral" />
                                    <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PrecioFinal" HeaderText="Total">
                                    <ItemStyle CssClass="letraGeneral" />
                                    <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle CssClass="gral_link" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#DFDFDF" />
                            <HeaderStyle BorderStyle="None" BorderWidth="0px" CssClass="LetraChicaNegra" 
                                HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 1579px;" 
                        height="1"></td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 795px;" 
                        height="1"></td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 278px;" 
                        height="1"></td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 385px;" 
                        height="1"></td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 330px;" 
                        height="1"></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 1579px">
                        </td>
                    <td style="width: 795px">
                        </td>
                    <td colspan="2">
                        SUBTOTAL:</td>
                    <td style="width: 330px">
                        <a>
                        <b>$<asp:Label ID="lblSubtotal" runat="server"></asp:Label>
                        </b></a></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 1579px">
                        </td>
                    <td style="width: 795px">
                        </td>
                    <td colspan="2">
                                                PROMOCIÓN:</td>
                    <td style="width: 330px">
                        <a>
                        <b>%<asp:Label ID="lblPromocion" runat="server"></asp:Label>
                        </b></a></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 1579px">
                        </td>
                    <td style="width: 795px">
                        </td>
                    <td colspan="2">
                        <a>
                        <b>Total:</b></a></td>
                    <td style="width: 330px">
                        <a>
                        <b>$<asp:Label ID="lblTotal" runat="server"></asp:Label>
                        </b></a></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td style="width: 1579px">
                        &nbsp;</td>
                    <td style="width: 795px">
                        &nbsp;</td>
                    <td colspan="2">
                        &nbsp;</td>
                    <td style="width: 330px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td style="width: 1579px">
                        &nbsp;</td>
                    <td style="width: 795px">
                        &nbsp;</td>
                    <td colspan="2">
                        &nbsp;</td>
                    <td style="width: 330px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                        </td>
                    <td class="style8" colspan="5">
                        <b>Detalles de tu compra:</b><br />
                        Precio: $
                        <asp:Label ID="lblPrecio" runat="server"></asp:Label>
                        <br />
                        Cantidad: 
                        <asp:Label ID="lblCantidad" runat="server"></asp:Label>
&nbsp;artículo/s<br />
                        Fecha: 
                        <asp:Label ID="lblFecha" runat="server"></asp:Label>
&nbsp;<br />
                        Lugar de entrega: 
                        <asp:Label ID="lblDomicilio" runat="server"></asp:Label>
                        <br />
                        IMPORTANTE: Tu factura será entregada junto con el pedido.</td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style8" colspan="5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style2" colspan="5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td colspan="5" align="center">
                        <asp:Button ID="btnVolver" runat="server" CssClass="gral_button" 
                            Text="Continuar" PostBackUrl="~/WebForms/EncuestaForm.aspx" />
                    </td>
                </tr></table>
    
    </div>
    </form>
</body>
</html>
