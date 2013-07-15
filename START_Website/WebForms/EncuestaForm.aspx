<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebForms/Main.Master" CodeBehind="EncuestaForm.aspx.vb" Inherits="START_Website.EncuestaForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
            <tr>
                <td colspan="3">
                    <div style="padding-right: 0px; padding-left: 0px;">
                        <asp:Label ID="Label5" runat="server" CssClass="LetraFormateada" meta:resourcekey="Label80Resource"
                            Text="E" />
                        <asp:Label class="LetraFormateadaNegra" ID="Label6" runat="server" meta:resourcekey="Label81Resource"
                            Text="ncuesta de satisfacción" /><br />
                    </div>
                </td>
            </tr>
        </table>
            <br />
                        <div align="left">
                            <br />
                            <asp:Label ID="Label1" runat="server" Text="Como siempre estamos intentanto mejorar, quisieramos contar con tu valiosa opinión:"></asp:Label>
                             <table cellpadding="0" cellspacing="0" class="LetraGeneral" align="left">
                                <tr class="LetraFormateadaNegra">
                                    <td class="style3">
                                      <asp:CustomValidator ID="cuGeneral" runat="server" Visible="False">*</asp:CustomValidator>
                                                </td>
                                                <td colspan="5">
                                                    <asp:ValidationSummary ID="vsMensajes" runat="server" class="gral_Summary" 
                                                        CssClass="gral_summary" Visible="False" Width="538px" />
                                        </td>
                                </tr>
                              </table>
                            <br />
                            <br />
                            <br />
                            <br />                         
                            <table style="width:100%;">
                                <tr>
                                
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td colspan="3">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td colspan="3">
                                        Como calificarías tu experiencia de compra en nuestro sitio?</td>
                                </tr>
                                <tr>
                                
                                    <td style="width: 64px">
                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" 
                                            ControlToValidate="rblExperiencia" Display=Dynamic ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="3">
                                        <asp:RadioButtonList CssClass=LetraGeneral RepeatDirection=Horizontal ID=rblExperiencia runat=server>
                                            <asp:ListItem Value="5">Excelente</asp:ListItem>
                                            <asp:ListItem Value="4">Muy buena</asp:ListItem>
                                            <asp:ListItem Value="3">Regular</asp:ListItem>
                                            <asp:ListItem Value="2">Malo</asp:ListItem>
                                            <asp:ListItem Value="1">Muy malo</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td colspan="3">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td colspan="3">
                                        El catalogo de productos satisface tus necesidades?</td>
                                </tr>
                                <tr>
                                
                                    <td style="width: 64px">
                                        <asp:RequiredFieldValidator ID="rfv2" runat="server" 
                                            ControlToValidate="rblCatalogo" Display=Dynamic ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="3">
                                        <asp:RadioButtonList CssClass=LetraGeneral RepeatDirection=Horizontal ID=rblCatalogo runat=server>
                                         <asp:ListItem Value="5">Excelente</asp:ListItem>
                                            <asp:ListItem Value="4">Muy buena</asp:ListItem>
                                            <asp:ListItem Value="3">Regular</asp:ListItem>
                                            <asp:ListItem Value="2">Malo</asp:ListItem>
                                            <asp:ListItem Value="1">Muy malo</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td colspan="3">
                                        &nbsp;</td>
                                </tr>
                                 <tr>
                                
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td colspan="3">
                                        El carrito de compras te da la confianza necesaria para confirmar la compra?</td>
                                </tr>
                                 <tr>
                                
                                    <td style="width: 64px">
                                        <asp:RequiredFieldValidator ID="rfv3" runat="server" 
                                            ControlToValidate="rblCarrito" Display=Dynamic ErrorMessage="*"></asp:RequiredFieldValidator>
                                     </td>
                                    <td colspan="3">
                                        <asp:RadioButtonList CssClass=LetraGeneral RepeatDirection=Horizontal ID=rblCarrito runat=server>
                                            <asp:ListItem Value="5">Excelente</asp:ListItem>
                                            <asp:ListItem Value="4">Muy buena</asp:ListItem>
                                            <asp:ListItem Value="3">Regular</asp:ListItem>
                                            <asp:ListItem Value="2">Malo</asp:ListItem>
                                            <asp:ListItem Value="1">Muy malo</asp:ListItem>
                                        </asp:RadioButtonList>
                                     </td>
                                </tr>
                                 <tr>
                                
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td colspan="3">
                                        &nbsp;</td>
                                </tr>
                                 <tr>
                                
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td colspan="3">
                                        Como calificarías a nuestra mesa de ayuda interactiva?</td>
                                </tr>
                                <tr>
                                
                                    <td style="width: 64px">
                                        <asp:RequiredFieldValidator ID="rfv4" runat="server" 
                                            ControlToValidate="rblMesaAyuda" Display=Dynamic ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="3">
                                        <asp:RadioButtonList CssClass=LetraGeneral RepeatDirection=Horizontal ID=rblMesaAyuda runat=server>
                                            <asp:ListItem Value="5">Excelente</asp:ListItem>
                                            <asp:ListItem Value="4">Muy buena</asp:ListItem>
                                            <asp:ListItem Value="3">Regular</asp:ListItem>
                                            <asp:ListItem Value="2">Malo</asp:ListItem>
                                            <asp:ListItem Value="1">Muy malo</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td colspan="3">
                                        &nbsp;</td>
                                </tr>
                                 <tr>
                                
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td colspan="3">
                                        Como calificarías al servicio de contacto?</td>
                                </tr>
                                <tr>
                                
                                    <td style="width: 64px">
                                        <asp:RequiredFieldValidator ID="rfv5" runat="server" 
                                            ControlToValidate="rblContacto" Display=Dynamic ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="3">
                                        <asp:RadioButtonList CssClass=LetraGeneral RepeatDirection=Horizontal ID=rblContacto runat=server>
                                            <asp:ListItem Value="5">Excelente</asp:ListItem>
                                            <asp:ListItem Value="4">Muy buena</asp:ListItem>
                                            <asp:ListItem Value="3">Regular</asp:ListItem>
                                            <asp:ListItem Value="2">Malo</asp:ListItem>
                                            <asp:ListItem Value="1">Muy malo</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td colspan="3">
                                        &nbsp;</td>
                                </tr>
                                 <tr>
                                
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td colspan="3">
                                        Como calificarías a la sección de Comunidad?</td>
                                </tr>
                                <tr>
                                
                                    <td style="width: 64px">
                                        <asp:RequiredFieldValidator ID="rfv6" runat="server" 
                                            ControlToValidate="rblComunidad" Display=Dynamic ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="3">
                                        <asp:RadioButtonList CssClass=LetraGeneral RepeatDirection=Horizontal ID=rblComunidad runat=server>
                                            <asp:ListItem Value="5">Excelente</asp:ListItem>
                                            <asp:ListItem Value="4">Muy buena</asp:ListItem>
                                            <asp:ListItem Value="3">Regular</asp:ListItem>
                                            <asp:ListItem Value="2">Malo</asp:ListItem>
                                            <asp:ListItem Value="1">Muy malo</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td style="width: 369px">
                                        &nbsp;</td>
                                    <td style="width: 92px">
                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="gral_button" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <br />
                        </div>

</asp:Content>
