<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_ConsultarVentasForm" title="Start - Consulta de ventas" Codebehind="ConsultarVentasForm.aspx.vb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language=javascript>
 var mostrar=0;
 function Avanzada() {
     var row = document.getElementById("trAvanzada");
     if (mostrar == 1) {
         row.style.visibility = "hidden";
        
         mostrar = 0;
      }
      else {
          row.style.visibility = "visible";
          
          mostrar = 1;
      }
      return false;
  }
 </script>
    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">C</span>onsulta de ventas</span></p>
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
          <asp:Panel ID="Panel1"  runat="server" CssClass="data_panel" Width="725px">          
          <table style="padding-right:5px; padding-top: 5px; height: 10px;" cellpadding="0" 
                  cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="7"   align=center>
                        Filtros de búsqueda</td>
                </tr>
                <tr>
                    <td style="width: 118px" align="right">
                        Usuario:</td>
                    <td style="width: 36px">
                         <asp:DropDownList ID="ddlUsuarios" runat="server" CssClass="gral_drop">
                            
                        </asp:DropDownList>
                    </td>
                    <td style="width: 85px" align="right">
                        Fecha:</td>
                    <td class="style9" style="width: 54px">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtFecha" runat="server" CssClass="gral_text_box"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" 
                                        ImageUrl="~/Images/gral_icon_calendar.jpg" />
                                  <asp:CalendarExtender  Format="dd/MM/yyyy" ID="txtFecha_CalendarExtender" runat="server" 
                                     TargetControlID="txtFecha" PopupButtonID=ImageButton2>
                                 </asp:CalendarExtender>     
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                        ControlToValidate="txtFecha" Display="Dynamic" Font-Size="Small" 
                                        meta:resourcekey="RequiredFieldValidator6Resource1" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                    <a class="gral_link"  onclick="Avanzada()" >Búsqueda avanzada</a></td>
                    <td style="width: 78px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr id="trAvanzada" style="visibility:hidden;">
                    <td style="width: 118px; ">
                        </td>
                    <td colspan="4">
                        <table class="data_panel_advanced" style="width: 100%">
                            <tr>
                                <td>
                                    Tipo de Pago:</td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoPago" runat="server" CssClass="gral_drop">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    Producto:</td>
                                <td>
                                    <asp:DropDownList ID="ddlProductos" runat="server" CssClass="gral_drop" 
                                        Height="26px" Width="116px">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    Monto:</td>
                                <td>
                                    <asp:TextBox ID="txtMonto" runat="server" CssClass="gral_text_box" 
                                        Height="16px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 118px">
                        </td>
                    <td style="width: 36px">
                        </td>
                    <td style="width: 85px">
                        </td>
                    <td style="width: 54px">
                        <asp:Button ID="btnBuscar" runat="server" CssClass="gral_button" 
                            Text="Buscar" />
                        </td>
                    <td>
                        </td>
                    <td>
                        &nbsp;</td>
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
                                                 <td style="height: 16px">
                                               <asp:HyperLink  ID="hlSeleccionar" Visible=true NavigateUrl=<%# "AdminPagosForm.aspx?ventaId=" & DataBinder.Eval(Container.DataItem, "Identificador")%>  runat="server" CssClass="gral_link">Asociar pago</asp:HyperLink>
                                               </td>
                                            </tr>
                                           </table>
                                </ItemTemplate>
                                <ItemStyle  CssClass="LetraFecha" />
                                <HeaderStyle CssClass="celdaGrilla" />
                                </asp:TemplateField>
                                 <asp:BoundField DataField="Usuario" HeaderText="Usuario">
                                  <HeaderStyle CssClass="celdaGrilla" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Productos" HeaderText="Productos">
                                   <HeaderStyle CssClass="celdaGrilla" />
                                    <ItemStyle CssClass="letraGeneral" Width="50%" />                                
                                </asp:BoundField>
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                    <HeaderStyle CssClass="celdaGrilla" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Importe" HeaderText="Precio total">
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

