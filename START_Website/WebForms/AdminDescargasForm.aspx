<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebForms/Main.Master" CodeBehind="AdminDescargasForm.aspx.vb" Inherits="START_Website.WebForms_AdminDescargasForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">A</span>dministración de descargas</span></p>
<span class="LetraFormateadaNegra">
    </span>
    <table cellpadding="0" cellspacing="0" class="LetraGeneral">
                <tr class="LetraChicaNegra">
                    <td style="width: 88px; ">
                        </td>
                    <td style="width: 1579px; ">
                        Título</td>
                    <td style="width: 1579px; ">
                        Descripción</td>
                    <td style="width: 795px; ">
                        Fecha</td>
                    <td style="width: 278px; ">
                        Tipo</td>
                </tr>
                 <tr>
                    <td style="width: 88px"></td>
                    <td  style="background-image: url('../resources/images/menu_separator.gif'); width: 1579px;"></td>
                    <td  style="background-image: url('../resources/images/menu_separator.gif'); width: 1579px;">
                        </td>
                    <td  style="background-image: url('../resources/images/menu_separator.gif'); width: 795px;">
                        </td>
                    <td  style="background-image: url('../resources/images/menu_separator.gif'); width: 278px;">
                        </td>
                </tr>
                <tr align="left">
                    <td style="width: 88px; height: 2px;">
                        </td>
                    <td style="width: 1579px; height: 2px;" align="left">
                    </td>
                    <td style="width: 1579px; height: 2px;" align="left">
                        </td>
                    <td style="width: 795px; height: 2px;" align="left">
                        </td>
                    <td style="width: 278px; height: 2px;" align="left">
                    </td>
                </tr>
                <tr align="left">
                    <td style="width: 88px; height: 30px;">
                        </td>
                    <td style="width: 1579px; height: 30px;" align="left">
                        <a>
                        <b>Catálogo de juegos 2011</b></a>
                        <br />
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="gral_link">Seleccionar</asp:HyperLink>
                    </td>
                    <td style="width: 1579px; height: 30px;" align="left">
                        Catálogo de juegos 2011 dividido por consolas </td>
                    <td class="LetraFecha" style="width: 795px; height: 30px;" align="left">
                        25/08/2011</td>
                    <td style="width: 278px; height: 30px;" align="left">
                        DOC</td>
                </tr>
                <tr>
                    <td style="width: 88px"></td>
                    <td  style="background-image: url('../resources/images/menu_separator.gif'); width: 1579px;"></td>
                    <td  style="background-image: url('../resources/images/menu_separator.gif'); width: 1579px;">
                        </td>
                    <td  style="background-image: url('../resources/images/menu_separator.gif'); width: 795px;">
                        </td>
                    <td  style="background-image: url('../resources/images/menu_separator.gif'); width: 278px;">
                        </td>
                 </tr>
                <tr>
                    <td style="width: 88px; height: 30px;">
                        </td>
                    <td style="width: 1579px; height: 30px;">
                        <a>
                        <b >Wallpapers de PS2</b></a>
                        <br />
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="gral_link">Seleccionar</asp:HyperLink>
                    </td>
                    <td style="width: 1579px; height: 30px;">
                        Los mejores wallpapers de PS2 para tu PC</td>
                    <td class="LetraFecha" style="width: 795px; height: 30px;">
                        12/03/2011</td>
                    <td style="width: 278px; height: 30px;">
                        PDF</td>
                </tr>               
                <tr>
                    <td style="width: 88px; height: 2px;">
                        </td>
                    <td style="width: 1579px; height: 2px;">
                    </td>
                    <td style="width: 1579px; height: 2px;">
                        </td>
                    <td style="width: 795px; height: 2px;">
                        </td>
                    <td style="width: 278px; height: 2px;">
                    </td>
                </tr>               
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 1579px">
                        </td>
                    <td style="width: 1579px">
                        </td>
                    <td style="width: 795px">
                        </td>
                    <td style="width: 278px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 1579px;" 
                        height="1"></td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 1579px;" 
                        height="1"></td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 795px;" 
                        height="1"></td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 278px;" 
                        height="1"></td>
                </tr>
                <tr>
                    <td style="width: 88px; height: 15px;">
                        </td>
                    <td style="width: 1579px; height: 15px;">
                        </td>
                    <td style="width: 1579px; height: 15px;">
                        </td>
                    <td style="width: 795px; height: 15px;">
                        </td>
                    <td style="height: 15px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td style="width: 1579px">
                        &nbsp;</td>
                    <td style="width: 1579px">
                        &nbsp;</td>
                    <td style="width: 795px">
                        &nbsp;</td>
                    <td align="right">
                        <asp:Button ID="Button3" 
                        runat="server" CssClass="gral_button" Text="Agregar" />&nbsp;<asp:Button 
                        ID="Button4" runat="server" CssClass="gral_button" Text="Eliminar" 
                        onclientclick="window.open('ReciboForm.aspx');" 
                        PostBackUrl="~/webForms/Home.aspx" /></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td style="width: 1579px">
                        &nbsp;</td>
                    <td style="width: 1579px">
                        &nbsp;</td>
                    <td style="width: 795px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                </table>
          <div style="padding-left:20px">
          <asp:Panel ID="Panel1"  runat="server" CssClass="data_panel" Width="60%">          
          <table style="padding-right:5px; padding-top: 5px;"  width=100% cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="2"   align=center>
                        Datos del producto</td>
                </tr>
                <tr>
                    <td style="width: 24px" valign="top">
                        Título:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="gral_text_box" 
                            Height="17px" Width="37%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 24px" valign="top">
                        Descripción:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="gral_text_box" 
                            Height="70px" Width="109%" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 24px" valign="top">Fecha:</td>
                    <td style="width: 289px">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="gral_text_box" Height="16px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 24px" valign="top">
                        Tipo:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="gral_text_box" 
                            Height="16px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 24px"> Ruta:</td>
                    <td style="width: 289px">                                                    
                    <table cellpadding=0 cellspacing=0>
                     <tr>
                     <td>
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="gral_text_box" Height="16px" 
                             Width="313px"></asp:TextBox>
                     </td>
                     <td>
                         &nbsp;
                     </td>
                    </tr>
                    </table>
                    </td>
                </tr>
                <tr>
                        <td align="center" colspan="2" style="height: 10px;" valign="top">
                            <asp:Button ID="Button2" runat="server" CssClass="gral_button" Text="Aceptar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                            </td>
                    </tr>
                </table>
          </asp:Panel></div>
</asp:Content>


