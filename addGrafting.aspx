<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addGrafting.aspx.cs" Inherits="AdversaryArchiveWeb.addItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
        .auto-style2 {
            width: 175px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" Orientation="Horizontal" StaticSubMenuIndent="10px">
                <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#B5C7DE" />
                <DynamicSelectedStyle BackColor="#507CD1" />
                <Items>
                    <asp:MenuItem NavigateUrl="~/" Text="Home" Value="Home"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/StatDisplay.aspx" Text="Stat Display" Value="Stat Display"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/addNPC.aspx" Text="Add NPC" Value="Add NPC"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/addStats.aspx" Text="Add Statblock" Value="Add Statblock"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/addInventory.aspx" Text="Add Inventory Item" Value="Add Inventory Item"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/linkStats.aspx" Text="Link Stats" Value="Link Stats"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#507CD1" />
            </asp:Menu>
            <br />
            New Grafting<br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        Name:
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;
&nbsp;<asp:DropDownList ID="typeList" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label5" runat="server" Text="Price: "></asp:Label>
                        <asp:TextBox ID="TextBox7" runat="server" Width="43px"></asp:TextBox>
                        C</td>
                    <td>
                        <asp:Label ID="label2" runat="server">Humanity Loss: </asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server" Width="13px"></asp:TextBox>
                        d6</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="miscLabel" runat="server">Details: </asp:Label>
&nbsp;<asp:TextBox ID="txtMisc" runat="server" Width="339px" Height="49px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:Label ID="errorLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
