<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebForms/Main.Master" CodeBehind="ConsultarEncuestasForm.aspx.vb" Inherits="START_Website.ConsultarEncuestasForm" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">C</span>onsulta de encuesta de satisfacción</span></p>
 <table cellpadding="0" cellspacing="0" class="LetraGeneral" width="100%">
                <tr>
                    <td style="width: 88px">
                        <asp:CustomValidator ID="cuGeneral" runat="server" 
            Visible="False">*</asp:CustomValidator></td>
                    <td colspan="3">
                        <asp:ValidationSummary ID="vsMensajes" runat="server"  class=gral_Summary 
                            Visible="False" CssClass="gral_summary" />
                        </td>
                </tr></table>
<div style="text-align:center">
              <div style="padding-left:20px">
          <asp:Panel ID="Panel1"  runat="server" CssClass="data_panel" Width="249px">          
          <table style="padding-right:5px; padding-top: 5px; height: 25px; width: 27px;" cellpadding="0" 
                  cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="3"   align=center>
                        Filtros de búsqueda</td>
                </tr>
                <tr>
                    <td style="width: 118px">
                        Usuario:</td>
                    <td style="width: 139px">
                         <asp:DropDownList ID="ddlUsuarios" runat="server" CssClass="gral_drop">
                            
                        </asp:DropDownList>
                </tr>
                <tr>
                    <td style="width: 118px">Fecha:</td>
                    <td style="width: 139px">                        
                        <table cellspacing=0 cellpadding=0 border=0>
                         <tr>
                            <td><asp:TextBox ID="txtFecha" CssClass=gral_text_box runat="server"></asp:TextBox></td>
                            <td>&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" 
                                     ImageUrl="~/Images/gral_icon_calendar.jpg" /></td>
                            <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                     ControlToValidate="txtFecha" Display="Dynamic" Font-Size="Small" 
                                     meta:resourcekey="RequiredFieldValidator6Resource1" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        </table>     
                        <asp:CalendarExtender  Format="dd/MM/yyyy" ID="txtFechaNacimiento_CalendarExtender" runat="server" 
                                     TargetControlID="txtFecha" PopupButtonID=ImageButton2>
                                 </asp:CalendarExtender>
                    </td>                    
                    
                </tr>
                <tr>
                    <td style="width: 118px">
                        Calificación:</td>
                    <td style="width: 139px">
                        <asp:DropDownList ID="ddlRespuesta" runat="server" CssClass="gral_drop">
                                <asp:ListItem Value="5">Excelente</asp:ListItem>
                                <asp:ListItem Value="4">Muy buena</asp:ListItem>
                                <asp:ListItem Value="3">Regular</asp:ListItem>
                                <asp:ListItem Value="2">Malo</asp:ListItem>
                                <asp:ListItem Value="1">Muy malo</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                </tr>
                <tr>
                    <td style="width: 118px">
                        &nbsp;</td>
                    <td style="width: 139px">
                        &nbsp;</td>
                    <td style="width: 54px">
                        <asp:Button ID="btnBuscar" runat="server" CssClass="gral_button" 
                            Text="Buscar" />
                    </td>
                </tr>
                </table>
          </asp:Panel></div></div>
    <table cellpadding="0" cellspacing="0" class="LetraGeneral">
        <tr class="LetraFormateadaNegra">
            <td style="width: 88px; height: 30px;">
                &nbsp;</td>
            <td style="width: 486px; height: 30px;">
                        &nbsp;</td>
            <td style="width: 175px; height: 30px;">
                        &nbsp;</td>
            <td style="width: 1579px; height: 30px;">
                        &nbsp;</td>
            <td style="width: 278px; height: 30px;">
                        &nbsp;</td>
            <td style="width: 278px; height: 30px;">
                        &nbsp;</td>
            <td style="width: 330px; height: 30px;">
                        &nbsp;</td>
        </tr>
        <tr class="LetraFormateadaNegra">
            <td style="width: 88px; height: 30px;">
            </td>
            <td style="height: 30px;" colspan="6">
                        <asp:GridView ID="grvVentas" runat="server" AutoGenerateColumns="False" 
                            BorderColor="#CACACA" BorderWidth="0px" CellPadding="0" CssClass="LetraGeneral" 
                            GridLines="Horizontal" 
                            Width="100%" AllowPaging="True">
                            <Columns>
                            <asp:TemplateField HeaderText="Fecha">
                                <ItemTemplate >
                                         <table style="padding-right:5px; "  cellpadding="0" cellspacing="0" class="LetraGeneral" >
                                            <tr>
                                                <td>
                                                      <asp:Label ID="lblFecha" CssClass=LetraFecha runat="server"><%#DataBinder.Eval(Container.DataItem, "Fecha")%></asp:Label>                        
                                                </td>                                                 
                                            </tr>
                                           </table>
                                </ItemTemplate>
                                <ItemStyle  CssClass="LetraFecha" />
                                <HeaderStyle CssClass="celdaGrilla" />
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="Usuario">
                                <ItemTemplate >
                                         <table style="padding-right:5px; "  cellpadding="0" cellspacing="0" class="LetraGeneral" >
                                            <tr>
                                                <td>
                                                      <asp:Label ID="lblUsuario" CssClass=LetraChicaNegra runat="server"><%#DataBinder.Eval(Container.DataItem, "Usuario.Nickname")%></asp:Label>                        
                                                </td>
                                            </tr>
                                           </table>
                                </ItemTemplate>
                                <ItemStyle  CssClass="LetraFecha" />
                                <HeaderStyle CssClass="celdaGrilla" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Pregunta1" HeaderText="Experiencia">
                                  <HeaderStyle CssClass="celdaGrilla" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>                               
                                <asp:BoundField DataField="Pregunta2" HeaderText="Catálogo">
                                  <HeaderStyle CssClass="celdaGrilla" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>                                
                                <asp:BoundField DataField="Pregunta3" HeaderText="Carrito">
                                  <HeaderStyle CssClass="celdaGrilla" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Pregunta4" HeaderText="MesaAyuda">
                                  <HeaderStyle CssClass="celdaGrilla" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Pregunta5" HeaderText="Soporte">
                                  <HeaderStyle CssClass="celdaGrilla" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Pregunta6" HeaderText="Comunidad">
                                  <HeaderStyle CssClass="celdaGrilla" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>                                                               
                            </Columns>
                            <PagerStyle CssClass="gral_link" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#DFDFDF" />
                            <HeaderStyle BorderStyle="None" BorderWidth="0px" CssClass="LetraChicaNegra" 
                                HorizontalAlign="Left" />
                        </asp:GridView>
                        </td>
        </tr>
        <tr>
            <td style="width: 88px">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 486px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 175px;">
                </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 1579px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 278px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 278px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 330px;">
            </td>
        </tr>
        <tr>
            <td style="width: 88px; height: 18px;">
            </td>
            <td style="width: 486px; height: 18px;">
            </td>
            <td style="width: 175px; height: 18px;">
                &nbsp;</td>
            <td style="width: 1579px; height: 18px;">
            </td>
            <td style="height: 18px">
                &nbsp;</td>
            <td style="height: 18px">
            </td>
            <td style="width: 330px; height: 18px;">
            </td>
        </tr>
    </table>

</asp:Content>
