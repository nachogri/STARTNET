<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebForms/Main.Master" CodeBehind="ConfirmacionRegistroForm.aspx.vb" Inherits="START_Website.ConfirmacionRegistroForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                </tr></table>
                </asp:Content>
