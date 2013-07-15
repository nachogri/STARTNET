<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_ConsultarBitacoraForm" title="Start - Consulta de bitácora" Codebehind="ConsultarBitacoraForm.aspx.vb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<span class="LetraFormateadaNegra"><span class="LetraFormateada">C</span>onsulta de bitácora</span>
<asp:CustomValidator ID="cuGeneral" runat="server" 
            Visible="False">*</asp:CustomValidator>
                <table cellpadding="0" cellspacing="0" class="LetraGeneral" width="100%">
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td style="width: 827px">
                        <asp:ValidationSummary ID="vsMensajes" runat="server"  class=gral_Summary 
                            Visible="False" CssClass="gral_summary" />
                        </td>
                    <td>
                        &nbsp;</td>
                </tr>
                </table>
<span class="LetraFormateadaNegra">
    </span><div style="text-align:center">
              <div style="padding-left:20px">
          <asp:Panel ID="Panel1"  runat="server" CssClass="data_panel" Width="631px" >          
          <table style="padding-right:5px; padding-top: 5px; " cellpadding="0" 
                  cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td align="center" colspan="8">
                        Filtros de búsqueda</td>
                </tr>
                <tr>
                    <td style="width: 118px">
                        Usuario:</td>
                    <td style="width: 280px">
                        <asp:DropDownList ID="ddlUsuarios" runat="server" CssClass="gral_drop">
                            <asp:ListItem>Registro de pago</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 167px">
                        &nbsp;Fecha:</td>
                    <td>
                       <table cellspacing=0 cellpadding=0 border=0>
                         <tr>
                            <td><asp:TextBox ID="txtFecha" CssClass=gral_text_box runat="server" 
                                    ></asp:TextBox></td>
                            <td>&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" 
                                     ImageUrl="~/Images/gral_icon_calendar.jpg" /></td>
                            <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                     ControlToValidate="txtFecha" Display="Dynamic" Font-Size="Small" 
                                     meta:resourcekey="RequiredFieldValidator6Resource1" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                            </td>
                            <td></td>
                        </tr>
                        </table>     
                        <asp:CalendarExtender  Format="dd/MM/yyyy" ID="txtFechaNacimiento_CalendarExtender" runat="server" 
                                     TargetControlID="txtFecha" PopupButtonID=ImageButton2>
                                 </asp:CalendarExtender>                                           
                        </td>
                    </td>                    
                    <td>
                        Acción:</td>
                    <td>
                        <asp:DropDownList ID="ddlAccion" runat="server" CssClass="gral_drop" 
                            Height="27px" Width="189px">
                            <asp:ListItem>Registro de pago</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                        <td align="center" colspan="2" valign="top">
                            &nbsp;</td>
                        <td align="center" style="width: 167px;" valign="top">
                        </td>
                        <td align="center" valign="top">
                        </td>
                        <td align="center" valign="top">
                            &nbsp;</td>
                        <td align="center" valign="top">
                            &nbsp;</td>
                        <td align="center" valign="top">
                            &nbsp;</td>
                        <td align="center" valign="top">
                            <asp:Button ID="btnBuscar" runat="server" CssClass="gral_button" 
                                Text="Buscar" />
                        </td>
                    </tr>
                </table>
          </asp:Panel></div></div>
    <table cellpadding="0" cellspacing="0" class="LetraGeneral">
        <tr class="LetraFormateadaNegra">
            <td style="width: 88px; height: 30px;">
            </td>
            <td style="width: 175px; height: 30px;">
                        </td>
            <td style="width: 175px; height: 30px;">
                        </td>
            <td style="width: 1579px; height: 30px;">
                        </td>
            <td style="width: 278px; height: 30px;">
                        </td>
        </tr>
        <tr class="LetraFormateadaNegra">
            <td style="width: 88px; height: 30px;">
                &nbsp;</td>
            <td style="height: 30px;" colspan="4">
                        <div id="divGrid"><asp:GridView ID="grvAcciones" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" BorderColor="#CACACA" 
                            BorderWidth="0px" CellPadding="0" CssClass="LetraGeneral" 
                             GridLines="Horizontal" Width="100%">
                            <Columns>                              
                                <asp:BoundField HeaderText="Usuario" DataField="Usuario">
                                 <HeaderStyle CssClass="celdaGrilla" />                                
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                <ItemStyle CssClass="LetraFecha" />
                                <HeaderStyle CssClass="celdaGrilla" />                                                                
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="HoraIn" HeaderText="HoraIn">
                                <ItemStyle CssClass="LetraFecha" />
                                <HeaderStyle CssClass="celdaGrilla" />                                                                
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="HoraOut" HeaderText="HoraOut">
                                <ItemStyle CssClass="LetraFecha" />
                                <HeaderStyle CssClass="celdaGrilla" />                                                                
                                </asp:BoundField>
                                
                                <asp:BoundField HeaderText="Accion" DataField="Tarea">
                                <HeaderStyle CssClass="celdaGrilla" />
                                
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#DFDFDF" />
                            <HeaderStyle BorderStyle="None" BorderWidth="0px" 
                                CssClass="LetraFormateadaNegra" HorizontalAlign="Left" 
                                Font-Size="Medium" />
                        </asp:GridView></div>
                        </td>
        </tr>
        <tr>
            <td style="width: 88px; height: 18px;">
            </td>
            <td style="width: 175px; height: 18px;">
                &nbsp;</td>
            <td style="width: 175px; height: 18px;">
            </td>
            <td style="width: 1579px; height: 18px;">
            </td>
            <td style="height: 18px">
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

