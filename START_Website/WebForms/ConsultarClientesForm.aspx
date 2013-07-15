<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_ConsultarClientesForm" title="Start - Consulta de clientes" Codebehind="ConsultarClientesForm.aspx.vb" %>

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
    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">C</span>onsulta de clientes</span></p>
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
          <asp:Panel ID="Panel2"  runat="server" CssClass="data_panel" Width="543px">          
          <table style="padding-right:5px; padding-top: 5px; height: 25px; width: 547px;" cellpadding="0" 
                  cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="7"   align=center>
                        Filtros de búsqueda</td>
                </tr>
                <tr>
                    <td style="width: 118px">
                        Nickname:</td>
                    <td style="width: 139px">
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="gral_text_box" 
                            Height="17px"></asp:TextBox>
                    </td>
                    <td class="style9" style="width: 106px">
                        Nombre:</td>
                    <td style="width: 147px">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="104px"></asp:TextBox>
                    </td>
                    <td style="width: 147px">
                        <asp:CheckBox ID="chkCliente" runat="server" Checked="True" Text="Cliente" />
                    </td>
                    <td colspan="2">
                        <a class="gral_link" onclick="Avanzada()">Búsqueda avanzada</a></td>
                </tr>
                     <tr id="trAvanzada" style="visibility:hidden;">
                    <td style="width: 118px; ">
                        </td>
                    <td colspan="5">
                        <table class="data_panel_advanced" style="width: 100%">
                            <tr>
                                <td class="style9" style="width: 106px">
                                 Email:</td>
                                <td style="width: 147px">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="gral_text_box" 
                            Height="17px"></asp:TextBox>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                        Documento:</td>
                    <td style="width: 78px">
                        <asp:TextBox ID="txtDocumento" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="66px"></asp:TextBox>
                    </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                            <asp:CheckBox ID="chkDesarrollador" runat="server" Text="Desarrollador" /></td>
                                <td>
                                    
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
                        <td align="center" colspan="3" valign="top">
                          
                        </td>
                        <td align="center" valign="top">
                            &nbsp;</td>
                        <td align="center" valign="top">
                            &nbsp;</td>
                        <td align="center" style="width: 191px" valign="top">
                            &nbsp;</td>
                        <td align="center" valign="top">
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
                        <asp:GridView ID="grvClientes" runat="server" AutoGenerateColumns="False" 
                            BorderColor="#CACACA" BorderWidth="0px" CellPadding="0" CssClass="LetraGeneral" 
                            GridLines="Horizontal" 
                            Width="100%" AllowPaging="True">
                            <Columns>                           
                                 <asp:BoundField DataField="Nickname" HeaderText="Usuario">
                                  <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                   <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
                                    <ItemStyle CssClass="letraGeneral"  />                                
                                </asp:BoundField>   
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido">
                                   <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
                                    <ItemStyle CssClass="letraGeneral"  />                                
                                </asp:BoundField>                                
                                <asp:BoundField DataField="NroDoc" HeaderText="Documento">
                                    <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email">
                                  <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
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
        </table>

<span class="LetraFormateadaNegra">
    </span>

</asp:Content>

