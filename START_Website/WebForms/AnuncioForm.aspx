<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" CodeFile="AnuncioForm.aspx.vb" Inherits="WebForms_AnuncioForm" title="Start - Compra de anuncios " %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">C</span>omprar espacio publicitario</span></p>
          <div style="padding-left:30px; height: 21px;">
          </div>
          <div style="height:2px"></div>
          
          <div style="padding-left:30px">
          <asp:Panel ID="Panel2"  runat="server" CssClass="data_panel" Width="60%">
                <table style="padding-right:5px;  padding-top: 5px;" width=100%
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                 <tr>
                    <td colspan="2"  align=center>
                        Datos comerciales</td>
                </tr>
                <tr>
                    <td style="width: 129px">
                        Razon social:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="gral_text_box" 
                            Height="16px" Width="56%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 129px" valign="top">
                        Descripción del producto:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="gral_text_box" 
                            Height="94px" Width="100%" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 129px" valign="top">
                        Comentarios:</td>
                    <td style="width: 289px">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="gral_text_box" 
                            Height="104px" Width="100%" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 129px" valign="top">
                        Duración del anuncio:</td>
                    <td style="width: 289px">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="gral_drop">
                            <asp:ListItem>3 meses</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                    <tr>
                        <td style="width: 129px" valign="top">
                            Valor:</td>
                        <td style="width: 289px">
                            $120</td>
                    </tr>
                
                </table>
          </asp:Panel></div>
               <div style="padding-left:30px">
          </div>
          <div style="height:2px"></div>
           <div style="height:20px"></div>
          <div style="padding-left:30px">
              <table style="padding-right:5px; padding-top: 5px;"  width=100%
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
                <tr>
                    <td valign="top" style="width: 363px">
                        Has leído y comprendido nuestra&nbsp;
                        <asp:HyperLink ID="HyperLink16" runat="server" CssClass="gral_link">Política de 
                        privacidad</asp:HyperLink>&nbsp;y
                        <asp:HyperLink ID="HyperLink17" runat="server" CssClass="gral_link">Términos de 
                        uso</asp:HyperLink>
                        ?</td>
                    <td>
                        <asp:CheckBox ID="CheckBox3" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="width: 363px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="height: 38px">
                        <asp:Button ID="Button1" runat="server" CssClass="gral_button" 
                            Text="Comprar" />
                    </td>
                </tr>
                </table></div>

</asp:Content>

