<%@ Page Title="" Language="vb" AutoEventWireup="false" EnableEventValidation="false" MasterPageFile="~/WebForms/Main.Master" CodeBehind="AdminProveedoresForm.aspx.vb" Inherits="START_Website.WebForms_AdminProveedoresForm" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <span class="LetraFormateadaNegra"><span class="LetraFormateada">A</span>dministración 
        de Proveedores</span>
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
                        <asp:GridView ID="grvProveedores" runat="server" AutoGenerateColumns="False" 
                            GridLines="Horizontal" Width="100%" AllowPaging="True" AllowSorting="True" 
                            PageSize="5" BorderWidth="0px" CellPadding="0" 
                            DataKeyNames="Identificador" OnRowDataBound=grvProveedores_RowDataBound 
                            CssClass="LetraGeneral" BorderColor="#CACACA">
                            <Columns>                                
                                <asp:TemplateField HeaderText="Título">
                                <ItemTemplate >
                                         <table style="padding-right:5px; "  cellpadding="0" cellspacing="0" class="LetraGeneral" >
                                            <tr>
                                                <td>
                                                      <asp:Label ID="lblNombre" CssClass=LetraChicaNegra runat="server"><%#DataBinder.Eval(Container.DataItem, "Nombre")%></asp:Label>                        
                                                </td>
                                            </tr>
                                            <tr>
                                               <td style="height: 16px">
                                               <asp:HyperLink  ID="hlSeleccionar"  runat="server" CssClass="gral_link" >Seleccionar</asp:HyperLink>
                                               </td>
                                            </tr>
                                           </table>
                                </ItemTemplate>
                                <ItemStyle  CssClass="celdaGrilla" />
                                <HeaderStyle CssClass="celdaGrilla" />
                                </asp:TemplateField>                                
                                <asp:BoundField  HeaderText="Email" DataField="Email" >
                                <ItemStyle  CssClass="celdaGrilla" />    
                                <HeaderStyle CssClass="celdaGrilla" />                        
                                </asp:BoundField>
                                <asp:BoundField  HeaderText="Teléfono" DataField="Telefono" 
                                    DataFormatString="{0:dd-MM-yyyy}" >
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
                        <asp:Button ID="btnAgregarProveedor" 
                        runat="server" CssClass="gral_button" Text="Agregar" />&nbsp;<asp:Button 
                        ID="btnEliminarProveedor" runat="server" CssClass="gral_button" 
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
          <asp:Panel ID="Panel2"  runat="server" CssClass="data_panel" Width="60%">
          <table style="padding-right:5px; padding-top: 5px;"  width=100%
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td colspan="2"   align=center>
                        Datos de Proveedor</td>
                </tr>
               <tr>
                    <td style="width: 15px" valign="top">
                        Nombre:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="gral_text_box" 
                            Height="17px" Width="37%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv0" runat="server" 
                            ControlToValidate="txtNombre" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15px" valign="top">
                        Email:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="29%" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtEmail" Enabled=true  Font-Size="Small" ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td style="width: 15px" valign="top">
                        Teléfono:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="gral_text_box" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtTelefono" Enabled=true  Font-Size="Small" 
                            ValidationGroup="AMProducto">*</asp:RequiredFieldValidator>
                       
                    </td>
                </tr>                 
               
               
                <tr>
                    <td style="width: 15px">
                        Productos:</td>
                    <td style="width: 289px">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td rowspan="2">
                                                <asp:ListBox ID="lstProductos" runat="server" CssClass="gral_text_box" 
                                                    Width="200px"></asp:ListBox>
                                            </td>
                                            <td>
                                            
                                                &nbsp; Precio:</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:Button ID="btnAgregarProducto" runat="server" CssClass="gral_button" 
                                                    Text="&gt;&gt;" ValidationGroup="AMProducto" />
                                                <asp:RequiredFieldValidator ID="rfvProducto" runat="server" 
                                                    ControlToValidate="lstProductos" Display="Dynamic" Enabled="true" 
                                                    Font-Size="Small" ValidationGroup="AMProducto">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td rowspan="2">
                                                <asp:ListBox ID="lstProductosFinal" runat="server" CssClass="gral_text_box" 
                                                    Width="200px"></asp:ListBox>
                                                <asp:RequiredFieldValidator ID="rfvProducto1" runat="server" 
                                                    ControlToValidate="lstProductosFinal" Display="Dynamic" Enabled="true" 
                                                    ErrorMessage="Debe tener al menos 1 producto asociado" Font-Size="Small" 
                                                    ValidationGroup="AMSubmit">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtPrecio" runat="server" CssClass="LetraGeneral" Width="51px"></asp:TextBox>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                    ControlToValidate="txtPrecio" Font-Size="Small" Operator="DataTypeCheck" 
                                                    Type="Double">*</asp:CompareValidator>
                                                <asp:RequiredFieldValidator ID="rfvProducto2" runat="server" 
                                                    ControlToValidate="txtPrecio" Display="Dynamic" Enabled="true" 
                                                    Font-Size="Small" ValidationGroup="AMProducto">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:Button ID="btnQuitarProducto" runat="server" CssClass="gral_button" 
                                                    Text="&lt;&lt;" ValidationGroup="AMProductoFinal" />
                                                <asp:RequiredFieldValidator ID="rfvProducto0" runat="server" 
                                                    ControlToValidate="lstProductosFinal" Display="Dynamic" Enabled="true" 
                                                    Font-Size="Small" ValidationGroup="AMProductoFinal">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table></td>                                
                            </tr>
                        </table>
                    </td>
                </tr>                
                <tr>
                    <td style="width: 15px" valign="top">
                        Domicilio:</td>
                    <td align="left" style="width: 289px">
                        <asp:TextBox ID="txtDomicilio" runat="server" CssClass="gral_text_box" 
                            Height="43px" TextMode="MultiLine" Width="307px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtTelefono" Enabled="true" Font-Size="Small" 
                            ValidationGroup="AMProducto">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="height: 21px;" valign="top">
                        <asp:Button ID="btnAceptar" runat="server" CssClass="gral_button" Height="16px" 
                            Text="Aceptar" />
                    </td>
                </tr>
                </table>
          </asp:Panel></div>
        <div style="padding-left:30px">
          </div>

</asp:Content>
