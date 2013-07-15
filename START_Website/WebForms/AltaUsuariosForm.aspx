<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_AltaUsuariosForm" title="Start - Registro" Codebehind="AltaUsuariosForm.aspx.vb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">R</span>egistro 
     de usuarios</span></p>
<span class="LetraFormateadaNegra">
<div> Bienvenido. Llená tus datos personales y formá parte de nuestra comunidad..<span >. :)</span></div></span>
         <asp:CustomValidator ID="cuGeneral" runat="server" 
            Visible="False" meta:resourcekey="cuGeneralResource1">*</asp:CustomValidator>
 <table cellpadding="0" cellspacing="0" class="LetraGeneral" width="100%">
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td colspan="3">
                        <asp:ValidationSummary ID="vsMensajes" runat="server"  class=gral_Summary 
                            Visible="False" CssClass="gral_summary" 
                            meta:resourcekey="vsMensajesResource1" />
                        </td>
                </tr></table> 
          <div style="height:20px"></div>
          <div style="padding-left:30px">
          <asp:Panel  runat="server" CssClass="data_panel" Width="60%" 
                  meta:resourcekey="PanelResource1">
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
                            Height="17px" Width="37%" meta:resourcekey="txtNicknameResource1"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfv0" runat="server" 
                            ControlToValidate="txtNickname"  Font-Size="Small" 
                            ValidationGroup="AMSubmit" meta:resourcekey="rfv0Resource1">*</asp:RequiredFieldValidator>
                    
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Contraseña:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="37%" TextMode="Password" 
                            meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtPassword"  Font-Size="Small" 
                            ValidationGroup="AMSubmit" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
                    
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Repita contraseña:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtPassword2" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="37%" TextMode="Password" 
                            meta:resourcekey="txtPassword2Resource1"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtPassword2"  Font-Size="Small" 
                            ValidationGroup="AMSubmit" meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator>
                    
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Email:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="27%" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                     ControlToValidate="txtEmail" Display="Dynamic" Font-Size="Small" 
                                     ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                </table>
          </asp:Panel></div>
          <div style="height:2px"></div>
          
          <div style="padding-left:30px">
          <asp:Panel ID="Panel1"  runat="server" CssClass="data_panel" Width="60%" 
                  meta:resourcekey="Panel1Resource1">
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
                            Height="16px" Width="56%" meta:resourcekey="txtNombreResource1"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtNombre"  Font-Size="Small" 
                            ValidationGroup="AMSubmit" meta:resourcekey="RequiredFieldValidator3Resource1">*</asp:RequiredFieldValidator>
                    
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Apellido:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="56%" meta:resourcekey="txtApellidoResource1"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtApellido"  Font-Size="Small" 
                            ValidationGroup="AMSubmit" meta:resourcekey="RequiredFieldValidator4Resource1">*</asp:RequiredFieldValidator>
                    
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Tipo de documento:</td>
                    <td style="width: 289px">
                        <asp:DropDownList ID="ddlDNI" runat="server" CssClass="gral_drop" 
                            meta:resourcekey="ddlDNIResource1">
                            <asp:ListItem Value="DNI" meta:resourcekey="ListItemResource1">DNI</asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource2">LE</asp:ListItem>
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="ddlDNI"  Font-Size="Small" ValidationGroup="AMSubmit" 
                            meta:resourcekey="RequiredFieldValidator5Resource1">*</asp:RequiredFieldValidator>
                    
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Nro. de documento:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtDocumento" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="27%" meta:resourcekey="txtDocumentoResource1"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtDocumento"  Font-Size="Small" 
                            ValidationGroup="AMSubmit" 
                            meta:resourcekey="RequiredFieldValidator6Resource1" Display="Dynamic">*</asp:RequiredFieldValidator>
                    
                    </td>
                </tr>
                    <tr>
                        <td style="width: 118px" valign="top">
                            Fecha de nacimiento:</td>
                        <td >
                                                    
                        <table cellspacing=0 cellpadding=0 border=0>
                         <tr>
                            <td><asp:TextBox ID="txtFechaNacimiento" CssClass=gral_text_box runat="server" 
                                    ></asp:TextBox></td>
                            <td>&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" 
                                     ImageUrl="~/Images/gral_icon_calendar.jpg" /></td>
                            <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                     ControlToValidate="txtFechaNacimiento" Display="Dynamic" Font-Size="Small" 
                                     meta:resourcekey="RequiredFieldValidator6Resource1" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                            </td>
                            <td></td>
                        </tr>
                        </table>     
                        <asp:CalendarExtender  Format="dd/MM/yyyy" ID="txtFechaNacimiento_CalendarExtender" runat="server" 
                                     TargetControlID="txtFechaNacimiento" PopupButtonID=ImageButton1>
                                 </asp:CalendarExtender>                                           
                        </td>
                    </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Teléfono:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="27%" meta:resourcekey="txtTelefonoResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                     ControlToValidate="txtTelefono" Display="Dynamic" Font-Size="Small" 
                                     ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>                
                 <%--<tr>
                    <td style="width: 118px" valign="top">
                        CUIL:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtCUIL" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="27%" ></asp:TextBox>                            
                    </td>
                </tr>
                 <tr>
                    <td style="width: 118px" valign="top">
                        CUIT:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtCUIT" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="27%" ></asp:TextBox>
                    </td>
                </tr>  --%>
                 <tr>
                        <td style="width: 118px" valign="top">
                            Condicion IVA:</td>
                        <td style="width: 289px">
                            <asp:DropDownList ID="ddlVA" runat="server" CssClass="gral_drop" 
                                meta:resourcekey="ddlDNIResource1" >                                
                                <asp:ListItem Value="1">Responsable Inscripto</asp:ListItem>
                                <asp:ListItem Value="2">Responsable No Inscripto</asp:ListItem>
                                <asp:ListItem Selected="True" Value="3">Consumidor Final</asp:ListItem>
                            </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="rfvddlVA" runat="server" 
                                     ControlToValidate="ddlVA" Display="Dynamic" Font-Size="Small" 
                                     ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>              
                    <tr>
                        <td style="width: 118px" valign="top">
                            Idioma:</td>
                        <td style="width: 289px">
                            <asp:DropDownList ID="ddlIdioma" runat="server" CssClass="gral_drop" 
                                meta:resourcekey="ddlIdiomaResource1">
                                <asp:ListItem meta:resourcekey="ListItemResource3">Español</asp:ListItem>
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                     ControlToValidate="ddlIdioma" Display="Dynamic" Font-Size="Small" 
                                     ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
          </asp:Panel></div>
          <div style="height:2px"></div>
               <div style="padding-left:30px">
          <asp:Panel ID="Panel2"  runat="server" CssClass="data_panel" Width="60%" 
                       meta:resourcekey="Panel2Resource1">
          <table style="padding-right:5px; padding-top: 5px;"  width=100%
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="2"   align=center>
                        Datos de domicilio</td>
                </tr>
               <tr>
                    <td style="width: 118px" valign="top">
                        Tipo:</td>
                    <td style="width: 289px">
                        <asp:DropDownList ID="ddlDomicilio" runat="server" CssClass="gral_drop" 
                            meta:resourcekey="ddlDomicilioResource1">
                            <asp:ListItem meta:resourcekey="ListItemResource4">Casa</asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource5">Departamento</asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource6">PH</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvddlDomicilio" runat="server" 
                                     ControlToValidate="ddlDomicilio" Display="Dynamic" Font-Size="Small" 
                                     ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Calle:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtCalle" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="68%" meta:resourcekey="txtCalleResource1"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                     ControlToValidate="txtCalle" Display="Dynamic" Font-Size="Small" 
                                     ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Número:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtNumero" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="19%" meta:resourcekey="txtNumeroResource1"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                     ControlToValidate="txtNumero" Display="Dynamic" Font-Size="Small" 
                                     ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        País</td>
                    <td style="width: 289px">
                    <table cellpadding=0 cellspacing=0><tr><td>
                        <asp:DropDownList ID="ddlPais" runat="server" CssClass="gral_drop" 
                            AutoPostBack="True" meta:resourcekey="ddlPaisResource1">
                        </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                     ControlToValidate="ddlPais" Display="Dynamic" Font-Size="Small" 
                                     ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                        </td><td>
                            
                            &nbsp;
                            
                        </td></tr></table>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Provincia</td>
                    <td style="width: 289px">
                        <table cellpadding=0 cellspacing=0><tr><td>
                        <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="gral_drop" 
                                AutoPostBack="True" meta:resourcekey="ddlProvinciaResource1">
                        </asp:DropDownList>       <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                     ControlToValidate="ddlProvincia" Display="Dynamic" Font-Size="Small" 
                                     ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator></td><td>
                            
                                &nbsp;
                            
                        </td></tr></table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 118px" valign="top">
                        Localidad</td>
                    <td style="width: 289px">
                        <table cellpadding=0 cellspacing=0><tr><td>
                        <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="gral_drop" 
                                meta:resourcekey="ddlLocalidadResource1">
                        </asp:DropDownList>       <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                     ControlToValidate="ddlLocalidad" Display="Dynamic" Font-Size="Small" 
                                     ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator></td><td>
                            
                                &nbsp;
                            
                        </td></tr></table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" valign="top" align="center">
                        &nbsp;</td>
                </tr>
                </table>
          </asp:Panel></div>
          <div style="height:2px"></div>
           <div style="height:20px"></div>
          <div style="padding-left:30px">
              <table style="padding-right:5px; padding-top: 5px;"  width=100%
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td valign="top" style="width: 431px">
                        Desarrollador (solo para desarrolladores independientes de video juegos) </td>
                    <td>
                        <asp:CheckBox ID="chkDesarrollador" runat="server" 
                            meta:resourcekey="chkDesarrolladorResource1" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="width: 431px">
                        ¿Desea recibir nuestro newsletter con las novedades destacadas?</td>
                    <td>
                        <asp:CheckBox ID="chkNewsletter" runat="server" 
                            meta:resourcekey="chkNewsletterResource1" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="width: 431px">
                        Has leído y comprendido nuestra&nbsp;
                        <asp:HyperLink ID="HyperLink16" runat="server" CssClass="gral_link" 
                            NavigateUrl="~/webForms/CopyrightForm.aspx" 
                            meta:resourcekey="HyperLink16Resource1">Política de 
                        privacidad</asp:HyperLink>
                        ?</td>
                    <td>
                        <asp:CheckBox ID="chkCondiciones" runat="server" 
                            meta:resourcekey="chkCondicionesResource1" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="width: 431px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="height: 38px">
                        <asp:Button ID="btnAceptar" runat="server" CssClass="gral_button" 
                            Text="Registrarse" ValidationGroup="AMSubmit" 
                            meta:resourcekey="btnAceptarResource1" />
                    </td>
                </tr>
                </table></div>
</asp:Content>

