<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" EnableEventValidation="false" Inherits="START_Website.WebForms_AdminNovedadesForm" title="Start - Administración de novedades" Codebehind="AdminNovedadesForm.aspx.vb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <span class="LetraFormateadaNegra"><span class="LetraFormateada">A</span>dministración 
        de novedades</span>
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
                        <asp:GridView ID="grvNovedades" runat="server" AutoGenerateColumns="False" 
                            GridLines="Horizontal" Width="100%" AllowPaging="True" AllowSorting="True" 
                            PageSize="5" BorderWidth="0px" CellPadding="0" 
                            DataKeyNames="Identificador" OnRowDataBound=grvNovedades_RowDataBound 
                            CssClass="LetraGeneral" BorderColor="#CACACA">
                            <Columns>                                
                                <asp:TemplateField HeaderText="Título">
                                <ItemTemplate >
                                         <table style="padding-right:5px; "  cellpadding="0" cellspacing="0" class="LetraGeneral" >
                                            <tr>
                                                <td>
                                                      <asp:Label ID="lblTitulo" CssClass=LetraChicaNegra runat="server"><%#DataBinder.Eval(Container.DataItem, "Titulo")%></asp:Label>                        
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
                                <asp:BoundField  HeaderText="Descripción" DataField="Descripcion" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                                <asp:BoundField  HeaderText="Fecha" DataField="FechaActualizacion" 
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
                        <asp:Button ID="btnAgregarNovedad" 
                        runat="server" CssClass="gral_button" Text="Agregar" />&nbsp;<asp:Button 
                        ID="btnEliminarNovedad" runat="server" CssClass="gral_button" 
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
                        Datos de novedad</td>
                </tr>
               <tr>
                    <td style="width: 15px" valign="top">
                        Titulo:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="gral_text_box" 
                            Height="17px" Width="37%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv0" runat="server" 
                            ControlToValidate="txtTitulo" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15px" valign="top">
                        Descripción:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtDecripcion" runat="server" CssClass="gral_text_box" 
                            Height="72px" Width="110%" TextMode="MultiLine" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtDecripcion" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15px" valign="top">
                        Fecha:</td>
                    <td style="width: 289px">
                         <table cellspacing=0 cellpadding=0 border=0>
                        <tr>
                        <td>
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="gral_text_box"></asp:TextBox>
                            </td>                        
                        <td>&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" 
                                 ImageUrl="~/Images/gral_icon_calendar.jpg" /></td>
                        <td><asp:CalendarExtender Format="dd/MM/yyyy"  ID="txtFechaNacimiento_CalendarExtender" runat="server" 
                                 TargetControlID="txtFecha" PopupButtonID=ImageButton2></asp:CalendarExtender></td>
                        </tr>
                        </table>
                        </td>
                </tr>
                <tr>
                    <td style="width: 15px">
                        Imagen:</td>
                    <td style="width: 289px">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <input ID="File1" runat="server" class="gral_text_box" 
                                        CssClass="gral_button" name="File1" style="width: 181px" type="file"></input></td>                                
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

