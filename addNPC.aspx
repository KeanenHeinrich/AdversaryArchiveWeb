<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNPC.aspx.cs" Inherits="AdversaryArchiveWeb.addNPC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
        .auto-style2 {
            height: 23px;
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
        <br />
        <asp:Label ID="Label1" runat="server" Text="New NPC"></asp:Label>
        <table class="auto-style1">
            <tr>
                <td>Handle: </td>
                <td>
                    <asp:TextBox ID="txtHandle" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td>Type:</td>
                <td>
                    <asp:TextBox ID="txtType" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>First Name:</td>
                <td>
                    <asp:TextBox ID="txtFName" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td>Tier:</td>
                <td>
                    <asp:TextBox ID="txtTier" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Surname: </td>
                <td>
                    <asp:TextBox ID="txtSName" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td>Player Relationship:</td>
                <td>
                    <asp:TextBox ID="txtRelationship" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Gender: </td>
                <td>
                    <asp:TextBox ID="txtGender" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td>Location:</td>
                <td>
                    <asp:TextBox ID="txtLocation" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Age:</td>
                <td>
                    <asp:TextBox ID="txtAge" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td>Alive:</td>
                <td>
                    <asp:CheckBox ID="boolAlive" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Occupation:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtOccupation" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="auto-style2">Organisation: </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="organisationList" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        Bio:&nbsp;
        <asp:TextBox ID="txtBio" runat="server" AutoPostBack="True" Height="23px" Width="477px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Clear" />
        <br />
        <br />
        <asp:Label ID="errorLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
