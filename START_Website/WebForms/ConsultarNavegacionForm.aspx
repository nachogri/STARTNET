<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" CodeFile="ConsultarNavegacionForm.aspx.vb" Inherits="WebForms_ConsultarNavegacionForm" title="Start - Consulta de navegación" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">C</span>onsulta de navegación</span></p>
<span class="LetraFormateadaNegra">
    </span><div style="text-align:center">
              <div style="padding-left:20px">
          <asp:Panel ID="Panel1"  runat="server" CssClass="data_panel" Width="624px">          
          <table style="padding-right:5px; padding-top: 5px; height: 25px;" cellpadding="0" 
                  cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="7"   align=center>
                        Filtros de búsqueda</td>
                </tr>
                <tr>
                    <td style="width: 118px">
                        Usuario:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="gral_text_box" 
                            Height="17px"></asp:TextBox>
                    </td>
                    <td style="width: 167px">
                        Fecha:</td>
                    <td style="width: 147px">
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="gral_text_box" 
                            Height="16px"></asp:TextBox>
                    </td>
                    <td style="width: 284px">
                        Pantalla:</td>
                    <td style="width: 284px">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="gral_drop">
                            <asp:ListItem>Novedades</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 329px">
                        &nbsp;</td>
                </tr>
                <tr>
                        <td align="center" colspan="2" valign="top">
                        </td>
                        <td align="center" style="width: 167px;" valign="top">
                        </td>
                        <td align="center" style="width: 147px;" valign="top">
                        </td>
                        <td align="center" style="width: 284px;" valign="top">
                            </td>
                        <td align="center" style="width: 284px;" valign="top">
                            </td>
                        <td align="center" style="width: 329px;" valign="top">
                            <asp:Button ID="Button2" runat="server" CssClass="gral_button" Text="Buscar" />
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
        </tr>
        <tr class="LetraFormateadaNegra">
            <td style="width: 88px; ">
            </td>
            <td style="width: 175px; ">
                        Usuario</td>
            <td style="width: 175px; ">
                        Fecha</td>
            <td style="width: 1579px; ">
                        Recorrido</td>
        </tr>
        <tr>
            <td style="width: 88px">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 175px;">
                </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 175px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 1579px;">
            </td>
        </tr>
        <tr align="left">
            <td style="width: 88px; height: 2px;">
            </td>
            <td style="width: 175px; height: 2px;" align="left">
                &nbsp;</td>
            <td style="width: 175px; height: 2px;" align="left">
                </td>
            <td style="width: 1579px; height: 2px;" align="left">
            </td>
        </tr>
        <tr align="left">
            <td style="width: 88px">
            </td>
            <td style="width: 175px"  align="left">
                        King23</td>
            <td class="LetraFecha" style="width: 175px"  align="left">
                        24/08/2011</td>
            <td style="width: 1579px" align="left">
                Home =&gt; Novedades =&gt; Foro =&gt; Resumen de cuenta =&gt;</td>
        </tr>
        <tr align="left">
            <td style="width: 88px">
            </td>
            <td style="width: 175px" align="left">
                        ViperII</td>
            <td class="LetraFecha" style="width: 175px" align="left">
                        30/08/2011</td>
            <td style="width: 1579px" align="left">
                Home =&gt; Novedades =&gt; Juegos =&gt; Carrito de compra =&gt; Recibo de compra =&gt; Resumen 
                de cuenta</td>
        </tr>
        <tr>
            <td style="width: 88px">
            </td>
            <td style="width: 175px">
                &nbsp;</td>
            <td style="width: 175px">
                </td>
            <td style="width: 1579px">
            </td>
        </tr>
        <tr>
            <td style="width: 88px">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 175px;">
                </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 175px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 1579px;">
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
        </tr>
    </table>

</asp:Content>

