<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebForms/Main.Master" CodeBehind="AdministracionParametrosForm.aspx.vb" Inherits="START_Website.AdministracionParametrosForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
 <span class="LetraFormateadaNegra"><span class="LetraFormateada">A</span>dministración 
        de parámetros</span><table cellpadding="0" cellspacing="0" class="LetraGeneral">
            <tr align="left">
                    <td style="height: 2px;" colspan="4">
            <table cellpadding="0" cellspacing="0" class="LetraGeneral" align="left" width="100%">
                <tr class="LetraFormateadaNegra">
                      <td class="style3">
                      <asp:CustomValidator ID="cuGeneral" runat="server" Visible="False">*</asp:CustomValidator>
                                </td>
                                <td>
                                    <asp:ValidationSummary ID="vsMensajes" runat="server" class="gral_Summary" 
                                        CssClass="gral_summary" Visible="False" />
                    </td>
                </tr>
            </table>
                        </td>
                    <td style="height: 2px;">
                        &nbsp;</td>
                </tr>
            <tr align="left">
                    <td style="width: 374px; height: 2px;">
                        </td>
                    <td style="width: 638px; height: 2px;" align="left">
                        </td>
                    <td style="width: 168px; height: 2px;">
                        </td>
                    <td style="width: 330px; height: 2px;">
                        </td>
                    <td style="width: 330px; height: 2px;">
                        &nbsp;</td>
                </tr>
                </table>
    <table cellpadding="0" cellspacing="0" class="LetraGeneral">
        <tr class="LetraFormateadaNegra">
            <td style="width: 88px; ">
                &nbsp;</td>
            <td colspan="5">
                        &nbsp;</td>
            <td style="width: 109px">
                        &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 88px">
                <span class="LetraFormateadaNegra">
    <span class="LetraFormateada">P</span>aíses</span></td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 175px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 1125px;">
                &nbsp;</td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 237px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 106px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 330px;">
            </td>
            <td style="width: 109px;">
            </td>
        </tr>
        <tr>
            <td style="width: 88px; height: 18px;">
            </td>
            <td style="width: 175px; height: 18px;">
                Nombre:</td>
            <td style="width: 1125px; height: 18px;">
                <asp:TextBox ID="txtPais" runat="server" CssClass="LetraGeneral" Width="125px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtPais" ValidationGroup="vgPais">*</asp:RequiredFieldValidator>
                <asp:Button ID="btnAgregarPais" runat="server" CssClass="gral_button" 
                    Text="Agregar" ValidationGroup="vgPais" />
            </td>
            <td style="height: 18px; width: 237px;">
                        &nbsp;</td>
            <td style="height: 18px; width: 106px;">
                        &nbsp;</td>
            <td style="width: 330px; height: 18px;">
            </td>
            <td style="width: 109px; height: 18px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 88px; height: 18px;">
                &nbsp;</td>
            <td style="width: 175px; height: 18px;">
                &nbsp;</td>
            <td style="width: 1125px; height: 18px;">
                <asp:ListBox ID="lstPaises" runat="server" CssClass="LetraGeneral" Height="97px" 
                    Width="127px"></asp:ListBox>
            </td>
            <td style="height: 18px; width: 237px;">
                        &nbsp;</td>
            <td style="height: 18px; width: 106px;">
                        &nbsp;</td>
            <td style="width: 330px; height: 18px;">
                &nbsp;</td>
            <td style="width: 109px; height: 18px;">
                &nbsp;</td>
        </tr>
              <tr>
            <td style="width: 88px">
                <span class="LetraFormateadaNegra">
    <span class="LetraFormateada">P</span>rovincias</span></td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 175px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 1125px;">
                &nbsp;</td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 237px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 106px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 330px;">
            </td>
            <td style="width: 109px;">
            </td>
        </tr>
        <tr>
            <td style="width: 88px; height: 18px;">
            </td>
            <td style="width: 175px; height: 18px;">
                Nombre:</td>
            <td style="width: 1125px; height: 18px;">
                <asp:TextBox ID="txtProvincia" runat="server" CssClass="LetraGeneral" 
                    Width="125px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtProvincia" ValidationGroup="vgProvincia">*</asp:RequiredFieldValidator>
            </td>
            <td style="height: 18px; width: 237px;">
                        &nbsp;</td>
            <td style="height: 18px; width: 106px;">
                        &nbsp;</td>
            <td style="width: 330px; height: 18px;">
            </td>
            <td style="width: 109px; height: 18px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 88px; height: 31px;">
                </td>
            <td style="width: 175px; height: 31px;">
                </td>
            <td style="width: 1125px; height: 31px;">
                <asp:DropDownList ID="ddlPaises" runat="server" CssClass="LetraGeneral" 
                    Width="127px">
                </asp:DropDownList>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="ddlPaises" ValidationGroup="vgProvincia">*</asp:RequiredFieldValidator>
