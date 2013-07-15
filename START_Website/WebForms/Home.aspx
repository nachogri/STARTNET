<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_Home" meta:resourcekey="PageResource1" Codebehind="Home.aspx.vb" culture="auto" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">    
    <div  style=" float:right; width:20%">
        <div>
            <asp:Label ID="Label15" runat="server" CssClass="LetraFormateada" meta:resourcekey="Label5Resource1"
                Text="P" />
            <asp:Label class="LetraFormateadaNegra" ID="Label16" runat="server" meta:resourcekey="Label6Resource1"
                Text="romociones" />
            <div align="center">
                <div align="left">
             <asp:Label class="LetraFormateadaNegra" ID="Label3" runat="server" 
                        CssClass=LetraGeneral meta:resourcekey="Label3Resource1"  />                    <br />                   
                     <asp:GridView ID="grvPromos" runat="server" AutoGenerateColumns="False"
                                BorderStyle="None" GridLines="None" 
    style="padding-right:5px; " cellpadding="0" 
    class="LetraGeneral" BorderWidth="0px" PageSize="3" 
    Font-Bold="False" Font-Names="Arial" Font-Size="XX-Small" 
    Font-Underline="False" Width="100%" meta:resourcekey="grvPromosResource1" >
    <Columns>
    <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
        <ItemTemplate>
         <table style="padding-right:5px; " 
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td >
                     <img height=30px width=30px src="../images/hot.jpg" /></div>
                        </td>                   
                    <td>
                        <a>
                            <asp:Label ID="lblPromociones" class="&quot;LetraFormateada" runat="server" 
                            meta:resourcekey="lblPromocionesResource1"  ><%#DataBinder.Eval(Container.DataItem, "nombre")%></asp:Label>                        
                    </td>
                </tr>
                <tr>
                    <td style="height: 48px">
                        </td>
                    <td style="height: 48px">
                        Descripción: <asp:Label ID="lblVigencia" runat="server" 
                            meta:resourcekey="lblVigenciaResource1"><%#DataBinder.Eval(Container.DataItem, "requisitos")%></asp:Label><br />
                        Vencimiento: <asp:Label ID="lblRequisitos" runat="server" 
                            meta:resourcekey="lblRequisitosResource1" ><%#DataBinder.Eval(Container.DataItem, "expiracion")%></asp:Label>
                    </td>
                    <td style="height: 48px">
                    </td>
                </tr>              
                  <tr>
                    <td>
                        </td>
                    <td colspan="2" 
                        style="background-image: url('../images/menu_separator.gif')" 
                        height="1"></td>
                    <td 
                        style="background-image: url('../images/menu_separator.gif')" 
                        height="1"></td>
                </tr>
                </table>
        </ItemTemplate>        
        </asp:TemplateField>
    </Columns>
    <PagerStyle HorizontalAlign="Center" Font-Size="X-Small" Font-Underline="False" 
        ForeColor="#789200"  />
</asp:GridView>
                </div>
            </div>
        </div> 
    </div>
    <div style="width:80%" >    
    <div style="padding-top: 5px;>
        <div style="float:left; width:40%">
         <table>
         <tr><td>
             <asp:CustomValidator ID="cuGeneral" runat="server" CssClass="LetraGeneral" 
                 Display="Dynamic" meta:resourcekey="cuGeneralResource1" >*</asp:CustomValidator>
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                 CssClass="gral_summary" meta:resourcekey="ValidationSummary1Resource1" />
             </td></tr>
            <tr>
                <td colspan="3">
                    <div style="padding-right: 0px; padding-left: 0px; width: 736px;">
                        <asp:Label ID="Label5" runat="server" CssClass="LetraFormateada" meta:resourcekey="Label80Resource"
                            Text="J" />
                        <asp:Label class="LetraFormateadaNegra" ID="Label6" runat="server" meta:resourcekey="Label81Resource"
                            Text="uegos" /><br />
                        <div align="left">
                            <asp:Label ID="Label7" runat="server" meta:resourcekey="Label7Resource1" Text="Venta de los mejores Video Juegos, todas las consolas y accesorios disponibles. Conocé nuestros propios juegos y creaciones! y unite a la comunidad de desarrollo..."></asp:Label>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        </div>          
        <div align="center">
            <table>
                <tr>
                    <td>
                        <div align="center">
                            <img src="../images/cover.gif" /></div>
                    </td>
                    <td>
                        <div align="center">
                            <img src="../images/transformers-el-juego-ps3.jpg" />
                        </div>
                    </td>
                    <td>
                        <img src="../images/Game_For_XBOX_360_Lost_Planet.jpg" />
                    </td>
                    <td>
                        <img src="../Images/ResidentEvil4WiiEdition.jpg" style="width: 200px; height: 231px" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <div>
            <div style="width=50%; float=left;">
                <asp:Label ID="Label9" runat="server" class="LetraFormateada" meta:resourcekey="Label19Resource1"
                    Text="C"></asp:Label>
                <asp:Label class="LetraFormateadaNegra" ID="Label10" runat="server" meta:resourcekey="Label110Resource1"
                    Text="onsolas y "></asp:Label>
                <asp:Label ID="Label1" runat="server" class="LetraFormateada" meta:resourcekey="Label9Resource1"
                    Text=" A"></asp:Label>
                <asp:Label class="LetraFormateadaNegra" ID="Label2" runat="server" meta:resourcekey="Label10Resource1"
                    Text="ccesorios"></asp:Label>
                <div style="padding-top: 5px">
                    <asp:Label ID="Label8" runat="server" meta:resourcekey="Label8Resource1" Text="Consolas WII, PC, PSP, PlayStation 2, gamecube, Xbox, gameboy advance, muchísimos accesorios, información y descargas. Todo lo que necesitás en un sólo lugar..."></asp:Label>
                </div>
            </div>
            <div align="center">
                <table>
                    <tr>
                        <td>
                            <div align="center">
                                <img src="../Images/xbox360-logo.jpg" style="width: 157px; height: 111px" /></div>
                        </td>
                        <td>
                            <div align="center">
                                <img src="../Images/ps3-logo.jpg" style="width: 159px; height: 109px" />
                            </div>
                        </td>
                        <td style="width: 179px;">
                            <img src="../Images/wii-logo.jpg" style="width: 167px; height: 107px" />
                        </td>
                        <td style="width: 179px;">
                            <img src="../Images/wii-jois-logo.jpg" style="width: 167px; height: 107px" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div style="padding-top: 15px">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 83%">
                    <div style="padding-left: 0px">
                        <span class="LetraFormateadaNegra">
                            <asp:Label ID="Label12" runat="server" meta:resourcekey="Label12Resource1" Text="Venta y envíos al"></asp:Label>
                            <span class="LetraFormateada">&nbsp;<asp:Label ID="Label14" runat="server" meta:resourcekey="Label14Resource1"
                                Text="I"></asp:Label>
                            </span>
                            <asp:Label ID="Label13" runat="server" meta:resourcekey="Label13Resource1" Text="nterior y al por mayor"></asp:Label>
                            <div style="padding-top: 5px">
                                <asp:Label ID="Label11" runat="server" meta:resourcekey="Label11Resource1" Text="Nos especializamos en la venta y reparación de consolas, venta de juegos, accesorios. Realizamos envíos a domicilio. También disponemos de un amplio servicio especializado. "></asp:Label>
                                &nbsp;</div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </div>
</asp:Content>
