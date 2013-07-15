<%@ Page Title="" Language="VB" MasterPageFile="~/WebForms/Main.Master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AdminFamiliasForm.aspx.vb" Inherits="WebForms_AdminFamiliasForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <span class="LetraFormateadaNegra"><span class="LetraFormateada">A</span>dministración 
        de familias</span>
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
                        <asp:GridView ID="grvFamilias" runat="server" AutoGenerateColumns="False" 
                            GridLines="Horizontal" Width="100%" AllowPaging="True" AllowSorting="True" 
                            PageSize="5" BorderWidth="0px" CellPadding="0" 
                            DataKeyNames="Identificador" OnRowDataBound=grvFamilias_RowDataBound 
                            CssClass="LetraGeneral" BorderColor="#CACACA">
                            <Columns>                                
                                <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate >
                                         <table style="padding-right:5px; "  cellpadding="0" cellspacing="0" class="LetraGeneral" >
                                            <tr>
                                                <td>
                                                      <asp:Label ID="lblNombre" CssClass=LetraChicaNegra runat="server"><%#DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:Label>                        
                                                </td>
                                            </tr>
                                            <tr>
                                               <td style="height: 16px">
                                               <asp:HyperLink  ID="hlEspecificaciones"  runat="server" CssClass="gral_link" >Seleccionar</asp:HyperLink>
                                               </td>
                                            </tr>
                                           </table>
                                </ItemTemplate>
                                <ItemStyle  CssClass="celdaGrilla" />
                                <HeaderStyle CssClass="celdaGrilla" />
                                </asp:TemplateField>
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
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td style="width: 1579px">
                        &nbsp;</td>
                    <td style="width: 1319px">
                        &nbsp;</td>
                    <td align="right" style="width: 682px">
                        <asp:Button ID="btnAgregarFamilia" 
                        runat="server" CssClass="gral_button" Text="Agregar" />&nbsp;
                        <asp:Button 
                        ID="btnEliminarFamilia" runat="server" CssClass="gral_button" 
                            Text="Borrar" /></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td style="width: 1579px">
                        &nbsp;</td>
                    <td style="width: 1319px">
                        &nbsp;</td>
                    <td style="width: 682px">
                        &nbsp;</td>
                </tr>
                </table>
          <div style="height:2px"></div>
          
          <div style="padding-left:30px">
          <asp:Panel ID="Panel2"  runat="server" CssClass="data_panel" Width="60%">
                <table style="padding-right:5px;  padding-top: 5px;" width=100%
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                 <tr>
                    <td colspan="2"  align=center>
                        Datos de familia</td>
                </tr>
                <tr>
                    <td style="width: 118px">
                        Nombre:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="56%"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtNombre" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                </table>
          </asp:Panel></div>
          <div style="height:2px"></div>
                         <div style="padding-left:30px">
          <asp:Panel ID="Panel4"  runat="server" CssClass="data_panel" Width="60%">
          <table style="padding-right:5px; padding-top: 5px;"  width=100%
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="2"   align=center>
                        Datos de seguridad</td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Patente individual:</td>
                    <td style="width: 289px">
                         <table width="100%">
                            <tr>
                                <td rowspan="2">
                                    <asp:ListBox ID="lstPatentes" runat="server" CssClass="gral_text_box" 
                                        Width="200px"></asp:ListBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnAgregarPatente" runat="server" CssClass="gral_button" 
                                        Text="&gt;&gt;" ValidationGroup="AMPatente" />
                                    <asp:RequiredFieldValidator ID="rfvPatentes" runat="server" 
                                        ControlToValidate="lstPatentes" Display="Dynamic" Enabled="true" 
                                        Font-Size="Small" ValidationGroup="AMPatente">*</asp:RequiredFieldValidator>
                                </td>
                                <td rowspan="2">
                                    <asp:ListBox ID="lstPatentesFinal" runat="server" CssClass="gral_text_box" 
                                        Width="200px"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnQuitarPatente" runat="server" CssClass="gral_button" 
                                        Text="&lt;&lt;" ValidationGroup="AMPatenteFinal" />
                                    <asp:RequiredFieldValidator ID="rfvFamilia1" runat="server" 
                                        ControlToValidate="lstPatentesFinal" Display="Dynamic" Enabled="true" 
                                        Font-Size="Small" ValidationGroup="AMPatenteFinal">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table></td>
                </tr>
                <tr>
                    <td colspan="2" valign="top">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" valign="top">
                        <asp:Button ID="btnAceptar" runat="server" CssClass="gral_button" 
                            Text="Aceptar" ValidationGroup="AMSubmit" />
                    </td>
                </tr>
                </table>
          </asp:Panel></div>
</asp:Content>

