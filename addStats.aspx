<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addStats.aspx.cs" Inherits="AdversaryArchiveWeb.addStats" %>

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
            <asp:Label ID="Label1" runat="server" Text="New Stats"></asp:Label>
            <table class="auto-style1">
                <tr>
                    <td>Stat Name:</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                    <td>Role:</td>
                    <td>
                        <asp:TextBox ID="txtRole" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">HP:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtHP" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">Role Level</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtRoleLvl" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>EMP:</td>
                    <td>
                        <asp:TextBox ID="txtEMP" runat="server"></asp:TextBox>
                    </td>
                    <td>Initiative:</td>
                    <td>
                        <asp:TextBox ID="txtInitiative" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>LUCK:</td>
                    <td>
                        <asp:TextBox ID="txtLUCK" runat="server"></asp:TextBox>
                    </td>
                    <td>Facedown:</td>
                    <td>
                        <asp:TextBox ID="txtFacedown" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>MOVE:</td>
                    <td>
                        <asp:TextBox ID="txtMOVE" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>BODY:</td>
                    <td>
                        <asp:TextBox ID="txtBODY" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Melee:</td>
                    <td>
                        <asp:TextBox ID="txtMelee" runat="server"></asp:TextBox>
                    </td>
                    <td>Ranged:</td>
                    <td>
                        <asp:TextBox ID="txtRanged" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Autofire:
                        <asp:CheckBox ID="boolAutofire" runat="server" AutoPostBack="True" OnCheckedChanged="boolAutofire_CheckedChanged" />
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtAutofire" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style2">Martial Arts:
                        <asp:CheckBox ID="boolMartialArts" runat="server" AutoPostBack="True" OnCheckedChanged="boolMartialArts_CheckedChanged" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtMartialArts" runat="server" Visible="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Heavy Weapons:
                        <asp:CheckBox ID="boolHeavyWeapons" runat="server" AutoPostBack="True" OnCheckedChanged="boolHeavyWeapons_CheckedChanged" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtHeavyWeapons" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td>Athletics: <asp:CheckBox ID="boolAthletics" runat="server" AutoPostBack="True" OnCheckedChanged="boolAthletics_CheckedChanged" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtAthletics" runat="server" Visible="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Brawling:</td>
                    <td>
                        <asp:TextBox ID="txtBrawling" runat="server"></asp:TextBox>
                    </td>
                    <td>Evasion:</td>
                    <td>
                        <asp:TextBox ID="txtEvasion" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Resist T/D:</td>
                    <td>
                        <asp:TextBox ID="txtResistTD" runat="server"></asp:TextBox>
                    </td>
                    <td>Concentration:</td>
                    <td>
                        <asp:TextBox ID="txtConcentration" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Perception:</td>
                    <td>
                        <asp:TextBox ID="txtPerception" runat="server"></asp:TextBox>
                    </td>
                    <td>Stealth:</td>
                    <td>
                        <asp:TextBox ID="txtStealth" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Social:</td>
                    <td>
                        <asp:TextBox ID="txtSocial" runat="server"></asp:TextBox>
                    </td>
                    <td>Insight:</td>
                    <td>
                        <asp:TextBox ID="txtInsight" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Clear" />
            <br />
            <asp:Label ID="errorLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