&nbsp;<asp:Button ID="btnAgregarPaises" runat="server" CssClass="gral_button" Text="Agregar" 
                    ValidationGroup="vgProvincia" />
            </td>
            <td style="height: 31px; width: 237px;">
                        </td>
            <td style="height: 31px; width: 106px;">
                        </td>
            <td style="width: 330px; height: 31px;">
                </td>
            <td style="width: 109px; height: 31px;">
                </td>
        </tr>
        <tr>
            <td style="width: 88px; height: 18px;">
                &nbsp;</td>
            <td style="width: 175px; height: 18px;">
                &nbsp;</td>
            <td style="width: 1125px; height: 18px;">
                <asp:ListBox ID="lstProvincias" runat="server" CssClass="LetraGeneral" Height="97px" 
                    Width="127px"></asp:ListBox>
            </td>
            <td style="height: 18px; width: 237px;">
                        &nbsp;</td>
            <td style="height: 18px; width: 106px;">
                        &nbsp;</td>
            <td style="width: 330px; height: 18px;">
                &nbsp;</td>
            <td style="width: 109px; height: 18px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 88px">
                <span class="LetraFormateadaNegra">
    <span class="LetraFormateada">L</span>ocalidades</span></td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 175px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 1125px;">
                &nbsp;</td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 237px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 106px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 330px;">
            </td>
            <td style="width: 109px;">
            </td>
        </tr>
        <tr>
            <td style="width: 88px; height: 18px;">
            </td>
            <td style="width: 175px; height: 18px;">
                Nombre:</td>
            <td style="width: 1125px; height: 18px;">
                <asp:TextBox ID="txtLocalidad" runat="server" CssClass="LetraGeneral" 
                    Width="125px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtLocalidad" ValidationGroup="vgLocalidad">*</asp:RequiredFieldValidator>
            </td>
            <td style="height: 18px; width: 237px;">
                        &nbsp;</td>
            <td style="height: 18px; width: 106px;">
                        &nbsp;</td>
            <td style="width: 330px; height: 18px;">
            </td>
            <td style="width: 109px; height: 18px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 88px; height: 18px;">
                &nbsp;</td>
            <td style="width: 175px; height: 18px;">
                CP:</td>
            <td style="width: 1125px; height: 18px;">
                <asp:TextBox ID="txtCP" runat="server" CssClass="LetraGeneral" Width="78px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtCP" ValidationGroup="vgLocalidad">*</asp:RequiredFieldValidator>
            </td>
            <td style="height: 18px; width: 237px;">
                        &nbsp;</td>
            <td style="height: 18px; width: 106px;">
                        &nbsp;</td>
            <td style="width: 330px; height: 18px;">
                &nbsp;</td>
            <td style="width: 109px; height: 18px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 88px; height: 27px;">
                </td>
            <td style="width: 175px; height: 27px;">
                </td>
            <td style="width: 1125px; height: 27px;">
                <asp:DropDownList ID="ddProvincias" runat="server" CssClass="LetraGeneral" 
                    Width="127px">
                </asp:DropDownList>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="ddProvincias" ValidationGroup="vgLocalidad">*</asp:RequiredFieldValidator>
&nbsp;<asp:Button ID="btnAgregarLocalidades" runat="server" CssClass="gral_button" 
                    Text="Agregar" ValidationGroup="vgLocalidad" />
            </td>
            <td style="height: 27px; width: 237px;">
                        </td>
            <td style="height: 27px; width: 106px;">
                        </td>
            <td style="width: 330px; height: 27px;">
                </td>
            <td style="width: 109px; height: 27px;">
                </td>
        </tr>
        <tr>
            <td style="width: 88px; height: 18px;">
                &nbsp;</td>
            <td style="width: 175px; height: 18px;">
                &nbsp;</td>
            <td style="width: 1125px; height: 18px;">
                <asp:ListBox ID="lstLocalidades" runat="server" CssClass="LetraGeneral" Height="97px" 
                    Width="127px"></asp:ListBox>
            </td>
            <td style="height: 18px; width: 237px;">
                        &nbsp;</td>
            <td style="height: 18px; width: 106px;">
                        &nbsp;</td>
            <td style="width: 330px; height: 18px;">
                &nbsp;</td>
            <td style="width: 109px; height: 18px;">
                &nbsp;</td>
        </tr>        
    </table>
    </div>
</asp:Content>
