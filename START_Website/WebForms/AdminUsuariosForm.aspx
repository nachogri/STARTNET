<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" EnableEventValidation="false" AutoEventWireup="false" Inherits="START_Website.WebForms_AdminUsuariosForm" title="Start - Administración de usuarios" Codebehind="AdminUsuariosForm.aspx.vb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<span class="LetraFormateadaNegra"><span class="LetraFormateada">A</span>dministración 
        de usuarios</span>
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
                        <asp:GridView ID="grvUsuarios" runat="server" AutoGenerateColumns="False" 
                            GridLines="Horizontal" Width="100%" AllowPaging="True" AllowSorting="True" 
                            PageSize="5" BorderWidth="0px" CellPadding="0" 
                            DataKeyNames="Identificador" OnRowDataBound=grvUsuarios_RowDataBound 
                            CssClass="LetraGeneral" BorderColor="#CACACA">
                            <Columns>                                
                                <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate >
                                         <table style="padding-right:5px; "  cellpadding="0" cellspacing="0" class="LetraGeneral" >
                                            <tr>
                                                <td>
                                                      <asp:Label ID="lblNombre" CssClass=LetraChicaNegra runat="server"><%#DataBinder.Eval(Container.DataItem, "Nombre") & " " & DataBinder.Eval(Container.DataItem, "Apellido")%></asp:Label>                        
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
                                <asp:BoundField  HeaderText="Nickname" DataField="NickName" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
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
                        <asp:Button ID="btnAgregarUsuario" 
                        runat="server" CssClass="gral_button" Text="Agregar" />&nbsp;<asp:Button 
                        ID="btnEliminarUsuario" runat="server" CssClass="gral_button" 
                            Text="Eliminar" /></td>
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
                <div style="padding-left:30px">
          <asp:Panel ID="Panel1"  runat="server" CssClass="data_panel" Width="60%">
          <table style="padding-right:5px; padding-top: 5px;"  width=100%
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="2"   align=center>
                        Datos de cuenta</td>
                </tr>
               <tr>
                    <td style="width: 118px" valign="top">
                        Nickname:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtNickname" runat="server" CssClass="gral_text_box" 
                            Height="17px" Width="37%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv0" runat="server" 
                            ControlToValidate="txtNickname" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Contraseña:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtContrasena" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="37%" TextMode="Password"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtContrasena" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Repita contraseña:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtContrasenaR" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="37%" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtContrasenaR" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                      
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        &nbsp;</td>
                    <td style="width: 289px">
                        <asp:Button ID="btnAgregarFamilia0" runat="server" CssClass="gral_button" 
                            Text="Desbloquear" ValidationGroup="AMFamilia" Enabled="False" />
                    </td>
                </tr>
                </table>
          </asp:Panel></div>
          <div style="height:2px"></div>
          
          <div style="padding-left:30px">
          <asp:Panel ID="Panel2"  runat="server" CssClass="data_panel" Width="60%">
                <table style="padding-right:5px;  padding-top: 5px;" width=100%
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                 <tr>
                    <td colspan="2"  align=center>
                        Datos personales</td>
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
                <tr>
                    <td style="width: 118px" valign="top">
                        Apellido:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="56%"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtApellido" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Tipo de documento:</td>
                    <td style="width: 289px">
                        <asp:DropDownList ID="ddlDocumentoT" runat="server" CssClass="gral_drop">
                            <asp:ListItem>DNI</asp:ListItem>
                            <asp:ListItem>LE</asp:ListItem>
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="ddlDocumentoT" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Nro. de documento:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtNroDocumento" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="27%"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtNroDocumento" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                    <tr>
                        <td style="width: 118px" valign="top">                        
                            Fecha de nacimiento:</td>
                        <td>                          
                         <table cellspacing=0 cellpadding=0 border=0>
                        <tr>
                        <td><asp:TextBox ID="txtFechaNacimiento" CssClass=gral_text_box runat="server"></asp:TextBox></td>                        
                        <td>&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" 
                                 ImageUrl="~/Images/gral_icon_calendar.jpg" /></td>
                        <td></td>
                        </tr>
                        </table>
                        <asp:CalendarExtender Format="dd/MM/yyyy"  ID="txtFechaNacimiento_CalendarExtender" runat="server" 
                                 TargetControlID="txtFechaNacimiento" PopupButtonID=ImageButton2></asp:CalendarExtender>
                            </td>
                    </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Teléfono:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="27%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="txtTelefono" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Email:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="40%"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="txtEmail" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td style="width: 118px" valign="top">
                        Estado:</td>
                    <td style="width: 289px">
                       <asp:DropDownList ID="ddlEstado" runat="server" CssClass="gral_drop">
                            <asp:ListItem Value=1>Habilitado</asp:ListItem>
                            <asp:ListItem Value=0>Deshabilitado</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>                
                <tr>
                    <td style="width: 118px" valign="top">
                        Idioma:</td>
                    <td style="width: 289px">
                        <asp:DropDownList ID="ddlIdioma" runat="server" CssClass="gral_drop">
                            <asp:ListItem>Español</asp:ListItem>
                            <asp:ListItem>Ingles</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="ddlIdioma" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
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
                        Familias:</td>
                    <td style="width: 289px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        &nbsp;</td>
                    <td style="width: 289px">
                        <table width="100%">
                            <tr>
                                <td rowspan="2">
                                    <asp:ListBox ID="lstFamilias" runat="server" CssClass="gral_text_box" 
                                        Width="200px"></asp:ListBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnAgregarFamilia" runat="server" CssClass="gral_button" 
                                        Text="&gt;&gt;" ValidationGroup="AMFamilia" />
                                    <asp:RequiredFieldValidator ID="rfvFamilia" runat="server" 
                                        ControlToValidate="lstFamilias" Display="Dynamic" Enabled="true" 
                                        Font-Size="Small" ValidationGroup="AMFamilia">*</asp:RequiredFieldValidator>
                                </td>
                                <td rowspan="2">
                                    <asp:ListBox ID="lstFamiliasFinal" runat="server" CssClass="gral_text_box" 
                                        Width="200px"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnQuitarFamilia" runat="server" CssClass="gral_button" 
                                        Text="&lt;&lt;" ValidationGroup="AMFamiliaFinal" />
                                    <asp:RequiredFieldValidator ID="rfvFamilia0" runat="server" 
                                        ControlToValidate="lstFamiliasFinal" Display="Dynamic" Enabled="true" 
                                        Font-Size="Small" ValidationGroup="AMFamiliaFinal">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="hlNuevaFamilia" runat="server" CssClass="gral_link" 
                                        NavigateUrl="~/webForms/AdminFamiliasForm.aspx">Nueva familia</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="center" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top" align="center" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 118px;" valign="top">
                        Patentes individuales:</td>
                    <td style="width: 289px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 118px;" valign="top">
                        &nbsp;</td>
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
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="height: 10px;" valign="top">
                        &nbsp;</td>
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

