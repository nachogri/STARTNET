<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_ProductosForm" title="Start - Consolas" Codebehind="ConsolasForm.aspx.vb" %>

<%@ Register src="../UControls/InventarioUC.ascx" tagname="InventarioUC" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<span class="LetraFormateadaNegra"><span class="LetraFormateada">C</span>onsolas</span>
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
                        &nbsp;</td>
                </tr></table>
          <table style="padding-right:5px; " 
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <uc1:InventarioUC ID="InventarioUC1" runat="server" />
                        </td>
                </tr>
                </table>

</asp:Content>

