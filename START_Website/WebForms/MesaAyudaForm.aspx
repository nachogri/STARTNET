<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_MesaAyudaForm" title="Start - Mesa de ayuda" Codebehind="MesaAyudaForm.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">M</span>esa de 
        ayuda</span></p>
<span class="LetraFormateadaNegra">
<div > Solucionador de problemas:</div></span>
          <table style="padding-right:5px; padding-top: 5px;" 
                cellpadding="0" cellspacing="0" >
                <tr>
                    <td colspan="2">
                         <table cellpadding="0" cellspacing="0" class="LetraGeneral" width="100%">
                <tr>
                    <td style="width: 88px">
        <asp:CustomValidator ID="cuGeneral" runat="server" Visible="False">*</asp:CustomValidator>
                    </td>
                    <td style="width: 88px">
                        <asp:ValidationSummary ID="vsMensajes" runat="server"  class=gral_Summary 
                            Visible="False" CssClass="gral_summary" Width="765px" />
                        </td>
                    <td>
                        </td>
                </tr></table></td>
                </tr>
                <tr>
                    <td style="width: 88px; height: 26px;">
                        </td>
                    <td style="height: 26px">
                        <asp:Label ID="lblPregunta" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 709px">
                        <asp:Panel ID="pnlRespuestas" runat="server">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                <asp:ListItem>Si</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 709px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 88px; height: 83px;">
                        </td>
                    <td align="center" style="height: 83px">
                        <asp:Button ID="btnSiguiente" runat="server" CssClass="gral_button" 
                            Text="Siguiente" />
                    </td>
                </tr>
                </table>

</asp:Content>

