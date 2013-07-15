<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" CodeFile="InventarioForm.aspx.vb" Inherits="WebForms_InventarioForm" title="Start - Control de inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">C</span>ontrol de inventario</span></p>
<span class="LetraFormateadaNegra">
    </span>
    <asp:CustomValidator ID="cuGeneral" runat="server" 
            Visible="False">*</asp:CustomValidator>
 <table cellpadding="0" cellspacing="0" class="LetraGeneral">
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td colspan="3">
                        <asp:ValidationSummary ID="vsMensajes" runat="server"  class=gral_Summary 
                            Visible="False" CssClass="gral_summary" />
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
                        <asp:GridView ID="grvInventario" runat="server" AutoGenerateColumns="False" 
                            GridLines="Horizontal" Width="100%" AllowPaging="True" AllowSorting="True" 
                            PageSize="5" BorderWidth="0px" CellPadding="0" 
                            DataKeyNames="Identificador" OnRowDataBound=grvInventario_RowDataBound 
                            CssClass="LetraGeneral" BorderColor="#CACACA">
                            <Columns>                                
                                <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate >
                                         <table style="padding-right:5px; "  cellpadding="0" cellspacing="0" class="LetraGeneral" >
                                            <tr>
                                                <td>
                                                      <asp:Label ID="lblNombre" CssClass=LetraChicaNegra runat="server"><%#DataBinder.Eval(Container.DataItem, "Nombre")%></asp:Label>                        
                                                </td>
                                            </tr>
                                            <tr>
                                               <td style="height: 16px">
                                               <asp:HyperLink  ID="hlEspecificaciones"  runat="server" CssClass="gral_link" >Seleccionar</asp:HyperLink>
                                               </td>
                                            </tr>
                                           </table>
                                </ItemTemplate>
                                <ItemStyle  CssClass="celdaGrilla" />
                                <HeaderStyle CssClass="celdaGrilla" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>                                
                                <asp:BoundField  HeaderText="Cantidad" DataField="Cantidad" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                                <asp:BoundField DataField="Precio" HeaderText="Precio">
                               <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                                <asp:BoundField DataField="PMR" HeaderText="PMR" >
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
                    <td style="width: 88px; height: 15px;">
                        </td>
                    <td style="width: 1579px; height: 15px;">
                        </td>
                    <td style="width: 1319px; height: 15px;">
                        </td>
                    <td style="height: 15px; width: 682px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td style="width: 1579px">
                        &nbsp;</td>
                    <td style="width: 1319px">
                        &nbsp;</td>
                    <td align="right" style="width: 682px">
                        <asp:Button ID="btnAgregarProducto" 
                        runat="server" CssClass="gral_button" Text="Agregar" />&nbsp;<asp:Button 
                        ID="btnEliminarProducto" runat="server" CssClass="gral_button" 
                            Text="Eliminar" /></td>
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
          <div style="padding-left:20px">
          <asp:Panel ID="Panel1"  runat="server" CssClass="data_panel" Width="60%">          
          <table style="padding-right:5px; padding-top: 5px;"  width=100%
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="2"   align=center>
                        Datos del producto</td>
                </tr>
               <tr>
                    <td style="width: 118px" valign="top">
                        Nombre:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="gral_text_box" 
                            Height="17px" Width="64%"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="vgSubmit" ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtNombre">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Descripción:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="gral_text_box" 
                            Height="70px" Width="109%" TextMode="MultiLine"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                      Tipo:</td>
                    <td style="width: 289px">
                    <table cellpadding=0 cellspacing=0><tr><td>
                        <asp:DropDownList ID="ddlTipoProducto" runat="server" CssClass="gral_drop">
                            <asp:ListItem>Consola</asp:ListItem>
                        </asp:DropDownList></td><td>
                            
                           <asp:HyperLink  ID="hlEspecificaciones2"  runat="server" CssClass="gral_link" >nuevo tipo de producto</asp:HyperLink>
                            
                        </td></tr></table></td>
                </tr>
                <tr>
                    <td style="width: 118px">
                        Cantidad:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="14%"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="vgSubmit" ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtCantidad">*</asp:RequiredFieldValidator>
                       </td>
                </tr>
                <tr>
                    <td style="width: 118px; height: 26px;" valign="top">
                        Moneda:</td>
                    <td style="width: 289px; height: 26px;">
                        <asp:DropDownList ID="ddlMoneda" runat="server" CssClass="gral_drop" 
                            Height="73px">
                            <asp:ListItem>Pesos argentinos</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Precio:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="26%"></asp:TextBox>
                             <asp:RequiredFieldValidator ValidationGroup="vgSubmit" ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtPrecio">*</asp:RequiredFieldValidator>
                        </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        PMR:</td>
                    <td>
                        <asp:TextBox ID="txtPMR" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="10%"></asp:TextBox>
                             <asp:RequiredFieldValidator ValidationGroup="vgSubmit" ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtPMR">*</asp:RequiredFieldValidator>
                        </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Dimensión:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtDimension" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="27%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Nacionalidad:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="gral_text_box" 
                            Height="16px"></asp:TextBox>
                    </td>
                </tr>
                </tr __designer:mapid="762">
                <tr>
                    <td style="width: 118px" valign="top">
                        Fabricante:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtFabricante" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="37%"></asp:TextBox>
                    </td>
                    <tr>
                        <td style="width: 118px" valign="top">
                            Especificaciones:</td>
                        <td style="width: 289px">
                            <asp:TextBox ID="txtEspecificaciones" runat="server" CssClass="gral_text_box" 
                                Height="69px" TextMode="MultiLine" Width="107%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 118px" valign="top">
                            Garantía:</td>
                        <td style="width: 289px">
                            <asp:DropDownList ID="ddlGarantia" runat="server" CssClass="gral_drop">
                                <asp:ListItem>Si</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 118px;" valign="top">
                            Imagen:</td>
                        <td style="width: 289px">
                            <input ID="File1" runat="server" class="gral_text_box" CssClass="gral_button" 
                                name="File1" style="width: 181px" type="file"></input></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top" align="center" style="height: 10px;">
                            <asp:Button ID="btnAceptar" runat="server" CssClass="gral_button" 
                                Text="Aceptar" ValidationGroup="vgSubmit" />
                            </td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                        </td>
                    </tr>
                </tr>
                </table>
          </asp:Panel></div>
          <div style="height:2px"></div>
           <div style="height:20px"></div>
          <div style="padding-left:30px">
              <table style="padding-right:5px; padding-top: 5px;"  width=100%
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td valign="top" style="width: 431px">
                        </td>
                    <td>
                        </td>
                </tr>
                </table></div>
</asp:Content>

