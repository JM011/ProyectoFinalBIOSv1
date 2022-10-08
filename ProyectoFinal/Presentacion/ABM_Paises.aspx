<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABM_Paises.aspx.cs" Inherits="ABM_Paises" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <body>
        <form id="form1" runat="server">
            <div>
            <span>ABM de Países</span>
            <table>
                <tr>
                    <td>
                        Código:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
<%--                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nombre:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />                        
                    </td>
                </tr>
            </table>
            </div>
            
        </form>
    </body>
</html>
