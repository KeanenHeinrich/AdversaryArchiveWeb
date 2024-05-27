<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addGrafting.aspx.cs" Inherits="AdversaryArchiveWeb.addInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
        .auto-style2 {
            width: 222px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
        <div>
            <br />
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:DropDownList ID="npcList" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="typeList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="typeList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="itemList" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Item" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="qualityList" runat="server" Visible="False">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Clear" />
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ammoList" runat="server" Visible="False">
                        </asp:DropDownList>
&nbsp;
                        <asp:TextBox ID="txtAmmo" runat="server" Width="24px" Visible="False"></asp:TextBox>
&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="attachment1" runat="server" Visible="False">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="attachment2" runat="server" Visible="False">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="attachment3" runat="server" Visible="False">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Label ID="errorLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
