<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" CodeFile="DesarrolladoresForm.aspx.vb" Inherits="WebForms_DesarrolladoresForm" title="Start - Desarrolladores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">D</span>esarrolladores</span></p>
<span class="LetraFormateadaNegra">
<div > Si sos desarrollador de video juegos independiente podes dejar tu anuncio en nuestro sitio 
    haciendo click en el carrito de compras. </div></span>
          <table style="padding-right:5px; " 
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td style="width: 88px; height: 23px;">
                        &nbsp;</td>
                    <td style="height: 23px">
                        &nbsp;</td>
                    <td style="width: 562px; height: 23px;" align="right">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 88px; height: 23px;">
                        </td>
                    <td style="height: 23px">
                        </td>
                    <td style="width: 562px; height: 23px;" align="right">
<span class="LetraFormateadaNegra">
                        <asp:Imagebutton PostBackUrl="~/webForms/AnuncioForm.aspx" ID="Image4" runat="server" 
                            ImageUrl="~/Images/carrito.jpg" />
                        </span>
                        </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td rowspan="3">
                        <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/enix-logo.jpg" />
                    </td>
                    <td style="width: 562px">
                        <a>
                        <b class="LetraFormateadaNegraBold">Enix</b></a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 562px">
                        <span>Creamos historias y personajes; les 
damos un espacio, reglas simples y 
controles para que cualquier ser vivo 
los controle, los recuerde y se lo cuente 
a todos sus amigos</span></td>
                </tr>
                <tr>
                     <td style="width: 88px">
                        </td>
                    <td style="width: 562px">
                        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="gral_link" 
                            NavigateUrl="">Web</asp:HyperLink>
                    &nbsp;- Telefono: <% %>
                        - Email: <% %>
                    &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td colspan="2" 
                        style="background-image: url('../resources/images/menu_separator.gif')" 
                        height="1"></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td>
                        </td>
                    <td style="width: 562px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td rowspan="3">
                        <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/thq-logo.jpg" />
                    </td>
                    <td style="width: 562px">
                        <a>
                        <b class="LetraFormateadaNegraBold">THQ Desarrollos </b></a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 562px">
                        <span>THQ Inc. (NASDAQ: THQI) es un desarrollador y editor de software de entretenimiento interactivo de fama mundial. La empresa desarrolla sus productos para los sistemas de juego, ordenadores personales y dispositivos inalámbricos más populares. Con sus oficinas centrales en Los Ángeles, California, THQ vende productos a través de su red global de oficinas ubicadas en América del norte, Europa y la costa del Pacífico de Asia.
                        </span></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 562px">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="gral_link" 
                            NavigateUrl="">Web</asp:HyperLink>
                    &nbsp;- Telefono: <% %>
                        - Email: <% %>
                    &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td colspan="2" 
                        style="background-image: url('../resources/images/menu_separator.gif')" 
                        height="1"></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td>
                        </td>
                    <td style="width: 562px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td rowspan="3">
                        <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/evolution-logo.jpg" />
                    </td>
                    <td style="width: 562px">
                        <a>
                        <b class="LetraFormateadaNegraBold">Evolution dreams studio</b></a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 562px">
                        <span>Evolution Dreams Studio S.L. es un estudio joven e independiente de desarrollo de ocio interactivo digital.

La misión de la empresa consiste en ofrecer juegos atractivos, sencillos e inmediatos para que la gente disfrute al máximo de su tiempo de ocio. De esta forma tiene una orientación hacia los videojuegos de corte casual, sin olvidar ofrecer mecánicas innovadoras que satisfagan al público más exigente.

                        </span></td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td style="width: 562px">
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="gral_link" 
                            NavigateUrl="">Web</asp:HyperLink>
                    &nbsp;- Telefono: <% %>
                        - Email: <% %>
                    &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 88px">
                        </td>
                    <td colspan="2" 
                        style="background-image: url('../resources/images/menu_separator.gif')" 
                        height="1"></td>
                </tr>
                </table>

</asp:Content>

