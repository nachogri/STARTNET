<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" EnableEventValidation="false" AutoEventWireup="false" Inherits="START_Website.WebForms_AdminMensajesForm" title="Start - Mensajes" Codebehind="AdminMensajesForm.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">A</span>dministración de mensajes</span></p>
<span class="LetraFormateadaNegra">
    </span>
     <table cellpadding="0" cellspacing="0" class="LetraGeneral">
                <tr>
                    <td style="width: 88px">
                        <span class="LetraFormateadaNegra">
        <asp:CustomValidator ID="cuGeneral" runat="server" 
            Visible="False">*</asp:CustomValidator>
                        </span></td>
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
                        <asp:GridView ID="grvMensajes" runat="server" AutoGenerateColumns="False" 
                            GridLines="Horizontal" Width="100%" AllowPaging="True" AllowSorting="True" 
                            PageSize="5" BorderWidth="0px" CellPadding="0" 
                            DataKeyNames="Identificador" OnRowDataBound=grvUsuarios_RowDataBound 
                            CssClass="LetraGeneral" BorderColor="#CACACA">
                            <Columns>                                
                                <asp:TemplateField HeaderText="Usuario">
                                <ItemTemplate >
                                         <table style="padding-right:5px; "  cellpadding="0" cellspacing="0" class="LetraGeneral" >
                                            <tr>
                                                <td>
                                                      <asp:Label ID="lblUsuario" CssClass=LetraChicaNegra runat="server"><%#DataBinder.Eval(Container.DataItem, "Usuario.Nickname")%></asp:Label>                        
                                                </td>
                                            </tr>
                                            <tr>
                                               <td style="height: 16px">
                                               <asp:HyperLink  ID="hlSeleccionar"  runat="server" CssClass="gral_link" >Responder</asp:HyperLink>
                                               </td>
                                            </tr>
                                           </table>
                                </ItemTemplate>
                                <ItemStyle  CssClass="celdaGrilla" />
                                <HeaderStyle CssClass="celdaGrilla" />
                                </asp:TemplateField>                                
                                <asp:BoundField  HeaderText="Tipo" DataField="Tipo" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha" DataFormatString="{0:dd-MM-yyyy}" 
                                    HeaderText="Fecha">
                                    <HeaderStyle CssClass="celdaGrilla" />
                                    <ItemStyle CssClass="celdaGrilla" />
                                </asp:BoundField>
                                <asp:BoundField  HeaderText="Mensaje" DataField="Mensaje" >
                                    <HeaderStyle CssClass="celdaGrilla" />
                                <ItemStyle  CssClass="celdaGrilla" />    
                                </asp:BoundField>
                                <asp:BoundField  HeaderText="Respuesta" DataField="Respuesta" >
                                    <HeaderStyle CssClass="celdaGrilla" />
                                <ItemStyle  CssClass="celdaGrilla" />    
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
                </table>
    <table cellpadding="0" cellspacing="0" class="LetraGeneral">
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td style="width: 1579px">
                        &nbsp;</td>
                    <td style="width: 855px">
                        &nbsp;</td>
                </tr>
                </table>
          <div style="padding-left:20px">
          <asp:Panel ID="Panel1"  runat="server" CssClass="data_panel" Width="60%">          
          <table style="padding-right:5px; padding-top: 5px;"  width=100% cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="2"   align=center>
                        Datos de la respuesta</td>
                </tr>
                <tr>
                    <td style="width: 54px" valign="top">
                        Usuario:</td>
                    <td style="width: 289px">
                    <table cellpadding=0 cellspacing=0><tr><td>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="gral_text_box" 
                            ReadOnly="True" Width="75px"></asp:TextBox></td><td> &nbsp;
                            </td></tr></table>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width: 54px" valign="top">
                        Tipo:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtTipo" runat="server" CssClass="gral_text_box" 
                            ReadOnly="True" Width="75px"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td style="width: 54px" valign="top">
                        Fecha:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="gral_text_box" 
                            ReadOnly="True" Width="75px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 54px" valign="top">
                        Mensaje:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtMensaje" runat="server" CssClass="gral_text_box" 
                            Height="122px" ReadOnly="True" TextMode="MultiLine" Width="392px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 54px" valign="top">
                        Respuesta:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtRespuesta" runat="server" CssClass="gral_text_box" 
                            Height="122px" Width="392px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                        <td align="center" colspan="2" style="height: 10px;" valign="top">
                            <asp:Button ID="btnAceptar" runat="server" CssClass="gral_button" 
                                Text="Enviar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                            </td>
                    </tr>
                </table>
          </asp:Panel></div>
</asp:Content>

