<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_AdminReparacionesForm" title="Start - Reparaciones" Codebehind="AdminReparacionesForm.aspx.vb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">A</span>dministración de reparaciones</span></p>
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
                        <asp:GridView ID="grvReparaciones" runat="server" AutoGenerateColumns="False" 
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
                                                      <asp:Label ID="lblTitulo" runat="server"><%#DataBinder.Eval(Container.DataItem, "Usuario.Nickname")%></asp:Label>                        
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
                                <asp:BoundField  HeaderText="Fecha recepción" DataField="FechaRecepcion" 
                                    DataFormatString="{0:dd-MM-yyyy}" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                                <asp:BoundField  HeaderText="Fecha devolución" DataField="FechaDevolucion" 
                                    DataFormatString="{0:dd-MM-yyyy}" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                                <asp:BoundField  HeaderText="Importe" DataField="ImporteTotal" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                                 <asp:TemplateField HeaderText="Tipo pago">
                                <ItemTemplate >
                                         <table style="padding-right:5px; "  cellpadding="0" cellspacing="0" class="LetraGeneral" >
                                            <tr>
                                                <td>
                                                      <asp:Label ID="lblTitulo" runat="server"><%#DataBinder.Eval(Container.DataItem, "TipoPago.Descripcion")%></asp:Label>                        
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
                        <asp:Button ID="btnAgregarNovedad" 
                        runat="server" CssClass="gral_button" Text="Agregar" />&nbsp;</td>
                </tr>
                </table>
          <div style="padding-left:20px">
          <asp:Panel ID="Panel1"  runat="server" CssClass="data_panel" Width="60%">          
          <table style="padding-right:5px; padding-top: 5px;"  width=100% cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="2"   align=center>
                        Datos de la reparación</td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Usuario:</td>
                    <td style="width: 289px">
                    <table cellpadding=0 cellspacing=0><tr><td>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="gral_text_box" 
                            Width="75px"></asp:TextBox></td><td> &nbsp;
                            </td></tr></table>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Fecha de recepción:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtFechaRecepcion" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="25%" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtFechaRecepcion" Enabled=true  Font-Size="Small" 
                            ValidationGroup="AMSubmit" Display="Dynamic">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvFecha" runat="server" 
                            ControlToValidate="txtFechaRecepcion" ErrorMessage="CompareValidator" Font-Size="Small" 
                            Operator="DataTypeCheck" Type="Date" ValidationGroup="AMSubmit">*</asp:CompareValidator>
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" 
                                 ImageUrl="~/Images/gral_icon_calendar.jpg" />
                       <asp:CalendarExtender Format="dd/MM/yyyy"  ID="txtExpiracion_CalendarExtender" runat="server" 
                                 TargetControlID="txtFechaRecepcion" PopupButtonID=ImageButton2></asp:CalendarExtender>
                    </td>
                    
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Fecha de devolución:</td>
                   <td style="width: 289px">
                        <asp:TextBox ID="txtFechaDevolucion" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="25%" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtFechaDevolucion" Enabled=true  Font-Size="Small" 
                            ValidationGroup="AMSubmit" Display="Dynamic">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="txtFechaDevolucion" ErrorMessage="CompareValidator" Font-Size="Small" 
                            Operator="DataTypeCheck" Type="Date" ValidationGroup="AMSubmit">*</asp:CompareValidator>
                        &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" 
                                 ImageUrl="~/Images/gral_icon_calendar.jpg" />
                       <asp:CalendarExtender Format="dd/MM/yyyy"  ID="txtFechaDevolucion_CalendarExtender" runat="server" 
                                 TargetControlID="txtFechaDevolucion" PopupButtonID=ImageButton1></asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Monto:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtMonto" runat="server" CssClass="gral_text_box" 
                            Width="37px" Height="16px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtMonto" Display="Dynamic" Enabled="true" Font-Size="Small" 
                            ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Tipo de pago:</td>
                    <td style="width: 289px">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlTipoPago" runat="server" CssClass="gral_drop">                                        
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Estado:</td>
                    <td style="width: 289px">
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="gral_drop">
                            <asp:ListItem Selected="True" Value="1">EnProceso</asp:ListItem>
                            <asp:ListItem Value="2">Reparado</asp:ListItem>
                            <asp:ListItem Value="3">Cancelado</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                        <td align="center" colspan="2" style="height: 10px;" valign="top">
                            <asp:Button ID="btnAceptar" runat="server" CssClass="gral_button" 
                                Text="Aceptar" />
                        </td>
                    </tr>
                </table>
          </asp:Panel></div>
</asp:Content>

