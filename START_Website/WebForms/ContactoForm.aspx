<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_ContactoForm" title="Start - Contáctenos" Codebehind="ContactoForm.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<span class="LetraFormateadaNegra"><span class="LetraFormateada">C</span>ontáctenos<div class=celdaGrilla>
        <br />
El éxito de Start.com se logra manteniendo un alto nivel de comunicación tanto con nuestros clientes, como con nuestros empleados y proveedores. 
        <br />
        Para ello les ofrecemos las siguientes vías de contacto directo:
        <br />

    <br />    
    <table>
        <tr><td><img src="../Images/emailContact.jpg" /></td><td><a class=gral_link href="mailto:info@start.com">info@start.com</a></td></tr>
    </table>        
    <table>
        <tr><td><img src="../Images/phoneContact.jpg" /></td><td>Argentina: +54 11 6981 1544</td></tr>
    </table>
     <table>
        <tr><td><img src="../Images/homeContact.jpg" /> </td><td>H.Primo 844, 1103 CABA</a></td></tr>
    </table>
    <br />
    <span class="LetraFormateadaNegra"><span class="LetraFormateada">S</span>íganos</span>
    <table>
        <tr>
        <td><asp:ImageButton ID="ImageButton1" runat=server PostBackUrl="http://www.facebook.com" ImageUrl="~/Images/facebook.gif" /></td>
        <td><asp:ImageButton ID="ImageButton2" runat=server PostBackUrl="http://www.linkedin.com" ImageUrl="~/Images/linkedin.gif" /></td>
        <td><asp:ImageButton ID="ImageButton3" runat=server PostBackUrl="http://www.twitter.com" ImageUrl="~/Images/twitter.gif" /></td></tr>
    </table>    
    <br />
   Si lo desea, puede dejarnos un mensaje y un representante de atención al cliente se comunicará a la brevedad con usted.
</div>
<table style="padding-right:5px; padding-top: 5px;" 
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td style="width: 709px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td>
     <asp:CustomValidator ID="cuGeneral" runat="server" Visible="False">*</asp:CustomValidator>
                    </td>
                    <td style="width: 709px">
                        <asp:ValidationSummary ID="vsMensajes" runat="server"  class=gral_Summary 
                            Visible="False" CssClass="gral_summary" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td>
                        Tipo:</td>
                    <td style="width: 709px">
                        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="gral_drop">
                            <asp:ListItem>Sugerencia</asp:ListItem>
                            <asp:ListItem>Consulta</asp:ListItem>
                            <asp:ListItem>Queja</asp:ListItem>
                            <asp:ListItem>Opinión de producto</asp:ListItem>                                                       
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td valign="top">
                        Mensaje:</td>
                    <td style="width: 709px">
                        <asp:TextBox ID="txtMensaje" runat="server"  Width="100%" CssClass="gral_text_box" 
                            Height="183px" TextMode="MultiLine" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td align="center">
                        <asp:Button ID="BtnEnviar" runat="server" CssClass="gral_button" 
                            Text="Enviar" />
                    </td>
                </tr>
                </table>
    </span></asp:Content>
                

