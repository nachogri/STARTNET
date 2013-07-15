<%@ Page Language="VB" MasterPageFile="~/WebForms/Main.Master" AutoEventWireup="false" Inherits="START_Website.WebForms_NovedadesForm" title="Start - Novedades" Codebehind="NovedadesForm.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p><span class="LetraFormateadaNegra"><span class="LetraFormateada">N</span>ovedades</span></p>
     <asp:CustomValidator ID="cuGeneral" runat="server" Visible="False">*</asp:CustomValidator>
 <table cellpadding="0" cellspacing="0" class="LetraGeneral" width="100%">
                <tr>
                    <td style="width: 88px"></td>
                    <td colspan="3">
                        <asp:ValidationSummary ID="vsMensajes" runat="server"  class=gral_Summary 
                            Visible="False" CssClass="gral_summary" />
                        </td>
                </tr></table>
        <span class="LetraFormateadaNegra">
        <div > Estas son las novedades del mundo tecnológico de la semana:</div></span>
<table style="padding-right:5px; " 
                cellpadding="0" cellspacing="0" class="LetraGeneral" width="100%" >
                <tr>
                    <td style="width: 88px; height: 23px;">
                        &nbsp;</td>
                    <td style="height: 23px">
                  </td>
                </tr>
                <tr>
                    <td style="width: 88px; height: 23px;">
                        &nbsp;</td>
                    <td style="height: 23px">
           
<asp:GridView ID="grvNovedades"  runat="server" AutoGenerateColumns="False" 
    Width="100%" BorderStyle="None" GridLines="None" 
    style="padding-right:5px; " cellpadding="0" cellspacing="0" 
    class="LetraGeneral" BorderWidth="0px" AllowPaging="True" PageSize="2" 
    Font-Bold="False" Font-Names="Arial" Font-Size="XX-Small" 
    Font-Underline="False" >
    <Columns>
    <asp:TemplateField >
        <ItemTemplate>
         <table style="padding-right:5px; width:90% " 
                cellpadding="1" cellspacing="1" class="LetraGeneral" >
                <tr>
                    <td>
                        </td>
                    <td rowspan="3" style="width:10px">                       
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/webForms/hlrImageLoader.ashx?Table=Novedades&Id=" & DataBinder.Eval(Container.DataItem, "Identificador").ToString()%>'/> 
                    </td>
                    <td>
                        <a>
                            <asp:Label ID="lblTitulo" class="LetraFormateadaNegraBold" runat="server"><%#DataBinder.Eval(Container.DataItem, "Titulo")%></asp:Label>                        
                    </td>                                        
                </tr>
                <tr>
                    <td style="height: 48px">
                        </td>
                    <td style="height: 48px">
                        <asp:Label ID="lblDescripcion" runat="server"><%#DataBinder.Eval(Container.DataItem, "Descripcion")%></asp:Label><br />                        
                    </td>
                    <td style="height: 48px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 16px">
                        </td>
                   <td style="height: 16px">
                        <asp:HyperLink ID="hlAmpliar" runat="server" CssClass="gral_link" NavigateUrl='<%# "~/webForms/DetalleForm.aspx?Table=Novedades&Id=" & DataBinder.Eval(Container.DataItem, "Identificador").ToString()%>'>Ampliar</asp:HyperLink>
                    </td>
                   <td style="height: 16px">
                        </td>
                </tr>
                  <tr>
                    <td>
                        </td>
                    <td colspan="2" 
                        style="background-image: url('../resources/images/menu_separator.gif')" 
                        height="1"></td>
                    <td 
                        style="background-image: url('../resources/images/menu_separator.gif')" 
                        height="1"></td>
                </tr>
                </table>
        </ItemTemplate>        
        </asp:TemplateField>
    </Columns>
    <PagerStyle HorizontalAlign="Center" Font-Size="X-Small" Font-Underline="False" 
        ForeColor="#789200"  />
</asp:GridView>
                        </td>
                </tr>                
                </table>
           
</asp:Content>

