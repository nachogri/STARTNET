<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_AdminPagosForm" title="Start - Administración de pagos" Codebehind="AdminPagosForm.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">     
    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">A</span>dministración 
        de cobros</span></p>
<span class="LetraFormateadaNegra">
    </span>
    <table cellpadding="0" cellspacing="0" class="LetraGeneral">
                <tr class="LetraChicaNegra">
                    <td style="width: 88px; ">
                        &nbsp;</td>
                    <td colspan="8">
                         <asp:CustomValidator ID="cuGeneral" runat="server" 
            Visible="False">*</asp:CustomValidator>
 <table cellpadding="0" cellspacing="0" class="LetraGeneral">
                <tr>
                    <td colspan="3">
                        <asp:ValidationSummary ID="vsMensajes" runat="server"  class=gral_Summary 
                            Visible="False" CssClass="gral_summary" />
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="grvSeguimientos" runat="server" AutoGenerateColumns="False" 
                            GridLines="Horizontal" Width="100%" AllowPaging="True" AllowSorting="True" 
                            PageSize="5" BorderWidth="0px" CellPadding="0" 
                            DataKeyNames="Identificador" OnRowDataBound=grvReparaciones_RowDataBound 
                            CssClass="LetraGeneral" BorderColor="#CACACA">
                            <Columns>                                
                                <asp:TemplateField HeaderText="Usuario">
                                <ItemTemplate >
                                         <table style="padding-right:5px; "  cellpadding="0" cellspacing="0" class="LetraGeneral" >
                                            <tr>
                                                <td>
                                                      <asp:Label ID="lblUsuario" runat="server"><%#DataBinder.Eval(Container.DataItem, "Venta.Usuario.Nickname")%></asp:Label>                        
                                                </td>
                                            </tr>
                                            <tr>
                                               <td style="height: 16px">
                                               <asp:HyperLink  ID="hlSeleccionar"  runat="server" CssClass="gral_link" >Ver detalle</asp:HyperLink>
                                               </td>
                                            </tr>
                                           </table>
                                </ItemTemplate>
                                <ItemStyle  CssClass="celdaGrilla" />
                                <HeaderStyle CssClass="celdaGrilla" />
                                </asp:TemplateField>                                                                                                
                                <asp:BoundField  HeaderText="Estado" DataField="Estado" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                                 <asp:TemplateField HeaderText="Tipo pago">
                                <ItemTemplate >
                                         <table style="padding-right:5px; "  cellpadding="0" cellspacing="0" class="LetraGeneral" >
                                            <tr>
                                                <td>
                                                      <asp:Label ID="lblTitulo" runat="server"><%#DataBinder.Eval(Container.DataItem, "Venta.TipoPago.Descripcion")%></asp:Label>                        
                                                </td>
                                            </tr>
                                           </table>
                                </ItemTemplate>
                                <ItemStyle  CssClass="celdaGrilla" />
                                <HeaderStyle CssClass="celdaGrilla" />
                                </asp:TemplateField> 
                                 <asp:BoundField  HeaderText="Factura" DataField="NumeroFactura" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                                <asp:BoundField  HeaderText="Comprobante" DataField="Comprobante" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                                <asp:BoundField  HeaderText="Calificacion" DataField="Calificacion" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle CssClass="gral_link" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#DFDFDF" />
                            <HeaderStyle CssClass="LetraChicaNegra" HorizontalAlign="Left" 
                                BorderStyle="None" BorderWidth="0px" />
                        </asp:GridView>
                        </td>
                </tr>
                <tr>
                    <td style="width: 1579px">
                        &nbsp;</td>
                    <td style="width: 1319px">
                        &nbsp;</td>
                    <td align="right" style="width: 682px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 1579px">
                        &nbsp;</td>
                    <td style="width: 1319px">
                        &nbsp;</td>
                    <td align="right" style="width: 682px">
                        <asp:Button ID="btnAgregarSeguimiento" 
                        runat="server"  CssClass="gral_button" Text="Nuevo pago" 
                            PostBackUrl="~/webForms/ConsultarVentasForm.aspx" />&nbsp;</td>
                </tr>
                </table></td>
                </tr>
                <tr class="LetraChicaNegra">
                    <td style="width: 88px; ">
                        &nbsp;</td>
                    <td style="width: 1026px; ">
                        &nbsp;</td>
                    <td style="width: 1066px; ">
                        &nbsp;</td>
                    <td style="width: 795px; ">
                        &nbsp;</td>
                    <td style="width: 795px; ">
                        &nbsp;</td>
                    <td style="width: 278px; ">
                        &nbsp;</td>
                    <td style="width: 278px; ">
                        &nbsp;</td>
                    <td style="width: 278px; ">
                        &nbsp;</td>
                    <td style="width: 2296px; ">
                        &nbsp;</td>
                </tr>
                </table>
          <div style="padding-left:20px">
          <asp:Panel ID="Panel1"  runat="server" CssClass="data_panel" Width="60%">          
          <table style="padding-right:5px; padding-top: 5px;"  width=100% cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="2"   align=center>
                        Datos del pago</td>
                </tr>
                <tr>
                    <td style="width: 92px" valign="top">
                        Venta relacionada:</td>
                    <td style="width: 289px">
                    <table cellpadding=0 cellspacing=0><tr><td>
                    <asp:TextBox ID="txtVentaAsociada" runat="server" CssClass="gral_text_box" 
                            ReadOnly="True" Width="317px"></asp:TextBox>&nbsp;</td><td> 
                            &nbsp;</td></tr></table>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width: 92px" valign="top">
                        Tipo:</td>
                    <td style="width: 289px">
                    <table cellpadding=0 cellspacing=0><tr><td>
                    <asp:DropDownList ID="ddlTipoPago" runat="server" CssClass="gral_drop">
                        </asp:DropDownList></td><td>&nbsp;
                            </td></tr></table>                        
                    </td>
                    
                </tr>
                <tr>
                    <td style="width: 92px" valign="top">
                        Factura:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtFactura" runat="server" CssClass="gral_text_box" 
                            Height="17px" Width="37%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 92px" valign="top">
                        Comprobante:</td>
                    <td class="gral_drop" style="width: 289px">
                        <asp:TextBox ID="txtComprobante" runat="server" CssClass="gral_text_box" 
                            Height="17px" Width="37%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 92px" valign="top">
                        Comentarios:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtComentarios" runat="server" CssClass="gral_text_box" 
                            Height="70px" Width="109%" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 92px" valign="top">Calificación:</td>
                    <td style="width: 289px">
                        <asp:DropDownList ID="ddlCalificacion" runat="server" CssClass="gral_drop">
                            <asp:ListItem>Buena</asp:ListItem>
                            <asp:ListItem>Regular</asp:ListItem>
                            <asp:ListItem>Mala</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                        <td align="center" colspan="2" style="height: 10px;" valign="top">
                            <asp:Button ID="btnAceptar" runat="server" CssClass="gral_button" 
                                Text="Aceptar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                            </td>
                    </tr>
                </table>
          </asp:Panel></div>

</asp:Content>

