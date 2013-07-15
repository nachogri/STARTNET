<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" CodeFile="VentaForm.aspx.vb"  Inherits="WebForms_VentaForm" title="Start - Tu carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript">
        function openNewWin(url) {
            var x = window.open(url, 'Recibo', 'width=600,height=600,toolbar=1');
            x.focus();
        } 
</script>
    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">&nbsp;C</span>arrito de compras</span></p>
<span class="LetraFormateadaNegra">
<div > Este es tu pedido hasta el momento:<br /></div>
</span>
         <div style="padding-right:10px">
                        <table cellpadding="0" cellspacing="0" class="LetraGeneral">
                            <tr>
                                <td style="width: 88px">
         <asp:CustomValidator ID="cuGeneral" runat="server" Visible="False">*</asp:CustomValidator>
                                </td>
                                <td colspan="3">
                                    <asp:ValidationSummary ID="vsMensajes" runat="server" class="gral_Summary" 
                                        CssClass="gral_summary" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 88px">
                                    &nbsp;</td>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 88px">
                                </td>
                                <td colspan="3">
                                    <span class="LetraFormateadaNegra"><asp:GridView ID="grvVenta" runat="server" AutoGenerateColumns="False" BorderColor="#CACACA" 
                                        BorderWidth="0px" CellPadding="0" CssClass="LetraGeneral"
                                        GridLines="Horizontal" 
                                        OnRowDataBound="grvProductos_RowDataBound" PageSize="5" Width="100%">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" class="LetraGeneral" 
                                                        style="padding-right:5px; ">
                                                        <tr>
                                                            <td style="height: 16px">
                                                                <asp:HyperLink ID="hlSeleccionar" runat="server" CssClass="gral_link">Quitar</asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="celdaGrilla" />
                                                <HeaderStyle CssClass="celdaGrilla" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Producto" HeaderText="Producto">
                                                <ItemStyle CssClass="celdaGrilla" Width="60%" />
                                                <HeaderStyle CssClass="celdaGrilla" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Cantidad">
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" class="LetraGeneral" 
                                                        style="padding-right:5px; ">
                                                        <tr>
                                                            <td style="height: 16px">
                                                                <asp:DropDownList ID="ddlCantidad" runat="server" CssClass="LetraGeneral">
                                                                    <asp:ListItem Value="1"></asp:ListItem>
                                                                    <asp:ListItem>2</asp:ListItem>
                                                                    <asp:ListItem>3</asp:ListItem>
                                                                    <asp:ListItem>4</asp:ListItem>
                                                                    <asp:ListItem>5</asp:ListItem>
                                                                    <asp:ListItem>6</asp:ListItem>
                                                                    <asp:ListItem>7</asp:ListItem>
                                                                    <asp:ListItem>8</asp:ListItem>
                                                                    <asp:ListItem>9</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="celdaGrilla" />
                                                <HeaderStyle CssClass="celdaGrilla" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Precio" HeaderText="Precio">
                                                <ItemStyle CssClass="celdaGrilla" />
                                                <HeaderStyle CssClass="celdaGrilla" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="PrecioFinal" HeaderText="Total">
                                                <ItemStyle CssClass="celdaGrilla" />
                                                <HeaderStyle CssClass="celdaGrilla" />
                                            </asp:BoundField>
                                        </Columns>
                                        <PagerStyle CssClass="gral_link" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#DFDFDF" />
                                        <HeaderStyle BorderStyle="None" BorderWidth="0px" CssClass="LetraChicaNegra" 
                                            HorizontalAlign="Left" />
                                    </asp:GridView>
                                </span></td>
                            </tr>
                            <tr>
                                <td style="width: 88px">
                                    &nbsp;</td>
                                <td style="width: 1579px">
                                    &nbsp;</td>
                                <td style="width: 1319px">
                                    &nbsp;</td>
                                <td style="width: 682px">
                                    &nbsp;</td>
                            </tr>
                        </table>
             <table cellpadding="0" cellspacing="0" class="LetraGeneral" align="left" >
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td style="width: 87px">
                        &nbsp;</td>
                    <td style="width: 1317px">
                        &nbsp;</td>
                    <td style="width: 795px">
                        &nbsp;</td>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnRecalcular" runat="server" CssClass="gral_button" 
                            Text="Recalcular" /></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td style="width: 87px">
                        &nbsp;</td>
                    <td style="width: 1317px">
                        &nbsp;</td>
                    <td style="width: 795px">
                        &nbsp;</td>
                    <td colspan="2" align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 87px">
                        </td>
                    <td style="width: 1317px">
                        </td>
                    <td style="width: 795px">
                        </td>
                    <td>
                        SUBTOTAL:</td>
                    <td style="width: 330px">
                        <a>
                        <b>$</b><asp:Label ID="lblSubtotal" runat="server" CssClass="LetraChicaNegra"></asp:Label>
                        </a></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 87px">
                        </td>
                    <td style="width: 1317px">
                        </td>
                    <td style="width: 795px">
                        </td>
                    <td>
                        PROMOCIÓN: </td>
                    <td style="width: 330px">
                        <a>
                        <b>%</b><asp:Label ID="lblPromocion" runat="server" CssClass="LetraChicaNegra"></asp:Label>
                        </a></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 87px">
                        </td>
                    <td style="width: 1317px">
                        </td>
                    <td style="width: 795px">
                        </td>
                    <td>
                        <a>
                        <b>Total:</b></a></td>
                    <td style="width: 330px">
                        <a>
                        <b>$</b><asp:Label ID="lblTotal" runat="server" CssClass="LetraChicaNegra"></asp:Label>
                        </a></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td style="width: 87px">
                        &nbsp;</td>
                    <td style="width: 1317px">
                        &nbsp;</td>
                    <td style="width: 795px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td style="width: 330px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>Lugar de entrega:</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                <table cellpadding=0 cellspacing=0><tr><td>&nbsp;</td>
                                <td>&nbsp;
                                    <asp:TextBox ID="txtDomicilio" runat="server" CssClass="gral_text_box" 
                                        Height="40px" Width="343px" Enabled="False" TextMode="MultiLine"></asp:TextBox></td></tr></table>
                                </td>
                            </tr>
                            </table>
                        </td>
                    <td style="width: 795px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td style="width: 330px">
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 83px">Tipo de pago:</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="width: 83px"></td>
                                <td>
                                <table cellpadding=0 cellspacing=0><tr><td>&nbsp;</td>
                                <td>&nbsp;
                                    <asp:DropDownList ID="ddlTipoPago" runat="server">
                                    </asp:DropDownList>                                    
                                   </td></tr></table>
                                </td>
                            </tr>
                            </table>
                        </td>
                    <td style="width: 795px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td style="width: 330px">
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>Condición de IVA:</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                <table cellpadding=0 cellspacing=0><tr><td>&nbsp;</td>
                                <td>&nbsp;
                                    <asp:DropDownList ID="ddlIVA" runat="server">                                    
                                    <asp:ListItem Text="Responsable Inscripto" Value=1></asp:ListItem>
                                    <asp:ListItem Text="Responsable No Inscripto" Value=2></asp:ListItem>
                                    <asp:ListItem Text="Consumidor Final" Selected=True Value=3></asp:ListItem>
                                    </asp:DropDownList></td></tr></table>
                                </td>
                            </tr>
                            </table>
                        </td>
                    <td style="width: 795px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td style="width: 330px">
                        &nbsp;</td>
                </tr>
                <tr><td colspan=6 align="center" style="height: 77px"><asp:Button ID="Button2" 
                        runat="server" CssClass="gral_button" Text="Seguir comprando" 
                        PostBackUrl="~/webForms/ConsolasForm.aspx" />&nbsp;<asp:Button 
                        ID="btnCheckOut" runat="server" CssClass="gral_button" 
                        Text="Confirmar pedido" /></td>
                 </tr>
                </table>
                </div>
</asp:Content>

