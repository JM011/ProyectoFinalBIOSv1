<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMUsuario.aspx.cs" Inherits="ABMUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <form id="form1" runat="server">
        <div class="container">
            <br />
            <span style="font-size: 14pt; color: #006699; text-decoration: underline"><strong>Mantenimiento a Usuario</strong></span><br />
            <br />
            <br />
            <table border="1" style="margin: 0 auto;">
                <tr>
                    <td style="width: 94px; height: 21px">
                        Nombre de usuario:</td>
                    <td style="width: 100px; height: 21px">
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox></td>
                    <td style="width: 100px; height: 21px">
                        <asp:Button ID="btnBuscar" runat="server" Font-Bold="True" 
                            Text="Buscar" OnClick="btnBuscar_Click" /></td>
                </tr>
                <tr>
                    <td style="width: 94px">
                        Nombre:</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 94px">
                        Apellido:</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                    </td>
                </tr>
                            <tr>
                    <td style="width: 94px">
                        Contraseña:</td>
                    <td style="width: 100px">
                        <input id="txtContrasena" type="password" runat="server" /></td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnAlta" runat="server" Font-Bold="True" OnClick="btnAlta_Click"
                            Text="Alta" />
                        <asp:Button ID="BtnModificar" runat="server" Font-Bold="True" 
                            Text="Modificar" OnClick="BtnModificar_Click" Enabled="False" />
                        <asp:Button ID="btnBaja" runat="server" Font-Bold="True" 
                            Text="Eliminar" OnClick="btnBaja_Click" Enabled="False" />
                    </td>
                    <td align="center" colspan="1">
                        <asp:Button ID="btnLimpiar" runat="server" Font-Bold="True" OnClick="btnLimpiar_Click"
                            Text="Limpiar" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>&nbsp;<br />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    
        </div>
        </form>
    </body>
</html>
