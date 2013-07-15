<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebForms/Main.Master" CodeBehind="RecuperoForm.aspx.vb" Inherits="START_Website.RecuperoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
            <tr>
                <td colspan="3">
                    <div style="padding-right: 0px; padding-left: 0px;">
                        <asp:Label ID="Label5" runat="server" CssClass="LetraFormateada" meta:resourcekey="Label80Resource"
                            Text="R" />
                        <asp:Label class="LetraFormateadaNegra" ID="Label6" runat="server" meta:resourcekey="Label81Resource"
                            Text="ecuperar contraseña" /><br />
                    </div>
                </td>
            </tr>
        </table>
<br />
                        <div align="left">
                            <br />
                            <asp:Label ID="Label1" runat="server" Text="La contraseña se le enviará a su casilla de email."></asp:Label>
                            <br />
                            <br />
                            <table style="width:100%;">
                                <tr>
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td style="width: 64px">
                                        Usuario:</td>
                                    <td style="width: 92px">
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="gral_text_box"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td style="width: 64px">
                                        &nbsp;</td>
                                    <td style="width: 92px">
                                        &nbsp;</td>
                                    <td>
                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="gral_button" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                        </div>
                    </asp:Content>
