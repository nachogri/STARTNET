<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_ResumenCuentaForm" title="Start - Resumen cuenta" Codebehind="ResumenCuentaForm.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
 <span class="LetraFormateadaNegra"><span class="LetraFormateada">S</span>aldo de cuenta</span>
            <table cellpadding="0" cellspacing="0" class="LetraGeneral">
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
            <tr>
                    <td style="width: 374px">
                        </td>
                    <td style="width: 638px">
                        Última factura</td>
                     <td style="width: 168px">
                         </td>
                    <td style="width: 330px">
                        $<asp:Label ID="lblSaldoUltimaFactura" runat="server"></asp:Label>
                    </td>
                    <td style="width: 330px">
                        &nbsp;</td>
                </tr>               
                <tr>
                    <td style="width: 374px; height: 2px;">
                        </td>
                    <td style="width: 638px; height: 2px;">
                        Pagos y bonificaciones posteriores</td>
                     <td style="width: 168px; height: 2px;" align="right">
                         -</td>
                    <td style="width: 330px; height: 2px;">
                        $<asp:Label ID="lblPago" runat="server"></asp:Label>
                    </td>
                    <td style="width: 330px; height: 2px;">
                        &nbsp;</td>
                </tr>               
                <tr>
                    <td style="width: 374px">
                        </td>
                    <td style="width: 638px">
                        </td>
                    <td style="width: 168px">
                        </td>
                    <td>
                        </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 374px">
                        </td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 638px;"></td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 168px;"></td>
                    <td style="background-image: url('../resources/images/menu_separator.gif'); width: 330px;"></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 374px; height: 25px;">
                        </td>
                    <td style="width: 638px; height: 25px;">
                        </td>
                    <td style="width: 168px; height: 25px;">
                        <a>
                        <b>Total a pagar:</b></a></td>
                    <td style="width: 330px; height: 25px;">
                        <a>
                        <b>$<asp:Label ID="lblTotalAPagar" runat="server"></asp:Label>
                        </b></a></td>
                    <td style="width: 330px; height: 25px;">
                        &nbsp;</td>
                </tr>
                </table><span class="LetraFormateadaNegra">
    <span class="LetraFormateada">T</span>us compras</span>
    <table cellpadding="0" cellspacing="0" class="LetraGeneral">
        <tr class="LetraFormateadaNegra">
            <td style="width: 88px; ">
                &nbsp;</td>
            <td colspan="5">
                        <asp:GridView ID="grvVentas" runat="server" AutoGenerateColumns="False" 
                            BorderColor="#CACACA" BorderWidth="0px" CellPadding="0" CssClass="LetraGeneral" 
                            GridLines="Horizontal" PageSize="5" 
                            Width="100%">
                            <Columns>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                    <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
                                    <ItemStyle CssClass="LetraFecha"  />
                                </asp:BoundField>
                                <asp:BoundField DataField="Productos" HeaderText="Productos">
                                   <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
                                    <ItemStyle CssClass="LetraChicaNegra" Width="50%" />                                
                                </asp:BoundField>
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                    <HeaderStyle CssClass="celdaLetraFormateadaNegra" />
                                    <ItemStyle CssClass="letraGeneral" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Importe" HeaderText="Precio total">
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
            <td style="width: 109px">
                        &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 88px">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 175px;">
            </td>
            <td style="background-image: url('../resources/images/menu_separator.gif'); width: 1579px;">
            </td>
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
            </td>
            <td style="width: 1579px; height: 18px;">
            </td>
            <td style="height: 18px; width: 237px;">
                        <a>
                        <b>Total consumido:</b></a></td>
            <td style="height: 18px; width: 106px;">
                        <a>
                        <b>$<asp:Label ID="lblTotal" runat="server"></asp:Label>
                        </b></a>
            </td>
            <td style="width: 330px; height: 18px;">
            </td>
            <td style="width: 109px; height: 18px;">
                &nbsp;</td>
        </tr>
    </table>
    </div>
<div>
    <span class="LetraFormateadaNegra"><span class="LetraFormateada">
    O</span>tras estadísticas</span>
<table cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr align="left">
                    <td style="width: 31px; height: 2px;">
                        </td>
                    <td style="width: 87px; height: 2px;" align="left">
                        Aportes en el sitio:</td>
                    <td style="width: 175px; height: 2px;" align="left">
                        </td>
                    <td style="width: 278px; height: 2px;" align="left">
                    </td>
                </tr>
               <tr align="left">
                    <td style="width: 31px">
                        </td>
                    <td style="width: 87px" align="left">
                        </td>
                    <td style="width: 175px" align="left">
                        Descargas:</td>
                    <td style="width: 278px" align="left">
                        0</td>
                </tr>
                <tr align="left">
                    <td style="width: 31px">
                        </td>
                    <td style="width: 87px" align="left">
                        </td>
                    <td style="width: 175px" align="left">
                        Comentarios en foro:</td>
                    <td style="width: 278px" align="left">
                        0</td>
                </tr>
                <tr align="left">
                    <td style="width: 31px">
                        </td>
                    <td style="width: 87px" align="left">
                        </td>
                    <td style="width: 175px" align="left">
                        Utilización de mesa de ayuda:</td>
                    <td style="width: 278px" align="left">
                        0</td>
                </tr>
                <tr>
                    <td style="width: 31px; height: 13px;">
                        </td>
                    <td style="width: 87px; height: 13px;">
                        </td>
                    <td style="width: 175px; height: 13px;">
                        Mensajes:</td>
                    <td style="width: 278px; height: 13px;">
                        0</td>
                </tr>
                <tr>
                    <td style="width: 31px">
                        </td>
                    <td colspan="2">
                        </td>
                    <td>
                        </td>
                </tr>
                </table>
                </div>
                <div>
    <span class="LetraFormateadaNegra"><span class="LetraFormateada">
    D</span>atos personales</span>
<table cellpadding="0" cellspacing="0" class="LetraGeneral" align="left" >
                <tr align="left">
                    <td style="width: 31px; height: 2px;">
                        </td>
                    <td style="width: 87px; height: 2px;" align="left">
                        <asp:HyperLink ID="HyperLink17" runat="server" CssClass="gral_link" 
                            NavigateUrl="~/webForms/AltaUsuariosForm.aspx?Modo=M">Actualizar</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td style="width: 31px">
                        </td>
                    <td>
                        </td>
                </tr>
                </table>
                </div>
                 </asp:Content>

