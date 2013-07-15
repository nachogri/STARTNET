<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_DetalleForm" title="Start - Novedades" Codebehind="DetalleForm.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">
        D</span>etalle</span></p>
             <asp:CustomValidator ID="cuGeneral" runat="server" Visible="False">*</asp:CustomValidator>
 <table cellpadding="0" cellspacing="0" class="LetraGeneral" width="100%">
                <tr>
                    <td style="width: 88px"></td>
                    <td colspan="3">
                        <asp:ValidationSummary ID="vsMensajes" runat="server"  class=gral_Summary 
                            Visible="False" CssClass="gral_summary" />
                        </td>
                </tr></table>
                <table style="padding-right:5px; width:90% " 
                cellpadding="1" cellspacing="1" class="LetraGeneral" >
                <tr>
                    <td style="width: 90px">
                        </td>
                    <td rowspan="3" style="width:10px">                       
                        <asp:Image ID="Image1" runat="server" />
                    </td>
                    <td>
                        <a>
                            <asp:Label ID="lblTitulo" class="LetraFormateadaNegraBold" runat="server"></asp:Label>                        
                    </td>                                        
                </tr>
                <tr>
                    <td style="width: 90px;">
                        </td>
                    <td>
                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label><br />                        
                    </td>
                    <td>
                    </td>
                </tr>                
                  <tr>
                    <td style="width: 90px">
                        </td>
                    <td colspan="2">&nbsp;</td>
                    <td></td>
                </tr>
                </table>
</asp:Content>

