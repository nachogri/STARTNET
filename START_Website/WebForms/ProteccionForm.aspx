<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_ProteccionForm" title="Start - Protección del sistema" Codebehind="ProteccionForm.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:CustomValidator ID="cuGeneral" runat="server" 
            Visible="False" CssClass="LetraGeneral">*</asp:CustomValidator>
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
    <span class="LetraFormateadaNegra"><span class="LetraFormateada">B</span>ackup</span>
            <table cellpadding="0" cellspacing="0" class="LetraGeneral">
            <tr align="left">
                    <td style="width: 88px; height: 2px;">
                        </td>
                    <td style="width: 133px; height: 2px;" align="left">
                        </td>
                    <td style="width: 281px; height: 2px;">
                        </td>
                </tr>
                <tr align="left">
                    <td style="width: 88px">
                        </td>
                    <td style="width: 133px" align="left">
                        Fecha de último backup:</td>
                    <td class="LetraFecha" style="width: 281px">
                        <asp:Label ID="lblFechaBackup" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 133px">
                        &nbsp;</td>
                     <td style="width: 281px">
                         </td>
                </tr>               
                <tr>
                    <td style="width: 88px; height: 2px;">
                        </td>
                    <td style="height: 2px;" align="center" colspan="2">
                        <asp:Button ID="btnGenerarBackup" runat="server" CssClass="gral_button" 
                            Text="Generar" />
&nbsp;<asp:Button ID="btnRestaurarBackup" runat="server" CssClass="gral_button" Text="Restaurar" />
                    </td>
                </tr>               
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 133px">
                        </td>
                    <td style="width: 281px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 133px;"></td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 281px;"></td>
                </tr>
                </table>
                <span class="LetraFormateadaNegra"><span class="LetraFormateada">N</span>ews letter</span>
            <table cellpadding="0" cellspacing="0" class="LetraGeneral">
            <tr align="left">
                    <td style="width: 88px; height: 2px;">
                        </td>
                    <td style="width: 135px; height: 2px;" align="left">
                        </td>
                    <td style="width: 281px; height: 2px;">
                        </td>
                </tr>
                <tr align="left">
                    <td style="width: 88px">
                        </td>
                    <td style="width: 135px" align="left">
                        Fecha de último envío:</td>
                    <td class="LetraFecha" style="width: 281px">
                        <asp:Label ID="lblFechaNewsLetter" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 135px">
                        &nbsp;</td>
                     <td style="width: 281px">
                         </td>
                </tr>               
                <tr>
                    <td style="width: 88px; height: 2px;">
                        </td>
                    <td style="height: 2px;" align="center" colspan="2">
                        <asp:Button ID="Button4" runat="server" CssClass="gral_button" 
                            Text="Enviar" />
                    </td>
                </tr>               
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 135px">
                        </td>
                    <td style="width: 281px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 135px;"></td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 281px;"></td>
                </tr>
                </table>
                </div>
</asp:Content>

