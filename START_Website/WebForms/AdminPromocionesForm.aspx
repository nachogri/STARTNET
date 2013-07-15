<%@ Page Title="" Language="vb" AutoEventWireup="false" EnableEventValidation="false" MasterPageFile="~/WebForms/Main.Master" CodeBehind="AdminPromocionesForm.aspx.vb" Inherits="START_Website.WebForms_AdminPromocionesForm" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <span class="LetraFormateadaNegra"><span class="LetraFormateada">A</span>dministración 
        de Promociones</span>
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
                        <asp:GridView ID="grvPromociones" runat="server" AutoGenerateColumns="False" 
                            GridLines="Horizontal" Width="100%" AllowPaging="True" AllowSorting="True" 
                            PageSize="5" BorderWidth="0px" CellPadding="0" 
                            DataKeyNames="Identificador" OnRowDataBound=grvPromociones_RowDataBound 
                            CssClass="LetraGeneral" BorderColor="#CACACA">
                            <Columns>                                
                                <asp:TemplateField HeaderText="Título">
                                <ItemTemplate >
                                         <table style="padding-right:5px; "  cellpadding="0" cellspacing="0" class="LetraGeneral" >
                                            <tr>
                                                <td>
                                                      <asp:Label ID="lblNombre" CssClass=LetraChicaNegra runat="server"><%#DataBinder.Eval(Container.DataItem, "Nombre")%></asp:Label>                        
                                                </td>
                                            </tr>
                                            <tr>
                                               <td style="height: 16px">
                                               <asp:HyperLink  ID="hlSeleccionar"  runat="server" CssClass="gral_link" >Seleccionar</asp:HyperLink>
                                               </td>
                                            </tr>
                                           </table>
                                </ItemTemplate>
                                <ItemStyle  CssClass="celdaGrilla" />
                                <HeaderStyle CssClass="celdaGrilla" />
                                </asp:TemplateField>                                
                                <asp:BoundField  HeaderText="Descripción" DataField="Requisitos" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                                <asp:BoundField  HeaderText="Expiración" DataField="Expiracion" 
                                    DataFormatString="{0:dd-MM-yyyy}" >
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
                        <asp:Button ID="btnAgregarPromocion" 
                        runat="server" CssClass="gral_button" Text="Agregar" />&nbsp;<asp:Button 
                        ID="btnEliminarPromocion" runat="server" CssClass="gral_button" 
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
                <div style="padding-left:30px">
          <asp:Panel ID="Panel2"  runat="server" CssClass="data_panel" Width="60%">
          <table style="padding-right:5px; padding-top: 5px;"  width=100%
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="2"   align=center>
                        Datos de Promocion</td>
                </tr>
               <tr>
                    <td style="width: 15px" valign="top">
                        Nombre:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="gral_text_box" 
                            Height="17px" Width="37%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv0" runat="server" 
                            ControlToValidate="txtNombre" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15px" valign="top">
                        Descripción:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtRequisitos" runat="server" CssClass="gral_text_box" 
                            Height="72px" Width="110%" TextMode="MultiLine" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtRequisitos" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td style="width: 15px" valign="top">
                        Decuento:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtDecuento" runat="server" CssClass="gral_text_box" 
                              ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtDecuento" Enabled=true  Font-Size="Small" 
                            ValidationGroup="AMProducto">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="txtDecuento" ErrorMessage="El valor debe ser numérico" 
                            Type="Double" Font-Size="Small" ValidationGroup="AMProducto" 
                            Operator="DataTypeCheck">*</asp:CompareValidator>
                    </td>
                </tr>                 
                <tr>
                    <td style="width: 15px" valign="top">
                        Expiración:</td>
                    <td style="width: 289px">
                         <table cellspacing=0 cellpadding=0 border=0>
                        <tr>
                        <td>
                            <asp:TextBox ID="txtExpiracion" runat="server" CssClass="gral_text_box"></asp:TextBox>
                            </td>                        
                        <td>&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" 
                                 ImageUrl="~/Images/gral_icon_calendar.jpg" /></td>
                        <td><asp:CalendarExtender Format="dd/MM/yyyy"  ID="txtExpiracion_CalendarExtender" runat="server" 
                                 TargetControlID="txtExpiracion" PopupButtonID=ImageButton2></asp:CalendarExtender></td>
                        </tr>
                        </table>
                        </td>
                </tr>
                <tr>
                    <td style="width: 15px">
                        Productos:</td>
                    <td style="width: 289px">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td rowspan="2">
                                                <asp:ListBox ID="lstProductos" runat="server" CssClass="gral_text_box" 
                                                    Width="200px"></asp:ListBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnAgregarProducto" runat="server" CssClass="gral_button" 
                                                    Text="&gt;&gt;" ValidationGroup="AMProducto" />
                                                <asp:RequiredFieldValidator ID="rfvProducto" runat="server" 
                                                    ControlToValidate="lstProductos" Display="Dynamic" Enabled="true" 
                                                    Font-Size="Small" ValidationGroup="AMProducto">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td rowspan="2">
                                                <asp:ListBox ID="lstProductosFinal" runat="server" CssClass="gral_text_box" 
                                                    Width="200px"></asp:ListBox>
                                                <asp:RequiredFieldValidator ID="rfvProducto1" runat="server" 
                                                    ControlToValidate="lstProductosFinal" Display="Dynamic" Enabled="true" 
                                                    ErrorMessage="Debe tener al menos 1 producto asociado" Font-Size="Small" 
                                                    ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnQuitarProducto" runat="server" CssClass="gral_button" 
                                                    Text="&lt;&lt;" ValidationGroup="AMProductoFinal" />
                                                <asp:RequiredFieldValidator ID="rfvProducto0" runat="server" 
                                                    ControlToValidate="lstProductosFinal" Display="Dynamic" Enabled="true" 
                                                    Font-Size="Small" ValidationGroup="AMProductoFinal">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table></td>                                
                            </tr>
                        </table>
                    </td>
                </tr>                
                <tr>
                    <td style="width: 15px" valign="top">
                        &nbsp;</td>
                    <td align="center" style="width: 289px">
                        &nbsp;<asp:Button ID="btnAceptar" runat="server" CssClass="gral_button" 
                            Text="Aceptar" />
                    </td>
                </tr>
                </table>
          </asp:Panel></div>

</asp:Content>
